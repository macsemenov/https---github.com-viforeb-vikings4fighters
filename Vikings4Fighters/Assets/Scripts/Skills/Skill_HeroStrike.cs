using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Skill_HeroStrike : Skill {


	//to set the default values
	public Skill_HeroStrike(){
		SkillName = "HeroStrike";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, false, true, true };
		CanToGetTarget = new bool[]{ true, true, false, false };
		damageModifier = 0;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}
}
