using System;

// Token: 0x0200430E RID: 17166
internal class Mechanism136 : BeMechanism
{
	// Token: 0x06017C01 RID: 97281 RVA: 0x00753B8E File Offset: 0x00751F8E
	public Mechanism136(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C02 RID: 97282 RVA: 0x00753B98 File Offset: 0x00751F98
	public override void OnInit()
	{
		this.hpRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017C03 RID: 97283 RVA: 0x00753C00 File Offset: 0x00752000
	public override void OnStart()
	{
		if (!base.owner.HasSkill(this.skillId))
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (base.owner.GetEntityData().GetHPRate() <= this.hpRate)
			{
				base.owner.UseSkill(this.skillId, false);
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeModelFinish, delegate(object[] args)
		{
			this.handleA.Remove();
			this.handleA = null;
		});
	}

	// Token: 0x0401113C RID: 69948
	private VFactor hpRate;

	// Token: 0x0401113D RID: 69949
	private int skillId;
}
