using System;
using BattleVehicle;
using UnityEngine;
using Zenject;

[Serializable]
public class WeaponData
{
	public Transform[] ShootPoints;
	public float SpeedFire;
	public int Damage;
	public string ShellPrefabName;
}

public class MonsterWeapon : MonoBehaviour, IWeapon
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
		var shell = shellPool.Rent();
		shell.transform.position = weaponData.ShootPoints[0].position;
		shell.gameObject.SetActive(true);
		shell.SetDamageValue(weaponData.Damage);
		shell.Shoot(transform.forward * weaponData.SpeedFire);
	}

	public void Join()
	{
		throw new System.NotImplementedException();
	}

	public void Unjoin()
	{
		throw new System.NotImplementedException();
	}
}
