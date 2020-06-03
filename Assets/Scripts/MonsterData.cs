using System;
using UnityEngine;

namespace Enemies
{
	[Serializable]
	public class MonsterData
	{
		[HideInInspector]
		public int Health;
		public int MaxHealth;
		[HideInInspector]
		public int Armor;
		public int MaxArmor;
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

