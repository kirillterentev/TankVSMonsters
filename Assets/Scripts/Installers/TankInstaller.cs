using BattleVehicle;
using UnityEngine;
using Zenject;

public class TankInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject healthBar;
	[SerializeField]
	private GameObject armorBar;

	public override void InstallBindings()
	{
		Container.Bind<IIndicator>().WithId("TankHealthBar").To<TankIndicator>()
			.FromNewComponentOn(healthBar).AsTransient();

		Container.Bind<IIndicator>().WithId("TankArmorBar").To<TankIndicator>()
			.FromNewComponentOn(armorBar).AsTransient();
	}
}
