using UnityEngine;
using System.Collections;

public class Skill_Healing : Skill {

    //to set the default values
    public Skill_Healing()
    {
        SkillName = "Heal";
        SkillLevel = 1;
		skillTarget = SkillTarget.Friends;
		targetsQuantity = 1;
		CanUseInPositions = new bool[] { true, true, true, false };
		CanToGetTarget = new bool[] { true, true, true, true };
        damageModifier = 1;
        accuracyModifier = 0;
        critChanceModifier = 2;
        critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
    }
}
