using System;
using GameClient;
using ProtoTable;
using UnityEngine.Events;

namespace Parser
{
	// Token: 0x020045F5 RID: 17909
	public class DungeonParser : IParser
	{
		// Token: 0x060192D6 RID: 103126 RVA: 0x007F6220 File Offset: 0x007F4620
		public ParserReturn OnParse(string value)
		{
			ParserReturn result;
			result.color = "#ffffff";
			result.iId = 0U;
			result.content = string.Empty;
			string text = value.TrimStart(new char[]
			{
				'['
			});
			text = text.TrimEnd(new char[]
			{
				']'
			});
			int num = int.Parse(text);
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			result.color = "#13ff82";
			result.content = tableItem.Name;
			result.iId = (uint)num;
			return result;
		}

		// Token: 0x060192D7 RID: 103127 RVA: 0x007F62BC File Offset: 0x007F46BC
		public static void OnClickLink(int iDungenID, int iTaskID)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(iDungenID, string.Empty, string.Empty);
			if (clientSystemTown != null && tableItem != null)
			{
				DataManager<MissionManager>.GetInstance().OnExecuteDungenTrace(iTaskID, null, null);
			}
		}

		// Token: 0x060192D8 RID: 103128 RVA: 0x007F6308 File Offset: 0x007F4708
		public static bool OnClickLink(int iDungenID, OnLinkOk onLinkOk = null)
		{
			ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
			if (targetSystem != null)
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(iDungenID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					BeTownPlayerMain.CommandStopAutoMove();
					DungeonParser.DungenTrace dungenTrace = new DungeonParser.DungenTrace();
					dungenTrace.onLinkOk = onLinkOk;
					dungenTrace.iDungenID = iDungenID;
					BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(dungenTrace.OnMoveStateChanged));
					BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(dungenTrace.OnMoveSuccess));
					BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(dungenTrace.OnAutoMoveFail));
					targetSystem.MainPlayer.CommandMoveToDungeon(iDungenID);
					return true;
				}
			}
			return false;
		}

		// Token: 0x020045F6 RID: 17910
		private class DungenTrace
		{
			// Token: 0x060192DA RID: 103130 RVA: 0x007F63AF File Offset: 0x007F47AF
			public void OnMoveStateChanged(BeTownPlayerMain.EMoveState ePre, BeTownPlayerMain.EMoveState eCur)
			{
			}

			// Token: 0x060192DB RID: 103131 RVA: 0x007F63B4 File Offset: 0x007F47B4
			public void OnMoveSuccess()
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
				this.OnTriggerDungen();
			}

			// Token: 0x060192DC RID: 103132 RVA: 0x007F640C File Offset: 0x007F480C
			public void OnAutoMoveFail()
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
				BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
				this.onLinkOk = null;
			}

			// Token: 0x060192DD RID: 103133 RVA: 0x007F6464 File Offset: 0x007F4864
			private void OnTriggerDungen()
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.iDungenID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ChapterSelectFrame.SetDungeonID(this.iDungenID);
				}
				if (this.onLinkOk != null)
				{
					this.onLinkOk();
					this.onLinkOk = null;
				}
			}

			// Token: 0x0401209A RID: 73882
			public int iDungenID;

			// Token: 0x0401209B RID: 73883
			public OnLinkOk onLinkOk;
		}
	}
}
