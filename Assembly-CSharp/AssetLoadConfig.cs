using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020000B0 RID: 176
public class AssetLoadConfig : Singleton<AssetLoadConfig>
{
	// Token: 0x0600039E RID: 926 RVA: 0x0001A97C File Offset: 0x00018D7C
	public override void Init()
	{
		this.m_AsyncLoad = true;
		string path = "Environment/LoadConfig.json";
		Object obj = Singleton<AssetLoader>.instance.LoadRes(path, true, 0U).obj;
		if (obj == null)
		{
			return;
		}
		string @string = Encoding.Default.GetString((obj as TextAsset).bytes);
		Hashtable hashtable = MiniJSON.jsonDecode(@string) as Hashtable;
		try
		{
			int num = 1;
			string text = hashtable["AsyncLoad"].ToString();
			if (!string.IsNullOrEmpty(text) && int.TryParse(text, out num) && num == 0)
			{
				this.m_AsyncLoad = false;
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("读取LoadConfig.json出错" + ex.ToString());
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600039F RID: 927 RVA: 0x0001AA4C File Offset: 0x00018E4C
	public bool asyncLoad
	{
		get
		{
			return this.m_AsyncLoad;
		}
	}

	// Token: 0x04000379 RID: 889
	private bool m_AsyncLoad = true;
}
