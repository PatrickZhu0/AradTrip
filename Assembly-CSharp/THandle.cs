using System;

// Token: 0x020001E6 RID: 486
public struct THandle
{
	// Token: 0x06000F60 RID: 3936 RVA: 0x0004EB78 File Offset: 0x0004CF78
	public THandle(int eType = -1, int iHandleID = 0, uint iIndex = 0U)
	{
		this.m_eType = eType;
		this.m_iID = iHandleID;
		this.m_iIndex = iIndex;
	}

	// Token: 0x06000F61 RID: 3937 RVA: 0x0004EB8F File Offset: 0x0004CF8F
	public bool IsValid()
	{
		return true;
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x0004EB92 File Offset: 0x0004CF92
	public int Type()
	{
		return this.m_eType;
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x0004EB9A File Offset: 0x0004CF9A
	public int Id()
	{
		return this.m_iID;
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x0004EBA2 File Offset: 0x0004CFA2
	public uint Index()
	{
		return this.m_iIndex;
	}

	// Token: 0x04000A9D RID: 2717
	public int m_eType;

	// Token: 0x04000A9E RID: 2718
	public int m_iID;

	// Token: 0x04000A9F RID: 2719
	public uint m_iIndex;
}
