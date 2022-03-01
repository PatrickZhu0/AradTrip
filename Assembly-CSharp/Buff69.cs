using System;

// Token: 0x0200422E RID: 16942
public class Buff69 : BeBuff
{
	// Token: 0x0601773F RID: 96063 RVA: 0x00734DB7 File Offset: 0x007331B7
	public Buff69(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017740 RID: 96064 RVA: 0x00734DC5 File Offset: 0x007331C5
	public override void OnStart()
	{
		base.owner.m_pkGeActor.SetActorVisible(false);
	}

	// Token: 0x06017741 RID: 96065 RVA: 0x00734DD8 File Offset: 0x007331D8
	public override void OnFinish()
	{
		base.owner.m_pkGeActor.SetActorVisible(true);
	}
}
