using System;

// Token: 0x02004234 RID: 16948
public class Buff810001 : BeBuff
{
	// Token: 0x06017759 RID: 96089 RVA: 0x00735363 File Offset: 0x00733763
	public Buff810001(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x04010D6B RID: 68971
	private int mEffectID = -1;

	// Token: 0x04010D6C RID: 68972
	private Buff810001.eState mState;

	// Token: 0x02004235 RID: 16949
	private enum eState
	{
		// Token: 0x04010D6E RID: 68974
		None,
		// Token: 0x04010D6F RID: 68975
		Inited,
		// Token: 0x04010D70 RID: 68976
		Checked
	}
}
