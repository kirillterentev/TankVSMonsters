using System;
using UniRx;
using UnityEngine;

public class TankInputManager : MonoBehaviour, IInputManager
{
	public void SubscribeToAxis(string axis, Action<float> action)
	{
		gameObject.AddComponent<ObservableGetAxisTrigger>().OnGetAxisAsObservable(axis).Subscribe(x => action.Invoke(x));
	}

	public void SubscribeToButtonDown(string button, Action action)
	{
		gameObject.AddComponent<ObservableGetButtonDownTrigger>().OnGetButtonDownAsObservable(button).Subscribe(_=> action.Invoke());
	}
}
