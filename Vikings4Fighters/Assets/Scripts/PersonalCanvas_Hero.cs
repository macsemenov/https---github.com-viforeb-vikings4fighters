using UnityEngine;
using System.Collections;

public class PersonalCanvas_Hero : PersonalCanvas {

	void Start(){
		HpSlider.maxValue = myCharacter.Health.MaxHP;
		HpSlider.value = myCharacter.Health.CurrentHP;
		HPText.text = myCharacter.Health.CurrentHP + "/" + myCharacter.Health.MaxHP;
	}

	void Update(){
		HpSlider.value = myCharacter.Health.CurrentHP;
		HPText.text = myCharacter.Health.CurrentHP + "/" + myCharacter.Health.MaxHP;
	}
}
