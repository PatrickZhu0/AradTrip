using System;
using System.Text;
using UnityEngine;

// Token: 0x02004663 RID: 18019
public class SDKInterfaceAndroid_VIVO : SDKInterfaceAndroid
{
	// Token: 0x0601963A RID: 103994 RVA: 0x00806DA0 File Offset: 0x008051A0
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.PAY_NORITY_URL = string.Format("http://{0}/vivo_charge2", Global.ANDROID_MG_CHARGE);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚和网络",
			string.Empty,
			"30bb57c34c18515cbee0b771cdc436d2",
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			this.PAY_NORITY_URL
		});
	}

	// Token: 0x0601963B RID: 103995 RVA: 0x00806E34 File Offset: 0x00805234
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
		foreach (SDKChannel sdkchannel in Global.SDKPushChannel)
		{
			if (sdkchannel == SDKChannel.VIVO)
			{
				base.GetActivity().Call("InitPush", new object[0]);
				break;
			}
		}
	}

	// Token: 0x0601963C RID: 103996 RVA: 0x00806E98 File Offset: 0x00805298
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x0601963D RID: 103997 RVA: 0x00806EB0 File Offset: 0x008052B0
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

	// Token: 0x0601963E RID: 103998 RVA: 0x00806F14 File Offset: 0x00805314
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
			sdkChannel,
			ext
		});
	}

	// Token: 0x0601963F RID: 103999 RVA: 0x00806F67 File Offset: 0x00805367
	public override void SetCreateRoleInfo(string accid, string roleid, string roleName, string roleLevel, string serverName, string roleRank, string beSociaty)
	{
		base.GetActivity().Call("updatePlayerInfo", new object[]
		{
			roleid,
			roleLevel,
			serverName,
			beSociaty
		});
	}

	// Token: 0x06019640 RID: 104000 RVA: 0x00806F94 File Offset: 0x00805394
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		string text = string.Empty;
		if (scene == 1)
		{
			text = "enterServer";
		}
		else if (scene == 2)
		{
			text = "levelUp";
		}
		else if (scene == 3)
		{
			text = "createRole";
		}
		else if (scene == 4)
		{
			text = "exitServer";
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
				text,
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

	// Token: 0x06019641 RID: 104001 RVA: 0x00807070 File Offset: 0x00805470
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

	// Token: 0x06019642 RID: 104002 RVA: 0x008070CC File Offset: 0x008054CC
	public override void OpenGameCenter()
	{
		try
		{
			base.GetActivity().Call("StartVivoGameCenter", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("StartOppoGameCenter failed " + ex.ToString());
		}
	}

	// Token: 0x06019643 RID: 104003 RVA: 0x00807120 File Offset: 0x00805520
	public override void GotoSDKChannelCommunity()
	{
		try
		{
			base.GetActivity().Call("GotoVivoCommunity", new object[0]);
		}
		catch (Exception ex)
		{
			Logger.LogError("GotoVivoCommunity failed " + ex.ToString());
		}
	}

	// Token: 0x04012308 RID: 74504
	private const string APP_ID = "30bb57c34c18515cbee0b771cdc436d2";

	// Token: 0x04012309 RID: 74505
	private const string Cp_ID = "20150728111537728033";

	// Token: 0x0401230A RID: 74506
	private const string APP_Key = "b58595db30dd4838c306f8906aacd253";

	// Token: 0x0401230B RID: 74507
	private const string COMPANY_NAME = "聚和网络";

	// Token: 0x0401230C RID: 74508
	private string PAY_NORITY_URL = "http://120.132.26.173:59003/vivo_charge2";
}
