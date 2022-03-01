using System;

// Token: 0x0200434F RID: 17231
public class Mechanism2025 : BeMechanism
{
	// Token: 0x06017DAC RID: 97708 RVA: 0x0075F81F File Offset: 0x0075DC1F
	public Mechanism2025(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DAD RID: 97709 RVA: 0x0075F82C File Offset: 0x0075DC2C
	public override void OnInit()
	{
		base.OnInit();
		this.addRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addBuffTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040112A4 RID: 70308
	public int addRate;

	// Token: 0x040112A5 RID: 70309
	public int addBuffTime;
}
