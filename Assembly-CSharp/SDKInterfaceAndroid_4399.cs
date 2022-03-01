using System;
using System.Text;
using UnityEngine;

// Token: 0x02004655 RID: 18005
public class SDKInterfaceAndroid_4399 : SDKInterfaceAndroid
{
	// Token: 0x060195CB RID: 103883 RVA: 0x008046D0 File Offset: 0x00802AD0
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"116506",
			"http://118.178.215.163:58022/4399_get_order"
		});
	}

	// Token: 0x060195CC RID: 103884 RVA: 0x00804708 File Offset: 0x00802B08
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195CD RID: 103885 RVA: 0x00804720 File Offset: 0x00802B20
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195CE RID: 103886 RVA: 0x00804738 File Offset: 0x00802B38
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

	// Token: 0x060195CF RID: 103887 RVA: 0x0080479C File Offset: 0x00802B9C
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
			"4399",
			ext
		});
	}

	// Token: 0x060195D0 RID: 103888 RVA: 0x008047F2 File Offset: 0x00802BF2
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

	// Token: 0x040122D2 RID: 74450
	private const string APP_KEY = "116506";

	// Token: 0x040122D3 RID: 74451
	private const string PAY_GETORDER_URL = "http://118.178.215.163:58022/4399_get_order";

	// Token: 0x040122D4 RID: 74452
	private const string COMPANY_NAME = "聚和网络";
}
