using System;

namespace GameClient
{
	// Token: 0x02001970 RID: 6512
	public class PersonalSettingFrame : ClientFrame
	{
		// Token: 0x0600FD22 RID: 64802 RVA: 0x0045AD5C File Offset: 0x0045915C
		protected sealed override void _bindExUI()
		{
			this.mPersonalSettingView = this.mBind.GetCom<PersonalSettingView>("PersonalSettingView");
		}

		// Token: 0x0600FD23 RID: 64803 RVA: 0x0045AD74 File Offset: 0x00459174
		protected sealed override void _unbindExUI()
		{
			this.mPersonalSettingView = null;
		}

		// Token: 0x0600FD24 RID: 64804 RVA: 0x0045AD7D File Offset: 0x0045917D
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/PersonalSettingFrame/PersonalSettingFrame";
		}

		// Token: 0x0600FD25 RID: 64805 RVA: 0x0045AD84 File Offset: 0x00459184
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				PersonalSettingFrame.mDefalutTabIndex = (int)this.userData;
			}
			this.mPersonalSettingView.InitView();
		}

		// Token: 0x0600FD26 RID: 64806 RVA: 0x0045ADAC File Offset: 0x004591AC
		protected sealed override void _OnCloseFrame()
		{
			PersonalSettingFrame.mDefalutTabIndex = 0;
		}

		// Token: 0x04009F05 RID: 40709
		private PersonalSettingView mPersonalSettingView;

		// Token: 0x04009F06 RID: 40710
		public static int mDefalutTabIndex;
	}
}
