using System;

// Token: 0x020042B0 RID: 17072
public class Mechanism1118 : BeMechanism
{
	// Token: 0x060179E0 RID: 96736 RVA: 0x00746B2B File Offset: 0x00744F2B
	public Mechanism1118(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179E1 RID: 96737 RVA: 0x00746B38 File Offset: 0x00744F38
	public override void OnInit()
	{
		this.m_StartFrame = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true).ToString();
		this.m_EndFrame = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true).ToString();
	}

	// Token: 0x060179E2 RID: 96738 RVA: 0x00746BB1 File Offset: 0x00744FB1
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, new BeEventHandle.Del(this.OnSkillCurFrame));
	}

	// Token: 0x060179E3 RID: 96739 RVA: 0x00746BD2 File Offset: 0x00744FD2
	public override void OnFinish()
	{
		this.ResetWing();
	}

	// Token: 0x060179E4 RID: 96740 RVA: 0x00746BDC File Offset: 0x00744FDC
	private void OnSkillCurFrame(object[] args)
	{
		string a = args[0] as string;
		if (a == this.m_StartFrame)
		{
			this.ShowWing();
		}
		else if (a == this.m_EndFrame)
		{
			this.ResetWing();
		}
	}

	// Token: 0x060179E5 RID: 96741 RVA: 0x00746C25 File Offset: 0x00745025
	private void ShowWing()
	{
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		base.owner.m_pkGeActor.SetAttachmentVisible("wing", false);
	}

	// Token: 0x060179E6 RID: 96742 RVA: 0x00746C59 File Offset: 0x00745059
	private void ResetWing()
	{
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		base.owner.m_pkGeActor.SetAttachmentVisible("wing", true);
	}

	// Token: 0x04010F9A RID: 69530
	private string m_StartFrame;

	// Token: 0x04010F9B RID: 69531
	private string m_EndFrame;
}
