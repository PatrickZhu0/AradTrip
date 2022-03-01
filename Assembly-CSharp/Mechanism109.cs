using System;

// Token: 0x0200429F RID: 17055
internal class Mechanism109 : BeMechanism
{
	// Token: 0x06017987 RID: 96647 RVA: 0x00744921 File Offset: 0x00742D21
	public Mechanism109(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017988 RID: 96648 RVA: 0x0074492C File Offset: 0x00742D2C
	public override void OnInit()
	{
		this.effectId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.addNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.addNumLimit = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017989 RID: 96649 RVA: 0x007449DC File Offset: 0x00742DDC
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeSummonNum, delegate(object[] args)
		{
			int num = (int)args[0];
			int num2 = (int)args[1];
			if (this.effectId == num || this.buffId == num2)
			{
				int[] array = (int[])args[2];
				array[0] += this.addNum;
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeSummonNumLimit, delegate(object[] args)
		{
			int num = (int)args[0];
			int num2 = (int)args[1];
			if (this.effectId == num || this.buffId == num2)
			{
				int[] array = (int[])args[2];
				array[0] += this.addNumLimit;
			}
		});
	}

	// Token: 0x04010F4B RID: 69451
	private int effectId;

	// Token: 0x04010F4C RID: 69452
	private int buffId;

	// Token: 0x04010F4D RID: 69453
	private int addNum;

	// Token: 0x04010F4E RID: 69454
	private int addNumLimit;
}
