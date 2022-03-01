using System;

namespace GameClient
{
	// Token: 0x02001747 RID: 5959
	public class MagicCardOneKeyMergeTipFrame : ClientFrame
	{
		// Token: 0x0600E9FF RID: 59903 RVA: 0x003DF89C File Offset: 0x003DDC9C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MagicCard/MagicCardOneKeyMergeTipFrame";
		}

		// Token: 0x0600EA00 RID: 59904 RVA: 0x003DF8A4 File Offset: 0x003DDCA4
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			MagicCardMergeData magicCardMergeData = this.userData as MagicCardMergeData;
			if (this.mMagicCardOneKeyMergeTipView != null)
			{
				this.mMagicCardOneKeyMergeTipView.InitData(magicCardMergeData);
			}
		}

		// Token: 0x0600EA01 RID: 59905 RVA: 0x003DF8E0 File Offset: 0x003DDCE0
		protected override void _bindExUI()
		{
			this.mMagicCardOneKeyMergeTipView = this.mBind.GetCom<MagicCardOneKeyMergeTipView>("MagicCardOneKeyMergeTipView");
		}

		// Token: 0x0600EA02 RID: 59906 RVA: 0x003DF8F8 File Offset: 0x003DDCF8
		protected override void _unbindExUI()
		{
			this.mMagicCardOneKeyMergeTipView = null;
		}

		// Token: 0x04008DE6 RID: 36326
		private MagicCardOneKeyMergeTipView mMagicCardOneKeyMergeTipView;
	}
}
