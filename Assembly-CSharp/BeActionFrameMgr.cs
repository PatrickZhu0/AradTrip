using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004136 RID: 16694
public class BeActionFrameMgr
{
	// Token: 0x06016B8B RID: 93067 RVA: 0x006EB4E8 File Offset: 0x006E98E8
	public static Object GetSkillObjectCache(string res)
	{
		if (BeActionFrameMgr.skillObjectCache.ContainsKey(res))
		{
			return BeActionFrameMgr.skillObjectCache[res];
		}
		Object obj = Singleton<AssetLoader>.instance.LoadRes(res, typeof(DSkillData), true, 0U).obj;
		BeActionFrameMgr.skillObjectCache.Add(res, obj);
		return obj;
	}

	// Token: 0x06016B8C RID: 93068 RVA: 0x006EB53B File Offset: 0x006E993B
	public static void ClearSkillObjectCache()
	{
		BeActionFrameMgr.skillObjectCache.Clear();
	}

	// Token: 0x06016B8D RID: 93069 RVA: 0x006EB548 File Offset: 0x006E9948
	public static BDEntityActionInfo GetCached(string path)
	{
		BeActionFrameMgr.refInfo refInfo = null;
		if (BeActionFrameMgr.sEntityActionInfoCache.TryGetValue(path, out refInfo))
		{
			refInfo.refCount++;
			return refInfo.info;
		}
		return null;
	}

	// Token: 0x06016B8E RID: 93070 RVA: 0x006EB580 File Offset: 0x006E9980
	public static void AddCached(string path, BDEntityActionInfo actInfo)
	{
		if (BeActionFrameMgr.sEntityActionInfoCache.ContainsKey(path))
		{
			return;
		}
		actInfo.key = path;
		BeActionFrameMgr.sEntityActionInfoCache.Add(path, new BeActionFrameMgr.refInfo
		{
			info = actInfo,
			refCount = 1
		});
	}

	// Token: 0x06016B8F RID: 93071 RVA: 0x006EB5C8 File Offset: 0x006E99C8
	public static void ReleaseActInfo(BDEntityActionInfo actInfo)
	{
		BeActionFrameMgr.refInfo refInfo = null;
		if (BeActionFrameMgr.sEntityActionInfoCache.TryGetValue(actInfo.key, out refInfo))
		{
			refInfo.refCount--;
			if (refInfo.refCount == 0)
			{
				BeActionFrameMgr.sEntityActionInfoCache.Remove(actInfo.key);
			}
		}
	}

	// Token: 0x06016B90 RID: 93072 RVA: 0x006EB618 File Offset: 0x006E9A18
	public static void Clear()
	{
		BeActionFrameMgr.sEntityActionInfoCache.Clear();
	}

	// Token: 0x040103F5 RID: 66549
	private static Dictionary<string, BeActionFrameMgr.refInfo> sEntityActionInfoCache = new Dictionary<string, BeActionFrameMgr.refInfo>();

	// Token: 0x040103F6 RID: 66550
	private static Dictionary<string, Object> skillObjectCache = new Dictionary<string, Object>();

	// Token: 0x02004137 RID: 16695
	private class refInfo
	{
		// Token: 0x040103F7 RID: 66551
		public BDEntityActionInfo info;

		// Token: 0x040103F8 RID: 66552
		public int refCount;
	}
}
