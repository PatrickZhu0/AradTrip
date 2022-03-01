using System;
using System.Collections.Generic;

// Token: 0x0200424D RID: 16973
public class Mechanism1005 : BeMechanism
{
	// Token: 0x060177C1 RID: 96193 RVA: 0x00738DDC File Offset: 0x007371DC
	public Mechanism1005(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177C2 RID: 96194 RVA: 0x00738DF4 File Offset: 0x007371F4
	public override void OnInit()
	{
		base.OnInit();
		if (this.data.ValueA.Count > 0)
		{
			this.addEntityCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		}
		if (this.data.ValueB.Count > 0)
		{
			this.addRadius = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.addTimeAccRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.impactMechanismIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true));
		}
	}

	// Token: 0x04010E02 RID: 69122
	public int addEntityCount;

	// Token: 0x04010E03 RID: 69123
	public int addRadius;

	// Token: 0x04010E04 RID: 69124
	public int addTimeAccRate;

	// Token: 0x04010E05 RID: 69125
	public List<int> impactMechanismIdList = new List<int>();
}
