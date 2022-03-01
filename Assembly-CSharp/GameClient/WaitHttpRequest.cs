using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001176 RID: 4470
	internal class WaitHttpRequest : BaseWaitHttpRequest
	{
		// Token: 0x0600AAF3 RID: 43763 RVA: 0x00249D54 File Offset: 0x00248154
		public WaitHttpRequest(string op)
		{
			this._setUrl(op);
			base.SetRequestWaitResult();
			Debug.LogFormat("[WaitHttpRequest] 开始 url {0}, {1}", new object[]
			{
				base.url,
				this.mResult
			});
		}

		// Token: 0x0600AAF4 RID: 43764 RVA: 0x00249D90 File Offset: 0x00248190
		private void _setUrl(string op)
		{
			string text = string.Format("http://{0}/{1}", Global.ROLE_SAVEDATA_SERVER_ADDRESS, op);
			if (text.Contains("?"))
			{
				text += "&";
			}
			else
			{
				text += "?";
			}
			string arg = SDKInterface.instance.NeedUriEncodeOpenid(ClientApplication.playerinfo.openuid);
			text += string.Format("version={0}&openid={1}", Singleton<VersionManager>.instance.Version(), arg);
			if (op.Contains("node"))
			{
				text = string.Format("http://{0}/info/{1}/serverlist", Global.ROLE_SAVEDATA_SERVER_ADDRESS, Global.channelName);
			}
			else if (op.Contains("zone_list"))
			{
				text = string.Format("http://{0}/info/{1}/zone_list", Global.ROLE_SAVEDATA_SERVER_ADDRESS, Global.channelName);
			}
			base.url = text;
		}
	}
}
