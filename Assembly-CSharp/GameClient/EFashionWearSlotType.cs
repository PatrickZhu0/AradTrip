using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x020016CC RID: 5836
	public enum EFashionWearSlotType
	{
		// Token: 0x040089FB RID: 35323
		Invalid,
		// Token: 0x040089FC RID: 35324
		[MapIndex(2)]
		[Description("item_slot_fashion_halo")]
		Halo,
		// Token: 0x040089FD RID: 35325
		[MapIndex(3)]
		[Description("item_slot_fashion_head")]
		Head,
		// Token: 0x040089FE RID: 35326
		[MapIndex(1)]
		[Description("item_slot_fashion_waist")]
		Waist,
		// Token: 0x040089FF RID: 35327
		[MapIndex(4)]
		[Description("item_slot_fashion_upper_body")]
		UpperBody,
		// Token: 0x04008A00 RID: 35328
		[MapIndex(5)]
		[Description("item_slot_fashion_lower_body")]
		LowerBody,
		// Token: 0x04008A01 RID: 35329
		[MapIndex(0)]
		[Description("item_slot_fashion_chest")]
		Chest,
		// Token: 0x04008A02 RID: 35330
		[MapIndex(6)]
		[Description("item_slot_fashion_weapon")]
		Weapon,
		// Token: 0x04008A03 RID: 35331
		[MapIndex(7)]
		[Description("item_slot_fashion_auras")]
		Auras,
		// Token: 0x04008A04 RID: 35332
		Max
	}
}
