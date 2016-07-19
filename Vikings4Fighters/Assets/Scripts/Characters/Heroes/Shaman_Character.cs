using UnityEngine;
using System.Collections;

public class Shaman_Character : Character {



    Shaman_Character() {
		myEssences = Essences.Hero;
		Role = new CharacterRole(CharacterRole.Role.Support.ToString());
        Experience = new Experience(0);     
		Health = new Health (20, 20);
		Initiative = new Initiative (10);
		CharacterName = "Shaman";
		Damage = new Damage (2, 4); 
		Accuracy = 70;
		CriticalChance = 10;
		CriticalModifare = 2;        
	}
}
