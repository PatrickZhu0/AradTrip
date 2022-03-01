using System;

// Token: 0x02004286 RID: 17030
public class Mechanism1061 : BeMechanism
{
	// Token: 0x06017907 RID: 96519 RVA: 0x00740D85 File Offset: 0x0073F185
	public Mechanism1061(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017908 RID: 96520 RVA: 0x00740D8F File Offset: 0x0073F18F
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06017909 RID: 96521 RVA: 0x00740D98 File Offset: 0x0073F198
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.SetHeadInfoVisible(false);
			if (base.owner.attachModel != null)
			{
				base.owner.attachModel.CustomActive(false);
			}
		}
	}

	// Token: 0x0601790A RID: 96522 RVA: 0x00740DF4 File Offset: 0x0073F1F4
	public override void OnFinish()
	{
		base.OnFinish();
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.SetHeadInfoVisible(true);
			if (base.owner.attachModel != null)
			{
				base.owner.attachModel.CustomActive(true);
			}
		}
	}
}
