using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001A0D RID: 6669
	public class SettingManager : Singleton<SettingManager>
	{
		// Token: 0x060105E9 RID: 67049 RVA: 0x00499D08 File Offset: 0x00498108
		public InputManager.JoystickMode GetJoystickMode()
		{
			InputManager.JoystickMode result = InputManager.JoystickMode.DYNAMIC;
			if (PlayerLocalSetting.GetValue("SETTING_JOYSTICK1") != null && (string)PlayerLocalSetting.GetValue("SETTING_JOYSTICK1") == "static")
			{
				result = InputManager.JoystickMode.STATIC;
			}
			return result;
		}

		// Token: 0x060105EA RID: 67050 RVA: 0x00499D47 File Offset: 0x00498147
		public void SetJoystickMode(InputManager.JoystickMode mode)
		{
			PlayerLocalSetting.SetValue("SETTING_JOYSTICK1", (mode != InputManager.JoystickMode.DYNAMIC) ? "static" : "dynamic");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105EB RID: 67051 RVA: 0x00499D6D File Offset: 0x0049816D
		public void SetJoystickDir(InputManager.JoystickDir mode)
		{
			PlayerLocalSetting.SetValue("STR_JOYSTICKDIR", (mode != InputManager.JoystickDir.MORE_DIR) ? "eightDir" : "moreDir");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105EC RID: 67052 RVA: 0x00499D94 File Offset: 0x00498194
		public InputManager.JoystickDir GetJoystickDir()
		{
			InputManager.JoystickDir result = InputManager.JoystickDir.MORE_DIR;
			if (PlayerLocalSetting.GetValue("STR_JOYSTICKDIR") != null && (string)PlayerLocalSetting.GetValue("STR_JOYSTICKDIR") == "eightDir")
			{
				result = InputManager.JoystickDir.EIGHT_DIR;
			}
			return result;
		}

		// Token: 0x060105ED RID: 67053 RVA: 0x00499DD4 File Offset: 0x004981D4
		public void SetJoystickDirAdjust(float value)
		{
			PlayerLocalSetting.SetValue("STR_JOYSTICKDIR_ADJUST", ((int)(value * 1000f)).ToString());
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105EE RID: 67054 RVA: 0x00499E08 File Offset: 0x00498208
		public float GetJoystickDirAdjust()
		{
			int num = 500;
			object value = PlayerLocalSetting.GetValue("STR_JOYSTICKDIR_ADJUST");
			if (value != null)
			{
				num = Convert.ToInt32(value);
			}
			return (float)num / 1000f;
		}

		// Token: 0x060105EF RID: 67055 RVA: 0x00499E3C File Offset: 0x0049823C
		public InputManager.RunAttackMode GetRunAttackMode()
		{
			return InputManager.RunAttackMode.NORMAL;
		}

		// Token: 0x060105F0 RID: 67056 RVA: 0x00499E4C File Offset: 0x0049824C
		public void SetRunAttackMode(InputManager.RunAttackMode mode)
		{
			PlayerLocalSetting.SetValue("SETTING_RUNATTACK", (mode != InputManager.RunAttackMode.NORMAL) ? "qte" : "normal");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105F1 RID: 67057 RVA: 0x00499E74 File Offset: 0x00498274
		public InputManager.CameraShockMode GetCameraShockMode()
		{
			InputManager.CameraShockMode result = InputManager.CameraShockMode.OPEN;
			if (PlayerLocalSetting.GetValue("STR_SHOCKEFFECT") != null && (string)PlayerLocalSetting.GetValue("STR_SHOCKEFFECT") == "close")
			{
				result = InputManager.CameraShockMode.CLOSE;
			}
			return result;
		}

		// Token: 0x060105F2 RID: 67058 RVA: 0x00499EB3 File Offset: 0x004982B3
		public void SetCameraShockMode(InputManager.CameraShockMode mode)
		{
			PlayerLocalSetting.SetValue("STR_SHOCKEFFECT", (mode != InputManager.CameraShockMode.OPEN) ? "close" : "open");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105F3 RID: 67059 RVA: 0x00499EDC File Offset: 0x004982DC
		public InputManager.PaladinAttack GetPaladinAttack()
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(41, string.Empty, string.Empty);
			if (tableItem == null || !tableItem.Open)
			{
				return InputManager.PaladinAttack.OPEN;
			}
			if (PlayerLocalSetting.GetValue("SETTING_PALADINATTACK") == null)
			{
				return (tableItem.ValueA != 0) ? InputManager.PaladinAttack.OPEN : InputManager.PaladinAttack.CLOSE;
			}
			if ((string)PlayerLocalSetting.GetValue("SETTING_PALADINATTACK") == "open")
			{
				return InputManager.PaladinAttack.OPEN;
			}
			return InputManager.PaladinAttack.CLOSE;
		}

		// Token: 0x060105F4 RID: 67060 RVA: 0x00499F56 File Offset: 0x00498356
		public void SetPaladinAttack(InputManager.PaladinAttack flag)
		{
			PlayerLocalSetting.SetValue("SETTING_PALADINATTACK", (flag != InputManager.PaladinAttack.CLOSE) ? "open" : "close");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105F5 RID: 67061 RVA: 0x00499F80 File Offset: 0x00498380
		public bool GetLiGuiValue(string key)
		{
			bool result = this.GetValue(key);
			if (PlayerLocalSetting.GetValue(key) == null && key == "SETTING_LIGUI")
			{
				result = SwitchFunctionUtility.IsOpen(25);
			}
			if (key == "SETTING_LIGUI" && !SwitchFunctionUtility.IsOpen(24))
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060105F6 RID: 67062 RVA: 0x00499FDC File Offset: 0x004983DC
		public InputManager.SlideSetting GetSlideMode(string key)
		{
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return InputManager.SlideSetting.NORMAL;
			}
			int num = 0;
			switch (key)
			{
			case "1204":
				num = 17;
				break;
			case "1007":
				num = 18;
				break;
			case "2010":
				num = 19;
				break;
			case "1512":
				num = 20;
				break;
			case "1216":
				num = 49;
				break;
			case "3600":
				num = 36;
				break;
			case "3608":
				num = 37;
				break;
			case "3713":
				num = 54;
				break;
			case "1218":
				num = 56;
				break;
			case "2611":
				num = 43;
				break;
			case "2301":
				num = 66;
				break;
			case "2302":
				num = 68;
				break;
			case "1608":
				num = 70;
				break;
			case "1006":
				num = 71;
				break;
			case "1104":
				num = 72;
				break;
			case "3612":
				num = 108;
				break;
			}
			if (num == 0)
			{
				return InputManager.SlideSetting.NORMAL;
			}
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return InputManager.SlideSetting.NORMAL;
			}
			if (!tableItem.Open)
			{
				return InputManager.SlideSetting.NORMAL;
			}
			InputManager.SlideSetting result = InputManager.SlideSetting.NORMAL;
			if (PlayerLocalSetting.GetValue(key) != null && (string)PlayerLocalSetting.GetValue(key) == "slide")
			{
				result = InputManager.SlideSetting.SLIDE;
			}
			return result;
		}

		// Token: 0x060105F7 RID: 67063 RVA: 0x0049A222 File Offset: 0x00498622
		public void SetSlideMode(InputManager.SlideSetting mode, string key)
		{
			PlayerLocalSetting.SetValue(key, (mode != InputManager.SlideSetting.NORMAL) ? "slide" : "normal");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x060105F8 RID: 67064 RVA: 0x0049A244 File Offset: 0x00498644
		public int GetChaserSetting(string key)
		{
			string key2 = string.Format("{0}{1}", key, DataManager<PlayerBaseData>.GetInstance().RoleID);
			return this.GetValueInt(key2);
		}

		// Token: 0x060105F9 RID: 67065 RVA: 0x0049A274 File Offset: 0x00498674
		public void SetChaserSetting(string key, int value)
		{
			string key2 = string.Format("{0}{1}", key, DataManager<PlayerBaseData>.GetInstance().RoleID);
			this.SetValue(key2, value);
		}

		// Token: 0x060105FA RID: 67066 RVA: 0x0049A2A4 File Offset: 0x004986A4
		public bool GetVipSettingData(string key, string roleId)
		{
			string key2 = string.Format("{0}{1}", key, roleId);
			return this.GetValue(key2);
		}

		// Token: 0x060105FB RID: 67067 RVA: 0x0049A2C8 File Offset: 0x004986C8
		public void SetVipSettingData(string key, bool value)
		{
			string key2 = string.Format("{0}{1}", key, DataManager<PlayerBaseData>.GetInstance().RoleID);
			this.SetValue(key2, value);
		}

		// Token: 0x060105FC RID: 67068 RVA: 0x0049A2F8 File Offset: 0x004986F8
		public SettingManager.SetCommonType GetCommmonSet(string key)
		{
			string text = (string)PlayerLocalSetting.GetValue(key);
			if (string.IsNullOrEmpty(text))
			{
				if (Singleton<GeGraphicSetting>.instance.IsHighLevel() || Singleton<GeGraphicSetting>.instance.IsMiddleLevel())
				{
					return SettingManager.SetCommonType.Open;
				}
				return SettingManager.SetCommonType.Close;
			}
			else
			{
				if (text.Equals("open"))
				{
					return SettingManager.SetCommonType.Open;
				}
				return SettingManager.SetCommonType.Close;
			}
		}

		// Token: 0x060105FD RID: 67069 RVA: 0x0049A351 File Offset: 0x00498751
		public void SetCommomData(string key, string value)
		{
			PlayerLocalSetting.SetValue(key, value);
		}

		// Token: 0x060105FE RID: 67070 RVA: 0x0049A35C File Offset: 0x0049875C
		public bool GetValue(string key)
		{
			bool result = false;
			if (PlayerLocalSetting.GetValue(key) != null && (string)PlayerLocalSetting.GetValue(key) == "true")
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060105FF RID: 67071 RVA: 0x0049A394 File Offset: 0x00498794
		public bool GetValueWithDefault(string key, bool defaultRet)
		{
			bool result = defaultRet;
			if (PlayerLocalSetting.GetValue(key) != null)
			{
				result = ((string)PlayerLocalSetting.GetValue(key) == "true");
			}
			return result;
		}

		// Token: 0x06010600 RID: 67072 RVA: 0x0049A3C8 File Offset: 0x004987C8
		public int GetValueInt(string key)
		{
			int result = 0;
			if (PlayerLocalSetting.GetValue(key) != null)
			{
				int.TryParse(PlayerLocalSetting.GetValue(key).ToString(), out result);
			}
			return result;
		}

		// Token: 0x06010601 RID: 67073 RVA: 0x0049A3F6 File Offset: 0x004987F6
		public void SetValue(string key, bool value)
		{
			PlayerLocalSetting.SetValue(key, (!value) ? "false" : "true");
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x06010602 RID: 67074 RVA: 0x0049A418 File Offset: 0x00498818
		public void SetValue(string key, int value)
		{
			PlayerLocalSetting.SetValue(key, value);
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x0400A60B RID: 42507
		public const string STR_JOYSTICKMODE = "SETTING_JOYSTICK1";

		// Token: 0x0400A60C RID: 42508
		public const string STR_JOYSTICKDIR = "STR_JOYSTICKDIR";

		// Token: 0x0400A60D RID: 42509
		public const string STR_JOYSTICKDIR_ADJUST = "STR_JOYSTICKDIR_ADJUST";

		// Token: 0x0400A60E RID: 42510
		public const string STR_RUNATTACKMODE = "SETTING_RUNATTACK";

		// Token: 0x0400A60F RID: 42511
		public const string STR_SHOCKEFFECT = "STR_SHOCKEFFECT";

		// Token: 0x0400A610 RID: 42512
		public const string STR_PALADINATTACK = "SETTING_PALADINATTACK";

		// Token: 0x0400A611 RID: 42513
		public const string STR_LIGUI = "SETTING_LIGUI";

		// Token: 0x0400A612 RID: 42514
		public const string STR_BACKHIT = "STR_BACKHIT";

		// Token: 0x0400A613 RID: 42515
		public const string STR_AUTOHIT = "STR_AUTOHIT";

		// Token: 0x0400A614 RID: 42516
		public const string STR_CHASER_SWITCH = "STR_CHASER_SWITCH";

		// Token: 0x0400A615 RID: 42517
		public const string STR_CHASER_PVE = "STR_CHASER_PVE";

		// Token: 0x0400A616 RID: 42518
		public const string STR_CHASER_PVP = "STR_CHASER_PVP";

		// Token: 0x0400A617 RID: 42519
		public const string STR_VIPDRUG = "SETTING_VIPDRUG";

		// Token: 0x0400A618 RID: 42520
		public const string STR_VIPPREFER = "STR_VIPPREFER";

		// Token: 0x0400A619 RID: 42521
		public const string STR_VIPHP = "STR_VIPHP";

		// Token: 0x0400A61A RID: 42522
		public const string STR_VIPREBORN = "SETTING_VIPREBORN";

		// Token: 0x0400A61B RID: 42523
		public const string STR_VIPCRYSTAL = "SETTING_VIPCRYSTAL";

		// Token: 0x0400A61C RID: 42524
		public const string STR_SUMMONDISPLAY = "SETTING_SUMMONDISSET";

		// Token: 0x0400A61D RID: 42525
		public const string STR_SKILLEFFECTDISPLAY = "SETTING_SKILLEFFECTSET";

		// Token: 0x0400A61E RID: 42526
		public const string STR_HITNUMDISPLAY = "SETTING_HITNUMSET";

		// Token: 0x0400A61F RID: 42527
		public const string STR_TITLEDISPLAY = "SETTING_TITLESET";

		// Token: 0x0400A620 RID: 42528
		public const string STR_SETTING_HALO = "SETTING_ACTOR_HALO";

		// Token: 0x0400A621 RID: 42529
		public const string STR_TITLEDISPLAYPVP = "SETTING_TITLESETPVP";

		// Token: 0x0400A622 RID: 42530
		public const string STR_PETDISPLAY = "SETTING_PETDISPLAY";

		// Token: 0x0400A623 RID: 42531
		public const int vipDrugTableId = 30;

		// Token: 0x0400A624 RID: 42532
		public const int vipRebornTableId = 31;

		// Token: 0x0400A625 RID: 42533
		public const int vipUseCrystalTableId = 32;

		// Token: 0x0400A626 RID: 42534
		public const int vipPreferTableId = 28;

		// Token: 0x02001A0E RID: 6670
		public enum SetCommonType
		{
			// Token: 0x0400A629 RID: 42537
			None = -1,
			// Token: 0x0400A62A RID: 42538
			Close,
			// Token: 0x0400A62B RID: 42539
			Open
		}
	}
}
