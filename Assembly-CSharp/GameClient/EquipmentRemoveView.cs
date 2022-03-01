using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B7A RID: 7034
	internal class EquipmentRemoveView : StrengthGrowthBaseView
	{
		// Token: 0x0601140E RID: 70670 RVA: 0x004F9A5F File Offset: 0x004F7E5F
		public sealed override void IniteData(SmithShopNewLinkData linkData, StrengthenGrowthType type, StrengthenGrowthView strengthenGrowthView)
		{
			this.mStrengthenGrowthType = type;
			this.mStrengthenGrowthView = strengthenGrowthView;
			this.CreatComitem();
			if (this.mEquipStateCtrl != null)
			{
				this.mEquipStateCtrl.Key = "notHasEquip";
			}
		}

		// Token: 0x0601140F RID: 70671 RVA: 0x004F9A98 File Offset: 0x004F7E98
		private void Awake()
		{
			this.RegisterUIEventHandle();
			if (this.mClearBtn != null)
			{
				this.mClearBtn.onClick.RemoveAllListeners();
				this.mClearBtn.onClick.AddListener(new UnityAction(this.OnClearBtnClick));
			}
		}

		// Token: 0x06011410 RID: 70672 RVA: 0x004F9AE8 File Offset: 0x004F7EE8
		private void OnDestroy()
		{
			this.UnRegisterUIEventHandle();
			this.mEquipComItem = null;
			this.mExpendComItem = null;
			this.mExpendItemData = null;
			this.mSelectEquipItemData = null;
			this.mStrengthenGrowthView = null;
			this.mStrengthenGrowthType = StrengthenGrowthType.SGT_NONE;
		}

		// Token: 0x06011411 RID: 70673 RVA: 0x004F9B1C File Offset: 0x004F7F1C
		private void RegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Combine(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBreathEquipClearSuccess, new ClientEventSystem.UIEventHandler(this.OnBreathEquipClearSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x06011412 RID: 70674 RVA: 0x004F9B80 File Offset: 0x004F7F80
		private void UnRegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Remove(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBreathEquipClearSuccess, new ClientEventSystem.UIEventHandler(this.OnBreathEquipClearSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x06011413 RID: 70675 RVA: 0x004F9BE4 File Offset: 0x004F7FE4
		private void UpdateGrowthExpengItem(ItemData equipItem)
		{
			if (equipItem == null)
			{
				this.mExpendItemData = null;
			}
			else
			{
				ItemData itemData = null;
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
				this.FindBindExpendItemData(itemsByPackageType, ref itemData);
				if (itemData != null)
				{
					this.CreatExpendItemData(itemData);
				}
				else
				{
					this.FindUnBindExpendItemData(itemsByPackageType, ref itemData);
					if (itemData != null)
					{
						this.CreatExpendItemData(itemData);
					}
					else
					{
						this.mExpendItemData = null;
					}
				}
			}
			this.UpdateExpendState(this.mExpendItemData);
		}

		// Token: 0x06011414 RID: 70676 RVA: 0x004F9C5C File Offset: 0x004F805C
		private void FindBindExpendItemData(List<ulong> items, ref ItemData expendItemData)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.SubType == 104)
					{
						if (item.BindAttr > ItemTable.eOwner.NOTBIND)
						{
							item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
							if (this.timeLeft > 0 || !this.bStartCountdown)
							{
								expendItemData = item;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06011415 RID: 70677 RVA: 0x004F9CF8 File Offset: 0x004F80F8
		private void FindUnBindExpendItemData(List<ulong> items, ref ItemData expendItemData)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.SubType == 104)
					{
						if (item.BindAttr == ItemTable.eOwner.NOTBIND)
						{
							item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
							if (this.timeLeft > 0 || !this.bStartCountdown)
							{
								expendItemData = item;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06011416 RID: 70678 RVA: 0x004F9D94 File Offset: 0x004F8194
		private void CreatExpendItemData(ItemData itemData)
		{
			this.mExpendItemData = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			this.mExpendItemData.GUID = itemData.GUID;
			this.mExpendItemData.DeadTimestamp = itemData.DeadTimestamp;
			this.iExpendCount = itemData.Count;
		}

		// Token: 0x06011417 RID: 70679 RVA: 0x004F9DE3 File Offset: 0x004F81E3
		private void OnItemClick(GameObject obj, ItemData item)
		{
			this.OnOpenExpendFrameBtnClick();
		}

		// Token: 0x06011418 RID: 70680 RVA: 0x004F9DEC File Offset: 0x004F81EC
		private void OnOpenExpendFrameBtnClick()
		{
			GrowthExpendData growthExpendData = new GrowthExpendData();
			growthExpendData.mStrengthenGrowthType = this.mStrengthenGrowthType;
			growthExpendData.mEquipItemData = this.mSelectEquipItemData;
			growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.OnGrowthExpendItemClick);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GrowthExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
		}

		// Token: 0x06011419 RID: 70681 RVA: 0x004F9E3B File Offset: 0x004F823B
		private void OnGrowthExpendItemClick(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.CreatExpendItemData(itemData);
			this.UpdateExpendState(this.mExpendItemData);
		}

		// Token: 0x0601141A RID: 70682 RVA: 0x004F9E58 File Offset: 0x004F8258
		private void OnStrengthenGrowthEquipItemClick(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			this.mSelectEquipItemData = itemData;
			if (eStrengthenGrowthType == this.mStrengthenGrowthType)
			{
				this.UpdateEquipItem(itemData);
				this.UpdateGrowthExpengItem(itemData);
				if (this.mEquipStateCtrl != null)
				{
					this.mEquipStateCtrl.Key = "hasEquip";
				}
			}
		}

		// Token: 0x0601141B RID: 70683 RVA: 0x004F9EAE File Offset: 0x004F82AE
		private void OnBreathEquipClearSuccess(UIEvent uiEvent)
		{
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x0601141C RID: 70684 RVA: 0x004F9ECC File Offset: 0x004F82CC
		private void OnEquipmentListNoEquipment(UIEvent uiEvent)
		{
			this.mExpendItemData = null;
			this.mSelectEquipItemData = null;
			this.UpdateEquipItem(this.mSelectEquipItemData);
			this.UpdateExpendState(this.mExpendItemData);
			if (this.mEquipStateCtrl != null)
			{
				this.mEquipStateCtrl.Key = "notHasEquip";
			}
		}

		// Token: 0x0601141D RID: 70685 RVA: 0x004F9F20 File Offset: 0x004F8320
		private void CreatComitem()
		{
			if (this.mEquipComItem == null)
			{
				this.mEquipComItem = ComItemManager.Create(this.mItemParent);
			}
			this.mEquipComItem.Setup(null, null);
			if (this.mExpendComItem == null)
			{
				this.mExpendComItem = ComItemManager.Create(this.mExpendItemParent);
			}
			this.mExpendComItem.Setup(null, null);
		}

		// Token: 0x0601141E RID: 70686 RVA: 0x004F9F8C File Offset: 0x004F838C
		private void UpdateExpendState(ItemData itemData)
		{
			if (this.mExpendComItem != null)
			{
				this.mExpendComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClick));
			}
			string text = string.Empty;
			if (itemData == null)
			{
				if (this.mExpendStateCtl != null)
				{
					this.mExpendStateCtl.Key = "UnSelected";
				}
				if (this.mExpendCount != null)
				{
					this.mExpendCount.text = "0/1";
					this.mExpendCount.color = Color.red;
				}
			}
			else
			{
				if (this.mExpendStateCtl != null)
				{
					this.mExpendStateCtl.Key = "Selected";
				}
				text = itemData.GetColorName(string.Empty, false);
				if (this.mExpendCount != null)
				{
					this.mExpendCount.text = string.Format("{0}/1", this.iExpendCount);
					this.mExpendCount.color = Color.white;
				}
			}
			if (this.mExpendName != null)
			{
				this.mExpendName.text = text;
			}
		}

		// Token: 0x0601141F RID: 70687 RVA: 0x004FA0B1 File Offset: 0x004F84B1
		private void UpdateEquipItem(ItemData itemData)
		{
			if (this.mEquipComItem != null)
			{
				ComItem comItem = this.mEquipComItem;
				if (EquipmentRemoveView.<>f__mg$cache0 == null)
				{
					EquipmentRemoveView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(itemData, EquipmentRemoveView.<>f__mg$cache0);
			}
		}

		// Token: 0x06011420 RID: 70688 RVA: 0x004FA0F0 File Offset: 0x004F84F0
		private void OnClearBtnClick()
		{
			if (this.mSelectEquipItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择装备", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mSelectEquipItemData != null && this.mSelectEquipItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法清除", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.mExpendItemData == null)
			{
				ItemComeLink.OnLink(300000206, 0, true, null, false, false, false, null, string.Empty);
				return;
			}
			if (this.mExpendItemData != null)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.mExpendItemData.GUID);
				if (item == null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int num;
				bool flag;
				this.mExpendItemData.GetLimitTimeLeft(out num, out flag);
				if (num <= 0 && flag)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
			}
			DataManager<EquipGrowthDataManager>.GetInstance().OnSceneEquipEnhanceClear(this.mSelectEquipItemData, (uint)this.mExpendItemData.TableID);
		}

		// Token: 0x0400B248 RID: 45640
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B249 RID: 45641
		[SerializeField]
		private GameObject mExpendItemParent;

		// Token: 0x0400B24A RID: 45642
		[SerializeField]
		private Button mClearBtn;

		// Token: 0x0400B24B RID: 45643
		[SerializeField]
		private StateController mExpendStateCtl;

		// Token: 0x0400B24C RID: 45644
		[SerializeField]
		private StateController mEquipStateCtrl;

		// Token: 0x0400B24D RID: 45645
		[SerializeField]
		private Text mExpendName;

		// Token: 0x0400B24E RID: 45646
		[SerializeField]
		private Text mExpendCount;

		// Token: 0x0400B24F RID: 45647
		private StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B250 RID: 45648
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B251 RID: 45649
		private ComItem mEquipComItem;

		// Token: 0x0400B252 RID: 45650
		private ComItem mExpendComItem;

		// Token: 0x0400B253 RID: 45651
		private ItemData mExpendItemData;

		// Token: 0x0400B254 RID: 45652
		private ItemData mSelectEquipItemData;

		// Token: 0x0400B255 RID: 45653
		private int iExpendCount;

		// Token: 0x0400B256 RID: 45654
		private int timeLeft;

		// Token: 0x0400B257 RID: 45655
		private bool bStartCountdown;

		// Token: 0x0400B258 RID: 45656
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
