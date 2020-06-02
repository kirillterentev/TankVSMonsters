using UnityEngine;

namespace BattleVehicle
{
	public interface IMover
	{
		void SetMovingDirection(Vector2 direction);
		void SetMovingRotation(Vector2 rotation);
	}
}


