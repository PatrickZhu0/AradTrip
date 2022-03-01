using System;
using System.Text;
using LitJson;
using UnityEngine;

// Token: 0x0200010D RID: 269
public class ClientConfig : Singleton<ClientConfig>
{
	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00024FB2 File Offset: 0x000233B2
	public static bool AppPackageFetchEnable
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageFetchEnable;
		}
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x060005D5 RID: 1493 RVA: 0x00024FC3 File Offset: 0x000233C3
	public static int AppMinAndroidLevel
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appMinAndroidLevel;
		}
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00024FD4 File Offset: 0x000233D4
	public static int AppMaxAndroidLevel
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appMaxAndroidLevel;
		}
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00024FE5 File Offset: 0x000233E5
	public static string AppPackageFetchServer
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageFetchServer;
		}
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00024FF6 File Offset: 0x000233F6
	public static string AppPackageMessageLoginFailed
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageMessageLoginFailed;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00025007 File Offset: 0x00023407
	public static string AppPackageMessageAppVersionLow
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageMessageAppVersionLow;
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x00025018 File Offset: 0x00023418
	public static string AppPackageButTextRetryLogin
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageButTextRetryLogin;
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x060005DB RID: 1499 RVA: 0x00025029 File Offset: 0x00023429
	public static string AppPackageButTextRetryUpdate
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageButTextRetryUpdate;
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x060005DC RID: 1500 RVA: 0x0002503A File Offset: 0x0002343A
	public static string AppPackageButTextOpenURL
	{
		get
		{
			return Singleton<ClientConfig>.instance.m_ConfigData.appPackageButTextOpenURL;
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x0002504B File Offset: 0x0002344B
	public sealed override void Init()
	{
		this.LoadConfig();
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x00025054 File Offset: 0x00023454
	public void LoadConfig()
	{
		try
		{
			byte[] array = this._loadData();
			if (array != null)
			{
				string @string = Encoding.Default.GetString(array);
				this.m_ConfigData = JsonMapper.ToObject<ClientConfig.ClientConfigData>(@string);
			}
			else
			{
				Debug.LogFormat("Client config load failed!", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Debug.LogFormat("Client config load failed with exception:{0}!", new object[]
			{
				ex.Message
			});
		}
		Debug.LogFormat("Client config:[appPackageFetchEnable:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageFetchEnable
		});
		Debug.LogFormat("Client config:[appMinAndroidLevel:'{0}'] ", new object[]
		{
			this.m_ConfigData.appMinAndroidLevel
		});
		Debug.LogFormat("Client config:[appMaxAndroidLevel:'{0}'] ", new object[]
		{
			this.m_ConfigData.appMaxAndroidLevel
		});
		Debug.LogFormat("Client config:[appPackageFetchServer:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageFetchServer
		});
		Debug.LogFormat("Client config:[appPackageMessageLoginFailed:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageMessageLoginFailed
		});
		Debug.LogFormat("Client config:[appPackageMessageAppVersionLow:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageMessageAppVersionLow
		});
		Debug.LogFormat("Client config:[appPackageButTextRetryLogin:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageButTextRetryLogin
		});
		Debug.LogFormat("Client config:[appPackageButTextRetryUpdate:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageButTextRetryUpdate
		});
		Debug.LogFormat("Client config:[appPackageButTextOpenURL:'{0}'] ", new object[]
		{
			this.m_ConfigData.appPackageButTextOpenURL
		});
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x000251EC File Offset: 0x000235EC
	private byte[] _loadData()
	{
		byte[] result = null;
		try
		{
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive("clientconfig.json", out result))
			{
				Debug.LogError("Load client config file from persistent path has failed!");
				if (!FileArchiveAccessor.LoadFileInLocalFileArchive("clientconfig.json", out result))
				{
					Debug.LogError("Load client config file from streaming path has failed!");
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("Load client config file exception:{0}!", new object[]
			{
				ex.Message
			});
		}
		return result;
	}

	// Token: 0x040004FD RID: 1277
	private ClientConfig.ClientConfigData m_ConfigData = new ClientConfig.ClientConfigData();

	// Token: 0x040004FE RID: 1278
	private const string kConfigFileName = "clientconfig.json";

	// Token: 0x0200010E RID: 270
	public class ClientConfigData
	{
		// Token: 0x060005E0 RID: 1504 RVA: 0x00025268 File Offset: 0x00023668
		public ClientConfigData()
		{
			this.appPackageFetchEnable = true;
			this.appMinAndroidLevel = 28;
			this.appMaxAndroidLevel = 28;
			this.appPackageFetchServer = "download.aldzn.com:59000";
			this.appPackageMessageLoginFailed = "当前游戏版本号过低 点击〖重新登录〗进行游戏更新，如果仍不能正常游戏， 请点击〖<color=#ff0000ff>下载客户端</color>〗下载游戏最新版本。";
			this.appPackageMessageAppVersionLow = "当前游戏版本号过低 点击〖尝试更新〗尝试游戏更新，如果仍不能正常游戏， 请点击〖<color=#ff0000ff>下载客户端</color>〗下载游戏最新版本。";
			this.appPackageButTextRetryUpdate = "尝试更新";
			this.appPackageButTextRetryLogin = "重新登录";
			this.appPackageButTextOpenURL = "下载客户端";
		}

		// Token: 0x040004FF RID: 1279
		public bool appPackageFetchEnable;

		// Token: 0x04000500 RID: 1280
		public int appMinAndroidLevel;

		// Token: 0x04000501 RID: 1281
		public int appMaxAndroidLevel;

		// Token: 0x04000502 RID: 1282
		public string appPackageFetchServer;

		// Token: 0x04000503 RID: 1283
		public string appPackageMessageLoginFailed;

		// Token: 0x04000504 RID: 1284
		public string appPackageMessageAppVersionLow;

		// Token: 0x04000505 RID: 1285
		public string appPackageButTextRetryLogin;

		// Token: 0x04000506 RID: 1286
		public string appPackageButTextRetryUpdate;

		// Token: 0x04000507 RID: 1287
		public string appPackageButTextOpenURL;
	}
}
