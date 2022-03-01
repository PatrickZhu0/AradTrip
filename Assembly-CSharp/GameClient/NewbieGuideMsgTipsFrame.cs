using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001029 RID: 4137
	public class NewbieGuideMsgTipsFrame : ClientFrame
	{
		// Token: 0x06009C9B RID: 40091 RVA: 0x001E98B6 File Offset: 0x001E7CB6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideMsgTips";
		}

		// Token: 0x06009C9C RID: 40092 RVA: 0x001E98BD File Offset: 0x001E7CBD
		public void SetMessage(string msg)
		{
			this.mFileName.text = msg;
		}

		// Token: 0x040055F5 RID: 22005
		[UIControl("Content/Text", typeof(Text), 0)]
		private Text mFileName;
	}
}
