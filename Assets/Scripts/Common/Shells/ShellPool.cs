using BattleVehicle;
using Zenject;

public class ShellPool : AbstractShellPool
{
	[Inject]
	private AbstractShellFactory shellFactory;

	protected override AbstractShell CreateInstance()
	{
		var shell = shellFactory.Create(prefabName);
		shell.DoOnDestroy(() => Return(shell));
		return shell;
	}

	protected override void OnBeforeRent(AbstractShell instance)
	{
		
	}
}
