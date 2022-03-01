using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001677 RID: 5751
	public class HonorSystemUnLockShopItem : MonoBehaviour
	{
		// Token: 0x0600E218 RID: 57880 RVA: 0x003A184B File Offset: 0x0039FC4B
		private void Awake()
		{
		}

		// Token: 0x0600E219 RID: 57881 RVA: 0x003A184D File Offset: 0x0039FC4D
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600E21A RID: 57882 RVA: 0x003A1855 File Offset: 0x0039FC55
		private void ClearData()
		{
			this._shopItemId = 0;
		}

		// Token: 0x0600E21B RID: 57883 RVA: 0x003A185E File Offset: 0x0039FC5E
		public void InitUnLockShopItem(int shopItemId)
		{
			this._shopItemId = shopItemId;
			if (this._shopItemId <= 0)
			{
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600E21C RID: 57884 RVA: 0x003A187C File Offset: 0x0039FC7C
		private void InitItemView()
		{
			if (this.shopItemRoot == null)
			{
				return;
			}
			CommonNewItem commonNewItem = this.shopItemRoot.GetComponentInChildren<CommonNewItem>();
			if (commonNewItem == null)
			{
				commonNewItem = CommonUtility.CreateCommonNewItem(this.shopItemRoot);
			}
			else
			{
				commonNewItem.Reset();
			}
			if (commonNewItem != null)
			{
				commonNewItem.InitItem(this._shopItemId, 1);
				commonNewItem.SetItemLevelFontSize(28);
			}
		}

		// Token: 0x0600E21D RID: 57885 RVA: 0x003A18EB File Offset: 0x0039FCEB
		public void OnRecycleItem()
		{
			this._shopItemId = 0;
		}

		// Token: 0x04008750 RID: 34640
		private int _shopItemId;

		// Token: 0x04008751 RID: 34641
		[Space(10f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject shopItemRoot;
	}
}
