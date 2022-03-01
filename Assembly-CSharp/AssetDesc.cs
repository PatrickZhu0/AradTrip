using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class AssetDesc
{
	// Token: 0x06000352 RID: 850 RVA: 0x00019488 File Offset: 0x00017888
	public bool Init(string fullPath, Type type, string subRes = "")
	{
		float num = Time.realtimeSinceStartup * 1000f;
		Object @object = this._CreateAsset(PathUtil.EraseExtension(fullPath), type, subRes);
		this.m_AssetObjRef = new WeakReference(@object, false);
		num = Time.realtimeSinceStartup * 1000f - num;
		if (this.m_AssetObjRef != null)
		{
			this.m_AssetType = type;
			this.m_FullPath = fullPath;
			this.m_Extension = PathUtil.GetExtension(fullPath);
			this.m_SubResource = subRes;
			if (this.m_AssetObjRef.Target != null)
			{
				this.m_AssetObjInstID = @object.GetInstanceID();
				this.m_IsInstAsset = (this.m_AssetObjRef.Target is GameObject);
				if (this.m_IsInstAsset)
				{
					this.m_GameObject = (this.m_AssetObjRef.Target as GameObject);
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000353 RID: 851 RVA: 0x00019550 File Offset: 0x00017950
	public void InitAsync(string fullPath, Type type, string subRes = "", bool highPriority = false)
	{
		this.m_AssetType = type;
		this.m_FullPath = fullPath;
		this.m_Extension = PathUtil.GetExtension(fullPath);
		this.m_SubResource = subRes;
		this.m_AsyncRequest = this._CreateAssetAsync(fullPath, type, subRes, highPriority);
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00019584 File Offset: 0x00017984
	public bool CheckAsyncLoadComplete()
	{
		if (this.m_AsyncRequest == null)
		{
			return true;
		}
		if (this.m_AssetPackage != null && null == this.m_AssetPackage.assetBundle)
		{
			if (EngineConfig.asyncPackageLoad)
			{
				if (!this.m_AssetPackage.IsPackageInLoading())
				{
					Singleton<AssetPackageManager>.instance.LoadPackageAsync(this.m_AssetPackage, false, false);
				}
			}
			else
			{
				Singleton<AssetPackageManager>.instance.LoadPackage(this.m_AssetPackage, false);
			}
		}
		if (this.m_AsyncRequest.IsDone())
		{
			Object @object = this.m_AsyncRequest.Extract();
			this.m_AssetObjRef = new WeakReference(@object, false);
			if (this.m_AssetObjRef.Target != null)
			{
				this.m_AssetObjInstID = @object.GetInstanceID();
				this.m_IsInstAsset = (this.m_AssetObjRef.Target is GameObject);
				if (this.m_IsInstAsset)
				{
					this.m_GameObject = (this.m_AssetObjRef.Target as GameObject);
				}
			}
			this.m_AsyncRequest = null;
			return true;
		}
		return false;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0001968C File Offset: 0x00017A8C
	protected IAsyncLoadRequest<Object> _CreateAssetAsync(string assetPath, Type type, string subRes = "", bool highPriority = false)
	{
		if (!Global.Settings.loadFromPackage || assetPath.Contains("Base/"))
		{
			float num;
			IAsyncLoadRequest<Object> result;
			if (type == typeof(Sprite) && !string.IsNullOrEmpty(subRes))
			{
				num = Time.realtimeSinceStartup * 1000f;
				result = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.AllocAsyncTask(assetPath, new ResourceResquestData(type, subRes), highPriority);
				num = Time.realtimeSinceStartup * 1000f - num;
				Singleton<AssetLoadStatistician>.instance.AddAssetProfile(assetPath, num, false, true);
				return result;
			}
			num = Time.realtimeSinceStartup * 1000f;
			result = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.AllocAsyncTask(assetPath, new ResourceResquestData(type, subRes), highPriority);
			num = Time.realtimeSinceStartup * 1000f - num;
			Singleton<AssetLoadStatistician>.instance.AddAssetProfile(assetPath, num, false, true);
			return result;
		}
		else
		{
			string text = null;
			this.m_AssetPackage = Singleton<AssetPackageManager>.instance.GetResPackage(assetPath, type, out text);
			if (this.m_AssetPackage != null)
			{
				string resName = assetPath;
				if (this.m_AssetPackage.usingHashName && !string.IsNullOrEmpty(text))
				{
					resName = text;
				}
				float num2 = Time.realtimeSinceStartup * 1000f;
				return this.m_AssetPackage.LoadResFromPackageAsync(resName, type, subRes, highPriority);
			}
			return AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>.INVALID_LOAD_REQUEST;
		}
	}

	// Token: 0x06000356 RID: 854 RVA: 0x000197BC File Offset: 0x00017BBC
	public void Deinit()
	{
		if (this.m_AssetObjRef == null)
		{
			Logger.LogErrorFormat("Bad asset \"{0}\"!", new object[]
			{
				this.m_FullPath
			});
		}
		else if (this.m_AssetObjRef.IsAlive)
		{
		}
		this._DestroyAsset();
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00019808 File Offset: 0x00017C08
	public AssetInst CreateRefInst(uint flag = 0U)
	{
		AssetInst assetInst;
		if (Global.Settings.enableAssetInstPool)
		{
			assetInst = Singleton<AssetInstPool>.instance.GetAssetInst(this, null, flag);
		}
		else
		{
			assetInst = new AssetInst();
			assetInst.Init(this, flag);
		}
		this.m_LastUseTime = Time.time;
		return assetInst;
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00019853 File Offset: 0x00017C53
	public void AddRefInst(AssetInst assetInst)
	{
		if (null != assetInst.obj)
		{
			this.m_ObjectList.Add(assetInst.obj as GameObject);
		}
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0001987C File Offset: 0x00017C7C
	public void RemoveRefInst(AssetInst assetInst)
	{
		if (null != assetInst.obj)
		{
			bool hasRemoved = false;
			this.m_ObjectList.RemoveAll(delegate(GameObject f)
			{
				if (f == assetInst.obj as GameObject)
				{
					hasRemoved = true;
				}
				return f == assetInst.obj as GameObject;
			});
			if (!hasRemoved)
			{
				Logger.LogErrorFormat("Asset [{0}] inst is not in list!", new object[]
				{
					assetInst.assetDesc.m_FullPath
				});
			}
		}
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00019906 File Offset: 0x00017D06
	protected void _CheckDeadObj()
	{
		this.m_ObjectList.RemoveAll((GameObject f) => null == f);
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00019934 File Offset: 0x00017D34
	public int GetRefCount()
	{
		if (this.isInstAsset)
		{
			this._CheckDeadObj();
			if (this.m_ObjectList != null)
			{
				return this.m_ObjectList.Count;
			}
			return 0;
		}
		else
		{
			if (this.m_AssetObjRef != null && null != this.m_AssetObjRef.Target as Object)
			{
				return 1;
			}
			return 0;
		}
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00019994 File Offset: 0x00017D94
	public bool CanBeRemoved()
	{
		return 0 == this.GetRefCount();
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x0600035D RID: 861 RVA: 0x0001999F File Offset: 0x00017D9F
	public float lastUseTime
	{
		get
		{
			return this.m_LastUseTime;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x0600035E RID: 862 RVA: 0x000199A7 File Offset: 0x00017DA7
	public bool isInstAsset
	{
		get
		{
			return this.m_IsInstAsset;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x0600035F RID: 863 RVA: 0x000199AF File Offset: 0x00017DAF
	public bool initActive
	{
		get
		{
			return this.m_initActive;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000360 RID: 864 RVA: 0x000199B7 File Offset: 0x00017DB7
	public Type assetType
	{
		get
		{
			return this.m_AssetType;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000361 RID: 865 RVA: 0x000199BF File Offset: 0x00017DBF
	public bool IsDeadAsset
	{
		get
		{
			return null == this.m_AssetObjRef;
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x000199CC File Offset: 0x00017DCC
	protected Object _CreateAsset(string assetPath, Type type, string subRes = "")
	{
		Object @object = null;
		if (!Global.Settings.loadFromPackage || assetPath.Contains("Base/"))
		{
			float num = Time.realtimeSinceStartup * 1000f;
			if (type == typeof(Sprite))
			{
				if (!string.IsNullOrEmpty(subRes))
				{
					Sprite[] array = Resources.LoadAll<Sprite>(CFileManager.EraseExtension(assetPath));
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].name == subRes)
						{
							return array[i];
						}
					}
				}
			}
			else if (type == typeof(AnimationClip) && !string.IsNullOrEmpty(subRes))
			{
				AnimationClip[] array2 = Resources.LoadAll<AnimationClip>(CFileManager.EraseExtension(assetPath));
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j].name == subRes)
					{
						return array2[j];
					}
				}
			}
			@object = Resources.Load(PathUtil.EraseExtension(assetPath), type);
			num = Time.realtimeSinceStartup * 1000f - num;
			Singleton<AssetLoadStatistician>.instance.AddAssetProfile(assetPath, num, false, false);
		}
		else
		{
			float num2 = Time.realtimeSinceStartup * 1000f;
			string text = null;
			this.m_AssetPackage = Singleton<AssetPackageManager>.instance.GetResPackage(assetPath, type, out text);
			if (this.m_AssetPackage != null)
			{
				string resName = assetPath;
				if (this.m_AssetPackage.usingHashName && !string.IsNullOrEmpty(text))
				{
					resName = text;
				}
				@object = this.m_AssetPackage.LoadResFromPackage(resName, type, false, subRes);
				if (null == @object)
				{
				}
			}
			num2 = Time.realtimeSinceStartup * 1000f - num2;
			Singleton<AssetLoadStatistician>.instance.AddAssetProfile(assetPath, num2, true, false);
		}
		return @object;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00019B7C File Offset: 0x00017F7C
	protected void _DestroyAsset()
	{
		if (this.m_AsyncRequest != null)
		{
			this.m_AsyncRequest.Abort();
			this.m_AsyncRequest = null;
		}
		if (this.m_AssetObjRef == null)
		{
			return;
		}
		if (this.m_AssetPackage != null)
		{
			this.m_AssetPackage.UnloadAsset(this.m_AssetObjInstID);
			this.m_AssetPackage = null;
		}
		else if (!this.isInstAsset)
		{
			Resources.UnloadAsset(this.m_AssetObjRef.Target as Object);
		}
		this.m_AssetObjRef = null;
		this.m_GameObject = null;
		this.m_AssetObjInstID = -1;
	}

	// Token: 0x04000340 RID: 832
	public string m_FullPath;

	// Token: 0x04000341 RID: 833
	public int m_FullPathHash = -1;

	// Token: 0x04000342 RID: 834
	public string m_Extension;

	// Token: 0x04000343 RID: 835
	public string m_SubResource;

	// Token: 0x04000344 RID: 836
	public GameObject m_GameObject;

	// Token: 0x04000345 RID: 837
	public int m_AssetObjInstID = -1;

	// Token: 0x04000346 RID: 838
	public AssetPackage m_AssetPackage;

	// Token: 0x04000347 RID: 839
	public WeakReference m_AssetObjRef;

	// Token: 0x04000348 RID: 840
	public IAsyncLoadRequest<Object> m_AsyncRequest;

	// Token: 0x04000349 RID: 841
	private Type m_AssetType = typeof(void);

	// Token: 0x0400034A RID: 842
	protected bool m_IsInstAsset;

	// Token: 0x0400034B RID: 843
	protected List<GameObject> m_ObjectList = new List<GameObject>();

	// Token: 0x0400034C RID: 844
	protected float m_LastUseTime;

	// Token: 0x0400034D RID: 845
	protected bool m_initActive;
}
