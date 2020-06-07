using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObservableGetAxisTrigger : ObservableTriggerBase
{
	private List<Subject<float>> onGetAxis = new List<Subject<float>>();
	private List<string> axis = new List<string>();


	void Update()
	{
		for (int i = 0; i < axis.Count; i++)
		{
			onGetAxis[i].OnNext(Input.GetAxis(axis[i]));
		}
	}

	public IObservable<float> OnGetAxisAsObservable(string axis)
	{
		this.axis.Add(axis);
		var subject = new Subject<float>();
		onGetAxis.Add(subject);
		return subject;
	}

	protected override void RaiseOnCompletedOnDestroy()
	{
		for (int i = 0; i < axis.Count; i++)
		{
			onGetAxis[i].OnCompleted();
		}
	}
}