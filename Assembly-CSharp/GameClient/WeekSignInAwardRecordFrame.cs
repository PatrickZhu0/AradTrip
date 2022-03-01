using System;

namespace GameClient
{
	// Token: 0x02001A91 RID: 6801
	public class WeekSignInAwardRecordFrame : ClientFrame
	{
		// Token: 0x06010B1D RID: 68381 RVA: 0x004BC1E4 File Offset: 0x004BA5E4
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SignIn/WeekSignInAwardRecordFrame";
		}

		// Token: 0x06010B1E RID: 68382 RVA: 0x004BC1EC File Offset: 0x004BA5EC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mWeekSignInAwardRecordView != null)
			{
				int awardRecordType = (int)this.userData;
				this.mWeekSignInAwardRecordView.InitView(awardRecordType);
			}
		}

		// Token: 0x06010B1F RID: 68383 RVA: 0x004BC228 File Offset: 0x004BA628
		protected override void _bindExUI()
		{
			this.mWeekSignInAwardRecordView = this.mBind.GetCom<WeekSignInAwardRecordView>("WeekSignInAwardRecordView");
		}

		// Token: 0x06010B20 RID: 68384 RVA: 0x004BC240 File Offset: 0x004BA640
		protected override void _unbindExUI()
		{
			this.mWeekSignInAwardRecordView = null;
		}

		// Token: 0x0400AAC1 RID: 43713
		private WeekSignInAwardRecordView mWeekSignInAwardRecordView;
	}
}
