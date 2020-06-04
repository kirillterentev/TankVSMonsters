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
		private IIndicator monsterIndicator;
		[Inject]
		private IMover monsterMover;
		[Inject]
		private IBumper monsterBumper;
		private TankController player;

		private void Start()
		{
			monsterData.Health = monsterData.MaxHealth;
			monsterIndicator.SetValue(monsterData.Health / monsterData.MaxHealth);
			monsterMover.SetMovingRotation(Up * monsterData.SpeedRot);
			monsterBumper.SetAttackValue(monsterData.Damage);
		}

		public void GetDamage(int value)
		{
			Debug.Log("Монстр получил урон");
			monsterData.Health -= value * monsterData.Armor;
			monsterIndicator.SetValue(monsterData.Health / monsterData.MaxHealth);
		}
	}
}

