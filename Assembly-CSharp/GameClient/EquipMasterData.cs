using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016B1 RID: 5809
	public class EquipMasterData
	{
		// Token: 0x0600E3DB RID: 58331 RVA: 0x003ADC08 File Offset: 0x003AC008
		public EquipProp GetEquipProp(int equipLevel)
		{
			EquipProp equipProp = new EquipProp();
			for (int i = 0; i < equipProp.props.Length; i++)
			{
				int i2 = IntMath.Float2Int(Mathf.Round((float)equipLevel / 5f));
				VFactor a = new VFactor((long)(GlobalLogic.VALUE_1 * this.qualityParam[i]), (long)GlobalLogic.VALUE_1000);
				VFactor vfactor = new VFactor((long)(GlobalLogic.VALUE_1 * this.partParam[i]), (long)GlobalLogic.VALUE_1000);
				VFactor b = new VFactor((long)(GlobalLogic.VALUE_1 * this.fixParam[i]), (long)GlobalLogic.VALUE_1000);
				VFactor a2 = a * vfactor + (long)(i2 * vfactor) + b;
				equipProp.props[i] = (a2 * (long)EquipPropRate.propRates[i]).roundInt;
			}
			return equipProp;
		}

		// Token: 0x040088D1 RID: 35025
		public int id;

		// Token: 0x040088D2 RID: 35026
		public int jobID;

		// Token: 0x040088D3 RID: 35027
		public CrypticInt32 quality;

		// Token: 0x040088D4 RID: 35028
		public int part;

		// Token: 0x040088D5 RID: 35029
		public int materialType;

		// Token: 0x040088D6 RID: 35030
		public CrypticInt32[] qualityParam = new CrypticInt32[61];

		// Token: 0x040088D7 RID: 35031
		public CrypticInt32[] partParam = new CrypticInt32[61];

		// Token: 0x040088D8 RID: 35032
		public CrypticInt32[] fixParam = new CrypticInt32[61];

		// Token: 0x040088D9 RID: 35033
		public EquipMasterTable masterItem;
	}
}
