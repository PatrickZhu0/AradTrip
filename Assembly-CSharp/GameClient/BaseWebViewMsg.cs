using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020011F4 RID: 4596
	public struct BaseWebViewMsg
	{
		// Token: 0x04006301 RID: 25345
		public string scheme;

		// Token: 0x04006302 RID: 25346
		public string path;

		// Token: 0x04006303 RID: 25347
		public Action<Dictionary<string, string>, UniWebViewUtility> onReceiveWebViewMsg;
	}
}
