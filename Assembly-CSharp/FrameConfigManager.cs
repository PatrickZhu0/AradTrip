using System;
using System.Text;
using LitJson;
using UnityEngine;

// Token: 0x0200012B RID: 299
public class FrameConfigManager : Singleton<FrameConfigManager>
{
	// Token: 0x06000892 RID: 2194 RVA: 0x0002DCA8 File Offset: 0x0002C0A8
	public void LoadFrameConfig()
	{
		byte[] array = this._loadData();
		if (array != null)
		{
			string @string = Encoding.Default.GetString(array);
			FrameConfigManager.FrameConfig frameConfig = JsonMapper.ToObject<FrameConfigManager.FrameConfig>(@string);
			FrameSync.logicUpdateStep = 32U;
			FrameSync.logicFrameStepDelta = frameConfig.logicFrameStepDelta;
			Debug.LogFormat("[FrameConfig] 更新设置 {0} , {1}, {2}", new object[]
			{
				Global.Settings.logicFrameStep,
				FrameSync.logicUpdateStep,
				FrameSync.logicFrameStepDelta
			});
		}
		else
		{
			Debug.LogFormat("[FrameConfig] 加载失败", new object[0]);
		}
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0002DD38 File Offset: 0x0002C138
	private byte[] _loadData()
	{
		byte[] array = null;
		try
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive("frameconfig.conf", out array);
			if (array == null || array.Length <= 0)
			{
			}
		}
		catch (Exception ex)
		{
		}
		return array;
	}

	// Token: 0x0400056B RID: 1387
	private const string kConfigFileName = "frameconfig.conf";

	// Token: 0x0200012C RID: 300
	public class FrameConfig
	{
		// Token: 0x0400056C RID: 1388
		public uint logicUpdateStep = 16U;

		// Token: 0x0400056D RID: 1389
		public uint logicFrameStep = 1U;

		// Token: 0x0400056E RID: 1390
		public int logicFrameStepDelta = 1;
	}
}
