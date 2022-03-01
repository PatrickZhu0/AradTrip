using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class CResPreloader : MonoSingleton<CResPreloader>
{
	// Token: 0x0600042F RID: 1071 RVA: 0x0001DE3C File Offset: 0x0001C23C
	public static void DefaultResExtractor(string file)
	{
		MonoSingleton<CResPreloader>.instance.AddRes(file, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0001DE5B File Offset: 0x0001C25B
	public void SetTag(CResPreloader.PreloadTag tag)
	{
		this.curTag = tag;
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0001DE64 File Offset: 0x0001C264
	public void RemovePriorityKeys(CResPreloader.PreloadTag tag)
	{
		this.priorityKeys.RemoveAll((CResPreloader.PriorityKey x) => x.tag == tag);
		this.priorityGameObjectKeys.Clear();
		for (int i = 0; i < this.priorityKeys.Count; i++)
		{
			this.priorityGameObjectKeys.Add(this.priorityKeys[i].key);
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0001DED9 File Offset: 0x0001C2D9
	public void Clear(bool allclear = false)
	{
		this.m_ResPreloadTbl.Clear();
		if (allclear)
		{
			this.priorityGameObjectKeys.Clear();
			this.priorityKeys.Clear();
		}
		this.m_StatePreloading = false;
		this.m_Percentage = 0;
		this.m_ProcessCount = 0;
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0001DF18 File Offset: 0x0001C318
	public void AddRes(string resFullPath, bool mustExist = false, int num = 1, ResExtrator extractor = null, int extData = 0, List<string> extDataList = null, CResPreloader.ResType resType = CResPreloader.ResType.OBJECT, Type t = null)
	{
		if (this.m_StatePreloading)
		{
			return;
		}
		bool flag = true;
		if (string.IsNullOrEmpty(resFullPath))
		{
			return;
		}
		if (extractor != null)
		{
			extractor(resFullPath);
		}
		else
		{
			bool flag2 = true;
			if (flag)
			{
				CResPreloader.CResDesc cresDesc = this.m_ResPreloadTbl.Find((CResPreloader.CResDesc x) => x.m_FullPath == resFullPath);
				if (cresDesc != null)
				{
					flag2 = false;
					cresDesc.num += num;
					if (cresDesc.extData == 0 && extData > 0)
					{
						cresDesc.extDataList = extDataList;
					}
				}
			}
			if (flag2)
			{
				CResPreloader.CResDesc cresDesc2 = new CResPreloader.CResDesc();
				cresDesc2.m_FullPath = resFullPath;
				cresDesc2.m_MustExist = mustExist;
				cresDesc2.m_Type = this._GetResType(PathUtil.GetExtension(resFullPath));
				cresDesc2.num = num;
				cresDesc2.extData = extData;
				cresDesc2.extDataList = extDataList;
				cresDesc2.tag = this.curTag;
				cresDesc2.resType = resType;
				cresDesc2.type = t;
				this.m_ResPreloadTbl.Add(cresDesc2);
			}
		}
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0001E03C File Offset: 0x0001C43C
	public int DoPreLoad()
	{
		this.m_StatePreloading = true;
		AssetLoader instance = Singleton<AssetLoader>.GetInstance();
		if (instance == null)
		{
			return 0;
		}
		for (int i = 0; i < this.m_ResPreloadTbl.Count; i++)
		{
			CResPreloader.CResDesc cresDesc = this.m_ResPreloadTbl[i];
			instance.LoadRes(cresDesc.m_FullPath, cresDesc.m_Type, cresDesc.m_MustExist, 0U);
		}
		return 100;
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x0001E0A4 File Offset: 0x0001C4A4
	public int DoPreLoadAsync(bool savePriority = false, bool useSync = false)
	{
		this.m_StatePreloading = true;
		if (Singleton<AssetLoader>.GetInstance() == null)
		{
			return 0;
		}
		Type typeFromHandle = typeof(AudioClip);
		long num = 0L;
		for (int i = this.m_ProcessCount; i < this.m_ResPreloadTbl.Count; i++)
		{
			CResPreloader.CResDesc cresDesc = this.m_ResPreloadTbl[i];
			long ticks = DateTime.Now.Ticks;
			int num2 = cresDesc.num;
			if (cresDesc.resType == CResPreloader.ResType.RES)
			{
				AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(cresDesc.m_FullPath, cresDesc.type, true, 0U);
				if (assetInst.obj != null && cresDesc.type == typeFromHandle)
				{
					MonoSingleton<AudioManager>.instance.AddPreloadSound(assetInst.obj);
				}
			}
			else
			{
				string prefabFullPath = TMEngine.Runtime.Utility.Path.ChangeExtension(cresDesc.m_FullPath.Replace("_ModelData", null), ".prefab");
				Singleton<CGameObjectPool>.instance.PrepareGameObject(prefabFullPath, enResourceType.BattleScene, num2);
			}
			this.PreloadAnimation(cresDesc);
			if (!useSync)
			{
				num += DateTime.Now.Ticks - ticks;
				if (num > this.TIME_SLICE_TICKES)
				{
					this.m_ProcessCount = i;
					return (int)((float)this.m_ProcessCount / (float)this.m_ResPreloadTbl.Count);
				}
			}
		}
		if (savePriority)
		{
			for (int j = 0; j < this.m_ResPreloadTbl.Count; j++)
			{
				CResPreloader.PriorityKey priorityKey = new CResPreloader.PriorityKey();
				priorityKey.key = CFileManager.EraseExtension(this.m_ResPreloadTbl[j].m_FullPath);
				priorityKey.tag = this.m_ResPreloadTbl[j].tag;
				this.priorityKeys.Add(priorityKey);
				this.priorityGameObjectKeys.Add(priorityKey.key);
			}
		}
		bool flag = true;
		if (flag)
		{
			List<string> list = new List<string>();
			list.Add("---------------------------------");
			for (int k = 0; k < this.m_ResPreloadTbl.Count; k++)
			{
				list.Add(this.m_ResPreloadTbl[k].m_FullPath);
				if (this.m_ResPreloadTbl[k].extDataList != null)
				{
					for (int l = 0; l < this.m_ResPreloadTbl[k].extDataList.Count; l++)
					{
						list.Add("--" + this.m_ResPreloadTbl[k].extDataList[l]);
					}
				}
			}
			Singleton<ExceptionManager>.GetInstance().PrintPreloadRes(list);
			list.Clear();
			List<int> cachedResID = PreloadManager.cachedResID;
			list.Add("RES ID---------------------------------");
			for (int m = 0; m < cachedResID.Count; m++)
			{
				list.Add(cachedResID[m].ToString());
			}
			Singleton<ExceptionManager>.GetInstance().PrintPreloadRes(list);
		}
		this.m_ResPreloadTbl.Clear();
		return 100;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0001E3B4 File Offset: 0x0001C7B4
	private void PreloadAnimation(CResPreloader.CResDesc desc)
	{
		if (desc != null && desc.extData > 0 && desc.extDataList != null)
		{
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(desc.m_FullPath, enResourceType.BattleScene, 0U);
			if (gameObject != null)
			{
				GeAnimDescProxy component = gameObject.GetComponent<GeAnimDescProxy>();
				if (component != null)
				{
					component.PreloadAction(desc.extDataList.ToArray());
				}
				Singleton<CGameObjectPool>.instance.RecycleGameObject(gameObject);
			}
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0001E42C File Offset: 0x0001C82C
	public int GetLoadPercentage()
	{
		return this.m_Percentage;
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0001E434 File Offset: 0x0001C834
	protected void _LoadRes(string resFullPath)
	{
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0001E438 File Offset: 0x0001C838
	protected IEnumerator _LoadResAsync()
	{
		yield return null;
		yield break;
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0001E44C File Offset: 0x0001C84C
	protected Type _GetResType(string fullPath)
	{
		string extension = PathUtil.GetExtension(fullPath);
		if (string.Equals(extension, ".prefab", StringComparison.OrdinalIgnoreCase))
		{
			return typeof(GameObject);
		}
		if (string.Equals(extension, ".asset", StringComparison.OrdinalIgnoreCase))
		{
			return typeof(ScriptableObject);
		}
		return typeof(Object);
	}

	// Token: 0x040003D0 RID: 976
	protected CResPreloader.PreloadTag curTag;

	// Token: 0x040003D1 RID: 977
	protected bool m_StatePreloading;

	// Token: 0x040003D2 RID: 978
	protected int m_Percentage;

	// Token: 0x040003D3 RID: 979
	protected int m_ProcessCount;

	// Token: 0x040003D4 RID: 980
	protected List<CResPreloader.CResDesc> m_ResPreloadTbl = new List<CResPreloader.CResDesc>();

	// Token: 0x040003D5 RID: 981
	public List<string> priorityGameObjectKeys = new List<string>();

	// Token: 0x040003D6 RID: 982
	protected List<CResPreloader.PriorityKey> priorityKeys = new List<CResPreloader.PriorityKey>();

	// Token: 0x040003D7 RID: 983
	protected readonly long TIME_SLICE_TICKES = 10000000L;

	// Token: 0x020000C5 RID: 197
	public enum PreloadTag
	{
		// Token: 0x040003D9 RID: 985
		NONE,
		// Token: 0x040003DA RID: 986
		HELL
	}

	// Token: 0x020000C6 RID: 198
	public enum ResType
	{
		// Token: 0x040003DC RID: 988
		OBJECT,
		// Token: 0x040003DD RID: 989
		RES
	}

	// Token: 0x020000C7 RID: 199
	protected class CResDesc
	{
		// Token: 0x040003DE RID: 990
		public string m_FullPath;

		// Token: 0x040003DF RID: 991
		public Type m_Type;

		// Token: 0x040003E0 RID: 992
		public bool m_MustExist;

		// Token: 0x040003E1 RID: 993
		public int num = 1;

		// Token: 0x040003E2 RID: 994
		public int extData;

		// Token: 0x040003E3 RID: 995
		public List<string> extDataList;

		// Token: 0x040003E4 RID: 996
		public CResPreloader.PreloadTag tag;

		// Token: 0x040003E5 RID: 997
		public CResPreloader.ResType resType;

		// Token: 0x040003E6 RID: 998
		public Type type;
	}

	// Token: 0x020000C8 RID: 200
	protected class PriorityKey
	{
		// Token: 0x040003E7 RID: 999
		public string key;

		// Token: 0x040003E8 RID: 1000
		public CResPreloader.PreloadTag tag;
	}
}
