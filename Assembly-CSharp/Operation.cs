using System;

// Token: 0x020041B6 RID: 16822
public struct Operation
{
	// Token: 0x04010B2B RID: 68395
	public Operation.OP op;

	// Token: 0x04010B2C RID: 68396
	public Operation.TARGET target;

	// Token: 0x04010B2D RID: 68397
	public string varName;

	// Token: 0x04010B2E RID: 68398
	public int value;

	// Token: 0x04010B2F RID: 68399
	public int[] skillIDs;

	// Token: 0x020041B7 RID: 16823
	public enum OP
	{
		// Token: 0x04010B31 RID: 68401
		NONE,
		// Token: 0x04010B32 RID: 68402
		ADD,
		// Token: 0x04010B33 RID: 68403
		REPLACE
	}

	// Token: 0x020041B8 RID: 16824
	public enum TARGET
	{
		// Token: 0x04010B35 RID: 68405
		NONE,
		// Token: 0x04010B36 RID: 68406
		SKILL,
		// Token: 0x04010B37 RID: 68407
		ACTOR
	}
}
