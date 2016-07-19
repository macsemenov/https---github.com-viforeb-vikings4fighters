using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_HealthDance : Skill {

	//to set the default values
	public Skill_HealthDance(){
		SkillName = "Heal Dance";
		SkillLevel = 1;
		skillTarget = SkillTarget.Friends;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ true, true, true, false };
		CanToGetTarget = new bool[]{ true, true, true, true };
		damageModifier = 1.2f;
		accuracyModifier = 0;
		critChanceModifier = 2; //per percent
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
    }
}
