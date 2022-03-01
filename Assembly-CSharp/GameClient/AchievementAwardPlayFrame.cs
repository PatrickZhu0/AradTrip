using System;

namespace GameClient
{
	// Token: 0x020013C6 RID: 5062
	public class AchievementAwardPlayFrame : ClientFrame
	{
		// Token: 0x0600C47A RID: 50298 RVA: 0x002F314D File Offset: 0x002F154D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActiveGroup/AchievementAwardPlayFrame";
		}

		// Token: 0x0600C47B RID: 50299 RVA: 0x002F3154 File Offset: 0x002F1554
		public static void CommandOpen(object argv)
		{
		}

		// Token: 0x0600C47C RID: 50300 RVA: 0x002F3158 File Offset: 0x002F1558
		protected override void _OnOpenFrame()
		{
			this._Data = (this.userData as AchievementAwardPlayFrameData);
			if (this._Data == null)
			{
				this._Data = new AchievementAwardPlayFrameData();
			}
			if (null != this.comAchievementAwardPlayFrameConfig)
			{
				this.comAchievementAwardPlayFrameConfig.SetAwards(this._Data.iId);
			}
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<AchievementAwardPlayFrame>(this, false);
			});
		}

		// Token: 0x0600C47D RID: 50301 RVA: 0x002F31CA File Offset: 0x002F15CA
		protected override void _OnCloseFrame()
		{
			if (null != this.comAchievementAwardPlayFrameConfig)
			{
				this.comAchievementAwardPlayFrameConfig.DestroyComItems();
			}
			this._Data = null;
		}

		// Token: 0x04006FE8 RID: 28648
		[UIControl("", typeof(ComAchievementAwardPlayFrameConfig), 0)]
		private ComAchievementAwardPlayFrameConfig comAchievementAwardPlayFrameConfig;

		// Token: 0x04006FE9 RID: 28649
		private AchievementAwardPlayFrameData _Data;
	}
}
