using UnityEngine;

namespace BattleVehicle
{
	public class TankMover : MonoBehaviour, IMover
	{
		[SerializeField]
		private Rigidbody rigidbody;
		[SerializeField]
		private Transform tBody;

		public void SetMovingDirection(Vector3 direction)
		{
			rigidbody.MovePosition(rigidbody.position + direction.y * tBody.forward * Time.deltaTime);
		}

		public void SetMovingRotation(Vector3 rotation)
		{
			rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(rotation.x * Vector3.up * Time.deltaTime));
		}

		private void OnCollisionStay(Collision collision)
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}

}
