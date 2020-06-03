using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class TankController : MonoBehaviour
	{
		private readonly Vector2 Up = Vector2.up;
		private readonly Vector2 Right = Vector2.right;

		[SerializeField]
		private TankData tankData;

		[Inject]
		private IInputManager inputManager;
		[Inject(Id = "TankHealthBar")]
		private IIndicator healthBar;
		[Inject(Id = "TankArmorBar")]
		private IIndicator armorBar;
		private IWeaponManager weaponManager;
		private IMover mover;

		void Awake()
		{
			weaponManager = GetComponentInChildren<IWeaponManager>();
			mover = GetComponent<IMover>();

			inputManager.SubscribeToAxis("Vertical", (z) => mover.SetMovingDirection(Up * z * tankData.Speed));
			inputManager.SubscribeToAxis("Horizontal", (x) => mover.SetMovingRotation(Right * x * tankData.SpeedRot));
			inputManager.SubscribeToButtonDown("Fire", () => weaponManager.Fire());
			inputManager.SubscribeToButtonDown("NextWeapon", () => weaponManager.NextWeapon());
			inputManager.SubscribeToButtonDown("PrevWeapon", () => weaponManager.PrevWeapon());
		}

		void Start()
		{
			healthBar.SetValue(0.5f);
			armorBar.SetValue(0.7f);
		}

		public void Damage()
		{
			Debug.Log("Танк получил урон!");
		}
	}
}

