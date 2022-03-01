using System;

// Token: 0x02004362 RID: 17250
public class Mechanism2043 : BeMechanism
{
	// Token: 0x06017E3D RID: 97853 RVA: 0x007639B5 File Offset: 0x00761DB5
	public Mechanism2043(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E3E RID: 97854 RVA: 0x007639CC File Offset: 0x00761DCC
	public override void OnInit()
	{
		base.OnInit();
		this.buffIDCondition = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.sightAddRate = VFactor.NewVFactor(valueFromUnionCell, GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017E3F RID: 97855 RVA: 0x00763A3C File Offset: 0x00761E3C
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.OnAddBuff));
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, new BeEventHandle.Del(this.OnRemoveBuff));
	}

	// Token: 0x06017E40 RID: 97856 RVA: 0x00763A90 File Offset: 0x00761E90
	private void OnAddBuff(object[] args)
	{
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff == null || beBuff.buffID != this.buffIDCondition)
		{
			return;
		}
		if (base.owner == null || base.owner.buffController == null || base.owner.aiManager == null)
		{
			return;
		}
		if (base.owner.buffController.GetBuffCountByID(beBuff.buffID) > 1)
		{
			return;
		}
		this.originSight = base.owner.aiManager.sight;
		int sight = this.originSight * (VFactor.one + this.sightAddRate);
		base.owner.aiManager.sight = sight;
	}

	// Token: 0x06017E41 RID: 97857 RVA: 0x00763B4C File Offset: 0x00761F4C
	private void OnRemoveBuff(object[] args)
	{
		int num = (int)args[0];
		if (this.buffIDCondition != num)
		{
			return;
		}
		if (base.owner == null || base.owner.buffController == null || base.owner.aiManager == null)
		{
			return;
		}
		if (base.owner.buffController.GetBuffCountByID(num) > 1)
		{
			return;
		}
		base.owner.aiManager.sight = this.originSight;
	}

	// Token: 0x04011313 RID: 70419
	private int buffIDCondition;

	// Token: 0x04011314 RID: 70420
	private VFactor sightAddRate = VFactor.zero;

	// Token: 0x04011315 RID: 70421
	private int originSight;
}
