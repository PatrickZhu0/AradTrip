using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class AssetInstRequest : IAssetInstRequest
{
	// Token: 0x06000398 RID: 920 RVA: 0x0001A8BA File Offset: 0x00018CBA
	public AssetInstRequest()
	{
		this.Reset();
	}

	// Token: 0x06000399 RID: 921 RVA: 0x0001A8C8 File Offset: 0x00018CC8
	public void Reset()
	{
		this.m_HasExtract = false;
		this.m_AssetInst = null;
		this.m_IsDone = false;
		this.m_IsAbort = false;
		this.m_flag = 0U;
		this.m_waterMark = 0U;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0001A8F4 File Offset: 0x00018CF4
	public bool IsDone()
	{
		return this.m_IsDone;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0001A8FC File Offset: 0x00018CFC
	public AssetInst Extract()
	{
		if (!this.m_IsDone)
		{
			return null;
		}
		if (!this.m_HasExtract)
		{
			AssetInst assetInst = this.m_AssetInst;
			this.m_AssetInst = null;
			this.m_HasExtract = true;
			return assetInst;
		}
		return null;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x0001A939 File Offset: 0x00018D39
	public void Abort()
	{
		this.m_IsAbort = true;
		if (this.m_AssetInst != null && this.m_AssetInst.isGameObject)
		{
			Object.Destroy(this.m_AssetInst.obj);
		}
	}

	// Token: 0x04000370 RID: 880
	public bool m_HasExtract;

	// Token: 0x04000371 RID: 881
	public AssetInst m_AssetInst;

	// Token: 0x04000372 RID: 882
	public bool m_IsDone;

	// Token: 0x04000373 RID: 883
	public bool m_IsAbort;

	// Token: 0x04000374 RID: 884
	public uint m_flag;

	// Token: 0x04000375 RID: 885
	public uint m_waterMark;
}
