using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x02004556 RID: 17750
	public enum ChatType
	{
		// Token: 0x04011D21 RID: 72993
		[Description("全部")]
		[EnumCommon("<color=#0391FF>[全部]</color>")]
		CT_ALL,
		// Token: 0x04011D22 RID: 72994
		[Description("系统")]
		[EnumCommon("<color=#FF00FF>[系统]</color>")]
		CT_SYSTEM,
		// Token: 0x04011D23 RID: 72995
		[Description("世界")]
		[EnumCommon("<color=#00FF00>[世界]</color>")]
		CT_WORLD,
		// Token: 0x04011D24 RID: 72996
		[Description("附近")]
		[EnumCommon("<color=#FFFF00>[附近]</color>")]
		CT_NORMAL,
		// Token: 0x04011D25 RID: 72997
		[Description("公会")]
		[EnumCommon("<color=#0391FF>[公会]</color>")]
		CT_GUILD,
		// Token: 0x04011D26 RID: 72998
		[Description("队伍")]
		[EnumCommon("<color=#0391FF>[队伍]</color>")]
		CT_TEAM,
		// Token: 0x04011D27 RID: 72999
		[Description("密聊")]
		[EnumCommon("<color=#0391FF>[密聊]</color>")]
		CT_PRIVATE_LIST,
		// Token: 0x04011D28 RID: 73000
		CT_PRIVATE,
		// Token: 0x04011D29 RID: 73001
		[Description("组队")]
		[EnumCommon("<color=#0391FF>[组队]</color>")]
		CT_ACOMMPANY,
		// Token: 0x04011D2A RID: 73002
		CT_PK3V3_ROOM,
		// Token: 0x04011D2B RID: 73003
		[Description("跨服")]
		[EnumCommon("<color=#FFFF00>[跨服]</color>")]
		CT_TEAM_COPY_PREPARE,
		// Token: 0x04011D2C RID: 73004
		[Description("团队")]
		[EnumCommon("<color=#0391FF>[团队]</color>")]
		CT_TEAM_COPY_TEAM,
		// Token: 0x04011D2D RID: 73005
		[Description("小队")]
		[EnumCommon("<color=#0391FF>[小队]</color>")]
		CT_TEAM_COPY_SQUAD,
		// Token: 0x04011D2E RID: 73006
		CT_MAX_WORDS
	}
}
