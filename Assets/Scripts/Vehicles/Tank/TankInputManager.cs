using System;
using UniRx;
using UnityEngine;

namespace BattleVehicle
{
	public class TankInputManager : MonoBehaviour, IInputManager
	{
		private ObservableGetAxisTrigger axisTrigger;
		private ObservableGetButtonDownTrigger buttonTrigger;

		private void Awake()
		{
			axisTrigger = gameObject.AddComponent<ObservableGetAxisTrigger>();
			buttonTrigger = gameObject.AddComponent<ObservableGetButtonDownTrigger>();
		}

		public void SubscribeToAxis(string axis, Action<float> action)
		{
			axisTrigger.OnGetAxisAsObservable(axis).Subscribe(x => action.Invoke(x));
		}

		public void SubscribeToButtonDown(string button, Action action)
		{
			buttonTrigger.OnGetButtonDownAsObservable(button).Subscribe(_ => action.Invoke());
		}
	}
}

