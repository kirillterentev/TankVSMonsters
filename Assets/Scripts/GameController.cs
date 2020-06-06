using BattleVehicle;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
	[Inject]
	private AbstractEnemyControllerPool enemyPool;
	[Inject]
	private VehicleFactory vehicleFactory;

	private AbstractVehicleController vehicle;

	private void Start()
	{
		vehicle = vehicleFactory.Create();
		var enemy = enemyPool.Rent();
		enemy.Init(vehicle);
	}
}
