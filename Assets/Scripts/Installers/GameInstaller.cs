using BattleVehicle;
using Enemies;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject enemyFactory;

    public override void InstallBindings()
    {
		Container.BindFactory<EnemyType, AbstractEnemyController, EnemyFactory>().FromFactory<MonsterFactory>();
	    Container.BindFactory<AbstractVehicleController, VehicleFactory>().FromFactory<TankFactory>();
    }
}