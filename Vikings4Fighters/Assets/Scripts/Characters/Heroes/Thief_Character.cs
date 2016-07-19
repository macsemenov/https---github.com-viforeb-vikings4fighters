using UnityEngine;
using System.Collections;

public class Thief_Character : Character {

	Thief_Character(){
        myEssences = Essences.Hero;
		Role = new CharacterRole (CharacterRole.Role.Damager.ToString());
		Experience = new Experience (0);
		Health = new Health (25, 25);
		Initiative = new Initiative (15);
		CharacterName = "Thief";
		Damage = new Damage (6, 12); 
		Accuracy = 70;
		CriticalChance = 5;
		CriticalModifare = 2;
	}
}
