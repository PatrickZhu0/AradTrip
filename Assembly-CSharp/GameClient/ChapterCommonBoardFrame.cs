using System;

namespace GameClient
{
	// Token: 0x02001527 RID: 5415
	public class ChapterCommonBoardFrame : CommonBoardFrame
	{
		// Token: 0x0600D2BA RID: 53946 RVA: 0x0033E959 File Offset: 0x0033CD59
		protected override void _OnLoadPrefabFinish()
		{
			base._OnLoadPrefabFinish();
			this._loadData();
			this._loadBg();
			this._loadLeftPanel();
			this._loadRightPanel();
		}

		// Token: 0x0600D2BB RID: 53947 RVA: 0x0033E979 File Offset: 0x0033CD79
		private void _onTownSceneChange(UIEvent ui)
		{
			if (ui.EventParams.CurrentSceneID != ChapterSelectFrame.sSceneID)
			{
				this.frameMgr.CloseFrame<ChapterCommonBoardFrame>(this, false);
			}
		}

		// Token: 0x0600D2BC RID: 53948 RVA: 0x0033E99D File Offset: 0x0033CD9D
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600D2BD RID: 53949 RVA: 0x0033E99F File Offset: 0x0033CD9F
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D2BE RID: 53950 RVA: 0x0033E9A1 File Offset: 0x0033CDA1
		protected virtual void _loadData()
		{
		}

		// Token: 0x0600D2BF RID: 53951 RVA: 0x0033E9A3 File Offset: 0x0033CDA3
		protected virtual void _loadBg()
		{
		}

		// Token: 0x0600D2C0 RID: 53952 RVA: 0x0033E9A5 File Offset: 0x0033CDA5
		protected virtual void _loadLeftPanel()
		{
		}

		// Token: 0x0600D2C1 RID: 53953 RVA: 0x0033E9A7 File Offset: 0x0033CDA7
		protected virtual void _loadRightPanel()
		{
		}

		// Token: 0x04007B47 RID: 31559
		private const string kCommonTipsPath = "UI/Prefabs/Chapter/CommonCostTips";
	}
}
