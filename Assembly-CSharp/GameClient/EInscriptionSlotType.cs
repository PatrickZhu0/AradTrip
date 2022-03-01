using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x02001B5B RID: 7003
	public enum EInscriptionSlotType
	{
		// Token: 0x0400B11D RID: 45341
		Invalid,
		// Token: 0x0400B11E RID: 45342
		[Description("Inscription_Hole_Red")]
		RetSlot = 800,
		// Token: 0x0400B11F RID: 45343
		[Description("Inscription_Hole_Yellow")]
		YellowSlot,
		// Token: 0x0400B120 RID: 45344
		[Description("Inscription_Hole_Blue")]
		BlueSlot,
		// Token: 0x0400B121 RID: 45345
		[Description("Inscription_Hole_DarkGold")]
		DarkGoldSlot,
		// Token: 0x0400B122 RID: 45346
		[Description("Inscription_Hole_YaoGolden")]
		YaoGolSlot,
		// Token: 0x0400B123 RID: 45347
		[Description("Inscription_Hole_Orange")]
		OrangeSlot,
		// Token: 0x0400B124 RID: 45348
		[Description("Inscription_Hole_Green")]
		GreenSlot,
		// Token: 0x0400B125 RID: 45349
		[Description("Inscription_Hole_Purple")]
		PurpleSlot
	}
}
