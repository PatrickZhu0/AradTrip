using System;
using System.Collections.Generic;
using System.Text;
using GameClient;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x02004656 RID: 18006
public class SDKInterfaceAndroid_915 : SDKInterfaceAndroid
{
	// Token: 0x060195D2 RID: 103890 RVA: 0x00804823 File Offset: 0x00802C23
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚合网络",
			string.Empty
		});
	}

	// Token: 0x060195D3 RID: 103891 RVA: 0x0080485B File Offset: 0x00802C5B
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195D4 RID: 103892 RVA: 0x00804873 File Offset: 0x00802C73
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195D5 RID: 103893 RVA: 0x0080488C File Offset: 0x00802C8C
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		base.GetActivity().Call("Pay", new object[]
		{
			requestId,
			price,
			serverId,
			openUid,
			roleId,
			mallType,
			productId,
			productName,
			productDesc,
			extra
		});
	}

	// Token: 0x060195D6 RID: 103894 RVA: 0x008048F0 File Offset: 0x00802CF0
	public override string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		string text = Convert.ToBase64String(Encoding.Default.GetBytes(token));
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}&ext={6}", new object[]
		{
			serverUrl,
			serverId,
			openuid,
			text,
			SystemInfo.deviceUniqueIdentifier,
			"915",
			ext
		});
	}

	// Token: 0x060195D7 RID: 103895 RVA: 0x00804948 File Offset: 0x00802D48
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = string.Empty;
			if (scene == 1)
			{
				value = "enterServer";
			}
			else if (scene == 2)
			{
				value = "levelUp";
			}
			else if (scene == 3)
			{
				value = "createRole";
			}
			else if (scene == 4)
			{
				value = "exitServer";
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(proID, string.Empty, string.Empty);
			string value2 = "无";
			if (tableItem != null)
			{
				value2 = tableItem.Name;
			}
			dictionary.Add("type", value);
			dictionary.Add("zoneid", serverID.ToString());
			dictionary.Add("zonename", serverName.ToString());
			dictionary.Add("roleid", roleID);
			dictionary.Add("rolename", roleName);
			dictionary.Add("professionid", proID.ToString());
			dictionary.Add("profession", value2);
			dictionary.Add("gender", "无");
			dictionary.Add("rolelevel", roleLevel.ToString());
			dictionary.Add("vip", vip.ToString());
			dictionary.Add("balancenum", dianquanNum.ToString());
			dictionary.Add("partyid", "0");
			dictionary.Add("partyname", "无");
			dictionary.Add("partylevel", "0");
			dictionary.Add("partyrolename", "无");
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				dictionary["partyid"] = myGuild.uGUID.ToString();
				dictionary["partyname"] = myGuild.strName;
				dictionary["partylevel"] = myGuild.nLevel.ToString();
				dictionary["partyrolename"] = "会员";
			}
			base.GetActivity().Call("UpdateRoleInfo915", new object[]
			{
				dictionary.toJson()
			});
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("UpdateRoleInfo error:{0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x040122D5 RID: 74453
	private const string APP_ID = "10172150";

	// Token: 0x040122D6 RID: 74454
	private const string COMPANY_NAME = "聚合网络";

	// Token: 0x040122D7 RID: 74455
	private const string PAY_NORITY_URL = "";
}
