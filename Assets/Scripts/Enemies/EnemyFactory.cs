using Zenject;

namespace Enemies
{
	public class EnemyFactory : PlaceholderFactory<EnemyFactory.EnemyType, AbstractEnemyController>
	{
		public enum EnemyType
		{
			Tank,
			Soldier,
			Shooter
		}
	}
}

