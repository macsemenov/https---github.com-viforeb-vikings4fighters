using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class CharacterManager : MonoBehaviour {

	public Transform[] CharacterPlaces = new Transform[4];
	Character[] myCharacters = new Character[4];

	List<Character> liveCharacters = new List<Character>();

	public List<Character> LiveCharacters{
		get {
			liveCharacters.Clear ();
			for (int i = 0; i < CharacterPlaces.Length; i++ ) {
				if (CharacterPlaces [i].childCount > 0)
					liveCharacters.Add(CharacterPlaces [i].GetChild (0).GetComponent<Character>());
			}
			return liveCharacters;
		}
	}


	public abstract void SetActiveCharacter (Character character);
		

	public Character[] MyCharacters{
		get{
			for (int i = 0; i < CharacterPlaces.Length; i++) {
				if (CharacterPlaces [i].childCount > 0)
					myCharacters [i] = CharacterPlaces [i].GetComponentInChildren <Character> ();
				else
					myCharacters [i] = null;
			}
			return myCharacters;
		}
	}


	public int GetCharacterArrayIndexFor(Character character){
		for (int i = 0; i < MyCharacters.Length; i++) {
			if (myCharacters [i] == character)
				return i;
		}
		Debug.Log (character.name + " нету в списке моего CharManager");
		return -1;
	}
				

	public void SwipeHeroes(Character target1, Character target2){
		StartCoroutine (CharacterMovement (target1, target2));
	}


	IEnumerator CharacterMovement (Character character1, Character character2){

		Vector2 character1Pos = (Vector2)character1.transform.position;
		Vector2 character2Pos = (Vector2)character2.transform.position;

		Vector2 newPosition1 = new Vector2 (character2Pos.x, character1Pos.y);
		Vector2 newPosition2 = new Vector2 (character1Pos.x, character2Pos.y);

		while (character1Pos.x != newPosition1.x && character2Pos.x != newPosition2.x) {

			character1Pos = Vector2.Lerp (character1Pos, newPosition1, Time.deltaTime * 5);
			character2Pos = Vector2.Lerp (character2Pos, newPosition2, Time.deltaTime * 5);

			if (Vector2.Distance (character1Pos, newPosition1) < 0.05f)
				character1Pos = newPosition1;

			if (Vector2.Distance (character2Pos, newPosition2) < 0.05f)
				character2Pos = newPosition2;

			character1.transform.position = character1Pos;
			character2.transform.position = character2Pos;
			yield return null;
		}

		int char1Index = GetCharacterArrayIndexFor (character1);
		int char2Index = GetCharacterArrayIndexFor (character2);

		character2.transform.parent = CharacterPlaces [char1Index];
		character1.transform.parent = CharacterPlaces [char2Index];
		FightManager.instance.NextTurn ();
	}
}
