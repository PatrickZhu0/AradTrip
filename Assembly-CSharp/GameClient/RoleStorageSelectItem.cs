using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001703 RID: 5891
	public class RoleStorageSelectItem : MonoBehaviour
	{
		// Token: 0x0600E763 RID: 59235 RVA: 0x003D02A3 File Offset: 0x003CE6A3
		private void Awake()
		{
			if (this.ItemSelectButton != null)
			{
				this.ItemSelectButton.onClick.RemoveAllListeners();
				this.ItemSelectButton.onClick.AddListener(new UnityAction(this.OnItemSelectButtonClick));
			}
		}

		// Token: 0x0600E764 RID: 59236 RVA: 0x003D02E2 File Offset: 0x003CE6E2
		private void OnDestroy()
		{
			if (this.ItemSelectButton != null)
			{
				this.ItemSelectButton.onClick.RemoveAllListeners();
			}
			this._itemIndex = 0;
			this._totalOwnerItemNumber = 0;
			this._onRoleStorageSelectItemClick = null;
		}

		// Token: 0x0600E765 RID: 59237 RVA: 0x003D031A File Offset: 0x003CE71A
		public void InitItem(int itemIndex, OnRoleStorageSelectItemClick onRoleStorageSelectItemClick)
		{
			this._itemIndex = itemIndex;
			this._onRoleStorageSelectItemClick = onRoleStorageSelectItemClick;
		}

		// Token: 0x0600E766 RID: 59238 RVA: 0x003D032A File Offset: 0x003CE72A
		public void OnUpdateItem(int ownerItemNumber)
		{
			this._totalOwnerItemNumber = ownerItemNumber;
			this.UpdateSelectItem();
		}

		// Token: 0x0600E767 RID: 59239 RVA: 0x003D0339 File Offset: 0x003CE739
		public void OnUpdateItemName()
		{
			this.UpdateSelectItem();
		}

		// Token: 0x0600E768 RID: 59240 RVA: 0x003D0344 File Offset: 0x003CE744
		private void UpdateSelectItem()
		{
			if (this._itemIndex > this._totalOwnerItemNumber)
			{
				CommonUtility.UpdateGameObjectVisible(this.itemLockImage, true);
				if (this.itemButtonImage != null)
				{
					this.itemButtonImage.color = new Color(255f, 255f, 255f, 0.6f);
				}
				CommonUtility.UpdateTextVisible(this.itemNameLabel, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.itemLockImage, false);
				if (this.itemButtonImage != null)
				{
					this.itemButtonImage.color = new Color(255f, 255f, 255f, 1f);
				}
				CommonUtility.UpdateTextVisible(this.itemNameLabel, true);
				if (this.itemNameLabel != null)
				{
					string roleStorageNameByStorageIndex = StorageUtility.GetRoleStorageNameByStorageIndex(this._itemIndex);
					this.itemNameLabel.text = roleStorageNameByStorageIndex;
				}
			}
		}

		// Token: 0x0600E769 RID: 59241 RVA: 0x003D042C File Offset: 0x003CE82C
		private void OnItemSelectButtonClick()
		{
			if (this._itemIndex > this._totalOwnerItemNumber)
			{
				StorageUnLockCostDataModel storageUnLockCostDataModel = StorageUtility.GetStorageUnLockCostDataModel(this._totalOwnerItemNumber);
				if (storageUnLockCostDataModel == null)
				{
					return;
				}
				StorageUtility.OnOpenStorageUnLockTipFrame(storageUnLockCostDataModel);
			}
			else if (this._onRoleStorageSelectItemClick != null)
			{
				this._onRoleStorageSelectItemClick(this._itemIndex);
			}
		}

		// Token: 0x0600E76A RID: 59242 RVA: 0x003D0484 File Offset: 0x003CE884
		public int GetItemIndex()
		{
			return this._itemIndex;
		}

		// Token: 0x04008C59 RID: 35929
		private int _itemIndex;

		// Token: 0x04008C5A RID: 35930
		private int _totalOwnerItemNumber;

		// Token: 0x04008C5B RID: 35931
		private OnRoleStorageSelectItemClick _onRoleStorageSelectItemClick;

		// Token: 0x04008C5C RID: 35932
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Button ItemSelectButton;

		// Token: 0x04008C5D RID: 35933
		[SerializeField]
		private Text itemNameLabel;

		// Token: 0x04008C5E RID: 35934
		[SerializeField]
		private GameObject itemLockImage;

		// Token: 0x04008C5F RID: 35935
		[SerializeField]
		private Image itemButtonImage;
	}
}
