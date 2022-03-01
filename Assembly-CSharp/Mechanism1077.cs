using System;

// Token: 0x02004297 RID: 17047
public class Mechanism1077 : BeMechanism
{
	// Token: 0x0601795E RID: 96606 RVA: 0x007432F8 File Offset: 0x007416F8
	public Mechanism1077(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601795F RID: 96607 RVA: 0x00743304 File Offset: 0x00741704
	public override void OnInit()
	{
		base.OnInit();
		this.totalDamage = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.effectId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017960 RID: 96608 RVA: 0x00743367 File Offset: 0x00741767
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, new BeEventHandle.Del(this.OnHpChange));
	}

	// Token: 0x06017961 RID: 96609 RVA: 0x00743394 File Offset: 0x00741794
	protected void InitData()
	{
		this.curTotalDamage = 0;
	}

	// Token: 0x06017962 RID: 96610 RVA: 0x007433A0 File Offset: 0x007417A0
	protected void OnHpChange(object[] args)
	{
		int num = (int)args[0];
		if (num > 0)
		{
			return;
		}
		this.curTotalDamage += -num;
		if (this.curTotalDamage < this.totalDamage)
		{
			return;
		}
		this.curTotalDamage = 0;
		base.owner.DealEffectFrame(base.owner, this.effectId, 0, false, true, false, false);
	}

	// Token: 0x04010F25 RID: 69413
	protected int totalDamage;

	// Token: 0x04010F26 RID: 69414
	protected int effectId;

	// Token: 0x04010F27 RID: 69415
	protected int curTotalDamage;
}
