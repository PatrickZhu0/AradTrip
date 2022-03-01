using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02000220 RID: 544
	internal class VersionSwitchController
	{
		// Token: 0x0600121E RID: 4638 RVA: 0x00062978 File Offset: 0x00060D78
		public void UpdateSwitch(string switchJson)
		{
			if (string.IsNullOrEmpty(switchJson))
			{
				return;
			}
			Hashtable hashtable = this._GetJsonHashtable(switchJson);
			if (hashtable == null)
			{
				return;
			}
			VersionSwitch<bool> versionSwitch = this._GetSwitchFromJson<bool>(hashtable, VersionSwitchController.SWITCH_KEYS[VersionSwitchController.SwitchType.Agreement]);
			if (versionSwitch != null)
			{
				ClientSystemLogin.mOpenUserAgreement = versionSwitch.GetSwitchValue();
			}
			VersionSwitch<SDKChannel> versionSwitch2 = this._GetSwitchFromJson<SDKChannel>(hashtable, VersionSwitchController.SWITCH_KEYS[VersionSwitchController.SwitchType.VipAuth]);
			if (versionSwitch2 != null)
			{
				Global.VipAuthSDKChannel = versionSwitch2.GetSwitchValues();
			}
			VersionSwitch<SDKChannel> versionSwitch3 = this._GetSwitchFromJson<SDKChannel>(hashtable, VersionSwitchController.SWITCH_KEYS[VersionSwitchController.SwitchType.RealNameAuth]);
			if (versionSwitch3 != null)
			{
				Global.RealNamePopWindowsChannel = versionSwitch3.GetSwitchValues();
			}
			VersionSwitch<SDKChannel> versionSwitch4 = this._GetSwitchFromJson<SDKChannel>(hashtable, VersionSwitchController.SWITCH_KEYS[VersionSwitchController.SwitchType.SdkPush]);
			if (versionSwitch4 != null)
			{
				Global.SDKPushChannel = versionSwitch4.GetSwitchValues();
			}
			VersionSwitch<SDKChannel> versionSwitch5 = this._GetSwitchFromJson<SDKChannel>(hashtable, VersionSwitchController.SWITCH_KEYS[VersionSwitchController.SwitchType.SelectChannel]);
			if (versionSwitch5 != null)
			{
				Global.openSelectChannels = versionSwitch5.GetSwitchValues();
			}
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x00062A5C File Offset: 0x00060E5C
		private Hashtable _GetJsonHashtable(string jsonData)
		{
			if (string.IsNullOrEmpty(jsonData))
			{
				return null;
			}
			try
			{
				Hashtable hashtable = MiniJSON.jsonDecode(jsonData) as Hashtable;
				if (hashtable != null)
				{
					return hashtable;
				}
				Debug.LogFormat("[_GetSwitchFromJson] json data : {0},  convert to json failed !", new object[]
				{
					jsonData
				});
			}
			catch (Exception ex)
			{
				Debug.LogFormat("[_GetSwitchFromJson] json data : {0},  convert to json failed ! {1}", new object[]
				{
					jsonData,
					ex.ToString()
				});
			}
			return null;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00062AE0 File Offset: 0x00060EE0
		private VersionSwitch<T> _GetSwitchFromJson<T>(Hashtable jsonData, string switchKey)
		{
			try
			{
				if (jsonData == null)
				{
					return null;
				}
				if (jsonData.ContainsKey(switchKey))
				{
					string text = jsonData[switchKey] as string;
					if (!string.IsNullOrEmpty(text))
					{
						return new VersionSwitch<T>(switchKey, text);
					}
					Debug.LogFormat("[_GetSwitchFromJson] switch key : {0}, value not string format", new object[]
					{
						switchKey
					});
				}
				else
				{
					Debug.LogFormat("[_GetSwitchFromJson] switch key : {0}, not found !", new object[]
					{
						switchKey
					});
				}
			}
			catch (Exception ex)
			{
				Debug.LogFormat("[_GetSwitchFromJson] switch key : {0}, get switch failed : {1} !", new object[]
				{
					switchKey,
					ex.ToString()
				});
			}
			return null;
		}

		// Token: 0x04000C0C RID: 3084
		public static readonly string VERSION_SWITCH_FILE_NAME = "version_switch.json";

		// Token: 0x04000C0D RID: 3085
		public static readonly string SWITCH_PATH_ROOT = "version_switch";

		// Token: 0x04000C0E RID: 3086
		protected static readonly Dictionary<VersionSwitchController.SwitchType, string> SWITCH_KEYS = new Dictionary<VersionSwitchController.SwitchType, string>
		{
			{
				VersionSwitchController.SwitchType.Agreement,
				"agreement"
			},
			{
				VersionSwitchController.SwitchType.AgreementNew,
				"agreementnew"
			},
			{
				VersionSwitchController.SwitchType.VipAuth,
				"vipauth"
			},
			{
				VersionSwitchController.SwitchType.RealNameAuth,
				"realnameauth"
			},
			{
				VersionSwitchController.SwitchType.SdkPush,
				"sdkpush"
			},
			{
				VersionSwitchController.SwitchType.SelectChannel,
				"selectchannel"
			}
		};

		// Token: 0x02000221 RID: 545
		public enum SwitchType
		{
			// Token: 0x04000C10 RID: 3088
			Agreement,
			// Token: 0x04000C11 RID: 3089
			AgreementNew,
			// Token: 0x04000C12 RID: 3090
			VipAuth,
			// Token: 0x04000C13 RID: 3091
			RealNameAuth,
			// Token: 0x04000C14 RID: 3092
			SdkPush,
			// Token: 0x04000C15 RID: 3093
			SelectChannel
		}
	}
}
