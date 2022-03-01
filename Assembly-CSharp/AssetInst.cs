using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class AssetInst
{
	// Token: 0x06000365 RID: 869 RVA: 0x00019C77 File Offset: 0x00018077
	public AssetInst()
	{
		this.m_AssetDesc = null;
		this.m_Object = null;
		this.m_Removed = false;
		this.m_InstanceID = -1;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00019CA2 File Offset: 0x000180A2
	public AssetInst(Object obj)
	{
		this.m_AssetDesc = null;
		this.m_Object = obj;
		this.m_Removed = false;
		this.m_InstanceID = -1;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00019CD0 File Offset: 0x000180D0
	public void Init(AssetDesc ad, Object obj, uint flag = 0U)
	{
		if (ad == null || ad.m_AssetObjRef == null)
		{
			Logger.LogErrorFormat("Bad asset desc! [{0}]", new object[]
			{
				ad.m_FullPath
			});
			this.m_AssetDesc = null;
			this.m_Object = null;
			return;
		}
		if (null == obj)
		{
			Logger.LogErrorFormat("Bad asset object! [{0}]", new object[]
			{
				ad.m_FullPath
			});
			this.m_AssetDesc = null;
			this.m_Object = null;
			return;
		}
		this.m_Removed = false;
		this.m_AssetDesc = ad;
		if (null == this.m_AssetDesc.m_AssetObjRef.Target as Object)
		{
			this.m_AssetDesc.Init(this.m_AssetDesc.m_FullPath, this.m_AssetDesc.assetType, this.m_AssetDesc.m_SubResource);
		}
		if (this.m_AssetDesc.isInstAsset)
		{
			this.m_Object = obj;
			GameObject gameObject = this.m_Object as GameObject;
			if (flag == 1U)
			{
				gameObject.SetActive(false);
			}
			if (null != gameObject)
			{
				AssetProxy component = gameObject.GetComponent<AssetProxy>();
				if (null != component)
				{
					if (component.Init(this))
					{
						this.m_InstanceID = gameObject.GetInstanceID();
						this.m_AssetDesc.AddRefInst(this);
						return;
					}
				}
				else
				{
					Logger.LogError("Get asset proxy component has failed!");
				}
			}
			this.m_AssetDesc = null;
			this.m_Object = null;
		}
		else
		{
			this.m_AssetDesc = null;
			this.m_Object = null;
		}
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00019E54 File Offset: 0x00018254
	public void Init(AssetDesc ad, uint flag)
	{
		if (ad.m_AssetObjRef == null)
		{
			Logger.LogErrorFormat("Bad asset desc! [{0}]", new object[]
			{
				ad.m_FullPath
			});
			this.m_AssetDesc = null;
			this.m_Object = null;
			return;
		}
		this.m_Removed = false;
		this.m_AssetDesc = ad;
		if (null == this.m_AssetDesc.m_AssetObjRef.Target as Object)
		{
			this.m_AssetDesc.Init(this.m_AssetDesc.m_FullPath, this.m_AssetDesc.assetType, this.m_AssetDesc.m_SubResource);
		}
		if (this.m_AssetDesc.isInstAsset)
		{
			this.m_Object = Object.Instantiate<GameObject>(this.m_AssetDesc.m_GameObject);
			GameObject gameObject = this.m_Object as GameObject;
			if (flag == 1U)
			{
				gameObject.SetActive(false);
			}
			if (null != gameObject)
			{
				AssetProxy assetProxy = gameObject.GetComponent<AssetProxy>();
				if (null == assetProxy)
				{
					assetProxy = gameObject.AddComponent<AssetProxy>();
				}
				if (null != assetProxy)
				{
					if (assetProxy.Init(this))
					{
						this.m_InstanceID = this.m_Object.GetInstanceID();
						this.m_AssetDesc.AddRefInst(this);
					}
					else
					{
						Object.Destroy(this.m_Object);
						this.m_Object = null;
						this.m_AssetDesc = null;
						this.m_InstanceID = -1;
					}
				}
			}
		}
		else
		{
			this.m_Object = (this.m_AssetDesc.m_AssetObjRef.Target as Object);
		}
	}

	// Token: 0x06000369 RID: 873 RVA: 0x00019FDC File Offset: 0x000183DC
	~AssetInst()
	{
		this._Dispose();
		this.m_Object = null;
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0001A014 File Offset: 0x00018414
	public void Release()
	{
		if (this.m_Removed)
		{
			return;
		}
		this._Dispose();
		this.m_Object = null;
		this.m_Removed = true;
		if (Global.Settings.enableAssetInstPool)
		{
			Singleton<AssetInstPool>.instance.RecycleAssetInst(this);
		}
	}

	// Token: 0x0600036B RID: 875 RVA: 0x0001A050 File Offset: 0x00018450
	private void _Dispose()
	{
		if (this.m_AssetDesc != null)
		{
			if (this.m_AssetDesc.isInstAsset)
			{
				this.m_AssetDesc.RemoveRefInst(this);
			}
			this.m_AssetDesc = null;
		}
		this.m_InstanceID = -1;
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x0600036C RID: 876 RVA: 0x0001A08C File Offset: 0x0001848C
	public bool isGameObject
	{
		get
		{
			return null != this.m_Object && null != this.m_Object as GameObject;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600036D RID: 877 RVA: 0x0001A0B2 File Offset: 0x000184B2
	public int instanceID
	{
		get
		{
			return this.m_InstanceID;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600036E RID: 878 RVA: 0x0001A0BA File Offset: 0x000184BA
	public Object obj
	{
		get
		{
			return this.m_Object;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x0600036F RID: 879 RVA: 0x0001A0C2 File Offset: 0x000184C2
	public Type assetType
	{
		get
		{
			return this.m_AssetDesc.assetType;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000370 RID: 880 RVA: 0x0001A0CF File Offset: 0x000184CF
	public AssetDesc assetDesc
	{
		get
		{
			return this.m_AssetDesc;
		}
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0001A0D7 File Offset: 0x000184D7
	public void Reset()
	{
		this.m_AssetDesc = null;
		this.m_Object = null;
		this.m_Removed = false;
		this.m_InstanceID = -1;
	}

	// Token: 0x0400034F RID: 847
	protected AssetDesc m_AssetDesc;

	// Token: 0x04000350 RID: 848
	protected Object m_Object;

	// Token: 0x04000351 RID: 849
	protected bool m_Removed;

	// Token: 0x04000352 RID: 850
	protected int m_InstanceID = -1;
}
