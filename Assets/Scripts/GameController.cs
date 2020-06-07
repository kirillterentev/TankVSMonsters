using BattleVehicle;
using Enemies;
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
	[Inject]
	private SignalBus signalBus;

	private AbstractVehicleController vehicle;

	private void Start()
	{
		vehicle = vehicleFactory.Create();
		vehicle.Init();

		for(int i = 0; i < spawnPoints.Length; i++)
		{
			SpawnEnemy(spawnPoints[i].position);
		}

		camera.SetTarget(vehicle.transform);
		signalBus.Subscribe<EnemyKilledSignal>(EnemyKilled);
		signalBus.Subscribe<GameOverSignal>(GameOver);
	}

	private void EnemyKilled(EnemyKilledSignal signal)
	{
		enemyPool.Return(signal.enemy);
		SpawnEnemy(spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position);
	}

	private void GameOver(GameOverSignal signal)
	{
		vehicle.transform.position = new Vector3(0, 0.5f, 0);
		vehicle.Init();
	}

	private void SpawnEnemy(Vector3 position)
	{
		var enemy = enemyPool.Rent();
		enemy.transform.position = position;
		enemy.gameObject.SetActive(true);
		enemy.Init(vehicle);
	}
}
