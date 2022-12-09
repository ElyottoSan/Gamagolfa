using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public Easing.Type easing;
	public float delay;

	void Start () {
		Camera.main.FadeIn(delay, easing);
	}

	void Update () {
	
	}
}
