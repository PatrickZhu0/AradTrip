using System;

// Token: 0x02004400 RID: 17408
public class Mechanism64 : BeMechanism
{
	// Token: 0x060182BC RID: 99004 RVA: 0x00785666 File Offset: 0x00783A66
	public Mechanism64(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182BD RID: 99005 RVA: 0x00785678 File Offset: 0x00783A78
	public override void OnInit()
	{
		this.m_OriginalEntityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_ReplaceEntityId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.m_AddEffectId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
	}

	// Token: 0x060182BE RID: 99006 RVA: 0x00785713 File Offset: 0x00783B13
	public override void OnStart()
	{
		base.OnStart();
		this.RemoveHandle();
		this.m_ReplaceEntity = base.owner.RegisterEvent(BeEventType.onBeforeGenBullet, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.m_OriginalEntityId)
			{
				array[0] = this.m_ReplaceEntityId;
				if (this.m_AddEffectId > 0)
				{
					array[1] = this.m_AddEffectId;
				}
			}
		});
	}

	// Token: 0x060182BF RID: 99007 RVA: 0x00785740 File Offset: 0x00783B40
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x060182C0 RID: 99008 RVA: 0x00785748 File Offset: 0x00783B48
	protected void RemoveHandle()
	{
		if (this.m_ReplaceEntity != null)
		{
			this.m_ReplaceEntity.Remove();
			this.m_ReplaceEntity = null;
		}
	}

	// Token: 0x04011710 RID: 71440
	protected int m_OriginalEntityId;

	// Token: 0x04011711 RID: 71441
	protected int m_ReplaceEntityId;

	// Token: 0x04011712 RID: 71442
	protected int m_AddEffectId = -1;

	// Token: 0x04011713 RID: 71443
	protected BeEventHandle m_ReplaceEntity;
}
