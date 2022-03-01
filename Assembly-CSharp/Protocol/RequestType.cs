using System;

namespace Protocol
{
	// Token: 0x020006E4 RID: 1764
	public enum RequestType
	{
		// Token: 0x04002426 RID: 9254
		InviteTeam = 1,
		// Token: 0x04002427 RID: 9255
		JoinTeam,
		// Token: 0x04002428 RID: 9256
		RequestFriend,
		// Token: 0x04002429 RID: 9257
		RequestMaster,
		// Token: 0x0400242A RID: 9258
		RequestDisciple,
		// Token: 0x0400242B RID: 9259
		JoinTeamByTeamID = 21,
		// Token: 0x0400242C RID: 9260
		RequestFriendByName = 29,
		// Token: 0x0400242D RID: 9261
		Request_Challenge_PK,
		// Token: 0x0400242E RID: 9262
		InviteJoinGuild,
		// Token: 0x0400242F RID: 9263
		Request_Equal_PK
	}
}
