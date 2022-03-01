using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020011F3 RID: 4595
	public class BaseWebViewParams
	{
		// Token: 0x0600B13B RID: 45371 RVA: 0x00272835 File Offset: 0x00270C35
		public BaseWebViewParams()
		{
			this.Clear();
		}

		// Token: 0x0600B13C RID: 45372 RVA: 0x00272844 File Offset: 0x00270C44
		public void Clear()
		{
			this.type = BaseWebViewType.None;
			this.fullUrl = string.Empty;
			this.needFrameUpdate = false;
			this.needGobackBtn = false;
			this.needRefreshBtn = false;
			if (this.uniWebViewMsgs != null)
			{
				for (int i = 0; i < this.uniWebViewMsgs.Count; i++)
				{
					BaseWebViewMsg baseWebViewMsg = this.uniWebViewMsgs[i];
					baseWebViewMsg.scheme = string.Empty;
					baseWebViewMsg.path = string.Empty;
					baseWebViewMsg.onReceiveWebViewMsg = null;
				}
				this.uniWebViewMsgs.Clear();
				this.uniWebViewMsgs = null;
			}
		}

		// Token: 0x040062FB RID: 25339
		public BaseWebViewType type;

		// Token: 0x040062FC RID: 25340
		public string fullUrl;

		// Token: 0x040062FD RID: 25341
		public bool needFrameUpdate;

		// Token: 0x040062FE RID: 25342
		public bool needGobackBtn;

		// Token: 0x040062FF RID: 25343
		public bool needRefreshBtn;

		// Token: 0x04006300 RID: 25344
		public List<BaseWebViewMsg> uniWebViewMsgs;
	}
}
