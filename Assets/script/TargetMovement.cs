using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	// Use this for initialization
	public float speed = 5.0f;

	//private Vector3 initialPosition;
	private Vector3 targetPosition;

	void Start () {
		targetPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}

	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.forward * speed * Time.deltaTime);
		targetPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		transform.RotateAround(targetPosition, Vector3.up, Time.deltaTime*speed);
	}
}
