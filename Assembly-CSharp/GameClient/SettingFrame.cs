using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using _Settings;

namespace GameClient
{
	// Token: 0x02001A0F RID: 6671
	public class SettingFrame : ClientFrame
	{
		// Token: 0x06010604 RID: 67076 RVA: 0x0049A433 File Offset: 0x00498833
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SettingPanel/SettingPanel";
		}

		// Token: 0x06010605 RID: 67077 RVA: 0x0049A43C File Offset: 0x0049883C
		protected override void _bindExUI()
		{
			this.tabRoleInfo = this.mBind.GetCom<Toggle>("TabRoleInfo");
			if (this.tabRoleInfo)
			{
				this.tabRoleInfo.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabRoleInfoChanged));
				this.tabRoleInfo.onValueChanged.AddListener(new UnityAction<bool>(this.TabRoleInfoChanged));
			}
			this.mUploadCompress = this.mBind.GetCom<Button>("UploadCompress");
			if (null != this.mUploadCompress)
			{
				this.mUploadCompress.onClick.AddListener(new UnityAction(this._onUploadCompressButtonClick));
			}
			this.tabSysSet = this.mBind.GetCom<Toggle>("TabSysSet");
			if (this.tabSysSet)
			{
				this.tabSysSet.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabSysSetChanged));
				this.tabSysSet.onValueChanged.AddListener(new UnityAction<bool>(this.TabSysSetChanged));
			}
			this.tabBattleCtrl = this.mBind.GetCom<Toggle>("TabBattleCtrl");
			if (this.tabBattleCtrl)
			{
				this.tabBattleCtrl.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabBattleCtrlChanged));
				this.tabBattleCtrl.onValueChanged.AddListener(new UnityAction<bool>(this.TabBattleCtrlChanged));
			}
			this.vipTab = this.mBind.GetCom<Toggle>("VipTab");
			if (this.vipTab)
			{
				this.vipTab.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabVipChanged));
				this.vipTab.onValueChanged.AddListener(new UnityAction<bool>(this.TabVipChanged));
			}
			this.tabPushSet = this.mBind.GetCom<Toggle>("TabPushMsg");
			if (this.tabPushSet)
			{
				this.tabPushSet.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabPushSetChanged));
				this.tabPushSet.onValueChanged.AddListener(new UnityAction<bool>(this.TabPushSetChanged));
			}
			this.tabVoiceChat = this.mBind.GetCom<Toggle>("TabVoiceChat");
			if (this.tabVoiceChat)
			{
				bool bActive = Singleton<PluginManager>.GetInstance().OpenChatVoice || Singleton<PluginManager>.GetInstance().OpenTalkRealVocie;
				this.tabVoiceChat.gameObject.CustomActive(bActive);
				this.tabVoiceChat.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabVoiceChatChanged));
				this.tabVoiceChat.onValueChanged.AddListener(new UnityAction<bool>(this.TabVoiceChatChanged));
			}
			this.tabCDK = this.mBind.GetCom<Toggle>("TabCDK");
			if (this.tabCDK)
			{
				this.tabCDK.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabCDKChanged));
				this.tabCDK.onValueChanged.AddListener(new UnityAction<bool>(this.TabCDKChanged));
			}
			this.tabMobileBind = this.mBind.GetCom<Toggle>("TabBindMobile");
			if (this.tabMobileBind)
			{
				this.tabMobileBind.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabMobileBindChanged));
				this.tabMobileBind.onValueChanged.AddListener(new UnityAction<bool>(this.TabMobileBindChanged));
			}
			this.tabAccountLock = this.mBind.GetCom<Toggle>("TabAccountLock");
			if (this.tabAccountLock)
			{
				this.tabAccountLock.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabAccountLockChanged));
				this.tabAccountLock.onValueChanged.AddListener(new UnityAction<bool>(this.TabAccountLockChanged));
			}
			this.tabDebug = this.mBind.GetCom<Toggle>("TabDebug");
			if (this.tabDebug)
			{
				this.tabDebug.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabDebugChanged));
				this.tabDebug.onValueChanged.AddListener(new UnityAction<bool>(this.TabDebugChanged));
			}
			this.btnRoleChange = this.mBind.GetCom<Button>("btnRoleChange");
			this.btnAccChange = this.mBind.GetCom<Button>("btnAccChange");
			this.goGlobalBtns = this.mBind.GetGameObject("goGlobalBtns");
			if (this.tabDebug != null)
			{
				this.tabDebug.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06010606 RID: 67078 RVA: 0x0049A8CC File Offset: 0x00498CCC
		protected override void _unbindExUI()
		{
			if (this.tabRoleInfo)
			{
				this.tabRoleInfo.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabRoleInfoChanged));
			}
			this.tabRoleInfo = null;
			if (this.tabSysSet)
			{
				this.tabSysSet.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabSysSetChanged));
			}
			this.tabSysSet = null;
			if (this.tabBattleCtrl)
			{
				this.tabBattleCtrl.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabBattleCtrlChanged));
			}
			this.tabBattleCtrl = null;
			if (this.vipTab)
			{
				this.vipTab.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabVipChanged));
			}
			this.vipTab = null;
			if (this.tabPushSet)
			{
				this.tabPushSet.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabPushSetChanged));
			}
			this.tabPushSet = null;
			if (this.tabVoiceChat)
			{
				this.tabVoiceChat.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabVoiceChatChanged));
			}
			this.tabVoiceChat = null;
			if (this.tabCDK)
			{
				this.tabCDK.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabCDKChanged));
			}
			this.tabCDK = null;
			if (this.tabMobileBind)
			{
				this.tabMobileBind.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabMobileBindChanged));
			}
			this.tabMobileBind = null;
			if (this.tabAccountLock)
			{
				this.tabAccountLock.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabAccountLockChanged));
			}
			this.tabAccountLock = null;
			if (this.tabDebug)
			{
				this.tabDebug.onValueChanged.RemoveListener(new UnityAction<bool>(this.TabDebugChanged));
			}
			if (null != this.mUploadCompress)
			{
				this.mUploadCompress.onClick.RemoveListener(new UnityAction(this._onUploadCompressButtonClick));
			}
			this.mUploadCompress = null;
			this.tabDebug = null;
			this.btnRoleChange = null;
			this.btnAccChange = null;
			this.goGlobalBtns = null;
		}

		// Token: 0x06010607 RID: 67079 RVA: 0x0049AB20 File Offset: 0x00498F20
		private void _onUploadCompressButtonClick()
		{
			SystemNotifyManager.BaseMsgBoxOkCancel("是否上传数据", delegate
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<UploadingCompressFrame>(FrameLayer.Middle, null, string.Empty);
			}, null, "确定", "取消");
		}

		// Token: 0x06010608 RID: 67080 RVA: 0x0049AB54 File Offset: 0x00498F54
		private void InitViewSettings()
		{
			this.roleInfoSettings = new RoleInfoSettings(this.frame, this);
			this.systemInfoSettings = new SystemInfoSettings(this.frame, this);
			this.vipSettings = new VipSettings(this.frame, this);
			this.voiceChatSettings = new VoiceChatSettings(this.frame, this);
			this.cdkRewardSettings = new CDKRewardSettings(this.frame, this);
			this.accountLockSettings = new AccountLockSettings(this.frame, this);
			this.InitTabsShow();
		}

		// Token: 0x06010609 RID: 67081 RVA: 0x0049ABD3 File Offset: 0x00498FD3
		private void UpDateViewSettings()
		{
		}

		// Token: 0x0601060A RID: 67082 RVA: 0x0049ABD8 File Offset: 0x00498FD8
		private void UnInitViewSettings()
		{
			if (this.roleInfoSettings != null)
			{
				this.roleInfoSettings.CloseFrame();
			}
			this.roleInfoSettings = null;
			if (this.systemInfoSettings != null)
			{
				this.systemInfoSettings.CloseFrame();
			}
			this.systemInfoSettings = null;
			if (this.vipSettings != null)
			{
				this.vipSettings.CloseFrame();
			}
			this.vipSettings = null;
			if (this.voiceChatSettings != null)
			{
				this.voiceChatSettings.CloseFrame();
			}
			this.voiceChatSettings = null;
			if (this.cdkRewardSettings != null)
			{
				this.cdkRewardSettings.CloseFrame();
			}
			this.cdkRewardSettings = null;
			if (this.accountLockSettings != null)
			{
				this.accountLockSettings.CloseFrame();
			}
			this.accountLockSettings = null;
		}

		// Token: 0x0601060B RID: 67083 RVA: 0x0049AC94 File Offset: 0x00499094
		private void InitTabsShow()
		{
			this.isTabRoleInfoOn = false;
			this.isTabSysSetOn = false;
			this.isTabBattleCtrlOn = false;
			this.isTabVipCtrlOn = false;
			this.isTabPushSetOn = false;
			this.isTabVoiceChatOn = false;
			this.isTabCDKOn = false;
			this.isTabMobileBindOn = false;
			this.isTabDebugOn = false;
			this.isTabVipCtrlOn = false;
			this.isTabAccountLockOn = false;
			Toggle toggle = null;
			SettingsBindUI settingsBindUI = null;
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_SECURITY_LOCK))
			{
				this.tabAccountLock.CustomActive(false);
				if (this.eStartUpTabType == SettingFrame.TabType.ACCOUNT_LOCK)
				{
					this.eStartUpTabType = SettingFrame.TabType.ROLE_INFO;
				}
			}
			switch (this.eStartUpTabType)
			{
			case SettingFrame.TabType.ROLE_INFO:
				this.isTabRoleInfoOn = true;
				toggle = this.tabRoleInfo;
				settingsBindUI = this.roleInfoSettings;
				break;
			case SettingFrame.TabType.SYS_SET:
				this.isTabSysSetOn = true;
				toggle = this.tabSysSet;
				settingsBindUI = this.systemInfoSettings;
				break;
			case SettingFrame.TabType.VIP:
				this.isTabVipCtrlOn = true;
				toggle = this.vipTab;
				settingsBindUI = this.vipSettings;
				break;
			case SettingFrame.TabType.PUSH_SET:
				this.isTabPushSetOn = true;
				toggle = this.tabPushSet;
				settingsBindUI = null;
				break;
			case SettingFrame.TabType.VOICE_CHAT:
				this.isTabVoiceChatOn = true;
				toggle = this.tabVoiceChat;
				settingsBindUI = this.voiceChatSettings;
				break;
			case SettingFrame.TabType.CDK:
				this.isTabCDKOn = true;
				toggle = this.tabCDK;
				settingsBindUI = this.cdkRewardSettings;
				break;
			case SettingFrame.TabType.MOBILE_BIND:
				this.isTabMobileBindOn = true;
				toggle = this.tabMobileBind;
				settingsBindUI = null;
				break;
			case SettingFrame.TabType.DEBUG:
				this.isTabDebugOn = true;
				toggle = this.tabDebug;
				settingsBindUI = null;
				break;
			case SettingFrame.TabType.ACCOUNT_LOCK:
				this.isTabAccountLockOn = true;
				toggle = this.tabAccountLock;
				settingsBindUI = this.accountLockSettings;
				break;
			}
			this.SetSelectedTabActive(this.tabRoleInfo, this.isTabRoleInfoOn);
			this.SetSelectedTabActive(this.tabSysSet, this.isTabSysSetOn);
			this.SetSelectedTabActive(this.tabBattleCtrl, this.isTabBattleCtrlOn);
			this.SetSelectedTabActive(this.tabPushSet, this.isTabPushSetOn);
			this.SetSelectedTabActive(this.tabVoiceChat, this.isTabVoiceChatOn);
			this.SetSelectedTabActive(this.tabCDK, this.isTabCDKOn);
			this.SetSelectedTabActive(this.tabMobileBind, this.isTabMobileBindOn);
			this.SetSelectedTabActive(this.tabDebug, this.isTabDebugOn);
			this.SetSelectedTabActive(this.vipTab, this.isTabVipCtrlOn);
			this.SetSelectedTabActive(this.tabAccountLock, this.isTabAccountLockOn);
			if (toggle != null)
			{
				toggle.isOn = true;
			}
			if (settingsBindUI != null)
			{
				settingsBindUI.ShowOut();
			}
			if (this.goGlobalBtns != null)
			{
				if (this.isTabAccountLockOn)
				{
					this.goGlobalBtns.CustomActive(false);
				}
				else
				{
					this.goGlobalBtns.CustomActive(true);
				}
			}
			this.vipTab.CustomActive(DataManager<PlayerBaseData>.GetInstance().VipLevel > 0 && this.CheckVipData());
		}

		// Token: 0x0601060C RID: 67084 RVA: 0x0049AF68 File Offset: 0x00499368
		protected bool CheckVipData()
		{
			return Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(30, string.Empty, string.Empty).Open || Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(31, string.Empty, string.Empty).Open || Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(32, string.Empty, string.Empty).Open || Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>("STR_VIPPREFER").Open;
		}

		// Token: 0x0601060D RID: 67085 RVA: 0x0049AFF8 File Offset: 0x004993F8
		private void TabRoleInfoChanged(bool isOn)
		{
			if (this.isTabRoleInfoOn == isOn)
			{
				return;
			}
			this.isTabRoleInfoOn = isOn;
			this.SetSelectedTabActive(this.tabRoleInfo, isOn);
			if (this.roleInfoSettings != null)
			{
				if (isOn)
				{
					this.roleInfoSettings.ShowOut();
				}
				else
				{
					this.roleInfoSettings.HideIn();
				}
			}
		}

		// Token: 0x0601060E RID: 67086 RVA: 0x0049B054 File Offset: 0x00499454
		private void TabSysSetChanged(bool isOn)
		{
			if (this.isTabSysSetOn == isOn)
			{
				return;
			}
			this.isTabSysSetOn = isOn;
			this.SetSelectedTabActive(this.tabSysSet, isOn);
			if (this.systemInfoSettings != null)
			{
				if (isOn)
				{
					this.systemInfoSettings.ShowOut();
				}
				else
				{
					this.systemInfoSettings.HideIn();
				}
			}
		}

		// Token: 0x0601060F RID: 67087 RVA: 0x0049B0AE File Offset: 0x004994AE
		private void TabBattleCtrlChanged(bool isOn)
		{
			if (this.isTabBattleCtrlOn == isOn)
			{
				return;
			}
			this.isTabBattleCtrlOn = isOn;
			this.SetSelectedTabActive(this.tabBattleCtrl, isOn);
		}

		// Token: 0x06010610 RID: 67088 RVA: 0x0049B0D4 File Offset: 0x004994D4
		private void TabVipChanged(bool isOn)
		{
			if (this.isTabVipCtrlOn == isOn)
			{
				return;
			}
			this.isTabVipCtrlOn = isOn;
			this.SetSelectedTabActive(this.vipTab, isOn);
			if (this.vipSettings != null)
			{
				if (isOn)
				{
					this.vipSettings.ShowOut();
				}
				else
				{
					this.vipSettings.HideIn();
				}
			}
		}

		// Token: 0x06010611 RID: 67089 RVA: 0x0049B12E File Offset: 0x0049952E
		private void TabPushSetChanged(bool isOn)
		{
			if (this.isTabPushSetOn == isOn)
			{
				return;
			}
			this.isTabPushSetOn = isOn;
			this.SetSelectedTabActive(this.tabPushSet, isOn);
		}

		// Token: 0x06010612 RID: 67090 RVA: 0x0049B154 File Offset: 0x00499554
		private void TabVoiceChatChanged(bool isOn)
		{
			if (this.isTabVoiceChatOn == isOn)
			{
				return;
			}
			this.isTabVoiceChatOn = isOn;
			this.SetSelectedTabActive(this.tabVoiceChat, isOn);
			if (this.voiceChatSettings != null)
			{
				if (isOn)
				{
					this.voiceChatSettings.ShowOut();
				}
				else
				{
					this.voiceChatSettings.HideIn();
				}
			}
		}

		// Token: 0x06010613 RID: 67091 RVA: 0x0049B1B0 File Offset: 0x004995B0
		private void TabCDKChanged(bool isOn)
		{
			if (this.isTabCDKOn == isOn)
			{
				return;
			}
			this.isTabCDKOn = isOn;
			this.SetSelectedTabActive(this.tabCDK, isOn);
			if (this.cdkRewardSettings != null)
			{
				if (isOn)
				{
					this.cdkRewardSettings.ShowOut();
				}
				else
				{
					this.cdkRewardSettings.HideIn();
				}
			}
		}

		// Token: 0x06010614 RID: 67092 RVA: 0x0049B20C File Offset: 0x0049960C
		private void TabAccountLockChanged(bool isOn)
		{
			if (this.isTabAccountLockOn == isOn)
			{
				return;
			}
			this.isTabAccountLockOn = isOn;
			if (isOn)
			{
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("SecurityLock");
			}
			this.SetSelectedTabActive(this.tabAccountLock, isOn);
			if (this.accountLockSettings != null)
			{
				if (isOn)
				{
					this.accountLockSettings.ShowOut();
				}
				else
				{
					this.accountLockSettings.HideIn();
				}
			}
		}

		// Token: 0x06010615 RID: 67093 RVA: 0x0049B27B File Offset: 0x0049967B
		private void TabMobileBindChanged(bool isOn)
		{
			if (this.isTabMobileBindOn == isOn)
			{
				return;
			}
			this.isTabMobileBindOn = isOn;
			this.SetSelectedTabActive(this.tabMobileBind, isOn);
		}

		// Token: 0x06010616 RID: 67094 RVA: 0x0049B29E File Offset: 0x0049969E
		private void TabDebugChanged(bool isOn)
		{
			if (this.isTabDebugOn == isOn)
			{
				return;
			}
			this.isTabDebugOn = isOn;
			this.SetSelectedTabActive(this.tabDebug, isOn);
		}

		// Token: 0x06010617 RID: 67095 RVA: 0x0049B2C4 File Offset: 0x004996C4
		private void SetSelectedTabActive(Toggle selectTab, bool isSelected)
		{
			if (selectTab && selectTab.graphic)
			{
				selectTab.graphic.gameObject.CustomActive(isSelected);
			}
			if (this.goGlobalBtns != null)
			{
				if (this.isTabAccountLockOn)
				{
					this.goGlobalBtns.CustomActive(false);
				}
				else
				{
					this.goGlobalBtns.CustomActive(true);
				}
			}
		}

		// Token: 0x06010618 RID: 67096 RVA: 0x0049B338 File Offset: 0x00499738
		protected override void _OnOpenFrame()
		{
			this.eStartUpTabType = SettingFrame.TabType.ROLE_INFO;
			if (this.userData != null)
			{
				this.eStartUpTabType = (SettingFrame.TabType)this.userData;
			}
			this.InitViewSettings();
			GameObject gameObject = Utility.FindGameObject(this.frame, "Panel/GlobalBtns/RoleChangeBtn", true);
			if (null != gameObject)
			{
			}
			if (null != this.mUploadCompress)
			{
				bool bActive = false;
				this.mUploadCompress.gameObject.CustomActive(bActive);
			}
		}

		// Token: 0x06010619 RID: 67097 RVA: 0x0049B3B0 File Offset: 0x004997B0
		protected override void _OnCloseFrame()
		{
			this.eStartUpTabType = SettingFrame.TabType.ROLE_INFO;
			this.UnInitViewSettings();
		}

		// Token: 0x0601061A RID: 67098 RVA: 0x0049B3BF File Offset: 0x004997BF
		public override bool IsNeedUpdate()
		{
			return this.tabMobileBind && this.tabMobileBind.isOn;
		}

		// Token: 0x0601061B RID: 67099 RVA: 0x0049B3DE File Offset: 0x004997DE
		protected override void _OnUpdate(float timeElapsed)
		{
			this.UpDateViewSettings();
		}

		// Token: 0x0601061C RID: 67100 RVA: 0x0049B3E6 File Offset: 0x004997E6
		public static void LoadDoublePressConfig()
		{
			if (PlayerLocalSetting.GetValue("KEY_DOUBLE") != null)
			{
				Global.Settings.hasDoubleRun = (bool)PlayerLocalSetting.GetValue("KEY_DOUBLE");
			}
		}

		// Token: 0x0601061D RID: 67101 RVA: 0x0049B410 File Offset: 0x00499810
		[UIEventHandle("Panel/BtnClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<SettingFrame>(this, false);
		}

		// Token: 0x0601061E RID: 67102 RVA: 0x0049B420 File Offset: 0x00499820
		[UIEventHandle("Panel/GlobalBtns/TakePhotoMode")]
		private void OnTakeFhotoMode()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			bool flag = false;
			if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL || tableItem.SceneType == CitySceneTable.eSceneType.SINGLE)
			{
				flag = true;
			}
			if (!flag)
			{
				SystemNotifyManager.SystemNotify(10042, string.Empty);
				return;
			}
			this.frameMgr.CloseFrame<SettingFrame>(this, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TakePhotoModeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601061F RID: 67103 RVA: 0x0049B4B8 File Offset: 0x004998B8
		[UIEventHandle("Panel/GlobalBtns/RoleChangeBtn")]
		private void OnChangeRole()
		{
			RoleSwitchReq cmd = new RoleSwitchReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<RoleSwitchReq>(ServerType.GATE_SERVER, cmd);
			ClientSystemLogin.mSwitchRole = true;
			Singleton<SDKVoiceManager>.GetInstance().LeaveVoiceSDK(false);
		}

		// Token: 0x06010620 RID: 67104 RVA: 0x0049B4EC File Offset: 0x004998EC
		[UIEventHandle("Panel/GlobalBtns/AccChangeBtn")]
		private void OnLoginOut()
		{
			GateLeaveGameReq cmd = new GateLeaveGameReq();
			NetManager.Instance().SendCommand<GateLeaveGameReq>(ServerType.GATE_SERVER, cmd);
			NetManager.Instance().Update();
			SDKInterface.instance.UpdateRoleInfo(4, ClientApplication.adminServer.id, ClientApplication.adminServer.name, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(), DataManager<PlayerBaseData>.GetInstance().Name, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)DataManager<PlayerBaseData>.GetInstance().Level, DataManager<PlayerBaseData>.GetInstance().VipLevel, (int)DataManager<PlayerBaseData>.GetInstance().Ticket);
			Singleton<ClientSystemManager>.instance._QuitToLoginImpl();
			SDKInterface.instance.NeedLogoutSDK();
		}

		// Token: 0x0400A62C RID: 42540
		public const string KEY_DOUBLE_PRESS = "KEY_DOUBLE";

		// Token: 0x0400A62D RID: 42541
		public const string KEY_ATTACK_REPLACE = "KEY_ATTACK_REPLACE";

		// Token: 0x0400A62E RID: 42542
		private Toggle tabRoleInfo;

		// Token: 0x0400A62F RID: 42543
		private Toggle tabSysSet;

		// Token: 0x0400A630 RID: 42544
		private Toggle tabBattleCtrl;

		// Token: 0x0400A631 RID: 42545
		private Toggle vipTab;

		// Token: 0x0400A632 RID: 42546
		private Toggle tabPushSet;

		// Token: 0x0400A633 RID: 42547
		private Toggle tabVoiceChat;

		// Token: 0x0400A634 RID: 42548
		private Toggle tabCDK;

		// Token: 0x0400A635 RID: 42549
		private Toggle tabMobileBind;

		// Token: 0x0400A636 RID: 42550
		private Toggle tabDebug;

		// Token: 0x0400A637 RID: 42551
		private Toggle tabAccountLock;

		// Token: 0x0400A638 RID: 42552
		private Button mUploadCompress;

		// Token: 0x0400A639 RID: 42553
		private Button btnRoleChange;

		// Token: 0x0400A63A RID: 42554
		private Button btnAccChange;

		// Token: 0x0400A63B RID: 42555
		private GameObject goGlobalBtns;

		// Token: 0x0400A63C RID: 42556
		private bool isTabRoleInfoOn;

		// Token: 0x0400A63D RID: 42557
		private bool isTabSysSetOn;

		// Token: 0x0400A63E RID: 42558
		private bool isTabBattleCtrlOn;

		// Token: 0x0400A63F RID: 42559
		private bool isTabVipCtrlOn;

		// Token: 0x0400A640 RID: 42560
		private bool isTabPushSetOn;

		// Token: 0x0400A641 RID: 42561
		private bool isTabVoiceChatOn;

		// Token: 0x0400A642 RID: 42562
		private bool isTabCDKOn;

		// Token: 0x0400A643 RID: 42563
		private bool isTabMobileBindOn;

		// Token: 0x0400A644 RID: 42564
		private bool isTabDebugOn;

		// Token: 0x0400A645 RID: 42565
		private bool isTabAccountLockOn;

		// Token: 0x0400A646 RID: 42566
		private RoleInfoSettings roleInfoSettings;

		// Token: 0x0400A647 RID: 42567
		private SystemInfoSettings systemInfoSettings;

		// Token: 0x0400A648 RID: 42568
		private VipSettings vipSettings;

		// Token: 0x0400A649 RID: 42569
		private VoiceChatSettings voiceChatSettings;

		// Token: 0x0400A64A RID: 42570
		private CDKRewardSettings cdkRewardSettings;

		// Token: 0x0400A64B RID: 42571
		private AccountLockSettings accountLockSettings;

		// Token: 0x0400A64C RID: 42572
		private SettingFrame.TabType eStartUpTabType;

		// Token: 0x02001A10 RID: 6672
		public enum TabType
		{
			// Token: 0x0400A64F RID: 42575
			ROLE_INFO,
			// Token: 0x0400A650 RID: 42576
			SYS_SET,
			// Token: 0x0400A651 RID: 42577
			BATTLE_CTRL,
			// Token: 0x0400A652 RID: 42578
			VIP,
			// Token: 0x0400A653 RID: 42579
			PUSH_SET,
			// Token: 0x0400A654 RID: 42580
			VOICE_CHAT,
			// Token: 0x0400A655 RID: 42581
			CDK,
			// Token: 0x0400A656 RID: 42582
			MOBILE_BIND,
			// Token: 0x0400A657 RID: 42583
			DEBUG,
			// Token: 0x0400A658 RID: 42584
			ACCOUNT_LOCK
		}
	}
}
