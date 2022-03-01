using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B76 RID: 7030
	internal class EquipmentActivationView : StrengthGrowthBaseView
	{
		// Token: 0x060113D7 RID: 70615 RVA: 0x004F78CE File Offset: 0x004F5CCE
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

		// Token: 0x060113D8 RID: 70616 RVA: 0x004F7908 File Offset: 0x004F5D08
		private void Awake()
		{
			this.RegisterUIEventHandle();
			if (this.mActivationBtn != null)
			{
				this.mActivationBtn.onClick.RemoveAllListeners();
				this.mActivationBtn.onClick.AddListener(new UnityAction(this.OnActivationClick));
			}
		}

		// Token: 0x060113D9 RID: 70617 RVA: 0x004F7958 File Offset: 0x004F5D58
		private void OnDestroy()
		{
			this.UnRegisterUIEventHandle();
			this.mEquipComItem = null;
			this.mExpendComItem = null;
			this.mExpendItemData = null;
			this.mSelectEquipItemData = null;
			this.mAttrValue = 0;
		}

		// Token: 0x060113DA RID: 70618 RVA: 0x004F7984 File Offset: 0x004F5D84
		private void RegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Combine(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBreathEquipActivationSuccess, new ClientEventSystem.UIEventHandler(this.OnBreathEquipActivationSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x060113DB RID: 70619 RVA: 0x004F79E8 File Offset: 0x004F5DE8
		private void UnRegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Remove(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBreathEquipActivationSuccess, new ClientEventSystem.UIEventHandler(this.OnBreathEquipActivationSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x060113DC RID: 70620 RVA: 0x004F7A4C File Offset: 0x004F5E4C
		private void OnStrengthenGrowthEquipItemClick(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			this.mSelectEquipItemData = itemData;
			if (eStrengthenGrowthType == this.mStrengthenGrowthType)
			{
				this.mExpendItemData = null;
				this.mAttrValue = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(itemData, 0);
				this.UpdateEquipItem(itemData);
				this.UpdateGrowthExpengItem(itemData);
				this.UpdateAttrDesc();
				if (this.mEquipStateCtrl != null)
				{
					this.mEquipStateCtrl.Key = "hasEquip";
				}
			}
		}

		// Token: 0x060113DD RID: 70621 RVA: 0x004F7AC4 File Offset: 0x004F5EC4
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

		// Token: 0x060113DE RID: 70622 RVA: 0x004F7B3C File Offset: 0x004F5F3C
		private void FindBindExpendItemData(List<ulong> items, ref ItemData expendItemData)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.SubType == 103)
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

		// Token: 0x060113DF RID: 70623 RVA: 0x004F7BD8 File Offset: 0x004F5FD8
		private void FindUnBindExpendItemData(List<ulong> items, ref ItemData expendItemData)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.SubType == 103)
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

		// Token: 0x060113E0 RID: 70624 RVA: 0x004F7C74 File Offset: 0x004F6074
		private void CreatExpendItemData(ItemData itemData)
		{
			this.mExpendItemData = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			this.mExpendItemData.GUID = itemData.GUID;
			this.mExpendItemData.DeadTimestamp = itemData.DeadTimestamp;
			this.iExpendCount = itemData.Count;
		}

		// Token: 0x060113E1 RID: 70625 RVA: 0x004F7CC4 File Offset: 0x004F60C4
		private void UpdateAttrDesc()
		{
			if (this.mAttrTexts.Count == this.mAttrDescs.Count)
			{
				for (int i = 0; i < this.mAttrTexts.Count; i++)
				{
					this.mAttrTexts[i].text = string.Format(this.mAttrDescs[i], this.mAttrValue);
				}
			}
		}

		// Token: 0x060113E2 RID: 70626 RVA: 0x004F7D35 File Offset: 0x004F6135
		private void OnItemClick(GameObject obj, ItemData item)
		{
			this.OnOpenExpendFrameBtnClick();
		}

		// Token: 0x060113E3 RID: 70627 RVA: 0x004F7D40 File Offset: 0x004F6140
		private void OnOpenExpendFrameBtnClick()
		{
			GrowthExpendData growthExpendData = new GrowthExpendData();
			growthExpendData.mStrengthenGrowthType = this.mStrengthenGrowthType;
			growthExpendData.mEquipItemData = this.mSelectEquipItemData;
			growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.OnGrowthExpendItemClick);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GrowthExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
		}

		// Token: 0x060113E4 RID: 70628 RVA: 0x004F7D8F File Offset: 0x004F618F
		private void OnGrowthExpendItemClick(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.CreatExpendItemData(itemData);
			this.UpdateExpendState(this.mExpendItemData);
		}

		// Token: 0x060113E5 RID: 70629 RVA: 0x004F7DAC File Offset: 0x004F61AC
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

		// Token: 0x060113E6 RID: 70630 RVA: 0x004F7E18 File Offset: 0x004F6218
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

		// Token: 0x060113E7 RID: 70631 RVA: 0x004F7F3D File Offset: 0x004F633D
		private void UpdateEquipItem(ItemData itemData)
		{
			if (this.mEquipComItem != null)
			{
				ComItem comItem = this.mEquipComItem;
				if (EquipmentActivationView.<>f__mg$cache0 == null)
				{
					EquipmentActivationView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(itemData, EquipmentActivationView.<>f__mg$cache0);
			}
		}

		// Token: 0x060113E8 RID: 70632 RVA: 0x004F7F79 File Offset: 0x004F6379
		private void OnBreathEquipActivationSuccess(UIEvent uiEvent)
		{
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x060113E9 RID: 70633 RVA: 0x004F7F98 File Offset: 0x004F6398
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

		// Token: 0x060113EA RID: 70634 RVA: 0x004F7FEC File Offset: 0x004F63EC
		private void OnActivationClick()
		{
			if (this.mSelectEquipItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择装备", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mSelectEquipItemData != null && this.mSelectEquipItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法激活", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.mExpendItemData == null)
			{
				ItemComeLink.OnLink(300000205, 0, true, null, false, false, false, null, string.Empty);
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
			DataManager<EquipGrowthDataManager>.GetInstance().OnSceneEquipEnhanceRed(this.mSelectEquipItemData, (uint)this.mExpendItemData.TableID);
		}

		// Token: 0x0400B212 RID: 45586
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B213 RID: 45587
		[SerializeField]
		private GameObject mExpendItemParent;

		// Token: 0x0400B214 RID: 45588
		[SerializeField]
		private Button mActivationBtn;

		// Token: 0x0400B215 RID: 45589
		[SerializeField]
		private StateController mExpendStateCtl;

		// Token: 0x0400B216 RID: 45590
		[SerializeField]
		private StateController mEquipStateCtrl;

		// Token: 0x0400B217 RID: 45591
		[SerializeField]
		private Text mExpendName;

		// Token: 0x0400B218 RID: 45592
		[SerializeField]
		private Text mExpendCount;

		// Token: 0x0400B219 RID: 45593
		[SerializeField]
		private List<Text> mAttrTexts;

		// Token: 0x0400B21A RID: 45594
		[SerializeField]
		private List<string> mAttrDescs;

		// Token: 0x0400B21B RID: 45595
		private StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B21C RID: 45596
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B21D RID: 45597
		private ComItem mEquipComItem;

		// Token: 0x0400B21E RID: 45598
		private ComItem mExpendComItem;

		// Token: 0x0400B21F RID: 45599
		private ItemData mExpendItemData;

		// Token: 0x0400B220 RID: 45600
		private ItemData mSelectEquipItemData;

		// Token: 0x0400B221 RID: 45601
		private int mAttrValue;

		// Token: 0x0400B222 RID: 45602
		private int iExpendCount;

		// Token: 0x0400B223 RID: 45603
		private int timeLeft;

		// Token: 0x0400B224 RID: 45604
		private bool bStartCountdown;

		// Token: 0x0400B225 RID: 45605
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
