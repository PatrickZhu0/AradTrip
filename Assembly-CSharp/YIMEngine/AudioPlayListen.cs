using System;

namespace YIMEngine
{
	// Token: 0x02004A8D RID: 19085
	public interface AudioPlayListen
	{
		// Token: 0x0601BB0E RID: 113422
		void OnPlayCompletion(ErrorCode errorcode, string path);

		// Token: 0x0601BB0F RID: 113423
		void OnGetMicrophoneStatus(AudioDeviceStatus status);
	}
}
