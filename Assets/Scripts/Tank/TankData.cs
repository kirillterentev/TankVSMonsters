using System;
using UnityEngine;

namespace BattleVehicle
{
	[Serializable]
	public class TankData
	{
		public float Speed;
		public float SpeedRot;
		[HideInInspector] public int Health;
		public int MaxHealth;
		[HideInInspector] public int Armor;
		public int MaxArmor;
	}
}

