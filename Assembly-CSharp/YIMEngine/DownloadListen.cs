using System;

namespace YIMEngine
{
	// Token: 0x02004A90 RID: 19088
	public interface DownloadListen
	{
		// Token: 0x0601BB19 RID: 113433
		void OnDownload(ErrorCode errorcode, MessageInfoBase message, string strSavePath);

		// Token: 0x0601BB1A RID: 113434
		void OnDownloadByUrl(ErrorCode errorcode, string strFromUrl, string strSavePath);
	}
}
