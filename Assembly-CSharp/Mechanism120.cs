using System;
using System.Collections.Generic;

// Token: 0x020042FC RID: 17148
internal class Mechanism120 : BeMechanism
{
	// Token: 0x06017BA4 RID: 97188 RVA: 0x00751092 File Offset: 0x0074F492
	public Mechanism120(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BA5 RID: 97189 RVA: 0x007510A8 File Offset: 0x0074F4A8
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this.skillPhaseIdList.Add(valueFromUnionCell);
		}
		this.align = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.xRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.yRate = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.zDimRate = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x06017BA6 RID: 97190 RVA: 0x007511A5 File Offset: 0x0074F5A5
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeAttackDBox, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.skillPhaseIdList.Contains(item))
			{
				int[] array = (int[])args[1];
				array[0] = this.align;
				array[1] += this.xRate;
				array[2] += this.yRate;
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeAttackZDim, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.skillPhaseIdList.Contains(item))
			{
				int[] array = (int[])args[1];
				array[0] += this.zDimRate;
			}
		});
	}

	// Token: 0x06017BA7 RID: 97191 RVA: 0x007511E5 File Offset: 0x0074F5E5
	public override void OnFinish()
	{
		this.skillPhaseIdList.Clear();
	}

	// Token: 0x040110D8 RID: 69848
	public List<int> skillPhaseIdList = new List<int>();

	// Token: 0x040110D9 RID: 69849
	public int align;

	// Token: 0x040110DA RID: 69850
	public int xRate;

	// Token: 0x040110DB RID: 69851
	public int yRate;

	// Token: 0x040110DC RID: 69852
	public int zDimRate;
}
