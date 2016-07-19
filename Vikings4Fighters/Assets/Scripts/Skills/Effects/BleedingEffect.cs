using UnityEngine;
using System.Collections;

public class BleedingEffect : SkillEffect {

	float damageModifare = 0.2f; 

	protected override void UseEffect(){
		myCharacter.GetDamage((int)(damage * damageModifare));
	}
}
