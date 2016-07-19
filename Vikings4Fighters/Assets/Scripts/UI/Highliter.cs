using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Highliter : MonoBehaviour {

	public static Highliter instance;
	List<Character> characters = new List<Character>();

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
	}

	void Start(){
		foreach (Character hero in HeroesManager.Instance.LiveCharacters) {
			characters.Add (hero);
		}

		foreach (Character enemy in EnemiesManager.Instance.Characters) {
			characters.Add (enemy);
		}
	}
	
	public void HighlightTargets(Character[] targets){
		DisableHighlights ();
		foreach (Character character in characters) {
			foreach (Character target in targets) {
				if (character == target) 
					character.personalCanvas.HighlightEffect.gameObject.SetActive (true);
			}
		}
	}

	public void DisableHighlights(){
		foreach (Character character in characters) {
			if(character != null)
				character.personalCanvas.HighlightEffect.gameObject.SetActive (false);
		}
	}
}
