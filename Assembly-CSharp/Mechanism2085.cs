using System;
using System.Collections.Generic;

// Token: 0x0200438E RID: 17294
public class Mechanism2085 : BeMechanism
{
	// Token: 0x06017FA8 RID: 98216 RVA: 0x0076DEBD File Offset: 0x0076C2BD
	public Mechanism2085(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017FA9 RID: 98217 RVA: 0x0076DED4 File Offset: 0x0076C2D4
	public sealed override void OnInit()
	{
		this.m_launchBullet.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_launchBullet.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x06017FAA RID: 98218 RVA: 0x0076DF3B File Offset: 0x0076C33B
	public sealed override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeGenBullet, delegate(object[] args)
		{
			if (!base.owner.IsCastingSkill())
			{
				return;
			}
			int[] array = (int[])args[0];
			if (this.IsLaunch(array[0]))
			{
				return;
			}
			array[2] = 0;
		});
	}

	// Token: 0x06017FAB RID: 98219 RVA: 0x0076DF5C File Offset: 0x0076C35C
	private bool IsLaunch(int resID)
	{
		return !this.IsTargetBullet(resID) || (!BattleMain.IsModePvP(base.battleType) && base.owner.GetMechanism(1061) != null);
	}

	// Token: 0x06017FAC RID: 98220 RVA: 0x0076DF96 File Offset: 0x0076C396
	private bool IsTargetBullet(int resID)
	{
		return this.m_launchBullet.Contains(resID);
	}

	// Token: 0x0401143A RID: 70714
	protected HashSet<int> m_launchBullet = new HashSet<int>();
}
