using UnityEngine;
using Zenject;

namespace Enemies
{
	public class MonsterInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject monsterIndicator;
		[SerializeField]
		private GameObject monsterMover;
		[SerializeField]
		private GameObject monsterBumper;

		public override void InstallBindings()
		{
			Container.Bind<IIndicator>().To<MonsterIndicator>()
				.FromComponentOn(monsterIndicator).AsSingle();
			Container.Bind<IMover>().To<MonsterMover>()
				.FromComponentOn(monsterMover).AsSingle();
			Container.Bind<IBumper>().To<MonsterBumper>()
				.FromComponentOn(monsterBumper).AsSingle();
		}
	}
}

