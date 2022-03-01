using System;

namespace YIMEngine
{
	// Token: 0x02004A96 RID: 19094
	public interface ReconnectListen
	{
		// Token: 0x0601BB3D RID: 113469
		void OnStartReconnect();

		// Token: 0x0601BB3E RID: 113470
		void OnRecvReconnectResult(ReconnectResult result);
	}
}
