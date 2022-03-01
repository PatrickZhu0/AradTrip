using System;

namespace GameClient
{
	// Token: 0x02001B10 RID: 6928
	public class EquipmentConversionUtility
	{
		// Token: 0x0601102C RID: 69676 RVA: 0x004DE228 File Offset: 0x004DC628
		public static int SoreEquipments(ItemData left, ItemData right)
		{
			if (left.PackageType != right.PackageType)
			{
				return right.PackageType - left.PackageType;
			}
			if (left.IsItemInUnUsedEquipPlan != right.IsItemInUnUsedEquipPlan)
			{
				if (left.IsItemInUnUsedEquipPlan)
				{
					return -1;
				}
				if (right.IsItemInUnUsedEquipPlan)
				{
					return 1;
				}
			}
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			if (left.SubType != right.SubType)
			{
				return left.SubType - right.SubType;
			}
			if (left.StrengthenLevel != right.StrengthenLevel)
			{
				return right.StrengthenLevel - left.StrengthenLevel;
			}
			return right.LevelLimit - left.LevelLimit;
		}
	}
}
