using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GameClient;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x02004654 RID: 18004
public class SDKInterfaceAndroid_360 : SDKInterfaceAndroid
{
	// Token: 0x060195C3 RID: 103875 RVA: 0x00804164 File Offset: 0x00802564
	public override void Init(bool debug)
	{
		base.Init(debug);
		string arg = Global.LOGIN_SERVER_ADDRESS.Split(new char[]
		{
			':'
		})[0];
		string text = string.Format("http://{0}:58022/360_charge_token", arg);
		string text2 = string.Format("http://{0}:58022/360_charge", arg);
		string text3 = string.Format("http://{0}/query", Global.LOGIN_SERVER_ADDRESS);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚合网络",
			text,
			text2,
			text3
		});
	}

	// Token: 0x060195C4 RID: 103876 RVA: 0x008041EB File Offset: 0x008025EB
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195C5 RID: 103877 RVA: 0x00804203 File Offset: 0x00802603
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195C6 RID: 103878 RVA: 0x0080421C File Offset: 0x0080261C
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

	// Token: 0x060195C7 RID: 103879 RVA: 0x00804280 File Offset: 0x00802680
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
			"360",
			ext
		});
	}

	// Token: 0x060195C8 RID: 103880 RVA: 0x008042D8 File Offset: 0x008026D8
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
			List<string> list = new List<string>();
			list.Add(new Dictionary<string, string>
			{
				{
					"balanceid",
					"1"
				},
				{
					"balancename",
					"点券"
				},
				{
					"balancenum",
					dianquanNum.ToString()
				}
			}.toJson());
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(list);
			dictionary.Add("balance", MiniJSON.jsonEncode(arrayList));
			dictionary.Add("partyid", "0");
			dictionary.Add("partyname", "无");
			dictionary.Add("partyroleid", "0");
			dictionary.Add("partyrolename", "无");
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				dictionary["partyid"] = myGuild.uGUID.ToString();
				dictionary["partyname"] = myGuild.strName;
				dictionary["partyroleid"] = "2";
				dictionary["partyrolename"] = "会员";
			}
			if (scene == 3)
			{
				dictionary.Add("friendlist", "无");
			}
			else
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
				if (relation.Count <= 0)
				{
					dictionary.Add("friendlist", "无");
				}
				else
				{
					List<string> list2 = new List<string>();
					int num = 0;
					while (num < relation.Count && num < 10)
					{
						list2.Add(new Dictionary<string, string>
						{
							{
								"roleid",
								relation[num].uid.ToString()
							},
							{
								"intimacy",
								"0"
							},
							{
								"nexusid",
								"6"
							},
							{
								"nexusname",
								"好友"
							}
						}.toJson());
						num++;
					}
					ArrayList arrayList2 = new ArrayList();
					arrayList2.AddRange(list2);
					dictionary.Add("friendlist", MiniJSON.jsonEncode(arrayList2));
				}
			}
			base.GetActivity().Call("updateRoleInfo360", new object[]
			{
				dictionary.toJson(),
				roleLevel,
				vip
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

	// Token: 0x060195C9 RID: 103881 RVA: 0x008046B0 File Offset: 0x00802AB0
	public void SwitchAccount()
	{
		base.GetActivity().Call("SwitchAccount", new object[0]);
	}

	// Token: 0x040122CE RID: 74446
	private const string COMPANY_NAME = "聚合网络";

	// Token: 0x040122CF RID: 74447
	private const string PAY_CHARGE_TOKEN_URL_FORMAT = "http://{0}:58022/360_charge_token";

	// Token: 0x040122D0 RID: 74448
	private const string PAY_NOTIFY_URL_FORMAT = "http://{0}:58022/360_charge";

	// Token: 0x040122D1 RID: 74449
	private const string LOGIN_INFO_URL = "http://{0}/query";
}
