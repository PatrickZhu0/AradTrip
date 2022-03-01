using System;
using System.Collections;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DC0 RID: 3520
	public class ClientSystem : GameBindSystem, IClientSystem, IGameBind
	{
		// Token: 0x06008E74 RID: 36468 RVA: 0x0005DD10 File Offset: 0x0005C110
		public ClientSystem.eClientSystemState GetState()
		{
			return this.state;
		}

		// Token: 0x06008E75 RID: 36469 RVA: 0x0005DD18 File Offset: 0x0005C118
		public void BeforeEnter()
		{
			this._clearState();
			this.state = ClientSystem.eClientSystemState.onInit;
			this.OnBeforeEnter();
		}

		// Token: 0x06008E76 RID: 36470 RVA: 0x0005DD2D File Offset: 0x0005C12D
		public void OnSystemError()
		{
			this.state = ClientSystem.eClientSystemState.onError;
		}

		// Token: 0x06008E77 RID: 36471 RVA: 0x0005DD36 File Offset: 0x0005C136
		private void _clearState()
		{
			this.mLastState = ClientSystem.eClientSystemState.onNone;
			this.mState = ClientSystem.eClientSystemState.onNone;
		}

		// Token: 0x170018D1 RID: 6353
		// (get) Token: 0x06008E78 RID: 36472 RVA: 0x0005DD46 File Offset: 0x0005C146
		public ClientSystem.eClientSystemState lastState
		{
			get
			{
				return this.mLastState;
			}
		}

		// Token: 0x170018D2 RID: 6354
		// (get) Token: 0x06008E79 RID: 36473 RVA: 0x0005DD4E File Offset: 0x0005C14E
		// (set) Token: 0x06008E7A RID: 36474 RVA: 0x0005DD56 File Offset: 0x0005C156
		public ClientSystem.eClientSystemState state
		{
			get
			{
				return this.mState;
			}
			private set
			{
				this.mLastState = this.mState;
				this.mState = value;
			}
		}

		// Token: 0x06008E7B RID: 36475 RVA: 0x0005DD6B File Offset: 0x0005C16B
		public void SetName(string name)
		{
			this.systemName = name;
		}

		// Token: 0x06008E7C RID: 36476 RVA: 0x0005DD74 File Offset: 0x0005C174
		public string GetName()
		{
			return this.systemName;
		}

		// Token: 0x170018D3 RID: 6355
		// (get) Token: 0x06008E7E RID: 36478 RVA: 0x0005DD85 File Offset: 0x0005C185
		// (set) Token: 0x06008E7D RID: 36477 RVA: 0x0005DD7C File Offset: 0x0005C17C
		public ClientSystemManager SystemManager { get; set; }

		// Token: 0x06008E7F RID: 36479 RVA: 0x0005DD8D File Offset: 0x0005C18D
		public T GetComponent<T>(string name) where T : Component
		{
			return base.GetComponentByName<T>(name);
		}

		// Token: 0x06008E80 RID: 36480 RVA: 0x0005DD96 File Offset: 0x0005C196
		public T GetComponentInChildren<T>(string name) where T : Component
		{
			return base.GetComponentInChilderByName<T>(name);
		}

		// Token: 0x06008E81 RID: 36481 RVA: 0x0005DD9F File Offset: 0x0005C19F
		public static bool IsTargetSystem<T>() where T : ClientSystem, new()
		{
			return (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is T && Singleton<ClientSystemManager>.GetInstance().TargetSystem == null) || Singleton<ClientSystemManager>.GetInstance().TargetSystem is T;
		}

		// Token: 0x06008E82 RID: 36482 RVA: 0x0005DDDC File Offset: 0x0005C1DC
		public static bool IsCurrentSystemStart()
		{
			if (Singleton<ClientSystemManager>.GetInstance().TargetSystem != null)
			{
				return (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystem).BStart;
			}
			return Singleton<ClientSystemManager>.GetInstance().CurrentSystem != null && (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystem).BStart;
		}

		// Token: 0x06008E83 RID: 36483 RVA: 0x0005DE34 File Offset: 0x0005C234
		public static T GetTargetSystem<T>() where T : ClientSystem, new()
		{
			T t = (T)((object)null);
			if (ClientSystem.IsTargetSystem<T>())
			{
				t = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as T);
				if (t == null)
				{
					t = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as T);
				}
			}
			return t;
		}

		// Token: 0x06008E84 RID: 36484 RVA: 0x0005DE88 File Offset: 0x0005C288
		public virtual void GetExitCoroutine(AddCoroutine exit)
		{
			exit(new loadingCoroutine(this._baseSystemExitCoroutine), string.Empty, 1f);
		}

		// Token: 0x06008E85 RID: 36485 RVA: 0x0005DEA7 File Offset: 0x0005C2A7
		public virtual void GetEnterCoroutine(AddCoroutine enter)
		{
			enter(new loadingCoroutine(this._baseSystemLoadingCoroutine), string.Empty, 1f);
		}

		// Token: 0x06008E86 RID: 36486 RVA: 0x0005DEC6 File Offset: 0x0005C2C6
		public void OnEnterSystem()
		{
			if (this.state != ClientSystem.eClientSystemState.onError)
			{
				this.state = ClientSystem.eClientSystemState.onTick;
			}
			InvokeMethod.Enter();
			Singleton<PlayerDataManager>.GetInstance().OnEnterSystem();
			this.OnEnter();
		}

		// Token: 0x06008E87 RID: 36487 RVA: 0x0005DEF0 File Offset: 0x0005C2F0
		public virtual void OnBeforeEnter()
		{
		}

		// Token: 0x06008E88 RID: 36488 RVA: 0x0005DEF2 File Offset: 0x0005C2F2
		public virtual void OnEnter()
		{
		}

		// Token: 0x06008E89 RID: 36489 RVA: 0x0005DEF4 File Offset: 0x0005C2F4
		public void OnExitSystem()
		{
			this.state = ClientSystem.eClientSystemState.onEnd;
			this.OnExit();
			this.BStart = false;
			InvokeMethod.Exit();
			Singleton<PlayerDataManager>.GetInstance().OnExitSystem();
			base.ExistBindSystem();
			this.DestoryMainUI();
			UIEventSystem.GetInstance().PopupLeakedEvents();
			this._clearState();
		}

		// Token: 0x06008E8A RID: 36490 RVA: 0x0005DF40 File Offset: 0x0005C340
		public virtual void OnExit()
		{
		}

		// Token: 0x170018D4 RID: 6356
		// (get) Token: 0x06008E8B RID: 36491 RVA: 0x0005DF42 File Offset: 0x0005C342
		// (set) Token: 0x06008E8C RID: 36492 RVA: 0x0005DF4A File Offset: 0x0005C34A
		public bool BStart
		{
			get
			{
				return this.bStart;
			}
			set
			{
				this.bStart = value;
			}
		}

		// Token: 0x06008E8D RID: 36493 RVA: 0x0005DF53 File Offset: 0x0005C353
		public void OnStartSystem(SystemContent systemContent)
		{
			this.BStart = true;
			this.OnStart(systemContent);
		}

		// Token: 0x06008E8E RID: 36494 RVA: 0x0005DF63 File Offset: 0x0005C363
		public virtual void OnStart(SystemContent systemContent)
		{
		}

		// Token: 0x06008E8F RID: 36495 RVA: 0x0005DF65 File Offset: 0x0005C365
		public void ShowMainFrame(bool isShow)
		{
			if (null != this._mainFrame)
			{
				this._OnMainFrameBeforeSetActive(isShow);
				this._mainFrame.SetActive(isShow);
			}
		}

		// Token: 0x06008E90 RID: 36496 RVA: 0x0005DF8C File Offset: 0x0005C38C
		public void CreateMainUI()
		{
			if (this._mainFrame == null)
			{
				string mainUIPrefabName = this.GetMainUIPrefabName();
				if (!string.IsNullOrEmpty(mainUIPrefabName))
				{
					this._mainFrame = Singleton<AssetLoader>.instance.LoadResAsGameObject(mainUIPrefabName, true, 0U);
					if (this._mainFrame != null)
					{
						this.mBind = this._mainFrame.GetComponent<ComCommonBind>();
						this._mainFrame.transform.SetParent(Singleton<ClientSystemManager>.instance.BottomLayer.transform, false);
						this._bindExUI();
						this._OnMainFrameOpen();
					}
					else
					{
						Logger.LogErrorFormat("[ClientSystem] {0} 创建主界面失败 {1}", new object[]
						{
							this.GetName(),
							mainUIPrefabName
						});
					}
				}
			}
		}

		// Token: 0x06008E91 RID: 36497 RVA: 0x0005E03F File Offset: 0x0005C43F
		protected virtual void _bindExUI()
		{
		}

		// Token: 0x06008E92 RID: 36498 RVA: 0x0005E041 File Offset: 0x0005C441
		protected virtual void _unbindExUI()
		{
		}

		// Token: 0x06008E93 RID: 36499 RVA: 0x0005E043 File Offset: 0x0005C443
		protected virtual void _OnMainFrameOpen()
		{
		}

		// Token: 0x06008E94 RID: 36500 RVA: 0x0005E045 File Offset: 0x0005C445
		protected virtual void _OnMainFrameClose()
		{
		}

		// Token: 0x06008E95 RID: 36501 RVA: 0x0005E047 File Offset: 0x0005C447
		protected virtual void _OnDoTweenEnd()
		{
			this._mainFrame.gameObject.SetActive(false);
		}

		// Token: 0x06008E96 RID: 36502 RVA: 0x0005E05A File Offset: 0x0005C45A
		public virtual string GetMainUIPrefabName()
		{
			return string.Empty;
		}

		// Token: 0x06008E97 RID: 36503 RVA: 0x0005E061 File Offset: 0x0005C461
		public void DestoryMainUI()
		{
			if (this._mainFrame != null)
			{
				this._unbindExUI();
				this._OnMainFrameClose();
				Object.Destroy(this._mainFrame);
				this._mainFrame = null;
			}
		}

		// Token: 0x06008E98 RID: 36504 RVA: 0x0005E092 File Offset: 0x0005C492
		protected virtual void _OnMainFrameBeforeSetActive(bool active)
		{
		}

		// Token: 0x06008E99 RID: 36505 RVA: 0x0005E094 File Offset: 0x0005C494
		public bool IsSystem<T>() where T : IClientSystem
		{
			return this is T;
		}

		// Token: 0x06008E9A RID: 36506 RVA: 0x0005E0A0 File Offset: 0x0005C4A0
		public IEnumerator _baseSystemExitCoroutine(IASyncOperation systemOperation)
		{
			this.state = ClientSystem.eClientSystemState.onExit;
			yield break;
		}

		// Token: 0x06008E9B RID: 36507 RVA: 0x0005E0BC File Offset: 0x0005C4BC
		public IEnumerator _baseSystemLoadingCoroutine(IASyncOperation systemOperation)
		{
			this.state = ClientSystem.eClientSystemState.onEnter;
			string levelName = this._GetLevelName();
			if (!string.IsNullOrEmpty(levelName) && Application.loadedLevelName != levelName)
			{
				AsyncOperation empty = Application.LoadLevelAsync("GCEmpty");
				while (!empty.isDone)
				{
					yield return Yielders.EndOfFrame;
				}
				MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
				AsyncOperation operation = Application.LoadLevelAsync(levelName);
				while (!operation.isDone)
				{
					systemOperation.SetProgress(operation.progress * 0.3f);
					yield return Yielders.EndOfFrame;
				}
			}
			MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
			this.CreateMainUI();
			base.InitBindSystem(this._mainFrame);
			systemOperation.SetProgress(0.5f);
			yield return Yielders.EndOfFrame;
			Singleton<CGameObjectPool>.instance.RebuildRoot();
			yield break;
		}

		// Token: 0x06008E9C RID: 36508 RVA: 0x0005E0DE File Offset: 0x0005C4DE
		public void Update(float timeElapsed)
		{
			if (this.state == ClientSystem.eClientSystemState.onTick)
			{
				this._OnUpdate(timeElapsed);
				InvokeMethod.Update();
			}
		}

		// Token: 0x06008E9D RID: 36509 RVA: 0x0005E0F8 File Offset: 0x0005C4F8
		protected virtual string _GetLevelName()
		{
			return string.Empty;
		}

		// Token: 0x06008E9E RID: 36510 RVA: 0x0005E0FF File Offset: 0x0005C4FF
		protected virtual void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x040046A5 RID: 18085
		protected ClientSystem.eClientSystemState mState;

		// Token: 0x040046A6 RID: 18086
		protected ClientSystem.eClientSystemState mLastState;

		// Token: 0x040046A8 RID: 18088
		private bool bStart;

		// Token: 0x040046A9 RID: 18089
		protected string systemName;

		// Token: 0x040046AA RID: 18090
		protected GameObject _mainFrame;

		// Token: 0x040046AB RID: 18091
		protected ComCommonBind mBind;

		// Token: 0x02000DC1 RID: 3521
		public enum eClientSystemState
		{
			// Token: 0x040046AD RID: 18093
			onNone,
			// Token: 0x040046AE RID: 18094
			onInit,
			// Token: 0x040046AF RID: 18095
			onEnter,
			// Token: 0x040046B0 RID: 18096
			onTick,
			// Token: 0x040046B1 RID: 18097
			onExit,
			// Token: 0x040046B2 RID: 18098
			onEnd,
			// Token: 0x040046B3 RID: 18099
			onError
		}
	}
}
