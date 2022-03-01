using System;
using System.Text;
using GameClient;
using UnityEngine;

// Token: 0x0200465A RID: 18010
public class SDKInterfaceAndroid_JoyLand : SDKInterfaceAndroid
{
	// Token: 0x060195EC RID: 103916 RVA: 0x008050E8 File Offset: 0x008034E8
	public override void Init(bool debug)
	{
		base.Init(debug);
		string platformNameByChannel = this.GetPlatformNameByChannel();
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		this.PAY_NOTIFY_URL = string.Format("http://{0}/joyland_charge", Global.ANDROID_MG_CHARGE);
		this.LOGIN_INFO_URL = string.Format("http://{0}/query", Global.LOGIN_SERVER_ADDRESS);
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			this.PAY_NOTIFY_URL,
			this.LOGIN_INFO_URL,
			platformNameByChannel,
			deviceUniqueIdentifier
		});
	}

	// Token: 0x060195ED RID: 103917 RVA: 0x0080516C File Offset: 0x0080356C
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195EE RID: 103918 RVA: 0x00805184 File Offset: 0x00803584
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195EF RID: 103919 RVA: 0x0080519C File Offset: 0x0080359C
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		string name = DataManager<PlayerBaseData>.GetInstance().Name;
		int num = 1;
		double num2;
		bool flag = double.TryParse(price, out num2);
		if (!flag || Global.Settings.isPaySDKDebug)
		{
			num2 = 0.01;
		}
		string text = "阿拉德之怒_" + productName;
		base.GetActivity().Call("Pay", new object[]
		{
			extra,
			roleId,
			productId.ToString(),
			text,
			num2,
			name,
			serverId.ToString(),
			productDesc,
			num,
			extra
		});
	}

	// Token: 0x060195F0 RID: 103920 RVA: 0x00805254 File Offset: 0x00803654
	public override string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		string text = this.NeedUriEncodeOpenid(openuid);
		string text2 = Convert.ToBase64String(Encoding.Default.GetBytes(token));
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}&ext={6}", new object[]
		{
			serverUrl,
			serverId,
			text,
			text2,
			SystemInfo.deviceUniqueIdentifier,
			this.GetPlatformNameByChannel(),
			ext
		});
	}

	// Token: 0x040122E8 RID: 74472
	private const string COMPANY_NAME = "聚合网络";

	// Token: 0x040122E9 RID: 74473
	private const string PRODUCT_PRE = "阿拉德之怒_";

	// Token: 0x040122EA RID: 74474
	private string PAY_NOTIFY_URL = "http://192.168.2.26:57352/joyland_charge";

	// Token: 0x040122EB RID: 74475
	private string LOGIN_INFO_URL = "http://192.168.2.26:56352/query";
}
