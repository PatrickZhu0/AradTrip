using System;

// Token: 0x02004305 RID: 17157
internal class Mechanism129 : BeMechanism
{
	// Token: 0x06017BC4 RID: 97220 RVA: 0x00751C61 File Offset: 0x00750061
	public Mechanism129(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BC5 RID: 97221 RVA: 0x00751C6C File Offset: 0x0075006C
	public override void OnInit()
	{
		this.dis = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		this.disRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040110FC RID: 69884
	public VInt dis;

	// Token: 0x040110FD RID: 69885
	public int disRate;
}
