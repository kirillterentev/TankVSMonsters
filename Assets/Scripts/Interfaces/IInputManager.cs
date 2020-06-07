using System;

namespace BattleVehicle
{
	public interface IInputManager
	{
		void SubscribeToAxis(string axis, Action<float> action);
		void SubscribeToButtonDown(string button, Action action);
	}
}
