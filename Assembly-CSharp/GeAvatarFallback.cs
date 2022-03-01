using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using LibZip;
using UnityEngine;

// Token: 0x02000CE8 RID: 3304
public static class GeAvatarFallback
{
	// Token: 0x0600875B RID: 34651 RVA: 0x0017DCD4 File Offset: 0x0017C0D4
	private static int GetOccupationFromPath(string resName)
	{
		foreach (KeyValuePair<string, int> keyValuePair in GeAvatarFallback.OccupationDic)
		{
			if (resName.Contains(keyValuePair.Key))
			{
				Dictionary<string, int>.Enumerator enumerator;
				KeyValuePair<string, int> keyValuePair2 = enumerator.Current;
				return keyValuePair2.Value;
			}
		}
		return -1;
	}

	// Token: 0x17001822 RID: 6178
	// (get) Token: 0x0600875C RID: 34652 RVA: 0x0017DD28 File Offset: 0x0017C128
	// (set) Token: 0x0600875D RID: 34653 RVA: 0x0017DD2F File Offset: 0x0017C12F
	public static bool EnableGlobalAvatarPartFallback { get; set; }

	// Token: 0x0600875E RID: 34654 RVA: 0x0017DD37 File Offset: 0x0017C137
	public static bool IsAvatarPartFallbackEnabled()
	{
		return false;
	}

	// Token: 0x0600875F RID: 34655 RVA: 0x0017DD3C File Offset: 0x0017C13C
	public static bool GetAPKPackageInfo()
	{
		GeAvatarFallback.m_APKABs.Clear();
		IntPtr intPtr = IntPtr.Zero;
		intPtr = LibZip.zip_open(Application.dataPath, 1, IntPtr.Zero);
		if (IntPtr.Zero == intPtr)
		{
			Debug.LogErrorFormat("[Zip] CompressFiles Open File fail {0}", new object[]
			{
				Application.dataPath
			});
			return false;
		}
		zip_stat zip_stat = default(zip_stat);
		int num = LibZip.zip_get_num_files(intPtr);
		for (int i = 0; i < num; i++)
		{
			if (LibZip.zip_stat_index(intPtr, (long)i, 0, ref zip_stat) == 0)
			{
				string path = Marshal.PtrToStringAnsi(zip_stat.name);
				GeAvatarFallback.m_APKABs.Add(Path.GetFileName(path));
			}
		}
		LibZip.zip_close(intPtr);
		return true;
	}

	// Token: 0x06008760 RID: 34656 RVA: 0x0017DDF0 File Offset: 0x0017C1F0
	public static void LoadAvatarRes()
	{
		if (GeAvatarFallback.m_Loaded)
		{
			return;
		}
		GeAvatarFallback.m_Loaded = true;
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes("Actor/AvatarFallback/AvatarFallbackAsset.asset", typeof(ScriptableObject), false, 0U);
		if (assetInst == null)
		{
			Debug.LogErrorFormat("LoadAvatarRes AvatarFallbackAsset failed", new object[0]);
			return;
		}
		GeAvatarFallback.m_AvatarFallback = (assetInst.obj as GeAvatarFallbackAsset);
		if (!GeAvatarFallback.GetAPKPackageInfo())
		{
			return;
		}
		GeAvatarFallback.m_LebianABDir = Singleton<PluginManager>.instance.LeBianGetFullResPath() + "assets/AssetBundles/";
		GeAvatarFallback.m_ResValid = true;
	}

	// Token: 0x06008761 RID: 34657 RVA: 0x0017DE80 File Offset: 0x0017C280
	public static string GetFallbackAvatar(int occupation, GeAvatarChannel channel, string resName)
	{
		if (!GeAvatarFallback.m_Loaded)
		{
			GeAvatarFallback.LoadAvatarRes();
		}
		if (GeAvatarFallback.m_AvatarFallback != null)
		{
			if (occupation == -1)
			{
				occupation = GeAvatarFallback.GetOccupationFromPath(resName);
			}
			if (occupation >= 0)
			{
				occupation -= occupation % 10;
				AvatarNames avatarNames;
				if (GeAvatarFallback.m_AvatarFallback.avatarDic.TryGetValue(occupation, out avatarNames))
				{
					return avatarNames.m_Names[(int)channel];
				}
			}
		}
		return null;
	}

	// Token: 0x06008762 RID: 34658 RVA: 0x0017DEEC File Offset: 0x0017C2EC
	public static bool IsAssetDependentAvaliable(string assetName)
	{
		if (!GeAvatarFallback.m_Loaded)
		{
			GeAvatarFallback.LoadAvatarRes();
		}
		if (!GeAvatarFallback.m_ResValid || GeAvatarFallback.m_ReadyAssets.Contains(assetName))
		{
			return true;
		}
		AssetLoader.QurreyResPackage(assetName, GeAvatarFallback.m_AssetDependentPackages);
		StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
		for (int i = 0; i < GeAvatarFallback.m_AssetDependentPackages.Count; i++)
		{
			string text = GeAvatarFallback.m_AssetDependentPackages[i];
			int num = text.LastIndexOf('/');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			if (!GeAvatarFallback.m_APKABs.Contains(text))
			{
				MyExtensionMethods.Clear(stringBuilder);
				stringBuilder.AppendFormat("{0}{1}", GeAvatarFallback.m_LebianABDir, GeAvatarFallback.m_AssetDependentPackages[i]);
				string path = stringBuilder.ToString();
				if (!File.Exists(path))
				{
					StringBuilderCache.Release(stringBuilder);
					GeAvatarFallback.m_AssetDependentPackages.Clear();
					return false;
				}
			}
		}
		StringBuilderCache.Release(stringBuilder);
		GeAvatarFallback.m_AssetDependentPackages.Clear();
		GeAvatarFallback.m_ReadyAssets.Add(assetName);
		return true;
	}

	// Token: 0x0400411D RID: 16669
	private static GeAvatarFallbackAsset m_AvatarFallback;

	// Token: 0x0400411E RID: 16670
	private static bool m_Loaded;

	// Token: 0x0400411F RID: 16671
	private static HashSet<string> m_ReadyAssets = new HashSet<string>();

	// Token: 0x04004120 RID: 16672
	private static List<string> m_AssetDependentPackages = new List<string>();

	// Token: 0x04004121 RID: 16673
	private static string m_LebianABDir;

	// Token: 0x04004122 RID: 16674
	private static bool m_ResValid;

	// Token: 0x04004123 RID: 16675
	private static HashSet<string> m_APKABs = new HashSet<string>();

	// Token: 0x04004124 RID: 16676
	private static Dictionary<string, int> OccupationDic = new Dictionary<string, int>
	{
		{
			"Swordsman",
			10
		},
		{
			"Gunman",
			20
		},
		{
			"MageGirl",
			30
		},
		{
			"Fightergirl",
			40
		},
		{
			"Gungirl",
			50
		},
		{
			"Paladin",
			60
		}
	};
}
