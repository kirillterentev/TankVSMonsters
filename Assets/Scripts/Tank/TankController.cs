using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class TankController : MonoBehaviour
	{
		private readonly float Speed = 2;
		private readonly Vector3 SpeedRot = 50 * Vector3.up;

		private IWeaponManager weaponManager;
		private Rigidbody rigidbody;
		private Transform tBody;

		[Inject]
		private IInputManager inputManager;

		void Awake()
		{
			weaponManager = GetComponentInChildren<IWeaponManager>();
			rigidbody = GetComponent<Rigidbody>();
			tBody = transform;

			inputManager.SubscribeToAxis("Vertical", (z) => rigidbody.MovePosition(rigidbody.position + z * tBody.forward * Speed * Time.fixedDeltaTime));
			inputManager.SubscribeToAxis("Horizontal", (x) => rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(x * SpeedRot * Time.fixedDeltaTime)));
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

