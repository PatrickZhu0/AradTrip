using System;
using System.Collections.Generic;

// Token: 0x0200412C RID: 16684
public class BDDBoxData
{
	// Token: 0x17001F1A RID: 7962
	// (set) Token: 0x06016B64 RID: 93028 RVA: 0x006E78C4 File Offset: 0x006E5CC4
	public float zDim
	{
		set
		{
			this.encryptedZDim = new VInt(value);
		}
	}

	// Token: 0x17001F1B RID: 7963
	// (get) Token: 0x06016B65 RID: 93029 RVA: 0x006E78D2 File Offset: 0x006E5CD2
	public VInt zDimInt
	{
		get
		{
			return this.encryptedZDim;
		}
	}

	// Token: 0x04010392 RID: 66450
	public List<DBoxImp> vBox = new List<DBoxImp>();

	// Token: 0x04010393 RID: 66451
	public int hurtID;

	// Token: 0x04010394 RID: 66452
	public int hurtType = 1;

	// Token: 0x04010395 RID: 66453
	private VInt encryptedZDim;
}
