using System;

namespace GameClient
{
	// Token: 0x02001526 RID: 5414
	[LoggerModel("Chapter")]
	public class CommonBoardFrame : ClientFrame
	{
		// Token: 0x0600D2B5 RID: 53941 RVA: 0x0033E8C0 File Offset: 0x0033CCC0
		protected override void _OnLoadPrefabFinish()
		{
			this.mCommonBoard = this.frame.GetComponent<ComCommonBoard>();
			if (null != this.mCommonBoard)
			{
				this.mCommonBoard.OnClose(delegate
				{
					this.frameMgr.CloseFrame<CommonBoardFrame>(this, false);
				});
				this.mCommonBoard.OnBack(delegate
				{
					this.frameMgr.CloseFrame<CommonBoardFrame>(this, false);
				});
			}
			else
			{
				Logger.LogError("missinng ComCommonBoard");
			}
		}

		// Token: 0x0600D2B6 RID: 53942 RVA: 0x0033E92C File Offset: 0x0033CD2C
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/Chapter/CommonBoard";
		}

		// Token: 0x04007B46 RID: 31558
		protected ComCommonBoard mCommonBoard;
	}
}
