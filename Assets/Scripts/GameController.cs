using BattleVehicle;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private Transform[] spawnPoints;

	[Inject]
	private AbstractEnemyControllerPool enemyPool;
	[Inject]
	private VehicleFactory vehicleFactory;
	[Inject]
	private ICamera camera;

	private AbstractVehicleController vehicle;

	private void Start()
	{
		vehicle = vehicleFactory.Create();

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			SpawnEnemy(spawnPoints[i].position);
		}

		camera.SetTarget(vehicle.transform);
	}

	private void SpawnEnemy(Vector3 position)
	{
		var enemy = enemyPool.Rent();
		enemy.transform.position = position;
		enemy.gameObject.SetActive(true);
		enemy.Init(vehicle);
		enemy.DoOnDestroy(() =>
		{
			var newEnemy = enemyPool.Rent();
			newEnemy.transform.position = position;
			newEnemy.gameObject.SetActive(true);
			enemy.Init(vehicle);
		});
	}
}
