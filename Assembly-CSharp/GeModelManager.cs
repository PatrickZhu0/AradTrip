using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x02000D20 RID: 3360
public class GeModelManager
{
	// Token: 0x0600897B RID: 35195 RVA: 0x0018CCA4 File Offset: 0x0018B0A4
	public GeModelManager(GeActorEx actor, int resIDOrigin, GameObject objOrigi)
	{
		if (GeModelManager.<>f__mg$cache0 == null)
		{
			GeModelManager.<>f__mg$cache0 = new OnAssetLoadSuccess(GeModelManager._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeModelManager.<>f__mg$cache0;
		if (GeModelManager.<>f__mg$cache1 == null)
		{
			GeModelManager.<>f__mg$cache1 = new OnAssetLoadFailure(GeModelManager._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeModelManager.<>f__mg$cache1);
		base..ctor();
		if (actor == null)
		{
			return;
		}
		this.m_Actor = actor;
		this.m_OriginModelInfo.resID = resIDOrigin;
		this.m_OriginModelInfo.go = objOrigi;
		this.Start();
	}

	// Token: 0x0600897C RID: 35196 RVA: 0x0018CD49 File Offset: 0x0018B149
	private void Start()
	{
		this.m_IsStarted = true;
	}

	// Token: 0x0600897D RID: 35197 RVA: 0x0018CD54 File Offset: 0x0018B154
	public bool PreChangeModel(int resID, bool changeWhenLoadOk = false, bool needRebindAttach = false)
	{
		GeModelManager.modelInfo modelLoaded = this.GetModelLoaded(resID);
		if (modelLoaded != null)
		{
			return false;
		}
		GeModelManager.LoadTask inTaskList = this.GetInTaskList(resID);
		if (inTaskList != null)
		{
			return false;
		}
		this.SetInTask(resID, changeWhenLoadOk, needRebindAttach);
		return true;
	}

	// Token: 0x0600897E RID: 35198 RVA: 0x0018CD8C File Offset: 0x0018B18C
	public void TryChangeModel(int resID, bool needRebindAttach = false)
	{
		GeModelManager.modelInfo modelLoaded = this.GetModelLoaded(resID);
		if (modelLoaded != null)
		{
			this.m_Actor.ChangeModel(modelLoaded.go, false);
			return;
		}
		GeModelManager.LoadTask inTaskList = this.GetInTaskList(resID);
		if (inTaskList != null)
		{
			inTaskList.changeWhenLoadOk = true;
			return;
		}
		this.SetInTask(resID, true, needRebindAttach);
	}

	// Token: 0x0600897F RID: 35199 RVA: 0x0018CDDC File Offset: 0x0018B1DC
	private GeModelManager.modelInfo GetModelLoaded(int resID)
	{
		int count = this.m_ExtraModelInfoList.Count;
		if (count < 1)
		{
			return null;
		}
		for (int i = 0; i < count; i++)
		{
			GeModelManager.modelInfo modelInfo = this.m_ExtraModelInfoList[i];
			if (modelInfo.resID == resID)
			{
				return modelInfo;
			}
		}
		return null;
	}

	// Token: 0x06008980 RID: 35200 RVA: 0x0018CE30 File Offset: 0x0018B230
	private GeModelManager.LoadTask GetInTaskList(int resID)
	{
		int count = this.m_TaskList.Count;
		for (int i = 0; i < count; i++)
		{
			GeModelManager.LoadTask loadTask = this.m_TaskList[i];
			if (loadTask.resID == resID)
			{
				return loadTask;
			}
		}
		return null;
	}

	// Token: 0x06008981 RID: 35201 RVA: 0x0018CE7C File Offset: 0x0018B27C
	private void SetInTask(int resID, bool changeWhenLoadOk = false, bool needRebindAttach = false)
	{
		GeModelManager.LoadTask item = new GeModelManager.LoadTask(resID, null, changeWhenLoadOk, needRebindAttach);
		this.m_TaskList.Add(item);
	}

	// Token: 0x06008982 RID: 35202 RVA: 0x0018CEA0 File Offset: 0x0018B2A0
	public void Update()
	{
		if (!this.m_IsStarted)
		{
			return;
		}
		int count = this.m_TaskList.Count;
		if (count < 1)
		{
			return;
		}
		GeModelManager.LoadTask loadTask = this.m_TaskList[0];
		GeModelManager.LoadState state = loadTask.state;
		int resID = loadTask.resID;
		string modelPath = loadTask.modelPath;
		switch (state)
		{
		case GeModelManager.LoadState.None:
			if (modelPath == null)
			{
				loadTask.state = GeModelManager.LoadState.Done;
			}
			else
			{
				if (EngineConfig.useTMEngine)
				{
					loadTask.asyncRequest = CGameObjectPool.GetGameObjectAsync(modelPath, this.m_AssetLoadCallbacks, this, 0U, 2900291122U);
				}
				else
				{
					loadTask.asyncRequest = Singleton<CGameObjectPool>.instance.GetGameObjectAsync(modelPath, enResourceType.BattleScene, 0U, 2900291122U);
				}
				loadTask.state = GeModelManager.LoadState.Ing;
			}
			break;
		case GeModelManager.LoadState.Ing:
			if (EngineConfig.useTMEngine)
			{
				if (null != loadTask.m_LoadGameObject)
				{
					loadTask.state = GeModelManager.LoadState.Done;
					GameObject loadGameObject = loadTask.m_LoadGameObject;
					loadTask.m_LoadGameObject = null;
					if (loadGameObject != null)
					{
						GeModelManager.modelInfo modelInfo = new GeModelManager.modelInfo();
						modelInfo.resID = resID;
						modelInfo.go = loadGameObject;
						loadGameObject.SetActive(false);
						if (loadTask.changeWhenLoadOk)
						{
							this.m_Actor.ChangeModel(loadGameObject, loadTask.rebindAttach);
						}
					}
				}
			}
			else
			{
				uint asyncRequest = loadTask.asyncRequest;
				if (asyncRequest != 4294967295U)
				{
					if (Singleton<CGameObjectPool>.instance.IsRequestDone(asyncRequest))
					{
						loadTask.state = GeModelManager.LoadState.Done;
						GameObject gameObject = Singleton<CGameObjectPool>.instance.ExtractAsset(asyncRequest) as GameObject;
						if (gameObject != null)
						{
							GeModelManager.modelInfo modelInfo2 = new GeModelManager.modelInfo();
							modelInfo2.resID = resID;
							modelInfo2.go = gameObject;
							gameObject.SetActive(false);
							if (loadTask.changeWhenLoadOk)
							{
								this.m_Actor.ChangeModel(gameObject, loadTask.rebindAttach);
							}
						}
					}
				}
				else
				{
					loadTask.state = GeModelManager.LoadState.Done;
				}
			}
			break;
		case GeModelManager.LoadState.Done:
			this.m_TaskList.RemoveAt(0);
			break;
		}
	}

	// Token: 0x06008983 RID: 35203 RVA: 0x0018D098 File Offset: 0x0018B498
	public void RmoveModel(GameObject go)
	{
	}

	// Token: 0x06008984 RID: 35204 RVA: 0x0018D09C File Offset: 0x0018B49C
	public void Clear()
	{
		if (!this.m_IsStarted)
		{
			return;
		}
		for (int i = 0; i < this.m_TaskList.Count; i++)
		{
			GeModelManager.LoadTask loadTask = this.m_TaskList[i];
			GeModelManager.LoadState state = loadTask.state;
			if (state == GeModelManager.LoadState.Ing && loadTask.asyncRequest != 4294967295U)
			{
				Singleton<CGameObjectPool>.instance.AbortRequest(loadTask.asyncRequest);
				loadTask.asyncRequest = uint.MaxValue;
			}
			if (loadTask.m_LoadGameObject != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(loadTask.m_LoadGameObject);
				loadTask.m_LoadGameObject = null;
			}
		}
		this.m_TaskList.Clear();
	}

	// Token: 0x06008985 RID: 35205 RVA: 0x0018D144 File Offset: 0x0018B544
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (asset != null)
		{
			GameObject gameObject = asset as GameObject;
			if (null != gameObject)
			{
				if (userData != null)
				{
					GeModelManager geModelManager = userData as GeModelManager;
					if (geModelManager != null)
					{
						int i = 0;
						int count = geModelManager.m_TaskList.Count;
						while (i < count)
						{
							GeModelManager.LoadTask loadTask = geModelManager.m_TaskList[i];
							if (loadTask.asyncRequest == (uint)grpID)
							{
								loadTask.m_LoadGameObject = gameObject;
								loadTask.asyncRequest = uint.MaxValue;
								return;
							}
							i++;
						}
					}
					else
					{
						TMDebug.LogErrorFormat("User data type '{0}' is NOT GeModelManager!", new object[0]);
					}
				}
				else
				{
					TMDebug.LogErrorFormat("User data can not be null!", new object[0]);
				}
				CGameObjectPool.RecycleGameObjectEx(gameObject);
			}
			else
			{
				TMDebug.LogErrorFormat("Asset '{0}' is nil or type '{1}' error!", new object[]
				{
					assetPath,
					asset.GetType()
				});
			}
		}
		else
		{
			TMDebug.LogErrorFormat("Asset '{0}' load error!", new object[]
			{
				assetPath
			});
		}
	}

	// Token: 0x06008986 RID: 35206 RVA: 0x0018D234 File Offset: 0x0018B634
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
		GeModelManager geModelManager = userData as GeModelManager;
		if (geModelManager == null)
		{
			TMDebug.LogErrorFormat("User data type '{0}' is NOT GeModelManager!", new object[0]);
			return;
		}
		if (geModelManager.m_TaskList != null && geModelManager.m_TaskList.Count > 0)
		{
			geModelManager.m_TaskList[0].state = GeModelManager.LoadState.Done;
		}
	}

	// Token: 0x040042E7 RID: 17127
	private bool m_IsStarted;

	// Token: 0x040042E8 RID: 17128
	private GeActorEx m_Actor;

	// Token: 0x040042E9 RID: 17129
	private GeModelManager.modelInfo m_OriginModelInfo = new GeModelManager.modelInfo();

	// Token: 0x040042EA RID: 17130
	private List<GeModelManager.modelInfo> m_ExtraModelInfoList = new List<GeModelManager.modelInfo>();

	// Token: 0x040042EB RID: 17131
	private List<GeModelManager.LoadTask> m_TaskList = new List<GeModelManager.LoadTask>();

	// Token: 0x040042EC RID: 17132
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x040042ED RID: 17133
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x040042EE RID: 17134
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x02000D21 RID: 3361
	public enum LoadState
	{
		// Token: 0x040042F0 RID: 17136
		None,
		// Token: 0x040042F1 RID: 17137
		Ing,
		// Token: 0x040042F2 RID: 17138
		Done
	}

	// Token: 0x02000D22 RID: 3362
	private class LoadTask
	{
		// Token: 0x06008987 RID: 35207 RVA: 0x0018D290 File Offset: 0x0018B690
		public LoadTask(int resIDIn, PostLoadCommand cbIn = null, bool changeWhenLoadOkIn = false, bool needRebindAttach = false)
		{
			this.resID = resIDIn;
			this.cb = cbIn;
			this.state = GeModelManager.LoadState.None;
			this.rebindAttach = needRebindAttach;
			this.changeWhenLoadOk = changeWhenLoadOkIn;
			ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(this.resID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.modelPath = tableItem.ModelPath;
		}

		// Token: 0x040042F3 RID: 17139
		public int resID;

		// Token: 0x040042F4 RID: 17140
		public PostLoadCommand cb;

		// Token: 0x040042F5 RID: 17141
		public GeModelManager.LoadState state;

		// Token: 0x040042F6 RID: 17142
		public uint asyncRequest = uint.MaxValue;

		// Token: 0x040042F7 RID: 17143
		public bool changeWhenLoadOk;

		// Token: 0x040042F8 RID: 17144
		public string modelPath;

		// Token: 0x040042F9 RID: 17145
		public bool rebindAttach;

		// Token: 0x040042FA RID: 17146
		public GameObject m_LoadGameObject;
	}

	// Token: 0x02000D23 RID: 3363
	private class modelInfo
	{
		// Token: 0x040042FB RID: 17147
		public int resID;

		// Token: 0x040042FC RID: 17148
		public GameObject go;
	}
}
