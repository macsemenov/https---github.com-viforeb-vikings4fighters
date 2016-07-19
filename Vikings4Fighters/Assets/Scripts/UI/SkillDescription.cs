using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillDescription : MonoBehaviour {

	public Text skillName;
	public Text skillDamage;
	public Text skillEffect;
	public Text skillAccuracy;
	public Text skillTargets;

	public static SkillDescription Instance;

	public Image[] canUsePoints;
	public Image[] rightTargetPoints;

	// Use this for initialization
	void Start () {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (this.gameObject);

		SetEmptyDescription ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				SetEmptyDescription ();
			}
		}
	}


	public void SetEmptyDescription(){
		skillName.text = "";
		skillDamage.text = "";
		skillEffect.text = "";
		skillAccuracy.text = "";
		skillTargets.text = "";
		SetEmptyPoints ();
	}

	public void SetUsefulPoints(bool[] points){
		for (int i = 0; i < canUsePoints.Length; i++) {
			canUsePoints [i].color = (points[i] == true) ? Color.green : Color.grey;
		}
	}

	public void SetRightPoints(bool[] points){
		for (int i = 0; i < rightTargetPoints.Length; i++) {
			rightTargetPoints [i].color = (points[i] == true) ? Color.red : Color.grey;
		}
	}

	public void SetEmptyPoints(){
		for (int i = 0; i < canUsePoints.Length; i++) {
			canUsePoints [i].color = Color.grey;
			rightTargetPoints [i].color = Color.grey;
		}
	}

	public void SetSkillDescription(Skill skill){
		skillName.text = skill.SkillName;
		skillDamage.text = "Damage: " + skill.GetDamageString();
		skillEffect.text = "Effect: " + skill.addedEffect.ToString();
		skillTargets.text = "Targets: " + skill.targetsQuantity.ToString();
		skillAccuracy.text = "Accuracy: " + skill.GetAccuracyString() + "%";

		if (skill.SkillName.ToString () == "Change Places") {
			SkillDescription.Instance.SetEmptyDescription ();
			SkillDescription.Instance.skillName.text = skill.SkillName;
		}
		SetUsefulPoints (skill.CanUseInPositions);
		SetRightPoints (skill.CanToGetTarget);
	}
}
