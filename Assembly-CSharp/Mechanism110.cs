using System;

// Token: 0x020042A4 RID: 17060
internal class Mechanism110 : BeMechanism
{
	// Token: 0x060179A8 RID: 96680 RVA: 0x00745674 File Offset: 0x00743A74
	public Mechanism110(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179A9 RID: 96681 RVA: 0x00745680 File Offset: 0x00743A80
	public override void OnInit()
	{
		this.effectIdArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.effectIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.addDamageRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.addDamageFixedRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060179AA RID: 96682 RVA: 0x00745743 File Offset: 0x00743B43
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeDamage, delegate(object[] args)
		{
			int value = (int)args[0];
			if (Array.IndexOf<int>(this.effectIdArray, value) != -1)
			{
				int[] array = (int[])args[1];
				array[0] += this.addDamageRate;
				array[1] += this.addDamageFixedRate;
			}
		});
	}

	// Token: 0x04010F69 RID: 69481
	private int[] effectIdArray;

	// Token: 0x04010F6A RID: 69482
	private int addDamageRate;

	// Token: 0x04010F6B RID: 69483
	private int addDamageFixedRate;
}
