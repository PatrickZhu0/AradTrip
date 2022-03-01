using System;
using System.Text;
using UnityEngine;

// Token: 0x02004661 RID: 18017
public class SDKInterfaceAndroid_SAMSUNG : SDKInterfaceAndroid
{
	// Token: 0x06019625 RID: 103973 RVA: 0x00806630 File Offset: 0x00804A30
	public override void Init(bool debug)
	{
		base.Init(debug);
		string text = string.Format("http://{0}/query", Global.LOGIN_SERVER_ADDRESS);
		string platformNameByChannel = this.GetPlatformNameByChannel();
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			"聚和网络",
			"5000915307",
			"rvk6433igw",
			"8C61BD297AD340396E40F67249B8B011",
			"MIICXAIBAAKBgQCmTldLSwpD6lQUhmS0cuwdEAshZD86TVpckyyQmsn9aiwMK8Px7DAlD6LVNJI0h8I+b0IXyF6UaAEDu8E0NY/6OFZnthry2TWze48oMk+Iu5EQZ0JLvM+Q0JNWprA8SX4/3jWpeUgEuX5wm+5c3TOfE4k0eVtQ88HATIJB5YAt4wIDAQABAoGAd+8hdzQ7x/TTBCZTs+r5KpBqZn9kNciZNRASYIqwxuftsi1R10MtCV04YifSlL2fMOWNtZcT1lUW/jlGQT+rf23nabt6MGqTx0DMKuiEAGviLY/Vspi/Pw4sG3m4IC+k5tt2I7I8NbiwhuFecgdb4SoEpUNaNk9KdlIhyxDbGnECQQDm9DE9p/Y0yup/5mukUOKN26RisPzwszcQRQitVLFKLbneUTCMhiwur2jLh76Gz1S+EzWwb7TpKJHzYNfqb/mrAkEAuFdgVzP/vePOjbJNvX928+UntzlY0L+ErhsF6JGP7XYW7UgJn+Rl4B9lv2ACGuL39zcBWMvWkyTldeWdYTkUqQJBAIHrjqOzj8IFAEOw2I7X3YqVq3TFQZUaC/jADPCMuysSbAPPQnNaqxIcJOSR2TE3AuHmJoa5YFjlNK1npi7AjP8CQGC29wTJc1PdQXF2KvNQ/MfZYozuuXpMAQCXjPIH7MtZOY4kTWhmHE0KLAfMB06z5gT+BubfiySIJxtD7N4lZIECQE4syt9VzVz+ZaYMhaVdMC8rW/EGbo+HzI20PzRc9JEphL0yKxFZ3IJVHEs7sdxEL2nzmkQs3jx/vAgYM0loWsg=",
			"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDbhVas0JUhJoE9Ut6z34oYnDhNYmnlZy0YhislpTei1h2FUB6x/Y2r2bqvSzvUZmNWdPT0bU/yN6MCfZTnvzqkv2te6uzYJ0u/yK6RZX5UwygrTSen3ZlrrBTWRCPc62tppH0em78JHRWgkvIDqxlS3HfUFwHELJnTZYLLpaE4pQIDAQAB",
			string.Empty,
			text,
			platformNameByChannel
		});
	}

	// Token: 0x06019626 RID: 103974 RVA: 0x008066BC File Offset: 0x00804ABC
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x06019627 RID: 103975 RVA: 0x008066D4 File Offset: 0x00804AD4
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x06019628 RID: 103976 RVA: 0x008066EC File Offset: 0x00804AEC
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

	// Token: 0x06019629 RID: 103977 RVA: 0x00806750 File Offset: 0x00804B50
	public override string LoginVerifyUrl(string serverUrl, string serverId, string openuid, string token, string deviceId, string sdkChannel, string ext)
	{
		string text = Convert.ToBase64String(Encoding.Default.GetBytes(ext));
		return string.Format("http://{0}/login?id={1}&openid={2}&token={3}&did={4}&platform={5}&ext={6}", new object[]
		{
			serverUrl,
			serverId,
			openuid,
			Uri.EscapeDataString(token),
			SystemInfo.deviceUniqueIdentifier,
			"samsung",
			text
		});
	}

	// Token: 0x0601962A RID: 103978 RVA: 0x008067AB File Offset: 0x00804BAB
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

	// Token: 0x040122FE RID: 74494
	private const string COMPANY_NAME = "聚和网络";

	// Token: 0x040122FF RID: 74495
	private const string APP_ID = "5000915307";

	// Token: 0x04012300 RID: 74496
	private const string CLIENT_ID = "rvk6433igw";

	// Token: 0x04012301 RID: 74497
	private const string CLIENT_SECRET = "8C61BD297AD340396E40F67249B8B011";

	// Token: 0x04012302 RID: 74498
	private const string PRIVATE_KEY = "MIICXAIBAAKBgQCmTldLSwpD6lQUhmS0cuwdEAshZD86TVpckyyQmsn9aiwMK8Px7DAlD6LVNJI0h8I+b0IXyF6UaAEDu8E0NY/6OFZnthry2TWze48oMk+Iu5EQZ0JLvM+Q0JNWprA8SX4/3jWpeUgEuX5wm+5c3TOfE4k0eVtQ88HATIJB5YAt4wIDAQABAoGAd+8hdzQ7x/TTBCZTs+r5KpBqZn9kNciZNRASYIqwxuftsi1R10MtCV04YifSlL2fMOWNtZcT1lUW/jlGQT+rf23nabt6MGqTx0DMKuiEAGviLY/Vspi/Pw4sG3m4IC+k5tt2I7I8NbiwhuFecgdb4SoEpUNaNk9KdlIhyxDbGnECQQDm9DE9p/Y0yup/5mukUOKN26RisPzwszcQRQitVLFKLbneUTCMhiwur2jLh76Gz1S+EzWwb7TpKJHzYNfqb/mrAkEAuFdgVzP/vePOjbJNvX928+UntzlY0L+ErhsF6JGP7XYW7UgJn+Rl4B9lv2ACGuL39zcBWMvWkyTldeWdYTkUqQJBAIHrjqOzj8IFAEOw2I7X3YqVq3TFQZUaC/jADPCMuysSbAPPQnNaqxIcJOSR2TE3AuHmJoa5YFjlNK1npi7AjP8CQGC29wTJc1PdQXF2KvNQ/MfZYozuuXpMAQCXjPIH7MtZOY4kTWhmHE0KLAfMB06z5gT+BubfiySIJxtD7N4lZIECQE4syt9VzVz+ZaYMhaVdMC8rW/EGbo+HzI20PzRc9JEphL0yKxFZ3IJVHEs7sdxEL2nzmkQs3jx/vAgYM0loWsg=";

	// Token: 0x04012303 RID: 74499
	private const string PUBLIC_KEY = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDbhVas0JUhJoE9Ut6z34oYnDhNYmnlZy0YhislpTei1h2FUB6x/Y2r2bqvSzvUZmNWdPT0bU/yN6MCfZTnvzqkv2te6uzYJ0u/yK6RZX5UwygrTSen3ZlrrBTWRCPc62tppH0em78JHRWgkvIDqxlS3HfUFwHELJnTZYLLpaE4pQIDAQAB";

	// Token: 0x04012304 RID: 74500
	private const string PAY_NORITY_URL = "";
}
