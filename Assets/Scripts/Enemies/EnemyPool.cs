using System;
using Enemies;
using Zenject;
using Random = UnityEngine.Random;

public class EnemyPool : AbstractEnemyControllerPool
{
	[Inject]
	private EnemyFactory enemyFactory;

	private Array values;

	protected override AbstractEnemyController CreateInstance()
	{
		if (values == null)
		{
			values = Enum.GetValues(typeof(EnemyFactory.EnemyType));
		}
		
		var enemy = enemyFactory.Create((EnemyFactory.EnemyType)values.GetValue(Random.Range(0, values.Length)));
		enemy.DoOnDestroy(() => Return(enemy));
		return enemy;
	}

	protected override void OnBeforeRent(AbstractEnemyController instance)
	{

	}
}
