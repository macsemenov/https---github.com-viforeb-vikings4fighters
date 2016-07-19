using UnityEngine;
using System.Collections;

public class Initiative {

	float baseInitiative;
	float currentInitiative;

	public Initiative(int value){
		baseInitiative = value;
		currentInitiative = baseInitiative;
	}

	public float CurrentInitiative{
		set{
			currentInitiative = value;
		}
		get{
			return currentInitiative;
		}
	}

	public float BaseValue{
		get{
			return baseInitiative;
		}
	}
}
