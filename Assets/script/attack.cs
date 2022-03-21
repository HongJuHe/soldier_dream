using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	public int heart = 5;
	public GUIText countText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		countText.text = "Enemy Heart : " + heart.ToString();
		if (heart <= 0) {
			Debug.Log ("Knight Die");
			Application.LoadLevel ("normalending");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (heart >= 1 && other.tag=="knight") {

			Debug.Log("knight Attack!");
			heart = heart - 1;
			countText.text = "Enemy Heart : " + heart.ToString ();
		} 
	}
}
