using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x020016CB RID: 5835
	public enum EFashionWearNewSlotType
	{
		// Token: 0x040089F0 RID: 35312
		Invalid,
		// Token: 0x040089F1 RID: 35313
		[MapIndex(0)]
		[Description("item_slot_fashion_head")]
		Head,
		// Token: 0x040089F2 RID: 35314
		[MapIndex(1)]
		[Description("item_slot_fashion_upper_body")]
		UpperBody,
		// Token: 0x040089F3 RID: 35315
		[MapIndex(2)]
		[Description("item_slot_fashion_chest")]
		Chest,
		// Token: 0x040089F4 RID: 35316
		[MapIndex(3)]
		[Description("item_slot_fashion_waist")]
		Waist,
		// Token: 0x040089F5 RID: 35317
		[MapIndex(4)]
		[Description("item_slot_fashion_lower_body")]
		LowerBody,
		// Token: 0x040089F6 RID: 35318
		[MapIndex(5)]
		[Description("item_slot_fashion_weapon")]
		Weapon,
		// Token: 0x040089F7 RID: 35319
		[MapIndex(6)]
		[Description("item_slot_fashion_halo")]
		Halo,
		// Token: 0x040089F8 RID: 35320
		[MapIndex(7)]
		[Description("item_slot_fashion_auras")]
		Auras,
		// Token: 0x040089F9 RID: 35321
		Max
	}
}
