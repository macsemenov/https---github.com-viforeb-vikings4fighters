using UnityEngine;
using System.Collections;

public abstract class SkillEffect : MonoBehaviour {

	public enum Effects {None, Bleeding, Stun, Vigor, Grapner};

	public int effectTime = 2;
	public int damage;
	protected Character myCharacter;

	void OnEnable(){
		myCharacter = GetComponent<Character> ();
		myCharacter.OnEndTurn += ReduceEffectTime;
		myCharacter.OnStartTurn += UseEffect;
	}

	void OnDisable(){
		myCharacter.OnEndTurn -= ReduceEffectTime;
		myCharacter.OnStartTurn -= UseEffect;
	}

	void ReduceEffectTime(){
		effectTime--;
		if (effectTime <= 0) {
			myCharacter.OnEndTurn -= ReduceEffectTime;
			Destroy (this);
		}
	}
		

	protected abstract void UseEffect ();


	public static System.Type GetEffect(Effects effectName){
		switch (effectName) {
		case Effects.None:
			return null;
		case Effects.Bleeding:
			return new BleedingEffect().GetType();
		case Effects.Stun:
			return new StunEffect().GetType();
		case Effects.Vigor:
			return new VigorEffect().GetType();
		case Effects.Grapner:
			return new GrapnerEffect().GetType();
		default:
			return null;
		}
	}


	public static Effects GetSkillEffect(string effectName){
		if(effectName == Effects.None.ToString())
			return Effects.None;

		if(effectName == Effects.Bleeding.ToString())
			return Effects.Bleeding;

		if(effectName == Effects.Stun.ToString())
			return Effects.Stun;

		if(effectName == Effects.Vigor.ToString())
			return Effects.Vigor;

		if(effectName == Effects.Grapner.ToString())
			return Effects.Grapner;

		return Effects.None;
	}

}
