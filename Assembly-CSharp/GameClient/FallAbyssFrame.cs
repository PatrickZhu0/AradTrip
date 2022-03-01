using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015DA RID: 5594
	public class FallAbyssFrame : ClientFrame
	{
		// Token: 0x0600DB25 RID: 56101 RVA: 0x003738D4 File Offset: 0x00371CD4
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mFallAbyssFrameView = this.mBind.GetCom<FallAbyssFrameView>("FallAbyssFrameView");
		}

		// Token: 0x0600DB26 RID: 56102 RVA: 0x00373929 File Offset: 0x00371D29
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mFallAbyssFrameView = null;
		}

		// Token: 0x0600DB27 RID: 56103 RVA: 0x00373955 File Offset: 0x00371D55
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<FallAbyssFrame>(this, false);
		}

		// Token: 0x0600DB28 RID: 56104 RVA: 0x00373964 File Offset: 0x00371D64
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FallAbyssFrame/FallAbyssFrame";
		}

		// Token: 0x0600DB29 RID: 56105 RVA: 0x0037396B File Offset: 0x00371D6B
		protected override void _OnOpenFrame()
		{
			if (this.mFallAbyssFrameView != null)
			{
				this.mFallAbyssFrameView.InitView();
			}
		}

		// Token: 0x0600DB2A RID: 56106 RVA: 0x00373989 File Offset: 0x00371D89
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x04008115 RID: 33045
		private Button mClose;

		// Token: 0x04008116 RID: 33046
		private FallAbyssFrameView mFallAbyssFrameView;
	}
}
