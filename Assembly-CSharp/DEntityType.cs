using System;
using System.ComponentModel;

// Token: 0x02004B5F RID: 19295
[Serializable]
public enum DEntityType
{
	// Token: 0x04013826 RID: 79910
	[Description("NPC")]
	NPC,
	// Token: 0x04013827 RID: 79911
	[Description("怪物")]
	MONSTER,
	// Token: 0x04013828 RID: 79912
	[Description("修饰物")]
	DECORATOR,
	// Token: 0x04013829 RID: 79913
	[Description("可破坏物")]
	DESTRUCTIBLE,
	// Token: 0x0401382A RID: 79914
	[Description("区域")]
	REGION,
	// Token: 0x0401382B RID: 79915
	[Description("传送门")]
	TRANSPORTDOOR,
	// Token: 0x0401382C RID: 79916
	[Description("BOSS怪物")]
	BOSS,
	// Token: 0x0401382D RID: 79917
	[Description("精英怪物")]
	ELITE,
	// Token: 0x0401382E RID: 79918
	[Description("出生点")]
	BIRTHPOSITION,
	// Token: 0x0401382F RID: 79919
	[Description("城镇传送门")]
	TOWNDOOR,
	// Token: 0x04013830 RID: 79920
	[Description("功能预设")]
	FUNCTION_PREFAB,
	// Token: 0x04013831 RID: 79921
	[Description("技能实现的怪物")]
	MONSTERDESTRUCT,
	// Token: 0x04013832 RID: 79922
	[Description("深渊柱子出生点")]
	HELLBIRTHPOSITION,
	// Token: 0x04013833 RID: 79923
	[Description("活动普通怪物刷怪点")]
	ACTIVITY_MONSTER_POS,
	// Token: 0x04013834 RID: 79924
	[Description("活动精英怪物刷怪点")]
	ACTIVITY_ELITE_POS,
	// Token: 0x04013835 RID: 79925
	[Description("活动BOSS怪物刷怪点")]
	ACTIVITY_BOSS_POS,
	// Token: 0x04013836 RID: 79926
	[Description("吃鸡道具投放点")]
	RESOURCE_POS,
	// Token: 0x04013837 RID: 79927
	[Description("吃鸡人物降落点")]
	FIGHTER_BORN_POS,
	// Token: 0x04013838 RID: 79928
	MAX
}
