using System;
using System.Collections.Generic;

// Token: 0x0200465D RID: 18013
public class SDKInterfaceAndroid_Lenovo : SDKInterfaceAndroid
{
	// Token: 0x06019600 RID: 103936 RVA: 0x00805828 File Offset: 0x00803C28
	public SDKInterfaceAndroid_Lenovo()
	{
		this.m_productMap.Add(1, 168981);
		this.m_productMap.Add(2, 168982);
		this.m_productMap.Add(3, 168983);
		this.m_productMap.Add(4, 168985);
		this.m_productMap.Add(5, 168986);
		this.m_productMap.Add(6, 168988);
		this.m_productMap.Add(7, 168989);
		this.m_productMap.Add(8, 168984);
		this.m_productMap.Add(9, 168987);
		this.m_productMap.Add(11, 220948);
		this.m_productMap.Add(12, 220949);
		this.m_productMap.Add(13, 220950);
	}

	// Token: 0x06019601 RID: 103937 RVA: 0x0080592C File Offset: 0x00803D2C
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.PayNotifyUrl = string.Format("http://{0}/lenovo_charge", Global.ANDROID_MG_CHARGE);
		this.LoginQueryUrl = string.Format("http://{0}/query", Global.LOGIN_SERVER_ADDRESS);
		string platformNameByChannel = this.GetPlatformNameByChannel();
		base.GetActivity().Call("Init", new object[]
		{
			debug,
			"1710130335182.app.ln",
			this.PayNotifyUrl,
			this.LoginQueryUrl,
			platformNameByChannel
		});
	}

	// Token: 0x06019602 RID: 103938 RVA: 0x008059AE File Offset: 0x00803DAE
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x06019603 RID: 103939 RVA: 0x008059C6 File Offset: 0x00803DC6
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x06019604 RID: 103940 RVA: 0x008059E0 File Offset: 0x00803DE0
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		int num = 0;
		this.m_productMap.TryGetValue(productId, out num);
		base.GetActivity().Call("Pay", new object[]
		{
			requestId,
			num,
			0,
			extra
		});
	}

	// Token: 0x06019605 RID: 103941 RVA: 0x00805A30 File Offset: 0x00803E30
	public override string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}&ext={6}", new object[]
		{
			serverUrl,
			serverId,
			Uri.EscapeDataString(openuid),
			Uri.EscapeDataString(token),
			deviceId,
			sdkChannel,
			ext
		});
	}

	// Token: 0x040122F0 RID: 74480
	private const string AppId = "1710130335182.app.ln";

	// Token: 0x040122F1 RID: 74481
	private string PayNotifyUrl = "http://120.132.26.173:59003/lenovo_charge";

	// Token: 0x040122F2 RID: 74482
	private string LoginQueryUrl = string.Empty;

	// Token: 0x040122F3 RID: 74483
	private Dictionary<int, int> m_productMap = new Dictionary<int, int>();
}
