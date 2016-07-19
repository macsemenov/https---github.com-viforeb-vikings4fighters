using UnityEngine;
using System.Collections;

public class Skill_Vigor : Skill {

	public Skill_Vigor()
	{
		SkillName = "Vigor";
		SkillLevel = 1;
		skillTarget = SkillTarget.Friends;
		targetsQuantity = 1;
		CanUseInPositions = new bool[] { true, true, false, false };
		CanToGetTarget = new bool[] { true, true, true, true };
		damageModifier = .4f;
		accuracyModifier = 0;
		critChanceModifier = 2;
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.Vigor;
    }

}
