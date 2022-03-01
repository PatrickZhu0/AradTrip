using System;
using System.Collections;
using GameClient;
using UnityEngine;
using XUPorterJSON;

namespace Client
{
	// Token: 0x0200009E RID: 158
	public static class AppPackageFetcher
	{
		// Token: 0x0600033E RID: 830 RVA: 0x00018E38 File Offset: 0x00017238
		public static IEnumerator FetchFullAppPackage()
		{
			AppPackageFetcher.m_RemoteClientMajor = -1;
			AppPackageFetcher.m_RemoteClientPatch = -1;
			AppPackageFetcher.m_IsFetchURLFinished = false;
			string fetchURL = Singleton<PluginManager>.instance.FullPackageFetchURL(ClientConfig.AppPackageFetchServer, Global.Settings.sdkChannel.ToString(), Singleton<VersionManager>.instance.Version());
			Debug.LogFormat("### Application package SDK channel name:[{0}] fetch URL:'{1}'.", new object[]
			{
				Global.SDKChannelName[(int)Global.Settings.sdkChannel],
				fetchURL
			});
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.reconnectCnt = 3;
			wt.timeout = 2000;
			wt.url = fetchURL;
			yield return wt;
			Debug.LogFormat("### Application package URL [{0}] fetch request has send, waiting response...", new object[]
			{
				fetchURL
			});
			if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				AppPackageFetchResult resultJson = wt.GetResultJson<AppPackageFetchResult>();
				if (resultJson != null)
				{
					if (resultJson.result.Equals("success", StringComparison.OrdinalIgnoreCase))
					{
						AppPackageFetcher.m_FullAppPackageURL = resultJson.url;
						AppPackageFetcher.m_RemoteFullPackageVersion = resultJson.version;
						Debug.LogFormat("### Application package remote version string:{0}", new object[]
						{
							AppPackageFetcher.m_RemoteFullPackageVersion
						});
						Debug.LogFormat("### Application package download url:{0}", new object[]
						{
							AppPackageFetcher.m_FullAppPackageURL
						});
						AppPackageFetcher._GetVersionFromVersionString(AppPackageFetcher.m_RemoteFullPackageVersion, ref AppPackageFetcher.m_RemoteClientMajor, ref AppPackageFetcher.m_RemoteClientPatch);
					}
					else
					{
						Debug.LogWarningFormat("Fetch application package URL has trouble! return with:{0}.", new object[]
						{
							resultJson.result
						});
					}
				}
				else
				{
					Debug.LogWarningFormat("BaseWaitHttpRequest GetResultJson parse failed! [Fetch URL:{0}]", new object[]
					{
						fetchURL
					});
				}
			}
			else
			{
				Debug.LogWarningFormat("Fetch application package URL has failed!", new object[0]);
			}
			AppPackageFetcher.m_IsFetchURLFinished = true;
			yield break;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00018E4C File Offset: 0x0001724C
		public static bool InitNativePackageVersion()
		{
			AppPackageFetcher.m_NativeClientMajor = -1;
			AppPackageFetcher.m_NativeClientPatch = -1;
			string jsonData;
			if (FileArchiveAccessor.LoadFileInLocalFileArchive("version.json", out jsonData))
			{
				AppPackageFetcher.m_NativeFullPackageVersion = AppPackageFetcher._GetVersionFromJson(jsonData);
				Debug.LogFormat("### Application package native version string:{0}", new object[]
				{
					AppPackageFetcher.m_NativeFullPackageVersion
				});
				return AppPackageFetcher._GetVersionFromVersionString(AppPackageFetcher.m_NativeFullPackageVersion, ref AppPackageFetcher.m_NativeClientMajor, ref AppPackageFetcher.m_NativeClientPatch);
			}
			return false;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00018EAF File Offset: 0x000172AF
		public static bool IsVersionValid()
		{
			return AppPackageFetcher.m_NativeClientMajor != -1 && AppPackageFetcher.m_NativeClientPatch != -1 && AppPackageFetcher.m_RemoteClientMajor != -1 && -1 != AppPackageFetcher.m_RemoteClientPatch;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00018EE0 File Offset: 0x000172E0
		public static bool IsRemoteNewer()
		{
			return AppPackageFetcher.m_RemoteClientMajor > AppPackageFetcher.m_NativeClientMajor || (AppPackageFetcher.m_RemoteClientMajor == AppPackageFetcher.m_NativeClientMajor && AppPackageFetcher.m_RemoteClientPatch > AppPackageFetcher.m_NativeClientPatch);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00018F16 File Offset: 0x00017316
		public static void SkipFetchAgain(bool skip)
		{
			AppPackageFetcher.m_SkipFetchAgain = skip;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00018F20 File Offset: 0x00017320
		public static void OpenAppPackageURL()
		{
			if (!AppPackageFetcher.m_IsFetchURLFinished)
			{
				Debug.LogWarning("### Application package URL fetch is not finish yet, You should begin fetch first.");
				return;
			}
			if (string.IsNullOrEmpty(AppPackageFetcher.m_FullAppPackageURL))
			{
				Debug.LogWarning("### Application package URL is empty string.");
				return;
			}
			Debug.LogFormat("### Application package URL fetch success, open application target url:'{0}'.", new object[]
			{
				AppPackageFetcher.m_FullAppPackageURL
			});
			Application.OpenURL(AppPackageFetcher.m_FullAppPackageURL);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00018F80 File Offset: 0x00017380
		public static bool NeedFetchAppPackage()
		{
			if (ClientConfig.AppPackageFetchEnable)
			{
				int androidOSAPILevel = (int)OSInfo.GetAndroidOSAPILevel();
				if (ClientConfig.AppMinAndroidLevel <= androidOSAPILevel && androidOSAPILevel <= ClientConfig.AppMaxAndroidLevel)
				{
					return !AppPackageFetcher.m_SkipFetchAgain;
				}
			}
			return false;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00018FC0 File Offset: 0x000173C0
		private static bool _GetVersionFromVersionString(string versionString, ref int majorClient, ref int patchClient)
		{
			majorClient = -1;
			patchClient = -1;
			string[] array = versionString.Split(new char[]
			{
				'.'
			});
			if (array.Length == 4)
			{
				if (int.TryParse(array[2], out majorClient))
				{
					if (int.TryParse(array[3], out patchClient))
					{
						return true;
					}
					Debug.LogError("Client application package fetch parse patch version has failed!");
				}
				else
				{
					Debug.LogError("Client application package fetch parse major version has failed!");
				}
			}
			else
			{
				Debug.LogWarning("Local version string is invalid(while split version string to sub versions)!");
			}
			return false;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00019038 File Offset: 0x00017438
		private static string _GetVersionFromJson(string jsonData)
		{
			try
			{
				Hashtable hashtable = MiniJSON.jsonDecode(jsonData) as Hashtable;
				return hashtable[AppPackageFetcher.PlatformString] as string;
			}
			catch (Exception ex)
			{
			}
			return "1.0.1.0";
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00019084 File Offset: 0x00017484
		public static string PlatformString
		{
			get
			{
				return "android";
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001908C File Offset: 0x0001748C
		private static IEnumerator _OpenAppPackageUrl()
		{
			yield return AppPackageFetcher.FetchFullAppPackage();
			AppPackageFetcher.OpenAppPackageURL();
			yield break;
		}

		// Token: 0x04000335 RID: 821
		private static readonly string DEFAULT_VERSION = "1.0.1.0";

		// Token: 0x04000336 RID: 822
		private static string m_FullAppPackageURL = string.Empty;

		// Token: 0x04000337 RID: 823
		private static bool m_IsFetchURLFinished = false;

		// Token: 0x04000338 RID: 824
		private static string m_RemoteFullPackageVersion = AppPackageFetcher.DEFAULT_VERSION;

		// Token: 0x04000339 RID: 825
		private static string m_NativeFullPackageVersion = AppPackageFetcher.DEFAULT_VERSION;

		// Token: 0x0400033A RID: 826
		private static int m_RemoteClientMajor = -1;

		// Token: 0x0400033B RID: 827
		private static int m_RemoteClientPatch = -1;

		// Token: 0x0400033C RID: 828
		private static int m_NativeClientMajor = -1;

		// Token: 0x0400033D RID: 829
		private static int m_NativeClientPatch = -1;

		// Token: 0x0400033E RID: 830
		private static bool m_SkipFetchAgain = false;
	}
}
