using System;
using System.Collections.Generic;

// Token: 0x020042FE RID: 17150
internal class Mechanism122 : BeMechanism
{
	// Token: 0x06017BAC RID: 97196 RVA: 0x007512C5 File Offset: 0x0074F6C5
	public Mechanism122(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BAD RID: 97197 RVA: 0x007512DC File Offset: 0x0074F6DC
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			string item = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true).ToString();
			this.effectNameList.Add(item);
		}
		this.xRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.yRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.zRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017BAE RID: 97198 RVA: 0x007513DD File Offset: 0x0074F7DD
	public override void OnFinish()
	{
		this.effectNameList.Clear();
	}

	// Token: 0x040110DE RID: 69854
	public List<string> effectNameList = new List<string>();

	// Token: 0x040110DF RID: 69855
	public VFactor xRate;

	// Token: 0x040110E0 RID: 69856
	public VFactor yRate;

	// Token: 0x040110E1 RID: 69857
	public VFactor zRate;
}
