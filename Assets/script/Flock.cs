using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flock : MonoBehaviour 
{
	internal FlockController controller;

	void Update()
	{
				if (controller) {
						Vector3 relativeVelocity = steer () * Time.deltaTime;

						if (relativeVelocity != Vector3.zero)
								rigidbody.velocity = relativeVelocity;

						float speed = rigidbody.velocity.magnitude;
						if (speed > controller.maxs) {
								rigidbody.velocity = rigidbody.velocity.normalized * controller.maxs;
						} else if (speed < controller.mins) {
								rigidbody.velocity = rigidbody.velocity.normalized * controller.mins;
						}
				}
		}
	private Vector3 steer()
	{
				Vector3 center = controller.flockCenter - transform.localPosition;
				Vector3 velocity = controller.flockVelocity - rigidbody.velocity;
				Vector3 follow = controller.target.localPosition - transform.localPosition;
				Vector3 separation = Vector3.zero;

				foreach (Flock flock in controller.flockList) {
						if (flock != this) {
								Vector3 relativePos = transform.localPosition - flock.transform.localPosition;
								separation += relativePos / (relativePos.sqrMagnitude);
						}
				}

				Vector3 randomize = new Vector3 ((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

				randomize.Normalize ();

				return (controller.centerw * center + controller.velocityw * velocity + controller.separationw * separation + controller.followw * follow + controller.randomw * randomize);
		}
}