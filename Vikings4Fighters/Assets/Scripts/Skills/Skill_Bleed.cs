using UnityEngine;
using System.Collections;
using Google2u;

public class Skill_Bleed : Skill {


	//to set the default values
	public Skill_Bleed(){
		SkillName = "Bleed";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, true, true, true };
		CanToGetTarget = new bool[]{ true, true, true, false };
		damageModifier = .4f;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.Bleeding;
	}


	//***//
	//Will take SkillDamage from my class parent
	//***//
}
