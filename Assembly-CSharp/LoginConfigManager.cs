using System;
using LitJson;
using UnityEngine;

// Token: 0x020001AE RID: 430
public class LoginConfigManager : Singleton<LoginConfigManager>
{
	// Token: 0x06000DEB RID: 3563 RVA: 0x00048112 File Offset: 0x00046512
	public uint GetServerAddressID()
	{
		return this.mConfig.defaultServer.id;
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x00048124 File Offset: 0x00046524
	public string GetServerAddressIP()
	{
		return this.mConfig.defaultServer.ip;
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00048136 File Offset: 0x00046536
	public ushort GetServerAddressPort()
	{
		return this.mConfig.defaultServer.port;
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x00048148 File Offset: 0x00046548
	public string GetServerAddressName()
	{
		return this.mConfig.defaultServer.name;
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x0004815A File Offset: 0x0004655A
	public int GetServerAddressStatus()
	{
		return this.mConfig.defaultServer.status;
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0004816C File Offset: 0x0004656C
	public int GetUserDataReconnectCount()
	{
		return this.mConfig.userDataReconnectCount;
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x00048179 File Offset: 0x00046579
	public int GetHttpDefaultTimeOut()
	{
		return this.mConfig.httpDefaultTimeOut;
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x00048186 File Offset: 0x00046586
	public int GetHttpDefaultGapTimeOut()
	{
		return this.mConfig.httpDefaultGapTimeOut;
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x00048193 File Offset: 0x00046593
	public int GetHttpDefaultReconnectCount()
	{
		return this.mConfig.httpDefaultReconnectCount;
	}

	// Token: 0x06000DF4 RID: 3572 RVA: 0x000481A0 File Offset: 0x000465A0
	public void LoadBaseLoginConfig()
	{
		string text = this._loadData();
		if (!string.IsNullOrEmpty(text))
		{
			try
			{
				LoginConfigManager.LoginConfig element = JsonMapper.ToObject<LoginConfigManager.LoginConfig>(text);
				this.mConfig = element;
				Debug.LogFormat("[LoginConfig] {0}", new object[]
				{
					ObjectDumper.Dump(element)
				});
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[LoginConfig] fail", new object[0]);
			}
		}
		else
		{
			Debug.LogErrorFormat("[LoginConfig] 加载失败", new object[0]);
		}
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x00048228 File Offset: 0x00046628
	private string _loadData()
	{
		string result = null;
		try
		{
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive("baseloginconfig.conf", out result))
			{
				FileArchiveAccessor.LoadFileInLocalFileArchive("baseloginconfig.conf", out result);
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("[LoginConfig] 加载失败 {0}", new object[]
			{
				ex.ToString()
			});
		}
		return result;
	}

	// Token: 0x040009B1 RID: 2481
	private const string kConfigFileName = "baseloginconfig.conf";

	// Token: 0x040009B2 RID: 2482
	private LoginConfigManager.LoginConfig mConfig = new LoginConfigManager.LoginConfig();

	// Token: 0x020001AF RID: 431
	private class LoginConfig
	{
		// Token: 0x040009B3 RID: 2483
		public int userDataReconnectCount = 5;

		// Token: 0x040009B4 RID: 2484
		public int httpDefaultTimeOut = 5000;

		// Token: 0x040009B5 RID: 2485
		public int httpDefaultGapTimeOut = 1000;

		// Token: 0x040009B6 RID: 2486
		public int httpDefaultReconnectCount = 3;

		// Token: 0x040009B7 RID: 2487
		public LoginConfigManager.ServerAddress defaultServer = new LoginConfigManager.ServerAddress();
	}

	// Token: 0x020001B0 RID: 432
	private class ServerAddress
	{
		// Token: 0x040009B8 RID: 2488
		public uint id = 1U;

		// Token: 0x040009B9 RID: 2489
		public string ip = "0.0.0.0";

		// Token: 0x040009BA RID: 2490
		public ushort port;

		// Token: 0x040009BB RID: 2491
		public string name = string.Empty;

		// Token: 0x040009BC RID: 2492
		public int status;
	}
}
