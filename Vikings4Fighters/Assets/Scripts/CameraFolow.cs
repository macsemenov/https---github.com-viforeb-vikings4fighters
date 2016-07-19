using UnityEngine;
using System.Collections;

public class CameraFolow : MonoBehaviour {


	public Transform target;
	public bool isCorridor;
	public float speedLerp;
	public Vector2 targetFactor;
	

	void Update () {
		if (isCorridor) {
			Vector2 lerpMovement = transform.position;
			if (target.position.x > transform.position.x) {
				lerpMovement = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.position, Time.deltaTime * speedLerp);
			} else if (target.position.x + targetFactor.x <= transform.position.x) {
				lerpMovement = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.position + targetFactor, Time.deltaTime * speedLerp);
			} 
			transform.position = new Vector3 (lerpMovement.x, transform.position.y, transform.position.z);
		}
        
	}
}
