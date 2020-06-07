using System;
using UnityEngine;

namespace Enemies
{
	[Serializable]
	public class MonsterData
	{
		public float Health;
		public float MaxHealth;
		public float Armor;
		public Damage Damage;
		public int Speed;
		public int SpeedRot;
	}
}

