using System;
using Network;

namespace GameClient
{
	// Token: 0x02001157 RID: 4439
	public interface IClientNet
	{
		// Token: 0x0600A962 RID: 43362
		void OnDisconnect(ServerType type);

		// Token: 0x0600A963 RID: 43363
		void OnReconnect();

		// Token: 0x0600A964 RID: 43364
		void OnReconnectError();
	}
}
