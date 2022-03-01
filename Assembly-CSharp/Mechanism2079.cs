using System;
using System.Collections.Generic;

// Token: 0x02004388 RID: 17288
public class Mechanism2079 : BeMechanism
{
	// Token: 0x06017F8A RID: 98186 RVA: 0x0076D312 File Offset: 0x0076B712
	public Mechanism2079(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F8B RID: 98187 RVA: 0x0076D31C File Offset: 0x0076B71C
	public override void OnInit()
	{
		this.mActiveTime = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) : TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true));
		this.mHurtIDSet = new HashSet<int>();
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.mHurtIDSet.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017F8C RID: 98188 RVA: 0x0076D3E4 File Offset: 0x0076B7E4
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, delegate(object[] args)
		{
			int item = (int)args[1];
			if (!this.mHurtIDSet.Contains(item))
			{
				return;
			}
			this.mActiveSkill = true;
			this.mActiveTimeAcc = 0;
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
		{
			this.mActiveSkill = false;
		});
	}

	// Token: 0x06017F8D RID: 98189 RVA: 0x0076D444 File Offset: 0x0076B844
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (this.mActiveSkill)
		{
			this.mActiveTimeAcc += iDeltime;
			if (this.mActiveTimeAcc >= this.mActiveTime)
			{
				this.mActiveSkill = false;
				this.mActiveTimeAcc = 0;
			}
		}
	}

	// Token: 0x06017F8E RID: 98190 RVA: 0x0076D490 File Offset: 0x0076B890
	public bool IsActive()
	{
		return this.mActiveSkill;
	}

	// Token: 0x06017F8F RID: 98191 RVA: 0x0076D498 File Offset: 0x0076B898
	public void SetActive(bool active)
	{
		this.mActiveSkill = active;
	}

	// Token: 0x0401142A RID: 70698
	private int mActiveTime;

	// Token: 0x0401142B RID: 70699
	private int mActiveTimeAcc;

	// Token: 0x0401142C RID: 70700
	private HashSet<int> mHurtIDSet;

	// Token: 0x0401142D RID: 70701
	private bool mActiveSkill;
}
