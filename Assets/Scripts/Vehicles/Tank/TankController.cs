using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class TankController : AbstractVehicleController, IDamageble
	{
		private readonly Vector2 Up = Vector2.up;
		private readonly Vector2 Right = Vector2.right;

		[SerializeField]
		private TankData tankData;

		[Inject]
		private IInputManager inputManager;
		[Inject]
		private IIndicator healthBar;
		[Inject]
		private IWeaponManager weaponManager;
		[Inject]
		private IMover mover;
		[Inject]
		private SignalBus signalBus;

		private void Start()
		{
			inputManager.SubscribeToAxis("Vertical", (z) => mover.SetMovingDirection(Up * z * tankData.Speed));
			inputManager.SubscribeToAxis("Horizontal", (x) => mover.SetMovingRotation(Right * x * tankData.SpeedRot));
			inputManager.SubscribeToButtonDown("Fire", () => weaponManager.Fire());
			inputManager.SubscribeToButtonDown("NextWeapon", () => weaponManager.NextWeapon());
			inputManager.SubscribeToButtonDown("PrevWeapon", () => weaponManager.PrevWeapon());
		}

		public override void Init()
		{
			tankData.Health = tankData.MaxHealth;
			healthBar.SetValue(tankData.Health / tankData.MaxHealth);
		}

		public void GetDamage(int value)
		{
			tankData.Health -= value * tankData.Armor;
			healthBar.SetValue(tankData.Health / tankData.MaxHealth);
			if (tankData.Health <= 0)
			{
				signalBus.Fire(new GameOverSignal());
			}
		}
	}
}

