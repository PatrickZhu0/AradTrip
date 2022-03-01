using System;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class AndroidSoUtility
{
	// Token: 0x0600033B RID: 827 RVA: 0x00018D58 File Offset: 0x00017158
	public static string GetCoreLibPath()
	{
		string text = string.Empty;
		try
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getApplicationInfo", new object[0]);
			int static2 = @static.GetStatic<int>("MODE_PRIVATE");
			AndroidJavaObject androidJavaObject2 = @static.Call<AndroidJavaObject>("getDir", new object[]
			{
				AndroidSoUtility.kSoLibDirName,
				static2
			});
			text = androidJavaObject2.Call<string>("getAbsolutePath", new object[0]);
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("[AndroidSoUtility] GetLibDirPath Error {0}", new object[]
			{
				ex.ToString()
			});
		}
		Debug.LogFormat("[AndroidSoUtility] GetLibDirPath {0}", new object[]
		{
			text
		});
		return text;
	}

	// Token: 0x04000331 RID: 817
	private static string kSoLibDirName = "corelibs";
}
