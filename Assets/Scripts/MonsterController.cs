using BattleVehicle;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent agent;

	private Transform target;
	private TankController player;

	void FixedUpdate()
	{
		if (target != null)
		{
			agent.SetDestination(target.position);
		}
	}

	public void SetTarget(TankController target)
	{
		this.target = target.transform;
		player = target;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Shell")
		{
			Debug.Log("Враг получил урон!");
			Destroy(other.collider.gameObject);
			return;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			player.Damage();
			return;
		}
	}
}
