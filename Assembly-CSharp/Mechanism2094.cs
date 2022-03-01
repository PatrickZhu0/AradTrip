using System;

// Token: 0x0200439A RID: 17306
public class Mechanism2094 : BeMechanism
{
	// Token: 0x06017FEE RID: 98286 RVA: 0x0076FC0E File Offset: 0x0076E00E
	public Mechanism2094(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x1700200B RID: 8203
	// (get) Token: 0x06017FEF RID: 98287 RVA: 0x0076FC23 File Offset: 0x0076E023
	public VFactor HpReplaceDelta
	{
		get
		{
			return this.m_HpReplaceDelta;
		}
	}

	// Token: 0x06017FF0 RID: 98288 RVA: 0x0076FC2B File Offset: 0x0076E02B
	public override void OnInit()
	{
		this.m_HpReplaceDelta = new VFactor((long)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true));
	}

	// Token: 0x04011480 RID: 70784
	private VFactor m_HpReplaceDelta = VFactor.zero;
}
