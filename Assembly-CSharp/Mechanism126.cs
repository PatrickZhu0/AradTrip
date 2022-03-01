using System;

// Token: 0x02004302 RID: 17154
internal class Mechanism126 : BeMechanism
{
	// Token: 0x06017BBE RID: 97214 RVA: 0x00751B29 File Offset: 0x0074FF29
	public Mechanism126(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BBF RID: 97215 RVA: 0x00751B34 File Offset: 0x0074FF34
	public override void OnInit()
	{
		this.bulletType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.bulletNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040110F6 RID: 69878
	public int bulletType;

	// Token: 0x040110F7 RID: 69879
	public int bulletNum;
}
