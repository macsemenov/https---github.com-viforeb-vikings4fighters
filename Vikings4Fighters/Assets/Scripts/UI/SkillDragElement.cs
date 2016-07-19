using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillDragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	public static GameObject itemBeignDraged;
	bool canMove;
	Vector3 slotPosition;
	Button myButton;
	Image myImage;
	public GameObject activeEffect;

	public Skill currentSkill { get; set;}

	void Start(){
		myButton = GetComponentInParent<Button> ();
	}

	void Update(){
		if (canMove) {
			slotPosition = transform.parent.position;
//			transform.position = Vector2.Lerp(transform.position, slotPosition, Time.deltaTime * 7);
			transform.position = slotPosition;
			if (Vector3.Distance (transform.position, slotPosition) < 0.3f) {
				transform.position = slotPosition;

			}
		}
	}


	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData){
		itemBeignDraged = gameObject;
		canMove = false;
	}
	#endregion



	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData){
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		activeEffect.SetActive (true);
	}
	#endregion


	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData){
		activeEffect.SetActive (false);
		canMove = true;
		itemBeignDraged = null;
		SkillButtons.instance.SetNormalButtons ();
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null && hit.collider.GetComponent<Character>() != null) {
			Character target = hit.collider.GetComponent<Character>();
			currentSkill.UseSkillToTarget (target);
		}	
	}
	#endregion

	public void SetIcon(Sprite icon){
		if (myImage == null)
			myImage = GetComponent<Image> ();

		myImage.sprite = icon;
	}
		
	public void SetActiveSkill(){
		Highliter.instance.HighlightTargets (currentSkill.RightTargets.ToArray ());
		SkillDescription.Instance.SetSkillDescription (currentSkill);
	}
}
