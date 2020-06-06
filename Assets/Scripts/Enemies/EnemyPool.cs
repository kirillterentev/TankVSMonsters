using System;
using BattleVehicle;
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
		
		return enemyFactory.Create((EnemyFactory.EnemyType)values.GetValue(Random.Range(0, values.Length - 1)));
	}

	protected override void OnBeforeReturn(AbstractEnemyController instance)
	{
		base.OnBeforeReturn(instance);
		instance.Init(null);
	}
}
