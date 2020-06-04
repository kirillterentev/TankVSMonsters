using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class TankFactory : IFactory<AbstractVehicleController>
	{
		private readonly string PrefabPath = "Prefabs/Tank";

		private DiContainer diContainer;

		public TankFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public AbstractVehicleController Create()
		{
			return diContainer.InstantiatePrefabResourceForComponent<AbstractVehicleController>(PrefabPath, new Vector3(0, 0.5f, 0), Quaternion.identity, null);
		}
	}
}

