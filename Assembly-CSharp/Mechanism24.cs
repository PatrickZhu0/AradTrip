using System;
using System.Collections.Generic;

// Token: 0x020043D1 RID: 17361
public class Mechanism24 : BeMechanism
{
	// Token: 0x0601816F RID: 98671 RVA: 0x0077BD68 File Offset: 0x0077A168
	public Mechanism24(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018170 RID: 98672 RVA: 0x0077BD84 File Offset: 0x0077A184
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.buffInfoIDs.Add(valueFromUnionCell);
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_BuffInfoTarget = (Mechanism24.BuffInfoTargetType)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.m_AddBuffTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
	}

	// Token: 0x06018171 RID: 98673 RVA: 0x0077BE64 File Offset: 0x0077A264
	public override void OnStart()
	{
		if (this.m_AddBuffTimeAcc == -1)
		{
			this.AddBuffInfo();
		}
	}

	// Token: 0x06018172 RID: 98674 RVA: 0x0077BE78 File Offset: 0x0077A278
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_AddBuffTimeAcc != -1)
		{
			if (this.m_CurrentTimeAcc >= this.m_AddBuffTimeAcc)
			{
				this.m_CurrentTimeAcc = 0;
				this.AddBuffInfo();
			}
			else
			{
				this.m_CurrentTimeAcc += deltaTime;
			}
		}
	}

	// Token: 0x06018173 RID: 98675 RVA: 0x0077BEB8 File Offset: 0x0077A2B8
	protected void AddBuffInfo()
	{
		BeActor beActor = null;
		if (this.m_BuffInfoTarget == Mechanism24.BuffInfoTargetType.Owner)
		{
			beActor = (base.owner.GetOwner() as BeActor);
		}
		else if (this.m_BuffInfoTarget == Mechanism24.BuffInfoTargetType.Self)
		{
			beActor = base.owner;
		}
		if (base.owner != null && !beActor.IsDead() && beActor != null)
		{
			int buffInfoID = this.buffInfoIDs[base.FrameRandom.InRange(0, this.buffInfoIDs.Count)];
			BuffInfoData info = new BuffInfoData(buffInfoID, this.level, 0);
			BeBuff beBuff = beActor.buffController.TryAddBuff(info, null, false, default(VRate), null);
			if (beBuff != null)
			{
				if (this.attachBuff != null)
				{
					beBuff.releaser = this.attachBuff.releaser;
				}
				if (this.data.ID == 1056 || this.data.ID == 1059)
				{
					beBuff.skillId = 1809;
				}
			}
		}
	}

	// Token: 0x040115C6 RID: 71110
	protected List<int> buffInfoIDs = new List<int>();

	// Token: 0x040115C7 RID: 71111
	protected Mechanism24.BuffInfoTargetType m_BuffInfoTarget;

	// Token: 0x040115C8 RID: 71112
	protected int m_AddBuffTimeAcc = -1;

	// Token: 0x040115C9 RID: 71113
	protected int m_CurrentTimeAcc;

	// Token: 0x020043D2 RID: 17362
	public enum BuffInfoTargetType
	{
		// Token: 0x040115CB RID: 71115
		Owner,
		// Token: 0x040115CC RID: 71116
		Self
	}
}
