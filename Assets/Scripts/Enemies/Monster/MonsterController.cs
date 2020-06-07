using BattleVehicle;
using UnityEngine;
using Zenject;

namespace Enemies
{
	public class MonsterController : AbstractEnemyController, IDamageble
	{
		private readonly Vector3 Up = Vector3.up;

		[SerializeField]
		private MonsterData monsterData;

		[Inject]
		private IMover monsterMover;
		[Inject]
		private IBumper monsterBumper;
		[Inject]
		private SignalBus signalBus;

		public override void Init(AbstractVehicleController vehicle)
		{
			base.Init(vehicle);
			monsterData.Health = monsterData.MaxHealth;
			monsterMover.SetMovingRotation(Up * monsterData.SpeedRot);
			monsterBumper.SetAttackValue(monsterData.Damage);
		}

		private void FixedUpdate()
		{
			monsterMover.SetMovingDirection(vehicle.transform.position);
		}

		public void GetDamage(int value)
		{
			Debug.Log("Монстр получил урон");
			monsterData.Health -= value * monsterData.Armor;
			if (monsterData.Health <= 0)
			{
				signalBus.Fire(new EnemyKilledSignal(){enemy = this});
			}
		}
	}
}

