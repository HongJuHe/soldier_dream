using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoviePlayer : MonoBehaviour {
	
	public MovieTexture texture;
	private float time = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (time < 27f) {
						renderer.material.mainTexture = texture;
						texture.Play ();
						time += Time.deltaTime;
				} else {
						Application.LoadLevel ("main_start");
				}
	}
}
