using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButtons : MonoBehaviour {

	public SkillDragElement[] skillButtons;

	public static SkillButtons instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
	}
	
	public void AssignSkillsToButtons(Skill[] skills){
		for (int i = 0; i < skillButtons.Length; i++) {
			if (skills [i] != null) {
				skillButtons [i].currentSkill = skills [i];			
				skillButtons [i].SetIcon (skills [i].SkillIcon);
				skills [i].IsActive = false;

			} else {
				//some code
			}
		}
	}

	public void SetNormalButtons(){
		foreach (SkillDragElement skillButton in skillButtons) {
			skillButton.GetComponentInParent<Button> ().animator.SetTrigger ("Normal");
		}
	}
}
