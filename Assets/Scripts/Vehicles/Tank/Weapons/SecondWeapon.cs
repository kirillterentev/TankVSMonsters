using UnityEngine;

namespace BattleVehicle
{
	public class SecondWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private WeaponData weaponData;

		public void Fire()
		{
			for (int i = 0; i < weaponData.ShootPoints.Length; i++)
			{
				var go = Instantiate(weaponData.ShellPrefab, weaponData.ShootPoints[i].position, Quaternion.identity) as UsualShell;
				go.Shoot(weaponData.ShootPoints[i].forward * weaponData.SpeedFire);
				go.SetDamageValue(weaponData.Damage);
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
