using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B02 RID: 6914
	public class EquipAdjustView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010F71 RID: 69489 RVA: 0x004D8FC4 File Offset: 0x004D73C4
		private void Awake()
		{
			this.RegisterEventHander();
			if (this.m_kPerfectScrollsBtn != null)
			{
				this.m_kPerfectScrollsBtn.onClick.RemoveAllListeners();
				this.m_kPerfectScrollsBtn.onClick.AddListener(new UnityAction(this.OnDetermineWashsPracticeClick));
			}
			if (this.m_kItemComLinkBtn != null)
			{
				this.m_kItemComLinkBtn.onClick.RemoveAllListeners();
				this.m_kItemComLinkBtn.onClick.AddListener(new UnityAction(this.OnAdjustItemComeLink));
			}
			if (this.m_kBaptizeVolumeItemComeLinkBtn != null)
			{
				this.m_kBaptizeVolumeItemComeLinkBtn.onClick.RemoveAllListeners();
				this.m_kBaptizeVolumeItemComeLinkBtn.onClick.AddListener(new UnityAction(this.OnBaptizeVolumeItemComeLink));
			}
		}

		// Token: 0x06010F72 RID: 69490 RVA: 0x004D908E File Offset: 0x004D748E
		private void OnDestroy()
		{
			this.UnRegisterEventHander();
			this.m_kComAdjust = null;
			this.m_kCostAdjustItem = null;
			this.m_kPerfectScrollsComItem = null;
			this.mCurrentBaptizeItem = null;
			this.m_kComSealEquipmentList.UnInitialize();
			DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab = false;
		}

		// Token: 0x06010F73 RID: 69491 RVA: 0x004D90C8 File Offset: 0x004D74C8
		private void OnDetermineWashsPracticeClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PerfectWashRollConfirm>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010F74 RID: 69492 RVA: 0x004D90DC File Offset: 0x004D74DC
		private void OnAdjustItemComeLink()
		{
			ItemComeLink.OnLink(this.m_iCostAdjustID, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010F75 RID: 69493 RVA: 0x004D9100 File Offset: 0x004D7500
		private void OnBaptizeVolumeItemComeLink()
		{
			ItemComeLink.OnLink(this.m_perfectScrollsID, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010F76 RID: 69494 RVA: 0x004D9124 File Offset: 0x004D7524
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.InitInterface(linkData);
		}

		// Token: 0x06010F77 RID: 69495 RVA: 0x004D912D File Offset: 0x004D752D
		public void OnEnableView()
		{
			if (this.comFunctionAdjust != null)
			{
				this.comFunctionAdjust.RegisterDelegateHandler();
			}
			this.RegisterDelegateHandler();
			this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_ADJUST, true);
			this.comFunctionAdjust.StopEffect();
		}

		// Token: 0x06010F78 RID: 69496 RVA: 0x004D9169 File Offset: 0x004D7569
		public void OnDisableView()
		{
			if (this.comFunctionAdjust != null)
			{
				this.comFunctionAdjust.UnRegisterDelegateHandler();
			}
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06010F79 RID: 69497 RVA: 0x004D9190 File Offset: 0x004D7590
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010F7A RID: 69498 RVA: 0x004D9210 File Offset: 0x004D7610
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010F7B RID: 69499 RVA: 0x004D928F File Offset: 0x004D768F
		private void RegisterEventHander()
		{
			this.RegisterDelegateHandler();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ContinueProcessFinish, new ClientEventSystem.UIEventHandler(this.OnAdjustQualityCrazyFinish));
		}

		// Token: 0x06010F7C RID: 69500 RVA: 0x004D92B2 File Offset: 0x004D76B2
		private void UnRegisterEventHander()
		{
			this.UnRegisterDelegateHandler();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ContinueProcessFinish, new ClientEventSystem.UIEventHandler(this.OnAdjustQualityCrazyFinish));
		}

		// Token: 0x06010F7D RID: 69501 RVA: 0x004D92D5 File Offset: 0x004D76D5
		private void OnAdjustQualityCrazyFinish(UIEvent uiEvent)
		{
			if (this.m_kComSealEquipmentList != null)
			{
				this.OnAdjustQualityChanged(this.m_kComSealEquipmentList.Selected);
			}
		}

		// Token: 0x06010F7E RID: 69502 RVA: 0x004D92F4 File Offset: 0x004D76F4
		private void OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip))
					{
						this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_ADJUST, true);
					}
					this.OnAdjustQualityChanged(this.m_kComAdjust.ItemData);
				}
			}
		}

		// Token: 0x06010F7F RID: 69503 RVA: 0x004D9384 File Offset: 0x004D7784
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.m_kComSealEquipmentList.Initilized)
			{
				this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_ADJUST, true);
			}
			if (this.m_iCostAdjustID == itemData.TableID || this.m_perfectScrollsID == itemData.TableID)
			{
				this.OnAdjustQualityChanged(this.m_kComAdjust.ItemData);
			}
		}

		// Token: 0x06010F80 RID: 69504 RVA: 0x004D93E8 File Offset: 0x004D77E8
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (this.mCurrentBaptizeItem != null && this.mCurrentBaptizeItem.GUID == item.GUID)
					{
						this.OnAdjustItemSelected(item);
					}
					if (this.m_kComAdjust != null && this.m_kComAdjust.ItemData != null && this.m_kComAdjust.ItemData.GUID == item.GUID)
					{
						this.OnAdjustQualityChanged(item);
					}
					if ((this.m_iCostAdjustID == item.TableID && this.m_kComAdjust != null) || this.m_perfectScrollsID == item.TableID)
					{
						this.OnAdjustQualityChanged(this.m_kComAdjust.ItemData);
					}
				}
			}
		}

		// Token: 0x06010F81 RID: 69505 RVA: 0x004D94E4 File Offset: 0x004D78E4
		private void InitInterface(SmithShopNewLinkData linkData)
		{
			if (this.m_kComAdjust == null)
			{
				this.m_kComAdjust = ComItemManager.Create(this.goItemParent);
			}
			this.m_kComAdjust.Setup(null, null);
			if (this.m_kCostAdjustItem == null)
			{
				this.m_kCostAdjustItem = ComItemManager.Create(this.goCostItemParent);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_iCostAdjustID, 100, 0);
			if (itemData != null)
			{
				ComItem kCostAdjustItem = this.m_kCostAdjustItem;
				ItemData item = itemData;
				if (EquipAdjustView.<>f__mg$cache0 == null)
				{
					EquipAdjustView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				kCostAdjustItem.Setup(item, EquipAdjustView.<>f__mg$cache0);
				if (this.m_kCostAdjustItemName != null)
				{
					this.m_kCostAdjustItemName.text = itemData.GetColorName(string.Empty, false);
				}
			}
			this.m_kCostAdjustItem.transform.SetAsFirstSibling();
			if (this.comFunctionAdjust != null)
			{
				this.comFunctionAdjust.Initialize();
			}
			if (this.m_kPerfectScrollsComItem == null)
			{
				this.m_kPerfectScrollsComItem = ComItemManager.Create(this.goBaptizeVolumeItemParent);
			}
			ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(this.m_perfectScrollsID, 100, 0);
			if (itemData2 != null)
			{
				ComItem kPerfectScrollsComItem = this.m_kPerfectScrollsComItem;
				ItemData item2 = itemData2;
				if (EquipAdjustView.<>f__mg$cache1 == null)
				{
					EquipAdjustView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				kPerfectScrollsComItem.Setup(item2, EquipAdjustView.<>f__mg$cache1);
				if (this.m_kPerfectScrollsItemName != null)
				{
					this.m_kPerfectScrollsItemName.text = itemData2.GetColorName(string.Empty, false);
				}
			}
			this.m_kPerfectScrollsComItem.transform.SetAsFirstSibling();
			bool flag = DataManager<ItemDataManager>.GetInstance().GetItemCountBySubType(EPackageType.Material, ItemTable.eSubType.Perfect_washing) > 0;
			if (this.adjustComBid != null && this.equipAdjustComBid != null)
			{
				GameObject mBtnAdjustCrazy = this.equipAdjustComBid.GetGameObject("btnAdjustCrazy");
				GameObject mBtnAdjustOnce = this.equipAdjustComBid.GetGameObject("btnAdjustOnce");
				GameObject mToggleRoot = this.equipAdjustComBid.GetGameObject("toggleRoot");
				GameObject mMagicItem = this.equipAdjustComBid.GetGameObject("magicItem");
				GameObject mCostParent = this.equipAdjustComBid.GetGameObject("costParent");
				GameObject mBaptizeNolumeRoot = this.equipAdjustComBid.GetGameObject("baptizeNolumeRoot");
				Toggle com = this.adjustComBid.GetCom<Toggle>("useMaterial");
				com.onValueChanged.RemoveAllListeners();
				com.onValueChanged.AddListener(delegate(bool isOn)
				{
					mBtnAdjustCrazy.CustomActive(true);
					mBtnAdjustOnce.CustomActive(true);
					mToggleRoot.CustomActive(true);
					mMagicItem.CustomActive(true);
					mCostParent.CustomActive(true);
					mBaptizeNolumeRoot.CustomActive(false);
				});
				Toggle com2 = this.adjustComBid.GetCom<Toggle>("PerfectPractice");
				com2.onValueChanged.RemoveAllListeners();
				com2.onValueChanged.AddListener(delegate(bool isOn)
				{
					mBtnAdjustCrazy.CustomActive(false);
					mBtnAdjustOnce.CustomActive(false);
					mToggleRoot.CustomActive(false);
					mMagicItem.CustomActive(false);
					mCostParent.CustomActive(false);
					mBaptizeNolumeRoot.CustomActive(true);
				});
				if (DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab)
				{
					com2.isOn = true;
				}
				else
				{
					com.isOn = true;
				}
			}
			if (flag)
			{
				this.goEquipmentsTransfom.offsetMax = new Vector2(this.goEquipmentsTransfom.offsetMax.x, -224f);
			}
			else
			{
				this.goEquipmentsTransfom.offsetMax = new Vector2(this.goEquipmentsTransfom.offsetMax.x, -115f);
			}
			if (this.m_kComSealEquipmentList != null && !this.m_kComSealEquipmentList.Initilized)
			{
				this.m_kComSealEquipmentList.Initialize(this.goAdjustFunctionCommonEquipment, new ComSealEquipmentList.OnItemSelected(this.OnAdjustItemSelected), SmithShopNewTabType.SSNTT_ADJUST, linkData);
			}
		}

		// Token: 0x06010F82 RID: 69506 RVA: 0x004D9850 File Offset: 0x004D7C50
		private void OnAdjustQualityChanged(ItemData itemData)
		{
			ComItem kComAdjust = this.m_kComAdjust;
			if (EquipAdjustView.<>f__mg$cache2 == null)
			{
				EquipAdjustView.<>f__mg$cache2 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			kComAdjust.Setup(itemData, EquipAdjustView.<>f__mg$cache2);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_iCostAdjustID, true);
			int num = 1;
			this.m_kCostAdjustCount.enabled = (itemData != null);
			this.m_kCostAdjustCount.text = string.Format("{0}/{1}", ownedItemCount, num);
			this.m_kCostAdjustCount.color = ((ownedItemCount >= num) ? Color.white : Color.red);
			this.goAdjustComeLink.CustomActive(ownedItemCount < num);
			this.m_kCostAdjustItem.SetShowNotEnoughState(ownedItemCount < num);
			int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_perfectScrollsID, true);
			this.m_kPerfectScrollsCount.enabled = (itemData != null);
			this.m_kPerfectScrollsCount.text = string.Format("{0}/{1}", ownedItemCount2, num);
			this.m_kPerfectScrollsCount.color = ((ownedItemCount2 >= num) ? Color.white : Color.red);
			this.m_kPerfectScrollsComItem.SetShowNotEnoughState(ownedItemCount2 < num);
			if (itemData != null)
			{
				this.m_kPerfectScrollsBtnGray.enabled = (ownedItemCount2 <= 0 || itemData.SubQuality >= 100);
				this.m_kPerfectScrollsBtn.enabled = (ownedItemCount2 > 0 && itemData.SubQuality < 100);
				if (itemData.SubQuality >= 100)
				{
					this.m_kPerfectRollText.text = TR.Value("perfectbaptize_dono");
				}
				else
				{
					this.m_kPerfectRollText.text = TR.Value("perfectbaptize_sure");
				}
			}
			this.m_kPerfectScrollsDes.text = TR.Value("ItemKeyPerfectScrollsDes");
			string text = string.Empty;
			if (itemData != null)
			{
				int subQuality = itemData.SubQuality;
				if (subQuality <= 20)
				{
					text = TR.Value("tip_grade_lower_most", subQuality);
				}
				else if (subQuality <= 40)
				{
					text = TR.Value("tip_grade_lower", subQuality);
				}
				else if (subQuality <= 60)
				{
					text = TR.Value("tip_grade_middle", subQuality);
				}
				else if (subQuality <= 80)
				{
					text = TR.Value("tip_grade_high", subQuality);
				}
				else if (subQuality < 100)
				{
					text = TR.Value("tip_grade_high_most", subQuality);
				}
				else
				{
					text = TR.Value("tip_grade_perfect", subQuality);
				}
			}
			else
			{
				text = TR.Value("tip_grade_high_most", 100);
			}
			this.m_kQualityLevel.text = text;
		}

		// Token: 0x06010F83 RID: 69507 RVA: 0x004D9B02 File Offset: 0x004D7F02
		private void OnAdjustItemSelected(ItemData itemData)
		{
			this.mCurrentBaptizeItem = itemData;
			this.OnAdjustQualityChanged(itemData);
			if (this.comFunctionAdjust != null)
			{
				this.comFunctionAdjust.SetUIData(itemData);
			}
		}

		// Token: 0x0400AE7A RID: 44666
		[SerializeField]
		private ComFunctionAdjust comFunctionAdjust;

		// Token: 0x0400AE7B RID: 44667
		[SerializeField]
		private GameObject goAdjustComeLink;

		// Token: 0x0400AE7C RID: 44668
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400AE7D RID: 44669
		[SerializeField]
		private GameObject goCostItemParent;

		// Token: 0x0400AE7E RID: 44670
		[SerializeField]
		private GameObject goBaptizeVolumeItemParent;

		// Token: 0x0400AE7F RID: 44671
		[SerializeField]
		private GameObject goAdjustFunctionCommonEquipment;

		// Token: 0x0400AE80 RID: 44672
		[SerializeField]
		private RectTransform goEquipmentsTransfom;

		// Token: 0x0400AE81 RID: 44673
		[SerializeField]
		private ComCommonBind adjustComBid;

		// Token: 0x0400AE82 RID: 44674
		[SerializeField]
		private ComCommonBind equipAdjustComBid;

		// Token: 0x0400AE83 RID: 44675
		[SerializeField]
		private Text m_kQualityLevel;

		// Token: 0x0400AE84 RID: 44676
		[SerializeField]
		private Text m_kCostAdjustCount;

		// Token: 0x0400AE85 RID: 44677
		[SerializeField]
		private Text m_kCostAdjustItemName;

		// Token: 0x0400AE86 RID: 44678
		[SerializeField]
		private Text m_kPerfectScrollsCount;

		// Token: 0x0400AE87 RID: 44679
		[SerializeField]
		private Text m_kPerfectScrollsDes;

		// Token: 0x0400AE88 RID: 44680
		[SerializeField]
		private Text m_kPerfectScrollsItemName;

		// Token: 0x0400AE89 RID: 44681
		[SerializeField]
		private Text m_kPerfectRollText;

		// Token: 0x0400AE8A RID: 44682
		[SerializeField]
		private UIGray m_kPerfectScrollsBtnGray;

		// Token: 0x0400AE8B RID: 44683
		[SerializeField]
		private Button m_kPerfectScrollsBtn;

		// Token: 0x0400AE8C RID: 44684
		[SerializeField]
		private Button m_kItemComLinkBtn;

		// Token: 0x0400AE8D RID: 44685
		[SerializeField]
		private Button m_kBaptizeVolumeItemComeLinkBtn;

		// Token: 0x0400AE8E RID: 44686
		[SerializeField]
		private int m_iCostAdjustID = 200110002;

		// Token: 0x0400AE8F RID: 44687
		[SerializeField]
		private int m_perfectScrollsID = 200000329;

		// Token: 0x0400AE90 RID: 44688
		private ComItem m_kComAdjust;

		// Token: 0x0400AE91 RID: 44689
		private ComItem m_kCostAdjustItem;

		// Token: 0x0400AE92 RID: 44690
		private ComItem m_kPerfectScrollsComItem;

		// Token: 0x0400AE93 RID: 44691
		private ComSealEquipmentList m_kComSealEquipmentList = new ComSealEquipmentList();

		// Token: 0x0400AE94 RID: 44692
		private ItemData mCurrentBaptizeItem;

		// Token: 0x0400AE95 RID: 44693
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AE96 RID: 44694
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;

		// Token: 0x0400AE97 RID: 44695
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache2;
	}
}
