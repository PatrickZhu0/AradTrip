using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015AD RID: 5549
	public class DeadLineReminderFrame : ClientFrame
	{
		// Token: 0x0600D90B RID: 55563 RVA: 0x003660CC File Offset: 0x003644CC
		protected override void _bindExUI()
		{
			this.mView = this.mBind.GetCom<DeadLineReminderView>("View");
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
		}

		// Token: 0x0600D90C RID: 55564 RVA: 0x00366132 File Offset: 0x00364532
		protected override void _unbindExUI()
		{
			this.mView = null;
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtClose = null;
		}

		// Token: 0x0600D90D RID: 55565 RVA: 0x0036616F File Offset: 0x0036456F
		private void _onBtCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600D90E RID: 55566 RVA: 0x00366178 File Offset: 0x00364578
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/DeadLineReminderFrame/DeadLineReminderFrame";
		}

		// Token: 0x0600D90F RID: 55567 RVA: 0x0036617F File Offset: 0x0036457F
		protected sealed override void _OnOpenFrame()
		{
			if (this.mView != null)
			{
				this.mView.InitView();
			}
		}

		// Token: 0x0600D910 RID: 55568 RVA: 0x0036619D File Offset: 0x0036459D
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x04007F8E RID: 32654
		private DeadLineReminderView mView;

		// Token: 0x04007F8F RID: 32655
		private Button mBtClose;
	}
}
