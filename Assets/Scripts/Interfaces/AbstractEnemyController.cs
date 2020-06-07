using System;
using BattleVehicle;
using UnityEngine;

namespace Enemies
{
	public abstract class AbstractEnemyController : MonoBehaviour
	{
		protected AbstractVehicleController vehicle;

		public virtual void Init(AbstractVehicleController vehicle)
		{
			this.vehicle = vehicle;
		}
	}
}

