using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B3 RID: 5043
	public class UltimateChallengeCustomsClearanceRewardFrame : ClientFrame
	{
		// Token: 0x0600C3B8 RID: 50104 RVA: 0x002EE62C File Offset: 0x002ECA2C
		protected override void _bindExUI()
		{
			this.mUltimateChallengeCustomsClearanceRewardFrame = this.mBind.GetCom<UltimateChallengeCustomsClearanceRewardView>("UltimateChallengeCustomsClearanceRewardFrame");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600C3B9 RID: 50105 RVA: 0x002EE681 File Offset: 0x002ECA81
		protected override void _unbindExUI()
		{
			this.mUltimateChallengeCustomsClearanceRewardFrame = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600C3BA RID: 50106 RVA: 0x002EE6AD File Offset: 0x002ECAAD
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<UltimateChallengeCustomsClearanceRewardFrame>(this, false);
		}

		// Token: 0x0600C3BB RID: 50107 RVA: 0x002EE6BC File Offset: 0x002ECABC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/UltimateChallengeCustomsClearanceRewardFrame";
		}

		// Token: 0x0600C3BC RID: 50108 RVA: 0x002EE6C3 File Offset: 0x002ECAC3
		protected override void _OnOpenFrame()
		{
			if (this.mUltimateChallengeCustomsClearanceRewardFrame != null)
			{
				this.mUltimateChallengeCustomsClearanceRewardFrame.InitView();
			}
		}

		// Token: 0x0600C3BD RID: 50109 RVA: 0x002EE6E1 File Offset: 0x002ECAE1
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x04006F41 RID: 28481
		private UltimateChallengeCustomsClearanceRewardView mUltimateChallengeCustomsClearanceRewardFrame;

		// Token: 0x04006F42 RID: 28482
		private Button mClose;
	}
}
