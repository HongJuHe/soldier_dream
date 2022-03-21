using UnityEngine;
using System.Collections;

public class main2_target : target 
{
	public enum FSMState
	{
		None,
		Patrol,
		Chase
	}

	public FSMState curState;
	private NavMeshAgent agent;

	protected override void Initialize () 
	{
		curState = FSMState.Patrol;
		agent = GetComponent<NavMeshAgent> ();
		pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
		FindNextPoint();

		GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;
		
		if(!playerTransform)
			print("Player doesn't exist.. Please add one with Tag named 'Player'");
	}

	protected override void FSMUpdate()
	{
		switch (curState)
		{
		case FSMState.Patrol: UpdatePatrolState(); break;
		case FSMState.Chase: UpdateChaseState(); break;
		}
	}

	protected void UpdatePatrolState()
	{
		if (Vector3.Distance(transform.position, destPos) <= 300.0f)
		{
			print("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}

		else if (Vector3.Distance(transform.position, playerTransform.position) <= 300.0f)
		{
			curState = FSMState.Chase;
			print("Switch to "+ curState.ToString()+ "Position");
		}
		
		agent.SetDestination (destPos);
	}

	protected void UpdateChaseState()
	{
		destPos = playerTransform.position;
		float dist = Vector3.Distance(transform.position, playerTransform.position);

		if (dist >= 300.0f)
		{
			curState = FSMState.Patrol;
		}

		agent.SetDestination (destPos);
		
	}

	protected void FindNextPoint()
	{
		print("Finding next point");
		int rndIndex = Random.Range(0, pointList.Length);
		float rndRadius = 10.0f;
		
		Vector3 rndPosition = Vector3.zero;
		destPos = pointList[rndIndex].transform.position + rndPosition;

		if (IsInCurrentRange(destPos))
		{
			rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
			destPos = pointList[rndIndex].transform.position + rndPosition;
		}
	}

	protected bool IsInCurrentRange(Vector3 pos)
	{
		float xPos = Mathf.Abs(pos.x - transform.position.x);
		float zPos = Mathf.Abs(pos.z - transform.position.z);
		
		if (xPos <= 50 && zPos <= 50)
			return true;
		
		return false;
	}
	
}
