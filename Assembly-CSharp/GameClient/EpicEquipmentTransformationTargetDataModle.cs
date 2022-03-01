using System;

namespace GameClient
{
	// Token: 0x02001B09 RID: 6921
	public class EpicEquipmentTransformationTargetDataModle
	{
		// Token: 0x0400AEDC RID: 44764
		public EpicEquipmentTransformationType type;

		// Token: 0x0400AEDD RID: 44765
		public ItemData equipmentItem;

		// Token: 0x0400AEDE RID: 44766
		public Action<ItemData> onTargetEquipmentClick;
	}
}
