using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x02001068 RID: 4200
	public enum ActorOccupation
	{
		// Token: 0x04005664 RID: 22116
		[Description("鬼武士")]
		SwordMan = 10,
		// Token: 0x04005665 RID: 22117
		[Description("白手")]
		SwordSoulMan,
		// Token: 0x04005666 RID: 22118
		[Description("阵鬼")]
		Zhengui = 13,
		// Token: 0x04005667 RID: 22119
		[Description("修罗")]
		AXiuLuo,
		// Token: 0x04005668 RID: 22120
		[Description("女法师")]
		MagicMan = 30,
		// Token: 0x04005669 RID: 22121
		[Description("枪手")]
		GunMan = 20,
		// Token: 0x0400566A RID: 22122
		[Description("漫影枪手")]
		SkyGunMan,
		// Token: 0x0400566B RID: 22123
		[Description("武器专家")]
		Wuqizhuanjia = 24,
		// Token: 0x0400566C RID: 22124
		[Description("狂战")]
		KuangZhan = 12,
		// Token: 0x0400566D RID: 22125
		[Description("大枪")]
		QiangPaoShi = 22,
		// Token: 0x0400566E RID: 22126
		[Description("战斗法师")]
		Zhandoufashi = 32,
		// Token: 0x0400566F RID: 22127
		[Description("唤灵师")]
		Zhaohuanshi,
		// Token: 0x04005670 RID: 22128
		[Description("秘术师")]
		Mishushi = 31,
		// Token: 0x04005671 RID: 22129
		[Description("女格斗")]
		Gedoujia = 40,
		// Token: 0x04005672 RID: 22130
		[Description("念气师")]
		Qigongshi,
		// Token: 0x04005673 RID: 22131
		[Description("武斗家")]
		Sanda,
		// Token: 0x04005674 RID: 22132
		[Description("女枪手")]
		Gungirl = 50,
		// Token: 0x04005675 RID: 22133
		[Description("漫舞枪手")]
		SkyGungirl,
		// Token: 0x04005676 RID: 22134
		[Description("女大枪")]
		QiangPaoShiGungirl,
		// Token: 0x04005677 RID: 22135
		[Description("圣职者")]
		Paladin = 60,
		// Token: 0x04005678 RID: 22136
		[Description("驱魔师")]
		Qumoshi,
		// Token: 0x04005679 RID: 22137
		[Description("圣骑士")]
		Shengqishi
	}
}
