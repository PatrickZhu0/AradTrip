using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001576 RID: 5494
	internal class CheckPointHelpFrame : ClientFrame
	{
		// Token: 0x0600D6A1 RID: 54945 RVA: 0x00359FA3 File Offset: 0x003583A3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/CheckPointHelpFrame.prefab";
		}

		// Token: 0x0600D6A2 RID: 54946 RVA: 0x00359FAA File Offset: 0x003583AA
		protected override void _OnOpenFrame()
		{
			this._Initialize();
		}

		// Token: 0x0600D6A3 RID: 54947 RVA: 0x00359FB2 File Offset: 0x003583B2
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x0600D6A4 RID: 54948 RVA: 0x00359FBC File Offset: 0x003583BC
		protected void _Initialize()
		{
			string text = string.Empty;
			if (this.userData != null)
			{
				text = (string)this.userData;
			}
			ComHelp component = this.frame.GetComponent<ComHelp>();
			if (component != null && component.textObj != null)
			{
				Text component2 = component.textObj.GetComponent<Text>();
				component2.text = text.Replace("\\n", "\n");
			}
		}

		// Token: 0x0600D6A5 RID: 54949 RVA: 0x0035A031 File Offset: 0x00358431
		protected void _Clear()
		{
		}

		// Token: 0x0600D6A6 RID: 54950 RVA: 0x0035A033 File Offset: 0x00358433
		[UIEventHandle("Back/Button")]
		private void _OnCloeFrame()
		{
			this.frameMgr.CloseFrame<CheckPointHelpFrame>(this, false);
		}
	}
}
