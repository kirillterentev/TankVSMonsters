using BattleVehicle;
using Zenject;

public class ShellFactory : IFactory<string, AbstractShell>
{
	private readonly string PrefabsPath = "Prefabs";

	private DiContainer diContainer;

	public ShellFactory(DiContainer diContainer)
	{
		this.diContainer = diContainer;
	}

	public AbstractShell Create(string param)
	{
		return diContainer.InstantiatePrefabResourceForComponent<AbstractShell>($"{PrefabsPath}/{param}");
	}
}
