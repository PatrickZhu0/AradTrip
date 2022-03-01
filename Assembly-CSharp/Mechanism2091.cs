using System;

// Token: 0x02004397 RID: 17303
public class Mechanism2091 : BeMechanism
{
	// Token: 0x06017FD7 RID: 98263 RVA: 0x0076F29A File Offset: 0x0076D69A
	public Mechanism2091(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x1700200A RID: 8202
	// (get) Token: 0x06017FD8 RID: 98264 RVA: 0x0076F2B0 File Offset: 0x0076D6B0
	public VRate SkillAttackAddRate
	{
		get
		{
			return this.m_SkillAttackAddRate;
		}
	}

	// Token: 0x06017FD9 RID: 98265 RVA: 0x0076F2B8 File Offset: 0x0076D6B8
	public override void OnInit()
	{
		this.m_SkillAttackAddRate = new VRate(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true));
	}

	// Token: 0x04011471 RID: 70769
	private VRate m_SkillAttackAddRate = 0;
}
