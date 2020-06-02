using UnityEngine;

namespace BattleVehicle
{
	public class SecondWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform[] shootPoint;
		[SerializeField] private float speedFire;
		[SerializeField] private Shell shellPrefab;

		public void Fire()
		{
			for (int i = 0; i < shootPoint.Length; i++)
			{
				var go = Instantiate(shellPrefab, shootPoint[i].position, Quaternion.identity) as Shell;
				go.Shoot(shootPoint[i].forward * speedFire);
			}
		}

		public void Join()
		{
			gameObject.SetActive(true);
		}

		public void Unjoin()
		{
			gameObject.SetActive(false);
		}
	}
}
