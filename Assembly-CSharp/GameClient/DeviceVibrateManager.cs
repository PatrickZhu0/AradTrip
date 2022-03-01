using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004696 RID: 18070
	public class DeviceVibrateManager : Singleton<DeviceVibrateManager>
	{
		// Token: 0x060198B6 RID: 104630 RVA: 0x0080D8A4 File Offset: 0x0080BCA4
		private string _GetVibrateSwitchKeyByType(VibrateSwitchType type)
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (ClientApplication.playerinfo != null)
			{
				arg = ClientApplication.playerinfo.serverID.ToString();
			}
			if (DataManager<PlayerBaseData>.GetInstance() != null)
			{
				arg2 = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
			}
			return string.Format(TR.Value("vibrate_settings_key"), arg, arg2, type.ToString());
		}

		// Token: 0x060198B7 RID: 104631 RVA: 0x0080D920 File Offset: 0x0080BD20
		public bool CheckVibrateSwitchOpen(VibrateSwitchType type)
		{
			string text = this._GetVibrateSwitchKeyByType(type);
			return !PlayerPrefs.HasKey(text) || PlayerPrefs.GetInt(text) == 1;
		}

		// Token: 0x060198B8 RID: 104632 RVA: 0x0080D958 File Offset: 0x0080BD58
		public void SetVibrateSwitch(VibrateSwitchType type, bool bOpen)
		{
			string text = this._GetVibrateSwitchKeyByType(type);
			PlayerPrefs.SetInt(text, (!bOpen) ? 0 : 1);
			if (PlayerPrefs.HasKey(text))
			{
			}
		}

		// Token: 0x060198B9 RID: 104633 RVA: 0x0080D98B File Offset: 0x0080BD8B
		public void TriggerDeviceVibrateByType(VibrateSwitchType type)
		{
			if (this.CheckVibrateSwitchOpen(type))
			{
				Singleton<PluginManager>.GetInstance().TriggerMobileVibrate();
			}
		}
	}
}
