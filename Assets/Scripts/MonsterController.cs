using BattleVehicle;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Enemies
{
	public class MonsterController : MonoBehaviour
	{
		[SerializeField]
		private MonsterData monsterData;

		[Inject]
		private IIndicator monsterIndicator;

		[SerializeField]
		private NavMeshAgent agent;

		private Transform target;
		private TankController player;

		private void Start()
		{
			monsterIndicator.SetValue(0.7f);
		}

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
}

