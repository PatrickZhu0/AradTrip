using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x020016CA RID: 5834
	public enum EEquipWearSlotType
	{
		// Token: 0x040089DB RID: 35291
		EquipInvalid,
		// Token: 0x040089DC RID: 35292
		[MapIndex(5)]
		[Description("item_slot_equip_weapon")]
		EquipWeapon,
		// Token: 0x040089DD RID: 35293
		[MapIndex(0)]
		[Description("item_slot_equip_head")]
		EquipHead,
		// Token: 0x040089DE RID: 35294
		[MapIndex(1)]
		[Description("item_slot_equip_chest")]
		EquipChest,
		// Token: 0x040089DF RID: 35295
		[MapIndex(2)]
		[Description("item_slot_equip_belt")]
		EquipBelt,
		// Token: 0x040089E0 RID: 35296
		[MapIndex(3)]
		[Description("item_slot_equip_leg")]
		EquipLeg,
		// Token: 0x040089E1 RID: 35297
		[MapIndex(4)]
		[Description("item_slot_equip_boot")]
		EquipBoot,
		// Token: 0x040089E2 RID: 35298
		[MapIndex(6)]
		[Description("item_slot_equip_ring")]
		EquipRing,
		// Token: 0x040089E3 RID: 35299
		[MapIndex(7)]
		[Description("item_slot_equip_necklase")]
		EquipNecklase,
		// Token: 0x040089E4 RID: 35300
		[MapIndex(8)]
		[Description("item_slot_equip_bracelet")]
		Equipbracelet,
		// Token: 0x040089E5 RID: 35301
		[MapIndex(9)]
		[Description("item_slot_equip_title")]
		Equiptitle,
		// Token: 0x040089E6 RID: 35302
		[MapIndex(14)]
		[Description("item_slot_secondequip_weapon")]
		SecondEquipWeapon,
		// Token: 0x040089E7 RID: 35303
		[MapIndex(10)]
		[Description("item_slot_equip_cloak")]
		Equipcloak,
		// Token: 0x040089E8 RID: 35304
		[MapIndex(11)]
		[Description("item_slot_equip_shirt")]
		Equipshirt,
		// Token: 0x040089E9 RID: 35305
		[MapIndex(12)]
		[Description("item_slot_equip_glove")]
		Equipglove,
		// Token: 0x040089EA RID: 35306
		[MapIndex(13)]
		[Description("item_slot_equip_accessories")]
		Equipaccessories,
		// Token: 0x040089EB RID: 35307
		[MapIndex(98)]
		[Description("item_slot_equip_assist1")]
		Equipassist1 = 99,
		// Token: 0x040089EC RID: 35308
		[MapIndex(99)]
		[Description("item_slot_equip_assist2")]
		Equipassist2,
		// Token: 0x040089ED RID: 35309
		[MapIndex(100)]
		[Description("item_slot_equip_assist3")]
		Equipassist3,
		// Token: 0x040089EE RID: 35310
		EquipMax
	}
}
