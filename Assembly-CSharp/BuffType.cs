using System;

// Token: 0x02004150 RID: 16720
public enum BuffType
{
	// Token: 0x040104EA RID: 66794
	ALL_SKILL_BUFF = -8,
	// Token: 0x040104EB RID: 66795
	USE_MECHANISM,
	// Token: 0x040104EC RID: 66796
	USE_SKILL,
	// Token: 0x040104ED RID: 66797
	TRIGGER_BUFFINFO,
	// Token: 0x040104EE RID: 66798
	BUFF_DISPEL,
	// Token: 0x040104EF RID: 66799
	SUMMON,
	// Token: 0x040104F0 RID: 66800
	SKILL_BUFF,
	// Token: 0x040104F1 RID: 66801
	ATTRIBUTE_ADD,
	// Token: 0x040104F2 RID: 66802
	ATTRIBUTE_CHANGE,
	// Token: 0x040104F3 RID: 66803
	BATI,
	// Token: 0x040104F4 RID: 66804
	SPEED_UP,
	// Token: 0x040104F5 RID: 66805
	BLESS,
	// Token: 0x040104F6 RID: 66806
	TRANSPARENT,
	// Token: 0x040104F7 RID: 66807
	HARD,
	// Token: 0x040104F8 RID: 66808
	[UIProperty("感电", "", true)]
	FLASH,
	// Token: 0x040104F9 RID: 66809
	[UIProperty("出血", "", true)]
	BLEEDING,
	// Token: 0x040104FA RID: 66810
	[UIProperty("灼烧", "", true)]
	BURN,
	// Token: 0x040104FB RID: 66811
	[UIProperty("中毒", "", true)]
	POISON,
	// Token: 0x040104FC RID: 66812
	[UIProperty("失明", "", true)]
	BLIND,
	// Token: 0x040104FD RID: 66813
	[UIProperty("眩晕", "", true)]
	STUN,
	// Token: 0x040104FE RID: 66814
	[UIProperty("石化", "", true)]
	STONE,
	// Token: 0x040104FF RID: 66815
	[UIProperty("冰冻", "", true)]
	FROZEN,
	// Token: 0x04010500 RID: 66816
	[UIProperty("睡眠", "", true)]
	SLEEP,
	// Token: 0x04010501 RID: 66817
	[UIProperty("混乱", "", true)]
	CONFUNSE,
	// Token: 0x04010502 RID: 66818
	[UIProperty("束缚", "", true)]
	STRAIN,
	// Token: 0x04010503 RID: 66819
	[UIProperty("减速", "", true)]
	SPEED_DOWN,
	// Token: 0x04010504 RID: 66820
	[UIProperty("诅咒", "", true)]
	CURSE,
	// Token: 0x04010505 RID: 66821
	DAMAGESTATE = 23,
	// Token: 0x04010506 RID: 66822
	BATI_NO_PAUSE
}
