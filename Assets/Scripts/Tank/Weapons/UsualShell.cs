using UnityEngine;

namespace BattleVehicle
{
	public class UsualShell : AbstractShell
	{
		[SerializeField]
		private Rigidbody rigidbody;

		public override void Shoot(Vector3 direction)
		{
			rigidbody.AddForce(direction, ForceMode.VelocityChange);
			Destroy(gameObject, 2);
		}
	}
}

