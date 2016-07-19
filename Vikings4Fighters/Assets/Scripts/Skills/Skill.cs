using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

	//who can be the target of the skill. For example: skill "Health" - target "Friend", skill "Strike" - target "Enemy"
	public enum SkillTarget{Enemies, Friends, Myself}
	public SkillTarget skillTarget;

	//the effect which can add when released
	public SkillEffect.Effects addedEffect;

	// The icon of the skill
	public Sprite SkillIcon;

	// The Name of the Skill
	public string SkillName;

	// Skill level
	public int SkillLevel;

	// Modifier for damage
	public float damageModifier;

	// Modifier for accuracy
	public float accuracyModifier;

	// Modifier for critChance
	public float critChanceModifier;

	// Modifier for crit damage
	public float critDamageModifier;

	//the number of targets for skill
	public int targetsQuantity;

	// the position of which can use this skill (need for Inspector)
	public bool[] CanUseInPositions;

	// at which positions can hit (need for Inspector)
	public bool[] CanToGetTarget;

	//the list of the mathcing positions
	protected List<Character> rightTargets = new List<Character>();

	//reference to this Skill Button
	private Button skillButton;

	//active or not active this Skill
	public bool IsActive { get; set;}

	//Reference to "Character" component of my character
	public Character myCharacter { get; set;}

	//current Skill Damage
	public int SkillDamage {
		get{ 
			float characterDamage = myCharacter.Damage.RandomDamage;
			int skillDamage = 0;
			float accuracy = Mathf.Clamp (myCharacter.Accuracy + accuracyModifier, 0, 100);
			if (Random.Range (0, 100 + 1) > accuracy) {
				//is Miss
				return 0;
			} 

			// if Critical or not
			if (Random.Range (0, 100 + 1) > myCharacter.CriticalChance + critChanceModifier) {
				//not
				skillDamage = (int)(characterDamage + (characterDamage * damageModifier));
			} else {
				//CritHit
				Debug.Log("!!!CRITICAL!!!");
				skillDamage = (int)((float)myCharacter.Damage.MaxDamage * (myCharacter.CriticalModifare + critDamageModifier));
			}
			return  (skillTarget == SkillTarget.Friends) ? -skillDamage : skillDamage;
		}
	}

	//
	public SkillsManager MySkillManager { 
		get{ 
			return myCharacter.skillsManager;
		} 
	}

	//Средний урон от скилла
	public float AverageSkillDamage{
		get { 
			return myCharacter.Damage.AverageDamage + (myCharacter.Damage.AverageDamage * damageModifier);
		}
	}


	public string GetDamageString(){
		int minDmg = (int)(myCharacter.Damage.MinDamage + (myCharacter.Damage.MinDamage * damageModifier));
		int maxDmg = (int)(myCharacter.Damage.MinDamage + (myCharacter.Damage.MaxDamage * damageModifier));
		return minDmg.ToString () + " - " + maxDmg.ToString();
	}


	public string GetAccuracyString(){
		int accuracy = (int)Mathf.Clamp ((myCharacter.Accuracy + accuracyModifier), 0, 100);
		return accuracy.ToString();
	}

	//set the SkillButton parametres
	public Button SkillButton{
		get{
			return skillButton;
		}
		set{
			skillButton = value;
			skillButton.GetComponentInChildren<SkillDragElement> ().currentSkill = this;
		}
	}

	//Возвращает цели по которым может попасть данный скилл
	public List<Character> RightTargets{
		get{
			rightTargets.Clear ();

			if (skillTarget == SkillTarget.Myself) {
				rightTargets.Add (myCharacter);
				return rightTargets;
			}

			CharacterManager targetsCharManager = GetRightTargetManager();
			for (int i = 0; i < targetsCharManager.LiveCharacters.Count; i++) {
				if (CanToGetTarget [i]) {
					if (targetsCharManager.LiveCharacters[i] != null) {
						rightTargets.Add (targetsCharManager.LiveCharacters [i]);
					}
				}		
			}
			return rightTargets;
		}
	}

	// Can I use this Skill now? 
	public bool CanUseInCurrentPosition{
		get{
			CharacterManager myCharManager = null;
			if (myCharacter.myEssences == Character.Essences.Enemy) {
				myCharManager = EnemiesManager.Instance;
			} else {
				myCharManager = HeroesManager.Instance;
			}

			if (myCharManager == null) {
				print ("Не назначено место героя в CharacterManager");
				return false;
			} else {
				int index = myCharManager.GetCharacterArrayIndexFor (myCharacter);
				return CanUseInPositions [index];
			}
		}
	}

	//method of damage for Heroes!
	public void ActivateSkillOnButton (){
		if (!IsActive) {
			Debug.Log ("Character " + myCharacter.name + " - activated skill: " + SkillName);
			IsActive = true;
			MySkillManager.ActiveSkill = GetComponent<Skill> ();
			StartCoroutine ("DamageCoroutine");
		}
	}


	protected IEnumerator DamageCoroutine (){
		Character targetEnemy = null;
		while (targetEnemy == null) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if (hit.collider != null && IsRightTarget(hit.collider.GetComponent<Character>())) {
					targetEnemy = hit.collider.GetComponent<Character>();
					UseSkillToTarget (targetEnemy);
				}	
			}
			if (!IsActive) break;
			yield return null;
		}
	} 


	public void UseSkillToTarget(Character target){
		for (int i = 0; i < RightTargets.Count; i++) {
			if (target == RightTargets[i]) {
				for (int x = 0; x < targetsQuantity; x++) {
					int arrayIndex = i + x;
					if (arrayIndex == RightTargets.Count)
						arrayIndex -= RightTargets.Count;

					int currentSkillDamage = SkillDamage;
					RightTargets [arrayIndex].GetDamage (currentSkillDamage);
					if (addedEffect != SkillEffect.Effects.None && Mathf.Abs(currentSkillDamage) > 0) {
						AddEffect(RightTargets [arrayIndex], addedEffect, currentSkillDamage);
					}
				}
				UI_Controller.Instance.ShowSkill (SkillName);               
				myCharacter.NextTurn ();
			}
		}
	}


	public CharacterManager GetRightTargetManager(){
		if (myCharacter.myEssences == Character.Essences.Hero) {
			if (skillTarget == Skill.SkillTarget.Enemies) {
				return EnemiesManager.Instance;
			} else {
				return HeroesManager.Instance;
			}
		} else {
			if (skillTarget == Skill.SkillTarget.Enemies) {
				return HeroesManager.Instance;
			} else {
				return EnemiesManager.Instance;
			}
		}
	}

	// Added some Effect, Like "Stun"
	protected void AddEffect (Character target, SkillEffect.Effects addEffect, int damage){
		System.Type effectType = SkillEffect.GetEffect (addEffect);
		target.gameObject.AddComponent(effectType);
		SkillEffect effect = (SkillEffect)target.GetComponent (effectType);
		effect.damage = damage;
	}


	public bool IsRightTarget(Character target){
		foreach (Character character in RightTargets) {
			if (target == character)
				return true;
		}
		return false;
	}


	public void SetSkillTarget(string skillTargetName){
		for (skillTarget = SkillTarget.Enemies; skillTarget <= SkillTarget.Myself; skillTarget++)
			if (skillTarget.ToString() == skillTargetName)
				break;
	}

	public void SetAddedEffect(string effectName){
		for (addedEffect = SkillEffect.Effects.None; addedEffect <= SkillEffect.Effects.Grapner; addedEffect++)
			if (addedEffect.ToString() == effectName)
				break;
	}
}
