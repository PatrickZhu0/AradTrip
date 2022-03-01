using System;
using System.Collections.Generic;

// Token: 0x0200440A RID: 17418
public class Mechanism72 : BeMechanism
{
	// Token: 0x06018304 RID: 99076 RVA: 0x007875BC File Offset: 0x007859BC
	public Mechanism72(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018305 RID: 99077 RVA: 0x007875DC File Offset: 0x007859DC
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
				this.m_EntityResIdList.Add(valueFromUnionCell);
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int j = 0; j < this.data.ValueB.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
				this.m_BuffInfoIdList.Add(valueFromUnionCell2);
			}
		}
	}

	// Token: 0x06018306 RID: 99078 RVA: 0x007876B5 File Offset: 0x00785AB5
	public override void OnStart()
	{
		this.RemoveHandle();
		this.AttackHandle();
	}

	// Token: 0x06018307 RID: 99079 RVA: 0x007876C3 File Offset: 0x00785AC3
	protected void AttackHandle()
	{
		this.m_OnHitOtherHandle = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
		{
			int item = (int)args[1];
			if (this.m_EntityResIdList.Contains(item))
			{
				for (int i = 0; i < this.m_BuffInfoIdList.Count; i++)
				{
					base.owner.buffController.TryAddBuff(this.m_BuffInfoIdList[i], null, false, null, 0);
				}
			}
		});
	}

	// Token: 0x06018308 RID: 99080 RVA: 0x007876E4 File Offset: 0x00785AE4
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018309 RID: 99081 RVA: 0x007876EC File Offset: 0x00785AEC
	protected void RemoveHandle()
	{
		if (this.m_OnHitOtherHandle != null)
		{
			this.m_OnHitOtherHandle.Remove();
			this.m_OnHitOtherHandle = null;
		}
	}

	// Token: 0x04011750 RID: 71504
	protected List<int> m_EntityResIdList = new List<int>();

	// Token: 0x04011751 RID: 71505
	protected List<int> m_BuffInfoIdList = new List<int>();

	// Token: 0x04011752 RID: 71506
	protected BeEventHandle m_OnHitOtherHandle;
}
