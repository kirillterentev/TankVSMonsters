using System;
using Enemies;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterBumper : MonoBehaviour, IBumper
{
	private readonly float IntervalAttack = 1;

	[SerializeField]
	private Collider bumper;

	private Damage damage;
	private float timer = 0;

	private void Start()
	{
		timer = IntervalAttack;
		bumper.isTrigger = true;
		bumper.OnTriggerExitAsObservable()
			.Subscribe(_ => timer = IntervalAttack).AddTo(this);
		bumper.OnTriggerStayAsObservable()
			.Subscribe(collider => { TakeDamage(collider); }).AddTo(this);
	}

	public void SetAttackValue(Damage value)
	{
		damage = value;
	}

	private void TakeDamage(Collider collider)
	{
		var target = collider.GetComponent<IDamageble>();
		if (target != null && collider.tag == "Player")
		{
			if (timer >= IntervalAttack)
			{
				target.GetDamage(Random.Range(damage.Min, damage.Max));
				timer = 0;
			}
			else
			{
				timer += Time.deltaTime;
			}
		}
		else
		{
			timer = 0;
		}
	}
}
