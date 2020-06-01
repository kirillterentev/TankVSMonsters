using UnityEngine;

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
		private Vector3 movementVector;
		private Transform tBody;

		void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
			movementVector = Vector3.zero;
			tBody = transform;
		}

		void FixedUpdate()
		{
			movementVector.x = Input.GetAxis("Horizontal");
			movementVector.z = Input.GetAxis("Vertical");

			rigidbody.MovePosition(rigidbody.position + movementVector.z * tBody.forward * Speed * Time.fixedDeltaTime);
			rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(movementVector.x * SpeedRot * Time.fixedDeltaTime));

			if (Input.GetKeyDown(KeyCode.X))
			{
				Fire();
			}
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

