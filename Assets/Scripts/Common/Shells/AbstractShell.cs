using UniRx.Triggers;
using UnityEngine;
using UniRx;

namespace BattleVehicle
{
	public abstract class AbstractShell : MonoBehaviour
	{
		protected int damage;

		public void SetDamageValue(int value)
		{
			damage = value;
		}

		public virtual void Shoot(Vector3 direction)
		{
			return;
		}
	}
}

