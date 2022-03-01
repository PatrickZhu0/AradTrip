using System;

// Token: 0x02004300 RID: 17152
internal class Mechanism124 : BeMechanism
{
	// Token: 0x06017BB1 RID: 97201 RVA: 0x0075141E File Offset: 0x0074F81E
	public Mechanism124(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BB2 RID: 97202 RVA: 0x00751428 File Offset: 0x0074F828
	public override void OnInit()
	{
		this.bulletNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040110E3 RID: 69859
	public int bulletNum;

	// Token: 0x040110E4 RID: 69860
	public int addTime;
}
