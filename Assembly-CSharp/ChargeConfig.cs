using System;

// Token: 0x02004BB2 RID: 19378
[Serializable]
public struct ChargeConfig
{
	// Token: 0x040139BC RID: 80316
	public int repeatPhase;

	// Token: 0x040139BD RID: 80317
	public int changePhase;

	// Token: 0x040139BE RID: 80318
	public int switchPhaseID;

	// Token: 0x040139BF RID: 80319
	public float chargeDuration;

	// Token: 0x040139C0 RID: 80320
	public float chargeMinDuration;

	// Token: 0x040139C1 RID: 80321
	public string effect;

	// Token: 0x040139C2 RID: 80322
	public string locator;

	// Token: 0x040139C3 RID: 80323
	public int buffInfo;

	// Token: 0x040139C4 RID: 80324
	public bool playBuffAni;
}
