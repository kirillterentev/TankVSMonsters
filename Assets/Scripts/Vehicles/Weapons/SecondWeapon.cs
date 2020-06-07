using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class SecondWeapon : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private WeaponData weaponData;

		[Inject]
		private AbstractShellPool shellPool;

		private void Start()
		{
			shellPool.SetPoolableObject(weaponData.ShellPrefabName);
		}

		public void Fire()
		{
			var go1 = shellPool.Rent();
			var go2 = shellPool.Rent();
			go1.transform.SetPositionAndRotation(weaponData.ShootPoints[0].position, Quaternion.identity);
			go2.transform.SetPositionAndRotation(weaponData.ShootPoints[1].position, Quaternion.identity);
			go1.gameObject.SetActive(true);
			go2.gameObject.SetActive(true);
			go1.Shoot(weaponData.ShootPoints[0].forward * weaponData.SpeedFire);
			go1.SetDamageValue(weaponData.Damage);
			go2.Shoot(weaponData.ShootPoints[1].forward * weaponData.SpeedFire);
			go2.SetDamageValue(weaponData.Damage);
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
