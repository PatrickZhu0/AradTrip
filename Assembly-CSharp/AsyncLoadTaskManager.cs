using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class AsyncLoadTaskManager : Singleton<AsyncLoadTaskManager>
{
	// Token: 0x06000489 RID: 1161 RVA: 0x0001F154 File Offset: 0x0001D554
	public AsyncLoadTaskManager()
	{
		if (AsyncLoadTaskManager.<>f__mg$cache0 == null)
		{
			AsyncLoadTaskManager.<>f__mg$cache0 = new OnAssetLoadSuccess(AsyncLoadTaskManager._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = AsyncLoadTaskManager.<>f__mg$cache0;
		if (AsyncLoadTaskManager.<>f__mg$cache1 == null)
		{
			AsyncLoadTaskManager.<>f__mg$cache1 = new OnAssetLoadFailure(AsyncLoadTaskManager._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, AsyncLoadTaskManager.<>f__mg$cache1);
		base..ctor();
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0001F1B8 File Offset: 0x0001D5B8
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		AsyncLoadTaskManager asyncLoadTaskManager = userData as AsyncLoadTaskManager;
		if (asyncLoadTaskManager != null)
		{
			GameObject gameObject = asset as GameObject;
			int i = 0;
			int count = asyncLoadTaskManager.mAsyncTasks.Count;
			while (i < count)
			{
				AsyncLoadTask asyncLoadTask = asyncLoadTaskManager.mAsyncTasks[i];
				if (grpID == (int)asyncLoadTask.handle)
				{
					asyncLoadTask.OnObjectLoaded(gameObject);
					return;
				}
				i++;
			}
			CGameObjectPool.RecycleGameObjectEx(gameObject);
		}
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0001F222 File Offset: 0x0001D622
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0001F224 File Offset: 0x0001D624
	public void ClearAllAsyncTasks()
	{
		for (int i = 0; i < this.mAsyncTasks.Count; i++)
		{
			this._abortAsyncTask(this.mAsyncTasks[i]);
		}
		this.mAsyncTasks.Clear();
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0001F26A File Offset: 0x0001D66A
	public void RemoveAsyncLoadGameObjectByHandle(uint handle)
	{
		this._removeAsyncLoadTask(handle);
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0001F273 File Offset: 0x0001D673
	public uint AddAsyncLoadGameObject(string tag, string path, PostLoadGameObject load, uint condition = 4294967295U)
	{
		return this._addAsyncLoadGameObject(tag, path, load, condition);
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0001F280 File Offset: 0x0001D680
	public uint AddAsyncLoadGameObject(string tag, string path, enResourceType restype, bool reserveLast, PostLoadGameObject load, uint condition = 4294967295U)
	{
		return this._addPooledAsyncLoadGameObject(tag, path, restype, reserveLast, load, condition);
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0001F294 File Offset: 0x0001D694
	private uint _addAsyncLoadGameObject(string tag, string path, PostLoadGameObject load, uint condition)
	{
		if (EngineConfig.useTMEngine)
		{
			uint num = AssetLoader.LoadResAsGameObjectAsync(path, this.m_AssetLoadCallbacks, this, 0U, 0U);
			this._addAsyncLoadTask(tag, num, path, condition, load, false);
			return num;
		}
		uint num2 = Singleton<AssetLoader>.instance.LoadResAsyncAsGameObject(path, true, 1U, 0U);
		if (!Singleton<AssetLoader>.instance.IsValidHandle(num2))
		{
			Logger.LogErrorFormat("[AsyncLoadTask] add fail with {0}:{1}", new object[]
			{
				tag,
				path
			});
			return uint.MaxValue;
		}
		this._addAsyncLoadTask(tag, num2, path, condition, load, false);
		return num2;
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0001F314 File Offset: 0x0001D714
	private uint _addPooledAsyncLoadGameObject(string tag, string path, enResourceType restype, bool reserveLast, PostLoadGameObject load, uint condition)
	{
		if (EngineConfig.useTMEngine)
		{
			uint gameObjectAsync = CGameObjectPool.GetGameObjectAsync(path, this.m_AssetLoadCallbacks, this, 0U, 0U);
			this._addAsyncLoadTask(tag, gameObjectAsync, path, condition, load, false);
			return gameObjectAsync;
		}
		uint gameObjectAsync2 = Singleton<CGameObjectPool>.instance.GetGameObjectAsync(path, restype, (!reserveLast) ? 1U : 3U, 841818898U);
		if (!Singleton<CGameObjectPool>.instance.IsValidHandle(gameObjectAsync2))
		{
			Logger.LogErrorFormat("[AsyncLoadTask] add fail with {0}:{1}", new object[]
			{
				tag,
				path
			});
			return uint.MaxValue;
		}
		this._addAsyncLoadTask(tag, gameObjectAsync2, path, condition, load, true);
		return gameObjectAsync2;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0001F3A4 File Offset: 0x0001D7A4
	public void Update(float delta)
	{
		for (int i = 0; i < this.mAsyncTasks.Count; i++)
		{
			switch (this.mAsyncTasks[i].status)
			{
			case eAsyncLoadTaskStatus.onNone:
				this.mAsyncTasks[i].status = eAsyncLoadTaskStatus.onLoading;
				break;
			case eAsyncLoadTaskStatus.onLoading:
				if (this._isRequestDone(this.mAsyncTasks[i]))
				{
					this.mAsyncTasks[i].status = eAsyncLoadTaskStatus.onCondition;
				}
				break;
			case eAsyncLoadTaskStatus.onCondition:
				if (this._isTaskCondition(this.mAsyncTasks[i]))
				{
					this.mAsyncTasks[i].status = eAsyncLoadTaskStatus.onPostCall;
				}
				break;
			case eAsyncLoadTaskStatus.onPostCall:
				this._onPostLoad(this.mAsyncTasks[i]);
				this.mAsyncTasks[i].status = eAsyncLoadTaskStatus.onFinish;
				break;
			}
		}
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0001F49F File Offset: 0x0001D89F
	private bool _removeAllFinishTask(AsyncLoadTask task)
	{
		if (task == null)
		{
			return true;
		}
		if (task.isFinish)
		{
			this._removeAsyncLoadTask(task);
			return true;
		}
		return false;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0001F4C0 File Offset: 0x0001D8C0
	private bool _isTaskCondition(AsyncLoadTask task)
	{
		if (task == null)
		{
			return true;
		}
		if (task.waithandle == 4294967295U)
		{
			return true;
		}
		AsyncLoadTask asyncLoadTask = this._findTask(task.waithandle);
		return asyncLoadTask == null || asyncLoadTask.isFinish;
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0001F500 File Offset: 0x0001D900
	private AsyncLoadTask _findTask(uint handle)
	{
		for (int i = 0; i < this.mAsyncTasks.Count; i++)
		{
			if (this.mAsyncTasks[i].handle == handle)
			{
				return this.mAsyncTasks[i];
			}
		}
		return null;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0001F550 File Offset: 0x0001D950
	private bool _isRequestDone(AsyncLoadTask task)
	{
		if (EngineConfig.useTMEngine)
		{
			return task.IsObjectLoaded();
		}
		if (task == null)
		{
			return false;
		}
		if (task.isPooled)
		{
			return Singleton<CGameObjectPool>.instance.IsRequestDone(task.handle);
		}
		return Singleton<AssetLoader>.instance.IsRequestDone(task.handle);
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0001F5A2 File Offset: 0x0001D9A2
	private void _onPostLoad(AsyncLoadTask task)
	{
		if (task == null)
		{
			return;
		}
		if (task.load != null)
		{
			task.load(this._extraGameObjectByHandle(task));
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0001F5C8 File Offset: 0x0001D9C8
	private GameObject _extraGameObjectByHandle(AsyncLoadTask task)
	{
		if (EngineConfig.useTMEngine)
		{
			return task.ExtractObject();
		}
		if (task == null)
		{
			return null;
		}
		if (task.isPooled)
		{
			return Singleton<CGameObjectPool>.instance.ExtractAsset(task.handle) as GameObject;
		}
		return Singleton<AssetLoader>.instance.Extract(task.handle).obj as GameObject;
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0001F62C File Offset: 0x0001DA2C
	private void _addAsyncLoadTask(string tag, uint handle, string path, uint condition, PostLoadGameObject load, bool isPooled)
	{
		AsyncLoadTask item = new AsyncLoadTask(tag, handle, path, condition, load, isPooled);
		this.mAsyncTasks.Add(item);
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0001F654 File Offset: 0x0001DA54
	private void _removeAsyncLoadTask(AsyncLoadTask task)
	{
		if (task == null)
		{
			return;
		}
		if (EngineConfig.useTMEngine)
		{
			GameObject gameObject = task.ExtractObject();
			if (null != gameObject)
			{
				if (task.isPooled)
				{
					CGameObjectPool.RecycleGameObjectEx(gameObject);
				}
				else
				{
					Object.Destroy(gameObject);
				}
			}
		}
		else
		{
			this._abortAsyncTask(task);
		}
		this.mAsyncTasks.Remove(task);
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x0001F6BC File Offset: 0x0001DABC
	private void _removeAsyncLoadTask(uint handle)
	{
		AsyncLoadTask asyncLoadTask = this._findTask(handle);
		if (asyncLoadTask == null)
		{
			return;
		}
		this._removeAsyncLoadTask(asyncLoadTask);
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0001F6E0 File Offset: 0x0001DAE0
	private void _abortAsyncTask(AsyncLoadTask task)
	{
		if (task == null)
		{
			return;
		}
		if (task.isFinish)
		{
			return;
		}
		if (task.isPooled)
		{
			Singleton<CGameObjectPool>.instance.AbortRequest(task.handle);
		}
		else
		{
			Singleton<AssetLoader>.instance.AbortRequest(task.handle);
		}
	}

	// Token: 0x0400041B RID: 1051
	private List<AsyncLoadTask> mAsyncTasks = new List<AsyncLoadTask>();

	// Token: 0x0400041C RID: 1052
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x0400041D RID: 1053
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x0400041E RID: 1054
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;
}
