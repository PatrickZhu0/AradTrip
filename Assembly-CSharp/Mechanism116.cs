using System;
using System.Collections.Generic;

// Token: 0x020042D3 RID: 17107
internal class Mechanism116 : BeMechanism
{
	// Token: 0x06017AB8 RID: 96952 RVA: 0x0074B76D File Offset: 0x00749B6D
	public Mechanism116(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017AB9 RID: 96953 RVA: 0x0074B784 File Offset: 0x00749B84
	public override void OnInit()
	{
		this.radiusRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.isChangeEffectSize = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) == 1);
		this.intervalRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count > 0)
		{
			this.impactMechanismIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true));
		}
	}

	// Token: 0x0401102C RID: 69676
	public int radiusRate;

	// Token: 0x0401102D RID: 69677
	public bool isChangeEffectSize;

	// Token: 0x0401102E RID: 69678
	public int intervalRate;

	// Token: 0x0401102F RID: 69679
	public List<int> impactMechanismIdList = new List<int>();
}
