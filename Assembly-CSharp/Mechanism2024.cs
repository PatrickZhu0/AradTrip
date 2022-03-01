using System;

// Token: 0x0200434E RID: 17230
public class Mechanism2024 : BeMechanism
{
	// Token: 0x06017DAA RID: 97706 RVA: 0x0075F7A0 File Offset: 0x0075DBA0
	public Mechanism2024(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DAB RID: 97707 RVA: 0x0075F7B8 File Offset: 0x0075DBB8
	public override void OnInit()
	{
		base.OnInit();
		this.addCountArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addCountArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
	}

	// Token: 0x040112A3 RID: 70307
	public int[] addCountArr = new int[2];
}
