using System;
using GameClient;

namespace Parser
{
	// Token: 0x020045F9 RID: 17913
	public class Common
	{
		// Token: 0x060192E7 RID: 103143 RVA: 0x007F6960 File Offset: 0x007F4D60
		public static void NameParse(ulong guid, byte job, string name)
		{
			if (guid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			ChatData chatDataBySendGuid = ChatUtility.GetChatDataBySendGuid(guid);
			bool flag = ChatUtility.IsChatDataFromDifferentServer(chatDataBySendGuid);
			if (flag)
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(guid, 1U, chatDataBySendGuid.zoneId);
			}
			else
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(guid, 0U, 0U);
			}
		}

		// Token: 0x060192E8 RID: 103144 RVA: 0x007F69B6 File Offset: 0x007F4DB6
		public static void RetinueParse(ulong guid, int iTableID)
		{
		}
	}
}
