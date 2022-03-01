using System;

// Token: 0x0200412D RID: 16685
public class BDGrabData
{
	// Token: 0x06016B66 RID: 93030 RVA: 0x006E78DC File Offset: 0x006E5CDC
	public BDGrabData()
	{
		this.posx = 0f;
		this.posy = 0f;
		this.endForcex = 0f;
		this.endForcey = 0f;
		this.duraction = 0;
		this.endForceType = 0;
		this.grabNum = 1;
		this.grabMoveSpeed = 0f;
		this.action = 12;
	}

	// Token: 0x04010396 RID: 66454
	public float posx;

	// Token: 0x04010397 RID: 66455
	public float posy;

	// Token: 0x04010398 RID: 66456
	public float endForcex;

	// Token: 0x04010399 RID: 66457
	public float endForcey;

	// Token: 0x0401039A RID: 66458
	public int duraction;

	// Token: 0x0401039B RID: 66459
	public int endForceType;

	// Token: 0x0401039C RID: 66460
	public int action;

	// Token: 0x0401039D RID: 66461
	public int grabNum;

	// Token: 0x0401039E RID: 66462
	public float grabMoveSpeed;

	// Token: 0x0401039F RID: 66463
	public bool quickPressDismis;

	// Token: 0x040103A0 RID: 66464
	public bool notGrabBati;

	// Token: 0x040103A1 RID: 66465
	public bool notGrabGeDang;

	// Token: 0x040103A2 RID: 66466
	public bool notUseGrabSetPos;

	// Token: 0x040103A3 RID: 66467
	public bool notGrabToBlock;

	// Token: 0x040103A4 RID: 66468
	public int buffInfoId;

	// Token: 0x040103A5 RID: 66469
	public int buffInfoIdToSelf;

	// Token: 0x040103A6 RID: 66470
	public int buffInfoIDToOther;
}
