using UnityEngine;
using System.Collections;

public class Skill_ThorStrike : Skill {
	
	public Skill_ThorStrike(){
		SkillName = "Thor Strike";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 4;
		CanUseInPositions = new bool[]{ false, false, false, true };
		CanToGetTarget = new bool[]{ true, true, true, true };
		damageModifier = 0;
		accuracyModifier = 100;
		critChanceModifier = 0;
		critDamageModifier = 1;
		addedEffect = SkillEffect.Effects.None;
	}
}
