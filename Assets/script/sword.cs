using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sword : MonoBehaviour {

	public GameObject[] list;
	public GameObject tree_base;

	private Vector3 pos;
	private Quaternion rot;

	void Start () {

		pos = new Vector3 (0, 0, 0);
		rot = new Quaternion (0, 0, 0, 0);

		list = GameObject.FindGameObjectsWithTag ("tree");
		foreach (GameObject t in list) {
						pos = t.transform.position;
						rot = t.transform.rotation;
						Instantiate (tree_base, pos, rot);
				}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "tree" && Input.GetKey(KeyCode.X)) 
		{
			Destroy(other.gameObject, 1);
		}
	}
}
