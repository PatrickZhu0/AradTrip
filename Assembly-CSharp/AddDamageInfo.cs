using System;

// Token: 0x02004176 RID: 16758
public struct AddDamageInfo
{
	// Token: 0x06016F6A RID: 94058 RVA: 0x0070A3D4 File Offset: 0x007087D4
	public AddDamageInfo(int v, int at = 0)
	{
		this.value = v;
		this.attackType = (AttackType)at;
	}

	// Token: 0x04010714 RID: 67348
	public CrypticInt32 value;

	// Token: 0x04010715 RID: 67349
	public AttackType attackType;
}
