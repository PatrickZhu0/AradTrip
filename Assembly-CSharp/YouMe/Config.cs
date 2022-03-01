using System;
using YIMEngine;

namespace YouMe
{
	// Token: 0x02004AA4 RID: 19108
	public class Config
	{
		// Token: 0x17002542 RID: 9538
		// (get) Token: 0x0601BB4F RID: 113487 RVA: 0x00880D07 File Offset: 0x0087F107
		// (set) Token: 0x0601BB50 RID: 113488 RVA: 0x00880D0F File Offset: 0x0087F10F
		public ServerZone ServerZone { get; set; }

		// Token: 0x17002543 RID: 9539
		// (get) Token: 0x0601BB51 RID: 113489 RVA: 0x00880D18 File Offset: 0x0087F118
		// (set) Token: 0x0601BB52 RID: 113490 RVA: 0x00880D20 File Offset: 0x0087F120
		public LogLevel LogLevel { get; set; }

		// Token: 0x17002544 RID: 9540
		// (set) Token: 0x0601BB53 RID: 113491 RVA: 0x00880D29 File Offset: 0x0087F129
		public string CachePath
		{
			set
			{
				this._cachePath = value;
				this.SetAudioCachePath(this._cachePath);
			}
		}

		// Token: 0x0601BB54 RID: 113492 RVA: 0x00880D3E File Offset: 0x0087F13E
		private void SetAudioCachePath(string cachePath)
		{
			IMAPI.Instance().SetAudioCachePath(cachePath);
			Log.e("初始化 设置语音缓存目录" + cachePath);
		}

		// Token: 0x04013553 RID: 79187
		private string _cachePath;
	}
}
