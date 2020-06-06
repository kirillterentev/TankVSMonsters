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
			for (int i = 0; i < weaponData.ShootPoints.Length; i++)
			{
				var go = shellPool.Rent();
				go.transform.position = weaponData.ShootPoints[i].position;
				go.transform.rotation = Quaternion.identity;
				go.Shoot(weaponData.ShootPoints[0].forward * weaponData.SpeedFire);
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
