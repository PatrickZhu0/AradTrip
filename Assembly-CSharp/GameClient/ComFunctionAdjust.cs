using System;
using System.Collections.Generic;
using ActivityLimitTime;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200002D RID: 45
	public class ComFunctionAdjust : MonoBehaviour
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000A775 File Offset: 0x00008B75
		// (set) Token: 0x0600010F RID: 271 RVA: 0x0000A77D File Offset: 0x00008B7D
		private ItemData itemData
		{
			get
			{
				return this.itemDataEx;
			}
			set
			{
				this.itemDataEx = value;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000A788 File Offset: 0x00008B88
		private void Start()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.RegisterDelegateHandler();
			this.m_perfectScrollsID = int.Parse(TR.Value("ItemKeyPerfectScrollsID"));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUsePerfectWashRoll, new ClientEventSystem.UIEventHandler(this.OnUsePerfectWashRoll));
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000A7F4 File Offset: 0x00008BF4
		public void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000A874 File Offset: 0x00008C74
		public void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000A8F3 File Offset: 0x00008CF3
		public void Initialize()
		{
			this.Locked = false;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000A8FC File Offset: 0x00008CFC
		private void OnUsePerfectWashRoll(UIEvent iEvent)
		{
			this.OnPerfectScrollsClick();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000A904 File Offset: 0x00008D04
		public void OnClickPopHintCrazyMode()
		{
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("carzy_adjust_intterupt_hint"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000A916 File Offset: 0x00008D16
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._UpdateMoneyItems();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000A91E File Offset: 0x00008D1E
		private void OnAddNewItem(List<Item> items)
		{
			this._UpdateUIStatus();
			this._UpdateMoneyItems();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000A92C File Offset: 0x00008D2C
		private void OnUpdateItem(List<Item> items)
		{
			this._UpdateUIStatus();
			this._UpdateMoneyItems();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000A93A File Offset: 0x00008D3A
		private void OnRemoveItem(ItemData data)
		{
			this._UpdateUIStatus();
			this._UpdateMoneyItems();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000A948 File Offset: 0x00008D48
		public void StopEffect()
		{
			this.m_akAdjustItems.ActiveObjects.ForEach(delegate(CachedAdjustItem x)
			{
				x.StopEffect();
			});
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000A978 File Offset: 0x00008D78
		private void _UpdateMoneyItems()
		{
			QuickBuyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<QuickBuyTable>(this.iAdjustItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int costItemID = tableItem.CostItemID;
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(costItemID);
			if (commonItemTableDataByID != null)
			{
				ETCImageLoader.LoadSprite(ref this.kIcon0, commonItemTableDataByID.Icon, true);
				this.kIcon1.sprite = this.kIcon0.sprite;
				this.kIcon1.material = this.kIcon0.material;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costItemID, false);
			int costNum = tableItem.CostNum;
			this.costCount.text = costNum.ToString();
			this.hasCount.text = ownedItemCount.ToString();
			this._UpdateMoneyItemConvert();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000AA4C File Offset: 0x00008E4C
		private void _UpdateMoneyItemConvert()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount > 0 || !this.toggle.isOn)
			{
				this.goCostItem.CustomActive(true);
				this.goCostMoney.CustomActive(false);
				this.statusBinder.ChangeStatus(2);
			}
			else
			{
				this.goCostItem.CustomActive(false);
				this.goCostMoney.CustomActive(true);
				this.statusBinder.ChangeStatus(1);
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000AAD0 File Offset: 0x00008ED0
		private void OnDestroy()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.UnRegisterDelegateHandler();
			InvokeMethod.RemoveInvokeCall(this);
			this.bStart = false;
			this.bCrazyMode = false;
			if (this.mCurWait != null)
			{
				DataManager<WaitNetMessageManager>.GetInstance().CancelWait(this.mCurWait);
				this.mCurWait = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUsePerfectWashRoll, new ClientEventSystem.UIEventHandler(this.OnUsePerfectWashRoll));
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000AB5C File Offset: 0x00008F5C
		public void SetUIData(ItemData itemData)
		{
			this.itemData = itemData;
			this._UpdateMoneyItems();
			this._UpdateUIStatus();
			this._SaveFullMinusAttrs(itemData);
			if (!this.Locked)
			{
				this._SaveOrgAttrs(itemData);
				this.m_eStopReason = ComFunctionAdjust.StopReason.SR_INVALID;
			}
			this._UpdateQualityDesc();
			this._SaveFullAttrs(itemData);
			this._SaveCurAttrs(itemData);
			this._SavePerfectAttrs(itemData);
			this._LoadChanges(this.Locked);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000ABC3 File Offset: 0x00008FC3
		// (set) Token: 0x06000120 RID: 288 RVA: 0x0000ABCC File Offset: 0x00008FCC
		public bool Locked
		{
			get
			{
				return ComFunctionAdjust.ms_bLocked;
			}
			set
			{
				ComFunctionAdjust.ms_bLocked = value;
				this.goMask.CustomActive(value);
				this.bStart = value;
				this.grayOnce.CustomActive(!value && !this.bIsShowBtnOncebtnCreazy);
				this.grayCrazy.CustomActive(!value && !this.bIsShowBtnOncebtnCreazy);
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000AC2C File Offset: 0x0000902C
		public ComFunctionAdjust.AdjustCheckResult CheckAdjust(UnityAction callback, UnityAction onFailed)
		{
			if (this.itemData == null)
			{
				return ComFunctionAdjust.AdjustCheckResult.ACR_ERROR;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount > 0)
			{
				if (callback != null)
				{
					callback.Invoke();
				}
				return ComFunctionAdjust.AdjustCheckResult.ACR_OK;
			}
			if (!this.toggle.isOn)
			{
				ItemComeLink.OnLink(this.iAdjustItemId, 1, true, delegate
				{
					if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true) >= 1)
					{
						if (callback != null)
						{
							callback.Invoke();
						}
					}
					else if (onFailed != null)
					{
						onFailed.Invoke();
					}
					this.bFirstCrazy = false;
				}, false, false, this.toggle.isOn || (this.bCrazyMode && !this.bFirstCrazy), delegate
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				}, string.Empty);
				return ComFunctionAdjust.AdjustCheckResult.ACR_OK;
			}
			QuickBuyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<QuickBuyTable>(this.iAdjustItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = tableItem.CostItemID,
					nCount = tableItem.CostNum
				}, delegate
				{
					if (callback != null)
					{
						callback.Invoke();
					}
				}, "common_money_cost", delegate
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				});
				return ComFunctionAdjust.AdjustCheckResult.ACR_OK;
			}
			return ComFunctionAdjust.AdjustCheckResult.ACR_ERROR;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000AD64 File Offset: 0x00009164
		public void OnPerfectScrollsClick()
		{
			if (this.itemData == null)
			{
				return;
			}
			if (this.Locked)
			{
				return;
			}
			this.bCrazyMode = false;
			this.m_eStopReason = ComFunctionAdjust.StopReason.SR_NORMAL_BEGIN;
			this._SaveOrgAttrs(this.itemData);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_perfectScrollsID, true);
			if (ownedItemCount > 0)
			{
				this.Locked = true;
				this._NetSyncChangeQuality(this.itemData, false, true);
				return;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000ADD4 File Offset: 0x000091D4
		public void AdjustQualityOnce()
		{
			if (this.itemData == null)
			{
				return;
			}
			if (this.Locked)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			this.bCrazyMode = false;
			this.m_eStopReason = ComFunctionAdjust.StopReason.SR_NORMAL_BEGIN;
			this._SaveOrgAttrs(this.itemData);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount > 0)
			{
				this.Locked = true;
				this._NetSyncChangeQuality(this.itemData, this._CheckNeedUsePoint(), false);
				return;
			}
			if (!this._CheckNeedUsePoint())
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.NO_QUILTY_ADJUST_BOX, delegate
				{
					ItemComeLink.OnLink(this.iAdjustItemId, 0, false, null, false, false, false, null, string.Empty);
				});
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			this._TryAdjustCostMoney(600000002, 10, delegate
			{
				this.Locked = true;
				this._NetSyncChangeQuality(this.itemData, this._CheckNeedUsePoint(), false);
			}, null);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000AEB0 File Offset: 0x000092B0
		private int _GetTargetQualityValue(ItemData itemData)
		{
			int num = 60;
			if (itemData == null)
			{
				return num;
			}
			int num2 = itemData.SubQuality;
			if (num2 < num)
			{
				return num;
			}
			num2++;
			return IntMath.Min(num2, 100);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000AEE8 File Offset: 0x000092E8
		private void _SaveOrgAttrs(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			EquipQLValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipQLValueTable>(this._GetEquipQLValueId(itemData), string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			float num = (float)tableItem.AtkDef * 0.001f;
			float num2 = (float)tableItem.FourDimensional * 0.001f;
			float num3 = (float)tableItem.IndependentResists * 0.001f;
			for (int i = 0; i < ComFunctionAdjust.ms_akProps.Length; i++)
			{
				float num4;
				if (i < 4 || (i >= 8 && i < 12))
				{
					num4 = this.fullMinusAttrs[i] * (1f - num) * (float)itemData.SubQuality / 100f;
				}
				else if (i == 16)
				{
					num4 = this.fullMinusAttrs[i] * (1f - num3) * (float)itemData.SubQuality / 100f;
				}
				else
				{
					num4 = this.fullMinusAttrs[i] * (1f - num2) * (float)itemData.SubQuality / 100f;
				}
				this.orgAttrs[i] = num4;
			}
			this.iOrgQuality = itemData.SubQuality;
			this._SaveItemOrgQuality(itemData.SubQuality);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000B01E File Offset: 0x0000941E
		private void _SaveItemOrgQuality(int data)
		{
			this.iEndQuality = data;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000B027 File Offset: 0x00009427
		private int _GetItemQuality()
		{
			return this.iEndQuality;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000B030 File Offset: 0x00009430
		private void _SaveCurAttrs(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			EquipQLValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipQLValueTable>(this._GetEquipQLValueId(itemData), string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemData.GUID);
			if (item == null)
			{
				return;
			}
			float num = (float)tableItem.AtkDef * 0.001f;
			float num2 = (float)tableItem.FourDimensional * 0.001f;
			float num3 = (float)tableItem.IndependentResists * 0.001f;
			if (itemData == null)
			{
				return;
			}
			for (int i = 0; i < ComFunctionAdjust.ms_akProps.Length; i++)
			{
				float num4;
				if (i < 4 || (i >= 8 && i < 12))
				{
					num4 = this.fullMinusAttrs[i] * (1f - num) * (float)item.SubQuality / 100f;
				}
				else if (i == 16)
				{
					num4 = this.fullMinusAttrs[i] * (1f - num3) * (float)item.SubQuality / 100f;
				}
				else
				{
					num4 = this.fullMinusAttrs[i] * (1f - num2) * (float)item.SubQuality / 100f;
				}
				this.curAttrs[i] = num4;
			}
			this.iCurQuality = item.SubQuality;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000B17C File Offset: 0x0000957C
		private void _SaveFullMinusAttrs(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			Array.Clear(this.fullMinusAttrs, 0, this.fullMinusAttrs.Length);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(tableItem.EquipPropID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			this.fullMinusAttrs[0] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[0], tableItem2.Atk);
			this.fullMinusAttrs[1] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[1], tableItem2.MagicAtk);
			this.fullMinusAttrs[2] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[2], tableItem2.Def);
			this.fullMinusAttrs[3] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[3], tableItem2.MagicDef);
			this.fullMinusAttrs[4] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[4], tableItem2.Strenth);
			this.fullMinusAttrs[5] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[5], tableItem2.Intellect);
			this.fullMinusAttrs[6] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[6], tableItem2.Spirit);
			this.fullMinusAttrs[7] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[7], tableItem2.Stamina);
			this.fullMinusAttrs[8] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[8], tableItem2.LightAttack);
			this.fullMinusAttrs[9] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[9], tableItem2.FireAttack);
			this.fullMinusAttrs[10] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[10], tableItem2.IceAttack);
			this.fullMinusAttrs[11] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[11], tableItem2.DarkAttack);
			this.fullMinusAttrs[12] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[12], tableItem2.LightDefence);
			this.fullMinusAttrs[13] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[13], tableItem2.FireDefence);
			this.fullMinusAttrs[14] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[14], tableItem2.IceDefence);
			this.fullMinusAttrs[15] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[15], tableItem2.DarkDefence);
			this.fullMinusAttrs[16] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[16], tableItem2.Independence);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000B3D4 File Offset: 0x000097D4
		private void _SaveFullAttrs(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			Array.Clear(this.fullAttrs, 0, this.fullAttrs.Length);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(tableItem.EquipPropID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			EquipQLValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EquipQLValueTable>(this._GetEquipQLValueId(itemData), string.Empty, string.Empty);
			if (tableItem3 == null)
			{
				return;
			}
			float num = 1f - (float)tableItem3.AtkDef * 0.001f;
			float num2 = 1f - (float)tableItem3.FourDimensional * 0.001f;
			float num3 = 1f - (float)tableItem3.IndependentResists * 0.001f;
			this.fullAttrs[0] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[0], tableItem2.Atk);
			this.fullAttrs[1] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[1], tableItem2.MagicAtk);
			this.fullAttrs[2] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[2], tableItem2.Def);
			this.fullAttrs[3] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[3], tableItem2.MagicDef);
			this.fullAttrs[4] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[4], tableItem2.Strenth);
			this.fullAttrs[5] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[5], tableItem2.Intellect);
			this.fullAttrs[6] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[6], tableItem2.Spirit);
			this.fullAttrs[7] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[7], tableItem2.Stamina);
			this.fullAttrs[8] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[8], tableItem2.LightAttack);
			this.fullAttrs[9] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[9], tableItem2.FireAttack);
			this.fullAttrs[10] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[10], tableItem2.IceAttack);
			this.fullAttrs[11] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[11], tableItem2.DarkAttack);
			this.fullAttrs[12] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[12], tableItem2.LightDefence);
			this.fullAttrs[13] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[13], tableItem2.FireDefence);
			this.fullAttrs[14] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[14], tableItem2.IceDefence);
			this.fullAttrs[15] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[15], tableItem2.DarkDefence);
			this.fullAttrs[16] = (float)itemData.ConvertAttrByValue(ComFunctionAdjust.ms_akProps[16], tableItem2.Independence);
			for (int i = 0; i < 4; i++)
			{
				this.fullAttrs[i] *= num;
			}
			for (int j = 4; j < 8; j++)
			{
				this.fullAttrs[j] *= num2;
			}
			for (int k = 8; k < 12; k++)
			{
				this.fullAttrs[k] *= num;
			}
			for (int l = 12; l < 16; l++)
			{
				this.fullAttrs[l] *= num2;
			}
			this.fullAttrs[16] *= num3;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000B748 File Offset: 0x00009B48
		private void _SavePerfectAttrs(ItemData itemData)
		{
			Array.Clear(this.perfectAttrs, 0, this.perfectAttrs.Length);
			if (itemData != null)
			{
				EquipQLValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipQLValueTable>(this._GetEquipQLValueId(itemData), string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int i = 0; i < this.perfectAttrs.Length; i++)
					{
						if (i < 8)
						{
							this.perfectAttrs[i] = (float)Mathf.FloorToInt(this.fullMinusAttrs[i] * (float)tableItem.PerfectAtkDef * 0.001f);
						}
						else if (i == 16)
						{
							this.perfectAttrs[i] = (float)Mathf.FloorToInt(this.fullMinusAttrs[i] * (float)tableItem.PerfectIndependentResists * 0.001f);
						}
						else
						{
							this.perfectAttrs[i] = (float)Mathf.FloorToInt(this.fullMinusAttrs[i] * (float)tableItem.PerfectFourDimensional * 0.001f);
						}
						this.perfectAttrs[i] = Mathf.Max(this.perfectAttrs[i], 1f);
					}
				}
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000B84C File Offset: 0x00009C4C
		private int _GetEquipQLValueId(ItemData itemData)
		{
			if (itemData != null)
			{
				if (itemData.SubType == 1)
				{
					return 1;
				}
				if (itemData.SubType >= 2 && itemData.SubType <= 6)
				{
					int num = itemData.ThirdType - ItemTable.eThirdType.CLOTH;
					if (num >= 0 && num < ComFunctionAdjust.ms_thirdtype_map_QLValueId.Length)
					{
						return ComFunctionAdjust.ms_thirdtype_map_QLValueId[num];
					}
				}
				if (itemData.SubType >= 7 && itemData.SubType <= 9)
				{
					return 7;
				}
			}
			return 1;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000B8C8 File Offset: 0x00009CC8
		private void _LoadChanges(bool bNeedEffect)
		{
			List<AdjustChangedAttr> list = ListPool<AdjustChangedAttr>.Get();
			for (int i = 0; i < ComFunctionAdjust.ms_akProps.Length; i++)
			{
				bool flag = this.orgAttrs[i] == 0f && this.curAttrs[i] == 0f && this.fullAttrs[i] == 0f;
				if (!flag)
				{
					list.Add(new AdjustChangedAttr
					{
						eEEquipProp = ComFunctionAdjust.ms_akProps[i],
						iOrgAttr = this.orgAttrs[i],
						iCurAttr = this.curAttrs[i],
						iOrgQuality = this.iOrgQuality,
						iCurQuality = this.iCurQuality,
						iFullAttr = this.fullAttrs[i],
						iExtraAttr = this.perfectAttrs[i],
						bEffect = bNeedEffect
					});
				}
			}
			this.m_akAdjustItems.RecycleAllObject();
			for (int j = 0; j < list.Count; j++)
			{
				this.m_akAdjustItems.Create(new object[]
				{
					this.goParent,
					this.goPrefab,
					list[j],
					false
				});
			}
			ListPool<AdjustChangedAttr>.Release(list);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000BA0C File Offset: 0x00009E0C
		public void AdjustQualityCrazy()
		{
			if (this.itemData == null)
			{
				return;
			}
			if (this.Locked)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			int num = this._GetItemQuality();
			if (num == -1)
			{
				return;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount > 0)
			{
				this._TryOpenNewMessageBox(new UnityAction(this._ConfirmToCrazyX), new UnityAction(this._ConfirmToCrazyX));
				return;
			}
			if (this._CheckNeedUsePoint())
			{
				this._TryOpenNewMessageBox(delegate
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
					this.toggle.isOn = true;
					this._TryAdjustCostMoney(600000002, 10, delegate
					{
						this._ConfirmToCrazyX();
					}, null);
				}, delegate
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
					this.toggle.isOn = true;
					this._TryAdjustCostMoney(600000002, 10, delegate
					{
						this._ConfirmToCrazyX();
					}, null);
				});
				return;
			}
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.NO_QUILTY_ADJUST_BOX, delegate
			{
				this._TryOpenNewMessageBox(delegate
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
					this.toggle.isOn = true;
					this._TryAdjustCostMoney(600000002, 10, delegate
					{
						this._ConfirmToCrazyX();
					}, null);
				}, delegate
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
					this.toggle.isOn = true;
					this._TryAdjustCostMoney(600000002, 10, delegate
					{
						this._ConfirmToCrazyX();
					}, null);
				});
			});
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000BAD0 File Offset: 0x00009ED0
		private void _TryOpenNewMessageBox(UnityAction tempAction1, UnityAction tempAction2)
		{
			this._SaveItemOrgQuality(this.itemData.SubQuality);
			int num = this._GetItemQuality();
			List<ToggleEvent> list = new List<ToggleEvent>();
			if (num >= 99)
			{
				list.Add(new ToggleEvent(TR.Value("quality_adjust_crazy_new_tip"), tempAction1));
			}
			else if (num >= 0 && num < 99)
			{
				list.Add(new ToggleEvent(TR.Value("quality_adjust_crazy_old_tip", ((num + 1 <= 60) ? 60 : (num + 1)).ToString()), tempAction1));
				list.Add(new ToggleEvent(TR.Value("quality_adjust_crazy_new_tip"), tempAction2));
			}
			CommonNewMessageBox.Notify("UIFlatten/Prefabs/SmithShop/CrazyAdjustConfirmFrame", 7013, null, null, list, new object[]
			{
				this._GetCrazyMsgBoxText()
			}, new object[]
			{
				this._GetTargetQualityValue(this.itemData)
			}, null, null, FrameLayer.Middle);
			CrazyAdjustPercentSet.initTargetQuality = ((num >= 60) ? ((num / 10 + 1) * 10) : 60);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000BBD8 File Offset: 0x00009FD8
		private string _GetCrazyMsgBoxText()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount > 0)
			{
				return TR.Value("crazy_adjust_cost_item");
			}
			if (!this.toggle.isOn)
			{
				return TR.Value("crazy_adjust_try_cost_money");
			}
			return TR.Value("crazy_adjust_cost_money");
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000BC30 File Offset: 0x0000A030
		private string _GetQualityDesc(ItemData itemData, string ex = "")
		{
			string result = string.Empty;
			if (itemData != null)
			{
				int subQuality = itemData.SubQuality;
				if (subQuality <= 20)
				{
					result = TR.Value("tip_grade_lower_most" + ex, subQuality);
				}
				else if (subQuality <= 40)
				{
					result = TR.Value("tip_grade_lower" + ex, subQuality);
				}
				else if (subQuality <= 60)
				{
					result = TR.Value("tip_grade_middle" + ex, subQuality);
				}
				else if (subQuality <= 80)
				{
					result = TR.Value("tip_grade_high" + ex, subQuality);
				}
				else if (subQuality < 100)
				{
					result = TR.Value("tip_grade_high_most" + ex, subQuality);
				}
				else
				{
					result = TR.Value("tip_grade_perfect" + ex, subQuality);
				}
			}
			else
			{
				result = TR.Value("tip_grade_perfect" + ex, 100);
			}
			return result;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000BD3C File Offset: 0x0000A13C
		private void _ConfirmToCarzy()
		{
			this.qualityHint.text = string.Format(TR.Value("quality_adjust_crazy_mode_hint", this._GetQualityDesc(this.itemData, "_ex")), new object[0]);
			this.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_BEGIN;
			this.bFirstCrazy = true;
			this.bCrazyMode = true;
			this._SaveOrgAttrs(this.itemData);
			this.Locked = true;
			this._NetSyncChangeQuality(this.itemData, this._CheckNeedUsePoint(), false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessStart, null, null, null, null);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000BDC8 File Offset: 0x0000A1C8
		private void _ConfirmToCrazyX()
		{
			if (this.itemData != null && CrazyAdjustPercentSet.curTargetQuality <= this.itemData.SubQuality)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("target_quality_less_than_now"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.StopCloseCommonNewMessageBoxView, null, null, null, null);
				return;
			}
			this.qualityHint.text = string.Format(TR.Value("quality_adjust_crazy_mode_hint", this._GetQualityDesc(this.itemData, "_ex")), new object[0]);
			this.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_BEGIN;
			this.bFirstCrazy = true;
			this.bCrazyMode = true;
			this._SaveOrgAttrs(this.itemData);
			this._SaveItemOrgQuality(CrazyAdjustPercentSet.curTargetQuality);
			this.Locked = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessStart, null, null, null, null);
			this._NetSyncChangeQuality(this.itemData, this._CheckNeedUsePoint(), false);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000BEA4 File Offset: 0x0000A2A4
		private void _ConfirmToCrazy100()
		{
			this.qualityHint.text = string.Format(TR.Value("quality_adjust_crazy_mode_hint", this._GetQualityDesc(this.itemData, "_ex")), new object[0]);
			this.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_BEGIN;
			this.bFirstCrazy = true;
			this.bCrazyMode = true;
			this._SaveOrgAttrs(this.itemData);
			this._SaveItemOrgQuality(99);
			this.Locked = true;
			this._NetSyncChangeQuality(this.itemData, this._CheckNeedUsePoint(), false);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000BF28 File Offset: 0x0000A328
		private void _TryAdjustCostMoney(int iId, int iCount, Action onOk, Action onFailed)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, true);
			if (ownedItemCount < 1)
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = iId,
					nCount = iCount
				}, onOk, "common_money_cost", onFailed);
				return;
			}
			if (onOk != null)
			{
				onOk();
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000BF82 File Offset: 0x0000A382
		private bool _CheckNeedUsePoint()
		{
			return this.toggle.isOn && DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iAdjustItemId, false) < 1;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000BFAB File Offset: 0x0000A3AB
		public void StopCrazyAdjust()
		{
			this.bStart = false;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000BFB4 File Offset: 0x0000A3B4
		private void _EndAdjust(ItemData a_item, bool bNeedEffect = true)
		{
			this._SaveFullMinusAttrs(a_item);
			this._SaveCurAttrs(a_item);
			this.bCrazyMode = false;
			this.Locked = false;
			this._SaveFullAttrs(a_item);
			this._SavePerfectAttrs(a_item);
			this._LoadChanges(bNeedEffect);
			this._UpdateQualityDesc();
			this.stopItem = null;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000BFF4 File Offset: 0x0000A3F4
		protected bool _SatisfiedWithQuality()
		{
			return this.iCurQuality >= this.iEndQuality && this.iCurQuality >= 60;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000C018 File Offset: 0x0000A418
		private void Update()
		{
			if (this.bCrazyMode && !this.bStart && this.Locked)
			{
				InvokeMethod.RemoveInvokeCall(this);
				this.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_CONTINUE;
				this.StopEffect();
				this.iCurQuality = this.stopItem.SubQuality;
				this.stopItem.SubQuality = this.iOrgQuality;
				string text = this._GetQualityDesc(this.stopItem, "_1");
				this.stopItem.SubQuality = this.iCurQuality;
				string text2 = this._GetQualityDesc(this.stopItem, "_1");
				this._EndAdjust(this.stopItem, false);
				CommonMessageBox.Notify(7010, "UIFlatten/Prefabs/SmithShop/CrazyAdjustFinish", new object[]
				{
					text,
					text2
				}, null, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000C0F4 File Offset: 0x0000A4F4
		protected void _NetSyncChangeQuality(ItemData a_item, bool bUsePoint, bool bUsePrefectScrolls = false)
		{
			ComFunctionAdjust.<_NetSyncChangeQuality>c__AnonStorey1 <_NetSyncChangeQuality>c__AnonStorey = new ComFunctionAdjust.<_NetSyncChangeQuality>c__AnonStorey1();
			<_NetSyncChangeQuality>c__AnonStorey.a_item = a_item;
			<_NetSyncChangeQuality>c__AnonStorey.$this = this;
			SceneRandEquipQlvReq sceneRandEquipQlvReq = new SceneRandEquipQlvReq();
			sceneRandEquipQlvReq.uid = <_NetSyncChangeQuality>c__AnonStorey.a_item.GUID;
			sceneRandEquipQlvReq.bUsePoint = ((!bUsePoint) ? 0 : 1);
			sceneRandEquipQlvReq.usePerfect = ((!bUsePrefectScrolls) ? 0 : 1);
			this.bIsShowBtnOncebtnCreazy = bUsePrefectScrolls;
			NetManager.Instance().SendCommand<SceneRandEquipQlvReq>(ServerType.GATE_SERVER, sceneRandEquipQlvReq);
			if (this.mCurWait != null)
			{
				Logger.LogErrorFormat("IWait is not null !!!", new object[0]);
				return;
			}
			this.mCurWait = DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneRandEquipQlvRet>(delegate(SceneRandEquipQlvRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					<_NetSyncChangeQuality>c__AnonStorey.$this.mCurWait = null;
					<_NetSyncChangeQuality>c__AnonStorey.$this.Locked = false;
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					<_NetSyncChangeQuality>c__AnonStorey.$this.mCurWait = null;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemQualityChanged, null, null, null, null);
					if (!<_NetSyncChangeQuality>c__AnonStorey.$this.bCrazyMode)
					{
						<_NetSyncChangeQuality>c__AnonStorey.$this.m_eStopReason = ComFunctionAdjust.StopReason.SR_NORMAL_END;
						<_NetSyncChangeQuality>c__AnonStorey.$this._EndAdjust(<_NetSyncChangeQuality>c__AnonStorey.a_item, true);
						if (<_NetSyncChangeQuality>c__AnonStorey.$this.bIsShowBtnOncebtnCreazy)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<PerfectBaptizeResultFrame>(FrameLayer.Middle, <_NetSyncChangeQuality>c__AnonStorey.a_item, string.Empty);
						}
						return;
					}
					if (<_NetSyncChangeQuality>c__AnonStorey.$this._SatisfiedWithQuality())
					{
						<_NetSyncChangeQuality>c__AnonStorey.$this.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_END;
						<_NetSyncChangeQuality>c__AnonStorey.$this.iCurQuality = <_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality;
						<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.$this.iOrgQuality;
						string text = <_NetSyncChangeQuality>c__AnonStorey.$this._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
						<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.$this.iCurQuality;
						string text2 = <_NetSyncChangeQuality>c__AnonStorey.$this._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
						<_NetSyncChangeQuality>c__AnonStorey.$this._EndAdjust(<_NetSyncChangeQuality>c__AnonStorey.a_item, true);
						CommonMessageBox.Notify(7009, "UIFlatten/Prefabs/SmithShop/CrazyAdjustFinish", new object[]
						{
							text,
							text2
						}, null, null, null, null, null);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
						return;
					}
					<_NetSyncChangeQuality>c__AnonStorey.$this.stopItem = <_NetSyncChangeQuality>c__AnonStorey.a_item;
					InvokeMethod.RemoveInvokeCall(<_NetSyncChangeQuality>c__AnonStorey.$this);
					InvokeMethod.Invoke(<_NetSyncChangeQuality>c__AnonStorey.$this, Global.Settings.qualityAdjust.fInterval, delegate()
					{
						if (<_NetSyncChangeQuality>c__AnonStorey.$this.bStart)
						{
							int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(<_NetSyncChangeQuality>c__AnonStorey.$this.iAdjustItemId, true);
							if (ownedItemCount > 0)
							{
								<_NetSyncChangeQuality>c__AnonStorey.$this.Locked = true;
								<_NetSyncChangeQuality>c__AnonStorey.$this._NetSyncChangeQuality(<_NetSyncChangeQuality>c__AnonStorey.$this.itemData, <_NetSyncChangeQuality>c__AnonStorey.$this._CheckNeedUsePoint(), false);
								return;
							}
							UnityAction ShowCrazyAdjustResult = delegate()
							{
								<_NetSyncChangeQuality>c__AnonStorey.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_CONTINUE;
								<_NetSyncChangeQuality>c__AnonStorey.iCurQuality = <_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality;
								<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.iOrgQuality;
								string text3 = <_NetSyncChangeQuality>c__AnonStorey._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
								<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.iCurQuality;
								string text4 = <_NetSyncChangeQuality>c__AnonStorey._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
								<_NetSyncChangeQuality>c__AnonStorey._EndAdjust(<_NetSyncChangeQuality>c__AnonStorey.a_item, false);
								CommonMessageBox.Notify(7011, "UIFlatten/Prefabs/SmithShop/CrazyAdjustFinish", new object[]
								{
									text3,
									text4
								}, delegate()
								{
									DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.NO_QUILTY_ADJUST_BOX, null);
								}, delegate()
								{
									DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.NO_QUILTY_ADJUST_BOX, null);
								}, null, null, null);
							};
							if (!<_NetSyncChangeQuality>c__AnonStorey.$this.toggle.isOn)
							{
								ShowCrazyAdjustResult.Invoke();
								return;
							}
							if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
							{
								return;
							}
							<_NetSyncChangeQuality>c__AnonStorey.$this._TryAdjustCostMoney(600000002, 10, delegate
							{
								<_NetSyncChangeQuality>c__AnonStorey.toggle.isOn = true;
								<_NetSyncChangeQuality>c__AnonStorey.Locked = true;
								<_NetSyncChangeQuality>c__AnonStorey._NetSyncChangeQuality(<_NetSyncChangeQuality>c__AnonStorey.itemData, <_NetSyncChangeQuality>c__AnonStorey._CheckNeedUsePoint(), false);
							}, delegate
							{
								<_NetSyncChangeQuality>c__AnonStorey.m_eStopReason = ComFunctionAdjust.StopReason.SR_CRAZY_CONTINUE;
								<_NetSyncChangeQuality>c__AnonStorey.iCurQuality = <_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality;
								<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.iOrgQuality;
								string text3 = <_NetSyncChangeQuality>c__AnonStorey._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
								<_NetSyncChangeQuality>c__AnonStorey.a_item.SubQuality = <_NetSyncChangeQuality>c__AnonStorey.iCurQuality;
								string text4 = <_NetSyncChangeQuality>c__AnonStorey._GetQualityDesc(<_NetSyncChangeQuality>c__AnonStorey.a_item, "_1");
								<_NetSyncChangeQuality>c__AnonStorey._EndAdjust(<_NetSyncChangeQuality>c__AnonStorey.a_item, false);
								CommonMessageBox.Notify(7011, "UIFlatten/Prefabs/SmithShop/CrazyAdjustFinish", new object[]
								{
									text3,
									text4
								}, null, null, null, null, null);
							});
						}
					});
				}
			}, true, 3f, new Action(this._OnAdjustTimerOver));
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000C1B0 File Offset: 0x0000A5B0
		private void _OnAdjustTimerOver()
		{
			this.Locked = false;
			if (this.mCurWait != null)
			{
				DataManager<WaitNetMessageManager>.GetInstance().CancelWait(this.mCurWait);
				this.mCurWait = null;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000C1DC File Offset: 0x0000A5DC
		public void OnClickAddCostItem()
		{
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			vipFrame.SwitchPage(VipTabType.PAY, true);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000C208 File Offset: 0x0000A608
		public void OnToggleChanged(bool bValue)
		{
			this._UpdateMoneyItems();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000C210 File Offset: 0x0000A610
		private void _UpdateUIStatus()
		{
			bool flag = this.itemData != null && this.itemData.SubQuality >= 100;
			this.grayOnce.enabled = flag;
			this.grayCrazy.enabled = flag;
			this.buttonOnce.enabled = !flag;
			this.buttonCrazy.enabled = !flag;
			this.goStopCrazy.CustomActive(this.bStart && this.bCrazyMode);
			this.goCrazyHint.CustomActive(this.bStart && this.bCrazyMode);
			this.qualityHint.CustomActive(this.bStart && this.bCrazyMode);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000C2D4 File Offset: 0x0000A6D4
		private void _UpdateQualityDesc()
		{
			if (this.itemData == null)
			{
				return;
			}
			if (this.m_eStopReason == ComFunctionAdjust.StopReason.SR_CRAZY_CONTINUE || this.m_eStopReason == ComFunctionAdjust.StopReason.SR_CRAZY_END || this.m_eStopReason == ComFunctionAdjust.StopReason.SR_NORMAL_END)
			{
				if (this.itemData.SubQuality >= 100)
				{
					this.qualityUpSpecial.CustomActive(false);
					this.qualityDown.CustomActive(false);
					this.qualityUp.CustomActive(false);
					this.qualityUnChanged.CustomActive(false);
					this.qualityFull.CustomActive(true);
				}
				else if (this.iCurQuality > this.iOrgQuality)
				{
					if (this.m_eStopReason == ComFunctionAdjust.StopReason.SR_NORMAL_END)
					{
						this.qualityUpSpecial.CustomActive(false);
						this.qualityUp.CustomActive(true);
					}
					else if (this.m_eStopReason == ComFunctionAdjust.StopReason.SR_CRAZY_CONTINUE || this.m_eStopReason == ComFunctionAdjust.StopReason.SR_CRAZY_END)
					{
						this.qualityUpSpecial.CustomActive(true);
						this.qualityUp.CustomActive(false);
					}
					this.qualityDown.CustomActive(false);
					this.qualityUnChanged.CustomActive(false);
					this.qualityFull.CustomActive(false);
				}
				else if (this.iCurQuality == this.iOrgQuality)
				{
					this.qualityUpSpecial.CustomActive(false);
					this.qualityDown.CustomActive(false);
					this.qualityUp.CustomActive(false);
					this.qualityUnChanged.CustomActive(true);
					this.qualityFull.CustomActive(false);
				}
				else
				{
					this.qualityUpSpecial.CustomActive(false);
					this.qualityDown.CustomActive(true);
					this.qualityUp.CustomActive(false);
					this.qualityUnChanged.CustomActive(false);
					this.qualityFull.CustomActive(false);
				}
			}
			else
			{
				this.qualityUpSpecial.CustomActive(false);
				this.qualityDown.CustomActive(false);
				this.qualityUp.CustomActive(false);
				this.qualityUnChanged.CustomActive(false);
				this.qualityFull.CustomActive(false);
			}
		}

		// Token: 0x040000E4 RID: 228
		public Text Quality;

		// Token: 0x040000E5 RID: 229
		public GameObject goParent;

		// Token: 0x040000E6 RID: 230
		public GameObject goPrefab;

		// Token: 0x040000E7 RID: 231
		public Image kIcon0;

		// Token: 0x040000E8 RID: 232
		public Image kIcon1;

		// Token: 0x040000E9 RID: 233
		public Text costCount;

		// Token: 0x040000EA RID: 234
		public Text hasCount;

		// Token: 0x040000EB RID: 235
		public Text qualityDown;

		// Token: 0x040000EC RID: 236
		public Text qualityUp;

		// Token: 0x040000ED RID: 237
		public Text qualityUpSpecial;

		// Token: 0x040000EE RID: 238
		public Text qualityUnChanged;

		// Token: 0x040000EF RID: 239
		public Text qualityFull;

		// Token: 0x040000F0 RID: 240
		public Text qualityHint;

		// Token: 0x040000F1 RID: 241
		public Text toggleHintText;

		// Token: 0x040000F2 RID: 242
		public Toggle toggle;

		// Token: 0x040000F3 RID: 243
		public GameObject goMask;

		// Token: 0x040000F4 RID: 244
		public UIGray grayOnce;

		// Token: 0x040000F5 RID: 245
		public UIGray grayCrazy;

		// Token: 0x040000F6 RID: 246
		public Button buttonOnce;

		// Token: 0x040000F7 RID: 247
		public Button buttonCrazy;

		// Token: 0x040000F8 RID: 248
		public GameObject goStopCrazy;

		// Token: 0x040000F9 RID: 249
		public GameObject goCrazyHint;

		// Token: 0x040000FA RID: 250
		public GameObject goCostItem;

		// Token: 0x040000FB RID: 251
		public GameObject goCostMoney;

		// Token: 0x040000FC RID: 252
		public StatusBinder statusBinder;

		// Token: 0x040000FD RID: 253
		private CachedObjectListManager<CachedAdjustItem> m_akAdjustItems = new CachedObjectListManager<CachedAdjustItem>();

		// Token: 0x040000FE RID: 254
		private ItemData itemDataEx;

		// Token: 0x040000FF RID: 255
		private bool bCrazyMode;

		// Token: 0x04000100 RID: 256
		private bool bStart;

		// Token: 0x04000101 RID: 257
		private bool bFirstCrazy = true;

		// Token: 0x04000102 RID: 258
		private bool bIsShowBtnOncebtnCreazy;

		// Token: 0x04000103 RID: 259
		private int iAdjustItemId = 200110002;

		// Token: 0x04000104 RID: 260
		private int m_perfectScrollsID;

		// Token: 0x04000105 RID: 261
		public static EEquipProp[] ms_akProps = new EEquipProp[]
		{
			EEquipProp.PhysicsAttack,
			EEquipProp.MagicAttack,
			EEquipProp.PhysicsDefense,
			EEquipProp.MagicDefense,
			EEquipProp.Strenth,
			EEquipProp.Intellect,
			EEquipProp.Spirit,
			EEquipProp.Stamina,
			EEquipProp.LightAttack,
			EEquipProp.FireAttack,
			EEquipProp.IceAttack,
			EEquipProp.DarkAttack,
			EEquipProp.LightDefence,
			EEquipProp.FireDefence,
			EEquipProp.IceDefence,
			EEquipProp.DarkDefence,
			EEquipProp.Independence
		};

		// Token: 0x04000106 RID: 262
		private float[] orgAttrs = new float[17];

		// Token: 0x04000107 RID: 263
		private int iOrgQuality;

		// Token: 0x04000108 RID: 264
		private int iEndQuality;

		// Token: 0x04000109 RID: 265
		private float[] curAttrs = new float[17];

		// Token: 0x0400010A RID: 266
		private int iCurQuality;

		// Token: 0x0400010B RID: 267
		private float[] fullAttrs = new float[17];

		// Token: 0x0400010C RID: 268
		private float[] perfectAttrs = new float[17];

		// Token: 0x0400010D RID: 269
		private float[] fullMinusAttrs = new float[17];

		// Token: 0x0400010E RID: 270
		private ComFunctionAdjust.StopReason m_eStopReason;

		// Token: 0x0400010F RID: 271
		private static bool ms_bLocked = false;

		// Token: 0x04000110 RID: 272
		private static int[] ms_thirdtype_map_QLValueId = new int[]
		{
			2,
			3,
			5,
			6,
			4
		};

		// Token: 0x04000111 RID: 273
		private ItemData stopItem;

		// Token: 0x04000112 RID: 274
		private WaitNetMessageManager.IWaitData mCurWait;

		// Token: 0x0200002E RID: 46
		public enum StopReason
		{
			// Token: 0x04000115 RID: 277
			SR_INVALID,
			// Token: 0x04000116 RID: 278
			SR_CRAZY_BEGIN,
			// Token: 0x04000117 RID: 279
			SR_CRAZY_CONTINUE,
			// Token: 0x04000118 RID: 280
			SR_NORMAL_BEGIN,
			// Token: 0x04000119 RID: 281
			SR_CRAZY_END,
			// Token: 0x0400011A RID: 282
			SR_NORMAL_END,
			// Token: 0x0400011B RID: 283
			SR_EFFECT_NOT_ENOUNGH,
			// Token: 0x0400011C RID: 284
			SR_BY_HANDLE,
			// Token: 0x0400011D RID: 285
			SR_REACH_TARGET
		}

		// Token: 0x0200002F RID: 47
		public enum AdjustCheckResult
		{
			// Token: 0x0400011F RID: 287
			ACR_OK,
			// Token: 0x04000120 RID: 288
			ACR_QUALITY_BOX,
			// Token: 0x04000121 RID: 289
			ACR_ERROR
		}
	}
}
