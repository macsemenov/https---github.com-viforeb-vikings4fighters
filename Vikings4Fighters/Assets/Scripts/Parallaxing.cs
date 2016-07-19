using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] Backgrounds;
    float[] ParallaxScales;
    public float Smoothing;
    Vector3 PreviousPosition;

	void Start () {
        PreviousPosition = transform.position;
        ParallaxScales = new float[Backgrounds.Length];

        for(int i = 0; i < ParallaxScales.Length; i++)
        {
            ParallaxScales[i] = Backgrounds[i].transform.position.z *-1;
        }
	}
	
	
	void LateUpdate () {
	
        for(int i = 0; i<Backgrounds.Length; i++)
        {
            Vector3 Parallax = -(PreviousPosition - transform.position) * ParallaxScales[i] * Smoothing;
            Backgrounds[i].transform.position = new Vector3((Parallax.x + Backgrounds[i].transform.position.x), Backgrounds[i].transform.position.y, Backgrounds[i].transform.position.z);
        }
        PreviousPosition = transform.position;
	}
}
