using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class AssetInstPool : Singleton<AssetInstPool>
{
	// Token: 0x06000393 RID: 915 RVA: 0x0001A840 File Offset: 0x00018C40
	public AssetInst GetAssetInst(AssetDesc ad, Object obj = null, uint flag = 0U)
	{
		AssetInst assetInst;
		if (this.m_AssetInstPool.Count > 0)
		{
			assetInst = this.m_AssetInstPool.Dequeue();
		}
		else
		{
			assetInst = new AssetInst();
		}
		if (assetInst != null)
		{
			if (null == obj)
			{
				assetInst.Init(ad, flag);
			}
			else
			{
				assetInst.Init(ad, obj, flag);
			}
		}
		return assetInst;
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0001A8A0 File Offset: 0x00018CA0
	public void RecycleAssetInst(AssetInst assetInst)
	{
		if (assetInst != null)
		{
			assetInst.Reset();
			this.m_AssetInstPool.Enqueue(assetInst);
		}
	}

	// Token: 0x0400036F RID: 879
	private Queue<AssetInst> m_AssetInstPool = new Queue<AssetInst>();
}
