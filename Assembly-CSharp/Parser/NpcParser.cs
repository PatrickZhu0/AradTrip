using System;
using GameClient;
using GameClient.TaskTrace;
using ProtoTable;
using UnityEngine.Events;

namespace Parser
{
	// Token: 0x020045F8 RID: 17912
	public class NpcParser : IParser
	{
		// Token: 0x060192E1 RID: 103137 RVA: 0x007F6568 File Offset: 0x007F4968
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
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			result.color = TR.Value("parse_color_npc");
			result.content = tableItem.NpcName;
			result.iId = (uint)num;
			return result;
		}

		// Token: 0x060192E2 RID: 103138 RVA: 0x007F6608 File Offset: 0x007F4A08
		public static void OnClickLink(ulong guid, int npcId, ESceneActorType eSceneActorType = ESceneActorType.Npc, OnReached onReached = null, UnityAction onFailed = null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcId, string.Empty, string.Empty);
			if (clientSystemTown != null && tableItem != null)
			{
				NpcTrace npcTrace = new NpcTrace();
				npcTrace.iNpcID = npcId;
				npcTrace.iTaskID = 0;
				npcTrace.onReached = onReached;
				npcTrace.bNeedDialog = false;
				npcTrace.onFailed = onFailed;
				BeTownPlayerMain.CommandStopAutoMove();
				BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(npcTrace.OnMoveStateChanged));
				BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(npcTrace.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(npcTrace.OnAutoMoveFail));
				if (clientSystemTown.MainPlayer != null)
				{
					clientSystemTown.MainPlayer.CommandMoveToSceneActor(guid, eSceneActorType);
				}
				else
				{
					Logger.LogErrorFormat("The ClientSystem MainPlayer is not exist and guid is {0}, npcId is {1}", new object[]
					{
						guid,
						npcId
					});
				}
			}
		}

		// Token: 0x060192E3 RID: 103139 RVA: 0x007F66FC File Offset: 0x007F4AFC
		public static void OnClickLinkByNpcId(int npcId)
		{
			NpcParser.OnClickLink(npcId, delegate()
			{
				TaskNpcAccess.OnClickFunctionNpc(npcId, 0UL, string.Empty);
			});
		}

		// Token: 0x060192E4 RID: 103140 RVA: 0x007F6730 File Offset: 0x007F4B30
		public static void OnClickLink(int iID, OnReached onReached = null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iID, string.Empty, string.Empty);
			if (clientSystemTown != null && tableItem != null)
			{
				NpcTrace npcTrace = new NpcTrace();
				npcTrace.iNpcID = iID;
				npcTrace.iTaskID = 0;
				npcTrace.onReached = onReached;
				npcTrace.bNeedDialog = false;
				BeTownPlayerMain.CommandStopAutoMove();
				BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(npcTrace.OnMoveStateChanged));
				BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(npcTrace.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(npcTrace.OnAutoMoveFail));
				if (clientSystemTown.MainPlayer != null)
				{
					clientSystemTown.MainPlayer.CommandMoveToSceneActor(iID, ESceneActorType.Npc);
				}
				else
				{
					Logger.LogErrorFormat("MainPlayer is not exist,where do you want to go ? iNpcID = {0}", new object[]
					{
						iID
					});
				}
			}
		}

		// Token: 0x060192E5 RID: 103141 RVA: 0x007F6814 File Offset: 0x007F4C14
		public static void OnClickLink(int iID, int iTaskID, bool bNeedDialog = true, UnityAction onSuccessed = null, UnityAction onFailed = null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iID, string.Empty, string.Empty);
			if (clientSystemTown != null && tableItem != null)
			{
				NpcTrace npcTrace = new NpcTrace();
				if (npcTrace == null)
				{
					Logger.LogErrorFormat("Parser.NpcParser.OnClickLink: alloc memory failed!!! iNpcID = {0} iTaskID = {1}", new object[]
					{
						iID,
						iTaskID
					});
					return;
				}
				npcTrace.iNpcID = iID;
				npcTrace.iTaskID = iTaskID;
				npcTrace.bNeedDialog = bNeedDialog;
				npcTrace.onSucceed = onSuccessed;
				npcTrace.onFailed = onFailed;
				BeTownPlayerMain.CommandStopAutoMove();
				BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(npcTrace.OnMoveStateChanged));
				BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(npcTrace.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(npcTrace.OnAutoMoveFail));
				if (clientSystemTown.MainPlayer != null)
				{
					clientSystemTown.MainPlayer.CommandMoveToSceneActor(iID, ESceneActorType.Npc);
					return;
				}
				Logger.LogErrorFormat("MainPlayer is not exist,where do you want to go ? iNpcID = {0} iTaskID = {1}", new object[]
				{
					iID,
					iTaskID
				});
			}
			if (onFailed != null)
			{
				onFailed.Invoke();
			}
		}
	}
}
