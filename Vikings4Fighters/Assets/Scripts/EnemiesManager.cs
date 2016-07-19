using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : CharacterManager {

	List<Character> enemies = new List<Character>();

	public static EnemiesManager Instance;

	void Awake(){
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (this.gameObject);
	}

	public List<Character> Characters{
		get {
			enemies.Clear ();
			for (int i = 0; i < CharacterPlaces.Length; i++ ) {
				if (CharacterPlaces [i].childCount > 0)
					enemies.Add(CharacterPlaces [i].GetChild (0).GetComponent<Character>());
			}
			return enemies;
		}
	}

	public override void SetActiveCharacter (Character Enemy){
		foreach (Character enemy in Characters) {
			if (enemy != null) {
				enemy.IsActive = (enemy == Enemy) ? true : false;
			}
		}
	}

	// обязательно переделать данный метод и его вызов в Update
	public void ShuffleEnemies(){
		for (int i = 0; i < CharacterPlaces.Length; i++) {
			if (CharacterPlaces [i].childCount > 0) {
				if (i > 0 && CharacterPlaces [i - 1].childCount == 0) {
					StartCoroutine(CharacterPlaces [i].GetChild (0).GetComponent<Character> ().MoveTo (CharacterPlaces [i - 1].position));
					CharacterPlaces [i].GetChild (0).parent = CharacterPlaces [i - 1];
					i--;
				}
			}
		}
	}

	void Update (){
		ShuffleEnemies ();
	}
}
