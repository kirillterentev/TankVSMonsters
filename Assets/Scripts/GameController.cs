using BattleVehicle;
using Enemies;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
	[Inject]
	private EnemyFactory enemyFactory;
	[Inject]
	private VehicleFactory vehicleFactory;

	private void Start()
	{
		enemyFactory.Create(EnemyType.Soldier);
		vehicleFactory.Create();
	}
}
