using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MapTrigger : MonoBehaviour {

    public List<GameObject> MapObjects = new List<GameObject>();
    public bool StartBattlePoint;
    public int LevelNumber;
    public int SelectedIndex;
    public bool a;//if ishidden foldout  
    public int b;//size of array
    SpriteRenderer spr;
    GameObject GameController;

    void Start()
    {
        GameController = GameObject.Find("#GameController");
        spr = Camera.main.transform.FindChild("FadingSprite").GetComponent<SpriteRenderer>();
        if (spr == null) Debug.Log("NO SPRITE!");
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hero" && StartBattlePoint)
        {            
            StartCoroutine(LoadScene());
            HeroesManager.Instance.gameObject.GetComponent<HeroesMovement>().CanMove = false;
            this.gameObject.GetComponent<MapTrigger>().enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Hero"&& !StartBattlePoint)
        {
            foreach (GameObject obj in MapObjects)
            {
                obj.GetComponent<Animator>().SetBool("Play", true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col )
    {
        if (col.tag == "Hero" && !StartBattlePoint)
        {
            foreach (GameObject obj in MapObjects)
            {
                obj.GetComponent<Animator>().SetBool("Play", false);
            }
        }
    }

    IEnumerator LoadScene(){        
        while (spr.color.a < 0.97f || GameController.GetComponent<GameProcess>().music.volume>0.1f)
        {
            GameController.GetComponent<GameProcess>().music.volume = Mathf.Lerp(GameController.GetComponent<GameProcess>().music.volume, 0, 0.08f);
            spr.color = Color.Lerp(spr.color, Color.black,0.08f);
            yield return null;                
        }
        SceneManager.LoadScene(LevelNumber);
    }

}


