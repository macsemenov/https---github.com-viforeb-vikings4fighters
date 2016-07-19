using UnityEngine;
using System.Collections;

public class GameProcess : MonoBehaviour {

    public static bool BattleStart;    
    [SerializeField]
    GameObject[] ObjectsToHide;
    [SerializeField]
    GameObject[] ObjectsToShow;

	public AudioSource music;
	public AudioClip battle;
	public AudioClip walking;

    bool AllObjectsHidden; // батл уже начался, нужно для отключения канваса на данный момент!
    bool AllObjectsAreShown = false; // все канвасы включены

    void Awake()
    {
        BattleStart = false;
    }

	void Start(){
		music.clip = walking;
		music.Play ();
	}
}
