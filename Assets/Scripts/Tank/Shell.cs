using UnityEngine;

namespace BattleVehicle
{
	public class Shell : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody rigidbody;

		protected internal void Shoot(Vector3 direction)
		{
			rigidbody.AddForce(direction, ForceMode.VelocityChange);
			Destroy(gameObject, 2);
		}
	}
}

