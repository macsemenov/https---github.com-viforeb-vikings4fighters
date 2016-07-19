using UnityEngine;
using System.Collections;

public class Enemy_Dwarf : Character {

	Enemy_Dwarf(){
		myEssences = Essences.Enemy;
		Experience = new Experience (0);
		Health = new Health (20, 20);
		Initiative = new Initiative (8);
		CharacterName = "Dwarf";
		Damage = new Damage (6, 10); 
		Accuracy = 70;
		CriticalChance = 5;
		CriticalModifare = 2;
	}
}
