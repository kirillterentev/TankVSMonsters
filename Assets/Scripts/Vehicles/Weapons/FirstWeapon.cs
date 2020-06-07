using UnityEngine;
using Zenject;

namespace BattleVehicle
{
	public class FirstWeapon : MonoBehaviour, IWeapon
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
			var go = shellPool.Rent();
			go.transform.position = weaponData.ShootPoints[0].position;
			go.transform.rotation = Quaternion.identity;
			go.gameObject.SetActive(true);
			go.Shoot(weaponData.ShootPoints[0].forward * weaponData.SpeedFire);
			go.SetDamageValue(weaponData.Damage);
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
