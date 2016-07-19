using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {

	public HeroesManager heroesManager;
	public EnemiesManager enemiesManager;
	List<Character> charactersLine = new List<Character>();
	Character activeCharacter;
	public static FightManager instance;
	public bool IsHeroTurn { get; set;}

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
	}

	void Start(){
		NextTurn ();
	}

	void Update(){
		if (enemiesManager.Characters.Count == 0) {
			UI_Controller.Instance.ShowWinLose ("Win");
		} else if (heroesManager.LiveCharacters.Count == 0) {
			UI_Controller.Instance.ShowWinLose ("Lose");
		}
	}


	public void NextTurn(){
		SkillDescription.Instance.SetEmptyDescription ();
		DisableAllHighlights ();
		charactersLine.Clear ();
		charactersLine.AddRange (heroesManager.LiveCharacters);
		charactersLine.AddRange (enemiesManager.Characters);
		charactersLine = charactersLine.OrderByDescending (x => x.GetComponent<Character> ().Initiative.CurrentInitiative).ToList();
		activeCharacter = charactersLine.First ();
		activeCharacter.Initiative.CurrentInitiative = 0;
		IsHeroTurn = (activeCharacter.myEssences == Character.Essences.Hero) ? true : false;
		SetInteractableAllSkill(IsHeroTurn);
		RecalculateInitiative ();
		SetActiveCharacter (activeCharacter);
	} 

	void SetActiveCharacter (Character Character){
		foreach (Character character in charactersLine)
			character.IsActive = (character == Character) ? true : false;
	}

	void RecalculateInitiative(){
		foreach (Character character in charactersLine) {
			character.Initiative.CurrentInitiative = character.Initiative.CurrentInitiative + (1f / charactersLine.Count) * character.Initiative.BaseValue;
		}
	}

	void DisableAllHighlights(){
		foreach (Character enemy in enemiesManager.Characters) {
			if (enemy != null)
				enemy.personalCanvas.HighlightEffect.gameObject.SetActive (false);
		}

		foreach (Character hero in heroesManager.LiveCharacters) {
			if (hero != null)
				hero.personalCanvas.HighlightEffect.gameObject.SetActive (false);
		}
	}

	void SetInteractableAllSkill(bool state){
		foreach (Button button in FindObjectsOfType<Button>())
			button.interactable = state;
	}
}
