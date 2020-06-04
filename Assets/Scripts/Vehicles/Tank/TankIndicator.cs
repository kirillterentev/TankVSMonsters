using UnityEngine;
using UnityEngine.UI;

namespace BattleVehicle
{
	public class TankIndicator : MonoBehaviour, IIndicator
	{
		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		public void SetValue(float value)
		{
			image.fillAmount = value;
		}
	}
}

