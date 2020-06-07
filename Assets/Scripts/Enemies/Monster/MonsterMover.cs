using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
	public class MonsterMover : MonoBehaviour, IMover
	{
		[SerializeField]
		protected NavMeshAgent agent;
		[SerializeField]
		protected Transform tBody;

		public virtual void SetMovingDirection(Vector3 direction)
		{
			agent.SetDestination(direction);
		}

		public virtual void SetMovingRotation(Vector3 rotation)
		{
			agent.angularSpeed = rotation.y;
		}
	}
}

