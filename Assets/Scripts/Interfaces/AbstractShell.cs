using UniRx.Triggers;
using UnityEngine;
using UniRx;

namespace BattleVehicle
{
	public abstract class AbstractShell : MonoBehaviour
	{
		[SerializeField]
		private Collider collider;
		private int damage;

		protected virtual void Start()
		{
			collider.OnCollisionEnterAsObservable()
				.Subscribe(collision => { TakeDamage(collision); })
				.AddTo(this);
		}

		public virtual void SetDamageValue(int value)
		{
			damage = value;
		}

		private void TakeDamage(Collision collision)
		{
			var target = collision.collider.GetComponent<IDamageble>();
			target?.GetDamage(damage);
			Destroy(gameObject);
		}

		public virtual void Shoot(Vector3 direction)
		{
			return;
		}
	}
}

