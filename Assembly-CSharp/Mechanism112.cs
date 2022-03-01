using System;

// Token: 0x020042B1 RID: 17073
internal class Mechanism112 : BeMechanism
{
	// Token: 0x060179E7 RID: 96743 RVA: 0x00746C8D File Offset: 0x0074508D
	public Mechanism112(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179E8 RID: 96744 RVA: 0x00746C98 File Offset: 0x00745098
	public override void OnInit()
	{
		this.tagArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.tagArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.modifySpeedRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x060179E9 RID: 96745 RVA: 0x00746D33 File Offset: 0x00745133
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeModifySpeed, delegate(object[] args)
		{
			int value = (int)args[0];
			if (Array.IndexOf<int>(this.tagArray, value) != -1)
			{
				int[] array = (int[])args[1];
				array[0] += this.modifySpeedRate;
			}
		});
	}

	// Token: 0x04010F9C RID: 69532
	private int[] tagArray;

	// Token: 0x04010F9D RID: 69533
	private int modifySpeedRate;
}
