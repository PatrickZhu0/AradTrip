using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017DE RID: 6110
	public class ComMoneyRewardsEnterSetting : MonoBehaviour
	{
		// Token: 0x0600F0D7 RID: 61655 RVA: 0x0040D7E0 File Offset: 0x0040BBE0
		public void UpdateHint()
		{
			if (null != this.hint)
			{
				int enrollItemID = DataManager<MoneyRewardsDataManager>.GetInstance().EnrollItemID;
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(enrollItemID);
				string arg = string.Empty;
				if (commonItemTableDataByID != null)
				{
					arg = commonItemTableDataByID.GetColorName(string.Empty, false);
				}
				this.hint.text = string.Format(this.fmtString, arg, DataManager<MoneyRewardsDataManager>.GetInstance().EnrollCount);
			}
		}

		// Token: 0x0600F0D8 RID: 61656 RVA: 0x0040D854 File Offset: 0x0040BC54
		public void UpdateChampAwards()
		{
			if (null != this.champAwards)
			{
				this.champAwards.text = DataManager<MoneyRewardsDataManager>.GetInstance().ChampAward.ToString();
			}
		}

		// Token: 0x040093DA RID: 37850
		public string fmtString;

		// Token: 0x040093DB RID: 37851
		public Text hint;

		// Token: 0x040093DC RID: 37852
		public Text champAwards;
	}
}
