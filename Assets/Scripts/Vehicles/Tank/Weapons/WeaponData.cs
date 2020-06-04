using System;
using UnityEngine;

namespace BattleVehicle
{
	[Serializable]
	public class WeaponData
	{
		public Transform[] ShootPoints;
		public float SpeedFire;
		public int Damage;
		public AbstractShell ShellPrefab;
	}
}

