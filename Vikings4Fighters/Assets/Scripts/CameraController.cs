using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CameraController : MonoBehaviour {

//	public float boardScaler;
//
//	void Awake () {
//
//		// center of own Grid
//		Vector2 centerOfGrid = new Vector2 (Grid.columns / 2 - 0.5f, Grid.rows / 2);
//
//		//the maximum point of the playing field (Like: "maximum screen hight" minus "hight of header". The header's hight is 18% from maximum hight)
//		float maxFitScreenHight = Camera.main.pixelHeight - (Camera.main.pixelHeight * 0.18f);
//
//		//the minimum point of the playing field (this hight is banner's hight and is 8% from maximum hight. We can't lower the playing field below the banner )
//		float minFitScreenHight = Camera.main.pixelHeight * 0.08f;
//
//		//we must find the centre of our limited space. To do this, find the extreme points of our limited space
//		Vector3 rightHightPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, maxFitScreenHight, 0));
//		Vector3 leftLowPoint = Camera.main.ScreenToWorldPoint (new Vector3 (0, minFitScreenHight, 0));
//		Vector3 rightLowPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, minFitScreenHight, 0));
//
//		//Find the center of limited space
//		Vector3 centerOfLimitedSpace = new Vector3 ((rightLowPoint.x + leftLowPoint.x) / 2f, (rightHightPoint.y + rightLowPoint.y) / 2f, 0);
//
//		//then set camera position
//		Vector2 directionVector = centerOfGrid - (Vector2)centerOfLimitedSpace;
//		transform.position += (Vector3)directionVector;
//
//		float newCameraOrtSize = (10) * Camera.main.pixelHeight / Camera.main.pixelWidth * 0.5f;
//		Camera.main.orthographicSize = (newCameraOrtSize < 7) ? 7 : newCameraOrtSize;

//	}
}
