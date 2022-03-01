using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
internal class AssetManager
{
	// Token: 0x060003D9 RID: 985 RVA: 0x0001BDDD File Offset: 0x0001A1DD
	public static Object LoadAsset(string strResPath, Type type, bool usePool, uint flag, bool mustExist = false)
	{
		if (usePool)
		{
			return Singleton<CGameObjectPool>.instance.GetGameObject(strResPath, enResourceType.BattleScene, 2U);
		}
		return Singleton<AssetLoader>.instance.LoadRes(strResPath, type, mustExist, 0U).obj;
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0001BE07 File Offset: 0x0001A207
	public static uint LoadAssetRequest(string strResPath, Type type, bool usePool, uint flag, bool mustExist = false, uint waterMark = 0U)
	{
		if (usePool)
		{
			return Singleton<CGameObjectPool>.instance.GetGameObjectAsync(strResPath, enResourceType.BattleScene, flag, waterMark);
		}
		return Singleton<AssetLoader>.instance.LoadResAync(strResPath, type, mustExist, flag, waterMark);
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0001BE30 File Offset: 0x0001A230
	public static void RecycleAsset(Object obj)
	{
		GameObject gameObject = obj as GameObject;
		if (null != gameObject)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(gameObject);
		}
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0001BE5C File Offset: 0x0001A25C
	public static bool IsRequestDone(uint handle)
	{
		uint num = handle >> 30 & 3U;
		if (num == 0U)
		{
			return Singleton<AssetLoader>.instance.IsRequestDone(handle);
		}
		if (num != 1U)
		{
			Logger.LogErrorFormat("Handle type [{0}] is invalid!", new object[]
			{
				num
			});
			return true;
		}
		return Singleton<CGameObjectPool>.instance.IsRequestDone(handle);
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0001BEBC File Offset: 0x0001A2BC
	public static Object ExtractAsset(uint handle)
	{
		uint num = handle >> 30 & 3U;
		if (num == 0U)
		{
			return Singleton<AssetLoader>.instance.Extract(handle).obj;
		}
		if (num != 1U)
		{
			Logger.LogErrorFormat("Handle type [{0}] is invalid!", new object[]
			{
				num
			});
			return null;
		}
		return Singleton<CGameObjectPool>.instance.ExtractAsset(handle);
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0001BF20 File Offset: 0x0001A320
	public static void AbortRequest(uint handle)
	{
		uint num = handle >> 30 & 3U;
		if (num == 0U)
		{
			Singleton<AssetLoader>.instance.AbortRequest(handle);
			return;
		}
		if (num != 1U)
		{
			Logger.LogErrorFormat("Handle type [{0}] is invalid!", new object[]
			{
				num
			});
			return;
		}
		Singleton<CGameObjectPool>.instance.AbortRequest(handle);
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0001BF78 File Offset: 0x0001A378
	public static bool IsValidHandle(uint handle)
	{
		uint num = handle >> 30 & 3U;
		if (num == 0U)
		{
			return Singleton<AssetLoader>.instance.IsValidHandle(handle);
		}
		if (num != 1U)
		{
			Logger.LogErrorFormat("Handle type [{0}] is invalid!", new object[]
			{
				num
			});
			return false;
		}
		return Singleton<CGameObjectPool>.instance.IsValidHandle(handle);
	}
}
