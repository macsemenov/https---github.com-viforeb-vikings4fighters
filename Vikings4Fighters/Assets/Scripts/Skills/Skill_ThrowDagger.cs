using UnityEngine;
using System.Collections;

public class Skill_ThrowDagger : Skill {
	
	//to set the default values
	public Skill_ThrowDagger(){
		SkillName = "Throw Dagger";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ true, true, false, false };
		CanToGetTarget = new bool[]{ false, false, false, true };
		damageModifier = .9f;
		accuracyModifier = 0;
		critChanceModifier = 0; //per percent
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}


	//***//
	//Will take SkillDamage from my class parent
	//***//
}
