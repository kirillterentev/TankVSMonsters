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

		protected virtual void FixedUpdate()
		{
			monsterMover.SetMovingDirection(vehicle.transform.position);
		}

		public virtual void GetDamage(int value)
		{
			monsterData.Health -= value * monsterData.Armor;
			if (monsterData.Health <= 0)
			{
				signalBus.Fire(new EnemyKilledSignal(){enemy = this});
			}
		}
	}
}

