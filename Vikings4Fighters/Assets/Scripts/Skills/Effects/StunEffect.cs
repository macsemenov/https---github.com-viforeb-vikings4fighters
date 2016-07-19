using UnityEngine;
using System.Collections;

public class StunEffect : SkillEffect {


	protected override void UseEffect(){
		myCharacter.NextTurn ();
	}
}
