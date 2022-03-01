using System;
using System.Collections.Generic;

// Token: 0x020043E8 RID: 17384
public class Mechanism41 : BeMechanism
{
	// Token: 0x06018205 RID: 98821 RVA: 0x00780712 File Offset: 0x0077EB12
	public Mechanism41(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018206 RID: 98822 RVA: 0x00780728 File Offset: 0x0077EB28
	public override void OnInit()
	{
		this.m_AttachBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_AttachMaxNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			for (int i = 0; i < this.data.ValueC.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
				this.m_BuffInfoList.Add(valueFromUnionCell);
			}
		}
		this.m_EntityId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		if (this.data.ValueE.Count > 0)
		{
			this.m_AddEffectId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
	}

	// Token: 0x06018207 RID: 98823 RVA: 0x00780851 File Offset: 0x0077EC51
	public override void OnStart()
	{
		this.m_CollideHandle = base.owner.RegisterEvent(BeEventType.onCollideOther, delegate(object[] args)
		{
			BeEntity target = args[0] as BeEntity;
			this.OnCollide(target);
		});
	}

	// Token: 0x06018208 RID: 98824 RVA: 0x00780874 File Offset: 0x0077EC74
	protected void OnCollide(BeEntity target)
	{
		if (target.GetCamp() != base.owner.GetCamp() && target.m_iResID == this.m_EntityId)
		{
			int buffCountByID = base.owner.buffController.GetBuffCountByID(this.m_AttachBuffId);
			if (buffCountByID < 3)
			{
				if (target.GetOwner().GetOwner() != null)
				{
					target.GetOwner().GetOwner().DoAttackTo(base.owner, this.m_AddEffectId, true, false);
				}
				target.DoDead(false);
				if (this.m_BuffInfoList.Count > 0)
				{
					for (int i = 0; i < this.m_BuffInfoList.Count; i++)
					{
						base.owner.buffController.TryAddBuff(this.m_BuffInfoList[i], null, false, null, 0);
					}
				}
			}
		}
	}

	// Token: 0x06018209 RID: 98825 RVA: 0x0078094A File Offset: 0x0077ED4A
	public override void OnFinish()
	{
		if (this.m_CollideHandle != null)
		{
			this.m_CollideHandle.Remove();
		}
	}

	// Token: 0x0401165C RID: 71260
	protected int m_AttachBuffId;

	// Token: 0x0401165D RID: 71261
	protected int m_AttachMaxNum;

	// Token: 0x0401165E RID: 71262
	protected List<int> m_BuffInfoList = new List<int>();

	// Token: 0x0401165F RID: 71263
	protected int m_EntityId;

	// Token: 0x04011660 RID: 71264
	protected int m_AddEffectId;

	// Token: 0x04011661 RID: 71265
	protected BeEventHandle m_CollideHandle;
}
