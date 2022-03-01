using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020015C6 RID: 5574
	internal class EquipHandbookUtility
	{
		// Token: 0x0600DA46 RID: 55878 RVA: 0x0036DDA0 File Offset: 0x0036C1A0
		public static bool IsFitOccupation(List<int> fitOccupations, List<int> baseOccupations)
		{
			if (baseOccupations != null && baseOccupations.Count > 0)
			{
				for (int i = 0; i < baseOccupations.Count; i++)
				{
					if (baseOccupations[i] == 0)
					{
						return true;
					}
					if (Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID) == Utility.GetBaseJobID(baseOccupations[i]))
					{
						return true;
					}
				}
			}
			else
			{
				for (int j = 0; j < fitOccupations.Count; j++)
				{
					if (DataManager<PlayerBaseData>.GetInstance().JobTableID == fitOccupations[j])
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600DA47 RID: 55879 RVA: 0x0036DE3C File Offset: 0x0036C23C
		public static bool IsFitOccupation(List<int> fitOccupations)
		{
			if (fitOccupations == null || fitOccupations.Count <= 0)
			{
				return true;
			}
			for (int i = 0; i < fitOccupations.Count; i++)
			{
				if (fitOccupations[i] == 0)
				{
					return true;
				}
				if (DataManager<PlayerBaseData>.GetInstance().JobTableID == fitOccupations[i])
				{
					return true;
				}
			}
			return false;
		}
	}
}
