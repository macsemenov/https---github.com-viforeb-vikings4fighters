using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollingCurrentObj : MonoBehaviour {

    [HideInInspector]
    public Transform ScrollRectTransf;
    [HideInInspector]
    public float cellSize;
    GameObject Bounds;

    void Start()
    {
        Bounds = ScrollRectTransf.GetChild(0).gameObject;
    }

    void Update()
    {       
            if (Bounds.GetComponent<RectTransform>().localPosition.x+ GetComponent<RectTransform>().localPosition.x > cellSize 
            && Bounds.GetComponent<RectTransform>().localPosition.x+ GetComponent<RectTransform>().localPosition.x< cellSize*2)
            {
                ScrollRectTransf.GetComponent<PlayersScrolling>().CurrentPerson = this.gameObject.GetComponent<Image>();                        
            }      
    }
}
