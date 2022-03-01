using System;

// Token: 0x02004227 RID: 16935
public class Buff4 : BeBuff
{
	// Token: 0x06017726 RID: 96038 RVA: 0x0073451D File Offset: 0x0073291D
	public Buff4(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017727 RID: 96039 RVA: 0x0073452B File Offset: 0x0073292B
	public override void OnFinish()
	{
		this.DoWorkForInterval();
	}
}
