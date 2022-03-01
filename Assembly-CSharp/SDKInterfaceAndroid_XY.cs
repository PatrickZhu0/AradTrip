using System;

// Token: 0x02004665 RID: 18021
public class SDKInterfaceAndroid_XY : SDKInterfaceAndroid
{
	// Token: 0x0601964C RID: 104012 RVA: 0x008072CF File Offset: 0x008056CF
	public override void Init(bool debug)
	{
		base.Init(debug);
		base.GetActivity().Call("InitXY", new object[]
		{
			debug
		});
	}

	// Token: 0x0601964D RID: 104013 RVA: 0x008072F7 File Offset: 0x008056F7
	public override void Login()
	{
		base.Login();
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x0601964E RID: 104014 RVA: 0x00807315 File Offset: 0x00805715
	public override void Pay(string price, string extra = "", int serverID = 0, string openuid = "")
	{
		base.GetActivity().Call("Pay", new object[]
		{
			"test app",
			"test app describe",
			price,
			extra,
			serverID
		});
	}

	// Token: 0x04012310 RID: 74512
	private const string APP_ID = "100031076";

	// Token: 0x04012311 RID: 74513
	private const string APP_KEY = "gOQuxDl7uY0k7t5OR1uU72Bu8f8JN5BJ";

	// Token: 0x04012312 RID: 74514
	private const string APP_PAYBACK = "GPpvimdx4OTKUaQnWwwst3VCQtVYogdD";

	// Token: 0x04012313 RID: 74515
	private const string PAY_APP_NAME = "test app";

	// Token: 0x04012314 RID: 74516
	private const string PAY_APP_DESC = "test app describe";
}
