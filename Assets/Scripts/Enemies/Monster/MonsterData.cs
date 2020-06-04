using System;
using UnityEngine;

namespace Enemies
{
	[Serializable]
	public class MonsterData
	{
		[HideInInspector]
		public float Health;
		public float MaxHealth;
		public float Armor;
		public Damage Damage;
		public int Speed;
		public int SpeedRot;
	}

	[Serializable]
	public class Damage
	{
		public int Min;
		public int Max;
	}
}

