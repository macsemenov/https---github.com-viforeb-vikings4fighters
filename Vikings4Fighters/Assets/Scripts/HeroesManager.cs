using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeroesManager : CharacterManager {

	public static HeroesManager Instance;
	public static Character activeHero;


	void Awake(){
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (this.gameObject);
	}
		

	public override void SetActiveCharacter (Character newActiveHero){
		foreach (Character hero in LiveCharacters) {
			if (hero != null) {
				hero.IsActive = (hero == newActiveHero) ? true : false;
			}
		}
	}

	public Character GetActiveHero(){
		foreach (Character hero in LiveCharacters) {
			if (hero != null) {
				if (hero.IsActive)
					return hero;
			}
		}
		return null;
	}
}
