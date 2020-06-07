using BattleVehicle;
using Enemies;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject camera;

    public override void InstallBindings()
    {
	    Container.BindFactory<EnemyFactory.EnemyType, AbstractEnemyController, EnemyFactory>().FromFactory<MonsterFactory>();
		Container.Bind<AbstractEnemyControllerPool>().To<EnemyPool>().AsSingle().NonLazy();
	    Container.BindFactory<AbstractVehicleController, VehicleFactory>().FromFactory<TankFactory>();
	    Container.Bind<ICamera>().To<MovementCamera>().FromComponentOn(camera).AsSingle();
    }
}