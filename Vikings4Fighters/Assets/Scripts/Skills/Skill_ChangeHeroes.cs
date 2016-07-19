using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_ChangeHeroes : Skill {


	public Skill_ChangeHeroes(){
		SkillName = "Change Places";
		SkillLevel = 1;
		skillTarget = SkillTarget.Friends;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ true, true, true, true };
		CanToGetTarget = new bool[]{ true, true, true, false };
		damageModifier = 0;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}

	// не трогать. Все переопределено верно
//	public override List<Character> RightTargets{
//		get{
//			rightTargets.Clear ();
//			for (int i = 0; i < HeroesManager.Instance.LiveCharacters.Count; i++) {
//				if (HeroesManager.Instance.LiveCharacters [i] == myCharacter) {
//					if (i + 1 < HeroesManager.Instance.LiveCharacters.Count)
//						rightTargets.Add (HeroesManager.Instance.LiveCharacters [i + 1]);
//					if(i - 1 >= 0)
//						rightTargets.Add (HeroesManager.Instance.LiveCharacters [i - 1]);
//					break;
//				}		
//			}
//			return rightTargets;
//		}
//	}
//
//
//
//	public override void UseSkillToTarget(Character target){
//		for (int i = 0; i < RightTargets.Count; i++) {
//			if (target == RightTargets[i]) {
//				UI_Controller.Instance.ShowSkill (SkillName);
//				HeroesManager.Instance.SwipeHeroes (myCharacter, target);
//			}
//		}
//	}
//
//	protected override IEnumerator DamageCoroutine (){
//		Character targetEnemy = null;
//		while (targetEnemy == null) {
//			if (Input.GetMouseButtonDown (0)) {
//				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//				if (hit.collider != null) {
//					targetEnemy = hit.collider.GetComponent<Character>();
//					UseSkillToTarget (targetEnemy);
//				}	
//			}
//			if (!IsActive) break;
//			yield return null;
//		}
//	} 
//

}
