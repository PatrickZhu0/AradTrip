using System;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class AssetBundleResquestWrapper : IAsyncLoadWrapper<Object>
{
	// Token: 0x060004B6 RID: 1206 RVA: 0x0001F83C File Offset: 0x0001DC3C
	public bool IsReady()
	{
		return this.m_LoadData != null && this.m_LoadData.m_AssetPackage != null && null != this.m_LoadData.m_AssetPackage.assetBundle;
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x0001F872 File Offset: 0x0001DC72
	public void Prepare(string loadPath, AsyncLoadData asyncLoadData)
	{
		if (this.m_LoadData == null)
		{
			this.m_LoadData = (asyncLoadData as AssetBundleResquestData);
			this.m_LoadPath = loadPath;
		}
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0001F894 File Offset: 0x0001DC94
	public void DoLoad()
	{
		if (this.m_LoadData != null)
		{
			string assetNameInPackage;
			if (AssetLoader.AsyncLoadPackageRes)
			{
				int num = this.m_LoadPath.LastIndexOf('/');
				if (num + 1 < this.m_LoadPath.Length)
				{
					assetNameInPackage = this.m_LoadPath.Substring(num + 1);
				}
				else
				{
					assetNameInPackage = this.m_LoadPath;
				}
			}
			else
			{
				assetNameInPackage = this.m_LoadPath;
			}
			this.m_Request = this.m_LoadData.m_AssetPackage.OnBeginLoadAssetAsync(assetNameInPackage, this.m_LoadData.m_AssetType, string.IsNullOrEmpty(this.m_LoadData.m_SubAsset));
		}
		else
		{
			Logger.LogErrorFormat("Async load data is invalid with res path:{0}!", new object[]
			{
				this.m_LoadPath
			});
		}
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0001F950 File Offset: 0x0001DD50
	public bool IsDone()
	{
		return this.m_Request.isDone;
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0001F95D File Offset: 0x0001DD5D
	public void OnAbort()
	{
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x0001F960 File Offset: 0x0001DD60
	public Object Extract()
	{
		if (this.m_Request == null)
		{
			return null;
		}
		Object @object = null;
		if (string.IsNullOrEmpty(this.m_LoadData.m_SubAsset))
		{
			@object = this.m_Request.asset;
		}
		else
		{
			Object[] allAssets = this.m_Request.allAssets;
			int i = 0;
			int num = allAssets.Length;
			while (i < num)
			{
				if (allAssets[i].name == this.m_LoadData.m_SubAsset)
				{
					@object = allAssets[i];
					break;
				}
				i++;
			}
		}
		this.m_LoadData.m_AssetPackage.OnFinishLoadAsset();
		if (null != @object)
		{
			this.m_LoadData.m_OnExtractCallback(@object, this.m_LoadPath);
		}
		return @object;
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0001FA1E File Offset: 0x0001DE1E
	public bool InLoading()
	{
		return null != this.m_Request;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0001FA2C File Offset: 0x0001DE2C
	public void Reset()
	{
		this.m_Request = null;
		this.m_LoadData = null;
		this.m_LoadPath = null;
	}

	// Token: 0x04000428 RID: 1064
	public AssetBundleRequest m_Request;

	// Token: 0x04000429 RID: 1065
	private AssetBundleResquestData m_LoadData;

	// Token: 0x0400042A RID: 1066
	protected string m_LoadPath;
}
