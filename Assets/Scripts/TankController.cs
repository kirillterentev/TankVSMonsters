using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class TankController : MonoBehaviour
	{
		private readonly float Speed = 2;
		private readonly float SpeedShell = 10;
		private readonly Vector3 SpeedRot = 50 * Vector3.up;

		[SerializeField]
		private Transform shootPoint;
		[SerializeField]
		private Shell shellPrefab;

		private Rigidbody rigidbody;
		private Transform tBody;

		[Inject]
		private IInputManager inputManager;

		void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
			tBody = transform;

			inputManager.SubscribeToAxis("Vertical", (z) => rigidbody.MovePosition(rigidbody.position + z * tBody.forward * Speed * Time.fixedDeltaTime));
			inputManager.SubscribeToAxis("Horizontal", (x) => rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(x * SpeedRot * Time.fixedDeltaTime)));
			inputManager.SubscribeToButtonDown("Fire", () => Fire());
		}

		void Fire()
		{
			var go = Instantiate(shellPrefab, shootPoint.position, Quaternion.identity) as Shell;
			go.Shoot(tBody.forward * SpeedShell);
		}

		public void Damage()
		{
			Debug.Log("Танк получил урон!");
		}
	}
}

