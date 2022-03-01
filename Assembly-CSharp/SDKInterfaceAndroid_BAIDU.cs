using System;
using System.Text;
using UnityEngine;

// Token: 0x02004657 RID: 18007
public class SDKInterfaceAndroid_BAIDU : SDKInterfaceAndroid
{
	// Token: 0x060195D9 RID: 103897 RVA: 0x00804BBC File Offset: 0x00802FBC
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚合网络",
			"10251863",
			"xkql1mRmvFC9f0z59F9eTHY7",
			string.Empty
		});
	}

	// Token: 0x060195DA RID: 103898 RVA: 0x00804C0F File Offset: 0x0080300F
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195DB RID: 103899 RVA: 0x00804C27 File Offset: 0x00803027
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195DC RID: 103900 RVA: 0x00804C40 File Offset: 0x00803040
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

	// Token: 0x060195DD RID: 103901 RVA: 0x00804CA4 File Offset: 0x008030A4
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

	// Token: 0x040122D8 RID: 74456
	private const string APP_ID = "10251863";

	// Token: 0x040122D9 RID: 74457
	private const string APP_KEY = "xkql1mRmvFC9f0z59F9eTHY7";

	// Token: 0x040122DA RID: 74458
	private const string COMPANY_NAME = "聚合网络";

	// Token: 0x040122DB RID: 74459
	private const string PAY_NORITY_URL = "";
}
