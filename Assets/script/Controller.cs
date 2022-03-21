using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public float walkspeed = 30f;
	public float jumpspeed = 50f;
	public float gravity = 10f;
	public float rotspeed = 30f;
	//public ParticleSystem slash;

	private Vector3 velocity;
	Animation anim;
	List<string> aniar;
	private CharacterController controller;
	
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animation> ();
		aniar = new List<string>();
		foreach (AnimationState state in anim) {
			aniar.Add (state.name);
		}
		anim.Play (aniar [0]);
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (controller.isGrounded) {
			velocity = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			velocity = transform.TransformDirection(velocity);
			velocity *= walkspeed;
			if(Input.GetButton("Jump"))
			{
				velocity.y = jumpspeed;
				anim.Play(aniar[2]);
			}
			else if (velocity.magnitude>0.5) {
				anim.CrossFade (aniar [1]);
			}
			else if(Input.GetKey(KeyCode.F)){
				anim.CrossFade(aniar[3]);
			}
			else if(Input.GetKey(KeyCode.X))
			{
				anim.CrossFade(aniar[4]);
				//Quaternion srot = new Quaternion(0, 0, transform.rotation.eulerAngles.y*Mathf.Deg2Rad*0.5f, 0);
				//Quaternion srot = new Quaternion(0,0 , 0, 0);
				//Instantiate(slash, transform.position+new Vector3(0, 20, 30), srot);
			}
			else
			{
				anim.CrossFade(aniar[0]);
			}
		}
		velocity.y -= gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
		transform.Rotate(0, Input.GetAxis("Horizontal")*rotspeed*Time.deltaTime, 0.0f);
	}
}