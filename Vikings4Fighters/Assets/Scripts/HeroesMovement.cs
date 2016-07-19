using UnityEngine;
using System.Collections;

public class HeroesMovement : MonoBehaviour {


	public float speedMovement;
    [HideInInspector]
    public bool CanMove;
	int direction;
	void Start() { CanMove = true; }
	// Update is called once per frame
	void Update () {
        
		if (Input.GetMouseButton (0) && CanMove) {
           foreach(Character Hero in GetComponent<HeroesManager>().LiveCharacters)
            {
                if (Hero.gameObject.GetComponent<Animator>() != null) Hero.gameObject.GetComponent<Animator>().SetBool("IsWalk", true);
            }
			Vector2 worldMousePosition = Input.mousePosition;
            if (worldMousePosition.x > Screen.width * 0.5f) transform.Translate(new Vector2(speedMovement*Time.deltaTime, 0));
            else if (worldMousePosition.x < Screen.width * 0.5f) transform.Translate(new Vector2(-speedMovement*Time.deltaTime, 0));
		}
        if (Input.GetMouseButtonUp(0) || CanMove == false)
        {
            foreach (Character Hero in GetComponent<HeroesManager>().LiveCharacters)
            {
                if (Hero.gameObject.GetComponent<Animator>() != null) Hero.gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
            }
        }
	}
}
