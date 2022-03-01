using System;
using System.Collections.Generic;

// Token: 0x0200441D RID: 17437
public class Mechanism91 : BeMechanism
{
	// Token: 0x0601837A RID: 99194 RVA: 0x0078AC11 File Offset: 0x00789011
	public Mechanism91(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601837B RID: 99195 RVA: 0x0078AC3C File Offset: 0x0078903C
	public override void OnInit()
	{
		this.hpPercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.buffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.removeBuffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		if (this.data.ValueD.Count > 0)
		{
			this.mSecurityFlag = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
		}
		if (this.data.ValueD.Count > 1)
		{
			this.mRegistRebornFlag = (TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true) != 0);
		}
		if (this.data.ValueD.Count > 2)
		{
			this.mAddBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueD[2], this.level, true);
		}
		this.mAddBuffTimeAcc = this.mAddBuffTime;
	}

	// Token: 0x0601837C RID: 99196 RVA: 0x0078ADEC File Offset: 0x007891EC
	public override void OnStart()
	{
		base.OnStart();
		this.hpPercentFactor = new VFactor((long)this.hpPercent, (long)GlobalLogic.VALUE_1000);
		this.CheckHp();
		this.hpChangeHandle = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			this.CheckHp();
		});
		if (this.mRegistRebornFlag)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this.OnRebornEvent));
		}
	}

	// Token: 0x0601837D RID: 99197 RVA: 0x0078AE66 File Offset: 0x00789266
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateAddBuffTimeAcc(deltaTime);
	}

	// Token: 0x0601837E RID: 99198 RVA: 0x0078AE6F File Offset: 0x0078926F
	protected void UpdateAddBuffTimeAcc(int deltaTime)
	{
		if (this.mAddBuffTime <= 0 || this.mAddBuffTimeAcc >= this.mAddBuffTime)
		{
			return;
		}
		this.mAddBuffTimeAcc += deltaTime;
	}

	// Token: 0x0601837F RID: 99199 RVA: 0x0078AE9D File Offset: 0x0078929D
	protected void OnRebornEvent(object[] args)
	{
		this.CheckHp();
	}

	// Token: 0x06018380 RID: 99200 RVA: 0x0078AEA8 File Offset: 0x007892A8
	protected void CheckHp()
	{
		if (this.mSecurityFlag && this.mAddBuffFlag)
		{
			return;
		}
		int hp = base.owner.GetEntityData().GetHP();
		int maxHP = base.owner.GetEntityData().GetMaxHP();
		VFactor a = new VFactor((long)hp, (long)maxHP);
		if (a > this.hpPercentFactor)
		{
			this.AddBuffInfo();
		}
		else
		{
			this.RemoveBuff();
		}
	}

	// Token: 0x06018381 RID: 99201 RVA: 0x0078AF1B File Offset: 0x0078931B
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x06018382 RID: 99202 RVA: 0x0078AF29 File Offset: 0x00789329
	protected bool ReduceAddBuffTimeAcc()
	{
		if (this.mAddBuffTime <= 0)
		{
			return true;
		}
		if (this.mAddBuffTimeAcc >= this.mAddBuffTime)
		{
			this.mAddBuffTimeAcc -= this.mAddBuffTime;
			return true;
		}
		return false;
	}

	// Token: 0x06018383 RID: 99203 RVA: 0x0078AF60 File Offset: 0x00789360
	protected void AddBuffInfo()
	{
		if (!this.ReduceAddBuffTimeAcc())
		{
			return;
		}
		for (int i = 0; i < this.buffInfoIdList.Count; i++)
		{
			if (base.owner.buffController.HasBuffByID(this.removeBuffIdList[i]) == null)
			{
				this.mAddBuffFlag = true;
				base.owner.buffController.TryAddBuff(this.buffInfoIdList[i], null, false, null, 0);
				this.mAddBuffFlag = false;
			}
		}
	}

	// Token: 0x06018384 RID: 99204 RVA: 0x0078AFE8 File Offset: 0x007893E8
	protected void RemoveBuff()
	{
		for (int i = 0; i < this.removeBuffIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.removeBuffIdList[i], 0, 0);
		}
	}

	// Token: 0x06018385 RID: 99205 RVA: 0x0078B02F File Offset: 0x0078942F
	protected void RemoveHandle()
	{
		if (this.hpChangeHandle != null)
		{
			this.hpChangeHandle.Remove();
			this.hpChangeHandle = null;
		}
	}

	// Token: 0x040117B4 RID: 71604
	protected int hpPercent;

	// Token: 0x040117B5 RID: 71605
	protected List<int> buffInfoIdList = new List<int>();

	// Token: 0x040117B6 RID: 71606
	protected List<int> removeBuffIdList = new List<int>();

	// Token: 0x040117B7 RID: 71607
	protected VFactor hpPercentFactor = VFactor.zero;

	// Token: 0x040117B8 RID: 71608
	protected BeEventHandle hpChangeHandle;

	// Token: 0x040117B9 RID: 71609
	protected bool mAddBuffFlag;

	// Token: 0x040117BA RID: 71610
	protected bool mSecurityFlag;

	// Token: 0x040117BB RID: 71611
	protected bool mRegistRebornFlag;

	// Token: 0x040117BC RID: 71612
	protected int mAddBuffTimeAcc;

	// Token: 0x040117BD RID: 71613
	protected int mAddBuffTime;
}
