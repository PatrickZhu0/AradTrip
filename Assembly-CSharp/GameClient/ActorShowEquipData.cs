using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020013EB RID: 5099
	internal class ActorShowEquipData
	{
		// Token: 0x0600C5B1 RID: 50609 RVA: 0x002FA68B File Offset: 0x002F8A8B
		public bool HasGuild()
		{
			return this.guildName != null && this.guildName.Length > 0;
		}

		// Token: 0x0600C5B2 RID: 50610 RVA: 0x002FA6A9 File Offset: 0x002F8AA9
		public bool HasVip()
		{
			return this.vip > 0 && this.vip <= 30;
		}

		// Token: 0x0600C5B3 RID: 50611 RVA: 0x002FA6C7 File Offset: 0x002F8AC7
		public bool HasAdventureTeam()
		{
			return this.adventureTeamName != null && this.adventureTeamName.Length > 0;
		}

		// Token: 0x040070F5 RID: 28917
		public List<ItemData> m_akEquipts;

		// Token: 0x040070F6 RID: 28918
		public List<ItemData> m_akFashions;

		// Token: 0x040070F7 RID: 28919
		public Dictionary<int, EquipSuitObj> m_dictEquipSuitObjs;

		// Token: 0x040070F8 RID: 28920
		public int m_iLevel;

		// Token: 0x040070F9 RID: 28921
		public string m_kName;

		// Token: 0x040070FA RID: 28922
		public int m_iJob;

		// Token: 0x040070FB RID: 28923
		public ulong m_guid;

		// Token: 0x040070FC RID: 28924
		public uint m_zoneId;

		// Token: 0x040070FD RID: 28925
		public uint m_queryPlayerType;

		// Token: 0x040070FE RID: 28926
		public PkStatisticInfo m_pkInfo;

		// Token: 0x040070FF RID: 28927
		public uint pkValue;

		// Token: 0x04007100 RID: 28928
		public uint matchScore;

		// Token: 0x04007101 RID: 28929
		public int vip;

		// Token: 0x04007102 RID: 28930
		public string guildName;

		// Token: 0x04007103 RID: 28931
		public int guildJob;

		// Token: 0x04007104 RID: 28932
		public string prefabPath;

		// Token: 0x04007105 RID: 28933
		public bool bCompare;

		// Token: 0x04007106 RID: 28934
		public ActorShowEquipData.PetData[] pets = new ActorShowEquipData.PetData[3];

		// Token: 0x04007107 RID: 28935
		public PlayerAvatar avatar;

		// Token: 0x04007108 RID: 28936
		public string adventureTeamName;

		// Token: 0x04007109 RID: 28937
		public string adventureTeamGrade;

		// Token: 0x0400710A RID: 28938
		public uint adventureTeamRank;

		// Token: 0x0400710B RID: 28939
		public int emblemLv;

		// Token: 0x0400710C RID: 28940
		public uint totalEquipScore;

		// Token: 0x020013EC RID: 5100
		public struct PetData
		{
			// Token: 0x0400710D RID: 28941
			public int dataID;

			// Token: 0x0400710E RID: 28942
			public int level;

			// Token: 0x0400710F RID: 28943
			public int hunger;

			// Token: 0x04007110 RID: 28944
			public int skillIndex;

			// Token: 0x04007111 RID: 28945
			public int petScore;
		}
	}
}
