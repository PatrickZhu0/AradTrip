using System;

// Token: 0x0200430A RID: 17162
internal class Mechanism132 : BeMechanism
{
	// Token: 0x06017BE8 RID: 97256 RVA: 0x007530FC File Offset: 0x007514FC
	public Mechanism132(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BE9 RID: 97257 RVA: 0x00753108 File Offset: 0x00751508
	public override void OnInit()
	{
		this.hpReduce = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.hpReduce <= 0)
		{
			this.hpReduce = 1000;
		}
		this.effectIdArray = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.effectIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
	}

	// Token: 0x06017BEA RID: 97258 RVA: 0x007531BA File Offset: 0x007515BA
	public override void OnStart()
	{
		this.hpTotal = 0;
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			int num = (int)args[0];
			this.hpTotal += num;
			while (-this.hpTotal > this.hpReduce)
			{
				this.hpTotal += this.hpReduce;
				for (int i = 0; i < this.effectIdArray.Length; i++)
				{
					base.owner.DealEffectFrame(base.owner, this.effectIdArray[i], 0, false, true, false, false);
				}
			}
		});
	}

	// Token: 0x04011130 RID: 69936
	private int hpReduce;

	// Token: 0x04011131 RID: 69937
	private int[] effectIdArray;

	// Token: 0x04011132 RID: 69938
	private int hpTotal;
}
