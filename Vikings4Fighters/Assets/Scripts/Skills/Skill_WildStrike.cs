﻿using UnityEngine;
using System.Collections;

public class Skill_WildStrike : Skill {

	//to set the default values
	public Skill_WildStrike(){
		SkillName = "Wild Strike";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, false, true, true };
		CanToGetTarget = new bool[]{ true, true, false, false };
		damageModifier = 0.2f;
		accuracyModifier = 0;
		critChanceModifier = 5;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
	}
}
