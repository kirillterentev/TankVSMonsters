using BattleVehicle;
using UnityEngine;

namespace BattleVehicle
{
	public class FirstWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private WeaponData weaponData;

		public void Fire()
		{
			var go = Instantiate(weaponData.ShellPrefab, weaponData.ShootPoints[0].position, Quaternion.identity) as Shell;
			go.Shoot(weaponData.ShootPoints[0].forward * weaponData.SpeedFire);
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
