using UnityEngine;
using System.Collections;

public class Skill_PainfulAnalysis : Skill {

	//to set the default values
	public Skill_PainfulAnalysis(){
		SkillName = "Painful Analysis";
		SkillLevel = 1;
		skillTarget = SkillTarget.Enemies;
		targetsQuantity = 1;
		CanUseInPositions = new bool[]{ false, false, false, true };
		CanToGetTarget = new bool[]{ true, true, false, false };
		damageModifier = .85f;
		accuracyModifier = 0;
		critChanceModifier = 0; //per percent
		critDamageModifier = 0;
		addedEffect = SkillEffect.Effects.None;
    }
}
