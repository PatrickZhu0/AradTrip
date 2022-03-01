using System;

// Token: 0x0200422B RID: 16939
public class Buff560001 : BeBuff
{
	// Token: 0x06017734 RID: 96052 RVA: 0x00734A71 File Offset: 0x00732E71
	public Buff560001(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017735 RID: 96053 RVA: 0x00734A7F File Offset: 0x00732E7F
	public override void OnStart()
	{
		base.owner.m_pkGeActor.SetActorVisible(false);
	}

	// Token: 0x06017736 RID: 96054 RVA: 0x00734A92 File Offset: 0x00732E92
	public override void OnFinish()
	{
		base.owner.m_pkGeActor.SetActorVisible(true);
	}
}
