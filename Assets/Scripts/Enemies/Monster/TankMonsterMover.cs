using UnityEngine;

public class TankMonsterMover : MonsterMover
{
	public override void SetMovingDirection(Vector3 direction)
	{
		if (Quaternion.Angle(tBody.rotation, Quaternion.LookRotation(direction - tBody.position)) > 10f)
		{
			tBody.Rotate(Vector3.up, agent.angularSpeed * Time.fixedDeltaTime);
			return;
		}

		base.SetMovingDirection(direction);
	}
}
