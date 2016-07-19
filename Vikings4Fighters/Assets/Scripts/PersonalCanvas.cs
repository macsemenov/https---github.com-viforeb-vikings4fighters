using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonalCanvas : MonoBehaviour {

    public Text DamageText;
    public Slider HpSlider;
    public Text HPText;
    public Image HighlightEffect;
	public Character myCharacter;


	public void ShowDamage (int damage){
		if (damage == 0) {
			DamageText.text = "Miss!";
		} else if (damage > 0) {
			DamageText.color = Color.red;
			DamageText.text = "- " + damage.ToString ();
		} else if (damage < 0) {
			DamageText.color = Color.green;
			DamageText.text = "+ " + Mathf.Abs(damage).ToString ();
		}
		DamageText.gameObject.SetActive (true);
	}
}
