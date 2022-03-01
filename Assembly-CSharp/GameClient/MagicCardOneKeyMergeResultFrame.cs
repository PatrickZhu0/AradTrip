using System;

namespace GameClient
{
	// Token: 0x02001744 RID: 5956
	public class MagicCardOneKeyMergeResultFrame : ClientFrame
	{
		// Token: 0x0600E9EA RID: 59882 RVA: 0x003DF3E4 File Offset: 0x003DD7E4
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MagicCard/MagicCardOneKeyMergeResultFrame";
		}

		// Token: 0x0600E9EB RID: 59883 RVA: 0x003DF3EB File Offset: 0x003DD7EB
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mMagicCardOneKeyMergeResultView != null)
			{
				this.mMagicCardOneKeyMergeResultView.InitData();
			}
		}

		// Token: 0x0600E9EC RID: 59884 RVA: 0x003DF40F File Offset: 0x003DD80F
		protected override void _bindExUI()
		{
			this.mMagicCardOneKeyMergeResultView = this.mBind.GetCom<MagicCardOneKeyMergeResultView>("MagicCardOneKeyMergeResultView");
		}

		// Token: 0x0600E9ED RID: 59885 RVA: 0x003DF427 File Offset: 0x003DD827
		protected override void _unbindExUI()
		{
			this.mMagicCardOneKeyMergeResultView = null;
		}

		// Token: 0x04008DDD RID: 36317
		private MagicCardOneKeyMergeResultView mMagicCardOneKeyMergeResultView;
	}
}
