using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockController : MonoBehaviour
{
	public float mins = 1;
	public float maxs = 8;
	public int flocksize = 5;
	public float centerw = 1;
	public float velocityw = 1;
	public float separationw = 1;
	public float followw = 1;
	public float randomw = 1;

	public Flock prefab;
	public Transform target;

	internal Vector3 flockCenter;
	internal Vector3 flockVelocity;

	public ArrayList flockList = new ArrayList();

	private float time = 0.0f;
	public GUIText SoulText;
	private int rnum = 0;

	void Start()
	{
			Flock flock = Instantiate (prefab, transform.position, transform.rotation) as Flock;
			flock.transform.parent = transform;
			flock.controller = this;
			flockList.Add (flock);
			SoulText.text = "영혼의 말소리가 들린다";
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.X)) {
			time+= Time.deltaTime;
			if(time>=1.0f)
			{
				Flock flock = Instantiate (prefab, transform.position, transform.rotation) as Flock;
				flock.transform.parent = transform;
				flock.controller = this;
				flockList.Add (flock);
				SoulSay ();
				time = 0.0f;
			}
		}
			Vector3 center = Vector3.zero;
			Vector3 velocity = Vector3.zero;

			foreach(Flock flock in flockList)
			{
				center += flock.transform.localPosition;
				velocity += rigidbody.velocity;
			}
			flockCenter = center / flocksize;
			flockVelocity = velocity / flocksize;
	}

	void SoulSay()
	{
		rnum = Random.Range (0, 8);
		string text = "";
		switch (rnum) {
				case 0:
						text = "나를 왜 죽였어...?";
						break;
				case 1:
						text = "제가 무슨 잘못을 했나요...?";
						break;
				case 2:
						text = "한번만.. 살려주세요...";
						break;
				case 3:
						text = "신이시여... 저를 구원해주시길..";
						break;
				case 4:
						text = "우리 아이만이라도...";
						break;
				case 5:
					text = "제발... 한번만...";
					break;
				case 6:
					text = "끝없는 비명소리가 들린다.";
					break;
				case 7:
					text = "저주나 받아라";
					break;
		}
		SoulText.text = text;
	}
}