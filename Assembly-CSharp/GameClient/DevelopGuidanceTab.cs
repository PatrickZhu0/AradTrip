using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AFA RID: 6906
	internal class DevelopGuidanceTab : CachedSelectedObject<TabData, DevelopGuidanceTab>
	{
		// Token: 0x06010F1B RID: 69403 RVA: 0x004D6D10 File Offset: 0x004D5110
		public override void Initialize()
		{
			this.Label = Utility.FindComponent<Text>(this.goLocal, "Label", true);
			this.CheckLabel = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Label", true);
			this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
		}

		// Token: 0x06010F1C RID: 69404 RVA: 0x004D6D61 File Offset: 0x004D5161
		public override void UnInitialize()
		{
		}

		// Token: 0x06010F1D RID: 69405 RVA: 0x004D6D64 File Offset: 0x004D5164
		public override void OnUpdate()
		{
			if (base.Value != null && base.Value.mainItem != null)
			{
				Text label = this.Label;
				string desc = base.Value.mainItem.Desc;
				this.CheckLabel.text = desc;
				label.text = desc;
			}
		}

		// Token: 0x06010F1E RID: 69406 RVA: 0x004D6DB5 File Offset: 0x004D51B5
		public override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
		}

		// Token: 0x0400AE28 RID: 44584
		private Text Label;

		// Token: 0x0400AE29 RID: 44585
		private Text CheckLabel;

		// Token: 0x0400AE2A RID: 44586
		private GameObject goCheckMark;
	}
}
