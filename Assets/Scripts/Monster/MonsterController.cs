using BattleVehicle;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Enemies
{
	public class MonsterController : MonoBehaviour, IDamageble
	{
		private readonly Vector3 Up = Vector3.up;

		[SerializeField]
		private MonsterData monsterData;
		[SerializeField]
		private Transform tBody;
		[SerializeField]
		private Transform target;

		[Inject]
		private IIndicator monsterIndicator;
		private IMover monsterMover;
		private IBumper monsterBumper;

		private TankController player;

		private void Start()
		{
			monsterBumper = GetComponent<IBumper>();
			monsterMover = GetComponent<IMover>();
			monsterData.Health = monsterData.MaxHealth;
			monsterIndicator.SetValue(monsterData.Health / monsterData.MaxHealth);
			monsterMover.SetMovingRotation(Up * monsterData.SpeedRot);
			monsterBumper.SetAttackValue(monsterData.Damage);
		}

		void FixedUpdate()
		{
			if (target != null)
			{
				monsterMover.SetMovingDirection((target.position - tBody.position).normalized * monsterData.Speed);
			}
		}

		public void GetDamage(int value)
		{
			Debug.Log("Монстр получил урон");
			monsterData.Health -= value * monsterData.Armor;
			monsterIndicator.SetValue(monsterData.Health / monsterData.MaxHealth);
		}
	}
}

