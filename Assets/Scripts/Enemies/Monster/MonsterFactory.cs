using UnityEngine;
using Zenject;

namespace Enemies
{
	public enum EnemyType
	{
		Soldier,
		Tank,
		Shooter
	}

	public class MonsterFactory : IFactory<EnemyType, MonsterController>
	{
		private readonly string PrefabsFolder = "Prefabs";

		private DiContainer diContainer;

		public MonsterFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public MonsterController Create(EnemyType param)
		{
			switch (param)
			{
				case EnemyType.Soldier: return diContainer.InstantiatePrefabResourceForComponent<MonsterController>($"{PrefabsFolder}/{param.ToString()}", Vector3.zero, Quaternion.identity, null);
				default: return null;
			}
		}
	}
}

