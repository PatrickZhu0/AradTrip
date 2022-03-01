using System;
using System.Text;
using LitJson;

// Token: 0x020046C4 RID: 18116
public class RecordServerConfigManager : Singleton<RecordServerConfigManager>
{
	// Token: 0x06019AEF RID: 105199 RVA: 0x00818D52 File Offset: 0x00817152
	public bool isPrintStack()
	{
		return this.mConfig != null && this.mConfig.isPrintStack;
	}

	// Token: 0x06019AF0 RID: 105200 RVA: 0x00818D6C File Offset: 0x0081716C
	public string GetVersion()
	{
		return this.mVersion;
	}

	// Token: 0x06019AF1 RID: 105201 RVA: 0x00818D74 File Offset: 0x00817174
	public bool isRecordProcess()
	{
		return this.mConfig != null && this.mConfig.isRecordProcess;
	}

	// Token: 0x06019AF2 RID: 105202 RVA: 0x00818D8E File Offset: 0x0081718E
	public bool isRecordReplay()
	{
		return this.mConfig != null && this.mConfig.isRecordReplay;
	}

	// Token: 0x06019AF3 RID: 105203 RVA: 0x00818DA8 File Offset: 0x008171A8
	public override void Init()
	{
		this._loadRecordServerConfig();
	}

	// Token: 0x06019AF4 RID: 105204 RVA: 0x00818DB0 File Offset: 0x008171B0
	private void _loadRecordServerConfig()
	{
		byte[] array = this._loadData();
		if (array == null)
		{
			return;
		}
		try
		{
			string @string = Encoding.Default.GetString(array);
			this.mConfig = JsonMapper.ToObject<RecordServerConfigManager.RecordServerConfig>(@string);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[recordServerconfig] 解析JSON失败 {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x06019AF5 RID: 105205 RVA: 0x00818E18 File Offset: 0x00817218
	private byte[] _loadData()
	{
		return null;
	}

	// Token: 0x040124CE RID: 74958
	private RecordServerConfigManager.RecordServerConfig mConfig = new RecordServerConfigManager.RecordServerConfig();

	// Token: 0x040124CF RID: 74959
	private string mVersion = string.Empty;

	// Token: 0x040124D0 RID: 74960
	private const string kConfigFileName = "recordserver.json";

	// Token: 0x040124D1 RID: 74961
	private const string kVersionFileName = "version.cfg";

	// Token: 0x020046C5 RID: 18117
	private class RecordServerConfig
	{
		// Token: 0x040124D2 RID: 74962
		public bool isRecordProcess;

		// Token: 0x040124D3 RID: 74963
		public bool isRecordReplay = true;

		// Token: 0x040124D4 RID: 74964
		public bool isPrintStack;
	}
}
