using UnityEngine;
using System.Collections;

public class Health  {



	int maxHP;
	int currentHP;


	public Health (int MaxHP, int CurrentHP){
		this.maxHP = MaxHP;
		this.currentHP = CurrentHP;
		Mathf.Clamp (currentHP, 0, maxHP);
	}

	public Health(){}


	public int CurrentHP {
		set {
			currentHP = Mathf.Clamp (value, 0, maxHP);;
		}
		get{
			return currentHP;
		}
	}

	public int MaxHP {
		get{
			return maxHP;
		}
	}
}
