using System;

namespace GameClient
{
	// Token: 0x0200199E RID: 6558
	internal class ReplayWaitHttpRequest : BaseWaitHttpRequest
	{
		// Token: 0x0600FF5D RID: 65373 RVA: 0x0046BC3E File Offset: 0x0046A03E
		public ReplayWaitHttpRequest(string sessionID, bool isCrossService = false)
		{
			this._setUrl(sessionID, isCrossService);
			base.SetRequestWaitResult();
		}

		// Token: 0x0600FF5E RID: 65374 RVA: 0x0046BC54 File Offset: 0x0046A054
		private void _setUrl(string sessionID, bool isCrossService = false)
		{
			string url = string.Format("http://{0}/replay?serverid={2}&raceid={1}", ClientApplication.replayServer, sessionID, ClientApplication.adminServer.id);
			if (isCrossService)
			{
				url = string.Format("http://{0}/replay?serverid={2}&raceid={1}", ClientApplication.replayServer, sessionID, 0);
			}
			base.url = url;
		}
	}
}
