using System;
using System.Collections.Generic;

// Token: 0x02004139 RID: 16697
public class SkillFileListCache
{
	// Token: 0x06016B96 RID: 93078 RVA: 0x006EB7AC File Offset: 0x006E9BAC
	public static List<SkillFileName> GetCached(string path)
	{
		List<SkillFileName> list = null;
		if (SkillFileListCache.skillFileListCache.TryGetValue(path, out list))
		{
			return list;
		}
		list = BeUtility.GetSkillFileList(path);
		SkillFileListCache.AddCache(path, list);
		return list;
	}

	// Token: 0x06016B97 RID: 93079 RVA: 0x006EB7DE File Offset: 0x006E9BDE
	public static void AddCache(string path, List<SkillFileName> list)
	{
		if (SkillFileListCache.skillFileListCache.ContainsKey(path))
		{
			return;
		}
		SkillFileListCache.skillFileListCache.Add(path, list);
	}

	// Token: 0x06016B98 RID: 93080 RVA: 0x006EB800 File Offset: 0x006E9C00
	public static List<SkillFileName> GetCachedWithoutNew(string path)
	{
		List<SkillFileName> result = null;
		if (SkillFileListCache.skillFileListCache.TryGetValue(path, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06016B99 RID: 93081 RVA: 0x006EB824 File Offset: 0x006E9C24
	public static void Clear()
	{
		SkillFileListCache.skillFileListCache.Clear();
	}

	// Token: 0x04010405 RID: 66565
	private static Dictionary<string, List<SkillFileName>> skillFileListCache = new Dictionary<string, List<SkillFileName>>();
}
