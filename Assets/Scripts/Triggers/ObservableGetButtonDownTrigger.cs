using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableGetButtonDownTrigger : ObservableTriggerBase
{
	private List<Subject<Unit>> onGetButtonDown = new List<Subject<Unit>>();
	private List<string> button = new List<string>();

	void Update()
	{
		for (int i = 0; i < button.Count; i++)
		{
			if (Input.GetButtonDown(button[i]))
			{
				onGetButtonDown[i].OnNext(Unit.Default);
			}
		}
	}

	public IObservable<Unit> OnGetButtonDownAsObservable(string button)
	{
		this.button.Add(button);
		var subject = new Subject<Unit>();
		onGetButtonDown.Add(subject);
		return subject;
	}

	protected override void RaiseOnCompletedOnDestroy()
	{
		for (int i = 0; i < button.Count; i++)
		{
			if (Input.GetButtonDown(button[i]))
			{
				onGetButtonDown[i].OnCompleted();
			}
		}
	}
}