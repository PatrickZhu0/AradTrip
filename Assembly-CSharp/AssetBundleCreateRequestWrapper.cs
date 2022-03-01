using System;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class AssetBundleCreateRequestWrapper : IAsyncLoadWrapper<AssetBundle>
{
	// Token: 0x060004C0 RID: 1216 RVA: 0x0001FA5A File Offset: 0x0001DE5A
	public bool IsReady()
	{
		return this.m_LoadData.m_AssetPackage.IsDependecyLoaded();
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x0001FA6C File Offset: 0x0001DE6C
	public void Prepare(string loadPath, AsyncLoadData asyncLoadData)
	{
		if (this.m_LoadData == null)
		{
			this.m_LoadData = (asyncLoadData as AssetBundleCreateRequestData);
			this.m_LoadPath = loadPath;
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x0001FA8C File Offset: 0x0001DE8C
	public void DoLoad()
	{
		if (this.m_LoadData != null)
		{
			this.m_AassetBundle = Singleton<AssetBundleRegiester>.instance.AquireAssetBundle(this.m_LoadPath);
			if (null == this.m_AassetBundle)
			{
				this.m_Request = AssetBundle.LoadFromFileAsync(this.m_LoadPath);
			}
		}
		else
		{
			Logger.LogErrorFormat("Async load data is invalid with res path:{0}!", new object[]
			{
				this.m_LoadPath
			});
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0001FAFC File Offset: 0x0001DEFC
	public bool IsDone()
	{
		if (null != this.m_AassetBundle)
		{
			return true;
		}
		if (this.m_Request.isDone)
		{
			if (null != this.m_Request.assetBundle)
			{
				this.m_AassetBundle = this.m_Request.assetBundle;
				Singleton<AssetBundleRegiester>.instance.RegiesterAssetBundle(this.m_LoadPath, this.m_AassetBundle);
				this.m_Request = null;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0001FB73 File Offset: 0x0001DF73
	public AssetBundle Extract()
	{
		if (null != this.m_AassetBundle)
		{
			return this.m_AassetBundle;
		}
		if (this.m_Request == null)
		{
			return null;
		}
		return this.m_Request.assetBundle;
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x0001FBA5 File Offset: 0x0001DFA5
	public bool InLoading()
	{
		return this.m_Request != null || null != this.m_AassetBundle;
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0001FBC4 File Offset: 0x0001DFC4
	public void OnAbort()
	{
		if (null != this.m_AassetBundle)
		{
			Singleton<AssetBundleRegiester>.instance.ReleaseAssetBundle(this.m_AassetBundle, false);
			this.m_AassetBundle = null;
		}
		if (this.m_Request != null && this.m_Request.isDone)
		{
			this.m_Request.assetBundle.Unload(false);
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x0001FC26 File Offset: 0x0001E026
	public void Reset()
	{
		this.m_Request = null;
		this.m_AassetBundle = null;
		this.m_LoadData = null;
	}

	// Token: 0x0400042C RID: 1068
	public AssetBundleCreateRequest m_Request;

	// Token: 0x0400042D RID: 1069
	private AssetBundleCreateRequestData m_LoadData;

	// Token: 0x0400042E RID: 1070
	protected string m_LoadPath;

	// Token: 0x0400042F RID: 1071
	private AssetBundle m_AassetBundle;
}
