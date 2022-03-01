using System;

namespace GameClient
{
	// Token: 0x0200125E RID: 4702
	internal enum EGuildPermission
	{
		// Token: 0x040065C4 RID: 26052
		Invalid,
		// Token: 0x040065C5 RID: 26053
		SetDutyNormal = 2,
		// Token: 0x040065C6 RID: 26054
		SetDutyElder = 8,
		// Token: 0x040065C7 RID: 26055
		SetDutyAssistant = 16,
		// Token: 0x040065C8 RID: 26056
		SetDutyLeader = 32,
		// Token: 0x040065C9 RID: 26057
		KickMember = 64,
		// Token: 0x040065CA RID: 26058
		ProcessRequester = 4096,
		// Token: 0x040065CB RID: 26059
		ChangeDeclaration = 8192,
		// Token: 0x040065CC RID: 26060
		ChangeNotice = 16384,
		// Token: 0x040065CD RID: 26061
		ChangeName = 32768,
		// Token: 0x040065CE RID: 26062
		SendMail = 65536,
		// Token: 0x040065CF RID: 26063
		Dismiss = 131072,
		// Token: 0x040065D0 RID: 26064
		UpgradeBuilding = 262144,
		// Token: 0x040065D1 RID: 26065
		StartGuildBattle = 524288,
		// Token: 0x040065D2 RID: 26066
		StartGuildAttackCity = 1048576,
		// Token: 0x040065D3 RID: 26067
		StartGuildCrossBattle = 2097152,
		// Token: 0x040065D4 RID: 26068
		ChangeJoinLv = 4194304,
		// Token: 0x040065D5 RID: 26069
		SetGuildDungeonBossDiff = 8388608,
		// Token: 0x040065D6 RID: 26070
		GuildMeger = 16777216,
		// Token: 0x040065D7 RID: 26071
		NormalMask = 0,
		// Token: 0x040065D8 RID: 26072
		EliteMask = 0,
		// Token: 0x040065D9 RID: 26073
		ElderMask = 4264000,
		// Token: 0x040065DA RID: 26074
		AssistantMask = 16347210,
		// Token: 0x040065DB RID: 26075
		LeaderMask = 33550458
	}
}
