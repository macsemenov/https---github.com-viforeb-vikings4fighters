using UnityEngine;
using System.Collections;

public class Damage   {

	int minDamage;
	int maxDamage;

	public Damage (int minDamage, int maxDamage){
		this.minDamage = minDamage;
		this.maxDamage = maxDamage;
	}

	public int RandomDamage{
		get{
			return Random.Range (minDamage, maxDamage + 1);
		}
	}

	public int MaxDamage{
		get{
			return maxDamage;
		}
	}

	public int MinDamage{
		get{
			return minDamage;
		}
	}

	public float AverageDamage{
		get{
			return (float)(minDamage + maxDamage) * 0.5f;
		}
	}
}
