using System;
using System.Collections.Generic;

// Token: 0x020043FD RID: 17405
public class Mechanism61 : BeMechanism
{
	// Token: 0x060182A8 RID: 98984 RVA: 0x00784C92 File Offset: 0x00783092
	public Mechanism61(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182A9 RID: 98985 RVA: 0x00784CA8 File Offset: 0x007830A8
	public override void OnInit()
	{
		this.m_AttackIntervalAdd = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
				this.m_HurtIdList.Add(valueFromUnionCell);
			}
		}
		this.m_AttackCountAdd = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060182AA RID: 98986 RVA: 0x00784D6B File Offset: 0x0078316B
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onRepeatAttackInterval, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int item = (int)args[1];
			if (this.m_HurtIdList.Count > 0 && this.m_HurtIdList.Contains(item))
			{
				array[0] += this.m_AttackIntervalAdd;
				array[1] += this.m_AttackCountAdd;
			}
		});
	}

	// Token: 0x040116FF RID: 71423
	protected int m_AttackIntervalAdd;

	// Token: 0x04011700 RID: 71424
	protected List<int> m_HurtIdList = new List<int>();

	// Token: 0x04011701 RID: 71425
	protected int m_AttackCountAdd;
}
