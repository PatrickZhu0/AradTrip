using System;

// Token: 0x02004407 RID: 17415
public class Mechanism7 : BeMechanism
{
	// Token: 0x060182EC RID: 99052 RVA: 0x00786A2A File Offset: 0x00784E2A
	public Mechanism7(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182ED RID: 99053 RVA: 0x00786A44 File Offset: 0x00784E44
	public override void OnInit()
	{
		this.hpPercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x060182EE RID: 99054 RVA: 0x00786AA1 File Offset: 0x00784EA1
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
			{
				BeEntity beEntity = args[0] as BeEntity;
				if (beEntity != null && beEntity.GetEntityData() != null && beEntity.GetEntityData().GetHPRate() <= VFactor.NewVFactor((long)this.hpPercent, (long)GlobalLogic.VALUE_1000) && this.buffInfoID > 0)
				{
					BuffInfoData info = new BuffInfoData(this.buffInfoID, this.level, 0);
					base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
				}
			});
		}
	}

	// Token: 0x04011734 RID: 71476
	private int hpPercent = 50;

	// Token: 0x04011735 RID: 71477
	private int buffInfoID = 1;
}
