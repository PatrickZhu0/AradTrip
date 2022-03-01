using System;
using System.Text;
using GameClient;
using ProtoTable;

// Token: 0x02004660 RID: 18016
public class SDKInterfaceAndroid_OPPO : SDKInterfaceAndroid
{
	// Token: 0x0601961A RID: 103962 RVA: 0x008062A5 File Offset: 0x008046A5
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.PayNotifyUrl = string.Format("http://{0}/oppo_charge", Global.ANDROID_MG_CHARGE);
		base.GetActivity().Call("Init", new object[]
		{
			debug
		});
	}

	// Token: 0x0601961B RID: 103963 RVA: 0x008062E2 File Offset: 0x008046E2
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x0601961C RID: 103964 RVA: 0x008062FA File Offset: 0x008046FA
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x0601961D RID: 103965 RVA: 0x00806314 File Offset: 0x00804714
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		float num = float.Parse(price) * 100f;
		int num2 = (int)num;
		base.GetActivity().Call("Pay", new object[]
		{
			requestId,
			num2,
			productName,
			productDesc,
			extra,
			this.PayNotifyUrl
		});
	}

	// Token: 0x0601961E RID: 103966 RVA: 0x0080636C File Offset: 0x0080476C
	public override string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		if (!string.IsNullOrEmpty(token))
		{
			token = Convert.ToBase64String(Encoding.Default.GetBytes(token));
		}
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}&ext={6}", new object[]
		{
			serverUrl,
			serverId,
			openuid,
			token,
			deviceId,
			sdkChannel,
			ext
		});
	}

	// Token: 0x0601961F RID: 103967 RVA: 0x008063CA File Offset: 0x008047CA
	public override void SetCreateRoleInfo(string accid, string roleid, string roleName, string roleLevel, string serverName, string roleRank, string beSociaty)
	{
	}

	// Token: 0x06019620 RID: 103968 RVA: 0x008063CC File Offset: 0x008047CC
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		string text = "default";
		int lastedDungeonIDByDiff = ChapterUtility.GetLastedDungeonIDByDiff(0);
		DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(lastedDungeonIDByDiff, string.Empty, string.Empty);
		if (tableItem != null)
		{
			text = tableItem.Name;
		}
		base.GetActivity().Call("ReportUserData", new object[]
		{
			roleID.ToString(),
			roleName,
			roleLevel,
			serverID.ToString(),
			serverName,
			text
		});
		string text2 = string.Empty;
		if (scene == 1)
		{
			text2 = "enterServer";
		}
		else if (scene == 2)
		{
			text2 = "levelUp";
		}
		else if (scene == 3)
		{
			text2 = "createRole";
		}
		else if (scene == 4)
		{
			text2 = "exitServer";
		}
		if (scene != 3)
		{
			if (scene != 1)
			{
				return;
			}
		}
		try
		{
			base.GetActivity().Call("ReporterRoleInfo", new object[]
			{
				text2,
				serverID.ToString(),
				serverName,
				roleID,
				roleName,
				roleLevel.ToString()
			});
		}
		catch (Exception ex)
		{
			Logger.LogError("ReporterRoleInfo failed" + ex.ToString());
		}
	}

	// Token: 0x06019621 RID: 103969 RVA: 0x00806524 File Offset: 0x00804924
	public override bool IsStartFromGameCenter()
	{
		bool result;
		try
		{
			result = base.GetActivity().Call<bool>("IsStartFromGameCenter", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("IsStartGameFromOppoCenter failed get from jar : " + ex.ToString());
			result = base.IsStartFromGameCenter();
		}
		return result;
	}

	// Token: 0x06019622 RID: 103970 RVA: 0x00806580 File Offset: 0x00804980
	public override void OpenGameCenter()
	{
		try
		{
			base.GetActivity().Call("StartOppoGameCenter", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("StartOppoGameCenter failed " + ex.ToString());
		}
	}

	// Token: 0x06019623 RID: 103971 RVA: 0x008065D4 File Offset: 0x008049D4
	public override void GotoSDKChannelCommunity()
	{
		try
		{
			base.GetActivity().Call("GotoOppoCommunity", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("GotoOppoCommunity failed " + ex.ToString());
		}
	}

	// Token: 0x040122FD RID: 74493
	private string PayNotifyUrl = "http://120.132.26.173:59003/oppo_charge";
}
