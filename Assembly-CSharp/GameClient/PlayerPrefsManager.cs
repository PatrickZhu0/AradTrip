using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004643 RID: 17987
	public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
	{
		// Token: 0x06019459 RID: 103513 RVA: 0x008001EC File Offset: 0x007FE5EC
		public string GetType_ServerId_RoleId_Key(PlayerPrefsManager.PlayerPrefsKeyType keyType, params object[] extraStr)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return string.Empty;
			}
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
			if (extraStr == null || extraStr.Length <= 0)
			{
				return string.Format(PlayerPrefsManager.format_keyType_serverId_roleId, keyType.ToString(), arg, arg2);
			}
			string format = "{0}";
			string text = string.Format(format, keyType.ToString());
			for (int i = 0; i < extraStr.Length; i++)
			{
				int num = i;
				text += string.Format("_{{{0}}}", num);
			}
			string arg3 = string.Format(text, extraStr);
			return string.Format(PlayerPrefsManager.format_keyType_serverId_roleId, arg3, arg, arg2);
		}

		// Token: 0x0601945A RID: 103514 RVA: 0x008002F0 File Offset: 0x007FE6F0
		public string HasType_ServerId_RoleId_Key(PlayerPrefsManager.PlayerPrefsKeyType keyType, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return string.Empty;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return string.Empty;
			}
			if (!PlayerPrefs.HasKey(type_ServerId_RoleId_Key))
			{
				return string.Empty;
			}
			return type_ServerId_RoleId_Key;
		}

		// Token: 0x0601945B RID: 103515 RVA: 0x00800340 File Offset: 0x007FE740
		public string HasTypeKey(PlayerPrefsManager.PlayerPrefsKeyType keyType)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return string.Empty;
			}
			string text = keyType.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			if (!PlayerPrefs.HasKey(text))
			{
				return string.Empty;
			}
			return text;
		}

		// Token: 0x0601945C RID: 103516 RVA: 0x00800394 File Offset: 0x007FE794
		public void SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, int value, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return;
			}
			PlayerPrefs.SetInt(type_ServerId_RoleId_Key, value);
			PlayerPrefs.Save();
		}

		// Token: 0x0601945D RID: 103517 RVA: 0x008003D4 File Offset: 0x007FE7D4
		public void SetTypeKeyFloatValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, float value, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return;
			}
			PlayerPrefs.SetFloat(type_ServerId_RoleId_Key, value);
			PlayerPrefs.Save();
		}

		// Token: 0x0601945E RID: 103518 RVA: 0x00800414 File Offset: 0x007FE814
		public void SetTypeKeyStringValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, string value, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return;
			}
			PlayerPrefs.SetString(type_ServerId_RoleId_Key, value);
			PlayerPrefs.Save();
		}

		// Token: 0x0601945F RID: 103519 RVA: 0x00800454 File Offset: 0x007FE854
		public void SetTypeKeyStringValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType keyType, string value)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return;
			}
			string text = keyType.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			PlayerPrefs.SetString(text, value);
			PlayerPrefs.Save();
		}

		// Token: 0x06019460 RID: 103520 RVA: 0x00800498 File Offset: 0x007FE898
		public void SetTypeKeyIntValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType keyType, int value)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return;
			}
			string text = keyType.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			PlayerPrefs.SetInt(text, value);
			PlayerPrefs.Save();
		}

		// Token: 0x06019461 RID: 103521 RVA: 0x008004DC File Offset: 0x007FE8DC
		public int GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return 0;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return 0;
			}
			if (!PlayerPrefs.HasKey(type_ServerId_RoleId_Key))
			{
				return 0;
			}
			return PlayerPrefs.GetInt(type_ServerId_RoleId_Key);
		}

		// Token: 0x06019462 RID: 103522 RVA: 0x00800522 File Offset: 0x007FE922
		public int GetTypeKeyIntValue(string typeKey)
		{
			if (string.IsNullOrEmpty(typeKey))
			{
				return 0;
			}
			return PlayerPrefs.GetInt(typeKey);
		}

		// Token: 0x06019463 RID: 103523 RVA: 0x00800538 File Offset: 0x007FE938
		public float GetTypeKeyFloatValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return 0f;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return 0f;
			}
			if (!PlayerPrefs.HasKey(type_ServerId_RoleId_Key))
			{
				return 0f;
			}
			return PlayerPrefs.GetFloat(type_ServerId_RoleId_Key);
		}

		// Token: 0x06019464 RID: 103524 RVA: 0x0080058C File Offset: 0x007FE98C
		public string GetTypeKeyStringValue(PlayerPrefsManager.PlayerPrefsKeyType keyType, params object[] extraKeyTypes)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return string.Empty;
			}
			string type_ServerId_RoleId_Key = this.GetType_ServerId_RoleId_Key(keyType, extraKeyTypes);
			if (string.IsNullOrEmpty(type_ServerId_RoleId_Key))
			{
				return string.Empty;
			}
			if (!PlayerPrefs.HasKey(type_ServerId_RoleId_Key))
			{
				return string.Empty;
			}
			return PlayerPrefs.GetString(type_ServerId_RoleId_Key);
		}

		// Token: 0x06019465 RID: 103525 RVA: 0x008005E0 File Offset: 0x007FE9E0
		public string GetTypeKeyStringValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType keyType)
		{
			if (keyType == PlayerPrefsManager.PlayerPrefsKeyType.None || keyType == PlayerPrefsManager.PlayerPrefsKeyType.Count)
			{
				return string.Empty;
			}
			string text = keyType.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			if (!PlayerPrefs.HasKey(text))
			{
				return string.Empty;
			}
			return PlayerPrefs.GetString(text);
		}

		// Token: 0x04012258 RID: 74328
		private static readonly string format_keyType_serverId_roleId = "{0}_{1}_{2}";

		// Token: 0x04012259 RID: 74329
		private static readonly string format_keyType_accId = "{0}_{1}";

		// Token: 0x02004644 RID: 17988
		public enum PlayerPrefsKeyType
		{
			// Token: 0x0401225B RID: 74331
			None,
			// Token: 0x0401225C RID: 74332
			MonthCardRewardRedPointUpdateTime,
			// Token: 0x0401225D RID: 74333
			DailyTodoFunctionRefreshState,
			// Token: 0x0401225E RID: 74334
			DailyTodoFunctionEndStateTime,
			// Token: 0x0401225F RID: 74335
			DailyTodoFunctionWeekFinishTime,
			// Token: 0x04012260 RID: 74336
			CurrencyDeadLineTipsTime,
			// Token: 0x04012261 RID: 74337
			ATPassBlessCheckTime,
			// Token: 0x04012262 RID: 74338
			ATWeeklyTaskCheckTime,
			// Token: 0x04012263 RID: 74339
			TapRedPointCheck,
			// Token: 0x04012264 RID: 74340
			MagicJarScoreRedPoint,
			// Token: 0x04012265 RID: 74341
			LimitTimeActivityTabRedPoint,
			// Token: 0x04012266 RID: 74342
			CoinDealMyOrderPriceInValidTime,
			// Token: 0x04012267 RID: 74343
			SelectChannelInfoString,
			// Token: 0x04012268 RID: 74344
			TeamDuplicationVoiceTalkMicOn,
			// Token: 0x04012269 RID: 74345
			TeamDuplicationVoiceTalkPlayerOn,
			// Token: 0x0401226A RID: 74346
			Count
		}
	}
}
