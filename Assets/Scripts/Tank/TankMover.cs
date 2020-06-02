using BattleVehicle;
using UnityEngine;

public class TankMover : MonoBehaviour, IMover
{
	[SerializeField]
	private Rigidbody rigidbody;
	[SerializeField]
	private Transform tBody;

	public void SetMovingDirection(Vector2 direction)
	{
		rigidbody.MovePosition(rigidbody.position + direction.y * tBody.forward * Time.fixedDeltaTime);
	}

	public void SetMovingRotation(Vector2 rotation)
	{
		rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(rotation.x * Vector3.up * Time.fixedDeltaTime));
	}
}
