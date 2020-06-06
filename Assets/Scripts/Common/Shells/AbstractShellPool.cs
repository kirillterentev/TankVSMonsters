using BattleVehicle;
using UniRx.Toolkit;

public abstract class AbstractShellPool : ObjectPool<AbstractShell>
{
	protected string prefabName;

	public virtual void SetPoolableObject(string prefabName)
	{
		this.prefabName = prefabName;
	}
}
