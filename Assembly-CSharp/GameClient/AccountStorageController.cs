using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001702 RID: 5890
	public class AccountStorageController : MonoBehaviour
	{
		// Token: 0x0600E750 RID: 59216 RVA: 0x003CFC4F File Offset: 0x003CE04F
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600E751 RID: 59217 RVA: 0x003CFC57 File Offset: 0x003CE057
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x0600E752 RID: 59218 RVA: 0x003CFC60 File Offset: 0x003CE060
		private void BindUiEvents()
		{
			if (this.storageItemListEx != null)
			{
				this.storageItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.storageItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.storageItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.arrangeButtonWithCd != null)
			{
				this.arrangeButtonWithCd.ResetButtonListener();
				this.arrangeButtonWithCd.SetButtonListener(new Action(this.OnArrangeButtonClick));
			}
			if (this.addGridButton != null)
			{
				this.addGridButton.onClick.RemoveAllListeners();
				this.addGridButton.onClick.AddListener(new UnityAction(this.OnAddGridButtonClick));
			}
		}

		// Token: 0x0600E753 RID: 59219 RVA: 0x003CFD48 File Offset: 0x003CE148
		private void UnBindUiEvents()
		{
			if (this.storageItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.storageItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.storageItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
				this.storageItemListEx.UnInitialize();
			}
			if (this.arrangeButtonWithCd != null)
			{
				this.arrangeButtonWithCd.ResetButtonListener();
			}
			if (this.addGridButton != null)
			{
				this.addGridButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600E754 RID: 59220 RVA: 0x003CFDFC File Offset: 0x003CE1FC
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
		}

		// Token: 0x0600E755 RID: 59221 RVA: 0x003CFE34 File Offset: 0x003CE234
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
		}

		// Token: 0x0600E756 RID: 59222 RVA: 0x003CFE6C File Offset: 0x003CE26C
		public void InitView(StorageType storageType)
		{
			this._storageType = storageType;
			DataManager<ItemDataManager>.GetInstance().ArrangeItems(EPackageType.Storage);
			this.UpdateStorageItemList();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E757 RID: 59223 RVA: 0x003CFE8C File Offset: 0x003CE28C
		public void OnEnableView()
		{
			this.ResetStorageItemList();
			this.UpdateStorageItemList();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E758 RID: 59224 RVA: 0x003CFEA0 File Offset: 0x003CE2A0
		private void ResetArrangeButton()
		{
			if (this.arrangeButtonWithCd != null)
			{
				this.arrangeButtonWithCd.Reset();
			}
		}

		// Token: 0x0600E759 RID: 59225 RVA: 0x003CFEC0 File Offset: 0x003CE2C0
		private void UpdateStorageItemList()
		{
			this.UpdateGridInfo();
			if (this.storageItemListEx == null)
			{
				return;
			}
			this._storageItemDataModelList = StorageUtility.GetStorageItemDataModelList(this._storageType, 0);
			int elementAmount = 0;
			if (this._storageItemDataModelList != null)
			{
				elementAmount = this._storageItemDataModelList.Count;
			}
			this.storageItemListEx.SetElementAmount(elementAmount);
		}

		// Token: 0x0600E75A RID: 59226 RVA: 0x003CFF1C File Offset: 0x003CE31C
		private void UpdateGridInfo()
		{
			if (this.gridValueLabel == null)
			{
				return;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Storage);
			int num = 0;
			if (itemsByPackageType != null && itemsByPackageType.Count > 0)
			{
				num = itemsByPackageType.Count;
			}
			int accountStorageSize = DataManager<PlayerBaseData>.GetInstance().AccountStorageSize;
			this.gridValueLabel.text = TR.Value("Common_Two_Number_Format_One", num, accountStorageSize);
		}

		// Token: 0x0600E75B RID: 59227 RVA: 0x003CFF8E File Offset: 0x003CE38E
		private void ResetStorageItemList()
		{
			if (this.storageItemListEx == null)
			{
				return;
			}
			this.storageItemListEx.ResetComUiListScriptEx();
		}

		// Token: 0x0600E75C RID: 59228 RVA: 0x003CFFB0 File Offset: 0x003CE3B0
		protected void OnArrangeButtonClick()
		{
			SceneTrimItem sceneTrimItem = new SceneTrimItem();
			sceneTrimItem.pack = (byte)this._storageType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneTrimItem>(ServerType.GATE_SERVER, sceneTrimItem);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneTrimItemRet>(delegate(SceneTrimItemRet msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().ArrangeItems(EPackageType.Storage);
					this.UpdateStorageItemList();
				}
			}, true, 15f, null);
		}

		// Token: 0x0600E75D RID: 59229 RVA: 0x003D0000 File Offset: 0x003CE400
		protected void OnAddGridButtonClick()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().AccountStorageSize + 10;
			if (num > 100)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("storage_unlock_max"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num + 1, string.Empty, string.Empty);
			if (tableItem != null && tableItem2 != null)
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo
				{
					nMoneyID = tableItem2.Value,
					nCount = tableItem.Value
				};
				string enlargeStorageSizeCostDesc = StorageUtility.GetEnlargeStorageSizeCostDesc(costInfo);
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(enlargeStorageSizeCostDesc, delegate()
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						SceneEnlargeStorage cmd = new SceneEnlargeStorage();
						NetManager netManager = NetManager.Instance();
						netManager.SendCommand<SceneEnlargeStorage>(ServerType.GATE_SERVER, cmd);
						DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEnlargeStorageRet>(delegate(SceneEnlargeStorageRet msgRet)
						{
							if (msgRet == null)
							{
								return;
							}
							if (msgRet.code != 0U)
							{
								SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("storage_unlock_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
								this.UpdateStorageItemList();
							}
						}, true, 15f, null);
					}, "common_money_cost", null);
				}, null, 0f, false);
			}
		}

		// Token: 0x0600E75E RID: 59230 RVA: 0x003D00CC File Offset: 0x003CE4CC
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			StorageItem component = item.GetComponent<StorageItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600E75F RID: 59231 RVA: 0x003D0100 File Offset: 0x003CE500
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.storageItemListEx == null)
			{
				return;
			}
			if (this._storageItemDataModelList == null || this._storageItemDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._storageItemDataModelList.Count)
			{
				return;
			}
			StorageItemDataModel storageItemDataModel = this._storageItemDataModelList[item.m_index];
			StorageItem component = item.GetComponent<StorageItem>();
			if (component != null && storageItemDataModel != null)
			{
				component.InitStorageItem(storageItemDataModel);
			}
		}

		// Token: 0x0600E760 RID: 59232 RVA: 0x003D019E File Offset: 0x003CE59E
		private void UpdateItemListByUiEvent(UIEvent uiEvent)
		{
			this.UpdateStorageItemList();
		}

		// Token: 0x04008C53 RID: 35923
		private StorageType _storageType;

		// Token: 0x04008C54 RID: 35924
		private List<StorageItemDataModel> _storageItemDataModelList;

		// Token: 0x04008C55 RID: 35925
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd arrangeButtonWithCd;

		// Token: 0x04008C56 RID: 35926
		[SerializeField]
		private Button addGridButton;

		// Token: 0x04008C57 RID: 35927
		[Space(10f)]
		[Header("GridValue")]
		[Space(10f)]
		[SerializeField]
		private Text gridValueLabel;

		// Token: 0x04008C58 RID: 35928
		[Space(10f)]
		[Header("ComUIList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx storageItemListEx;
	}
}
