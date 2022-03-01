using System;

namespace GameClient
{
	// Token: 0x020016A8 RID: 5800
	public static class EquipPropRate
	{
		// Token: 0x0600E3BD RID: 58301 RVA: 0x003AB25C File Offset: 0x003A965C
		static EquipPropRate()
		{
			for (int i = 0; i < EquipPropRate.propRates.Length; i++)
			{
				EquipPropRate.propRates[i] = new CrypticInt32(1);
			}
			EquipPropRate.propRates[4] = new CrypticInt32(GlobalLogic.VALUE_1000);
			EquipPropRate.propRates[5] = new CrypticInt32(GlobalLogic.VALUE_1000);
			EquipPropRate.propRates[6] = new CrypticInt32(GlobalLogic.VALUE_1000);
			EquipPropRate.propRates[7] = new CrypticInt32(GlobalLogic.VALUE_1000);
			EquipPropRate.propRates[16] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[17] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[18] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[30] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[31] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[32] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[33] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[36] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[8] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[9] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[10] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[11] = new CrypticInt32(GlobalLogic.VALUE_10);
			EquipPropRate.propRates[37] = new CrypticInt32(GlobalLogic.VALUE_100);
			EquipPropRate.propRates[38] = new CrypticInt32(GlobalLogic.VALUE_100);
			EquipPropRate.propRates[41] = new CrypticInt32(GlobalLogic.VALUE_100);
			EquipPropRate.propRates[42] = new CrypticInt32(GlobalLogic.VALUE_100);
			EquipPropRate.propRates[59] = new CrypticInt32(GlobalLogic.VALUE_1000);
			EquipPropRate.propRates[60] = new CrypticInt32(GlobalLogic.VALUE_1000);
		}

		// Token: 0x040088AF RID: 34991
		public static CrypticInt32[] propRates = new CrypticInt32[61];
	}
}
