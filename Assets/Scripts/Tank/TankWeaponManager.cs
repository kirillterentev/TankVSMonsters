using UnityEngine;

namespace BattleVehicle
{
	public class TankWeaponManager : MonoBehaviour, IWeaponManager
	{
		private IWeapon[] weapons;
		private int prevWeaponIndex = 0;
		private int currentWeaponIndex = 0;

		private void Awake()
		{
			weapons = GetComponentsInChildren<IWeapon>();
		}

		private void Start()
		{
			for (int i = 0; i < weapons.Length; i++)
			{
				weapons[i].Unjoin();
			}
			
			weapons[currentWeaponIndex].Join();
		}

		public void NextWeapon()
		{
			prevWeaponIndex = currentWeaponIndex;
			if (++currentWeaponIndex >= weapons.Length)
			{
				currentWeaponIndex = 0;
			}

			weapons[prevWeaponIndex].Unjoin();
			weapons[currentWeaponIndex].Join();
		}

		public void PrevWeapon()
		{
			prevWeaponIndex = currentWeaponIndex;
			if (--currentWeaponIndex < 0)
			{
				currentWeaponIndex = weapons.Length - 1;
			}

			weapons[prevWeaponIndex].Unjoin();
			weapons[currentWeaponIndex].Join();
		}

		public void Fire()
		{
			weapons[currentWeaponIndex].Fire();
		}
	}
}
