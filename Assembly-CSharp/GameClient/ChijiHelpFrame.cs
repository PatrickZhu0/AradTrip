using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200110D RID: 4365
	public class ChijiHelpFrame : ClientFrame
	{
		// Token: 0x0600A565 RID: 42341 RVA: 0x0022207C File Offset: 0x0022047C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiHelpFrame";
		}

		// Token: 0x0600A566 RID: 42342 RVA: 0x00222083 File Offset: 0x00220483
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600A567 RID: 42343 RVA: 0x00222085 File Offset: 0x00220485
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600A568 RID: 42344 RVA: 0x00222087 File Offset: 0x00220487
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600A569 RID: 42345 RVA: 0x002220BB File Offset: 0x002204BB
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600A56A RID: 42346 RVA: 0x002220E0 File Offset: 0x002204E0
		private void _onCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x04005C4F RID: 23631
		private Button mClose;
	}
}
