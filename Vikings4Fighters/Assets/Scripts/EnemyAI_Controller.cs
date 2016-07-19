using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI_Controller : MonoBehaviour {

	Character myCharacter;
	List<float> skillsChoiseChances = new List<float>();

	Character targetHero;
	Skill sellectedSkill;

	float activateTime;
	bool isCheckedSkill;

	void Start (){
		myCharacter = GetComponent<Character> ();
		if (myCharacter == null)
			Debug.Log ("не назначен класс для объекта: " + gameObject.name);
	}


	//тестовая черновая логика. Вероятнее всего со временем это дело поменяется
	void Update (){
		if (myCharacter.IsActive) {
			if (Time.time > activateTime + 2) {
				if (sellectedSkill == null && !isCheckedSkill) {
					Debug.Log ("hi");
					isCheckedSkill = true;
					sellectedSkill = ChoiseSkill ();
					if (sellectedSkill == null) {
						Debug.Log ("Enemy " + name + " не может использовать ни одного скилла ");
					} else {
						Debug.Log ("Enemy " + name + " choise skill: " + sellectedSkill.SkillName);
					}
				} else if (targetHero == null && sellectedSkill != null) {
					targetHero = FindTargetHeroForSkill (sellectedSkill);
					Debug.Log ("Enemy " + name + " choise targe: " + targetHero.name);
				} else if (sellectedSkill != null && targetHero != null) {
//					UI_Controller.Instance.ShowSkill (sellectedSkill.SkillName);
					sellectedSkill.UseSkillToTarget (targetHero);
					sellectedSkill = null;
					targetHero = null;
					isCheckedSkill = false;
				} else {
					myCharacter.NextTurn ();
				}
			}
		} else {
			activateTime = Time.time;
		}
	}

	//выбираем цель для использования скилла
	//пока смотрим просто: у кого больше агро, того и бьем
	Character FindTargetHeroForSkill(Skill skill){
		Character hero = null;
		float maxTargetAgro = 0;
		foreach (Character target in skill.RightTargets) {
			if (target.Agro > maxTargetAgro) {
				hero = target;
				maxTargetAgro = target.Agro;
			}
		}
		return hero;
	}

	//выбор скилла на основании Агро
	Skill ChoiseSkill(){
		skillsChoiseChances.Clear ();
		float totalAgro = GetTotalAgro();
		float handler = 0;
		int randomValue = Random.Range (0, 101);
		for (int i = 0; i < myCharacter.skillsManager.Skills.Length; i++) {
			if (myCharacter.skillsManager.Skills [i] != null) {
				float skillAgro = GetSkilllAgro (myCharacter.skillsManager.Skills [i]);
				skillsChoiseChances.Add (skillAgro / (totalAgro * 0.01f));
			}
		}

		for (int i = 0; i < skillsChoiseChances.Count; i++) {
			if (randomValue >= handler && randomValue < handler + skillsChoiseChances [i]) {
				return myCharacter.skillsManager.Skills [i];
			}
			handler += skillsChoiseChances [i];
		}

		return null;
	}

	//Получаем общее значение всего Агро которое выработаю все скиллы
	//нужно для нахождения процентного значения выбора скилла
	float GetTotalAgro(){
		float totalAgro = 0;
		foreach (Skill mySkill in myCharacter.skillsManager.Skills) {
			if(mySkill != null)
				totalAgro += GetSkilllAgro (mySkill);
		}
		return totalAgro;
	}

	//получает общее значение "Агро" которое выработает данный скилл
	//тут добавляются различные модификаторы, пока что работает только для Скиллов которые наносят урон
	float GetSkilllAgro(Skill skill){
		float agro = 0;
		float agroModifare = 1;
		if (skill.CanUseInCurrentPosition) {
			foreach (Character target in skill.RightTargets) {
				agro += skill.AverageSkillDamage * target.GetComponent<Character> ().Agro;
				if (skill.AverageSkillDamage >= target.Health.CurrentHP)
					agroModifare = 3;
			}
		} 
		return agro * agroModifare;
	}
}
