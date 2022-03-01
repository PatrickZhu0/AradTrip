using System;
using System.Collections;
using System.Collections.Generic;
using Client;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02001159 RID: 4441
	internal class ClientSystemLogin : ClientSystem
	{
		// Token: 0x0600A96B RID: 43371 RVA: 0x0023CB50 File Offset: 0x0023AF50
		private void SetBanQuan(bool isAppStore)
		{
			if (isAppStore)
			{
				this.mTishiwenzi_ios.CustomActive(true);
				this.mIosDescRoot.CustomActive(true);
				this.mVersion_ios.CustomActive(true);
				this.mPackageInfo_ios.CustomActive(true);
				this.mImage_bg1.CustomActive(false);
				this.mImage_bg2.CustomActive(false);
				this.mTishiwenzi.CustomActive(false);
				this.mVr.CustomActive(false);
			}
			else
			{
				this.mTishiwenzi_ios.CustomActive(false);
				this.mIosDescRoot.CustomActive(false);
				this.mVersion_ios.CustomActive(false);
				this.mPackageInfo_ios.CustomActive(false);
				this.mImage_bg1.CustomActive(true);
				this.mImage_bg2.CustomActive(true);
				this.mTishiwenzi.CustomActive(true);
				this.mVr.CustomActive(true);
			}
		}

		// Token: 0x17001A28 RID: 6696
		// (get) Token: 0x0600A96C RID: 43372 RVA: 0x0023CC28 File Offset: 0x0023B028
		// (set) Token: 0x0600A96D RID: 43373 RVA: 0x0023CC2F File Offset: 0x0023B02F
		public static bool mSwitchRole
		{
			get
			{
				return ClientSystemLogin.mswitchrole;
			}
			set
			{
				ClientSystemLogin.mswitchrole = value;
			}
		}

		// Token: 0x0600A96E RID: 43374 RVA: 0x0023CC38 File Offset: 0x0023B038
		protected sealed override void _bindExUI()
		{
			this.mrroot = this.mBind.GetGameObject("r");
			this.mAccountRoot = this.mBind.GetGameObject("accountRoot");
			this.mPassWordRoot = this.mBind.GetGameObject("passWordRoot");
			this.mVersionCode = this.mBind.GetCom<Text>("VersionCode");
			this.mCurServerBind = this.mBind.GetCom<ComCommonBind>("CurServerBind");
			this.mPackedInfo = this.mBind.GetCom<Text>("PackedInfo");
			this.mPassword = this.mBind.GetCom<InputField>("password");
			this.mAccount = this.mBind.GetCom<InputField>("account");
			this.mSelectServer = this.mBind.GetCom<Button>("SelectServer");
			this.mSelectServer.onClick.AddListener(new UnityAction(this._onSelectServerButtonClick));
			this.mPublish = this.mBind.GetCom<Button>("Publish");
			this.mPublish.onClick.AddListener(new UnityAction(this._onPublishButtonClick));
			this.mLogin = this.mBind.GetCom<Button>("Login");
			this.mRootServerLst = this.mBind.GetGameObject("rootServerLst");
			this.mRootClickEnter = this.mBind.GetGameObject("rootClickEnter");
			this.mClickEnterTips = this.mBind.GetCom<Text>("clickEnterTips");
			this.mBtnClickEnter = this.mBind.GetCom<Button>("btnClickEnter");
			this.mBtnClickEnter.onClick.AddListener(new UnityAction(this._onBtnClickEnterButtonClick));
			this.mLogin = this.mBind.GetCom<Button>("Login");
			this.mLogin.onClick.AddListener(new UnityAction(this._onLoginButtonClick));
			this.mLoginReg = this.mBind.GetCom<Button>("loginregEnter");
			this.mLoginReg.onClick.AddListener(new UnityAction(this._onLoginRegButtonClick));
			this.mTgSelUserAgree = this.mBind.GetCom<Toggle>("tgSelUserAgree");
			this.mTgSelUserAgree.onValueChanged.AddListener(new UnityAction<bool>(this._onTgSelUserAgreeToggleValueChange));
			this.mUserAgreement = this.mBind.GetCom<Button>("UserAgreement");
			this.mUserAgreement.onClick.AddListener(new UnityAction(this._onUserAgreementButtonClick));
			this.mUploadCompress = this.mBind.GetCom<Button>("UploadCompress");
			this.mUploadCompress.onClick.AddListener(new UnityAction(this._onUploadCompressButtonClick));
			this.mLoginSpineRender = this.mBind.GetCom<GeObjectRenderer>("LoginSpineRender");
			this.mSecretAgreement = this.mBind.GetCom<Button>("SecretAgreement");
			this.mSecretAgreement.onClick.AddListener(new UnityAction(this._onSecretAgreementButtonClick));
			this.mRegRoot = this.mBind.GetGameObject("reg");
			this.mRAccount = this.mBind.GetCom<InputField>("rAccountInput");
			this.mRPassword1 = this.mBind.GetCom<InputField>("rPasswordInput");
			this.mRPassword2 = this.mBind.GetCom<InputField>("rPasswordInput2");
			this.mRCPS = this.mBind.GetCom<InputField>("rcpsInput");
			this.regBack = this.mBind.GetCom<Button>("regBack");
			this.regBack.onClick.AddListener(new UnityAction(this._onRegBackButtonClick));
			this.regEnter = this.mBind.GetCom<Button>("regEnter");
			this.regEnter.onClick.AddListener(new UnityAction(this._onRegButtonClick));
			this.mImage_bg1 = this.mBind.GetGameObject("Image_bg1");
			this.mImage_bg2 = this.mBind.GetGameObject("Image_bg2");
			this.mTishiwenzi = this.mBind.GetGameObject("tishiwenzi");
			this.mVr = this.mBind.GetGameObject("vr");
			this.mIosDescRoot = this.mBind.GetGameObject("iosDescRoot");
			this.mTishiwenzi_ios = this.mBind.GetCom<Text>("tishiwenzi_ios");
			this.mVersion_ios = this.mBind.GetCom<Text>("Version_ios");
			this.mPackageInfo_ios = this.mBind.GetCom<Text>("PackageInfo_ios");
			this.miosDescBottom = this.mBind.GetGameObject("iosDescBottom");
			this.mBtnRepaire = this.mBind.GetCom<Button>("btnRepaire");
			this.mBtnRepaire.onClick.AddListener(new UnityAction(this._onBtnRepaireButtonClick));
			this.mTitle = this.mBind.GetCom<Image>("Title");
			this.mLocalLogin = this.mBind.GetGameObject("LocalLogin");
			this.mParam = this.mBind.GetCom<InputField>("param");
			this.mHashValue = this.mBind.GetCom<InputField>("hashValue");
			this.mTableMd5 = this.mBind.GetCom<InputField>("tableMd5");
			this.mSkillMd5 = this.mBind.GetCom<InputField>("skillMd5");
			this.mSv = this.mBind.GetCom<InputField>("sv");
			this.mLocalLogin.CustomActive(false);
			if (null != this.mUploadCompress)
			{
				bool bActive = false;
				this.mUploadCompress.gameObject.CustomActive(bActive);
			}
		}

		// Token: 0x0600A96F RID: 43375 RVA: 0x0023D1BC File Offset: 0x0023B5BC
		protected sealed override void _unbindExUI()
		{
			this.mAccountRoot = null;
			this.mPassWordRoot = null;
			this.mVersionCode = null;
			this.mCurServerBind = null;
			this.mPackedInfo = null;
			this.mPassword = null;
			this.mAccount = null;
			this.mSelectServer.onClick.RemoveListener(new UnityAction(this._onSelectServerButtonClick));
			this.mSelectServer = null;
			this.mPublish.onClick.RemoveListener(new UnityAction(this._onPublishButtonClick));
			this.mPublish = null;
			this.mRootServerLst = null;
			this.mRootClickEnter = null;
			this.mBtnClickEnter.onClick.RemoveListener(new UnityAction(this._onBtnClickEnterButtonClick));
			this.mBtnClickEnter = null;
			this.mClickEnterTips = null;
			this.mLogin.onClick.RemoveListener(new UnityAction(this._onLoginButtonClick));
			this.mLogin = null;
			this.mTgSelUserAgree.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTgSelUserAgreeToggleValueChange));
			this.mTgSelUserAgree = null;
			this.mUserAgreement.onClick.RemoveListener(new UnityAction(this._onUserAgreementButtonClick));
			this.mUserAgreement = null;
			this.mUploadCompress.onClick.RemoveListener(new UnityAction(this._onUploadCompressButtonClick));
			this.mUploadCompress = null;
			this.mLoginSpineRender = null;
			this.mSecretAgreement.onClick.RemoveListener(new UnityAction(this._onSecretAgreementButtonClick));
			this.mSecretAgreement = null;
			this.mImage_bg1 = null;
			this.mImage_bg2 = null;
			this.mTishiwenzi = null;
			this.mVr = null;
			this.mIosDescRoot = null;
			this.mTishiwenzi_ios = null;
			this.mVersion_ios = null;
			this.mPackageInfo_ios = null;
			this.miosDescBottom = null;
			this.mBtnRepaire.onClick.RemoveListener(new UnityAction(this._onBtnRepaireButtonClick));
			this.mBtnRepaire = null;
			this.mTitle = null;
			this.mLocalLogin = null;
			this.mParam = null;
			this.mHashValue = null;
			this.mTableMd5 = null;
			this.mSkillMd5 = null;
			this.mSv = null;
		}

		// Token: 0x0600A970 RID: 43376 RVA: 0x0023D3C1 File Offset: 0x0023B7C1
		private void _onSelectServerButtonClick()
		{
			this._onServerList();
		}

		// Token: 0x0600A971 RID: 43377 RVA: 0x0023D3C9 File Offset: 0x0023B7C9
		private void _onPublishButtonClick()
		{
			this._onPublish();
		}

		// Token: 0x0600A972 RID: 43378 RVA: 0x0023D3D1 File Offset: 0x0023B7D1
		private void _onBtnClickEnterButtonClick()
		{
			this.DoClickEnter();
		}

		// Token: 0x0600A973 RID: 43379 RVA: 0x0023D3D9 File Offset: 0x0023B7D9
		private void _onRegBackButtonClick()
		{
			this.mrroot.gameObject.SetActive(true);
			this.mRegRoot.gameObject.SetActive(false);
		}

		// Token: 0x0600A974 RID: 43380 RVA: 0x0023D400 File Offset: 0x0023B800
		private void _onRegButtonClick()
		{
			string text = "http://zc.rdjnc.com/SetPwd.php";
			Application.OpenURL(text);
		}

		// Token: 0x0600A975 RID: 43381 RVA: 0x0023D41C File Offset: 0x0023B81C
		private void _onLoginRegButtonClick()
		{
			string text = "http://zc.rdjnc.com/index.php";
			Application.OpenURL(text);
		}

		// Token: 0x0600A976 RID: 43382 RVA: 0x0023D435 File Offset: 0x0023B835
		private void _onLoginButtonClick()
		{
			if (!this.mTgSelUserAgree.isOn)
			{
				SystemNotifyManager.SystemNotify(9301, string.Empty);
				return;
			}
			this._onLogin(false);
		}

		// Token: 0x0600A977 RID: 43383 RVA: 0x0023D45E File Offset: 0x0023B85E
		private void _onTgSelUserAgreeToggleValueChange(bool changed)
		{
		}

		// Token: 0x0600A978 RID: 43384 RVA: 0x0023D460 File Offset: 0x0023B860
		private void _onUserAgreementButtonClick()
		{
			UserAgreementFrameData userAgreementFrameData = default(UserAgreementFrameData);
			userAgreementFrameData.frameType = UserAgreementFrameType.LookInfo;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<UserAgreementFrame>(FrameLayer.Middle, userAgreementFrameData, string.Empty);
		}

		// Token: 0x0600A979 RID: 43385 RVA: 0x0023D494 File Offset: 0x0023B894
		private void _onUploadCompressButtonClick()
		{
			SystemNotifyManager.BaseMsgBoxOkCancel("是否上传数据", delegate
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<UploadingCompressFrame>(FrameLayer.Middle, null, string.Empty);
			}, null, "确定", "取消");
		}

		// Token: 0x0600A97A RID: 43386 RVA: 0x0023D4C8 File Offset: 0x0023B8C8
		private void _onSecretAgreementButtonClick()
		{
			UserAgreementFrameData userAgreementFrameData = default(UserAgreementFrameData);
			userAgreementFrameData.frameType = UserAgreementFrameType.LookInfo;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SecretAgreementFrame>(FrameLayer.Middle, userAgreementFrameData, string.Empty);
		}

		// Token: 0x0600A97B RID: 43387 RVA: 0x0023D4FC File Offset: 0x0023B8FC
		private IEnumerator _openDownloadPackage()
		{
			if (AppPackageFetcher.InitNativePackageVersion())
			{
				yield return AppPackageFetcher.FetchFullAppPackage();
				if (AppPackageFetcher.IsVersionValid())
				{
					if (AppPackageFetcher.IsRemoteNewer())
					{
						SystemNotifyManager.SysNotifyMsgBoxOK("当前游戏版本号过低，请点击〖<color=#ff0000ff>下载客户端</color>〗下载游戏最新版本。", delegate
						{
							AppPackageFetcher.OpenAppPackageURL();
						}, ClientConfig.AppPackageButTextOpenURL, false);
					}
					else
					{
						SystemNotifyManager.SysNotifyMsgBoxOK("当前客户端为最新版本，无需修复。", null, string.Empty, false);
					}
				}
			}
			yield break;
		}

		// Token: 0x0600A97C RID: 43388 RVA: 0x0023D510 File Offset: 0x0023B910
		private void _onBtnRepaireButtonClick()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._openDownloadPackage());
		}

		// Token: 0x0600A97D RID: 43389 RVA: 0x0023D523 File Offset: 0x0023B923
		private void _onSelectChannelButtonClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ChooseChannelFrame>(FrameLayer.Middle, false, string.Empty);
			this.ShowLoginButton(false);
		}

		// Token: 0x17001A29 RID: 6697
		// (get) Token: 0x0600A97E RID: 43390 RVA: 0x0023D543 File Offset: 0x0023B943
		// (set) Token: 0x0600A97F RID: 43391 RVA: 0x0023D54B File Offset: 0x0023B94B
		protected bool Logining
		{
			get
			{
				return this.mIsLogining;
			}
			set
			{
				this.mIsLogining = value;
				this._enableLoginGray(this.mIsLogining);
				if (this.mIsLogining)
				{
					WaitNetMessageFrame.TryOpen();
				}
				else
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<WaitNetMessageFrame>(null, false);
				}
			}
		}

		// Token: 0x0600A980 RID: 43392 RVA: 0x0023D584 File Offset: 0x0023B984
		private void _enableLoginGray(bool enable)
		{
			if (null == this.mLogin)
			{
				return;
			}
			UIGray uigray = this.mLogin.gameObject.SafeAddComponent(false);
			if (null != uigray)
			{
				uigray.enabled = enable;
			}
		}

		// Token: 0x0600A981 RID: 43393 RVA: 0x0023D5C8 File Offset: 0x0023B9C8
		public void MarkNewActor(string name)
		{
			this.newActorName = name;
		}

		// Token: 0x0600A982 RID: 43394 RVA: 0x0023D5D4 File Offset: 0x0023B9D4
		public void OnReturnToLogin()
		{
			if (this.BkgSoundHandle == 4294967295U)
			{
				this.BkgSoundHandle = MonoSingleton<AudioManager>.instance.PlaySound("Sound/Login", AudioType.AudioStream, Global.Settings.bgmStart, true, null, false, false, null, 1f);
			}
		}

		// Token: 0x0600A983 RID: 43395 RVA: 0x0023D617 File Offset: 0x0023BA17
		public sealed override string GetMainUIPrefabName()
		{
			return "UIFlatten/Prefabs/Login/LoginFrame";
		}

		// Token: 0x0600A984 RID: 43396 RVA: 0x0023D620 File Offset: 0x0023BA20
		public void _onServerList()
		{
			if (this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.Error || this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.Loading || this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.None)
			{
				SystemNotifyManager.SystemNotify(8001, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.instance.OpenFrame<ServerListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A985 RID: 43397 RVA: 0x0023D672 File Offset: 0x0023BA72
		private void _onPublish()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<PublishContentFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A986 RID: 43398 RVA: 0x0023D688 File Offset: 0x0023BA88
		private void _onLogin(bool bReg = false)
		{
			ClientApplication.m_bReg = bReg;
			Singleton<PluginManager>.GetInstance().LeBianRequestUpdate();
			if (this.Logining)
			{
				return;
			}
			if (Global.Settings.isUsingSDK && ClientApplication.playerinfo.state != PlayerState.LOGIN)
			{
				Singleton<PluginManager>.GetInstance().OpenXYLogin();
				return;
			}
			if (this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.Error || this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.Loading || this.mLoadingServerStatus == ClientSystemLogin.eLoadingServerState.None)
			{
				SystemNotifyManager.SystemNotify(8001, string.Empty);
				Logger.LogErrorFormat("[登录], 错误状态，提示玩家 {0}", new object[]
				{
					this.mLoadingServerStatus
				});
				return;
			}
			SockAddr sockAddr = new SockAddr();
			if (ClientApplication.adminServer != null)
			{
				sockAddr.ip = ClientApplication.adminServer.ip;
				sockAddr.port = ClientApplication.adminServer.port;
			}
			else
			{
				Logger.LogError("[登录] ClientApplication.adminServer is null.");
			}
			if (string.IsNullOrEmpty(sockAddr.ip) || sockAddr.port == 0)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ServerListFrame>(FrameLayer.Middle, null, string.Empty);
				return;
			}
			ClientApplication.playerinfo.serverID = ClientApplication.adminServer.id;
			if (this.mAccount == null || this.mPassword == null)
			{
				return;
			}
			if (this.BkgSoundHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.BkgSoundHandle);
				this.BkgSoundHandle = uint.MaxValue;
			}
			this.Logining = true;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._login(sockAddr, bReg));
		}

		// Token: 0x0600A987 RID: 43399 RVA: 0x0023D810 File Offset: 0x0023BC10
		private IEnumerator _login(SockAddr addr, bool bReg = false)
		{
			this.mIsGetGateSendRoleInfo = false;
			string param = string.Empty;
			if (bReg)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				if (this.mRAccount != null && this.mRPassword1 != null && this.mRPassword2 != null && this.mRCPS != null)
				{
					text = this.mRAccount.text;
					text2 = this.mRPassword1.text;
					text3 = this.mRPassword2.text;
					text4 = this.mRCPS.text;
				}
				string text5 = string.Empty;
				if (text.Length <= 0)
				{
					text5 = "请输入账号";
				}
				if (text.Length != 8)
				{
					text5 = "请输入8位账号";
				}
				else if (text4.Length <= 0)
				{
					text5 = "请输入邀请码";
				}
				else if (text2.Length <= 0 || text3.Length <= 0)
				{
					text5 = "请输入密码";
				}
				else if (text2 != text3)
				{
					text5 = "两次输入的密码不一致";
				}
				if (text5.Length > 0)
				{
					SystemNotifyManager.SystemNotify(8001, text5);
					this.mLoginStatus = ClientSystemLogin.eLoginStatus.Fail;
					this.Logining = false;
					yield break;
				}
				param = "userid=" + text + "&reg=1";
				param = param + "&password=" + text2;
				param = param + "&password2=" + text3;
				param = param + "&cps=" + text4;
			}
			else
			{
				if (this.mAccount != null)
				{
					param = "userid=" + this.mAccount.text + "&openid=1";
				}
				else
				{
					Logger.LogError("mAccount is null in [_login]");
				}
				if (this.mPassword != null)
				{
					param = param + "&password=" + this.mPassword.text;
					ClientApplication.playerinfo.password = this.mPassword.text;
				}
				else
				{
					Logger.LogError("mPassword is null in [_login]");
					ClientApplication.playerinfo.password = string.Empty;
				}
			}
			if (Global.Settings.isUsingSDK)
			{
				if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.state != PlayerState.LOGIN)
				{
					Singleton<PluginManager>.GetInstance().OpenXYLogin();
					this.mLoginStatus = ClientSystemLogin.eLoginStatus.Fail;
					this.Logining = false;
					yield break;
				}
				int isAccountValidateRet = -1;
				string errorMsg = string.Empty;
				byte[] hashval = new byte[20];
				string url = Singleton<PluginManager>.instance.LoginVerifyUrl(Global.LOGIN_SERVER_ADDRESS, ClientApplication.playerinfo.serverID + string.Empty, ClientApplication.playerinfo.openuid, ClientApplication.playerinfo.token, SystemInfo.deviceUniqueIdentifier, Global.channelName, ClientApplication.playerinfo.sdkLoginExt);
				BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
				wt.url = url;
				yield return wt;
				if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
				{
					string resultString = wt.GetResultString();
					if (resultString == null)
					{
						isAccountValidateRet = 1;
					}
					else
					{
						Hashtable hashtable = (Hashtable)MiniJSON.jsonDecode(resultString);
						if (hashtable != null)
						{
							isAccountValidateRet = int.Parse(hashtable["result"].ToString());
							param = hashtable["params"].ToString();
							if (hashtable.ContainsKey("error"))
							{
								errorMsg = hashtable["error"].ToString();
							}
							if (ClientApplication.playerinfo != null)
							{
								ClientApplication.playerinfo.openuid = hashtable["openid"].ToString();
							}
							if (SDKInterface.instance.NeedPayToken() && ClientApplication.playerinfo != null)
							{
								ClientApplication.playerinfo.token = hashtable["token"].ToString();
								SDKInterface.instance.SetAccInfo(ClientApplication.playerinfo.openuid, ClientApplication.playerinfo.token);
							}
							if (isAccountValidateRet == 1002)
							{
								Singleton<PluginManager>.GetInstance().OpenXYLogin();
							}
							string text6 = hashtable["hashval"].ToString();
							for (int i = 0; i < text6.Length / 2; i++)
							{
								hashval[i] = Convert.ToByte(text6.Substring(i * 2, 2), 16);
							}
						}
						else
						{
							Logger.LogErrorFormat("[登录] resText jsonDecode 解析失败,resText = {0}", new object[]
							{
								resultString
							});
						}
					}
				}
				else
				{
					Logger.LogErrorFormat("[登录] BaseWaitHttpRequest.eState = {0}", new object[]
					{
						wt.GetResult()
					});
				}
				if (isAccountValidateRet != 0)
				{
					this.Logining = false;
					this.mLoginStatus = ClientSystemLogin.eLoginStatus.Fail;
					if (wt.GetResult() == BaseWaitHttpRequest.eState.TimeOut || wt.GetResult() == BaseWaitHttpRequest.eState.Error)
					{
						SystemNotifyManager.SystemNotify(8522, string.Empty);
					}
					yield break;
				}
				if (ClientApplication.playerinfo != null)
				{
					ClientApplication.playerinfo.hashValue = hashval;
				}
			}
			if (ClientApplication.playerinfo != null)
			{
				ClientApplication.playerinfo.param = param;
			}
			ClientSystemLoginUtility.StartLoginAfterVerify();
			yield break;
		}

		// Token: 0x0600A988 RID: 43400 RVA: 0x0023D832 File Offset: 0x0023BC32
		private void _startWaitRolesProcess()
		{
			this._stopWaitRolesProcess();
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._waitLoginSuccessAndRolesData());
		}

		// Token: 0x0600A989 RID: 43401 RVA: 0x0023D84B File Offset: 0x0023BC4B
		private void _stopWaitRolesProcess()
		{
			if (this.mWaitRolesProcessCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mWaitRolesProcessCo);
				this.mWaitRolesProcessCo = null;
			}
		}

		// Token: 0x0600A98A RID: 43402 RVA: 0x0023D870 File Offset: 0x0023BC70
		private IEnumerator _waitLoginSuccessAndRolesData()
		{
			this.mIsGetGateSendRoleInfo = false;
			while (this.mLoginStatus == ClientSystemLogin.eLoginStatus.Logining)
			{
				yield return null;
			}
			while (this.mLoginStatus == ClientSystemLogin.eLoginStatus.WaitQueue)
			{
				yield return null;
			}
			if (this.mLoginStatus == ClientSystemLogin.eLoginStatus.Fail)
			{
				this.Logining = false;
				yield break;
			}
			while (!this.mIsGetGateSendRoleInfo)
			{
				yield return Yielders.EndOfFrame;
			}
			this.Logining = false;
			yield break;
		}

		// Token: 0x0600A98B RID: 43403 RVA: 0x0023D88C File Offset: 0x0023BC8C
		[MessageHandle(300317U, false, 0)]
		private void NotifyAllowLogin(MsgDATA data)
		{
			if (this.mLoginStatus == ClientSystemLogin.eLoginStatus.WaitQueue)
			{
				this.mLoginStatus = ClientSystemLogin.eLoginStatus.Logining;
			}
			else
			{
				Logger.LogErrorFormat("[登录] 不在排队状态，通知进游戏？？？ {0} -> {1}", new object[]
				{
					this.mLoginStatus,
					ClientSystemLogin.eLoginStatus.Logining
				});
				this.mLoginStatus = ClientSystemLogin.eLoginStatus.Logining;
			}
		}

		// Token: 0x0600A98C RID: 43404 RVA: 0x0023D8E0 File Offset: 0x0023BCE0
		[MessageHandle(300301U, false, 0)]
		private void OnGateSendRoleInfo(MsgDATA msg)
		{
			if (this.mrroot != null)
			{
				this.mrroot.gameObject.SetActive(true);
			}
			if (this.mRegRoot != null)
			{
				this.mRegRoot.gameObject.SetActive(false);
			}
			if (ClientSystemLogin.mSwitchRole)
			{
				return;
			}
			GateSendRoleInfo gateSendRoleInfo = new GateSendRoleInfo();
			gateSendRoleInfo.decode(msg.bytes);
			foreach (RoleInfo roleInfo in gateSendRoleInfo.roles)
			{
			}
			int newCreateActorIndex = this.GetNewCreateActorIndex(gateSendRoleInfo);
			ClientApplication.playerinfo.roleinfo = gateSendRoleInfo.roles;
			ClientApplication.playerinfo.apponintmentOccus = gateSendRoleInfo.appointmentOccus;
			ClientApplication.playerinfo.appointmentRoleNum = gateSendRoleInfo.appointmentRoleNum;
			ClientApplication.playerinfo.baseRoleFieldNum = gateSendRoleInfo.baseRoleField;
			ClientApplication.playerinfo.extendRoleFieldNum = gateSendRoleInfo.extensibleRoleField;
			ClientApplication.playerinfo.unLockedExtendRoleFieldNum = gateSendRoleInfo.unlockedExtensibleRoleField;
			Singleton<ServerListManager>.instance.SaveUserData(gateSendRoleInfo.roles);
			if (SDKInterface.instance.IsSmallPackage() && !SDKInterface.instance.IsResourceDownloadFinished() && gateSendRoleInfo.roles != null)
			{
				for (int j = 0; j < gateSendRoleInfo.roles.Length; j++)
				{
					RoleInfo roleInfo2 = gateSendRoleInfo.roles[j];
					Singleton<PluginManager>.instance.LeBianJudgeLevelAndDownload((int)roleInfo2.level);
				}
			}
			if (!ClientSystemLogin.HasPreLoadRoles)
			{
				RoleSceneLoadingFrame roleSceneLoadingFrame = null;
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RoleSceneLoadingFrame>(null))
				{
					roleSceneLoadingFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<RoleSceneLoadingFrame>(FrameLayer.Top, null, string.Empty) as RoleSceneLoadingFrame);
				}
				if (roleSceneLoadingFrame != null)
				{
					int k = 0;
					int num = gateSendRoleInfo.roles.Length;
					while (k < num)
					{
						RoleInfo roleInfo3 = gateSendRoleInfo.roles[k];
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)roleInfo3.occupation, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								string modelPath = tableItem2.ModelPath;
								AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(modelPath, typeof(ScriptableObject), false, 0U);
								if (assetInst != null)
								{
									DModelData dmodelData = assetInst.obj as DModelData;
									roleSceneLoadingFrame.AddLoadingTask(dmodelData.modelAvatar.m_AssetPath);
									int l = 0;
									int num2 = dmodelData.partsChunk.Length;
									while (l < num2)
									{
										roleSceneLoadingFrame.AddLoadingTask(dmodelData.partsChunk[l].partAsset.m_AssetPath);
										l++;
									}
								}
								int m = 0;
								int num3 = roleInfo3.avatar.equipItemIds.Length;
								while (m < num3)
								{
									roleSceneLoadingFrame.AddLoadingTask(DataManager<PlayerBaseData>.GetInstance().GetWeaponResFormID((int)roleInfo3.avatar.equipItemIds[m]));
									m++;
								}
							}
						}
						k++;
					}
				}
				roleSceneLoadingFrame.ProcessLoading();
				ClientSystemLogin.HasPreLoadRoles = true;
			}
			if (gateSendRoleInfo.roles.Length <= 0)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SelectRoleFrame>(null) && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CreateActorFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<CreateActorFrame>(FrameLayer.Bottom, null, string.Empty);
				}
			}
			else
			{
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<CreateActorFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<CreateActorFrame>(null, false);
				}
				if (newCreateActorIndex != -1 && this.newActorName == gateSendRoleInfo.roles[newCreateActorIndex].name)
				{
					ClientApplication.playerinfo.curSelectedRoleIdx = newCreateActorIndex;
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(ClientSystemLogin.StartEnterGame());
					this.mIsGetGateSendRoleInfo = true;
					ComCreateRoleScene.ClearDemoRole();
					ComCreateRoleScene.ClearSelectRole();
					Singleton<GameStatisticManager>.GetInstance().DoStatClientData();
					RoleInfo roleInfo4 = ClientApplication.playerinfo.roleinfo[newCreateActorIndex];
					if (roleInfo4 != null)
					{
						SDKInterface.instance.SetCreateRoleInfo(ClientApplication.playerinfo.openuid, roleInfo4.roleId.ToString(), roleInfo4.name, roleInfo4.level + string.Empty, ClientApplication.adminServer.name, "赛季段位", "角色公会");
						SDKInterface.instance.SetCreateRoleInfo(ClientApplication.playerinfo.openuid, ClientApplication.playerinfo.roleinfo[newCreateActorIndex].roleId.ToString());
						SDKInterface.instance.UpdateRoleInfo(3, ClientApplication.adminServer.id, ClientApplication.adminServer.name, roleInfo4.strRoleId, roleInfo4.name, (int)roleInfo4.occupation, 1, 0, 0);
					}
					return;
				}
				ClientApplication.playerinfo.newUnLockExtendRoleFieldNum = 0U;
				DataManager<SecurityLockDataManager>.GetInstance().InitiallizeSystem();
				Singleton<ClientSystemManager>.instance.OpenFrame<SelectRoleFrame>(FrameLayer.Bottom, null, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleInfoUpdate, null, null, null, null);
			if (newCreateActorIndex != -1)
			{
				UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
				idleUIEvent.EventID = EUIEventID.SetDefaultSelectedID;
				idleUIEvent.EventParams.CurrentSelectedID = newCreateActorIndex;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
			}
			this.mIsGetGateSendRoleInfo = true;
		}

		// Token: 0x0600A98D RID: 43405 RVA: 0x0023DDF4 File Offset: 0x0023C1F4
		private int GetNewCreateActorIndex(GateSendRoleInfo ret)
		{
			int result = -1;
			int num = 0;
			while (num < ret.roles.Length && ClientApplication.playerinfo.roleinfo != null)
			{
				bool flag = false;
				for (int i = 0; i < ClientApplication.playerinfo.roleinfo.Length; i++)
				{
					if (ret.roles[num].roleId == ClientApplication.playerinfo.roleinfo[i].roleId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					result = num;
					break;
				}
				num++;
			}
			return result;
		}

		// Token: 0x0600A98E RID: 43406 RVA: 0x0023DE82 File Offset: 0x0023C282
		public sealed override void OnStart(SystemContent systemContent)
		{
			MonoSingleton<AssetAsyncLoader>.instance.SetLoadingLimit(16);
			Singleton<SystemSwitchEventManager>.GetInstance().TriggerEvent(SystemEventType.SYSETM_EVENT_SELECT_ROLE);
		}

		// Token: 0x0600A98F RID: 43407 RVA: 0x0023DEA0 File Offset: 0x0023C2A0
		public static IEnumerator StartEnterGame()
		{
			Singleton<ClientReconnectManager>.instance.canRelogin = false;
			RoleInfo roleInfo = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
			DataManager<PlayerBaseData>.GetInstance().Name = roleInfo.name;
			DataManager<PlayerBaseData>.GetInstance().Level = roleInfo.level;
			DataManager<PlayerBaseData>.GetInstance().RoleID = roleInfo.roleId;
			DataManager<PlayerBaseData>.GetInstance().JobTableID = (int)roleInfo.occupation;
			DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID = (int)roleInfo.preOccu;
			if (DataManager<SkillDamageStorage>.GetInstance() != null)
			{
				DataManager<SkillDamageStorage>.GetInstance().ResetData();
			}
			if (Global.Settings.isGuide && !ClientApplication.playerinfo.GetSelectRoleHasPassFirstFight())
			{
				GateFinishNewbeeGuide nbguide = new GateFinishNewbeeGuide();
				nbguide.roleId = roleInfo.roleId;
				nbguide.id = 1U;
				MonoSingleton<NetManager>.instance.SendCommand<GateFinishNewbeeGuide>(ServerType.GATE_SERVER, nbguide);
				BattleMain.OpenBattle(BattleType.NewbieGuide, eDungeonMode.LocalFrame, 0, "20000");
				yield return Yielders.EndOfFrame;
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemBattle>(null, null, false);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600A990 RID: 43408 RVA: 0x0023DEB4 File Offset: 0x0023C2B4
		protected override string _GetLevelName()
		{
			return "Start";
		}

		// Token: 0x0600A991 RID: 43409 RVA: 0x0023DEBC File Offset: 0x0023C2BC
		private void _updateVersion()
		{
			if (this.mVersionCode != null)
			{
				this.mVersionCode.text = string.Format("{0} {1}", Singleton<VersionManager>.instance.Version(), (!Global.Settings.loadFromPackage) ? "res" : string.Empty);
			}
			if (this.mPackedInfo != null)
			{
				this.mPackedInfo.text = string.Empty;
			}
			if (this.mVersion_ios != null)
			{
				this.mVersion_ios.text = string.Format("{0} {1}", Singleton<VersionManager>.instance.Version(), (!Global.Settings.loadFromPackage) ? "res" : string.Empty);
			}
			if (this.mPackageInfo_ios != null)
			{
				this.mPackageInfo_ios.text = string.Empty;
			}
		}

		// Token: 0x0600A992 RID: 43410 RVA: 0x0023DFA8 File Offset: 0x0023C3A8
		private void _LoadHistoryAccount()
		{
			if (!Global.Settings.isUsingSDK)
			{
				string text = PlayerLocalSetting.GetValue("AccountDefault") as string;
				this.mAccount.text = text;
			}
		}

		// Token: 0x0600A993 RID: 43411 RVA: 0x0023DFE0 File Offset: 0x0023C3E0
		private void _SaveHistoryAccount()
		{
		}

		// Token: 0x0600A994 RID: 43412 RVA: 0x0023DFE2 File Offset: 0x0023C3E2
		private void _onAccountUpdate(string st)
		{
		}

		// Token: 0x0600A995 RID: 43413 RVA: 0x0023DFE4 File Offset: 0x0023C3E4
		private void _onAccountEndEdit(string st)
		{
			if (!Global.Settings.isUsingSDK && !string.IsNullOrEmpty(st))
			{
				PlayerLocalSetting.SetValue("AccountDefault", st);
				PlayerLocalSetting.SaveConfig();
				this._forceloadSavedServer();
			}
		}

		// Token: 0x0600A996 RID: 43414 RVA: 0x0023E016 File Offset: 0x0023C416
		private void _forceloadSavedServer()
		{
			if (this.mCurrentLoadServerCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCurrentLoadServerCo);
			}
			this.mCurrentLoadServerCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._loadSavedServer());
		}

		// Token: 0x0600A997 RID: 43415 RVA: 0x0023E049 File Offset: 0x0023C449
		public void DoClickEnter()
		{
			this.OpenLogin();
		}

		// Token: 0x0600A998 RID: 43416 RVA: 0x0023E054 File Offset: 0x0023C454
		public void OpenLogin()
		{
			if (Global.Settings.isUsingSDK)
			{
				if (this.mAccountRoot != null)
				{
					this.mAccountRoot.SetActive(false);
				}
				if (this.mPassWordRoot != null)
				{
					this.mPassWordRoot.SetActive(false);
				}
				if (ClientApplication.playerinfo.state == PlayerState.LOGIN)
				{
					this.ShowLoginButton(true);
				}
				else if (!ClientSystemLogin.mSwitchRole)
				{
					Singleton<PluginManager>.GetInstance().OpenXYLogin();
				}
			}
			else
			{
				this.ShowLoginButton(true);
			}
		}

		// Token: 0x0600A999 RID: 43417 RVA: 0x0023E0E6 File Offset: 0x0023C4E6
		private void DoSelectChannel()
		{
			if (Singleton<ChooseChannelManager>.GetInstance().SetSelectChannelInfoSucc())
			{
				this.OpenLogin();
			}
			else
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ChooseChannelFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600A99A RID: 43418 RVA: 0x0023E114 File Offset: 0x0023C514
		public void ShowLoginButton(bool value = true)
		{
			if (this.mPublish != null)
			{
				this.mPublish.gameObject.CustomActive(value);
				if (!ClientSystemLogin.mSwitchRole && value)
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<PublishContentFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			if (this.mRootServerLst != null)
			{
				this.mRootServerLst.CustomActive(value);
			}
			if (this.mRootClickEnter != null)
			{
				this.mRootClickEnter.CustomActive(false);
			}
		}

		// Token: 0x0600A99B RID: 43419 RVA: 0x0023E1A0 File Offset: 0x0023C5A0
		public void _onSelectChannelSuc(UIEvent uiEvent)
		{
			bool flag = (bool)uiEvent.Param1;
			if (flag)
			{
				ClientSystemManager instance = Singleton<ClientSystemManager>.GetInstance();
				if (instance != null)
				{
					instance._QuitToLoginImpl();
				}
			}
			this.OpenLogin();
		}

		// Token: 0x0600A99C RID: 43420 RVA: 0x0023E1D7 File Offset: 0x0023C5D7
		public override void GetEnterCoroutine(AddCoroutine enter)
		{
			base.GetEnterCoroutine(enter);
			enter(new loadingCoroutine(this._init), string.Empty, 1f);
		}

		// Token: 0x0600A99D RID: 43421 RVA: 0x0023E200 File Offset: 0x0023C600
		private void SetBanQuanMsg()
		{
			this.SetBanQuan(true);
			if (this.banquan_Cot != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.banquan_Cot);
				this.banquan_Cot = null;
			}
			this.banquan_Cot = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._banquanMsg());
		}

		// Token: 0x0600A99E RID: 43422 RVA: 0x0023E24C File Offset: 0x0023C64C
		private IEnumerator _banquanMsg()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.reconnectCnt = 3;
			wt.timeout = 2000;
			string channelName = SDKInterface.instance.GetPlatformNameBySelect();
			wt.url = string.Format("http://{0}/copyright_txt", Global.IOS_BANQUAN_ADDRESS);
			yield return wt;
			if (this.mTishiwenzi_ios != null && wt.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				string resultString = wt.GetResultString();
				if (string.IsNullOrEmpty(resultString))
				{
					this.miosDescBottom.CustomActive(false);
				}
				else
				{
					this.miosDescBottom.CustomActive(true);
					this.mTishiwenzi_ios.text = resultString;
				}
			}
			yield break;
		}

		// Token: 0x0600A99F RID: 43423 RVA: 0x0023E268 File Offset: 0x0023C668
		private IEnumerator _init(IASyncOperation op)
		{
			this._bindEvents();
			ClientSystemLogin.HasPreLoadRoles = false;
			yield return Yielders.EndOfFrame;
			if (!Global.Settings.isUsingSDK && null != this.mAccount)
			{
				this.mAccount.onValueChanged.AddListener(new UnityAction<string>(this._onAccountUpdate));
				this.mAccount.onEndEdit.AddListener(new UnityAction<string>(this._onAccountEndEdit));
			}
			if (this.mAccountRoot != null)
			{
				this.mAccountRoot.CustomActive(true);
			}
			if (this.mPassWordRoot != null)
			{
				this.mPassWordRoot.CustomActive(true);
			}
			this.InitEnterTips();
			this.InitLogoImage();
			this.OpenLogin();
			if (ClientSystemLogin.mOpenUserAgreement && Global.Settings.isUsingSDK)
			{
				if (this.mTgSelUserAgree != null)
				{
					this.mTgSelUserAgree.CustomActive(true);
				}
			}
			else if (this.mTgSelUserAgree != null)
			{
				this.mTgSelUserAgree.CustomActive(false);
			}
			if (ClientSystemLogin.mSwitchRole)
			{
				DataManager<SecurityLockDataManager>.GetInstance().InitiallizeSystem();
				Singleton<ClientSystemManager>.instance.OpenFrame<SelectRoleFrame>(FrameLayer.Bottom, null, string.Empty);
				MonoSingleton<AudioManager>.instance.Stop(this.BkgSoundHandle);
				this.BkgSoundHandle = uint.MaxValue;
			}
			else
			{
				this.BkgSoundHandle = MonoSingleton<AudioManager>.instance.PlaySound("Sound/Login", AudioType.AudioStream, Global.Settings.bgmStart, true, null, false, false, null, 1f);
			}
			GlobalNetMessage.instance.Unload();
			GlobalNetMessage.instance.Load();
			this._SetServerSelection();
			this._updateVersion();
			this._LoadHistoryAccount();
			Singleton<NewbieGuideManager>.instance.Reset();
			if (!Global.Settings.isUsingSDK || ClientApplication.playerinfo.state == PlayerState.LOGIN)
			{
				this._loadPlayerSetting();
				this._forceloadSavedServer();
			}
			yield break;
		}

		// Token: 0x0600A9A0 RID: 43424 RVA: 0x0023E283 File Offset: 0x0023C683
		private void _LoadZhounianSpineAnimation()
		{
			if (this.mLoginSpineRender != null)
			{
				this.mLoginSpineRender.gameObject.CustomActive(true);
				this.mLoginSpineRender.LoadObject("UIFlatten/Animation/denglu_2zhounian/denglu_2zhounian_spine", 31, null);
			}
		}

		// Token: 0x0600A9A1 RID: 43425 RVA: 0x0023E2BA File Offset: 0x0023C6BA
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600A9A2 RID: 43426 RVA: 0x0023E2BC File Offset: 0x0023C6BC
		private IEnumerator _UserAgreementReq()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.url = string.Format("http://{0}/agreement_info?pf={1}&id={2}", Global.USER_AGREEMENT_SERVER_ADDRESS, SDKInterface.instance.GetPlatformNameBySelect(), ClientApplication.playerinfo.openuid);
			yield return wt;
			if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				UserAgreementdata resultJson = wt.GetResultJson<UserAgreementdata>();
				if (resultJson != null)
				{
					this.TryOpenUserAgreementInfoFrame(resultJson);
				}
			}
			yield break;
		}

		// Token: 0x0600A9A3 RID: 43427 RVA: 0x0023E2D8 File Offset: 0x0023C6D8
		private void TryOpenUserAgreementInfoFrame(UserAgreementdata tb)
		{
			if (tb == null)
			{
				return;
			}
			if (tb.err)
			{
				Logger.LogError("Return UserAgreementInfo Protcol error !");
				return;
			}
			if (tb.agree)
			{
				return;
			}
			UserAgreementFrameData userAgreementFrameData = default(UserAgreementFrameData);
			userAgreementFrameData.frameType = UserAgreementFrameType.FirstOpen;
			userAgreementFrameData.PlatFormType = SDKInterface.instance.GetPlatformNameBySelect();
			userAgreementFrameData.OpenUid = ClientApplication.playerinfo.openuid;
			Singleton<ClientSystemManager>.instance.OpenFrame<UserAgreementFrame>(FrameLayer.Middle, userAgreementFrameData, string.Empty);
		}

		// Token: 0x0600A9A4 RID: 43428 RVA: 0x0023E357 File Offset: 0x0023C757
		private void _stopGetUserAgreementInfo()
		{
			if (this.mGetUserAgreementInfo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mGetUserAgreementInfo);
			}
			this.mGetUserAgreementInfo = null;
		}

		// Token: 0x0600A9A5 RID: 43429 RVA: 0x0023E37C File Offset: 0x0023C77C
		private void _loadPlayerSetting()
		{
			object value = PlayerLocalSetting.GetValue("AccountDefault");
			if (!Global.Settings.isUsingSDK && value != null && null != this.mAccount)
			{
				this.mAccount.text = (value as string);
			}
			object value2 = PlayerLocalSetting.GetValue("ServerDefault");
			if (value2 != null)
			{
				this.currentServerName = (value2 as string);
			}
			object value3 = PlayerLocalSetting.GetValue("ServerID");
			if (value3 != null)
			{
				ClientApplication.adminServer.id = uint.Parse(value3.ToString());
			}
		}

		// Token: 0x0600A9A6 RID: 43430 RVA: 0x0023E410 File Offset: 0x0023C810
		protected void _SetServerSelection()
		{
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
			foreach (GlobalSetting.Address addr in Global.Settings.serverList)
			{
				ClientSystemLogin.OptionServerItem optionServerItem = new ClientSystemLogin.OptionServerItem(addr);
				list.Add(optionServerItem);
				if (optionServerItem.text == this.currentServerName)
				{
					int num = list.IndexOf(optionServerItem);
				}
			}
		}

		// Token: 0x0600A9A7 RID: 43431 RVA: 0x0023E47A File Offset: 0x0023C87A
		public sealed override void OnEnter()
		{
			base.OnEnter();
			MonoSingleton<NetManager>.instance.AllowForceReconnect = true;
		}

		// Token: 0x0600A9A8 RID: 43432 RVA: 0x0023E490 File Offset: 0x0023C890
		public override void OnExit()
		{
			MonoSingleton<AssetAsyncLoader>.instance.SetLoadingLimit(4);
			this._unBindEvents();
			if (!Global.Settings.isUsingSDK && null != this.mAccount)
			{
				this.mAccount.onValueChanged.RemoveListener(new UnityAction<string>(this._onAccountUpdate));
				this.mAccount.onEndEdit.RemoveListener(new UnityAction<string>(this._onAccountEndEdit));
			}
			this.newActorName = string.Empty;
			if (!Global.Settings.isUsingSDK)
			{
				string value = string.Empty;
				if (null != this.mAccount)
				{
					value = this.mAccount.text;
				}
				if (!string.IsNullOrEmpty(value))
				{
					PlayerLocalSetting.SetValue("AccountDefault", value);
				}
			}
			if (ClientApplication.adminServer.id > 0U)
			{
				PlayerLocalSetting.SetValue("ServerID", ClientApplication.adminServer.id);
			}
			if (!string.IsNullOrEmpty(this.currentServerName))
			{
				PlayerLocalSetting.SetValue("ServerDefault", this.currentServerName);
			}
			PlayerLocalSetting.SaveConfig();
			string arg = string.Empty;
			ushort num = 0;
			if (ClientApplication.playerinfo != null)
			{
				ulong num2 = (ulong)ClientApplication.playerinfo.accid;
				RoleInfo selectRoleBaseInfoByLogin = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
				if (selectRoleBaseInfoByLogin != null)
				{
					arg = selectRoleBaseInfoByLogin.name;
					num = selectRoleBaseInfoByLogin.level;
				}
			}
			BuglyAgent.SetUserId(string.Format("{0}_{1}", arg, num));
			if (this.BkgSoundHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.BkgSoundHandle);
			}
			if (base.SystemManager.TargetSystem != null)
			{
				Type type = base.SystemManager.TargetSystem.GetType();
				if (type != null && type == typeof(ClientSystemBattle))
				{
					MonoSingleton<ManualPoolCollector>.instance.Clear();
				}
			}
			base.OnExit();
		}

		// Token: 0x0600A9A9 RID: 43433 RVA: 0x0023E668 File Offset: 0x0023CA68
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerListSelectChanged, new ClientEventSystem.UIEventHandler(this._updateSelectServer));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.onSDKLoginSuccess, new ClientEventSystem.UIEventHandler(this._onSDKLoginSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerLoginStart, new ClientEventSystem.UIEventHandler(this._onServerLoginStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerLoginFail, new ClientEventSystem.UIEventHandler(this._onServerLoginFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerLoginFailWithServerConnect, new ClientEventSystem.UIEventHandler(this._onServerLoginFailWithServerConnect));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerLoginSuccess, new ClientEventSystem.UIEventHandler(this._onServerLoginSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ServerLoginQueueWait, new ClientEventSystem.UIEventHandler(this._onServerLoginQueueWait));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.onSelectChannelSuccess, new ClientEventSystem.UIEventHandler(this._onSelectChannelSuc));
		}

		// Token: 0x0600A9AA RID: 43434 RVA: 0x0023E750 File Offset: 0x0023CB50
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerListSelectChanged, new ClientEventSystem.UIEventHandler(this._updateSelectServer));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.onSDKLoginSuccess, new ClientEventSystem.UIEventHandler(this._onSDKLoginSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerLoginStart, new ClientEventSystem.UIEventHandler(this._onServerLoginStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerLoginFail, new ClientEventSystem.UIEventHandler(this._onServerLoginFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerLoginFailWithServerConnect, new ClientEventSystem.UIEventHandler(this._onServerLoginFailWithServerConnect));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerLoginSuccess, new ClientEventSystem.UIEventHandler(this._onServerLoginSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ServerLoginQueueWait, new ClientEventSystem.UIEventHandler(this._onServerLoginQueueWait));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.onSelectChannelSuccess, new ClientEventSystem.UIEventHandler(this._onSelectChannelSuc));
		}

		// Token: 0x0600A9AB RID: 43435 RVA: 0x0023E835 File Offset: 0x0023CC35
		private void _onServerLoginStart(UIEvent ui)
		{
			this.Logining = true;
			this.mLoginStatus = ClientSystemLogin.eLoginStatus.Logining;
			this._startWaitRolesProcess();
		}

		// Token: 0x0600A9AC RID: 43436 RVA: 0x0023E84C File Offset: 0x0023CC4C
		private void _onServerLoginFailWithServerConnect(UIEvent ui)
		{
			eAdminServerStatus state = ClientApplication.adminServer.state;
			if (state != eAdminServerStatus.Offline)
			{
				SystemNotifyManager.SystemNotify(8522, string.Empty);
			}
			else
			{
				SystemNotifyManager.SystemNotify(100001, string.Empty);
			}
		}

		// Token: 0x0600A9AD RID: 43437 RVA: 0x0023E898 File Offset: 0x0023CC98
		private void _onServerLoginFail(UIEvent ui)
		{
			Singleton<ClientReconnectManager>.instance.canRelogin = false;
			Singleton<ClientReconnectManager>.instance.canReconnectGate = false;
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.ADMIN_SERVER);
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.GATE_SERVER);
			Singleton<ClientSystemManager>.instance.CloseFrame<CreateActorFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<SelectRoleFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerWaitQueueUp>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(null, false);
			this.Logining = false;
			this.mLoginStatus = ClientSystemLogin.eLoginStatus.Fail;
			this._stopWaitRolesProcess();
		}

		// Token: 0x0600A9AE RID: 43438 RVA: 0x0023E918 File Offset: 0x0023CD18
		private void _onServerLoginQueueWait(UIEvent ui)
		{
			uint num = (uint)ui.Param1;
			Singleton<ClientSystemManager>.instance.CloseFrame<CreateActorFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<SelectRoleFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(null, false);
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<ServerWaitQueueUp>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ServerWaitQueueUp>(FrameLayer.Middle, num, string.Empty);
			}
			this.Logining = false;
			this.mLoginStatus = ClientSystemLogin.eLoginStatus.WaitQueue;
		}

		// Token: 0x0600A9AF RID: 43439 RVA: 0x0023E98F File Offset: 0x0023CD8F
		private void _onServerLoginSuccess(UIEvent ui)
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerWaitQueueUp>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(null, false);
			this.Logining = false;
			this.mLoginStatus = ClientSystemLogin.eLoginStatus.Success;
		}

		// Token: 0x0600A9B0 RID: 43440 RVA: 0x0023E9B8 File Offset: 0x0023CDB8
		private void _onSDKLoginSuccess(UIEvent ui)
		{
			this.ShowLoginButton(true);
			if (ClientSystemLogin.mOpenUserAgreement && Global.Settings.isUsingSDK && !ClientSystemLogin.mSwitchRole)
			{
				this._stopGetUserAgreementInfo();
				this.mGetUserAgreementInfo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._UserAgreementReq());
			}
			this._loadPlayerSetting();
			this._forceloadSavedServer();
		}

		// Token: 0x0600A9B1 RID: 43441 RVA: 0x0023EA18 File Offset: 0x0023CE18
		private void _updateSelectServer(UIEvent ui)
		{
			if (null == this.mCurServerBind)
			{
				return;
			}
			Image com = this.mCurServerBind.GetCom<Image>("status");
			Text com2 = this.mCurServerBind.GetCom<Text>("name");
			com2.text = ClientApplication.adminServer.name;
			switch (ClientApplication.adminServer.state)
			{
			case eAdminServerStatus.Offline:
				this.mCurServerBind.GetSprite("statusoffline", ref com);
				break;
			case eAdminServerStatus.Ready:
				this.mCurServerBind.GetSprite("statusready", ref com);
				break;
			case eAdminServerStatus.Buzy:
				this.mCurServerBind.GetSprite("statusbuzy", ref com);
				break;
			case eAdminServerStatus.Full:
				this.mCurServerBind.GetSprite("statusfull", ref com);
				break;
			}
		}

		// Token: 0x0600A9B2 RID: 43442 RVA: 0x0023EAF0 File Offset: 0x0023CEF0
		private void _updateServer(Hashtable tb)
		{
			uint id = uint.Parse(tb["id"].ToString());
			string ip = tb["ip"].ToString();
			ushort port = ushort.Parse(tb["port"].ToString());
			int state = int.Parse(tb["status"].ToString());
			string name = tb["name"].ToString();
			ClientApplication.adminServer.ip = ip;
			ClientApplication.adminServer.port = port;
			ClientApplication.adminServer.id = id;
			ClientApplication.adminServer.state = (eAdminServerStatus)state;
			ClientApplication.adminServer.name = name;
			this._updateSelectServer(null);
		}

		// Token: 0x0600A9B3 RID: 43443 RVA: 0x0023EBA4 File Offset: 0x0023CFA4
		private IEnumerator _loadSavedServer()
		{
			bool flag = false;
			this.mLoadingServerStatus = ClientSystemLogin.eLoadingServerState.Loading;
			if (PlayerLocalSetting.GetValue("AccountDefault") != null)
			{
				int cnt = 30;
				int num2;
				do
				{
					yield return Singleton<ServerListManager>.instance.SendHttpReqCharactorUnit();
					if (Singleton<ServerListManager>.instance.IsAllUserReady())
					{
						uint serverId = 0U;
						bool isCheckIdMap = false;
						for (;;)
						{
							serverId = ClientApplication.adminServer.id;
							ArrayList allUser = Singleton<ServerListManager>.instance.allusers;
							for (int i = 0; i < allUser.Count; i++)
							{
								Hashtable hashtable = allUser[i] as Hashtable;
								if (hashtable != null)
								{
									uint num = uint.Parse(hashtable["id"].ToString());
									if (num == serverId || serverId == 0U)
									{
										this._updateServer(hashtable);
										this.mLoadingServerStatus = ClientSystemLogin.eLoadingServerState.Success;
										flag = true;
										break;
									}
								}
							}
							if (isCheckIdMap)
							{
								break;
							}
							if (flag)
							{
								break;
							}
							isCheckIdMap = true;
							yield return Singleton<ServerListManager>.instance.SendHttpReqNodeMap((int)serverId);
							if (Singleton<ServerListManager>.instance.newServerID != -1 && Singleton<ServerListManager>.instance.newServerID != (int)serverId)
							{
								ClientApplication.adminServer.id = (uint)Singleton<ServerListManager>.instance.newServerID;
							}
						}
						IL_1D9:
						if (!flag)
						{
							string param = string.Format("nodes?ids={0}", serverId);
							WaitHttpRequest lastLoginServer = new WaitHttpRequest(param);
							yield return lastLoginServer;
							if (lastLoginServer.GetResult() == BaseWaitHttpRequest.eState.Success)
							{
								ArrayList resultJson = lastLoginServer.GetResultJson();
								if (resultJson.Count > 0)
								{
									this._updateServer(resultJson[0] as Hashtable);
									this.mLoadingServerStatus = ClientSystemLogin.eLoadingServerState.Success;
									flag = true;
								}
							}
						}
						goto IL_2AF;
						goto IL_1D9;
					}
					yield return Yielders.GetWaitForSeconds(1.5f);
					IL_2AF:
					if (Singleton<ServerListManager>.instance.IsAllUserReady())
					{
						break;
					}
					cnt = (num2 = cnt) - 1;
				}
				while (num2 > 0);
			}
			yield return Singleton<ServerListManager>.instance.SendHttpReqTab();
			bool hasGetServer = false;
			if (Singleton<ServerListManager>.instance.IsTabsReady())
			{
				ArrayList tabs = Singleton<ServerListManager>.instance.tabs;
				if (tabs.Count > 0)
				{
					yield return Singleton<ServerListManager>.instance.SendHttpReqRecommondServer();
					if (Singleton<ServerListManager>.instance.IsRecommendServerReady())
					{
						ArrayList recommendServer = Singleton<ServerListManager>.instance.recommendServer;
						if (recommendServer.Count > 0)
						{
							int index = Random.Range(0, recommendServer.Count);
							Hashtable hashtable2 = recommendServer[index] as Hashtable;
							if (hashtable2 != null)
							{
								hasGetServer = true;
								if (!flag)
								{
									this._updateServer(hashtable2);
									this.mLoadingServerStatus = ClientSystemLogin.eLoadingServerState.Success;
								}
							}
						}
					}
				}
			}
			if (!hasGetServer && !flag)
			{
				this.mLoadingServerStatus = ClientSystemLogin.eLoadingServerState.Default;
				DefaultAdminServerTable tableItem;
				if (Global.Settings.isUsingSDK)
				{
					tableItem = Singleton<TableManager>.instance.GetTableItem<DefaultAdminServerTable>(2, string.Empty, string.Empty);
				}
				else
				{
					tableItem = Singleton<TableManager>.instance.GetTableItem<DefaultAdminServerTable>(1, string.Empty, string.Empty);
				}
				if (tableItem != null)
				{
					this._updateServer(new Hashtable
					{
						{
							"id",
							tableItem.ServerID
						},
						{
							"ip",
							tableItem.ServerIP
						},
						{
							"port",
							tableItem.ServerPort
						},
						{
							"name",
							tableItem.ServerName
						},
						{
							"status",
							tableItem.ServerStaus
						}
					});
				}
			}
			yield break;
		}

		// Token: 0x0600A9B4 RID: 43444 RVA: 0x0023EBC0 File Offset: 0x0023CFC0
		private void InitEnterTips()
		{
			if (this.mClickEnterTips != null)
			{
				string text = TR.Value("ComGameEnterTip");
				if (Global.Settings.sdkChannel == SDKChannel.HuaWei)
				{
					text = TR.Value("ComGameEnterTipHuawei");
					this.mClickEnterTips.verticalOverflow = 1;
					this.mClickEnterTips.alignment = 1;
				}
				this.mClickEnterTips.text = text;
			}
			if (this.mBtnClickEnter)
			{
				this.mBtnClickEnter.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600A9B5 RID: 43445 RVA: 0x0023EC4C File Offset: 0x0023D04C
		private void InitLogoImage()
		{
			if (this.mTitle != null)
			{
				string sdklogoPath = PluginManager.GetSDKLogoPath(SDKInterface.SDKLogoType.LoginLogo);
				if (string.IsNullOrEmpty(sdklogoPath))
				{
					return;
				}
				ETCImageLoader.LoadSprite(ref this.mTitle, sdklogoPath, true);
			}
		}

		// Token: 0x0600A9B6 RID: 43446 RVA: 0x0023EC8C File Offset: 0x0023D08C
		[MessageHandle(308601U, false, 0)]
		private void OnSyncAdventureTeamInfo(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			AdventureTeamInfoSync adventureTeamInfoSync = new AdventureTeamInfoSync();
			adventureTeamInfoSync.decode(msg.bytes);
			ClientApplication.playerinfo.adventureTeamInfo = adventureTeamInfoSync.info;
		}

		// Token: 0x0600A9B7 RID: 43447 RVA: 0x0023ECC4 File Offset: 0x0023D0C4
		[MessageHandle(300324U, false, 0)]
		private void SyncIOSFunctionSwitchRes(MsgDATA data)
		{
			GateNotifySysSwitch gateNotifySysSwitch = new GateNotifySysSwitch();
			gateNotifySysSwitch.decode(data.bytes);
			Singleton<IOSFunctionSwitchManager>.GetInstance().AddClosedFunctions(gateNotifySysSwitch);
		}

		// Token: 0x04005EA7 RID: 24231
		private GameObject mrroot;

		// Token: 0x04005EA8 RID: 24232
		private GameObject mAccountRoot;

		// Token: 0x04005EA9 RID: 24233
		private GameObject mPassWordRoot;

		// Token: 0x04005EAA RID: 24234
		private Text mVersionCode;

		// Token: 0x04005EAB RID: 24235
		private ComCommonBind mCurServerBind;

		// Token: 0x04005EAC RID: 24236
		private Text mPackedInfo;

		// Token: 0x04005EAD RID: 24237
		private InputField mPassword;

		// Token: 0x04005EAE RID: 24238
		private InputField mAccount;

		// Token: 0x04005EAF RID: 24239
		private Button mSelectServer;

		// Token: 0x04005EB0 RID: 24240
		private Button mPublish;

		// Token: 0x04005EB1 RID: 24241
		private Button mLogin;

		// Token: 0x04005EB2 RID: 24242
		private Button mLoginReg;

		// Token: 0x04005EB3 RID: 24243
		private GameObject mRootServerLst;

		// Token: 0x04005EB4 RID: 24244
		private GameObject mRootClickEnter;

		// Token: 0x04005EB5 RID: 24245
		private Text mClickEnterTips;

		// Token: 0x04005EB6 RID: 24246
		private Button mBtnClickEnter;

		// Token: 0x04005EB7 RID: 24247
		private Toggle mTgSelUserAgree;

		// Token: 0x04005EB8 RID: 24248
		private Button mUserAgreement;

		// Token: 0x04005EB9 RID: 24249
		private Button mUploadCompress;

		// Token: 0x04005EBA RID: 24250
		private GeObjectRenderer mLoginSpineRender;

		// Token: 0x04005EBB RID: 24251
		private Button mSecretAgreement;

		// Token: 0x04005EBC RID: 24252
		private GameObject mRegRoot;

		// Token: 0x04005EBD RID: 24253
		private InputField mRAccount;

		// Token: 0x04005EBE RID: 24254
		private InputField mRPassword1;

		// Token: 0x04005EBF RID: 24255
		private InputField mRPassword2;

		// Token: 0x04005EC0 RID: 24256
		private InputField mRCPS;

		// Token: 0x04005EC1 RID: 24257
		private Button regBack;

		// Token: 0x04005EC2 RID: 24258
		private Button regEnter;

		// Token: 0x04005EC3 RID: 24259
		private GameObject mImage_bg1;

		// Token: 0x04005EC4 RID: 24260
		private GameObject mImage_bg2;

		// Token: 0x04005EC5 RID: 24261
		private GameObject mTishiwenzi;

		// Token: 0x04005EC6 RID: 24262
		private GameObject mVr;

		// Token: 0x04005EC7 RID: 24263
		private GameObject mIosDescRoot;

		// Token: 0x04005EC8 RID: 24264
		private Text mTishiwenzi_ios;

		// Token: 0x04005EC9 RID: 24265
		private Text mVersion_ios;

		// Token: 0x04005ECA RID: 24266
		private Text mPackageInfo_ios;

		// Token: 0x04005ECB RID: 24267
		private GameObject miosDescBottom;

		// Token: 0x04005ECC RID: 24268
		private Button mBtnRepaire;

		// Token: 0x04005ECD RID: 24269
		private Image mTitle;

		// Token: 0x04005ECE RID: 24270
		private GameObject mLocalLogin;

		// Token: 0x04005ECF RID: 24271
		private InputField mParam;

		// Token: 0x04005ED0 RID: 24272
		private InputField mHashValue;

		// Token: 0x04005ED1 RID: 24273
		private InputField mTableMd5;

		// Token: 0x04005ED2 RID: 24274
		private InputField mSkillMd5;

		// Token: 0x04005ED3 RID: 24275
		private InputField mSv;

		// Token: 0x04005ED4 RID: 24276
		public static bool mswitchrole;

		// Token: 0x04005ED5 RID: 24277
		protected string currentServerName;

		// Token: 0x04005ED6 RID: 24278
		protected uint BkgSoundHandle = uint.MaxValue;

		// Token: 0x04005ED7 RID: 24279
		protected List<string> HistoryAccount = new List<string>();

		// Token: 0x04005ED8 RID: 24280
		protected string newActorName = string.Empty;

		// Token: 0x04005ED9 RID: 24281
		private bool mIsLogining;

		// Token: 0x04005EDA RID: 24282
		private bool mAutoEnterToRoleSelect;

		// Token: 0x04005EDB RID: 24283
		private Coroutine mGetUserAgreementInfo;

		// Token: 0x04005EDC RID: 24284
		public static bool mOpenUserAgreement;

		// Token: 0x04005EDD RID: 24285
		private ClientSystemLogin.eLoginStatus mLoginStatus;

		// Token: 0x04005EDE RID: 24286
		protected static bool HasPreLoadRoles;

		// Token: 0x04005EDF RID: 24287
		private Coroutine mWaitRolesProcessCo;

		// Token: 0x04005EE0 RID: 24288
		private bool mIsGetGateSendRoleInfo;

		// Token: 0x04005EE1 RID: 24289
		private Coroutine mCurrentLoadServerCo;

		// Token: 0x04005EE2 RID: 24290
		private Coroutine banquan_Cot;

		// Token: 0x04005EE3 RID: 24291
		private ClientSystemLogin.eLoadingServerState mLoadingServerStatus;

		// Token: 0x0200115A RID: 4442
		private enum eLoginStatus
		{
			// Token: 0x04005EE6 RID: 24294
			None,
			// Token: 0x04005EE7 RID: 24295
			Logining,
			// Token: 0x04005EE8 RID: 24296
			WaitQueue,
			// Token: 0x04005EE9 RID: 24297
			Fail,
			// Token: 0x04005EEA RID: 24298
			Success
		}

		// Token: 0x0200115B RID: 4443
		public class OptionServerItem : Dropdown.OptionData
		{
			// Token: 0x0600A9BA RID: 43450 RVA: 0x0023ED04 File Offset: 0x0023D104
			public OptionServerItem(GlobalSetting.Address addr)
			{
				this.addr = addr;
				base.text = addr.ToString();
			}

			// Token: 0x04005EEB RID: 24299
			public GlobalSetting.Address addr;
		}

		// Token: 0x0200115C RID: 4444
		private enum eLoadingServerState
		{
			// Token: 0x04005EED RID: 24301
			None,
			// Token: 0x04005EEE RID: 24302
			Loading,
			// Token: 0x04005EEF RID: 24303
			Success,
			// Token: 0x04005EF0 RID: 24304
			Error,
			// Token: 0x04005EF1 RID: 24305
			Default
		}
	}
}
