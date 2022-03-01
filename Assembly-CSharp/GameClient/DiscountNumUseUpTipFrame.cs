using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001441 RID: 5185
	internal class DiscountNumUseUpTipFrame : ClientFrame
	{
		// Token: 0x0600C92F RID: 51503 RVA: 0x0030ECEE File Offset: 0x0030D0EE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ArtifactJar/DiscountNumUseUpTip";
		}

		// Token: 0x0600C930 RID: 51504 RVA: 0x0030ECF5 File Offset: 0x0030D0F5
		protected override void _OnOpenFrame()
		{
			this.okCallBack = null;
			if (this.userData != null && this.userData is UnityAction)
			{
				this.okCallBack = (UnityAction)this.userData;
			}
			this.InitUI();
		}

		// Token: 0x0600C931 RID: 51505 RVA: 0x0030ED30 File Offset: 0x0030D130
		protected override void _OnCloseFrame()
		{
			this.okCallBack = null;
		}

		// Token: 0x0600C932 RID: 51506 RVA: 0x0030ED3C File Offset: 0x0030D13C
		protected override void _bindExUI()
		{
			this.m_labContent = this.mBind.GetCom<Text>("tip");
			this.m_togCanNotify = this.mBind.GetCom<Toggle>("CanNotify");
			this.m_togCanNotify.SafeAddOnValueChangedListener(delegate(bool var)
			{
				DataManager<ArtifactDataManager>.GetInstance().isNotNotify = var;
			});
			this.m_btnOk = this.mBind.GetCom<Button>("OK");
			this.m_btnOk.SafeAddOnClickListener(delegate
			{
				if (this.okCallBack != null)
				{
					this.okCallBack.Invoke();
				}
				this.frameMgr.CloseFrame<DiscountNumUseUpTipFrame>(this, false);
			});
		}

		// Token: 0x0600C933 RID: 51507 RVA: 0x0030EDCA File Offset: 0x0030D1CA
		protected override void _unbindExUI()
		{
			this.m_labContent = null;
			this.m_togCanNotify = null;
			this.m_btnOk = null;
		}

		// Token: 0x0600C934 RID: 51508 RVA: 0x0030EDE1 File Offset: 0x0030D1E1
		private void InitUI()
		{
			this.m_labContent.SafeSetText(TR.Value("DiscountNumUseUpTip"));
			this.m_togCanNotify.SafeSetToggleOnState(DataManager<ArtifactDataManager>.GetInstance().isNotNotify);
		}

		// Token: 0x04007419 RID: 29721
		private UnityAction okCallBack;

		// Token: 0x0400741A RID: 29722
		private Text m_labContent;

		// Token: 0x0400741B RID: 29723
		private Toggle m_togCanNotify;

		// Token: 0x0400741C RID: 29724
		private Button m_btnOk;
	}
}
