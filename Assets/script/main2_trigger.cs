using UnityEngine;
using System.Collections;

public class main2_trigger : MonoBehaviour {

	public int hp = 5;
	public GUIText countText;
	private bool recover = true;
	private Animation anim;
	private bool death = true;
	private GameObject[] kn;

	// Use this for initialization
	void Start () {
		countText.text = "Heart : " + hp.ToString();
		anim = gameObject.GetComponent<Animation> ();
		kn = GameObject.FindGameObjectsWithTag ("knight");
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetKey (KeyCode.F) && recover) {
						hp = hp + 5;
						recover = false;
						countText.text = "Heart : " + hp.ToString ();
				}
				if (hp <= 0 ) {
			foreach(GameObject ob in kn)
			{
				Destroy(ob);
			}
						if (death) {
								StartCoroutine (deathanimation ());
						}
				else
				{
					Application.LoadLevel ("main2_start");
				}
			}
		}

	void OnCollisionEnter(Collision collision)
	{
		if (hp > 0) {
						if (collision.gameObject.tag == "knight") {
								hp = hp - 1;
								countText.text = "Heart : " + hp.ToString ();
						} else if (collision.gameObject.tag == "ruinarch") {
								Application.LoadLevel ("escapeknight_start");
						}
				} 
	}
	IEnumerator deathanimation()
	{
		anim.Play ("sword and shield death");
				yield return new WaitForSeconds (3.8f);
		death = false;
	//Application.LoadLevel("main");
		}
}
//collision.gameObject.tag == "Player"
//Application.LoadLevel ("main");