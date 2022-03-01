using System;
using System.IO;
using UnityEngine;

// Token: 0x02004A40 RID: 19008
public class UniWebViewHelper
{
	// Token: 0x0601B774 RID: 112500 RVA: 0x00877696 File Offset: 0x00875A96
	public static string StreamingAssetURLForPath(string path)
	{
		return Path.Combine("file:///android_asset/", path);
	}

	// Token: 0x0601B775 RID: 112501 RVA: 0x008776A3 File Offset: 0x00875AA3
	public static string PersistentDataURLForPath(string path)
	{
		return Path.Combine("file://" + Application.persistentDataPath, path);
	}
}
