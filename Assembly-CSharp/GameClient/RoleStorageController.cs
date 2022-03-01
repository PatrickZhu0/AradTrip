using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001705 RID: 5893
	public class RoleStorageController : MonoBehaviour
	{
		// Token: 0x0600E773 RID: 59251 RVA: 0x003D06D2 File Offset: 0x003CEAD2
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600E774 RID: 59252 RVA: 0x003D06DA File Offset: 0x003CEADA
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600E775 RID: 59253 RVA: 0x003D06E8 File Offset: 0x003CEAE8
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
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
				this.nextPageButton.onClick.AddListener(new UnityAction(this.OnNextPageButtonClick));
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
				this.prePageButton.onClick.AddListener(new UnityAction(this.OnPrePageButtonClick));
			}
			if (this.changeNameButton != null)
			{
				this.changeNameButton.onClick.RemoveAllListeners();
				this.changeNameButton.onClick.AddListener(new UnityAction(this.OnChangeNameButtonClick));
			}
			if (this.roleStorageSelectButton != null)
			{
				this.roleStorageSelectButton.onClick.RemoveAllListeners();
				this.roleStorageSelectButton.onClick.AddListener(new UnityAction(this.OnRoleStorageSelectButtonClick));
			}
		}

		// Token: 0x0600E776 RID: 59254 RVA: 0x003D0888 File Offset: 0x003CEC88
		private void UnBindUiEvents()
		{
			if (this.arrangeButtonWithCd != null)
			{
				this.arrangeButtonWithCd.ResetButtonListener();
			}
			if (this.storageItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.storageItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.storageItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
				this.storageItemListEx.UnInitialize();
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
			}
			if (this.changeNameButton != null)
			{
				this.changeNameButton.onClick.RemoveAllListeners();
			}
			if (this.roleStorageSelectButton != null)
			{
				this.roleStorageSelectButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600E777 RID: 59255 RVA: 0x003D099F File Offset: 0x003CED9F
		private void ClearData()
		{
			this._roleStorageOwnerStorageNumber = 0;
			this._roleStorageCurrentSelectedIndex = 0;
		}

		// Token: 0x0600E778 RID: 59256 RVA: 0x003D09B0 File Offset: 0x003CEDB0
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveRoleStorageChangeNameMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveRoleStorageChangeNameMessages));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveRoleStorageUnlockMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveRoleStorageUnlockMessage));
		}

		// Token: 0x0600E779 RID: 59257 RVA: 0x003D0A2C File Offset: 0x003CEE2C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this.UpdateItemListByUiEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveRoleStorageChangeNameMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveRoleStorageChangeNameMessages));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveRoleStorageUnlockMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveRoleStorageUnlockMessage));
		}

		// Token: 0x0600E77A RID: 59258 RVA: 0x003D0AA8 File Offset: 0x003CEEA8
		public void InitView(StorageType storageType)
		{
			this._storageType = storageType;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.RoleStorage);
			ItemDataUtility.ArrangeItemGuidList(itemsByPackageType);
			this._roleStorageCurrentSelectedIndex = DataManager<StorageDataManager>.GetInstance().GetRoleStorageCurrentSelectedIndex();
			this._roleStorageOwnerStorageNumber = DataManager<StorageDataManager>.GetInstance().GetRoleStorageOwnerStorageNumber();
			this.UpdateRoleStorageContent();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E77B RID: 59259 RVA: 0x003D0AFB File Offset: 0x003CEEFB
		public void OnEnableView()
		{
			this._roleStorageCurrentSelectedIndex = DataManager<StorageDataManager>.GetInstance().GetRoleStorageCurrentSelectedIndex();
			this._roleStorageOwnerStorageNumber = DataManager<StorageDataManager>.GetInstance().GetRoleStorageOwnerStorageNumber();
			this.UpdateRoleStorageContent();
			this.UpdateRoleStorageDropDownView();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E77C RID: 59260 RVA: 0x003D0B2F File Offset: 0x003CEF2F
		private void ResetArrangeButton()
		{
			if (this.arrangeButtonWithCd != null)
			{
				this.arrangeButtonWithCd.Reset();
			}
		}

		// Token: 0x0600E77D RID: 59261 RVA: 0x003D0B50 File Offset: 0x003CEF50
		private void UpdateRoleStorageItemList()
		{
			if (this.storageItemListEx == null)
			{
				return;
			}
			this._storageItemDataModelList = StorageUtility.GetStorageItemDataModelList(this._storageType, this._roleStorageCurrentSelectedIndex);
			int elementAmount = 0;
			if (this._storageItemDataModelList != null)
			{
				elementAmount = this._storageItemDataModelList.Count;
			}
			this.storageItemListEx.SetElementAmount(elementAmount);
		}

		// Token: 0x0600E77E RID: 59262 RVA: 0x003D0BAB File Offset: 0x003CEFAB
		private void ResetRoleStorageItemList()
		{
			if (this.storageItemListEx == null)
			{
				return;
			}
			this.storageItemListEx.ResetComUiListScriptEx();
		}

		// Token: 0x0600E77F RID: 59263 RVA: 0x003D0BCC File Offset: 0x003CEFCC
		private void UpdateRoleStoragePageContent()
		{
			int num = 9;
			if (this.pageValueLabel != null)
			{
				this.pageValueLabel.text = TR.Value("Common_Two_Number_Format_One", this._roleStorageCurrentSelectedIndex, num);
			}
			if (this._roleStorageCurrentSelectedIndex <= 1)
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, true);
			}
			if (this._roleStorageCurrentSelectedIndex >= this._roleStorageOwnerStorageNumber)
			{
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, true);
			}
		}

		// Token: 0x0600E780 RID: 59264 RVA: 0x003D0C84 File Offset: 0x003CF084
		private void UpdateRoleStorageSelectStorageName()
		{
			if (this.roleStorageSelectNameLabel == null)
			{
				return;
			}
			string roleStorageNameByStorageIndex = StorageUtility.GetRoleStorageNameByStorageIndex(this._roleStorageCurrentSelectedIndex);
			this.roleStorageSelectNameLabel.text = roleStorageNameByStorageIndex;
		}

		// Token: 0x0600E781 RID: 59265 RVA: 0x003D0CBC File Offset: 0x003CF0BC
		private void UpdateRoleStorageDropDownName()
		{
			if (this.roleStorageSelectViewRoot == null)
			{
				return;
			}
			if (!this.roleStorageSelectViewRoot.gameObject.activeInHierarchy)
			{
				return;
			}
			if (this._roleStorageSelectView == null)
			{
				return;
			}
			this._roleStorageSelectView.OnUpdateRoleStorageDropDownName(this._roleStorageCurrentSelectedIndex);
		}

		// Token: 0x0600E782 RID: 59266 RVA: 0x003D0D14 File Offset: 0x003CF114
		private void UpdateRoleStorageDropDownView()
		{
			if (this.roleStorageSelectViewRoot == null)
			{
				return;
			}
			if (!this.roleStorageSelectViewRoot.gameObject.activeInHierarchy)
			{
				return;
			}
			if (this._roleStorageSelectView == null)
			{
				return;
			}
			this._roleStorageSelectView.OnUpdateRoleStorageDropDownView();
		}

		// Token: 0x0600E783 RID: 59267 RVA: 0x003D0D66 File Offset: 0x003CF166
		private void UpdateRoleStorageContent()
		{
			this.UpdateRoleStoragePageContent();
			this.UpdateRoleStorageSelectStorageName();
			this.ResetRoleStorageItemList();
			this.UpdateRoleStorageItemList();
		}

		// Token: 0x0600E784 RID: 59268 RVA: 0x003D0D80 File Offset: 0x003CF180
		private void OnNextPageButtonClick()
		{
			if (this._roleStorageCurrentSelectedIndex <= 0)
			{
				this._roleStorageCurrentSelectedIndex = 1;
			}
			else if (this._roleStorageCurrentSelectedIndex < this._roleStorageOwnerStorageNumber)
			{
				this._roleStorageCurrentSelectedIndex++;
			}
			else
			{
				this._roleStorageCurrentSelectedIndex = this._roleStorageOwnerStorageNumber;
			}
			DataManager<StorageDataManager>.GetInstance().SetRoleStorageCurrentSelectedIndex(this._roleStorageCurrentSelectedIndex);
			this.UpdateRoleStorageContent();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E785 RID: 59269 RVA: 0x003D0DF4 File Offset: 0x003CF1F4
		private void OnPrePageButtonClick()
		{
			if (this._roleStorageCurrentSelectedIndex > this._roleStorageOwnerStorageNumber)
			{
				this._roleStorageCurrentSelectedIndex = this._roleStorageOwnerStorageNumber;
			}
			else if (this._roleStorageCurrentSelectedIndex <= 1)
			{
				this._roleStorageCurrentSelectedIndex = 1;
			}
			else
			{
				this._roleStorageCurrentSelectedIndex--;
			}
			DataManager<StorageDataManager>.GetInstance().SetRoleStorageCurrentSelectedIndex(this._roleStorageCurrentSelectedIndex);
			this.UpdateRoleStorageContent();
			this.ResetArrangeButton();
		}

		// Token: 0x0600E786 RID: 59270 RVA: 0x003D0E68 File Offset: 0x003CF268
		private void OnChangeNameButtonClick()
		{
			string roleStorageNameByStorageIndex = StorageUtility.GetRoleStorageNameByStorageIndex(this._roleStorageCurrentSelectedIndex);
			string titleStr = TR.Value("storage_change_name_Title");
			CommonSetContentDataModel setContentDataModel = new CommonSetContentDataModel
			{
				TitleStr = titleStr,
				DefaultEmptyStr = TR.Value("storage_change_name_default_content"),
				DefaultContentStr = roleStorageNameByStorageIndex,
				MaxWordNumber = 5,
				OnOkClicked = new UnityAction<string>(this.OnChangeStorageNameAction)
			};
			CommonUtility.OnOpenCommonSetContentFrame(setContentDataModel);
		}

		// Token: 0x0600E787 RID: 59271 RVA: 0x003D0ED4 File Offset: 0x003CF2D4
		private void OnChangeStorageNameAction(string setContentStr)
		{
			string roleStorageNameByStorageIndex = StorageUtility.GetRoleStorageNameByStorageIndex(this._roleStorageCurrentSelectedIndex);
			if (string.Equals(setContentStr, roleStorageNameByStorageIndex))
			{
				CommonUtility.OnCloseCommonSetContentFrame();
				return;
			}
			DataManager<SceneSettingDataManager>.GetInstance().OnSendSceneShortcutKeySetReq(this._roleStorageCurrentSelectedIndex, setContentStr);
		}

		// Token: 0x0600E788 RID: 59272 RVA: 0x003D0F10 File Offset: 0x003CF310
		protected void OnArrangeButtonClick()
		{
			int roleStorageItemGridMinGridIndex = StorageUtility.GetRoleStorageItemGridMinGridIndex(this._roleStorageCurrentSelectedIndex);
			int roleStorageItemGridMaxGridIndex = StorageUtility.GetRoleStorageItemGridMaxGridIndex(this._roleStorageCurrentSelectedIndex);
			StorageUtility.ResortRoleStorageItemGuidByGridIndex(roleStorageItemGridMinGridIndex, roleStorageItemGridMaxGridIndex);
			this.UpdateRoleStorageItemList();
		}

		// Token: 0x0600E789 RID: 59273 RVA: 0x003D0F44 File Offset: 0x003CF344
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

		// Token: 0x0600E78A RID: 59274 RVA: 0x003D0F78 File Offset: 0x003CF378
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

		// Token: 0x0600E78B RID: 59275 RVA: 0x003D1018 File Offset: 0x003CF418
		private void OnRoleStorageSelectButtonClick()
		{
			if (this.roleStorageSelectViewRoot == null)
			{
				return;
			}
			if (this.roleStorageSelectViewRoot.gameObject.activeInHierarchy)
			{
				CommonUtility.UpdateGameObjectVisible(this.roleStorageSelectViewRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.roleStorageSelectViewRoot, true);
				if (this._roleStorageSelectView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.roleStorageSelectViewRoot);
					if (gameObject != null)
					{
						this._roleStorageSelectView = gameObject.GetComponent<RoleStorageSelectView>();
					}
					if (this._roleStorageSelectView != null)
					{
						this._roleStorageSelectView.InitRoleStorageDropDownView(new OnRoleStorageSelectItemClick(this.OnRoleStorageSelectItemClickAction));
					}
				}
				else
				{
					this._roleStorageSelectView.OnUpdateRoleStorageDropDownView();
				}
			}
		}

		// Token: 0x0600E78C RID: 59276 RVA: 0x003D10D6 File Offset: 0x003CF4D6
		private void OnRoleStorageSelectItemClickAction(int index)
		{
			if (this._roleStorageCurrentSelectedIndex == index)
			{
				return;
			}
			this._roleStorageCurrentSelectedIndex = index;
			DataManager<StorageDataManager>.GetInstance().SetRoleStorageCurrentSelectedIndex(this._roleStorageCurrentSelectedIndex);
			this.UpdateRoleStorageContent();
			CommonUtility.UpdateGameObjectVisible(this.roleStorageSelectViewRoot, false);
			this.ResetArrangeButton();
		}

		// Token: 0x0600E78D RID: 59277 RVA: 0x003D1114 File Offset: 0x003CF514
		private void UpdateItemListByUiEvent(UIEvent uiEvent)
		{
			this.UpdateRoleStorageItemList();
		}

		// Token: 0x0600E78E RID: 59278 RVA: 0x003D111C File Offset: 0x003CF51C
		private void OnReceiveRoleStorageChangeNameMessages(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._roleStorageCurrentSelectedIndex != num)
			{
				return;
			}
			this.UpdateRoleStorageSelectStorageName();
			this.UpdateRoleStorageDropDownName();
		}

		// Token: 0x0600E78F RID: 59279 RVA: 0x003D1160 File Offset: 0x003CF560
		private void OnReceiveRoleStorageUnlockMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			this._roleStorageOwnerStorageNumber = (int)uiEvent.Param1;
			this._roleStorageCurrentSelectedIndex = (int)uiEvent.Param2;
			DataManager<StorageDataManager>.GetInstance().SetRoleStorageCurrentSelectedIndex(this._roleStorageCurrentSelectedIndex);
			this.UpdateRoleStorageContent();
			this.UpdateRoleStorageDropDownView();
		}

		// Token: 0x04008C64 RID: 35940
		private StorageType _storageType;

		// Token: 0x04008C65 RID: 35941
		private List<StorageItemDataModel> _storageItemDataModelList;

		// Token: 0x04008C66 RID: 35942
		private int _roleStorageCurrentSelectedIndex = 1;

		// Token: 0x04008C67 RID: 35943
		private int _roleStorageOwnerStorageNumber = 1;

		// Token: 0x04008C68 RID: 35944
		private RoleStorageSelectView _roleStorageSelectView;

		// Token: 0x04008C69 RID: 35945
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd arrangeButtonWithCd;

		// Token: 0x04008C6A RID: 35946
		[SerializeField]
		private Button changeNameButton;

		// Token: 0x04008C6B RID: 35947
		[Space(10f)]
		[Header("Page")]
		[Space(10f)]
		[SerializeField]
		private Button nextPageButton;

		// Token: 0x04008C6C RID: 35948
		[SerializeField]
		private UIGray nextPageGray;

		// Token: 0x04008C6D RID: 35949
		[SerializeField]
		private Button prePageButton;

		// Token: 0x04008C6E RID: 35950
		[SerializeField]
		private UIGray prePageGray;

		// Token: 0x04008C6F RID: 35951
		[SerializeField]
		private Text pageValueLabel;

		// Token: 0x04008C70 RID: 35952
		[Space(10f)]
		[Header("RoleStorageSelect")]
		[Space(10f)]
		[SerializeField]
		private Text roleStorageSelectNameLabel;

		// Token: 0x04008C71 RID: 35953
		[SerializeField]
		private Button roleStorageSelectButton;

		// Token: 0x04008C72 RID: 35954
		[SerializeField]
		private GameObject roleStorageSelectViewRoot;

		// Token: 0x04008C73 RID: 35955
		[Space(10f)]
		[Header("storageItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx storageItemListEx;
	}
}
