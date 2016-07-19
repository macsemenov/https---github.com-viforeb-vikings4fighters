using UnityEngine;
using System.Collections;

public class Skill_StunStrike : Skill {

	//to set the default values
	public Skill_StunStrike(){
		SkillName = "Stun Strike";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, false, false, true };
		CanToGetTarget = new bool[]{ true, true, false, false };
		damageModifier = 0;
		accuracyModifier = 0;
		critChanceModifier = 0;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.Stun;
	}
}
