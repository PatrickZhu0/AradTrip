using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001217 RID: 4631
	public static class ChatUtility
	{
		// Token: 0x0600B221 RID: 45601 RVA: 0x00277434 File Offset: 0x00275834
		public static ChatData GetChatDataBySendGuid(ulong sendGuid)
		{
			List<ChatBlock> globalChatBlock = DataManager<ChatManager>.GetInstance().GlobalChatBlock;
			if (globalChatBlock == null || globalChatBlock.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < globalChatBlock.Count; i++)
			{
				ChatBlock chatBlock = globalChatBlock[i];
				if (chatBlock != null && chatBlock.chatData != null)
				{
					if (chatBlock.chatData.objid == sendGuid)
					{
						return chatBlock.chatData;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B222 RID: 45602 RVA: 0x002774AE File Offset: 0x002758AE
		public static bool IsChatDataFromDifferentServer(ChatData chatData)
		{
			return chatData != null && (chatData.eChatType == ChatType.CT_TEAM_COPY_PREPARE || chatData.eChatType == ChatType.CT_TEAM_COPY_TEAM || chatData.eChatType == ChatType.CT_TEAM_COPY_SQUAD);
		}

		// Token: 0x0600B223 RID: 45603 RVA: 0x002774E2 File Offset: 0x002758E2
		public static bool IsForbidPrivateChat()
		{
			return TeamDuplicationUtility.IsInTeamDuplicationScene();
		}
	}
}
