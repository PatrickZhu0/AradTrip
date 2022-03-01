using System;
using System.Collections;
using AdsPush;
using Client;

namespace GameClient
{
	// Token: 0x02000211 RID: 529
	internal class ClientSystemVersion : ClientSystem
	{
		// Token: 0x060011B3 RID: 4531 RVA: 0x0005E323 File Offset: 0x0005C723
		private void Start()
		{
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0005E325 File Offset: 0x0005C725
		private void Update()
		{
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x0005E327 File Offset: 0x0005C727
		public sealed override string GetMainUIPrefabName()
		{
			return "Base/Version/VersionFrame/ClientSystemVersionMainUI";
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0005E32E File Offset: 0x0005C72E
		protected sealed override string _GetLevelName()
		{
			return "Start";
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0005E335 File Offset: 0x0005C735
		protected void InitHotFix()
		{
			Singleton<VersionManager>.instance.m_ProceedHotUpdate = true;
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x0005E344 File Offset: 0x0005C744
		protected IEnumerator _CheckUpdate()
		{
			if (AppPackageFetcher.NeedFetchAppPackage() && AppPackageFetcher.InitNativePackageVersion())
			{
				yield return AppPackageFetcher.FetchFullAppPackage();
				if (AppPackageFetcher.IsVersionValid() && AppPackageFetcher.IsRemoteNewer())
				{
					bool block = true;
					SystemNotifyManager.BaseMsgBoxOkCancel(ClientConfig.AppPackageMessageAppVersionLow, delegate
					{
						block = false;
					}, delegate
					{
						AppPackageFetcher.OpenAppPackageURL();
						block = false;
					}, ClientConfig.AppPackageButTextRetryUpdate, ClientConfig.AppPackageButTextOpenURL);
					while (block)
					{
						yield return Yielders.EndOfFrame;
					}
				}
			}
			AppPackageFetcher.SkipFetchAgain(false);
			SplashLoadingFrame splashFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(SplashLoadingFrame)) as SplashLoadingFrame;
			if (splashFrame != null)
			{
				while (!splashFrame.fadeFinish)
				{
					yield return Yielders.EndOfFrame;
				}
			}
			if (PluginManager.isFirstStartGame)
			{
				if (this.CheckIsShowSplash())
				{
					StartSplashFrame startSplashFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<StartSplashFrame>(FrameLayer.Bottom, null, string.Empty) as StartSplashFrame;
					if (startSplashFrame != null)
					{
						while (!startSplashFrame.IsSplashDone)
						{
							yield return Yielders.EndOfFrame;
						}
					}
				}
				PluginManager.isFirstStartGame = false;
			}
			VersionUpdateFrame versionFrame = null;
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VersionUpdateFrame>(null))
			{
				versionFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<VersionUpdateFrame>(FrameLayer.Bottom, null, string.Empty) as VersionUpdateFrame);
				string state = "正在初始化..";
				versionFrame.UpdateProgressState(state);
			}
			if (Global.Settings.enableHotFix)
			{
				MonoSingleton<HotUpdateDownloader>.instance.DoDeleteExpirePackage();
				MonoSingleton<HotUpdateDownloader>.instance.CheckHotUpdateVersion();
				while (MonoSingleton<HotUpdateDownloader>.instance.GetVersionCheckRes() == VersionCheckResult.None)
				{
					yield return Yielders.EndOfFrame;
				}
				if (MonoSingleton<HotUpdateDownloader>.instance.GetVersionCheckRes() == VersionCheckResult.NeedHotUpdate)
				{
					this.mState = ClientSystemVersion.VersionCheckState.HOT_FIX;
					string info = "正在链接版本服务器..";
					versionFrame.UpdateProgressState(info);
					MonoSingleton<HotUpdateDownloader>.instance.DoHotUpdate(versionFrame);
					while (MonoSingleton<HotUpdateDownloader>.instance.updateState != VersionUpdateState.FinishUpdate)
					{
						yield return Yielders.EndOfFrame;
					}
					MonoSingleton<GameFrameWork>.instance.DeinitLogicModule();
				}
			}
			if (Global.BuglyEnable)
			{
				PluginManager.InitBugly();
			}
			versionFrame.ResetProgress("初始化...");
			this.mState = ClientSystemVersion.VersionCheckState.INIT_STATE;
			yield return MonoSingleton<GameFrameWork>.instance._gameDataInitCoroutine(delegate(int process, string text)
			{
				versionFrame.UpdateProgress(process, text);
			});
			this.mState = ClientSystemVersion.VersionCheckState.DONE;
			if (PluginManager.CheckDeviceMemory())
			{
				yield break;
			}
			Singleton<LoginPushManager>.GetInstance().Init();
			Singleton<ServerAddressManager>.GetInstance().GetServerList(false);
			MonoSingleton<SDKCallback>.instance.StartScreenSave();
			Singleton<PluginManager>.GetInstance().InititalSDK();
			Singleton<PluginManager>.GetInstance().InitNotifications();
			Singleton<FrameConfigManager>.instance.LoadFrameConfig();
			Singleton<SystemConfig>.instance.LoadConfig();
			Singleton<ActivityDungeonPersistentDataManager>.instance.LoadData();
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemLogin>(null, null, false);
			yield break;
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x0005E35F File Offset: 0x0005C75F
		public sealed override void OnEnter()
		{
			base.OnEnter();
			if (Global.Settings.enableHotFix)
			{
				this.InitHotFix();
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._CheckUpdate());
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0005E38D File Offset: 0x0005C78D
		public sealed override void OnExit()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<VersionUpdateFrame>(null, false);
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0005E39B File Offset: 0x0005C79B
		protected sealed override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0005E3A0 File Offset: 0x0005C7A0
		private bool CheckIsShowSplash()
		{
			bool result = true;
			if (Global.Settings.sdkChannel == SDKChannel.M915 || Global.Settings.sdkChannel == SDKChannel.JUNHAI)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000B9E RID: 2974
		private new ClientSystemVersion.VersionCheckState mState;

		// Token: 0x04000B9F RID: 2975
		private float showVersionInfoSecond = 3f;

		// Token: 0x02000212 RID: 530
		private enum VersionCheckState
		{
			// Token: 0x04000BA1 RID: 2977
			NONE,
			// Token: 0x04000BA2 RID: 2978
			INIT_STATE,
			// Token: 0x04000BA3 RID: 2979
			HOT_FIX,
			// Token: 0x04000BA4 RID: 2980
			DONE
		}
	}
}
