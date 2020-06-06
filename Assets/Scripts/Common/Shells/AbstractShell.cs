using System;
using UniRx.Triggers;
using UnityEngine;
using UniRx;

namespace BattleVehicle
{
	public abstract class AbstractShell : MonoBehaviour
	{
		protected int damage;
		protected Action destroyAction;

		public void SetDamageValue(int value)
		{
			damage = value;
		}

		public virtual void Shoot(Vector3 direction)
		{
			return;
		}

		public virtual void DoOnDestroy(Action action)
		{
			destroyAction += action;
		}
	}
}

