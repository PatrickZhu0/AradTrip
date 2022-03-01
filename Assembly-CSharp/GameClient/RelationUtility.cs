using System;

namespace GameClient
{
	// Token: 0x020012D4 RID: 4820
	public static class RelationUtility
	{
		// Token: 0x0600BAFB RID: 47867 RVA: 0x002B45B8 File Offset: 0x002B29B8
		public static bool IsRelationFriend(ulong guid)
		{
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(guid);
			return relationByRoleID != null && relationByRoleID.type == 1;
		}

		// Token: 0x0600BAFC RID: 47868 RVA: 0x002B45E8 File Offset: 0x002B29E8
		public static bool IsRelationSameGuild(ulong guildId)
		{
			return DataManager<GuildDataManager>.GetInstance().myGuild != null && DataManager<GuildDataManager>.GetInstance().myGuild.uGUID == guildId;
		}
	}
}
