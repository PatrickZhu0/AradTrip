using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020016AF RID: 5807
	public class EquipSuitRes
	{
		// Token: 0x040088CB RID: 35019
		public int id;

		// Token: 0x040088CC RID: 35020
		public string name;

		// Token: 0x040088CD RID: 35021
		public IList<int> equips = new List<int>();

		// Token: 0x040088CE RID: 35022
		public Dictionary<int, EquipProp> props = new Dictionary<int, EquipProp>();
	}
}
