using UnityEngine;
using System.Collections;

public class Skill_BigScope : Skill {

	//to set the default values
	public Skill_BigScope(){
		SkillName = "Big Scope";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 2;
		CanUseInPositions = new bool[]{ false, false, true, true };
		CanToGetTarget = new bool[]{ true, true, false, false };
		damageModifier = 0;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}
		 
}
