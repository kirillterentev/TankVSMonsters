using BattleVehicle;
using UnityEngine;
using Zenject;

public class ShellFactory : IFactory<string, AbstractShell>
{
	private readonly string PrefabsPath = "Prefabs/Shells";

	private DiContainer diContainer;
	private Transform parent;

	public ShellFactory(DiContainer diContainer)
	{
		this.diContainer = diContainer;
		parent = new GameObject("Shells").transform;
	}

	public AbstractShell Create(string param)
	{
		return diContainer.InstantiatePrefabResourceForComponent<AbstractShell>(
			$"{PrefabsPath}/{param}",
			parent);
	}
}
