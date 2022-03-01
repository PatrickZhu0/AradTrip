using System;
using System.Text;
using GameClient;
using UnityEngine;

// Token: 0x02004658 RID: 18008
public class SDKInterfaceAndroid_HuaWei : SDKInterfaceAndroid
{
	// Token: 0x060195DF RID: 103903 RVA: 0x00804D0C File Offset: 0x0080310C
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.PaySignReqUrl = string.Format("http://{0}/get_hw_sign", Global.ANDROID_MG_CHARGE);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚和网络",
			"com.hegu.dnl.huawei",
			"100107279",
			"900086000032183599",
			"MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAKhvS172wSqZRWUPVD+xBqkPA5cp1rIyHy6Yb9OJUyWHrBFIoEk9UUUdamc/ytrpKH/6C/Hp5BMw8JX390jQBLsCAwEAAQ==",
			"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDhdEl6gfpiGnQywzedsSoGk87RwUl70gDghe6rvOly6EGbith2y2fXbs/uesHZnJyPYzZDy1Ixb8y0ahfcQnQB9Wgtz8LsutzMnMIRnhmJdCrXRVypeNG5yxB2W2qtg2Wf+jM81moUlXv3mIQ4T0SfNE7zy7CxXtuKDeA6I5H8LQIDAQAB",
			"MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAOF0SXqB+mIadDLDN52xKgaTztHBSXvSAOCF7qu86XLoQZuK2HbLZ9duz+56wdmcnI9jNkPLUjFvzLRqF9xCdAH1aC3Pwuy63MycwhGeGYl0KtdFXKl40bnLEHZbaq2DZZ/6MzzWahSVe/eYhDhPRJ80TvPLsLFe24oN4DojkfwtAgMBAAECgYB6TlyCQjrzt4gr9a2ZNYAn+01qiyHzMxTYuK+mqSA3/vmAiQ0vPN+DhpD0vdGl3Qkt3FOW6ZkYSp9RjHCPQ9msJab5PDn3ZmBpW50hKgTKt4ENRlem84NFbU+b6R0w/q9BV3dF7a9fKWRjFCJt3ErPIpv2dwz7I6L15jlzMZptvQJBAPOk1ahkfDHoX4oDqmMEBPUmwTnI5sngu3/R76aWizRnbalhDUFj4PaNmx3yiHI+ISO3nepU0nnrOXKaxDdvUzsCQQDs400SHIzjXagGD2Vxqg8W7yQy15ZVjXQtNeuD/ncPPraGw0yv2ee4zHGD00bJybeM/JEnpakD/JSoRAgr9qe3AkBdsi8kQfhs7PMIzV4SE/KgIFZAlZ0DV7RjdGWYB97iuT+32oXRdsqFpnFXs/R7Ep+F78//1LzYe/gstY3tz5cPAkAKkamioTt3+XnBq3YvOBMsRscqrYu7jXAdhEZZwUS2nWmvYY9OWT6JdDWsWATUg/d4htxDFJUR5HcNetuSepLJAkEAukODrpCujtTCBLm/5zjE3dJbyLPqqwupoL3UCx4NzydJr4+bKxD+fPlBXD969Te79Dxd8QNa0ilEr5MXKgu5HA==",
			string.Empty,
			string.Empty,
			this.PaySignReqUrl
		});
	}

	// Token: 0x060195E0 RID: 103904 RVA: 0x00804DA8 File Offset: 0x008031A8
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195E1 RID: 103905 RVA: 0x00804DC0 File Offset: 0x008031C0
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195E2 RID: 103906 RVA: 0x00804DD8 File Offset: 0x008031D8
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

	// Token: 0x060195E3 RID: 103907 RVA: 0x00804E3C File Offset: 0x0080323C
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

	// Token: 0x060195E4 RID: 103908 RVA: 0x00804E90 File Offset: 0x00803290
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		try
		{
			string empty = string.Empty;
			if (scene != 1)
			{
				if (scene != 2)
				{
					if (scene != 3)
					{
						if (scene == 4)
						{
						}
					}
				}
			}
			if (scene != 4)
			{
				string text = string.Empty;
				if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
				{
					GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
					text = myGuild.strName;
				}
				else
				{
					text = "无";
				}
				base.GetActivity().Call("updatePlayerInfo", new object[]
				{
					roleName,
					roleLevel + string.Empty,
					serverName,
					text
				});
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("上报角色信息 失败" + ex.ToString());
		}
	}

	// Token: 0x040122DC RID: 74460
	private const string APP_NAME = "阿拉德之怒";

	// Token: 0x040122DD RID: 74461
	private string PaySignReqUrl = "http://120.132.26.173:59003/get_hw_sign";

	// Token: 0x040122DE RID: 74462
	private const string PACKAGE_NAME = "com.hegu.dnl.huawei";

	// Token: 0x040122DF RID: 74463
	private const string APP_ID = "100107279";

	// Token: 0x040122E0 RID: 74464
	private const string PAY_ID = "900086000032183599";

	// Token: 0x040122E1 RID: 74465
	private const string COMPANY_NAME = "聚和网络";

	// Token: 0x040122E2 RID: 74466
	private const string BUOY_SECRET = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAOF0SXqB+mIadDLDN52xKgaTztHBSXvSAOCF7qu86XLoQZuK2HbLZ9duz+56wdmcnI9jNkPLUjFvzLRqF9xCdAH1aC3Pwuy63MycwhGeGYl0KtdFXKl40bnLEHZbaq2DZZ/6MzzWahSVe/eYhDhPRJ80TvPLsLFe24oN4DojkfwtAgMBAAECgYB6TlyCQjrzt4gr9a2ZNYAn+01qiyHzMxTYuK+mqSA3/vmAiQ0vPN+DhpD0vdGl3Qkt3FOW6ZkYSp9RjHCPQ9msJab5PDn3ZmBpW50hKgTKt4ENRlem84NFbU+b6R0w/q9BV3dF7a9fKWRjFCJt3ErPIpv2dwz7I6L15jlzMZptvQJBAPOk1ahkfDHoX4oDqmMEBPUmwTnI5sngu3/R76aWizRnbalhDUFj4PaNmx3yiHI+ISO3nepU0nnrOXKaxDdvUzsCQQDs400SHIzjXagGD2Vxqg8W7yQy15ZVjXQtNeuD/ncPPraGw0yv2ee4zHGD00bJybeM/JEnpakD/JSoRAgr9qe3AkBdsi8kQfhs7PMIzV4SE/KgIFZAlZ0DV7RjdGWYB97iuT+32oXRdsqFpnFXs/R7Ep+F78//1LzYe/gstY3tz5cPAkAKkamioTt3+XnBq3YvOBMsRscqrYu7jXAdhEZZwUS2nWmvYY9OWT6JdDWsWATUg/d4htxDFJUR5HcNetuSepLJAkEAukODrpCujtTCBLm/5zjE3dJbyLPqqwupoL3UCx4NzydJr4+bKxD+fPlBXD969Te79Dxd8QNa0ilEr5MXKgu5HA==";

	// Token: 0x040122E3 RID: 74467
	private const string PAY_RSA_PRIVATE = "";

	// Token: 0x040122E4 RID: 74468
	private const string PAY_RSA_PUBLIC = "MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAKhvS172wSqZRWUPVD+xBqkPA5cp1rIyHy6Yb9OJUyWHrBFIoEk9UUUdamc/ytrpKH/6C/Hp5BMw8JX390jQBLsCAwEAAQ==";

	// Token: 0x040122E5 RID: 74469
	private const string LOGIN_RSA_PUBLIC = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDhdEl6gfpiGnQywzedsSoGk87RwUl70gDghe6rvOly6EGbith2y2fXbs/uesHZnJyPYzZDy1Ixb8y0ahfcQnQB9Wgtz8LsutzMnMIRnhmJdCrXRVypeNG5yxB2W2qtg2Wf+jM81moUlXv3mIQ4T0SfNE7zy7CxXtuKDeA6I5H8LQIDAQAB";

	// Token: 0x040122E6 RID: 74470
	private const string PAY_NORITY_URL = "";
}
