using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_Grapner : Skill {

	public Skill_Grapner(){
		SkillName = "Grapner";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ true, true, true, true };
		CanToGetTarget = new bool[]{ true, true, true, true };
		damageModifier = 0;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.Grapner;
	} 
}
