using System;

// Token: 0x020042A8 RID: 17064
internal class Mechanism111 : BeMechanism
{
	// Token: 0x060179B9 RID: 96697 RVA: 0x00745D25 File Offset: 0x00744125
	public Mechanism111(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179BA RID: 96698 RVA: 0x00745D30 File Offset: 0x00744130
	public override void OnInit()
	{
		this.skillIdArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.skillIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.addStayDuration = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x060179BB RID: 96699 RVA: 0x00745DCB File Offset: 0x007441CB
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBoomerangStayDuration, delegate(object[] args)
		{
			int value = (int)args[0];
			if (Array.IndexOf<int>(this.skillIdArray, value) != -1)
			{
				int[] array = (int[])args[1];
				array[0] += this.addStayDuration;
			}
		});
	}

	// Token: 0x04010F7B RID: 69499
	private int[] skillIdArray;

	// Token: 0x04010F7C RID: 69500
	private int addStayDuration;
}
