using System;
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

		private IDisposable collisionStream;

		private void Start()
		{
			DoOnDestroy(() =>
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				collisionStream?.Dispose();
			});
		}

		private void TakeDamage(Collision collision)
		{
			var target = collision.collider.GetComponent<IDamageble>();
			target?.GetDamage(damage);
			destroyAction?.Invoke();
		}

		public override void Shoot(Vector3 direction)
		{
			collisionStream = collider.OnCollisionEnterAsObservable()
				.Subscribe(collision => { TakeDamage(collision); })
				.AddTo(this);

			rigidbody.AddForce(direction, ForceMode.VelocityChange);

			Observable.Timer(TimeSpan.FromSeconds(2))
				.Subscribe(_ =>
				{
					destroyAction?.Invoke();
				});
		}
	}
}

