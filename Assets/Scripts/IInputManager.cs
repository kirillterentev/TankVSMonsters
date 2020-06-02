using System;

public interface IInputManager
{
	void SubscribeToAxis(string axis, Action<float> action);
	void SubscribeToButtonDown(string button, Action action);
}
