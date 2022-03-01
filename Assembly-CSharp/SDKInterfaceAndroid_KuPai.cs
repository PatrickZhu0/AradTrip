using System;
using UnityEngine;

// Token: 0x0200465C RID: 18012
public class SDKInterfaceAndroid_KuPai : SDKInterfaceAndroid
{
	// Token: 0x060195FA RID: 103930 RVA: 0x008056C4 File Offset: 0x00803AC4
	public override void Init(bool debug)
	{
		base.Init(debug);
		int num = 0;
		string text = string.Format("http://{0}/query", Global.LOGIN_SERVER_ADDRESS);
		string platformNameByChannel = this.GetPlatformNameByChannel();
		base.GetActivity().Call("Init", new object[]
		{
			debug,
			num,
			text,
			platformNameByChannel,
			SystemInfo.deviceUniqueIdentifier
		});
	}

	// Token: 0x060195FB RID: 103931 RVA: 0x00805729 File Offset: 0x00803B29
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195FC RID: 103932 RVA: 0x00805741 File Offset: 0x00803B41
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195FD RID: 103933 RVA: 0x0080575C File Offset: 0x00803B5C
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		int num = 0;
		if (int.TryParse(this.GetProductId(productId), out num))
		{
			base.GetActivity().Call("Pay", new object[]
			{
				requestId,
				num,
				productName,
				extra
			});
		}
		else
		{
			Debug.LogError("GetProductId failed");
		}
	}

	// Token: 0x060195FE RID: 103934 RVA: 0x008057BC File Offset: 0x00803BBC
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

	// Token: 0x060195FF RID: 103935 RVA: 0x00805805 File Offset: 0x00803C05
	public override void SetAccInfo(string openid, string accesstoken)
	{
		base.GetActivity().Call("SetCoolInfo", new object[]
		{
			openid,
			accesstoken
		});
	}
}
