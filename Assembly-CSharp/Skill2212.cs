using System;

// Token: 0x0200449A RID: 17562
public class Skill2212 : BeSkill
{
	// Token: 0x060186B7 RID: 100023 RVA: 0x0079D6A5 File Offset: 0x0079BAA5
	public Skill2212(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060186B8 RID: 100024 RVA: 0x0079D6AF File Offset: 0x0079BAAF
	public override void OnStart()
	{
		base.OnStart();
		this.SetEffectVisible(false);
	}

	// Token: 0x060186B9 RID: 100025 RVA: 0x0079D6BE File Offset: 0x0079BABE
	public override void OnCancel()
	{
		base.OnCancel();
		this.SetEffectVisible(true);
	}

	// Token: 0x060186BA RID: 100026 RVA: 0x0079D6CD File Offset: 0x0079BACD
	public override void OnFinish()
	{
		base.OnFinish();
		this.SetEffectVisible(true);
	}

	// Token: 0x060186BB RID: 100027 RVA: 0x0079D6DC File Offset: 0x0079BADC
	protected void SetEffectVisible(bool isVisible)
	{
		base.owner.m_pkGeActor.GetEffectManager().SetEffectVisible(isVisible);
	}
}
