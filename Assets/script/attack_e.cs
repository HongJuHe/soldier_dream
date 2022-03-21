using UnityEngine;
using System.Collections;

public class attack_e : MonoBehaviour {
	
	public int heart = 5;
	public GUIText countText;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		countText.text = "Heart : " + heart.ToString();
		if (heart <= 0) {
						Debug.Log ("You Die");
			Application.LoadLevel ("badending");
				}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (heart >= 1 && other.tag=="Player") {
			
			Debug.Log("You Attack!");
			heart = heart - 1;
			countText.text = "Heart : " + heart.ToString ();
		} 
	}
}
