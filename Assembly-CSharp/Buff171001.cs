using System;

// Token: 0x02004219 RID: 16921
public class Buff171001 : BeBuff
{
	// Token: 0x060176CD RID: 95949 RVA: 0x007325F5 File Offset: 0x007309F5
	public Buff171001(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176CE RID: 95950 RVA: 0x0073260E File Offset: 0x00730A0E
	public override void OnStart()
	{
		if (this.runeManager == null)
		{
			this.runeManager = (base.owner.GetMechanism(this.mechanismID) as Mechanism22);
		}
		this.DoWorkForInterval();
	}

	// Token: 0x060176CF RID: 95951 RVA: 0x0073263D File Offset: 0x00730A3D
	public override void DoWorkForInterval()
	{
		if (this.runeManager != null)
		{
			this.runeManager.AddRune();
		}
	}

	// Token: 0x04010D15 RID: 68885
	private Mechanism22 runeManager;

	// Token: 0x04010D16 RID: 68886
	private int mechanismID = 1001;
}
