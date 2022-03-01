using System;

// Token: 0x020043FB RID: 17403
public class Mechanism6 : BeMechanism
{
	// Token: 0x0601828C RID: 98956 RVA: 0x00783EE1 File Offset: 0x007822E1
	public Mechanism6(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601828D RID: 98957 RVA: 0x00783F00 File Offset: 0x00782300
	public override void OnInit()
	{
		this.hpPercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.mSwitchEquipFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
		}
	}

	// Token: 0x0601828E RID: 98958 RVA: 0x00783FAC File Offset: 0x007823AC
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.InitBuff();
			this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
			{
				VFactor b = new VFactor((long)this.hpPercent, (long)GlobalLogic.VALUE_1000);
				if (base.owner.GetEntityData().GetHPRate() < b)
				{
					if (base.owner.buffController.HasBuffByID(this.buffID) == null)
					{
						base.owner.buffController.TryAddBuff(this.buffID, -1, this.level);
					}
				}
				else if (base.owner.buffController.HasBuffByID(this.buffID) != null)
				{
					base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
				}
			});
			this.handleB = base.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
			{
				if (base.owner.buffController.HasBuffByID(this.buffID) != null)
				{
					base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
				}
			});
		}
	}

	// Token: 0x0601828F RID: 98959 RVA: 0x00784008 File Offset: 0x00782408
	private void InitBuff()
	{
		if (this.mSwitchEquipFlag)
		{
			VFactor b = new VFactor((long)this.hpPercent, (long)GlobalLogic.VALUE_1000);
			if (base.owner.GetEntityData().GetHPRate() < b && base.owner.buffController.HasBuffByID(this.buffID) == null)
			{
				base.owner.buffController.TryAddBuff(this.buffID, -1, this.level);
			}
		}
	}

	// Token: 0x06018290 RID: 98960 RVA: 0x00784092 File Offset: 0x00782492
	public override void OnFinish()
	{
		if (this.mSwitchEquipFlag && base.owner.buffController.HasBuffByID(this.buffID) != null)
		{
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
	}

	// Token: 0x040116E1 RID: 71393
	private CrypticInt32 hpPercent = 50;

	// Token: 0x040116E2 RID: 71394
	private int buffID = 1;

	// Token: 0x040116E3 RID: 71395
	protected bool mSwitchEquipFlag;
}
