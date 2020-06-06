using BattleVehicle;
using Zenject;

public class ShellPool : AbstractShellPool
{
	[Inject]
	private AbstractShellFactory shellFactory;

	protected override AbstractShell CreateInstance()
	{
		return shellFactory.Create(prefabName);
	}
}
