using BattleVehicle;
using UnityEngine;

namespace BattleVehicle
{
	public class FirstWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform shootPoint;
		[SerializeField] private float speedFire;
		[SerializeField] private Shell shellPrefab;

		public void Fire()
		{
			var go = Instantiate(shellPrefab, shootPoint.position, Quaternion.identity) as Shell;
			go.Shoot(shootPoint.forward * speedFire);
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
