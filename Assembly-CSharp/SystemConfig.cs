using System;
using System.Text;
using GameClient;
using LitJson;
using UnityEngine;

// Token: 0x020001ED RID: 493
public class SystemConfig : Singleton<SystemConfig>
{
	// Token: 0x06000F94 RID: 3988 RVA: 0x0004F85C File Offset: 0x0004DC5C
	public void LoadConfig()
	{
		byte[] array = this._loadData();
		if (array != null)
		{
			string @string = Encoding.Default.GetString(array);
			this.mConfigData = JsonMapper.ToObject<SystemConfig.SystemConfigData>(@string);
			ClientSystemManager.sRemoveRefOnClose = this.mConfigData.removeRefOnClose;
		}
		else
		{
			Debug.LogFormat("[SystemConfig] 加载失败", new object[0]);
		}
	}

	// Token: 0x06000F95 RID: 3989 RVA: 0x0004F8B4 File Offset: 0x0004DCB4
	private byte[] _loadData()
	{
		byte[] array = null;
		try
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.mConfigPath, out array);
			if (array == null || array.Length <= 0)
			{
			}
		}
		catch (Exception ex)
		{
			Debug.LogFormat("[SystemConfig] 加载失败:" + ex.ToString(), new object[0]);
		}
		return array;
	}

	// Token: 0x04000AC4 RID: 2756
	protected readonly string mConfigPath = "system.conf";

	// Token: 0x04000AC5 RID: 2757
	protected SystemConfig.SystemConfigData mConfigData = new SystemConfig.SystemConfigData();

	// Token: 0x020001EE RID: 494
	protected class SystemConfigData
	{
		// Token: 0x04000AC6 RID: 2758
		public bool removeRefOnClose;
	}
}
