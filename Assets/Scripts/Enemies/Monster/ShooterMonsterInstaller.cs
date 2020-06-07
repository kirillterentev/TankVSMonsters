using BattleVehicle;
using Enemies;

public class ShooterMonsterInstaller : MonsterInstaller
{
	public override void InstallBindings()
	{
		base.InstallBindings();
		Container.Bind<AbstractShellPool>().To<ShellPool>().AsTransient().NonLazy();
		Container.BindFactory<string, AbstractShell, AbstractShellFactory>().FromFactory<ShellFactory>();
	}
}
