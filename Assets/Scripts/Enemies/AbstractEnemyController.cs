using System;
using BattleVehicle;
using UnityEngine;

namespace Enemies
{
	public abstract class AbstractEnemyController : MonoBehaviour
	{
		protected AbstractVehicleController vehicle;
		protected Action destroyAction;

		public virtual void Init(AbstractVehicleController vehicle)
		{
			this.vehicle = vehicle;
		}

		public virtual void DoOnDestroy(Action action)
		{
			destroyAction += action;
		}
	}
}

