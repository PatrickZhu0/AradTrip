using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020001E4 RID: 484
public class RemoteConfig : MonoSingleton<RemoteConfig>
{
	// Token: 0x06000F4F RID: 3919 RVA: 0x0004E338 File Offset: 0x0004C738
	public IEnumerator FetchRemoteConfig()
	{
		this.m_ConfigLoaded = false;
		if (this.m_ServerList == null)
		{
			yield return this._LoadServerList();
		}
		if (this.m_ServerList != null)
		{
			int serverIdx = Random.Range(0, this.m_ServerList.Count);
			string serverRoot = this.m_ServerList[serverIdx] as string;
			if (!string.IsNullOrEmpty(serverRoot))
			{
				int retryCnt = 0;
				WWW serverWWW = null;
				for (;;)
				{
					string configPath = Path.Combine(serverRoot, this.REMOTE_CONFIG_FILE_NAME);
					configPath = configPath.Replace("\\", "/");
					if (configPath.Contains("?"))
					{
						configPath = string.Format("{0}&tsp={1}", configPath, Utility.GetCurrentTimeUnix() / 300U);
					}
					else
					{
						configPath = string.Format("{0}?tsp={1}", configPath, Utility.GetCurrentTimeUnix() / 300U);
					}
					Debug.Log("URL:[" + configPath + "]!");
					float time = Time.realtimeSinceStartup;
					serverWWW = new WWW(configPath);
					yield return serverWWW;
					time = Time.realtimeSinceStartup - time;
					if (time * 1000f > 1f)
					{
						Debug.LogFormat("### RemoteConfig fetchTime:{0}", new object[]
						{
							time
						});
					}
					if (serverWWW.error == null)
					{
						break;
					}
					if (this._IsFileNotFound(serverWWW.error))
					{
						goto Block_7;
					}
					Logger.LogErrorFormat("连接资源服务器失败[{0}]!", new object[]
					{
						serverWWW.error
					});
					retryCnt++;
					if (retryCnt >= 3)
					{
						goto IL_2A3;
					}
				}
				this._ParseRemoveConfig(Encoding.Default.GetString(serverWWW.bytes));
				this.m_ConfigLoaded = true;
				yield break;
				Block_7:
				yield break;
			}
		}
		IL_2A3:
		yield break;
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x0004E353 File Offset: 0x0004C753
	public bool IsRoleNameInBlackList(string roleName)
	{
		return this.m_BuglyBlackRoleList != null && this.m_BuglyBlackRoleList.Contains(roleName);
	}

	// Token: 0x06000F51 RID: 3921 RVA: 0x0004E36E File Offset: 0x0004C76E
	public bool IsAndroidInBlackList(string androidAPI)
	{
		Debug.LogFormat("### OS API Level:{0}", new object[]
		{
			androidAPI
		});
		return this.m_BuglyBlackAndroidList != null && this.m_BuglyBlackAndroidList.Contains(androidAPI);
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x0004E3A0 File Offset: 0x0004C7A0
	public string GetCurrentOSAndroidAPILevel()
	{
		string operatingSystem = SystemInfo.operatingSystem;
		Debug.LogFormat("### Current OS:{0}", new object[]
		{
			operatingSystem
		});
		if (operatingSystem.Contains("Android OS", StringComparison.OrdinalIgnoreCase))
		{
			int num = operatingSystem.IndexOf("API-");
			if (0 <= num && num < operatingSystem.Length)
			{
				int num2 = 0;
				while (num2 + 4 + num < operatingSystem.Length)
				{
					char c = operatingSystem[num + 4 + num2];
					if ('9' < c || c < '0')
					{
						break;
					}
					num2++;
				}
				return operatingSystem.Substring(num + 4, num2);
			}
		}
		return string.Empty;
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x0004E443 File Offset: 0x0004C843
	private bool _IsFileNotFound(string error)
	{
		return error.Contains("404");
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x0004E450 File Offset: 0x0004C850
	protected void _ParseRemoveConfig(string jsonData)
	{
		Hashtable hashtable = MiniJSON.jsonDecode(jsonData) as Hashtable;
		if (hashtable != null)
		{
			Hashtable hashtable2 = hashtable["Bugly"] as Hashtable;
			if (hashtable2 != null)
			{
				ArrayList arrayList = hashtable2["RoleName"] as ArrayList;
				if (arrayList != null)
				{
					this.m_BuglyBlackRoleList.Clear();
					this.m_BuglyBlackRoleList.Capacity = arrayList.Count;
					int i = 0;
					int count = arrayList.Count;
					while (i < count)
					{
						this.m_BuglyBlackRoleList.Add(arrayList[i] as string);
						i++;
					}
				}
				ArrayList arrayList2 = hashtable2["AndroidAPI"] as ArrayList;
				if (arrayList2 != null)
				{
					this.m_BuglyBlackAndroidList.Clear();
					this.m_BuglyBlackAndroidList.Capacity = arrayList2.Count;
					int j = 0;
					int count2 = arrayList2.Count;
					while (j < count2)
					{
						this.m_BuglyBlackAndroidList.Add(arrayList2[j] as string);
						j++;
					}
				}
			}
		}
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x0004E55C File Offset: 0x0004C95C
	protected IEnumerator _LoadServerList()
	{
		byte[] fileData = null;
		string path = Path.Combine(this._GetHotfixAccessUrlProtocol(), this.UPDATA_SERVER_HACK_FILE_NAME);
		WWW www = new WWW(path);
		yield return www;
		if (www.error == null)
		{
			fileData = www.bytes;
		}
		if (fileData == null)
		{
			if (www != null)
			{
				www.Dispose();
			}
			path = Path.Combine(this._GetLocalAccessUrlProtocol(), this.UPDATA_SERVER_FILE_NAME);
			www = new WWW(path);
			yield return www;
			if (www.error == null)
			{
				fileData = www.bytes;
			}
			else
			{
				Debug.LogWarning(www.error);
			}
			if (fileData != null)
			{
				this.m_ServerList = this._GetUpdateServerFromJson(Encoding.Default.GetString(fileData));
			}
			else
			{
				Logger.LogErrorFormat("Can not open server config file with path:{0}", new object[]
				{
					path
				});
			}
		}
		if (www != null)
		{
			www.Dispose();
		}
		yield break;
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x0004E578 File Offset: 0x0004C978
	protected ArrayList _GetUpdateServerFromJson(string jsonData)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList result;
		try
		{
			Hashtable hashtable = MiniJSON.jsonDecode(jsonData) as Hashtable;
			if (Global.Settings.hotFixUrlDebug)
			{
				arrayList = (hashtable["debug"] as ArrayList);
			}
			else
			{
				arrayList = (hashtable["release"] as ArrayList);
			}
			result = arrayList;
		}
		catch (Exception ex)
		{
			arrayList.Clear();
			result = arrayList;
		}
		return result;
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x0004E5F4 File Offset: 0x0004C9F4
	protected string _GetLocalAccessUrlProtocol()
	{
		return "jar:file://" + Application.dataPath + "!/assets/";
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x0004E60A File Offset: 0x0004CA0A
	protected string _GetHotfixAccessUrlProtocol()
	{
		return "file://" + Application.persistentDataPath;
	}

	// Token: 0x04000A94 RID: 2708
	protected readonly string REMOTE_CONFIG_FILE_NAME = "remote_config.json";

	// Token: 0x04000A95 RID: 2709
	protected readonly string UPDATA_SERVER_FILE_NAME = "updateserver.json";

	// Token: 0x04000A96 RID: 2710
	protected readonly string UPDATA_SERVER_HACK_FILE_NAME = "updateserver-hack.json";

	// Token: 0x04000A97 RID: 2711
	protected ArrayList m_ServerList;

	// Token: 0x04000A98 RID: 2712
	protected bool m_ConfigLoaded;

	// Token: 0x04000A99 RID: 2713
	private List<string> m_BuglyBlackRoleList = new List<string>();

	// Token: 0x04000A9A RID: 2714
	private List<string> m_BuglyBlackAndroidList = new List<string>();
}
