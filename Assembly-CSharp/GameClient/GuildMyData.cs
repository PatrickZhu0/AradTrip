using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001268 RID: 4712
	internal class GuildMyData
	{
		// Token: 0x04006617 RID: 26135
		public ulong uGUID;

		// Token: 0x04006618 RID: 26136
		public string strName;

		// Token: 0x04006619 RID: 26137
		public int nLevel;

		// Token: 0x0400661A RID: 26138
		public int nMemberCount;

		// Token: 0x0400661B RID: 26139
		public int nMemberMaxCount;

		// Token: 0x0400661C RID: 26140
		public int nFund;

		// Token: 0x0400661D RID: 26141
		public string strDeclaration;

		// Token: 0x0400661E RID: 26142
		public string strNotice;

		// Token: 0x0400661F RID: 26143
		public uint nDismissTime;

		// Token: 0x04006620 RID: 26144
		public uint nExchangeCoolTime;

		// Token: 0x04006621 RID: 26145
		public int nTargetManorID;

		// Token: 0x04006622 RID: 26146
		public int nTargetCrossManorID;

		// Token: 0x04006623 RID: 26147
		public int nBattleScore;

		// Token: 0x04006624 RID: 26148
		public int nSelfManorID;

		// Token: 0x04006625 RID: 26149
		public int nSelfCrossManorID;

		// Token: 0x04006626 RID: 26150
		public int nSelfHistoryManorID;

		// Token: 0x04006627 RID: 26151
		public int nInspire;

		// Token: 0x04006628 RID: 26152
		public int nWinProbability;

		// Token: 0x04006629 RID: 26153
		public int nLoseProbability;

		// Token: 0x0400662A RID: 26154
		public int nStorageAddPost;

		// Token: 0x0400662B RID: 26155
		public int nStorageDelPost;

		// Token: 0x0400662C RID: 26156
		public uint nJoinLevel;

		// Token: 0x0400662D RID: 26157
		public uint emblemLevel;

		// Token: 0x0400662E RID: 26158
		public uint dungeonType;

		// Token: 0x0400662F RID: 26159
		public byte mergerRequestType;

		// Token: 0x04006630 RID: 26160
		public byte prosperity;

		// Token: 0x04006631 RID: 26161
		public uint lastWeekFunValue;

		// Token: 0x04006632 RID: 26162
		public uint thisWeekFunValue;

		// Token: 0x04006633 RID: 26163
		public GuildLeaderData leaderData = new GuildLeaderData();

		// Token: 0x04006634 RID: 26164
		public List<GuildMemberData> arrMembers = new List<GuildMemberData>();

		// Token: 0x04006635 RID: 26165
		public List<GuildRequesterData> arrRequesters = new List<GuildRequesterData>();

		// Token: 0x04006636 RID: 26166
		public GuildTableMember[] arrTableMembers = new GuildTableMember[7];

		// Token: 0x04006637 RID: 26167
		public Dictionary<GuildBuildingType, GuildBuildingData> dictBuildings = new Dictionary<GuildBuildingType, GuildBuildingData>();
	}
}
