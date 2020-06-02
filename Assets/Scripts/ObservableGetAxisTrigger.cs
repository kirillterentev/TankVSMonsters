using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableGetAxisTrigger : ObservableTriggerBase
{
	private Subject<float> onGetAxis;
	private string axis;

	void Update()
	{
		if (Input.GetAxis(axis) != 0)
		{
			onGetAxis?.OnNext(Input.GetAxis(axis));
		}
	}

	public IObservable<float> OnGetAxisAsObservable(string axis)
	{
		this.axis = axis;
		return onGetAxis ?? (onGetAxis = new Subject<float>());
	}

	protected override void RaiseOnCompletedOnDestroy()
	{
		onGetAxis?.OnCompleted();
	}
}