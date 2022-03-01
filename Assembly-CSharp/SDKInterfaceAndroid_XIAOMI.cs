using System;
using System.Text;
using UnityEngine;

// Token: 0x02004664 RID: 18020
public class SDKInterfaceAndroid_XIAOMI : SDKInterfaceAndroid
{
	// Token: 0x06019645 RID: 104005 RVA: 0x0080717C File Offset: 0x0080557C
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

	// Token: 0x06019646 RID: 104006 RVA: 0x008071B4 File Offset: 0x008055B4
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x06019647 RID: 104007 RVA: 0x008071CC File Offset: 0x008055CC
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x06019648 RID: 104008 RVA: 0x008071E4 File Offset: 0x008055E4
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

	// Token: 0x06019649 RID: 104009 RVA: 0x00807248 File Offset: 0x00805648
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
			"xiaomi",
			ext
		});
	}

	// Token: 0x0601964A RID: 104010 RVA: 0x0080729E File Offset: 0x0080569E
	public void updatePlayerInfoHW(string gameRole, string gameRank, string gameArea, string gameSociaty)
	{
		base.GetActivity().Call("updatePlayerInfo", new object[]
		{
			gameRole,
			gameRank,
			gameArea,
			gameSociaty
		});
	}

	// Token: 0x0401230D RID: 74509
	private const string APP_ID = "10172150";

	// Token: 0x0401230E RID: 74510
	private const string COMPANY_NAME = "聚合网络";

	// Token: 0x0401230F RID: 74511
	private const string PAY_NORITY_URL = "";
}
