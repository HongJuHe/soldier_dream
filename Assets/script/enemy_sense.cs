using UnityEngine;
using System.Collections;

public class enemy_sense : MonoBehaviour {

	// Use this for initialization
	public float detectionRate = 5.0f;
	public float stateRate = 10.0f;

	protected float elapsedTime_detect = 0.0f;
	protected float elapsedTime_state = 0.0f;
	protected Transform playerTransform;
	protected virtual void Initialize() {}
	protected virtual void UpdateSense() {}

	void Start () {
		elapsedTime_detect = 0.0f;
		elapsedTime_state = 0.0f;
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSense ();
	}
}
