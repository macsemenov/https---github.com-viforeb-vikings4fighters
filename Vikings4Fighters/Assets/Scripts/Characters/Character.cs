using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public enum Essences{Enemy, Hero}
	public Essences myEssences;

	public PersonalCanvas personalCanvas;

	//protected PersonalEnventory;

	public ParticleSystem activeEffect;
	public string CharacterName { get; set;}
	public int Accuracy{ get; set;}
	public int CriticalChance{ get; set;}
	public int CriticalModifare{ get; set;}
	public Damage Damage{ get; set;}
	public int Defense{ get; set;}
	public Health Health{ get; set;}
	public Initiative Initiative{ get; set;}
	public CharacterRole Role{ get; set;}
	public Experience Experience{ get; set;}

	protected bool isActive;

	public delegate void TurnAction ();
	public event TurnAction OnEndTurn;
	public event TurnAction OnStartTurn;

	void Start(){
        tag = myEssences.ToString();
    }

	public float Agro {
		get{ 
			return Role.GetAgro ();
		}
	}


	public SkillsManager skillsManager{
		get{
			return GetComponent<SkillsManager> ();
		}
	}


	//set and get Active state
	public bool IsActive{
		get{
			return isActive;
		}
		set {
			if (value == true) {

				if(myEssences == Essences.Hero)
					SkillButtons.instance.AssignSkillsToButtons (skillsManager.Skills);
				
				if(OnStartTurn != null)
					OnStartTurn ();
			}
			
			isActive = value;
			if (activeEffect != null) {
				if (value == true)
					activeEffect.Play ();
				else {
					activeEffect.Stop ();
					activeEffect.Clear ();
				}
			}  
		}
	}


	public virtual void GetDamage(int currDamage){
		Health.CurrentHP -= currDamage;
		personalCanvas.ShowDamage (currDamage);
		if (Health.CurrentHP <= 0) {
			Destroy(gameObject, 0.5f);
		}
	}


	public IEnumerator MoveTo (Vector2 position){
		while (Mathf.Abs (transform.position.x - position.x) > 0.2f) {
			transform.position = Vector2.Lerp (transform.position, new Vector2(position.x, transform.position.y), Time.deltaTime * 10);
			yield return null;
		}
	}

	public void NextTurn(){
		FightManager.instance.NextTurn ();
		if(OnEndTurn != null)
			OnEndTurn ();
	}
		

	public void SetEssence(string essenceName){
		for (myEssences = Essences.Enemy; myEssences <= Essences.Hero; myEssences++)
			if (myEssences.ToString() == essenceName)
				break;
	}
}
