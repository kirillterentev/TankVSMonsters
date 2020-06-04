using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Enemies
{
	public class MonsterIndicator : MonoBehaviour, IIndicator
	{
		private Image image;
		private IDisposable showStream;

		public void Awake()
		{
			image = GetComponent<Image>();
			image.gameObject.SetActive(false);
		}

		public void SetValue(float value)
		{
			image.fillAmount = value;
			image.gameObject.SetActive(true);
			showStream?.Dispose();
			Observable.Timer(TimeSpan.FromSeconds(1))
				.Subscribe(_ => image.gameObject.SetActive(false)).AddTo(this);
		}
	}
}

