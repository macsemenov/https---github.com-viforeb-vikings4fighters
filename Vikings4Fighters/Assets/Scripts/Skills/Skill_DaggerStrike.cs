using UnityEngine;
using System.Collections;

public class Skill_DaggerStrike : Skill {

	//to set the default values
	public Skill_DaggerStrike(){
		SkillName = "Dagger Strike";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, false, false, true };
		CanToGetTarget = new bool[]{ true, true, true, false };
		damageModifier = 1;
		accuracyModifier = 0;
		critChanceModifier = 10;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}


	//***//
	//Will take SkillDamage from my class parent
	//***//
}
