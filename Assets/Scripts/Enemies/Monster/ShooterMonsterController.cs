using BattleVehicle;
using Enemies;
using UnityEngine;

public class ShooterMonsterController : MonsterController
{
	private readonly float FireInterval = 2;

	private IWeapon weapon;
	private float timer = 0;

	private void Start()
	{
		weapon = GetComponentInChildren<IWeapon>();
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if ((vehicle.transform.position - transform.position).magnitude < 10)
		{
			if (timer > FireInterval)
			{
				weapon.Fire();
				timer = 0;
			}
			else
			{
				timer += Time.fixedDeltaTime;
			}
		}
		else
		{
			timer = 0;
		}
	}
}
