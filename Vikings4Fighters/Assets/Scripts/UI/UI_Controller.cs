using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

	public Button[] SkillsButton = new Button[4];
    public Text SkillDescription;
	public Text ChoisenSkillText;
	public Text WinLoseText;

	public static UI_Controller Instance;

	void Awake(){
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (this);
	}


	public void ShowSkill(string SkillName){
		ChoisenSkillText.text = "!!!" + SkillName + "!!!";
		ChoisenSkillText.GetComponent<Animator> ().SetTrigger ("Show");
	}

	public void ShowWinLose(string WinLose){
		WinLoseText.text = WinLose;
		WinLoseText.GetComponent<Animator> ().SetTrigger ("Show");
	}
		
}
