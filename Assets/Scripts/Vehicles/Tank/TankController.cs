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

		private void Start()
		{
			tankData.Health = tankData.MaxHealth;
			healthBar.SetValue(tankData.Health / tankData.MaxHealth);

			inputManager.SubscribeToAxis("Vertical", (z) => mover.SetMovingDirection(Up * z * tankData.Speed));
			inputManager.SubscribeToAxis("Horizontal", (x) => mover.SetMovingRotation(Right * x * tankData.SpeedRot));
			inputManager.SubscribeToButtonDown("Fire", () => weaponManager.Fire());
			inputManager.SubscribeToButtonDown("NextWeapon", () => weaponManager.NextWeapon());
			inputManager.SubscribeToButtonDown("PrevWeapon", () => weaponManager.PrevWeapon());
		}

		public void GetDamage(int value)
		{
			Debug.Log("Танк получил урон");
			tankData.Health -= value * tankData.Armor;
			healthBar.SetValue(tankData.Health / tankData.MaxHealth);
		}
	}
}

