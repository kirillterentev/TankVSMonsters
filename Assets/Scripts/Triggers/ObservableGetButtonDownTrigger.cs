using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableGetButtonDownTrigger : ObservableTriggerBase
{
	private Subject<Unit> onGetButtonDown;
	private string button;

	void Update()
	{
		if (Input.GetButtonDown(button))
		{
			onGetButtonDown?.OnNext(Unit.Default);
		}
	}

	public IObservable<Unit> OnGetButtonDownAsObservable(string button)
	{
		this.button = button;
		return onGetButtonDown ?? (onGetButtonDown = new Subject<Unit>());
	}

	protected override void RaiseOnCompletedOnDestroy()
	{
		onGetButtonDown?.OnCompleted();
	}
}