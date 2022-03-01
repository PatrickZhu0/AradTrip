using System;

namespace YIMEngine
{
	// Token: 0x02004A95 RID: 19093
	public interface NoticeListen
	{
		// Token: 0x0601BB3B RID: 113467
		void OnRecvNotice(Notice notice);

		// Token: 0x0601BB3C RID: 113468
		void OnCancelNotice(ulong noticeID, string channelID);
	}
}
