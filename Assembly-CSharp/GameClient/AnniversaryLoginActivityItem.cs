using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001810 RID: 6160
	public class AnniversaryLoginActivityItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F2B4 RID: 62132 RVA: 0x004179B4 File Offset: 0x00415DB4
		public void Init(bool isShow, GiftSyncInfo giftSyncInfo)
		{
			base.transform.localScale = Vector3.one;
			this.mTakenGo.CustomActive(true);
			this.mHaveRewardTxt.CustomActive(isShow);
			ComItem comItem = ComItemManager.Create(this.mIconParent.gameObject);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)giftSyncInfo.itemId, 100, 0);
			if (comItem != null && itemData != null)
			{
				itemData.Count = (int)giftSyncInfo.itemNum;
				this.mNameTxt.SafeSetText(itemData.Name);
				comItem.GetComponent<RectTransform>().sizeDelta = this.mComItemSize;
				ComItem comItem2 = comItem;
				ItemData item = itemData;
				if (AnniversaryLoginActivityItem.<>f__mg$cache0 == null)
				{
					AnniversaryLoginActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, AnniversaryLoginActivityItem.<>f__mg$cache0);
			}
		}

		// Token: 0x0600F2B5 RID: 62133 RVA: 0x00417A6D File Offset: 0x00415E6D
		public void ShowHaveReceivedState()
		{
			this.mHaveRewardTxt.CustomActive(true);
		}

		// Token: 0x0600F2B6 RID: 62134 RVA: 0x00417A7B File Offset: 0x00415E7B
		public void Dispose()
		{
		}

		// Token: 0x04009527 RID: 38183
		[SerializeField]
		private Transform mIconParent;

		// Token: 0x04009528 RID: 38184
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009529 RID: 38185
		[SerializeField]
		private Text mHaveRewardTxt;

		// Token: 0x0400952A RID: 38186
		[SerializeField]
		private GameObject mTakenGo;

		// Token: 0x0400952B RID: 38187
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(90f, 90f);

		// Token: 0x0400952C RID: 38188
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
