using System;
using System.Collections;
using DG.Tweening;
using Network;
using TMEngine.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000FE7 RID: 4071
	public class GameFrameWork : MonoSingleton<GameFrameWork>
	{
		// Token: 0x17001944 RID: 6468
		// (get) Token: 0x06009B5C RID: 39772 RVA: 0x001E132B File Offset: 0x001DF72B
		public static bool IsGameFrameWorkInited
		{
			get
			{
				return GameFrameWork.bInit;
			}
		}

		// Token: 0x06009B5D RID: 39773 RVA: 0x001E1332 File Offset: 0x001DF732
		private void Awake()
		{
			TMEngine.Runtime.Utility.Thread.SetMainThread();
		}

		// Token: 0x06009B5E RID: 39774 RVA: 0x001E1339 File Offset: 0x001DF739
		public void SetMainCamera(bool enable)
		{
			if (null == this._mainCamera)
			{
				Logger.LogError("[Environment] main camera is nil");
				return;
			}
			if (this._mainCamera.enabled != enable)
			{
				this._mainCamera.enabled = enable;
			}
		}

		// Token: 0x06009B5F RID: 39775 RVA: 0x001E1374 File Offset: 0x001DF774
		protected void _InitializeEnvironment()
		{
			if (this._environment == null)
			{
				GameObject gameObject = global::Utility.FindGameObject("Environment", false);
				if (gameObject != null)
				{
					Object.DestroyImmediate(gameObject);
				}
				this._environment = Singleton<AssetLoader>.instance.LoadResAsGameObject("Environment/Environment", true, 0U);
				if (this._environment == null)
				{
					Logger.LogErrorFormat("_environment is null!!!!!!!!!!!!", new object[0]);
				}
				this._environment.name = "Environment";
				this._environment.transform.SetAsFirstSibling();
				this._mainCamera = global::Utility.FindComponent<Camera>(this._environment, "FollowPlayer/Main Camera", true);
				if (this._mainCamera != null)
				{
					CameraAspectAdjust component = this._mainCamera.GetComponent<CameraAspectAdjust>();
					if (component != null)
					{
						component.enabled = true;
					}
				}
				Object.DontDestroyOnLoad(this._environment);
			}
		}

		// Token: 0x06009B60 RID: 39776 RVA: 0x001E145A File Offset: 0x001DF85A
		protected void _gameDataInit()
		{
			global::Utility.IterCoroutineImm(this._gameDataInitCoroutine(null));
		}

		// Token: 0x06009B61 RID: 39777 RVA: 0x001E1468 File Offset: 0x001DF868
		public IEnumerator _gameDataInitCoroutine(UnityAction<int, string> processSet)
		{
			yield return AssetLoader.IsAssetManagerReady();
			if (!this.bBaseModuleInited)
			{
				yield return this.InitBaseModuleCoroutine(processSet);
				this.bBaseModuleInited = true;
			}
			yield return this.InitLogicModuleCoroutine(processSet);
			yield break;
		}

		// Token: 0x06009B62 RID: 39778 RVA: 0x001E148C File Offset: 0x001DF88C
		public IEnumerator InitBaseModuleCoroutine(UnityAction<int, string> processSet)
		{
			if (processSet != null)
			{
				processSet.Invoke(1, string.Empty);
			}
			yield return Yielders.EndOfFrame;
			Logger.Init();
			PlayerLocalSetting.LoadConfig();
			Singleton<ClientReconnectManager>.instance.Clear();
			if (processSet != null)
			{
				processSet.Invoke(10, null);
			}
			yield return Yielders.EndOfFrame;
			Singleton<PluginManager>.CreateInstance(true);
			Singleton<ExceptionManager>.CreateInstance(true);
			DOTween.Init(new bool?(true), null, null);
			if (processSet != null)
			{
				processSet.Invoke(20, null);
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x06009B63 RID: 39779 RVA: 0x001E14A8 File Offset: 0x001DF8A8
		public IEnumerator InitLogicModuleCoroutine(UnityAction<int, string> processSet)
		{
			if (processSet != null)
			{
				processSet.Invoke(21, string.Empty);
			}
			yield return Yielders.EndOfFrame;
			if (EngineConfig.asyncPackageLoad)
			{
				MonoSingleton<AssetAsyncLoader>.instance.ClearWaitingQueue();
				if (MonoSingleton<AssetAsyncLoader>.instance.IsAsyncInLoading)
				{
					yield return Yielders.EndOfFrame;
				}
				MonoSingleton<AssetAsyncLoader>.instance.ClearFinishQueue();
			}
			Singleton<AssetPackageManager>.instance.AddPackageDependency();
			Singleton<AssetGabageCollectorHelper>.instance.LoadGCConfig();
			this._InitializeEnvironment();
			TR.Initialize(TR.EType.CN);
			Singleton<TableManager>.CreateInstance(false);
			yield return Singleton<TableManager>.GetInstance()._InitCoroutine(processSet);
			Singleton<PlayerDataManager>.GetInstance().OnApplicationStart();
			Singleton<GePhaseEffect>.instance.Init();
			DataManager<MissionManager>.GetInstance().AddSystemInvoke();
			DataManager<TAPDataManager>.GetInstance().AddSystemInvoke();
			if (processSet != null)
			{
				processSet.Invoke(80, null);
			}
			yield return Yielders.EndOfFrame;
			Singleton<NewbieGuideManager>.instance.Load();
			LoadingResourceManager.InitLoadingResource();
			SettingFrame.LoadDoublePressConfig();
			if (processSet != null)
			{
				processSet.Invoke(100, null);
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x06009B64 RID: 39780 RVA: 0x001E14CC File Offset: 0x001DF8CC
		public void DeinitLogicModule()
		{
			LoadingResourceManager.DeinitLoadingResource();
			Singleton<AssetPackageManager>.instance.UnInit();
			Singleton<NewbieGuideManager>.instance.Unload();
			DataManager<MissionManager>.GetInstance().RemoveSystemInvoke();
			DataManager<TAPDataManager>.GetInstance().RemoveSystemInvoke();
			Singleton<PlayerDataManager>.instance.OnApplicationQuit();
			if (TableManager.bNeedUninit)
			{
				Singleton<TableManager>.instance.UnInit();
			}
		}

		// Token: 0x06009B65 RID: 39781 RVA: 0x001E1524 File Offset: 0x001DF924
		private void InitGlobalSetting()
		{
			if (Global.Settings.isBanShuVersion)
			{
				Global.Settings.isGuide = false;
			}
		}

		// Token: 0x06009B66 RID: 39782 RVA: 0x001E1540 File Offset: 0x001DF940
		private new void Init()
		{
			this.InitGlobalSetting();
			NetManager.Instance();
			Singleton<ClientSystemManager>.Initialize();
			Singleton<FrameManager>.Initialize();
			Application.targetFrameRate = 30;
			if (!Singleton<DebugSettings>.GetInstance().DisableBugly)
			{
				Singleton<ExceptionManager>.CreateInstance(true);
			}
			iOSConfigureLibGC.ConfigureLibGC(16);
			PluginManager.KeepScreenOn();
		}

		// Token: 0x06009B67 RID: 39783 RVA: 0x001E1580 File Offset: 0x001DF980
		protected override void OnApplicationQuit()
		{
			Singleton<PlayerDataManager>.GetInstance().OnApplicationQuit();
			base.OnApplicationQuit();
		}

		// Token: 0x06009B68 RID: 39784 RVA: 0x001E1594 File Offset: 0x001DF994
		public IEnumerator _FadingFrame(UnityAction preAction, UnityAction postAction, UnityBoolAction waitForAction, float fadeIn, float fadeOut)
		{
			FadingFrame frame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<FadingFrame>(FrameLayer.Top, null, string.Empty) as FadingFrame;
			frame.FadingIn(fadeIn);
			while (!frame.IsOpened())
			{
				yield return Yielders.EndOfFrame;
			}
			yield return Yielders.EndOfFrame;
			if (preAction != null)
			{
				preAction.Invoke();
			}
			yield return Yielders.EndOfFrame;
			if (waitForAction != null)
			{
				while (waitForAction())
				{
					yield return Yielders.EndOfFrame;
				}
			}
			frame.FadingOut(fadeOut);
			yield return Yielders.EndOfFrame;
			while (!frame.IsClosed())
			{
				yield return Yielders.EndOfFrame;
			}
			if (postAction != null)
			{
				postAction.Invoke();
			}
			yield break;
		}

		// Token: 0x06009B69 RID: 39785 RVA: 0x001E15CD File Offset: 0x001DF9CD
		public Coroutine OpenFadeFrame(UnityAction preAction, UnityAction postAction, UnityBoolAction waitForAction = null, float fadeIn = 0.4f, float fadeOut = 0.6f)
		{
			return base.StartCoroutine(this._FadingFrame(preAction, postAction, waitForAction, fadeIn, fadeOut));
		}

		// Token: 0x06009B6A RID: 39786 RVA: 0x001E15E4 File Offset: 0x001DF9E4
		public void TownNameShow(string name)
		{
			GameObject gameObject = Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Middle, "UIFlatten/Prefabs/TownUI/TownNameShow", 0f);
			if (gameObject)
			{
				HGTownShow component = gameObject.GetComponent<HGTownShow>();
				if (component && component.control)
				{
					component.control.text = name;
				}
			}
		}

		// Token: 0x06009B6B RID: 39787 RVA: 0x001E1640 File Offset: 0x001DFA40
		private void Start()
		{
			Input.multiTouchEnabled = true;
			this.SwithTouchInput(false);
			Object.DontDestroyOnLoad(base.gameObject);
			GameObject gameObject = GameObject.Find("TMEngine");
			if (null == gameObject)
			{
				gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>("Base/TMEngine"));
				gameObject.name = "TMEngine";
			}
			ComponentFPS instance = MonoSingleton<ComponentFPS>.instance;
		}

		// Token: 0x06009B6C RID: 39788 RVA: 0x001E16A0 File Offset: 0x001DFAA0
		private void Update()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup - GameFrameWork.lastShowTime >= 1f)
			{
				GameFrameWork.lastShowTime = realtimeSinceStartup;
			}
			if (!GameFrameWork.bInit)
			{
				this.Init();
				switch (Global.Settings.startSystem)
				{
				case EClientSystem.Login:
					Singleton<ClientSystemManager>.instance.InitSystem<ClientSystemVersion>(new object[0]);
					break;
				case EClientSystem.Town:
					this._gameDataInit();
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
					break;
				case EClientSystem.Battle:
					this._gameDataInit();
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemBattle>(null, null, false);
					break;
				default:
					Logger.LogError("请检查GlobalSetting设置，需要选择一个模式进入！");
					break;
				}
				GameFrameWork.bInit = true;
			}
			float deltaTime = Time.deltaTime;
			Singleton<ClientSystemManager>.instance.Update(deltaTime);
		}

		// Token: 0x06009B6D RID: 39789 RVA: 0x001E1767 File Offset: 0x001DFB67
		private void LateUpdate()
		{
			if (this.onLastUpdate != null)
			{
				this.onLastUpdate.Invoke();
			}
		}

		// Token: 0x06009B6E RID: 39790 RVA: 0x001E177F File Offset: 0x001DFB7F
		public void SwithTouchInput(bool flag = true)
		{
		}

		// Token: 0x040054F9 RID: 21753
		public GameFrameWork.OnGameFrameWorkLastUpdate onLastUpdate = new GameFrameWork.OnGameFrameWorkLastUpdate();

		// Token: 0x040054FA RID: 21754
		private static bool bInit;

		// Token: 0x040054FB RID: 21755
		private bool bBaseModuleInited;

		// Token: 0x040054FC RID: 21756
		protected GameObject _environment;

		// Token: 0x040054FD RID: 21757
		protected Camera _mainCamera;

		// Token: 0x040054FE RID: 21758
		private static long lastTime;

		// Token: 0x040054FF RID: 21759
		private static float lastShowTime;

		// Token: 0x02000FE8 RID: 4072
		public class OnGameFrameWorkLastUpdate : UnityEvent
		{
		}
	}
}
