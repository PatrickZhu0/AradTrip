using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016EA RID: 5866
	public class ItemTipModelAvatarEnumerationItem : MonoBehaviour
	{
		// Token: 0x0600E5CC RID: 58828 RVA: 0x003BE5BE File Offset: 0x003BC9BE
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600E5CD RID: 58829 RVA: 0x003BE5C6 File Offset: 0x003BC9C6
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600E5CE RID: 58830 RVA: 0x003BE5D4 File Offset: 0x003BC9D4
		private void BindUiEvents()
		{
			if (this.itemSelectButton != null)
			{
				this.itemSelectButton.onClick.RemoveAllListeners();
				this.itemSelectButton.onClick.AddListener(new UnityAction(this.OnItemSelectButtonClicked));
			}
		}

		// Token: 0x0600E5CF RID: 58831 RVA: 0x003BE613 File Offset: 0x003BCA13
		private void UnBindUiEvents()
		{
			if (this.itemSelectButton != null)
			{
				this.itemSelectButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600E5D0 RID: 58832 RVA: 0x003BE636 File Offset: 0x003BCA36
		private void ClearData()
		{
			this._itemTipModelAvatarEnumerationDataModel = null;
		}

		// Token: 0x0600E5D1 RID: 58833 RVA: 0x003BE640 File Offset: 0x003BCA40
		public void InitItem(ItemTipModelAvatarEnumerationDataModel itemTipModelAvatarDataModel, OnItemTipModelAvatarEnumerationItemClick onItemTipModelAvatarEnumerationItemClick)
		{
			this._itemTipModelAvatarEnumerationDataModel = itemTipModelAvatarDataModel;
			this._onItemTipModelAvatarEnumerationItemClick = onItemTipModelAvatarEnumerationItemClick;
			if (this._itemTipModelAvatarEnumerationDataModel == null)
			{
				return;
			}
			CommonUtility.UpdateImageVisible(this.itemBg, false);
			CommonUtility.UpdateImageVisible(this.playerFrameIcon, false);
			if (this._itemTipModelAvatarEnumerationDataModel.IsPlayerProfessionType)
			{
				CommonUtility.UpdateImageVisible(this.playerFrameIcon, true);
				this.InitPlayerItem();
			}
			else
			{
				CommonUtility.UpdateImageVisible(this.itemBg, true);
				this.InitItemView();
			}
		}

		// Token: 0x0600E5D2 RID: 58834 RVA: 0x003BE6B8 File Offset: 0x003BCAB8
		private void InitPlayerItem()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this._itemTipModelAvatarEnumerationDataModel.ProfessionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.itemNameLabel != null)
			{
				this.itemNameLabel.text = tableItem.Name;
			}
			if (this.itemIcon != null)
			{
				string playerProfessionHeadIconPath = PlayerUtility.GetPlayerProfessionHeadIconPath(this._itemTipModelAvatarEnumerationDataModel.ProfessionId);
				if (!string.IsNullOrEmpty(playerProfessionHeadIconPath))
				{
					ETCImageLoader.LoadSprite(ref this.itemIcon, playerProfessionHeadIconPath, true);
				}
			}
			this.UpdateItemSelectedFlag();
		}

		// Token: 0x0600E5D3 RID: 58835 RVA: 0x003BE750 File Offset: 0x003BCB50
		private void InitItemView()
		{
			ItemTable itemTable = this._itemTipModelAvatarEnumerationDataModel.ItemTable;
			if (itemTable == null)
			{
				return;
			}
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(itemTable.Color, false, false);
			if (this.itemBg != null && qualityInfo != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemBg, qualityInfo.Background, true);
			}
			if (itemTable.SubType == ItemTable.eSubType.PetEgg)
			{
				int petIdByItemTable = ItemDataUtility.GetPetIdByItemTable(itemTable);
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petIdByItemTable, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this.itemIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.itemIcon, tableItem.IconPath, true);
					}
					if (this.itemNameLabel != null)
					{
						string petItemName = CommonUtility.GetPetItemName(tableItem);
						this.itemNameLabel.text = petItemName;
					}
				}
			}
			else
			{
				if (this.itemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.itemIcon, itemTable.Icon, true);
				}
				if (this.itemNameLabel != null)
				{
					string itemColorName = CommonUtility.GetItemColorName(itemTable);
					this.itemNameLabel.text = itemColorName;
				}
			}
			this.UpdateItemSelectedFlag();
		}

		// Token: 0x0600E5D4 RID: 58836 RVA: 0x003BE877 File Offset: 0x003BCC77
		public void UpdateItem()
		{
			this.UpdateItemSelectedFlag();
		}

		// Token: 0x0600E5D5 RID: 58837 RVA: 0x003BE87F File Offset: 0x003BCC7F
		public void RecycleItem()
		{
			this._itemTipModelAvatarEnumerationDataModel = null;
		}

		// Token: 0x0600E5D6 RID: 58838 RVA: 0x003BE888 File Offset: 0x003BCC88
		private void OnItemSelectButtonClicked()
		{
			if (this._itemTipModelAvatarEnumerationDataModel == null)
			{
				return;
			}
			if (this._itemTipModelAvatarEnumerationDataModel.IsSelectedFlag)
			{
				return;
			}
			this._itemTipModelAvatarEnumerationDataModel.IsSelectedFlag = true;
			this.UpdateItemSelectedFlag();
			if (this._onItemTipModelAvatarEnumerationItemClick != null)
			{
				this._onItemTipModelAvatarEnumerationItemClick(this._itemTipModelAvatarEnumerationDataModel.Index);
			}
		}

		// Token: 0x0600E5D7 RID: 58839 RVA: 0x003BE8E5 File Offset: 0x003BCCE5
		private void UpdateItemSelectedFlag()
		{
			if (this._itemTipModelAvatarEnumerationDataModel == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.itemSelectFlag, this._itemTipModelAvatarEnumerationDataModel.IsSelectedFlag);
		}

		// Token: 0x04008B21 RID: 35617
		private ItemTipModelAvatarEnumerationDataModel _itemTipModelAvatarEnumerationDataModel;

		// Token: 0x04008B22 RID: 35618
		private OnItemTipModelAvatarEnumerationItemClick _onItemTipModelAvatarEnumerationItemClick;

		// Token: 0x04008B23 RID: 35619
		[Space(10f)]
		[Header("ItemContent")]
		[Space(10f)]
		[SerializeField]
		private Image itemBg;

		// Token: 0x04008B24 RID: 35620
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04008B25 RID: 35621
		[SerializeField]
		private Text itemNameLabel;

		// Token: 0x04008B26 RID: 35622
		[Space(10f)]
		[Header("PlayerProfession")]
		[Space(10f)]
		[SerializeField]
		private Image playerFrameIcon;

		// Token: 0x04008B27 RID: 35623
		[Space(10f)]
		[Header("ItemSelected")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemSelectFlag;

		// Token: 0x04008B28 RID: 35624
		[SerializeField]
		private Button itemSelectButton;
	}
}
