using System;
using UnityEngine;

// Token: 0x02004410 RID: 17424
public class Mechanism78 : BeMechanism
{
	// Token: 0x06018324 RID: 99108 RVA: 0x00788370 File Offset: 0x00786770
	public Mechanism78(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018325 RID: 99109 RVA: 0x0078837A File Offset: 0x0078677A
	public override void OnInit()
	{
		this.duration = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
	}

	// Token: 0x06018326 RID: 99110 RVA: 0x007883AB File Offset: 0x007867AB
	public override void OnStart()
	{
		base.owner.m_pkGeActor.CreateSnapshot(Color.white, this.duration, string.Empty);
	}

	// Token: 0x04011770 RID: 71536
	private new float duration;
}
