using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace BattleVehicle
{
	public class UsualShell : AbstractShell
	{
		[SerializeField]
		private Rigidbody rigidbody;
		[SerializeField]
		private Collider collider;

		private void Start()
		{
			collider.OnCollisionEnterAsObservable()
				.Subscribe(collision => { TakeDamage(collision); })
				.AddTo(this);
		}

		private void TakeDamage(Collision collision)
		{
			var target = collision.collider.GetComponent<IDamageble>();
			target?.GetDamage(damage);
			Destroy(gameObject);
		}

		public override void Shoot(Vector3 direction)
		{
			rigidbody.AddForce(direction, ForceMode.VelocityChange);
			Destroy(gameObject, 2);
		}
	}
}

