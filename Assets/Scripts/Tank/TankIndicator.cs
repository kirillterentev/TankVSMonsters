using UnityEngine;
using UnityEngine.UI;

namespace BattleVehicle
{
	public class TankIndicator : MonoBehaviour, IIndicator
	{
		private Image image;
		private float max;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		public void SetMaxValue(float max)
		{
			this.max = max;
		}

		public void SetValue(float value)
		{
			image.fillAmount = Mathf.Clamp01(value / max);
		}
	}
}

