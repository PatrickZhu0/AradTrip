using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class AssetProxy : MonoBehaviour
{
	// Token: 0x0600043E RID: 1086 RVA: 0x0001E580 File Offset: 0x0001C980
	public void AddResRef(AssetProxy assetProxy)
	{
		if (null != assetProxy && assetProxy.m_AssetInst != null)
		{
			if (Global.Settings.enableAssetInstPool)
			{
				this.m_AssetInst = Singleton<AssetInstPool>.instance.GetAssetInst(assetProxy.m_AssetInst.assetDesc, base.gameObject, 1U);
			}
			else
			{
				this.m_AssetInst = new AssetInst();
				this.m_AssetInst.Init(assetProxy.m_AssetInst.assetDesc, base.gameObject, 1U);
			}
		}
		if (this.m_AssetInst != null && this.m_AssetInst.obj as GameObject == assetProxy.m_AssetInst.obj as GameObject)
		{
			Singleton<ExceptionManager>.instance.RecordLog("m_AssetInst.obj == assetProxy.m_AssetInst.obj reference copy error!");
		}
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0001E648 File Offset: 0x0001CA48
	public bool Init(AssetInst assetInst)
	{
		if (assetInst == this.m_AssetInst)
		{
			return true;
		}
		if (this.m_AssetInst == null)
		{
			if (assetInst != null)
			{
				if (null == assetInst.obj)
				{
				}
				this.m_AssetInst = assetInst;
				return true;
			}
			Singleton<ExceptionManager>.instance.RecordLog("null == assetInst!");
		}
		else
		{
			Singleton<ExceptionManager>.instance.RecordLog("null == m_AssetInst!");
		}
		this.m_AssetInst = null;
		return false;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0001E6B9 File Offset: 0x0001CAB9
	private void OnEnable()
	{
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0001E6BC File Offset: 0x0001CABC
	private void OnDestroy()
	{
		if (this.m_LogWhenDispose)
		{
			Logger.LogErrorFormat("AssetProxy OnDestroy![{0}]", new object[]
			{
				this.m_AssetInst.assetDesc.m_FullPath
			});
		}
		if (this.m_AssetInst != null)
		{
			this.m_AssetInst.Release();
			this.m_AssetInst = null;
		}
		this.m_LogWhenDispose = false;
	}

	// Token: 0x040003E9 RID: 1001
	public bool m_LogWhenDispose;

	// Token: 0x040003EA RID: 1002
	protected AssetInst m_AssetInst;
}
