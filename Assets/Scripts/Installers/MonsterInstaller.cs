using UnityEngine;
using Zenject;

namespace Enemies
{
	public class MonsterInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject healthBar;

		public override void InstallBindings()
		{
			Container.Bind<IIndicator>().To<MonsterIndicator>()
				.FromNewComponentOn(healthBar).AsTransient();
		}
	}
}

