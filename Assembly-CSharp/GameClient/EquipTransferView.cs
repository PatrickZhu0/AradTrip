using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B05 RID: 6917
	public class EquipTransferView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010F99 RID: 69529 RVA: 0x004DA03C File Offset: 0x004D843C
		private void Awake()
		{
			this.RegisterEventHander();
			if (this.btnItemComLink != null)
			{
				this.btnItemComLink.onClick.RemoveAllListeners();
				this.btnItemComLink.onClick.AddListener(new UnityAction(this.OnTransferItemComeLink));
			}
			if (this.btnLink != null)
			{
				this.btnLink.onClick.RemoveAllListeners();
				this.btnLink.onClick.AddListener(new UnityAction(this.OnTransferItemComeLink));
			}
			if (this.btnTransfer != null)
			{
				this.btnTransfer.onClick.RemoveAllListeners();
				this.btnTransfer.onClick.AddListener(new UnityAction(this.OnTransferClicked));
			}
			if (this.btnSelectRoot != null)
			{
				this.btnSelectRoot.onClick.RemoveAllListeners();
				this.btnSelectRoot.onClick.AddListener(new UnityAction(this.OnTransferSelectedItem));
			}
		}

		// Token: 0x06010F9A RID: 69530 RVA: 0x004DA144 File Offset: 0x004D8544
		private void OnDestroy()
		{
			this.UnRegisterEventHander();
			this.UnInitmTransferScrollViewUIList();
			this.m_kComSealEquipmentList.UnInitialize();
			if (this.m_kEquipTransferFitStoneData != null)
			{
				this.m_kEquipTransferFitStoneData.Clear();
			}
			this.m_kEquipTransferData = null;
			this.m_kComTransfer = null;
			this.m_kCostTransferItem = null;
		}

		// Token: 0x06010F9B RID: 69531 RVA: 0x004DA193 File Offset: 0x004D8593
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.InitInterface(linkData);
		}

		// Token: 0x06010F9C RID: 69532 RVA: 0x004DA19C File Offset: 0x004D859C
		public void OnEnableView()
		{
			this.RegisterEventHander();
			if (this.m_kComSealEquipmentList != null)
			{
				this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER, true);
			}
		}

		// Token: 0x06010F9D RID: 69533 RVA: 0x004DA1BC File Offset: 0x004D85BC
		public void OnDisableView()
		{
			this.UnRegisterEventHander();
		}

		// Token: 0x06010F9E RID: 69534 RVA: 0x004DA1C4 File Offset: 0x004D85C4
		private void RegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010F9F RID: 69535 RVA: 0x004DA244 File Offset: 0x004D8644
		private void UnRegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010FA0 RID: 69536 RVA: 0x004DA2C4 File Offset: 0x004D86C4
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
					if (item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip) && item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip))
					{
						this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER, true);
					}
				}
			}
		}

		// Token: 0x06010FA1 RID: 69537 RVA: 0x004DA366 File Offset: 0x004D8766
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.m_kComSealEquipmentList.Initilized)
			{
				this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER, true);
			}
		}

		// Token: 0x06010FA2 RID: 69538 RVA: 0x004DA38C File Offset: 0x004D878C
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				if (DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid) != null)
				{
					if (this.m_kComSealEquipmentList.Initilized)
					{
						this.m_kComSealEquipmentList.RefreshAllEquipments(SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER, true);
					}
				}
			}
		}

		// Token: 0x06010FA3 RID: 69539 RVA: 0x004DA3F8 File Offset: 0x004D87F8
		private void InitInterface(SmithShopNewLinkData linkData)
		{
			if (this.m_kComTransfer == null)
			{
				this.m_kComTransfer = ComItemManager.Create(this.goItemParent);
			}
			this.m_kComTransfer.Setup(null, null);
			if (this.m_kCostTransferItem == null)
			{
				this.m_kCostTransferItem = ComItemManager.Create(this.goCostItemParent);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_iCostSealID, 100, 0);
			ComItem kCostTransferItem = this.m_kCostTransferItem;
			ItemData item = itemData;
			if (EquipTransferView.<>f__mg$cache0 == null)
			{
				EquipTransferView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			kCostTransferItem.Setup(item, EquipTransferView.<>f__mg$cache0);
			this.m_kCostTransferItem.transform.SetAsFirstSibling();
			if (this.m_kTransferName != null)
			{
				this.m_kTransferName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.mGoTransferRightRoot != null)
			{
				this.mGoTransferRightRoot.CustomActive(false);
			}
			if (this.mGoTransferSelectItemRoot != null)
			{
				this.mGoTransferSelectItemRoot.CustomActive(false);
			}
			if (this.mGoTransferSelectAddRoot != null)
			{
				this.mGoTransferSelectAddRoot.CustomActive(true);
			}
			this.InitmTransferScrollViewUIList();
			this.OnAdjustTransferChanged(null);
			if (this.m_kComSealEquipmentList != null && !this.m_kComSealEquipmentList.Initilized)
			{
				this.m_kComSealEquipmentList.Initialize(this.goEquipments, new ComSealEquipmentList.OnItemSelected(this.OnAdjustTransferItemSelected), SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER, linkData);
			}
		}

		// Token: 0x06010FA4 RID: 69540 RVA: 0x004DA564 File Offset: 0x004D8964
		private void InitmTransferScrollViewUIList()
		{
			if (this.mTransferScrollView != null)
			{
				this.mTransferScrollView.Initialize();
				ComUIListScript comUIListScript = this.mTransferScrollView;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnnTransferScrollViewOnVisible));
			}
		}

		// Token: 0x06010FA5 RID: 69541 RVA: 0x004DA5B4 File Offset: 0x004D89B4
		private void UnInitmTransferScrollViewUIList()
		{
			if (this.mTransferScrollView != null)
			{
				ComUIListScript comUIListScript = this.mTransferScrollView;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnnTransferScrollViewOnVisible));
			}
		}

		// Token: 0x06010FA6 RID: 69542 RVA: 0x004DA5F0 File Offset: 0x004D89F0
		private void OnnTransferScrollViewOnVisible(ComUIListElementScript item)
		{
			if (this.m_kEquipTransferFitStoneData == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.m_kEquipTransferFitStoneData.Count)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				GameObject gameObject = component.GetGameObject("itemParent");
				Button com = component.GetCom<Button>("clickbutton");
				GameObject gameObject2 = component.GetGameObject("checkMark");
				Text com2 = component.GetCom<Text>("name");
				int index = item.m_index;
				ItemData curData = this.m_kEquipTransferFitStoneData[index];
				com2.text = curData.GetColorName(string.Empty, false);
				if (this.m_kEquipTransferData.material != null)
				{
					bool bActive = this.m_kEquipTransferData.material.TableID == curData.TableID;
					gameObject2.CustomActive(bActive);
				}
				else
				{
					gameObject2.CustomActive(false);
				}
				ComItem comItem = ComItemManager.Create(gameObject);
				comItem.Setup(curData, null);
				com.onClick.RemoveAllListeners();
				com.onClick.AddListener(delegate()
				{
					this.mGoTransferRightRoot.CustomActive(false);
					this.m_kEquipTransferData.material = curData;
					this.OnAdjustTransferChanged(this.m_kEquipTransferData);
				});
			}
		}

		// Token: 0x06010FA7 RID: 69543 RVA: 0x004DA724 File Offset: 0x004D8B24
		private void OnAdjustTransferChanged(EquipSealData transferData)
		{
			this.m_kEquipTransferData = transferData;
			if (transferData == null || transferData.item == null)
			{
				if (null != this.m_kComTransfer)
				{
					this.m_kComTransfer.Setup(null, null);
				}
				if (null != this.m_kTransferEquipName)
				{
					this.m_kTransferEquipName.text = TR.Value("ADJUS_TRANSFER_DEFAULT_NAME");
				}
				this.mGoTransferSelectAddRoot.CustomActive(true);
				this.mGoTransferSelectItemRoot.CustomActive(false);
			}
			else
			{
				if (null != this.m_kComTransfer)
				{
					ComItem kComTransfer = this.m_kComTransfer;
					ItemData item = transferData.item;
					if (EquipTransferView.<>f__mg$cache1 == null)
					{
						EquipTransferView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					kComTransfer.Setup(item, EquipTransferView.<>f__mg$cache1);
				}
				this.mGoTransferSelectAddRoot.CustomActive(null == transferData.material);
				this.mGoTransferSelectItemRoot.CustomActive(null != transferData.material);
				if (null != this.m_kTransferEquipName)
				{
					this.m_kTransferEquipName.text = transferData.item.GetColorName(string.Empty, false);
				}
			}
			if (transferData != null && transferData.material != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(transferData.material.TableID, true);
				int num = (transferData != null && transferData.material != null) ? transferData.material.Count : 1;
				if (null != this.m_kCostTransferCount)
				{
					this.m_kCostTransferCount.enabled = (transferData.material != null);
					this.m_kCostTransferCount.text = string.Format("{0}/{1}", ownedItemCount, num);
					this.m_kCostTransferCount.color = ((ownedItemCount < num) ? Color.red : Color.white);
				}
				ComItem kCostTransferItem = this.m_kCostTransferItem;
				ItemData material = transferData.material;
				if (EquipTransferView.<>f__mg$cache2 == null)
				{
					EquipTransferView.<>f__mg$cache2 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				kCostTransferItem.Setup(material, EquipTransferView.<>f__mg$cache2);
				this.m_kTransferName.text = transferData.material.GetColorName(string.Empty, false);
			}
			else
			{
				this.m_kTransferName.text = string.Empty;
				this.m_kCostTransferCount.text = string.Empty;
				this.m_kCostTransferItem.Setup(null, null);
				this.m_kTransferName.text = string.Empty;
			}
		}

		// Token: 0x06010FA8 RID: 69544 RVA: 0x004DA984 File Offset: 0x004D8D84
		private void OnAdjustTransferItemSelected(ItemData itemData)
		{
			EquipSealData equipSealData = new EquipSealData();
			equipSealData.item = itemData;
			if (this.m_kEquipTransferData != null && EquipTransferUtility.IsMatch(itemData, this.m_kEquipTransferData.material))
			{
				equipSealData.material = this.m_kEquipTransferData.material;
			}
			this.OnAdjustTransferChanged(equipSealData);
		}

		// Token: 0x06010FA9 RID: 69545 RVA: 0x004DA9D8 File Offset: 0x004D8DD8
		private void OnTransferItemComeLink()
		{
			ItemComeLink.OnLink(330000160, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010FAA RID: 69546 RVA: 0x004DA9FC File Offset: 0x004D8DFC
		private void OnTransferClicked()
		{
			if (this.m_kEquipTransferData == null || this.m_kEquipTransferData.item == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请先选择一件装备!", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_kEquipTransferData.material != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_kEquipTransferData.material.TableID, true);
				int count = this.m_kEquipTransferData.material.Count;
				if (ownedItemCount < count)
				{
					SystemNotifyManager.SysNotifyTextAnimation("数量不足!", CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				TransferConfirmFrameData userData = new TransferConfirmFrameData
				{
					data = this.m_kEquipTransferData.material,
					item = this.m_kEquipTransferData.item,
					onOk = new UnityAction<ItemData, ItemData>(this.OnEquipTransfer)
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TransferConfirmFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect("请选择转移石", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x06010FAB RID: 69547 RVA: 0x004DAAE0 File Offset: 0x004D8EE0
		private void OnEquipTransfer(ItemData data, ItemData material)
		{
			this.OnAdjustTransferChanged(null);
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(material.TableID, true, true);
			SceneEquipTransferReq cmd = new SceneEquipTransferReq
			{
				equid = data.GUID,
				transferId = itemByTableID.GUID
			};
			NetManager.Instance().SendCommand<SceneEquipTransferReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEquipTransferRes>(delegate(SceneEquipTransferRes msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<EquipTransferResultFrame>(FrameLayer.Middle, data, string.Empty);
				}
			}, true, 15f, null);
		}

		// Token: 0x06010FAC RID: 69548 RVA: 0x004DAB64 File Offset: 0x004D8F64
		private void OnTransferSelectedItem()
		{
			if (this.m_kEquipTransferData == null || this.m_kEquipTransferData.item == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请先选择一件装备!", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			this.mGoTransferRightRoot.CustomActive(true);
			this.mTransferScrollView.ResetContentPosition();
			if (this.m_kEquipTransferData == null || this.m_kEquipTransferData.item == null)
			{
				this.mTransferScrollView.SetElementAmount(0);
			}
			else
			{
				this.m_kEquipTransferFitStoneData = EquipTransferUtility.GetTransferStones(this.m_kEquipTransferData.item);
				this.mTransferScrollView.SetElementAmount(this.m_kEquipTransferFitStoneData.Count);
			}
		}

		// Token: 0x0400AE9D RID: 44701
		[SerializeField]
		private ComUIListScript mTransferScrollView;

		// Token: 0x0400AE9E RID: 44702
		[SerializeField]
		private GameObject goTransferComeItemLink;

		// Token: 0x0400AE9F RID: 44703
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400AEA0 RID: 44704
		[SerializeField]
		private GameObject goCostItemParent;

		// Token: 0x0400AEA1 RID: 44705
		[SerializeField]
		private GameObject goEquipments;

		// Token: 0x0400AEA2 RID: 44706
		[SerializeField]
		private GameObject mGoTransferRightRoot;

		// Token: 0x0400AEA3 RID: 44707
		[SerializeField]
		private GameObject mGoTransferSelectItemRoot;

		// Token: 0x0400AEA4 RID: 44708
		[SerializeField]
		private GameObject mGoTransferSelectAddRoot;

		// Token: 0x0400AEA5 RID: 44709
		[SerializeField]
		private Text m_kTransferEquipName;

		// Token: 0x0400AEA6 RID: 44710
		[SerializeField]
		private Text m_kTransferName;

		// Token: 0x0400AEA7 RID: 44711
		[SerializeField]
		private Text m_kCostTransferCount;

		// Token: 0x0400AEA8 RID: 44712
		[SerializeField]
		private Button btnItemComLink;

		// Token: 0x0400AEA9 RID: 44713
		[SerializeField]
		private Button btnTransfer;

		// Token: 0x0400AEAA RID: 44714
		[SerializeField]
		private Button btnSelectRoot;

		// Token: 0x0400AEAB RID: 44715
		[SerializeField]
		private Button btnLink;

		// Token: 0x0400AEAC RID: 44716
		[SerializeField]
		private int m_iCostSealID = 200110001;

		// Token: 0x0400AEAD RID: 44717
		private ComItem m_kComTransfer;

		// Token: 0x0400AEAE RID: 44718
		private ComItem m_kCostTransferItem;

		// Token: 0x0400AEAF RID: 44719
		private List<ItemData> m_kEquipTransferFitStoneData;

		// Token: 0x0400AEB0 RID: 44720
		private EquipSealData m_kEquipTransferData;

		// Token: 0x0400AEB1 RID: 44721
		private ComSealEquipmentList m_kComSealEquipmentList = new ComSealEquipmentList();

		// Token: 0x0400AEB2 RID: 44722
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AEB3 RID: 44723
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;

		// Token: 0x0400AEB4 RID: 44724
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache2;
	}
}
