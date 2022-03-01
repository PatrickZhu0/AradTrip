using System;
using System.Collections.Generic;

// Token: 0x0200412F RID: 16687
public class BDEntityActionFrameData
{
	// Token: 0x06016B68 RID: 93032 RVA: 0x006E794C File Offset: 0x006E5D4C
	public BDEntityActionFrameData()
	{
		this.kRange.x = VInt.NewVInt(-10, 1).i;
		this.kRange.y = VInt.NewVInt(10, 1).i;
	}

	// Token: 0x040103A8 RID: 66472
	public BDDBoxData pDefenseData;

	// Token: 0x040103A9 RID: 66473
	public BDDBoxData pAttackData;

	// Token: 0x040103AA RID: 66474
	public BDMoveData pMoveData;

	// Token: 0x040103AB RID: 66475
	public List<BDEventBase> pEvents = new List<BDEventBase>();

	// Token: 0x040103AC RID: 66476
	public VInt2 kRange;

	// Token: 0x040103AD RID: 66477
	public VInt2 kGrapPosition;

	// Token: 0x040103AE RID: 66478
	public SeFlag kFlag = new SeFlag(0);
}
