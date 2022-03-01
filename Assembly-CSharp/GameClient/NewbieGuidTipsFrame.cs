using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001026 RID: 4134
	public class NewbieGuidTipsFrame : ClientFrame
	{
		// Token: 0x06009C89 RID: 40073 RVA: 0x001E9608 File Offset: 0x001E7A08
		public override string GetPrefabPath()
		{
			bool flag = false;
			if (this.userData != null)
			{
				flag = (bool)this.userData;
			}
			return (!flag) ? "UIFlatten/Prefabs/NewbieGuide/NewbieGuidTip" : "UIFlatten/Prefabs/NewbieGuide/NewbieGuidTip2";
		}

		// Token: 0x06009C8A RID: 40074 RVA: 0x001E9643 File Offset: 0x001E7A43
		protected override void _bindExUI()
		{
			this.mText = this.mBind.GetCom<Text>("Text");
		}

		// Token: 0x06009C8B RID: 40075 RVA: 0x001E965B File Offset: 0x001E7A5B
		protected override void _unbindExUI()
		{
			this.mText = null;
		}

		// Token: 0x06009C8C RID: 40076 RVA: 0x001E9664 File Offset: 0x001E7A64
		protected override void _OnOpenFrame()
		{
			this.showCom = this.frame.AddComponent<ComShowText>();
		}

		// Token: 0x06009C8D RID: 40077 RVA: 0x001E9677 File Offset: 0x001E7A77
		protected override void _OnCloseFrame()
		{
			this.showCom = null;
		}

		// Token: 0x06009C8E RID: 40078 RVA: 0x001E9680 File Offset: 0x001E7A80
		public void SetTipsText(string text)
		{
			if (this.mText != null)
			{
				this.mText.text = text;
			}
		}

		// Token: 0x06009C8F RID: 40079 RVA: 0x001E969F File Offset: 0x001E7A9F
		public void SetTipsTextEx(string text, float speed, float delay)
		{
			if (this.mText != null)
			{
				this.showCom.Begin(this.mText, text, speed, delay, this);
			}
		}

		// Token: 0x040055F1 RID: 22001
		private Text mText;

		// Token: 0x040055F2 RID: 22002
		private ComShowText showCom;
	}
}
