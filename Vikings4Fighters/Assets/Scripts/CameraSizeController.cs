using UnityEngine;
using System.Collections;

public class CameraSizeController : MonoBehaviour {

	public float minHeightOfGame;
	// Use this for initialization
	void Start () {
		Camera.main.orthographicSize = minHeightOfGame * Camera.main.pixelHeight / Camera.main.pixelWidth * 0.5f;
	}
}
