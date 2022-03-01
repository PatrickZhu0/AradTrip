using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020015D8 RID: 5592
	public class ExpUpgradeFrame : ClientFrame
	{
		// Token: 0x0600DB13 RID: 56083 RVA: 0x003734FB File Offset: 0x003718FB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ExpUpgrade/ExpUpgrade";
		}

		// Token: 0x0600DB14 RID: 56084 RVA: 0x00373504 File Offset: 0x00371904
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.BindEvents();
			if (this.mExpUpgrade != null)
			{
				ExpUpgradeData expUpgradeData = this.userData as ExpUpgradeData;
				this.mExpUpgrade.InitExpUpgradeData(expUpgradeData);
			}
		}

		// Token: 0x0600DB15 RID: 56085 RVA: 0x00373546 File Offset: 0x00371946
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.UnBindEvents();
		}

		// Token: 0x0600DB16 RID: 56086 RVA: 0x00373554 File Offset: 0x00371954
		private void BindEvents()
		{
		}

		// Token: 0x0600DB17 RID: 56087 RVA: 0x00373556 File Offset: 0x00371956
		private void UnBindEvents()
		{
		}

		// Token: 0x0600DB18 RID: 56088 RVA: 0x00373558 File Offset: 0x00371958
		protected override void _bindExUI()
		{
			this.mExpUpgrade = this.mBind.GetCom<ExpUpgradeView>("ExpUpgrade");
			this.mExpUpgrade.OnButtonCloseCallBack = new UnityAction(this.CloseFrame);
			this.mExpUpgrade.OnTimeIntervalCloseCallBack = new UnityAction(this.CloseFrame);
		}

		// Token: 0x0600DB19 RID: 56089 RVA: 0x003735A9 File Offset: 0x003719A9
		protected override void _unbindExUI()
		{
			this.mExpUpgrade.OnButtonCloseCallBack = null;
			this.mExpUpgrade.OnTimeIntervalCloseCallBack = null;
			this.mExpUpgrade = null;
		}

		// Token: 0x0600DB1A RID: 56090 RVA: 0x003735CA File Offset: 0x003719CA
		private void CloseFrame()
		{
			base.Close(false);
		}

		// Token: 0x04008106 RID: 33030
		private ExpUpgradeView mExpUpgrade;
	}
}
