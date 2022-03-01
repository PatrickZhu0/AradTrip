using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B01 RID: 6913
	public class EnchantmentCardViceCardItem : MonoBehaviour
	{
		// Token: 0x17001D82 RID: 7554
		// (get) Token: 0x06010F6B RID: 69483 RVA: 0x004D8D65 File Offset: 0x004D7165
		public EnchantmentCardViceCardData ViceCardData
		{
			get
			{
				return this.viceCardData;
			}
		}

		// Token: 0x06010F6C RID: 69484 RVA: 0x004D8D70 File Offset: 0x004D7170
		public void OnItemVisiable(EnchantmentCardViceCardData viceCardData)
		{
			if (viceCardData == null || viceCardData.mViceCardItemData == null || viceCardData.mViceCardItemData.mPrecEnchantmentCard == null)
			{
				return;
			}
			this.viceCardData = viceCardData;
			if (this.mViceCardComItem == null)
			{
				this.mViceCardComItem = ComItemManager.Create(this.mViceCardItemRoot);
			}
			if (this.mViceCardComItem != null)
			{
				ComItem comItem = this.mViceCardComItem;
				ItemData mViceCardItemData = viceCardData.mViceCardItemData;
				if (EnchantmentCardViceCardItem.<>f__mg$cache0 == null)
				{
					EnchantmentCardViceCardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(mViceCardItemData, EnchantmentCardViceCardItem.<>f__mg$cache0);
			}
			InvokeMethod.Invoke(0.03f, delegate()
			{
				if (this.mViceCardComItem != null)
				{
					this.mViceCardComItem.SetLabCountIsShow(false);
				}
			});
			if (this.mViceCardName != null && this.mCheckViceCardName != null)
			{
				Text text = this.mViceCardName;
				string text2 = viceCardData.mViceCardItemData.GetColorName(string.Empty, false);
				this.mCheckViceCardName.text = text2;
				text.text = text2;
			}
			if (this.mViceCardArrt != null && this.mCheckViceCardArrt != null)
			{
				Text text3 = this.mViceCardArrt;
				string text2 = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(viceCardData.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardID, viceCardData.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
				this.mCheckViceCardArrt.text = text2;
				text3.text = text2;
			}
			if (this.mViceCardCount != null)
			{
				if (viceCardData.mViceCardCount > 1)
				{
					this.mViceCardCount.text = viceCardData.mViceCardCount.ToString();
				}
				else
				{
					this.mViceCardCount.text = string.Empty;
				}
			}
			if (this.mViceCardSuccessRate != null)
			{
				this.mViceCardSuccessRate.text = string.Format(this.sSuccessRateDesc, DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardProbabilityDesc(viceCardData.mAllSuccessRate));
			}
		}

		// Token: 0x06010F6D RID: 69485 RVA: 0x004D8F54 File Offset: 0x004D7354
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mCheckMarkGo != null)
			{
				this.mCheckMarkGo.CustomActive(bSelected);
			}
		}

		// Token: 0x06010F6E RID: 69486 RVA: 0x004D8F73 File Offset: 0x004D7373
		public void OnDestroy()
		{
			this.mViceCardComItem = null;
		}

		// Token: 0x0400AE6E RID: 44654
		[SerializeField]
		private Text mViceCardName;

		// Token: 0x0400AE6F RID: 44655
		[SerializeField]
		private Text mCheckViceCardName;

		// Token: 0x0400AE70 RID: 44656
		[SerializeField]
		private Text mViceCardArrt;

		// Token: 0x0400AE71 RID: 44657
		[SerializeField]
		private Text mCheckViceCardArrt;

		// Token: 0x0400AE72 RID: 44658
		[SerializeField]
		private Text mViceCardCount;

		// Token: 0x0400AE73 RID: 44659
		[SerializeField]
		private Text mViceCardSuccessRate;

		// Token: 0x0400AE74 RID: 44660
		[SerializeField]
		private GameObject mViceCardItemRoot;

		// Token: 0x0400AE75 RID: 44661
		[SerializeField]
		private GameObject mCheckMarkGo;

		// Token: 0x0400AE76 RID: 44662
		[SerializeField]
		private string sSuccessRateDesc = "成功率：{0}";

		// Token: 0x0400AE77 RID: 44663
		private ComItem mViceCardComItem;

		// Token: 0x0400AE78 RID: 44664
		private EnchantmentCardViceCardData viceCardData;

		// Token: 0x0400AE79 RID: 44665
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
