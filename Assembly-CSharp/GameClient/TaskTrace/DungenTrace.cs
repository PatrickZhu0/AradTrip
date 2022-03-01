using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient.TaskTrace
{
	// Token: 0x02001BFF RID: 7167
	internal class DungenTrace
	{
		// Token: 0x06011901 RID: 71937 RVA: 0x0051CDE4 File Offset: 0x0051B1E4
		public void OnMoveStateChanged(BeTownPlayerMain.EMoveState ePre, BeTownPlayerMain.EMoveState eCur)
		{
		}

		// Token: 0x06011902 RID: 71938 RVA: 0x0051CDE8 File Offset: 0x0051B1E8
		public void OnMoveSuccess()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			}
			this.OnTriggerDungen();
			if (this.onSucceed != null)
			{
				this.onSucceed.Invoke();
				this.onSucceed = null;
			}
			this.onFailed = null;
		}

		// Token: 0x06011903 RID: 71939 RVA: 0x0051CE78 File Offset: 0x0051B278
		public void OnAutoMoveFail()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			}
			if (this.onFailed != null)
			{
				this.onFailed.Invoke();
				this.onFailed = null;
			}
			this.onSucceed = null;
		}

		// Token: 0x06011904 RID: 71940 RVA: 0x0051CF0C File Offset: 0x0051B30C
		private void OnTriggerDungen()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.iDungenID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ChapterSelectFrame.SetDungeonID(this.iDungenID);
			}
		}

		// Token: 0x0400B6B1 RID: 46769
		public int iDungenID;

		// Token: 0x0400B6B2 RID: 46770
		public int iTaskID;

		// Token: 0x0400B6B3 RID: 46771
		public UnityAction onSucceed;

		// Token: 0x0400B6B4 RID: 46772
		public UnityAction onFailed;
	}
}
