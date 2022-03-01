using System;

// Token: 0x020001E5 RID: 485
public class SeFlag
{
	// Token: 0x06000F59 RID: 3929 RVA: 0x0004EAFB File Offset: 0x0004CEFB
	public SeFlag(int iFlag = 0)
	{
		this.m_iFlag = iFlag;
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x0004EB0C File Offset: 0x0004CF0C
	public bool HasFlag(int iFlag)
	{
		int num = this.m_iFlag & iFlag;
		return num != 0;
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x0004EB29 File Offset: 0x0004CF29
	public void SetFlag(int iFlag, string data = null)
	{
		this.m_iFlag |= iFlag;
		this.flagData = data;
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0004EB40 File Offset: 0x0004CF40
	public void ClearFlag(int iFlag)
	{
		this.m_iFlag &= ~iFlag;
		this.flagData = null;
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x0004EB58 File Offset: 0x0004CF58
	public void Clear()
	{
		this.m_iFlag = 0;
		this.flagData = null;
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0004EB68 File Offset: 0x0004CF68
	public int GetAllFlag()
	{
		return this.m_iFlag;
	}

	// Token: 0x06000F5F RID: 3935 RVA: 0x0004EB70 File Offset: 0x0004CF70
	public string GetFlagData()
	{
		return this.flagData;
	}

	// Token: 0x04000A9B RID: 2715
	protected int m_iFlag;

	// Token: 0x04000A9C RID: 2716
	protected string flagData;
}
