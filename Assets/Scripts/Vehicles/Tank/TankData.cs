using System;
using UnityEngine;

namespace BattleVehicle
{
	[Serializable]
	public class TankData
	{
		public float Speed;
		public float SpeedRot;
		[HideInInspector]
		public float Health;
		public float MaxHealth;
		public float Armor;
	}
}

