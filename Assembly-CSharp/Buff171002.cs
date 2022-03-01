using System;

// Token: 0x0200421A RID: 16922
public class Buff171002 : BeBuff
{
	// Token: 0x060176D0 RID: 95952 RVA: 0x00732655 File Offset: 0x00730A55
	public Buff171002(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176D1 RID: 95953 RVA: 0x0073266E File Offset: 0x00730A6E
	public override void OnStart()
	{
		if (this.runeManager == null)
		{
			this.runeManager = (base.owner.GetMechanism(this.mechanismID) as Mechanism22);
		}
		if (this.runeManager != null)
		{
			this.runeManager.AddRune();
		}
	}

	// Token: 0x04010D17 RID: 68887
	private Mechanism22 runeManager;

	// Token: 0x04010D18 RID: 68888
	private int mechanismID = 1001;
}
