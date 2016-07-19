using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayersScrolling : MonoBehaviour {  
      
    public Image CurrentPerson;
    [SerializeField]
    GameObject Bounds;
    [SerializeField]
    GameObject PlayersParent;


    Image PrevPerson;
    Vector3 BoundsBackPos;
    bool CanStop;
    float size;// размер картинки
    float ExtraDistance; // отступ первого игрока
    float Ypos; // позиция по Y
    float SmallIconPos = 40; // доп  высота поднятия маленьких иконок


    void Awake()
    {    
        PrevPerson = null;       
        int ChildCount = 0;
        size = CurrentPerson.GetComponent<RectTransform>().sizeDelta.x;
        Ypos = CurrentPerson.GetComponent<RectTransform>().position.y;
        ExtraDistance = PlayersParent.GetComponent<GridLayoutGroup>().padding.left + size * 0.5f;
        foreach (Transform transf in PlayersParent.transform)
        {
            if (transf.gameObject.activeSelf == true)
            {
                ScrollingCurrentObj comp = transf.gameObject.AddComponent<ScrollingCurrentObj>();
                comp.ScrollRectTransf = GetComponent<Transform>();
                comp.cellSize = size;
                ChildCount++;
                if (transf.gameObject != CurrentPerson)
                {
                    transf.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 0.7f, size * 0.7f);
                    transf.GetComponent<RectTransform>().localPosition = new Vector2(transf.GetComponent<RectTransform>().localPosition.x, Ypos + SmallIconPos);
                }
            }
        }       
        if (PlayersParent.GetComponent<GridLayoutGroup>() == null) Debug.Log("Добавьте компонент Grid layout Group на родителя персонажей и выключите его ");
        Bounds.GetComponent<RectTransform>().sizeDelta = new Vector2(size * (ChildCount-1)
            + PlayersParent.GetComponent<GridLayoutGroup>().spacing.x * (ChildCount-1) + ExtraDistance*2, size);
        Bounds.GetComponent<RectTransform>().localPosition = new Vector2(- CurrentPerson.GetComponent<RectTransform>().localPosition.x+ExtraDistance,
            Bounds.GetComponent<RectTransform>().localPosition.y);
    }

    void Update() {
        if (CurrentPerson != PrevPerson)
        {
            if (PrevPerson != null)
            {
                PrevPerson.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 0.7f, size * 0.7f);
                PrevPerson.GetComponent<RectTransform>().localPosition = new Vector2(PrevPerson.GetComponent<RectTransform>().localPosition.x, Ypos + SmallIconPos);
            }
            CurrentPerson.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            CurrentPerson.GetComponent<RectTransform>().localPosition = new Vector2(CurrentPerson.GetComponent<RectTransform>().localPosition.x, Ypos);
            PrevPerson = CurrentPerson;
        }
        if (Input.GetMouseButton(0)) CanStop = false;       
        else if(Mathf.Abs(GetComponent<ScrollRect>().velocity.x) < 200 && CurrentPerson != null)
        {          
            if (CanStop == false )
            {
                float Dist = CurrentPerson.GetComponent<RectTransform>().position.x;
                BoundsBackPos = new Vector3(Bounds.GetComponent<RectTransform>().position.x - Dist, 0, 0);
                CanStop = true;
            }
            if (CanStop == true)
            {
                Bounds.GetComponent<RectTransform>().localPosition =Vector2.Lerp(Bounds.GetComponent<RectTransform>().localPosition, new Vector2(-CurrentPerson.GetComponent<RectTransform>().localPosition.x + ExtraDistance,
             Bounds.GetComponent<RectTransform>().localPosition.y),0.1f);
            }
        }
    }
}
