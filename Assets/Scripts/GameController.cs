using Enemies;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
	[Inject]
	private EnemyFactory enemyFactory;

	private void Start()
	{
		enemyFactory.Create(EnemyType.Soldier);
	}
}
