using System;

// Token: 0x020043EF RID: 17391
public class Mechanism5 : BeMechanism
{
	// Token: 0x06018236 RID: 98870 RVA: 0x007818A7 File Offset: 0x0077FCA7
	public Mechanism5(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018237 RID: 98871 RVA: 0x007818C0 File Offset: 0x0077FCC0
	public override void OnInit()
	{
		this.abnormalType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06018238 RID: 98872 RVA: 0x00781920 File Offset: 0x0077FD20
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff != null && beBuff.buffType == (BuffType)this.abnormalType && base.owner.buffController.HasBuffByID(this.buffID) == null)
				{
					base.owner.buffController.TryAddBuff(this.buffID, -1, this.level);
				}
			});
			this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[1] as BeBuff;
				if (beBuff != null && beBuff.buffType == (BuffType)this.abnormalType)
				{
					base.owner.delayCaller.DelayCall(100, delegate
					{
						if (base.owner.buffController.GetBuffCountByType((BuffType)this.abnormalType) <= 0)
						{
							base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
						}
					}, 0, 0, false);
				}
			});
		}
	}

	// Token: 0x0401168E RID: 71310
	private int abnormalType = 5;

	// Token: 0x0401168F RID: 71311
	private int buffID = 1;
}
