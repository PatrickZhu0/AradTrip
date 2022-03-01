using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001679 RID: 5753
	public class HonorSystemProtectCardItem : MonoBehaviour
	{
		// Token: 0x0600E225 RID: 57893 RVA: 0x003A1952 File Offset: 0x0039FD52
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E226 RID: 57894 RVA: 0x003A195A File Offset: 0x0039FD5A
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E227 RID: 57895 RVA: 0x003A1968 File Offset: 0x0039FD68
		private void BindEvents()
		{
			if (this.getButton != null)
			{
				this.getButton.onClick.RemoveAllListeners();
				this.getButton.onClick.AddListener(new UnityAction(this.OnGetButtonClicked));
			}
			if (this.useButton != null)
			{
				this.useButton.onClick.RemoveAllListeners();
				this.useButton.onClick.AddListener(new UnityAction(this.OnUseButtonClicked));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnItemInPackageAddedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageAddedMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemPropertyChanged, new ClientEventSystem.UIEventHandler(this.OnItemPropertyChanged));
		}

		// Token: 0x0600E228 RID: 57896 RVA: 0x003A1A28 File Offset: 0x0039FE28
		private void UnBindEvents()
		{
			if (this.getButton != null)
			{
				this.getButton.onClick.RemoveAllListeners();
			}
			if (this.useButton != null)
			{
				this.useButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnItemInPackageAddedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageAddedMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemPropertyChanged, new ClientEventSystem.UIEventHandler(this.OnItemPropertyChanged));
		}

		// Token: 0x0600E229 RID: 57897 RVA: 0x003A1AAD File Offset: 0x0039FEAD
		private void ClearData()
		{
			this._protectCardItemId = 0;
			this._itemData = null;
			this._itemTable = null;
		}

		// Token: 0x0600E22A RID: 57898 RVA: 0x003A1AC4 File Offset: 0x0039FEC4
		public void InitItem(int protectCardItemId, ItemData itemData)
		{
			this._protectCardItemId = protectCardItemId;
			if (this._protectCardItemId <= 0)
			{
				return;
			}
			this._itemData = itemData;
			this._itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._protectCardItemId, string.Empty, string.Empty);
			if (this._itemTable == null)
			{
				return;
			}
			this.InitBaseView();
			this.UpdateItemCountLabel();
			this.UpdateButtonState();
		}

		// Token: 0x0600E22B RID: 57899 RVA: 0x003A1B2C File Offset: 0x0039FF2C
		private void InitBaseView()
		{
			if (this.itemNameLabel != null)
			{
				this.itemNameLabel.text = CommonUtility.GetItemColorName(this._itemTable);
			}
			if (this.itemLevelLimitLabel != null)
			{
				string text = TR.Value("Honor_System_Protect_Card_Level_Format_Label", this._itemTable.UseLimiteValue);
				this.itemLevelLimitLabel.text = text;
			}
			if (this.itemRoot != null)
			{
				CommonNewItem commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (commonNewItem == null)
				{
					commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
				commonNewItem.InitItem(this._protectCardItemId, 1);
			}
		}

		// Token: 0x0600E22C RID: 57900 RVA: 0x003A1BDC File Offset: 0x0039FFDC
		private void UpdateItemCountLabel()
		{
			if (this.itemCountLabel == null)
			{
				return;
			}
			if (this._itemData != null && this._itemData.Count > 0)
			{
				this.itemCountLabel.text = this._itemData.Count.ToString();
				this.itemCountLabel.color = Color.green;
			}
			else
			{
				this.itemCountLabel.text = "0";
				this.itemCountLabel.color = Color.red;
			}
		}

		// Token: 0x0600E22D RID: 57901 RVA: 0x003A1C70 File Offset: 0x003A0070
		private void UpdateButtonState()
		{
			bool flag = (ulong)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel > (ulong)((long)this._itemTable.UseLimiteValue);
			if (this._itemData != null && this._itemData.Count > 0)
			{
				CommonUtility.UpdateButtonVisible(this.getButton, false);
				CommonUtility.UpdateButtonVisible(this.useButton, true);
				if (flag)
				{
					CommonUtility.UpdateButtonState(this.useButton, this.useButtonGray, false);
				}
				else
				{
					CommonUtility.UpdateButtonState(this.useButton, this.useButtonGray, true);
				}
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.useButton, false);
				CommonUtility.UpdateButtonVisible(this.getButton, true);
				if (flag)
				{
					CommonUtility.UpdateButtonState(this.getButton, this.getButtonGray, false);
				}
				else
				{
					CommonUtility.UpdateButtonState(this.getButton, this.getButtonGray, true);
				}
			}
		}

		// Token: 0x0600E22E RID: 57902 RVA: 0x003A1D46 File Offset: 0x003A0146
		private void OnCloseFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemProtectCardFrame();
		}

		// Token: 0x0600E22F RID: 57903 RVA: 0x003A1D50 File Offset: 0x003A0150
		private void OnGetButtonClicked()
		{
			if (this._itemTable == null)
			{
				return;
			}
			HonorSystemUtility.OnCloseHonorSystemProtectCardFrame();
			ItemComeLink.OnLink(this._protectCardItemId, 0, false, null, false, this._itemTable.bNeedJump > 0, false, null, string.Empty);
		}

		// Token: 0x0600E230 RID: 57904 RVA: 0x003A1D94 File Offset: 0x003A0194
		private void OnUseButtonClicked()
		{
			if (this._itemData == null || this._itemTable == null)
			{
				return;
			}
			string itemColorName = CommonUtility.GetItemColorName(this._itemTable);
			string tipContent = TR.Value("Honor_System_Protect_Card_Use_Content_Format", itemColorName);
			CommonUtility.OnShowCommonMsgBox(tipContent, new Action(this.OnUseProtectCardItem), TR.Value("common_data_sure_2"));
		}

		// Token: 0x0600E231 RID: 57905 RVA: 0x003A1DEC File Offset: 0x003A01EC
		private void OnUseProtectCardItem()
		{
			HonorSystemUtility.OnCloseHonorSystemProtectCardFrame();
			if (this._itemData == null)
			{
				return;
			}
			DataManager<ItemDataManager>.GetInstance().UseItem(this._itemData, false, 0, 0);
		}

		// Token: 0x0600E232 RID: 57906 RVA: 0x003A1E14 File Offset: 0x003A0214
		private void OnItemPropertyChanged(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			EItemProperty eitemProperty = (EItemProperty)uiEvent.Param2;
			if (eitemProperty != EItemProperty.EP_NUM)
			{
				return;
			}
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (itemData == null)
			{
				return;
			}
			if (itemData.TableID != this._protectCardItemId)
			{
				return;
			}
			this.UpdateProtectCardItemInfo(itemData);
		}

		// Token: 0x0600E233 RID: 57907 RVA: 0x003A1E80 File Offset: 0x003A0280
		private void OnItemInPackageAddedMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong id = (ulong)uiEvent.Param1;
			int num = (int)uiEvent.Param2;
			if (num != this._protectCardItemId)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
			if (item == null)
			{
				return;
			}
			this.UpdateProtectCardItemInfo(item);
		}

		// Token: 0x0600E234 RID: 57908 RVA: 0x003A1EE9 File Offset: 0x003A02E9
		private void UpdateProtectCardItemInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this._itemData = itemData;
			this.UpdateItemCountLabel();
			this.UpdateButtonState();
		}

		// Token: 0x04008753 RID: 34643
		private int _protectCardItemId;

		// Token: 0x04008754 RID: 34644
		private ItemData _itemData;

		// Token: 0x04008755 RID: 34645
		private ItemTable _itemTable;

		// Token: 0x04008756 RID: 34646
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text itemNameLabel;

		// Token: 0x04008757 RID: 34647
		[SerializeField]
		private Text itemLevelLimitLabel;

		// Token: 0x04008758 RID: 34648
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x04008759 RID: 34649
		[SerializeField]
		private Text itemCountLabel;

		// Token: 0x0400875A RID: 34650
		[Space(10f)]
		[Header("ButtonRoot")]
		[Space(10f)]
		[SerializeField]
		private Button getButton;

		// Token: 0x0400875B RID: 34651
		[SerializeField]
		private UIGray getButtonGray;

		// Token: 0x0400875C RID: 34652
		[SerializeField]
		private Button useButton;

		// Token: 0x0400875D RID: 34653
		[SerializeField]
		private UIGray useButtonGray;
	}
}
