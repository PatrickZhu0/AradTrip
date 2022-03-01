using System;
using System.Collections.Generic;

// Token: 0x0200439B RID: 17307
public class Mechanism2095 : BeMechanism
{
	// Token: 0x06017FF1 RID: 98289 RVA: 0x0076FC5B File Offset: 0x0076E05B
	public Mechanism2095(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FF2 RID: 98290 RVA: 0x0076FC88 File Offset: 0x0076E088
	public override void OnInit()
	{
		this.m_BuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_Range = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.m_CheckBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_InRangeNum = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x06017FF3 RID: 98291 RVA: 0x0076FD61 File Offset: 0x0076E161
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateRangeBuff(deltaTime);
	}

	// Token: 0x06017FF4 RID: 98292 RVA: 0x0076FD6C File Offset: 0x0076E16C
	private void UpdateRangeBuff(int deltaTime)
	{
		this.m_CheckBuffTimeAcc += deltaTime;
		if (this.m_CheckBuffTimeAcc < this.m_CheckBuffTime)
		{
			return;
		}
		this.m_CheckBuffTimeAcc -= this.m_CheckBuffTime;
		base.owner.CurrentBeScene.FindTargets(this.findList, base.owner, this.m_Range, false, null);
		if (this.findList.Count > this.m_InRangeNum)
		{
			base.owner.buffController.TryAddBuff(this.m_BuffId, -1, this.level);
		}
		else
		{
			base.owner.buffController.RemoveBuff(this.m_BuffId, 0, 0);
		}
		this.findList.Clear();
	}

	// Token: 0x06017FF5 RID: 98293 RVA: 0x0076FE37 File Offset: 0x0076E237
	public override void OnFinish()
	{
		this.findList.Clear();
		base.owner.buffController.RemoveBuff(this.m_BuffId, 0, 0);
	}

	// Token: 0x04011481 RID: 70785
	private int m_CheckBuffTimeAcc;

	// Token: 0x04011482 RID: 70786
	private int m_CheckBuffTime = 200;

	// Token: 0x04011483 RID: 70787
	private int m_BuffId;

	// Token: 0x04011484 RID: 70788
	private int m_Range = 1000;

	// Token: 0x04011485 RID: 70789
	protected int m_InRangeNum;

	// Token: 0x04011486 RID: 70790
	private List<BeActor> findList = new List<BeActor>();
}
