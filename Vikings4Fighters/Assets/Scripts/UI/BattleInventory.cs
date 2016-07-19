using UnityEngine;
using System.Collections;

public class BattleInventory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchHideInventory(){
		bool currentState = GetComponent<Animator> ().GetBool ("Hide");
		GetComponent<Animator> ().SetBool ("Hide", !currentState);
	}
}
