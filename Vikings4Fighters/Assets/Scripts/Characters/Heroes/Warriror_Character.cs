using UnityEngine;
using System.Collections;

public class Warriror_Character : Character {

	Warriror_Character(){
		myEssences = Essences.Hero;
		Role = new CharacterRole (CharacterRole.Role.Tank.ToString());
		Experience = new Experience (0);
		Health = new Health (30,30);
		Initiative = new Initiative (10);
		CharacterName = "Tor";
		Damage = new Damage (6, 12); 
		Accuracy = 70;
		CriticalChance = 5;
		CriticalModifare = 2;
	}
}
