using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001163 RID: 4451
	internal class ChooseChannelManager : Singleton<ChooseChannelManager>
	{
		// Token: 0x0600AA00 RID: 43520 RVA: 0x002432DC File Offset: 0x002416DC
		public string loadPlatInfoFromFile()
		{
			string empty = string.Empty;
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive("platform_merge.conf", out empty) && !FileArchiveAccessor.LoadFileInLocalFileArchive("platform_merge.conf", out empty))
			{
				Debug.LogErrorFormat("[platform_merge] - can not load config {0} anywhere", new object[]
				{
					"platform_merge.conf"
				});
			}
			return empty;
		}

		// Token: 0x0600AA01 RID: 43521 RVA: 0x0024332C File Offset: 0x0024172C
		public List<ChooseChannelInfo> GetInfoList()
		{
			List<ChooseChannelInfo> result = new List<ChooseChannelInfo>();
			try
			{
				string text = this.loadPlatInfoFromFile();
				if (!string.IsNullOrEmpty(text))
				{
					JsonData jsonData = JsonMapper.ToObject(text);
					if (jsonData != null)
					{
						string text2 = Global.SDKChannelName[(int)Global.Settings.sdkChannel];
						if (jsonData.ContainsKey(text2) && jsonData[text2] != null && jsonData[text2].Count > 0)
						{
							result = JsonMapper.ToObject<List<ChooseChannelInfo>>(jsonData[text2].ToJson());
						}
					}
				}
				else
				{
					Debug.Log("[GetInfoList] loadString is null");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("GetInfoList json failed !" + ex.ToString());
			}
			return result;
		}

		// Token: 0x0600AA02 RID: 43522 RVA: 0x002433F0 File Offset: 0x002417F0
		public void SaveSelectChannelInfo(string infostring)
		{
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyStringValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType.SelectChannelInfoString, infostring);
		}

		// Token: 0x0600AA03 RID: 43523 RVA: 0x00243400 File Offset: 0x00241800
		public bool SetSelectChannelInfoSucc()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string typeKeyStringValueNoExtra = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyStringValueNoExtra(PlayerPrefsManager.PlayerPrefsKeyType.SelectChannelInfoString);
			if (!string.IsNullOrEmpty(typeKeyStringValueNoExtra))
			{
				string[] array = typeKeyStringValueNoExtra.Split(new char[]
				{
					','
				});
				if (array != null && array.Length > 0)
				{
					text = array[0];
					text2 = array[1];
					if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
					{
						return false;
					}
					this.ChangeChannelInfo(text, text2);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AA04 RID: 43524 RVA: 0x0024347D File Offset: 0x0024187D
		public void ChangeChannelInfo(string channelname, string serverlistname)
		{
			if (string.IsNullOrEmpty(channelname) || string.IsNullOrEmpty(serverlistname))
			{
				return;
			}
			Global.channelName = channelname;
			SDKInterface.STR_SERVERLIST_CHANGE_PACKAGE = serverlistname;
			Singleton<ServerAddressManager>.GetInstance().GetServerList(true);
			Singleton<ServerListManager>.instance.needflushFlag = true;
		}

		// Token: 0x0600AA05 RID: 43525 RVA: 0x002434B8 File Offset: 0x002418B8
		public bool IsSelectDiffChannel(string channelname)
		{
			return !string.Equals(channelname, Global.channelName);
		}

		// Token: 0x04005F3E RID: 24382
		private const string PLATFORM_MERGE_NAME = "platform_merge.conf";
	}
}
