using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02001175 RID: 4469
	internal class ServerAddressManager : Singleton<ServerAddressManager>
	{
		// Token: 0x0600AAF0 RID: 43760 RVA: 0x00249923 File Offset: 0x00247D23
		public override void Init()
		{
		}

		// Token: 0x0600AAF1 RID: 43761 RVA: 0x00249928 File Offset: 0x00247D28
		private void TrySetAddress(ref string dest, Hashtable table, string key)
		{
			if (table != null && !string.IsNullOrEmpty(key) && table.ContainsKey(key))
			{
				object obj = table[key];
				if (obj != null)
				{
					dest = obj.ToString();
				}
			}
		}

		// Token: 0x0600AAF2 RID: 43762 RVA: 0x00249968 File Offset: 0x00247D68
		public void GetServerList(bool isChangePack = false)
		{
			if (!Global.Settings.isUsingSDK)
			{
				return;
			}
			string fileResRelative = "serverList_hack.xml";
			byte[] bytes = null;
			if (FileArchiveAccessor.LoadFileInPersistentFileArchive(fileResRelative, out bytes))
			{
				string @string = Encoding.Default.GetString(bytes);
				Hashtable table = MiniJSON.jsonDecode(@string) as Hashtable;
				try
				{
					this.TrySetAddress(ref Global.STATISTIC_SERVER_ADDRESS, table, "statistic");
					this.TrySetAddress(ref Global.VERIFY_BIND_PHONE_ADDRESS, table, "bindphone");
					this.TrySetAddress(ref Global.STATISTIC_SERVER_ADDRESS, table, "android_statistic");
					this.TrySetAddress(ref Global.PUBLISH_SERVER_ADDRESS, table, "android_publish");
					this.TrySetAddress(ref Global.ROLE_SAVEDATA_SERVER_ADDRESS, table, "android_rolesave");
					this.TrySetAddress(ref Global.LOGIN_SERVER_ADDRESS, table, "android_loginvef");
					this.TrySetAddress(ref Global.ANDROID_MG_CHARGE, table, "android_mg_charge");
					this.TrySetAddress(ref Global.ROLE_SAVEDATA_SERVER_ADDRESS_HW, table, "android_hw_rolesave");
					this.TrySetAddress(ref Global.USER_AGREEMENT_SERVER_ADDRESS, table, "android_user_agreement");
					this.TrySetAddress(ref Global.VOICE_SERVER_ADDRESS, table, "voice");
					this.TrySetAddress(ref Global.ROLE_QUERY_OPENID_ADDRESS, table, "queryopenid");
					this.TrySetAddress(ref Global.ONLINE_SERVICE_ADDRESS, table, "online_service");
					this.TrySetAddress(ref Global.ONLINE_SERVICE_REQ_ADDRESS, table, "online_service_unread");
					this.TrySetAddress(ref Global.ONLINE_SERVICE_VIP_CHECK_ADDRESS, table, "online_service_vip_auth");
					this.TrySetAddress(ref Global.BANGBANGEVERISK_SERVICE_ADDRESS, table, "bangbangeverisk_post_address");
					this.TrySetAddress(ref Global.RECORDLOG_GET_ADDRESS, table, "record_get_address");
					this.TrySetAddress(ref Global.RECORDLOG_POST_ADDRESS, table, "record_post_address");
					this.TrySetAddress(ref Global.BATTLE_PERFORMANCE_POST_ADDRESS, table, "battle_perf_post_address");
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("serverList_hack.xml出错 {0}", new object[]
					{
						ex.ToString()
					});
				}
				if (Global.Settings.sdkChannel == SDKChannel.HuaWei)
				{
					Global.ROLE_SAVEDATA_SERVER_ADDRESS = Global.ROLE_SAVEDATA_SERVER_ADDRESS_HW;
				}
				return;
			}
			string path = "Environment/" + SDKInterface.instance.GetServerListName(isChangePack);
			Object obj = Singleton<AssetLoader>.instance.LoadRes(path, true, 0U).obj;
			if (obj == null)
			{
				return;
			}
			string string2 = Encoding.Default.GetString((obj as TextAsset).bytes);
			Hashtable table2 = MiniJSON.jsonDecode(string2) as Hashtable;
			try
			{
				this.TrySetAddress(ref Global.STATISTIC_SERVER_ADDRESS, table2, "statistic");
				this.TrySetAddress(ref Global.VERIFY_BIND_PHONE_ADDRESS, table2, "bindphone");
				this.TrySetAddress(ref Global.STATISTIC_SERVER_ADDRESS, table2, "android_statistic");
				this.TrySetAddress(ref Global.PUBLISH_SERVER_ADDRESS, table2, "android_publish");
				this.TrySetAddress(ref Global.ROLE_SAVEDATA_SERVER_ADDRESS, table2, "android_rolesave");
				this.TrySetAddress(ref Global.LOGIN_SERVER_ADDRESS, table2, "android_loginvef");
				this.TrySetAddress(ref Global.ANDROID_MG_CHARGE, table2, "android_mg_charge");
				this.TrySetAddress(ref Global.ROLE_SAVEDATA_SERVER_ADDRESS_HW, table2, "android_hw_rolesave");
				this.TrySetAddress(ref Global.USER_AGREEMENT_SERVER_ADDRESS, table2, "android_user_agreement");
				this.TrySetAddress(ref Global.VOICE_SERVER_ADDRESS, table2, "voice");
				this.TrySetAddress(ref Global.ROLE_QUERY_OPENID_ADDRESS, table2, "queryopenid");
				this.TrySetAddress(ref Global.STATISTIC2_SERVER_ADDRESS, table2, "statistic2");
				this.TrySetAddress(ref Global.ONLINE_SERVICE_ADDRESS, table2, "online_service");
				this.TrySetAddress(ref Global.ONLINE_SERVICE_REQ_ADDRESS, table2, "online_service_unread");
				this.TrySetAddress(ref Global.ONLINE_SERVICE_VIP_CHECK_ADDRESS, table2, "online_service_vip_auth");
				this.TrySetAddress(ref Global.BANGBANGEVERISK_SERVICE_ADDRESS, table2, "bangbangeverisk_post_address");
				this.TrySetAddress(ref Global.RECORDLOG_GET_ADDRESS, table2, "record_get_address");
				this.TrySetAddress(ref Global.RECORDLOG_POST_ADDRESS, table2, "record_post_address");
				this.TrySetAddress(ref Global.BATTLE_PERFORMANCE_POST_ADDRESS, table2, "battle_perf_post_address");
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat("读取serverList.xml出错 {0}", new object[]
				{
					ex2.ToString()
				});
			}
			if (Global.Settings.sdkChannel == SDKChannel.HuaWei)
			{
				Global.ROLE_SAVEDATA_SERVER_ADDRESS = Global.ROLE_SAVEDATA_SERVER_ADDRESS_HW;
			}
		}
	}
}
