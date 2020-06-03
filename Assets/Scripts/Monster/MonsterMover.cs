using UnityEngine;
using UnityEngine.AI;

public class MonsterMover : MonoBehaviour, IMover
{
	[SerializeField]
	private NavMeshAgent agent;
	[SerializeField]
	private Transform tBody;

	public void SetMovingDirection(Vector3 direction)
	{
		agent.speed = direction.magnitude;
		agent.SetDestination(tBody.position + direction);
	}

	public void SetMovingRotation(Vector3 rotation)
	{
		agent.angularSpeed = rotation.y;
	}
}
