using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class main_trigger : MonoBehaviour {

	public GUIText TimeText;
	public float count = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float min = Mathf.FloorToInt (count / 60);
		float sec = Mathf.FloorToInt (count % 60);
		if (count <= 0) {
						Application.LoadLevel ("main_start");
				} else {
						count -= Time.deltaTime;
						TimeText.text = min.ToString () + " : " + sec.ToString ();
				}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (count> 0) {
			if (collision.gameObject.tag == "Player") {
				Debug.Log ("NEXT");
				Application.LoadLevel ("main2_start");
			}
		} 
	}
}
