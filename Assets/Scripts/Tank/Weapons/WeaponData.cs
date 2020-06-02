using System;
using UnityEngine;

namespace BattleVehicle
{
	[Serializable]
	public class WeaponData
	{
		public Transform[] ShootPoints;
		public float SpeedFire;
		public Shell ShellPrefab;
	}
}

