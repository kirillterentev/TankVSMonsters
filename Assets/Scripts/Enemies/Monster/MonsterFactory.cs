using UnityEngine;
using Zenject;

namespace Enemies
{
	public class MonsterFactory : IFactory<EnemyFactory.EnemyType, AbstractEnemyController>
	{
		private readonly string PrefabsFolder = "Prefabs/Monsters";

		private DiContainer diContainer;
		private Transform parent;

		public MonsterFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
			parent = new GameObject("Monsters").transform;
		}

		public AbstractEnemyController Create(EnemyFactory.EnemyType param)
		{
			return diContainer.InstantiatePrefabResourceForComponent<MonsterController>(
				$"{PrefabsFolder}/{param.ToString()}", 
				new Vector3(0, 0.5f, -10), 
				Quaternion.identity, 
				parent);
		}
	}
}

