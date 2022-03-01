using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B80 RID: 7040
	public class MaterialSynthesisView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x0601143F RID: 70719 RVA: 0x004FAC88 File Offset: 0x004F9088
		public void InitView(SmithShopNewLinkData linkData)
		{
			if (this.mCostPrefabsList == null)
			{
				this.mCostPrefabsList = new List<GameObject>();
			}
			else
			{
				this.mCostPrefabsList.Clear();
			}
			if (this.mMaterialsSynthesisItemList == null)
			{
				this.mMaterialsSynthesisItemList = new List<MaterialsSynthesisData>();
			}
			else
			{
				this.mMaterialsSynthesisItemList.Clear();
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			List<MaterialsSynthesisData> materialsSynthesisData = DataManager<EquipGrowthDataManager>.GetInstance().GetMaterialsSynthesisData();
			this.mMaterialsSynthesisItemList.AddRange(materialsSynthesisData);
			if (this.mMaterialSynthesisUIListScript != null)
			{
				this.mMaterialSynthesisUIListScript.SetElementAmount(this.mMaterialsSynthesisItemList.Count);
			}
			this.TrySetDefaultItem();
		}

		// Token: 0x06011440 RID: 70720 RVA: 0x004FAD47 File Offset: 0x004F9147
		public void OnEnableView()
		{
			this.RegisterDelegateHandler();
		}

		// Token: 0x06011441 RID: 70721 RVA: 0x004FAD4F File Offset: 0x004F914F
		public void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06011442 RID: 70722 RVA: 0x004FAD58 File Offset: 0x004F9158
		private void Awake()
		{
			this.InitMaterialSynthesisUIListScript();
			this.RegisterUIEventHandle();
			if (this.mInputBtn != null)
			{
				this.mInputBtn.onClick.RemoveAllListeners();
				this.mInputBtn.onClick.AddListener(delegate()
				{
					CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(288f, -220f, 0f), 0UL, 99UL);
				});
			}
			if (this.mSyntheisBtn != null)
			{
				this.mSyntheisBtn.onClick.RemoveAllListeners();
				this.mSyntheisBtn.onClick.AddListener(new UnityAction(this.OnSyntheisBtnClick));
			}
		}

		// Token: 0x06011443 RID: 70723 RVA: 0x004FADFC File Offset: 0x004F91FC
		private void OnDestroy()
		{
			this.iSynthesisNumber = 1;
			if (this.mCostPrefabsList != null)
			{
				this.mCostPrefabsList.Clear();
			}
			if (this.mMaterialsSynthesisItemList != null)
			{
				this.mMaterialsSynthesisItemList.Clear();
			}
			if (this.costMaterials != null)
			{
				this.costMaterials.Clear();
			}
			this.mComItem = null;
			this.UnInitMaterialSynthesisUIListScript();
			this.UnRegisterUIEventHandle();
		}

		// Token: 0x06011444 RID: 70724 RVA: 0x004FAE68 File Offset: 0x004F9268
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
		}

		// Token: 0x06011445 RID: 70725 RVA: 0x004FAEC4 File Offset: 0x004F92C4
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
		}

		// Token: 0x06011446 RID: 70726 RVA: 0x004FAF1D File Offset: 0x004F931D
		private void RegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			this.RegisterDelegateHandler();
		}

		// Token: 0x06011447 RID: 70727 RVA: 0x004FAF40 File Offset: 0x004F9340
		private void UnRegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06011448 RID: 70728 RVA: 0x004FAF64 File Offset: 0x004F9364
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			CommonKeyBoardInputType commonKeyBoardInputType = (CommonKeyBoardInputType)uiEvent.Param1;
			ulong num = (ulong)uiEvent.Param2;
			if (commonKeyBoardInputType == CommonKeyBoardInputType.ChangeNumber)
			{
				this.iSynthesisNumber = (int)num;
				this.UpdateInputNumber(this.iSynthesisNumber);
			}
			else if (commonKeyBoardInputType == CommonKeyBoardInputType.Finished)
			{
				this.iSynthesisNumber = Mathf.Clamp(this.iSynthesisNumber, 1, this.iMaxNumber);
				this.UpdateInputNumber(this.iSynthesisNumber);
				this.UpdateCostMaterialsItem(this.mCurrentSelectMaterialsSynthesisData);
			}
		}

		// Token: 0x06011449 RID: 70729 RVA: 0x004FB000 File Offset: 0x004F9400
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.MATERIAL)
					{
						this.UpdateCostMaterialsItem(this.mCurrentSelectMaterialsSynthesisData);
						break;
					}
				}
			}
		}

		// Token: 0x0601144A RID: 70730 RVA: 0x004FB063 File Offset: 0x004F9463
		private void UpdateInputNumber(int number)
		{
			if (this.mInputNumber != null)
			{
				this.mInputNumber.text = number.ToString();
			}
		}

		// Token: 0x0601144B RID: 70731 RVA: 0x004FB090 File Offset: 0x004F9490
		private void InitMaterialSynthesisUIListScript()
		{
			if (this.mMaterialSynthesisUIListScript != null)
			{
				this.mMaterialSynthesisUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mMaterialSynthesisUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMaterialSynthesisUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mMaterialSynthesisUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mMaterialSynthesisUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangedDisplayDelegate));
			}
		}

		// Token: 0x0601144C RID: 70732 RVA: 0x004FB158 File Offset: 0x004F9558
		private void UnInitMaterialSynthesisUIListScript()
		{
			if (this.mMaterialSynthesisUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mMaterialSynthesisUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMaterialSynthesisUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mMaterialSynthesisUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mMaterialSynthesisUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangedDisplayDelegate));
			}
		}

		// Token: 0x0601144D RID: 70733 RVA: 0x004FB212 File Offset: 0x004F9612
		private MaterialSynthesisItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MaterialSynthesisItem>();
		}

		// Token: 0x0601144E RID: 70734 RVA: 0x004FB21C File Offset: 0x004F961C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			MaterialSynthesisItem materialSynthesisItem = item.gameObjectBindScript as MaterialSynthesisItem;
			if (materialSynthesisItem != null && item.m_index >= 0 && item.m_index < this.mMaterialsSynthesisItemList.Count)
			{
				materialSynthesisItem.OnItemVisiable(this.mMaterialsSynthesisItemList[item.m_index]);
			}
		}

		// Token: 0x0601144F RID: 70735 RVA: 0x004FB27C File Offset: 0x004F967C
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			MaterialSynthesisItem materialSynthesisItem = item.gameObjectBindScript as MaterialSynthesisItem;
			if (materialSynthesisItem != null)
			{
				this.mCurrentSelectMaterialsSynthesisData = materialSynthesisItem.mMaterialsSynthesisData;
				this.OnCostItemClick(this.mCurrentSelectMaterialsSynthesisData);
			}
		}

		// Token: 0x06011450 RID: 70736 RVA: 0x004FB2BC File Offset: 0x004F96BC
		private void OnItemChangedDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			MaterialSynthesisItem materialSynthesisItem = item.gameObjectBindScript as MaterialSynthesisItem;
			if (materialSynthesisItem != null)
			{
				materialSynthesisItem.OnOnItemChangeDisplayDelegate(bSelected);
			}
		}

		// Token: 0x06011451 RID: 70737 RVA: 0x004FB2E8 File Offset: 0x004F96E8
		private void OnCostItemClick(MaterialsSynthesisData data)
		{
			if (data == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(data.tableID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (this.mComItem != null)
			{
				ComItem comItem = this.mComItem;
				ItemData item = itemData;
				if (MaterialSynthesisView.<>f__mg$cache0 == null)
				{
					MaterialSynthesisView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, MaterialSynthesisView.<>f__mg$cache0);
			}
			this.mName.text = itemData.GetColorName(string.Empty, false);
			this.iSynthesisNumber = 1;
			this.UpdateInputNumber(this.iSynthesisNumber);
			this.UpdateCostMaterialsItem(data);
		}

		// Token: 0x06011452 RID: 70738 RVA: 0x004FB380 File Offset: 0x004F9780
		private void UpdateCostMaterialsItem(MaterialsSynthesisData data)
		{
			if (data == null)
			{
				return;
			}
			for (int i = 0; i < this.mCostPrefabsList.Count; i++)
			{
				this.mCostPrefabsList[i].CustomActive(false);
			}
			List<ItemSimpleData> costMaterialsList = DataManager<EquipGrowthDataManager>.GetInstance().GetCostMaterialsList(data.tableID);
			if (this.costMaterials != null)
			{
				this.costMaterials.Clear();
			}
			this.costMaterials.AddRange(costMaterialsList);
			for (int j = 0; j < this.costMaterials.Count; j++)
			{
				ItemSimpleData smipleData = this.costMaterials[j];
				if (j < this.mCostPrefabsList.Count)
				{
					GameObject gameObject = this.mCostPrefabsList[j];
					if (gameObject != null)
					{
						EquipUpgradeCostItem component = gameObject.GetComponent<EquipUpgradeCostItem>();
						if (component != null)
						{
							component.OnItemVisiable(smipleData, this.iSynthesisNumber);
						}
						gameObject.CustomActive(true);
					}
				}
				else
				{
					GameObject gameObject2 = Object.Instantiate<GameObject>(this.mCostPrefabs);
					if (gameObject2 != null)
					{
						Utility.AttachTo(gameObject2, this.mCostParent, false);
						EquipUpgradeCostItem component2 = gameObject2.GetComponent<EquipUpgradeCostItem>();
						if (component2 != null)
						{
							component2.OnItemVisiable(smipleData, this.iSynthesisNumber);
						}
						this.mCostPrefabsList.Add(gameObject2);
						gameObject2.CustomActive(true);
					}
				}
			}
			if (this.costMaterials.Count >= 3)
			{
				int num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.costMaterials[0].ItemID, true) / this.costMaterials[0].Count;
				int num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.costMaterials[1].ItemID, true) / this.costMaterials[1].Count;
				int num3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.costMaterials[2].ItemID, true) / this.costMaterials[2].Count;
				int num4 = (num >= num2) ? num2 : num;
				this.iMaxNumber = ((num4 >= num3) ? num3 : num4);
			}
			else if (this.costMaterials.Count == 2)
			{
				int num5 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.costMaterials[0].ItemID, true) / this.costMaterials[0].Count;
				int num6 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.costMaterials[1].ItemID, true) / this.costMaterials[1].Count;
				this.iMaxNumber = ((num5 >= num6) ? num6 : num5);
			}
			this.iMaxNumber = ((this.iMaxNumber != 0) ? this.iMaxNumber : 1);
		}

		// Token: 0x06011453 RID: 70739 RVA: 0x004FB654 File Offset: 0x004F9A54
		private void TrySetDefaultItem()
		{
			int selectItem = -1;
			if (this.mCurrentSelectMaterialsSynthesisData != null)
			{
				for (int i = 0; i < this.mMaterialsSynthesisItemList.Count; i++)
				{
					MaterialsSynthesisData materialsSynthesisData = this.mMaterialsSynthesisItemList[i];
					if (materialsSynthesisData.tableID == this.mCurrentSelectMaterialsSynthesisData.tableID)
					{
						selectItem = i;
						break;
					}
				}
			}
			else if (this.mMaterialsSynthesisItemList.Count > 0)
			{
				selectItem = 0;
			}
			this.SetSelectItem(selectItem);
		}

		// Token: 0x06011454 RID: 70740 RVA: 0x004FB6D8 File Offset: 0x004F9AD8
		private void SetSelectItem(int index)
		{
			if (index >= 0 && index < this.mMaterialsSynthesisItemList.Count)
			{
				if (this.mMaterialSynthesisUIListScript != null)
				{
					this.mCurrentSelectMaterialsSynthesisData = this.mMaterialsSynthesisItemList[index];
					if (!this.mMaterialSynthesisUIListScript.IsElementInScrollArea(index))
					{
						this.mMaterialSynthesisUIListScript.EnsureElementVisable(index);
					}
					this.mMaterialSynthesisUIListScript.SelectElement(index, true);
				}
			}
			else if (this.mMaterialSynthesisUIListScript != null)
			{
				this.mMaterialSynthesisUIListScript.SelectElement(-1, true);
				this.mCurrentSelectMaterialsSynthesisData = null;
			}
			this.OnCostItemClick(this.mCurrentSelectMaterialsSynthesisData);
		}

		// Token: 0x06011455 RID: 70741 RVA: 0x004FB780 File Offset: 0x004F9B80
		private void OnSyntheisBtnClick()
		{
			if (this.mCurrentSelectMaterialsSynthesisData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择要合成的材料", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.costMaterials != null)
			{
				for (int i = 0; i < this.costMaterials.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.costMaterials[i];
					int num = itemSimpleData.Count * this.iSynthesisNumber;
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemSimpleData.ItemID, true);
					if (num > ownedItemCount)
					{
						SystemNotifyManager.SysNotifyTextAnimation("材料不足", CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
			}
			DataManager<EquipGrowthDataManager>.GetInstance().OnSceneEnhanceMaterialCombo((uint)this.mCurrentSelectMaterialsSynthesisData.tableID, (uint)this.iSynthesisNumber);
		}

		// Token: 0x0400B274 RID: 45684
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B275 RID: 45685
		[SerializeField]
		private GameObject mCostPrefabs;

		// Token: 0x0400B276 RID: 45686
		[SerializeField]
		private GameObject mCostParent;

		// Token: 0x0400B277 RID: 45687
		[SerializeField]
		private Text mName;

		// Token: 0x0400B278 RID: 45688
		[SerializeField]
		private Text mInputNumber;

		// Token: 0x0400B279 RID: 45689
		[SerializeField]
		private Button mInputBtn;

		// Token: 0x0400B27A RID: 45690
		[SerializeField]
		private Button mSyntheisBtn;

		// Token: 0x0400B27B RID: 45691
		[SerializeField]
		private ComUIListScript mMaterialSynthesisUIListScript;

		// Token: 0x0400B27C RID: 45692
		[SerializeField]
		private int iMaxNumber = 99;

		// Token: 0x0400B27D RID: 45693
		private List<GameObject> mCostPrefabsList = new List<GameObject>();

		// Token: 0x0400B27E RID: 45694
		private List<MaterialsSynthesisData> mMaterialsSynthesisItemList = new List<MaterialsSynthesisData>();

		// Token: 0x0400B27F RID: 45695
		private int iSynthesisNumber = 1;

		// Token: 0x0400B280 RID: 45696
		private MaterialsSynthesisData mCurrentSelectMaterialsSynthesisData;

		// Token: 0x0400B281 RID: 45697
		private ComItem mComItem;

		// Token: 0x0400B282 RID: 45698
		private List<ItemSimpleData> costMaterials = new List<ItemSimpleData>();

		// Token: 0x0400B284 RID: 45700
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
