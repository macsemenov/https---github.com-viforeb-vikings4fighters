using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour {

	public Skill[] Skills = null;
	protected Skill activeSkill;

	//reference to character who use these skills
	Character myCharacter;

	public Skill ActiveSkill{
		get{
			foreach (Skill skill in Skills) {
				if (skill != null && skill.IsActive)
					return skill;
			}
			return null;
		}
		set{
            for (int i = 0; i < Skills.Length; i++)
            {
                if (Skills[i] != null) {
                    Skills[i].IsActive = (Skills[i] == value) ? true : false;
				}

				if (Skills[i] != null && Skills[i] != value) {
                    Skills[i].IsActive = false;
                    if (i == Skills.Length)
                    {
                        FindObjectOfType<UI_Controller>().SkillDescription.text = "";
                    }
                }

                else if (Skills[i] != null && Skills[i] == value) {                   
                    Skills[i].IsActive = true;
					HightlightTargets (Skills[i].RightTargets.ToArray());
                }
			}
		}
	}
		

	void HightlightTargets(Character[] targets){
		DisableHighlight ();
		foreach (Character target in targets) {
			target.personalCanvas.HighlightEffect.gameObject.SetActive(true);
		}
	}

	public void DisableHighlight(){
		foreach (Character enemy in EnemiesManager.Instance.Characters) {
			if(enemy != null)
				enemy.GetComponent<Character>().personalCanvas.HighlightEffect.gameObject.SetActive(false);
		}

		foreach (Character hero in HeroesManager.Instance.LiveCharacters) {
			if(hero != null)
				hero.GetComponent<Character>().personalCanvas.HighlightEffect.gameObject.SetActive(false);
		}
	}

	public void DeactivateAllSkill(){
		foreach (Skill skill in Skills) {
			if (skill != null)
				skill.IsActive = false;
		}
	}


	void Start (){
		myCharacter = GetComponent<Character> ();
		foreach (Skill skill in Skills) {
			if(skill != null)
				skill.myCharacter = myCharacter;
		}
	}
}
