using System;
using System.Text;
using GameClient;
using UnityEngine;

// Token: 0x0200465B RID: 18011
public class SDKInterfaceAndroid_JunHai : SDKInterfaceAndroid
{
	// Token: 0x060195F2 RID: 103922 RVA: 0x008052E8 File Offset: 0x008036E8
	public override void Init(bool debug)
	{
		base.Init(debug);
		string text = string.Format(this.loginQueryFormat, Global.LOGIN_SERVER_ADDRESS);
		string text2 = string.Format(this.payNotifyFormat, Global.ANDROID_MG_CHARGE);
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		base.GetActivity().Call("InitSDK", new object[]
		{
			debug,
			text2,
			text,
			this.GetPlatformNameByChannel(),
			deviceUniqueIdentifier
		});
	}

	// Token: 0x060195F3 RID: 103923 RVA: 0x00805358 File Offset: 0x00803758
	public override void Login()
	{
		base.GetActivity().Call("Login", new object[0]);
	}

	// Token: 0x060195F4 RID: 103924 RVA: 0x00805370 File Offset: 0x00803770
	public override void Logout()
	{
		base.GetActivity().Call("Logout", new object[0]);
	}

	// Token: 0x060195F5 RID: 103925 RVA: 0x00805388 File Offset: 0x00803788
	public override void Pay(string requestId, string price, int serverId, string openUid, string roleId, int mallType, int productId, string productName, string productDesc, string extra = "")
	{
		string name = DataManager<PlayerBaseData>.GetInstance().Name;
		int num = 1;
		if (!string.IsNullOrEmpty(price))
		{
			int num2 = 0;
			if (int.TryParse(price, out num2))
			{
				num2 *= 100;
				base.GetActivity().Call("Pay", new object[]
				{
					extra,
					roleId,
					name,
					serverId + string.Empty,
					productName,
					productId + string.Empty,
					productDesc,
					num,
					num2
				});
			}
			else if (price.Equals("0.01") && Global.Settings.isPaySDKDebug)
			{
				num2 = 1;
				base.GetActivity().Call("Pay", new object[]
				{
					extra,
					roleId,
					name,
					serverId + string.Empty,
					productName,
					productId + string.Empty,
					productDesc,
					num,
					num2
				});
			}
		}
	}

	// Token: 0x060195F6 RID: 103926 RVA: 0x008054B8 File Offset: 0x008038B8
	public override void SetAccInfo(string openid, string token)
	{
		try
		{
			base.GetActivity().Call("SetLoginInfo", new object[]
			{
				openid,
				token
			});
		}
		catch (Exception ex)
		{
			Logger.LogError("Junhai unity SetLoginInfo failed : " + ex.ToString());
		}
	}

	// Token: 0x060195F7 RID: 103927 RVA: 0x00805514 File Offset: 0x00803914
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
			this.GetPlatformNameByChannel(),
			ext
		});
	}

	// Token: 0x060195F8 RID: 103928 RVA: 0x0080556C File Offset: 0x0080396C
	public override void UpdateRoleInfo(int scene, uint serverID, string serverName, string roleID, string roleName, int proID, int roleLevel = 1, int vip = 0, int dianquanNum = 0)
	{
		try
		{
			string empty = string.Empty;
			if (scene != 1)
			{
				if (scene != 2)
				{
					if (scene != 3)
					{
						if (scene == 4)
						{
						}
					}
				}
			}
			if (scene != 4)
			{
				string text = string.Empty;
				if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
				{
					GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
					text = myGuild.strName;
				}
				else
				{
					text = "无";
				}
				int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				base.GetActivity().Call("ReporterRoleInfo", new object[]
				{
					scene,
					serverID + string.Empty,
					serverName,
					roleID,
					roleName,
					roleLevel,
					vip,
					dianquanNum,
					text,
					serverTime
				});
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("上报角色信息 失败" + ex.ToString(), new object[0]);
		}
	}

	// Token: 0x040122EC RID: 74476
	private string payNotifyUrl = "http://120.132.26.173:59003/junhai_charge";

	// Token: 0x040122ED RID: 74477
	private string loginQueryUrl = "http://120.132.26.173:59006/query";

	// Token: 0x040122EE RID: 74478
	private string loginQueryFormat = "http://{0}/query?";

	// Token: 0x040122EF RID: 74479
	private string payNotifyFormat = "http://{0}/junhai_charge";
}
