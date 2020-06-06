using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Vector3 offset;
	private Transform target;

	public void SetTarget(Transform target)
	{
		this.target = target;
	}

	private void LateUpdate()
	{
		if (!target)
		{
			return;
		}

		transform.position = target.position + offset;
	}
}
