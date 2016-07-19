using UnityEngine;
using System.Collections;

public class GrapnerEffect : SkillEffect {

	protected override void UseEffect(){
		CharacterManager myManager = null;
		if (myCharacter.myEssences == Character.Essences.Enemy) {
			myManager = EnemiesManager.Instance;
		} else {
			myManager = HeroesManager.Instance;
		}
			
		for (int i = 0; i < myManager.LiveCharacters.Count; i++) {
			if (myCharacter == myManager.LiveCharacters[i]) {
				Character secondTarget = null;
				if (i + 1 < myManager.LiveCharacters.Count)
					secondTarget = myManager.LiveCharacters [i + 1];

				if(i - 1 >= 0)
					secondTarget = myManager.LiveCharacters [i - 1];
				EnemiesManager.Instance.SwipeHeroes (myCharacter, secondTarget);
			}
		}
	}

	void Update(){
		UseEffect ();
		Destroy (this);
	}
}
