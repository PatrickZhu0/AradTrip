using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02000DDB RID: 3547
	public class PlayerLocalSetting
	{
		// Token: 0x06008F24 RID: 36644 RVA: 0x001A7EBA File Offset: 0x001A62BA
		public static object GetValue(string key)
		{
			if (PlayerLocalSetting.Settings == null)
			{
				return null;
			}
			if (!PlayerLocalSetting.Settings.ContainsKey(key))
			{
				return null;
			}
			return PlayerLocalSetting.Settings[key];
		}

		// Token: 0x06008F25 RID: 36645 RVA: 0x001A7EE8 File Offset: 0x001A62E8
		public static void SetValue(string key, object value)
		{
			if (PlayerLocalSetting.Settings == null)
			{
				PlayerLocalSetting.Settings = new Hashtable();
			}
			if (!PlayerLocalSetting.Settings.ContainsKey(key))
			{
				PlayerLocalSetting.Settings.Add(key, value);
			}
			else
			{
				PlayerLocalSetting.Settings[key] = value;
			}
		}

		// Token: 0x06008F26 RID: 36646 RVA: 0x001A7F36 File Offset: 0x001A6336
		public static string getSettingPath()
		{
			return Application.persistentDataPath + "/player.config";
		}

		// Token: 0x06008F27 RID: 36647 RVA: 0x001A7F48 File Offset: 0x001A6348
		public static void LoadConfig()
		{
			byte[] array = null;
			try
			{
				FileArchiveAccessor.LoadFileInPersistentFileArchive("player.config", out array);
				if (array != null)
				{
					PlayerLocalSetting.Settings = (MiniJSON.jsonDecode(Encoding.Default.GetString(array)) as Hashtable);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("Read player Config failed reason {0}", new object[]
				{
					ex.Message
				});
			}
		}

		// Token: 0x06008F28 RID: 36648 RVA: 0x001A7FB8 File Offset: 0x001A63B8
		public static void SaveConfig()
		{
			try
			{
				string data = MiniJSON.jsonEncode(PlayerLocalSetting.Settings);
				FileArchiveAccessor.SaveFileInPersistentFileArchive("player.config", data);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("Save player Config failed reason {0}", new object[]
				{
					ex.Message
				});
			}
		}

		// Token: 0x04004706 RID: 18182
		protected static Hashtable Settings = new Hashtable();
	}
}
