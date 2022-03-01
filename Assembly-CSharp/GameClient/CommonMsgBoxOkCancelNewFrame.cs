using System;

namespace GameClient
{
	// Token: 0x02000E20 RID: 3616
	public class CommonMsgBoxOkCancelNewFrame : ClientFrame
	{
		// Token: 0x060090CB RID: 37067 RVA: 0x001ACA7C File Offset: 0x001AAE7C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/CommonMsgBoxOKCancelNewFrame";
		}

		// Token: 0x060090CC RID: 37068 RVA: 0x001ACA84 File Offset: 0x001AAE84
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			CommonMsgBoxOkCancelNewParamData paramData = this.userData as CommonMsgBoxOkCancelNewParamData;
			if (this.mCommonMsgBoxOkCancelNewView != null)
			{
				this.mCommonMsgBoxOkCancelNewView.InitData(paramData);
			}
		}

		// Token: 0x060090CD RID: 37069 RVA: 0x001ACAC0 File Offset: 0x001AAEC0
		protected override void _bindExUI()
		{
			this.mCommonMsgBoxOkCancelNewView = this.mBind.GetCom<CommonMsgBoxOkCancelNewView>("CommonMsgBoxOkCancelNewView");
		}

		// Token: 0x060090CE RID: 37070 RVA: 0x001ACAD8 File Offset: 0x001AAED8
		protected override void _unbindExUI()
		{
			this.mCommonMsgBoxOkCancelNewView = null;
		}

		// Token: 0x0400481E RID: 18462
		private CommonMsgBoxOkCancelNewView mCommonMsgBoxOkCancelNewView;
	}
}
