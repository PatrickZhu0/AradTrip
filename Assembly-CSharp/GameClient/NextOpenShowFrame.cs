using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015E2 RID: 5602
	internal class NextOpenShowFrame : ClientFrame
	{
		// Token: 0x0600DB57 RID: 56151 RVA: 0x00374671 File Offset: 0x00372A71
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionUnlock/NextOpenShow";
		}

		// Token: 0x0600DB58 RID: 56152 RVA: 0x00374678 File Offset: 0x00372A78
		protected sealed override void _OnOpenFrame()
		{
			this.contentui = (this.userData as ContentUI);
			this.InitInterface();
		}

		// Token: 0x0600DB59 RID: 56153 RVA: 0x00374691 File Offset: 0x00372A91
		protected sealed override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600DB5A RID: 56154 RVA: 0x00374699 File Offset: 0x00372A99
		private void ClearData()
		{
			this.contentui.Clear();
			this.fintival = 0f;
			if (this.ResPlayEnd != null)
			{
				this.ResPlayEnd = null;
			}
		}

		// Token: 0x0600DB5B RID: 56155 RVA: 0x003746C3 File Offset: 0x00372AC3
		[UIEventHandle("Button")]
		private void OnClose()
		{
			if (this.contentui.bNeedWait)
			{
				if (this.ResPlayEnd != null)
				{
					this.ResPlayEnd();
				}
			}
			else
			{
				base.Close(true);
			}
		}

		// Token: 0x0600DB5C RID: 56156 RVA: 0x003746F8 File Offset: 0x00372AF8
		private void InitInterface()
		{
			this.title.text = this.contentui.title;
			this.icon.sprite = this.contentui.icon;
			this.icon.material = this.contentui.material;
			this.name.text = this.contentui.name;
			this.Explanation.text = this.contentui.explannation;
			this.fintival = 0f;
		}

		// Token: 0x0600DB5D RID: 56157 RVA: 0x0037477E File Offset: 0x00372B7E
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DB5E RID: 56158 RVA: 0x00374784 File Offset: 0x00372B84
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.contentui.bNeedWait)
			{
				this.fintival += timeElapsed;
				if (this.fintival >= this.fLastTime && this.ResPlayEnd != null)
				{
					this.ResPlayEnd();
				}
			}
		}

		// Token: 0x0400813F RID: 33087
		public NextOpenShowFrame.PlayEnd ResPlayEnd;

		// Token: 0x04008140 RID: 33088
		private ContentUI contentui = new ContentUI();

		// Token: 0x04008141 RID: 33089
		private float fLastTime = 4f;

		// Token: 0x04008142 RID: 33090
		private float fintival;

		// Token: 0x04008143 RID: 33091
		[UIControl("Bg/Title", null, 0)]
		protected Text title;

		// Token: 0x04008144 RID: 33092
		[UIControl("Bg/Icon", null, 0)]
		protected Image icon;

		// Token: 0x04008145 RID: 33093
		[UIControl("Bg/Icon/Text", null, 0)]
		protected Text name;

		// Token: 0x04008146 RID: 33094
		[UIControl("Bg/Explanation", null, 0)]
		protected Text Explanation;

		// Token: 0x020015E3 RID: 5603
		// (Invoke) Token: 0x0600DB60 RID: 56160
		public delegate void PlayEnd();
	}
}
