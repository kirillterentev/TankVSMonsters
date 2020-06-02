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
		private IWeaponManager weaponManager;
		private IMover mover;

		void Awake()
		{
			weaponManager = GetComponentInChildren<IWeaponManager>();
			mover = GetComponent<IMover>();

			inputManager.SubscribeToAxis("Vertical", (z) => mover.SetMovingDirection(Up * z));
			inputManager.SubscribeToAxis("Horizontal", (x) => mover.SetMovingDirection(Right * x));
			inputManager.SubscribeToButtonDown("Fire", () => weaponManager.Fire());
			inputManager.SubscribeToButtonDown("NextWeapon", () => weaponManager.NextWeapon());
			inputManager.SubscribeToButtonDown("PrevWeapon", () => weaponManager.PrevWeapon());
		}

		public void Damage()
		{
			Debug.Log("Танк получил урон!");
		}
	}
}

