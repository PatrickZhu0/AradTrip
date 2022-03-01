using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B29 RID: 6953
	internal class FashionAttributesModifyFrame : ClientFrame
	{
		// Token: 0x06011132 RID: 69938 RVA: 0x004E5055 File Offset: 0x004E3455
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionAttribute";
		}

		// Token: 0x06011133 RID: 69939 RVA: 0x004E505C File Offset: 0x004E345C
		protected override void _OnOpenFrame()
		{
			this.linkGUID = (ulong)this.userData;
			this.m_kComFashionAttributeModifyEquipmentList.Initialize(this, Utility.FindChild(this.frame, "Equiptments"), new ComFashionAttributeModifyEquipmentList.OnItemSelected(this._OnItemSelected), this.linkGUID);
			this.Locked = false;
			this._RegisterUIEvent();
		}

		// Token: 0x06011134 RID: 69940 RVA: 0x004E50B8 File Offset: 0x004E34B8
		private void _RegisterUIEvent()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		}

		// Token: 0x06011135 RID: 69941 RVA: 0x004E5138 File Offset: 0x004E3538
		private void _UnRegisterUIEvent()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		}

		// Token: 0x06011136 RID: 69942 RVA: 0x004E51B7 File Offset: 0x004E35B7
		private void OnAddNewItem(List<Item> items)
		{
			this.m_kComFashionAttributeModifyEquipmentList.RefreshAllEquipments();
		}

		// Token: 0x06011137 RID: 69943 RVA: 0x004E51C4 File Offset: 0x004E35C4
		private void OnRemoveItem(ItemData data)
		{
			this.m_kComFashionAttributeModifyEquipmentList.RefreshAllEquipments();
		}

		// Token: 0x06011138 RID: 69944 RVA: 0x004E51D1 File Offset: 0x004E35D1
		private void OnUpdateItem(List<Item> items)
		{
			this.m_kComFashionAttributeModifyEquipmentList.RefreshAllEquipments();
		}

		// Token: 0x06011139 RID: 69945 RVA: 0x004E51DE File Offset: 0x004E35DE
		public static void CommandOpen(object data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionAttributesModifyFrame>(FrameLayer.Middle, 0UL, string.Empty);
		}

		// Token: 0x0601113A RID: 69946 RVA: 0x004E51F8 File Offset: 0x004E35F8
		private void _RefreshFashionAttributeItems(ItemData itemData)
		{
			EquipAttrTable lastSelectedItem = null;
			if (CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected != null && CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value != null)
			{
				lastSelectedItem = CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value.item;
			}
			this.m_akFashionAttributeItems.RecycleAllObject();
			if (itemData.fashionAttributes != null)
			{
				EquipAttrTable curFashionAttribute = itemData.CurFashionAttribute;
				for (int i = 0; i < itemData.fashionAttributes.Count; i++)
				{
					this.m_akFashionAttributeItems.Create(new object[]
					{
						this.goAttributeParent,
						this.goAttributePrefab,
						new FashionAttributeItemData
						{
							item = itemData.fashionAttributes[i],
							selected = curFashionAttribute,
							bLast = (i == itemData.fashionAttributes.Count - 1)
						},
						Delegate.CreateDelegate(typeof(CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.OnSelectedDelegate), this, "_OnFashionAttributeItemSelected")
					});
				}
			}
			FashionAttributeItem fashionAttributeItem = this.m_akFashionAttributeItems.ActiveObjects.Find((FashionAttributeItem x) => lastSelectedItem == x.Value.item && lastSelectedItem != itemData.CurFashionAttribute);
			if (fashionAttributeItem == null)
			{
				fashionAttributeItem = this.m_akFashionAttributeItems.ActiveObjects.Find((FashionAttributeItem x) => x.Value.item != itemData.CurFashionAttribute);
			}
			if (fashionAttributeItem != null)
			{
				fashionAttributeItem.OnSelected();
			}
		}

		// Token: 0x0601113B RID: 69947 RVA: 0x004E5360 File Offset: 0x004E3760
		private void _OnItemSelected(ItemData itemData)
		{
			this.goFriendlyHint.CustomActive(!this.m_kComFashionAttributeModifyEquipmentList.HasEquipments());
			if (this.comItem == null)
			{
				this.comItem = base.CreateComItem(this.goCostItemParent);
			}
			this.goRoot.CustomActive(itemData != null);
			if (itemData == null)
			{
				return;
			}
			this.comBinder.ChangeStatus((itemData.FashionFreeTimes <= 0) ? 1 : 2);
			if (itemData.HasFashionAttribute)
			{
				this.curAttribute.text = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(itemData.FashionAttributeID, "fashion_attribute_color_white", string.Empty);
			}
			this.goAttributePrefab.CustomActive(false);
			this._RefreshFashionAttributeItems(itemData);
			ItemTable costItem = DataManager<FashionAttributeSelectManager>.GetInstance().CostItem;
			if (costItem != null)
			{
				ItemData costItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(costItem.ID);
				if (costItemData != null)
				{
					this.costItemName.text = costItemData.GetColorName(string.Empty, false);
				}
				int iHasCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costItem.ID, true);
				int iCostCount = 1;
				if (iHasCount < iCostCount)
				{
					this.costItemCount.text = string.Format("<color=#FF0000FF>{0}/{1}</color>", iHasCount, iCostCount);
				}
				else
				{
					this.costItemCount.text = string.Format("<color=#00FD7DFF>{0}/{1}</color>", iHasCount, iCostCount);
				}
				this.comItem.SetShowNotEnoughState(iHasCount < iCostCount);
				this.costItemAcquired.CustomActive(iHasCount < iCostCount);
				if (null != this.comItem && costItemData != null)
				{
					this.comItem.Setup(costItemData, delegate(GameObject obj, ItemData item)
					{
						if (iHasCount < iCostCount)
						{
							ItemComeLink.OnLink(costItemData.TableID, 0, true, null, false, false, false, null, string.Empty);
						}
						else
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
						}
					});
				}
			}
		}

		// Token: 0x0601113C RID: 69948 RVA: 0x004E556C File Offset: 0x004E396C
		private void _OnFashionAttributeItemSelected(FashionAttributeItemData data)
		{
		}

		// Token: 0x0601113D RID: 69949 RVA: 0x004E556E File Offset: 0x004E396E
		[UIEventHandle("EquipAdjust/Root/BtnApplay")]
		private void _OnClickBtnApplay()
		{
			if (this.Locked)
			{
				return;
			}
			if (!this._CheckIsLegal())
			{
				return;
			}
			this._OnConfirmToSelectAttribute();
		}

		// Token: 0x0601113E RID: 69950 RVA: 0x004E5590 File Offset: 0x004E3990
		[UIEventHandle("EquipAdjust/Root/BtnApplyConfirm")]
		private void _OnClickBtnApplyConfirm()
		{
			if (this.Locked)
			{
				return;
			}
			if (!this._CheckIsLegal())
			{
				return;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(DataManager<FashionAttributeSelectManager>.GetInstance().CostItemID, true);
			if (ownedItemCount > 0)
			{
				this._OnConfirmToSelectAttribute();
				return;
			}
			WorldGetMallItemByItemIdReq worldGetMallItemByItemIdReq = new WorldGetMallItemByItemIdReq();
			worldGetMallItemByItemIdReq.itemId = (uint)DataManager<FashionAttributeSelectManager>.GetInstance().CostItemID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, worldGetMallItemByItemIdReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(delegate(WorldGetMallItemByItemIdRes msgRet)
			{
				if (msgRet.retCode != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.retCode, string.Empty);
					return;
				}
				MallItemInfo mallItem = msgRet.mallItem;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItem, string.Empty);
			}, false, 15f, null);
		}

		// Token: 0x0601113F RID: 69951 RVA: 0x004E5630 File Offset: 0x004E3A30
		private void _OnConfirmToSelectAttribute()
		{
			string attributesDesc = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value.selected.ID, "fashion_attribute_color", string.Empty);
			string attributesDesc2 = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value.item.ID, "fashion_attribute_color", string.Empty);
			SystemNotifyManager.SystemNotify(7007, delegate()
			{
				this.Locked = true;
				this._NetSyncSelectFashionAttribute(ComFashionAttributeModifyEquipment.ms_selected, CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value.item.ID);
			}, null, new object[]
			{
				attributesDesc,
				attributesDesc2
			});
		}

		// Token: 0x17001D98 RID: 7576
		// (get) Token: 0x06011140 RID: 69952 RVA: 0x004E56B4 File Offset: 0x004E3AB4
		// (set) Token: 0x06011141 RID: 69953 RVA: 0x004E56BC File Offset: 0x004E3ABC
		public bool Locked
		{
			get
			{
				return this.bLocked;
			}
			set
			{
				this.bLocked = value;
				this.goMask.CustomActive(value);
			}
		}

		// Token: 0x06011142 RID: 69954 RVA: 0x004E56D4 File Offset: 0x004E3AD4
		private bool _CheckIsLegal()
		{
			if (ComFashionAttributeModifyEquipment.ms_selected == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_not_exist"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected == null || CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value == null || CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Selected.Value.item == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_attribute_not_exist"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			return true;
		}

		// Token: 0x06011143 RID: 69955 RVA: 0x004E573D File Offset: 0x004E3B3D
		protected void _NetSyncSelectFashionAttribute(ItemData a_item, int iFashionAttributeId)
		{
			DataManager<FashionAttributeSelectManager>.GetInstance().SendFashionAttributeSelect(a_item.GUID, iFashionAttributeId);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneFashionAttributeSelectRes>(delegate(SceneFashionAttributeSelectRes msgRet)
			{
				if (msgRet.result == 0U)
				{
					this.m_kComFashionAttributeModifyEquipmentList.RefreshAllEquipments();
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashion_select_attribute_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				this.Locked = false;
			}, true, 15f, null);
		}

		// Token: 0x06011144 RID: 69956 RVA: 0x004E576E File Offset: 0x004E3B6E
		protected override void _OnCloseFrame()
		{
			this.comItem = null;
			CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>.Clear();
			this.m_akFashionAttributeItems.DestroyAllObjects();
			this.m_kComFashionAttributeModifyEquipmentList.UnInitialize();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0400AFF3 RID: 45043
		private ComFashionAttributeModifyEquipmentList m_kComFashionAttributeModifyEquipmentList = new ComFashionAttributeModifyEquipmentList();

		// Token: 0x0400AFF4 RID: 45044
		private ulong linkGUID;

		// Token: 0x0400AFF5 RID: 45045
		[UIControl("EquipAdjust/Root/Light_BG/Text", typeof(Text), 0)]
		private Text curAttribute;

		// Token: 0x0400AFF6 RID: 45046
		[UIObject("EquipAdjust/Root/middleback/Scroll View/Viewport/Content/AttrItems")]
		private GameObject goAttributeParent;

		// Token: 0x0400AFF7 RID: 45047
		[UIObject("EquipAdjust/Root/middleback/Scroll View/Viewport/Content/AttrItems/AttrItem")]
		private GameObject goAttributePrefab;

		// Token: 0x0400AFF8 RID: 45048
		private CachedObjectListManager<FashionAttributeItem> m_akFashionAttributeItems = new CachedObjectListManager<FashionAttributeItem>();

		// Token: 0x0400AFF9 RID: 45049
		[UIObject("EquipAdjust/Root")]
		private GameObject goRoot;

		// Token: 0x0400AFFA RID: 45050
		[UIControl("EquipAdjust", typeof(StatusBinder), 0)]
		private StatusBinder comBinder;

		// Token: 0x0400AFFB RID: 45051
		[UIControl("EquipAdjust/Root/CostItem/Name", typeof(Text), 0)]
		private Text costItemName;

		// Token: 0x0400AFFC RID: 45052
		[UIControl("EquipAdjust/Root/CostItem/Count", typeof(Text), 0)]
		private Text costItemCount;

		// Token: 0x0400AFFD RID: 45053
		[UIControl("EquipAdjust/Root/CostItem/Acquired", typeof(Text), 0)]
		private Text costItemAcquired;

		// Token: 0x0400AFFE RID: 45054
		[UIObject("EquipAdjust/Root/CostItem/ItemParent")]
		private GameObject goCostItemParent;

		// Token: 0x0400AFFF RID: 45055
		private ComItem comItem;

		// Token: 0x0400B000 RID: 45056
		[UIObject("EquipAdjust/Mask")]
		private GameObject goMask;

		// Token: 0x0400B001 RID: 45057
		[UIObject("Equiptments/ViewPort/AddMagicFriendlyHint")]
		private GameObject goFriendlyHint;

		// Token: 0x0400B002 RID: 45058
		private bool bLocked;
	}
}
