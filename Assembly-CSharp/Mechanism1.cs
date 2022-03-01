using System;

// Token: 0x02004246 RID: 16966
public class Mechanism1 : BeMechanism
{
	// Token: 0x06017795 RID: 96149 RVA: 0x00737B9B File Offset: 0x00735F9B
	public Mechanism1(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017796 RID: 96150 RVA: 0x00737BA8 File Offset: 0x00735FA8
	public override void OnInit()
	{
		this.buffType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], 1, true);
		this.percent = TableManager.GetValueFromUnionCell(this.data.ValueB[0], 1, true);
	}

	// Token: 0x06017797 RID: 96151 RVA: 0x00737BF6 File Offset: 0x00735FF6
	public override void OnStart()
	{
		if (base.owner != null)
		{
			base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff != null && beBuff.buffType == (BuffType)this.buffType && this.percent > 0)
				{
					beBuff.duration *= VFactor.one - VFactor.NewVFactor(this.percent, GlobalLogic.VALUE_1000);
				}
			});
		}
	}

	// Token: 0x04010DDF RID: 69087
	private int buffType;

	// Token: 0x04010DE0 RID: 69088
	private CrypticInt32 percent;
}
