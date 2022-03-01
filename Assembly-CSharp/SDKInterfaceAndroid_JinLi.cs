using System;

// Token: 0x02004659 RID: 18009
public class SDKInterfaceAndroid_JinLi : SDKInterfaceAndroid
{
	// Token: 0x060195E6 RID: 103910 RVA: 0x00804F9F File Offset: 0x0080339F
	public override void Init(bool debug)
	{
		base.Init(debug);
		this.OrderUrl = string.Format("http://{0}/get_jinli_order", Global.ANDROID_MG_CHARGE);
		base.GetActivity().Call("Init", new object[]
		{
			debug
		});
	}

	// Token: 0x060195E7 RID: 103911 RVA: 0x00804FDC File Offset: 0x008033DC
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195E8 RID: 103912 RVA: 0x00804FF4 File Offset: 0x008033F4
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195E9 RID: 103913 RVA: 0x0080500C File Offset: 0x0080340C
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		base.GetActivity().Call("Pay", new object[]
		{
			openUid,
			roleId,
			mallType,
			productId,
			serverId,
			requestId,
			productName,
			price,
			extra,
			true,
			this.OrderUrl
		});
	}

	// Token: 0x060195EA RID: 103914 RVA: 0x00805080 File Offset: 0x00803480
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

	// Token: 0x040122E7 RID: 74471
	private string OrderUrl = "http://120.132.26.173:59003/get_jinli_order";
}
