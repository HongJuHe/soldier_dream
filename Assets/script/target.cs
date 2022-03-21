using UnityEngine;
using System.Collections;

public class target : MonoBehaviour 
{
	protected Transform playerTransform;

	protected Vector3 destPos;

	protected GameObject[] pointList;
	
	protected virtual void Initialize() { }
	protected virtual void FSMUpdate() { }
	protected virtual void FSMFixedUpdate() { }
	

	void Start () 
	{
		Initialize();
	}
	
	// Update is called once per frame
	void Update () 
	{
		FSMUpdate();
	}
	
	void FixedUpdate()
	{
		FSMFixedUpdate();
	}    
}
