using System;
using System.Collections.Generic;

// Token: 0x02004352 RID: 17234
public class Mechanism2028 : BeMechanism
{
	// Token: 0x06017DB4 RID: 97716 RVA: 0x0075FAB1 File Offset: 0x0075DEB1
	public Mechanism2028(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DB5 RID: 97717 RVA: 0x0075FAD4 File Offset: 0x0075DED4
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.impactBuffInfoList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.buffInfoRadiusAddRateList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
	}

	// Token: 0x040112AD RID: 70317
	public List<int> impactBuffInfoList = new List<int>();

	// Token: 0x040112AE RID: 70318
	public List<int> buffInfoRadiusAddRateList = new List<int>();
}
