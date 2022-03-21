using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : enemy_sense {

	public int fov = 45;
	public int vdistance = 200;
	public float rotspeed = 1.0f; 
	public float curspeed = 1.0f;

	private Vector3 rayDirection;
	private RaycastHit hit;
	private GameObject objPlayer;
	private int rnum;
	private bool check;

	Animation anim;
	List<string> aniar;

	// Use this for initialization
	protected override void Initialize() {

		objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		anim = gameObject.GetComponent<Animation> ();
		aniar = new List<string>();
		foreach (AnimationState state in anim) {
			aniar.Add (state.name);
		}
		anim.Play (aniar [0]);
		rnum = 0;
		check = false;
	}
	
	// Update is called once per frame
	protected override void UpdateSense() {
	
		elapsedTime_detect += Time.deltaTime;
		elapsedTime_state += Time.deltaTime;

		if (elapsedTime_detect >= detectionRate) {
						DetectAspect ();
				}
		if (elapsedTime_state >= stateRate) {
			if(check)
			{
				FSMUpdate ();
				elapsedTime_state = 0;
			}
			else
			{
				anim.CrossFade(aniar[0]);
			}
		}
		//if (rnum == 1 || rnum==4) {
		//	transform.Translate (Vector3.forward* Time.deltaTime * curspeed);
		//		}
	}

	void DetectAspect()
	{
				rayDirection = playerTransform.position - transform.position;

				if ((Vector3.Angle (rayDirection, transform.forward)) < fov) {
						if (Physics.Raycast (transform.position, rayDirection, out hit, vdistance)) {
								if (hit.collider.gameObject == objPlayer) {
										check = true;
										Quaternion tro = Quaternion.LookRotation (playerTransform.position - transform.position);
										transform.rotation = Quaternion.Slerp (transform.rotation, tro, Time.deltaTime * rotspeed);
										if (rnum == 1 || rnum==4) {
											transform.Translate (Vector3.forward* Time.deltaTime * curspeed);
										}
								} else {
										check = false;
								}
						} else {
								check = false;
						}
				} else {
						check = false;
				}
	}

	void FSMUpdate()
	{
		rnum = Random.Range (0, 5);
		switch (rnum%3) {
				case 1:
			anim.CrossFade (aniar [1]);
			//transform.Translate (new Vector3(0, 0, Time.deltaTime * curspeed));
						Debug.Log("GO");
						break;
				case 0 :
						Debug.Log("Attack");
			anim.CrossFade(aniar[4]);
						break;
				case 2:
			anim.CrossFade (aniar [3]);
						Debug.Log ("Power up");
						break;
				}
	}
}
