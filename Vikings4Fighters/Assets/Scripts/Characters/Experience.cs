using UnityEngine;
using System.Collections;

public class Experience {



	protected int experience;

	public Experience (int exp) {
		experience = exp;
	}

	public Experience(){
	}


	public int Level {
		get {
			return (experience / 100) + 1;
		}
	}


	public void AddExperience (int exp){
		experience += exp;
	}
}
