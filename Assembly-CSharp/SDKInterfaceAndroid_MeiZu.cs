using System;
using System.Text;
using UnityEngine;

// Token: 0x0200465F RID: 18015
public class SDKInterfaceAndroid_MeiZu : SDKInterfaceAndroid
{
	// Token: 0x06019613 RID: 103955 RVA: 0x008060D4 File Offset: 0x008044D4
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.PAY_NORITY_URL = string.Format("http://{0}/mz_create_charge", Global.ANDROID_MG_CHARGE);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚和网络",
			string.Empty,
			"3184987",
			"b4bdab0feb6a47de997db87e18ed50e0",
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			this.PAY_NORITY_URL
		});
	}

	// Token: 0x06019614 RID: 103956 RVA: 0x00806167 File Offset: 0x00804567
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
		base.GetActivity().Call("ShowFloatWindow", new object[0]);
	}

	// Token: 0x06019615 RID: 103957 RVA: 0x00806195 File Offset: 0x00804595
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x06019616 RID: 103958 RVA: 0x008061B0 File Offset: 0x008045B0
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

	// Token: 0x06019617 RID: 103959 RVA: 0x00806214 File Offset: 0x00804614
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

	// Token: 0x06019618 RID: 103960 RVA: 0x00806267 File Offset: 0x00804667
	public override void SetCreateRoleInfo(string accid, string roleid, string roleName, string roleLevel, string serverName, string roleRank, string beSociaty)
	{
		base.GetActivity().Call("updatePlayerInfo", new object[]
		{
			roleName,
			roleLevel,
			serverName,
			beSociaty
		});
	}

	// Token: 0x040122F9 RID: 74489
	private const string APP_ID = "3184987";

	// Token: 0x040122FA RID: 74490
	private const string APP_KEY = "b4bdab0feb6a47de997db87e18ed50e0";

	// Token: 0x040122FB RID: 74491
	private const string COMPANY_NAME = "聚和网络";

	// Token: 0x040122FC RID: 74492
	private string PAY_NORITY_URL = "http://120.132.26.173:59003/mz_create_charge";
}
