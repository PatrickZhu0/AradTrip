using System;
using System.Collections.Generic;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B20 RID: 6944
	public class ComFashionMergeDataBinder : MonoBehaviour
	{
		// Token: 0x060110AC RID: 69804 RVA: 0x004E0D24 File Offset: 0x004DF124
		public void _OnRedPointChanged(UIEvent uiEvent)
		{
			int redCount = DataManager<FashionMergeManager>.GetInstance().redCount;
			if (null != this.mRedCount)
			{
				this.mRedCount.text = redCount.ToString();
			}
			UnityEvent unityEvent = (redCount <= 0) ? this.mOnRedPointOff : this.mOnRedPointOn;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x060110AD RID: 69805 RVA: 0x004E0D8A File Offset: 0x004DF18A
		public void OnNotify()
		{
			SystemNotifyManager.SysNotifyTextAnimation(this.mPopContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x060110AE RID: 69806 RVA: 0x004E0D98 File Offset: 0x004DF198
		public void UpdateWindProcess()
		{
			if (null != this.windProcess)
			{
				int num = 0;
				if (DataManager<FashionMergeManager>.GetInstance().FashionType == FashionType.FT_SKY)
				{
					int num2 = 0;
					while (num2 < this.skySlotValues.Length && num2 < 5)
					{
						if (this.skySlotValues[num2] != 0)
						{
							num++;
						}
						num2++;
					}
				}
				else
				{
					int num3 = 0;
					while (num3 < this.goldSkySlotValues.Length && num3 < 5)
					{
						if (this.goldSkySlotValues[num3] != 0)
						{
							num++;
						}
						num3++;
					}
				}
				num = (int)IntMath.Clamp((long)num, 0L, 5L);
				this.windProcess.text = string.Format(this.windProcessString, num, 5);
				this.windProcess.CustomActive(num < 5);
			}
		}

		// Token: 0x060110AF RID: 69807 RVA: 0x004E0E70 File Offset: 0x004DF270
		public void FlyEffect2Slot(int iIndex, Vector3 start, ItemTable.eSubType sub, float len = 5f, UnityAction onStart = null, UnityAction onEnd = null)
		{
			int num = this._GetSlotIDByType(sub);
			if (this.goItemParents != null && num >= 0 && num < this.goItemParents.Length)
			{
				this.FlyEffect(iIndex, start, this.goItemParents[num].transform.position, len, onStart, onEnd);
			}
		}

		// Token: 0x060110B0 RID: 69808 RVA: 0x004E0EC8 File Offset: 0x004DF2C8
		public void FlyEffect(int iIndex, Vector3 start, Vector3 end, float len = 5f, UnityAction onStart = null, UnityAction onEnd = null)
		{
			if (null != this.mEffectLoader)
			{
				InvokeMethod.RmoveInvokeIntervalCall(this.mEffectLoader);
				float time = Time.time;
				InvokeMethod.InvokeInterval(this.mEffectLoader, 0f, 0.03f, len, delegate
				{
					if (onStart != null)
					{
						onStart.Invoke();
					}
					this.mEffectLoader.LoadEffect(iIndex);
					this.mEffectLoader.SetEffectPosition(iIndex, start);
					this.mEffectLoader.ActiveEffect(iIndex);
					if (null != this.mEffectFlyState)
					{
						this.mEffectFlyState.Key = this.mStrEnable;
					}
				}, delegate
				{
					if (null != this.mEffectLoader)
					{
						float num = Mathf.Clamp01((Time.time - time) / len);
						Vector3 zero = Vector3.zero;
						zero.x = Mathf.Lerp(start.x, end.x, num);
						zero.y = Mathf.Lerp(start.y, end.y, num);
						zero.z = Mathf.Lerp(start.z, end.z, num);
						this.mEffectLoader.SetEffectPosition(iIndex, zero);
					}
				}, delegate
				{
					if (null != this.mEffectLoader)
					{
						this.mEffectLoader.SetEffectPosition(iIndex, end);
						this.mEffectLoader.DeActiveEffect(iIndex);
					}
					if (onEnd != null)
					{
						onEnd.Invoke();
					}
				});
			}
		}

		// Token: 0x060110B1 RID: 69809 RVA: 0x004E0F82 File Offset: 0x004DF382
		public void DisableFlyState()
		{
			if (null != this.mEffectFlyState)
			{
				this.mEffectFlyState.Key = this.mStrDisable;
			}
		}

		// Token: 0x060110B2 RID: 69810 RVA: 0x004E0FA8 File Offset: 0x004DF3A8
		public Vector3 GetFlyFixedPosition()
		{
			if (null != this.mFlyFixedItem)
			{
				Vector3 position = this.mFlyFixedItem.transform.position;
				position.z = 0f;
				return position;
			}
			return Vector3.zero;
		}

		// Token: 0x17001D8E RID: 7566
		// (get) Token: 0x060110B3 RID: 69811 RVA: 0x004E0FEA File Offset: 0x004DF3EA
		// (set) Token: 0x060110B4 RID: 69812 RVA: 0x004E0FF2 File Offset: 0x004DF3F2
		public int ActivityFashionMergeBindGoldIndex
		{
			get
			{
				return this._ActivityFashionMergeBindGoldIndex;
			}
			set
			{
				this._ActivityFashionMergeBindGoldIndex = value;
				if (this.mComItemActivityFashionBindGlod == null)
				{
					this.mComItemActivityFashionBindGlod = ComItemManager.Create(this.mGoActivityFashionBindGoldParent);
				}
				this._UpdateBindGoldItem();
			}
		}

		// Token: 0x17001D8F RID: 7567
		// (get) Token: 0x060110B5 RID: 69813 RVA: 0x004E1023 File Offset: 0x004DF423
		// (set) Token: 0x060110B6 RID: 69814 RVA: 0x004E102B File Offset: 0x004DF42B
		public int FashionMergeItemIndex
		{
			get
			{
				return this._FashionMergeItemIndex;
			}
			set
			{
				this._FashionMergeItemIndex = value;
				if (null == this.mComBoxItem)
				{
					this.mComBoxItem = ComItemManager.Create(this.mGoBoxParent);
				}
				this._UpdateMergeBoxItem();
			}
		}

		// Token: 0x17001D90 RID: 7568
		// (get) Token: 0x060110B7 RID: 69815 RVA: 0x004E105C File Offset: 0x004DF45C
		// (set) Token: 0x060110B8 RID: 69816 RVA: 0x004E1063 File Offset: 0x004DF463
		public static ItemData SLValue
		{
			get
			{
				return ComFashionMergeDataBinder.lValue;
			}
			set
			{
				ComFashionMergeDataBinder.lValue = value;
			}
		}

		// Token: 0x17001D91 RID: 7569
		// (get) Token: 0x060110B9 RID: 69817 RVA: 0x004E106B File Offset: 0x004DF46B
		// (set) Token: 0x060110BA RID: 69818 RVA: 0x004E1072 File Offset: 0x004DF472
		public static ItemData SRValue
		{
			get
			{
				return ComFashionMergeDataBinder.rValue;
			}
			set
			{
				ComFashionMergeDataBinder.rValue = value;
			}
		}

		// Token: 0x17001D92 RID: 7570
		// (get) Token: 0x060110BB RID: 69819 RVA: 0x004E107A File Offset: 0x004DF47A
		// (set) Token: 0x060110BC RID: 69820 RVA: 0x004E1081 File Offset: 0x004DF481
		public ItemData LValue
		{
			get
			{
				return ComFashionMergeDataBinder.lValue;
			}
			set
			{
				ComFashionMergeDataBinder.lValue = value;
				this._UpdateSlotStatus();
			}
		}

		// Token: 0x17001D93 RID: 7571
		// (get) Token: 0x060110BD RID: 69821 RVA: 0x004E108F File Offset: 0x004DF48F
		// (set) Token: 0x060110BE RID: 69822 RVA: 0x004E1096 File Offset: 0x004DF496
		public ItemData RValue
		{
			get
			{
				return ComFashionMergeDataBinder.rValue;
			}
			set
			{
				ComFashionMergeDataBinder.rValue = value;
				this._UpdateSlotStatus();
			}
		}

		// Token: 0x060110BF RID: 69823 RVA: 0x004E10A4 File Offset: 0x004DF4A4
		public void SetBindItem(ulong guid)
		{
			try
			{
				if (this.RValue == null || this.RValue.GUID != guid)
				{
					if (this.LValue == null || this.LValue.GUID != guid)
					{
						this.LValue = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("RValue is {0}, LValue is {1},this pointer is {2}, Exception is {3}, ", new object[]
				{
					this.RValue,
					this.LValue,
					this,
					ex.ToString()
				});
			}
		}

		// Token: 0x060110C0 RID: 69824 RVA: 0x004E1150 File Offset: 0x004DF550
		public void PlayNormalSlotEffect(ItemTable.eSubType sub)
		{
			int num = this._GetSlotIDByType(sub);
			if (num < 0 || num >= this.goItemParents.Length)
			{
				return;
			}
			if (null == this.mGoSpecial0)
			{
				this.mGoSpecial0 = (Singleton<AssetLoader>.instance.LoadRes(this.mSpecial0, typeof(GameObject), true, 0U).obj as GameObject);
			}
			if (null != this.mGoSpecial0)
			{
				Utility.AttachTo(this.mGoSpecial0, this.goItemParents[num], false);
			}
			if (null != this.mGoSpecial0)
			{
				this.mGoSpecial0.SetActive(false);
				this.mGoSpecial0.SetActive(true);
			}
		}

		// Token: 0x060110C1 RID: 69825 RVA: 0x004E1208 File Offset: 0x004DF608
		public void PlaySpecialSlotEffect(ItemTable.eSubType sub)
		{
			int num = this._GetSlotIDByType(sub);
			if (num < 0 || num >= this.goItemParents.Length)
			{
				return;
			}
			if (null == this.mGoSpecial1)
			{
				this.mGoSpecial1 = (Singleton<AssetLoader>.instance.LoadRes(this.mSpecial1, typeof(GameObject), true, 0U).obj as GameObject);
			}
			if (null != this.mGoSpecial1)
			{
				Utility.AttachTo(this.mGoSpecial1, this.goItemParents[num], false);
			}
			if (null != this.mGoSpecial1)
			{
				this.mGoSpecial1.SetActive(false);
				this.mGoSpecial1.SetActive(true);
			}
		}

		// Token: 0x060110C2 RID: 69826 RVA: 0x004E12BE File Offset: 0x004DF6BE
		public void ClearSlotValues()
		{
			ComFashionMergeDataBinder.lValue = (ComFashionMergeDataBinder.rValue = null);
			this._UpdateSlotStatus();
		}

		// Token: 0x060110C3 RID: 69827 RVA: 0x004E12D4 File Offset: 0x004DF6D4
		public void PopItemComeLink()
		{
			if (this._FashionMergeItemIndex >= 0 && this._FashionMergeItemIndex < this.FashionMergeBoxIds.Length)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.FashionMergeBoxIds[this._FashionMergeItemIndex], string.Empty, string.Empty);
				if (this._FashionMergeItemIndex == 0)
				{
					this._onFastBuy(tableItem.ID);
				}
				else
				{
					ItemComeLink.OnLink(tableItem.ID, 0, true, null, false, false, false, null, string.Empty);
				}
			}
		}

		// Token: 0x060110C4 RID: 69828 RVA: 0x004E1358 File Offset: 0x004DF758
		public void SetNextMergeBox()
		{
			if (this.FashionMergeBoxIds.Length > 0)
			{
				int fashionMergeItemIndex = (this._FashionMergeItemIndex + 1) % this.FashionMergeBoxIds.Length;
				this.FashionMergeItemIndex = fashionMergeItemIndex;
			}
		}

		// Token: 0x060110C5 RID: 69829 RVA: 0x004E138C File Offset: 0x004DF78C
		private void _UpdateMergeBoxItem()
		{
			if (null != this.mComBoxItem)
			{
				int num = 1;
				int num2;
				if (this._FashionMergeItemIndex < 0 || this._FashionMergeItemIndex >= this.FashionMergeBoxIds.Length)
				{
					this.mComBoxItem.Setup(null, null);
					num2 = 0;
					if (null != this.mBoxItemName)
					{
						this.mBoxItemName.text = string.Empty;
					}
				}
				else
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.FashionMergeBoxIds[this._FashionMergeItemIndex]);
					this.mComBoxItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this._OnMergeBoxClicked));
					num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.FashionMergeBoxIds[this._FashionMergeItemIndex], true);
					if (null != this.mBoxItemName)
					{
						if (commonItemTableDataByID != null)
						{
							this.mBoxItemName.text = commonItemTableDataByID.GetColorName(string.Empty, false);
						}
						else
						{
							this.mBoxItemName.text = string.Empty;
						}
					}
				}
				if (null != this.mComBoxItem)
				{
					this.mComBoxItem.SetEnable(num <= num2);
				}
				if (null != this.mBoxCount)
				{
					this.mBoxCount.text = num2 + "/" + num;
				}
				if (null != this.mBoxCountStatus)
				{
					this.mBoxCountStatus.Key = ((num > num2) ? this.mStrDisable : this.mStrEnable);
				}
			}
		}

		// Token: 0x060110C6 RID: 69830 RVA: 0x004E1518 File Offset: 0x004DF918
		private int GetSlotExpendBindGoldCount()
		{
			for (int i = 0; i < this.mBindGoldCoinList.Count; i++)
			{
				ChangeFashionActivitySlotExpendBindGoldModel changeFashionActivitySlotExpendBindGoldModel = this.mBindGoldCoinList[i];
				if (changeFashionActivitySlotExpendBindGoldModel.mSubType == DataManager<FashionMergeManager>.GetInstance().FashionPart)
				{
					return changeFashionActivitySlotExpendBindGoldModel.mBindGoldCoinsNum;
				}
			}
			return 0;
		}

		// Token: 0x060110C7 RID: 69831 RVA: 0x004E1570 File Offset: 0x004DF970
		private void _UpdateBindGoldItem()
		{
			if (null != this.mComItemActivityFashionBindGlod)
			{
				int slotExpendBindGoldCount = this.GetSlotExpendBindGoldCount();
				int num;
				if (this._ActivityFashionMergeBindGoldIndex < 0 || this._ActivityFashionMergeBindGoldIndex >= this.ActivityFashionMergeBindGolds.Length)
				{
					this.mComItemActivityFashionBindGlod.Setup(null, null);
					num = 0;
				}
				else
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.ActivityFashionMergeBindGolds[this._ActivityFashionMergeBindGoldIndex]);
					this.mComItemActivityFashionBindGlod.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this._OnMergeBoxClicked));
					num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.ActivityFashionMergeBindGolds[this._ActivityFashionMergeBindGoldIndex], false);
				}
				if (null != this.mComItemActivityFashionBindGlod)
				{
					this.mComItemActivityFashionBindGlod.SetEnable(slotExpendBindGoldCount <= num);
				}
				if (null != this.mActivityFashionBindGlodCount)
				{
					this.mActivityFashionBindGlodCount.text = slotExpendBindGoldCount.ToString();
				}
				if (null != this.mActivityFashionBindGlodCountStatus)
				{
					this.mActivityFashionBindGlodCountStatus.Key = ((slotExpendBindGoldCount > num) ? this.mStrDisable : this.mStrEnable);
				}
			}
		}

		// Token: 0x060110C8 RID: 69832 RVA: 0x004E1693 File Offset: 0x004DFA93
		private void _OnMergeBoxClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x060110C9 RID: 69833 RVA: 0x004E16AC File Offset: 0x004DFAAC
		private void _OnSlotItemClicked(GameObject obj, ItemData item)
		{
			if (null != obj)
			{
				bool flag = false;
				while (!flag && null != obj && null != obj.transform.parent)
				{
					flag = (obj == this.goLeftParent);
					obj = obj.transform.parent.gameObject;
				}
				this.AddMergeFashion(flag);
			}
		}

		// Token: 0x060110CA RID: 69834 RVA: 0x004E171C File Offset: 0x004DFB1C
		private int _GetSlotIDByType(ItemTable.eSubType eSubType)
		{
			int result = -1;
			switch (eSubType)
			{
			case ItemTable.eSubType.FASHION_HAIR:
				result = 5;
				break;
			case ItemTable.eSubType.FASHION_HEAD:
				result = 0;
				break;
			case ItemTable.eSubType.FASHION_SASH:
				result = 4;
				break;
			case ItemTable.eSubType.FASHION_CHEST:
				result = 1;
				break;
			case ItemTable.eSubType.FASHION_LEG:
				result = 3;
				break;
			case ItemTable.eSubType.FASHION_EPAULET:
				result = 2;
				break;
			}
			return result;
		}

		// Token: 0x060110CB RID: 69835 RVA: 0x004E177C File Offset: 0x004DFB7C
		public void SetSlotItems(ItemData itemData, ComItem.OnItemClicked callback, ItemTable.eSubType eSubType)
		{
			int num = this._GetSlotIDByType(eSubType);
			if (num < 0 || num >= this.goItemParents.Length)
			{
				Logger.LogErrorFormat("slot id is invalid index is {0} but len = {1}", new object[]
				{
					num,
					this.goItemParents.Length
				});
				return;
			}
			if (null == this.mComItems[num])
			{
				this.mComItems[num] = ComItemManager.Create(this.goItemParents[num]);
			}
			if (null != this.mComItems[num])
			{
				this.mComItems[num].Setup(itemData, callback);
			}
		}

		// Token: 0x060110CC RID: 69836 RVA: 0x004E181C File Offset: 0x004DFC1C
		public void SetSkyMode(FashionType eFashionType)
		{
			this.mFashionType = eFashionType;
			if (null != this.mModelBinder)
			{
				this.mModelBinder.LoadAvatar(DataManager<PlayerBaseData>.GetInstance().JobTableID);
				this.mModelBinder.LoadWeapon();
				List<int> list = ListPool<int>.Get();
				DataManager<FashionMergeManager>.GetInstance().GetFashionItemsByTypeAndOccu(eFashionType, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().SkySuitID, ref list);
				List<ItemData> list2 = new List<ItemData>(list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(list[i]);
					if (commonItemTableDataByID != null)
					{
						list2.Add(commonItemTableDataByID);
					}
				}
				ListPool<int>.Release(list);
				this.mModelBinder.SetFashions(list2);
			}
		}

		// Token: 0x060110CD RID: 69837 RVA: 0x004E18DC File Offset: 0x004DFCDC
		public void SetSkyFashionPart(ItemTable.eSubType eSubType)
		{
			if (this.mFashionPart != eSubType)
			{
				this.ClearSlotValues();
			}
			this.mFashionPart = eSubType;
			if (null != this.mLogicPartSelectNode)
			{
				switch (eSubType)
				{
				case ItemTable.eSubType.FASHION_HAIR:
					this.mLogicPartSelectNode.Key = this.mPartFashionWind;
					break;
				case ItemTable.eSubType.FASHION_HEAD:
					this.mLogicPartSelectNode.Key = this.mPartFashionHead;
					break;
				case ItemTable.eSubType.FASHION_SASH:
					this.mLogicPartSelectNode.Key = this.mPartFashionSash;
					break;
				case ItemTable.eSubType.FASHION_CHEST:
					this.mLogicPartSelectNode.Key = this.mPartFashionChest;
					break;
				case ItemTable.eSubType.FASHION_LEG:
					this.mLogicPartSelectNode.Key = this.mPartFashionLeg;
					break;
				case ItemTable.eSubType.FASHION_EPAULET:
					this.mLogicPartSelectNode.Key = this.mPartFashionEpaulet;
					break;
				}
			}
			this._SyncSkyFashionPartItem(this.mFashionPart);
			this._SyncNormalFashionPartItem(this.mFashionPart);
			if (DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.FASHION_MERGE_AUTO_EQUIP_STATE) == 1)
			{
				this.TryAutoEquipFashion();
			}
		}

		// Token: 0x060110CE RID: 69838 RVA: 0x004E19F0 File Offset: 0x004DFDF0
		public void SetNormalFashionPart(ItemTable.eSubType eSubType)
		{
			this._SyncNormalFashionPartItem(this.mFashionPart);
		}

		// Token: 0x060110CF RID: 69839 RVA: 0x004E1A00 File Offset: 0x004DFE00
		public void SetSlotPart(ItemTable.eSubType eSubType)
		{
			int num = this._GetSlotIDByType(eSubType);
			if (num >= 0 && num < this.mChecks.Length)
			{
				for (int i = 0; i < this.mChecks.Length; i++)
				{
					this.mChecks[i].CustomActive(num == i);
				}
			}
		}

		// Token: 0x060110D0 RID: 69840 RVA: 0x004E1A54 File Offset: 0x004DFE54
		public void SetSkySuitName()
		{
			if (null != this.mSkySuitName)
			{
				string text = string.Empty;
				int fashionByKey = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(DataManager<FashionMergeManager>.GetInstance().FashionType, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().SkySuitID, ItemTable.eSubType.FASHION_HEAD);
				FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(fashionByKey, string.Empty, string.Empty);
				if (tableItem != null)
				{
					text = tableItem.SuitName;
				}
				this.mSkySuitName.text = text;
			}
		}

		// Token: 0x060110D1 RID: 69841 RVA: 0x004E1AD4 File Offset: 0x004DFED4
		public void ForceUpdateSkyStatus()
		{
			for (int i = 0; i < this.mTypeRelationSkyStatus.Length; i++)
			{
				StateController stateController = this.mTypeRelationSkyStatus[i];
				if (!(null == stateController))
				{
					if (this.mFashionType == FashionType.FT_SKY)
					{
						if (i < this.skySlotValues.Length)
						{
							stateController.Key = ((this.skySlotValues[i] != 1) ? this.mStrDisable : this.mStrEnable);
						}
					}
					else if (this.mFashionType == FashionType.FT_GOLD_SKY)
					{
						if (i < this.goldSkySlotValues.Length)
						{
							stateController.Key = ((this.goldSkySlotValues[i] != 1) ? this.mStrDisable : this.mStrEnable);
						}
					}
					else if (this.mFashionType == FashionType.FT_NATIONALDAY && i < this.nationalDaySlotValues.Length)
					{
						stateController.Key = ((this.nationalDaySlotValues[i] != 1) ? this.mStrDisable : this.mStrEnable);
					}
				}
			}
		}

		// Token: 0x060110D2 RID: 69842 RVA: 0x004E1BDF File Offset: 0x004DFFDF
		public void UpdateSkyStatus()
		{
			this._UpdateSkyStatus();
		}

		// Token: 0x060110D3 RID: 69843 RVA: 0x004E1BE8 File Offset: 0x004DFFE8
		public void UpdateSlotSkyStatus(ItemTable.eSubType eSubType)
		{
			int num = this._GetSlotIDByType(eSubType);
			if (num >= 0 && num < this.goldSkySlotValues.Length)
			{
				this.goldSkySlotValues[num] = 0;
			}
			if (num >= 0 && num < this.skySlotValues.Length)
			{
				this.skySlotValues[num] = 0;
			}
			this._AssignSpecificSkyValue(DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Fashion, eSubType));
			this._AssignSpecificSkyValue(DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.WearFashion, eSubType));
			if (num >= 0 && num < this.skySlotValues.Length && num < this.mSkyStatus.Length && null != this.mSkyStatus[num])
			{
				this.mSkyStatus[num].Key = ((this.skySlotValues[num] != 1) ? this.mStrDisable : this.mStrEnable);
			}
			if (num >= 0 && num < this.goldSkySlotValues.Length && num < this.mGoldSkyStatus.Length && null != this.mGoldSkyStatus[num])
			{
				this.mGoldSkyStatus[num].Key = ((this.goldSkySlotValues[num] != 1) ? this.mStrDisable : this.mStrEnable);
			}
		}

		// Token: 0x060110D4 RID: 69844 RVA: 0x004E1D24 File Offset: 0x004E0124
		private void _SyncSkyFashionPartItem(ItemTable.eSubType eSubType)
		{
			ItemData item = null;
			int fashionByKey;
			if (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				fashionByKey = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(FashionType.FT_NATIONALDAY, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().SkySuitID, eSubType);
			}
			else
			{
				fashionByKey = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(FashionType.FT_SKY, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().SkySuitID, eSubType);
			}
			if (fashionByKey != 0)
			{
				item = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(fashionByKey);
			}
			if (null == this.mComItemPreview)
			{
				this.mComItemPreview = ComItemManager.Create(this.mGoPreviewParent);
			}
			if (null != this.mComItemPreview)
			{
				this.mComItemPreview.Setup(item, new ComItem.OnItemClicked(this._OnFashionPartItemClicked));
			}
		}

		// Token: 0x060110D5 RID: 69845 RVA: 0x004E1DF8 File Offset: 0x004E01F8
		private void _SyncNormalFashionPartItem(ItemTable.eSubType eSubType)
		{
			ItemData item = null;
			int fashionByKey = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(FashionType.FT_NORMAL, DataManager<PlayerBaseData>.GetInstance().JobTableID, DataManager<FashionMergeManager>.GetInstance().NormalSuitID, eSubType);
			if (fashionByKey != 0)
			{
				item = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(fashionByKey);
			}
			if (null == this.mComItemNormalPreview)
			{
				this.mComItemNormalPreview = ComItemManager.Create(this.mGoNormalPreviewParent);
			}
			if (null != this.mComItemNormalPreview)
			{
				this.mComItemNormalPreview.Setup(item, new ComItem.OnItemClicked(this._OnNormalFashionPartItemClicked));
			}
		}

		// Token: 0x060110D6 RID: 69846 RVA: 0x004E1E88 File Offset: 0x004E0288
		private void _OnNormalFashionPartItemClicked(GameObject obj, ItemData item)
		{
			if (item == null)
			{
				return;
			}
			List<ItemData> list = new List<ItemData>();
			int num = 1;
			int num2 = 1;
			while (num2 != 0)
			{
				num2 = DataManager<FashionMergeManager>.GetInstance().GetFashionByKey(FashionType.FT_NORMAL, DataManager<PlayerBaseData>.GetInstance().JobTableID, num, (ItemTable.eSubType)item.SubType);
				if (num2 != 0)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(num2);
					if (commonItemTableDataByID != null)
					{
						list.Add(commonItemTableDataByID);
					}
				}
				num++;
			}
			list.Sort(delegate(ItemData x, ItemData y)
			{
				if (x.Quality != y.Quality)
				{
					return x.Quality - y.Quality;
				}
				return x.TableID - y.TableID;
			});
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionAvatarSeleteFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x060110D7 RID: 69847 RVA: 0x004E1F26 File Offset: 0x004E0326
		private void _OnFashionPartItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x060110D8 RID: 69848 RVA: 0x004E1F3E File Offset: 0x004E033E
		public bool IsWindUnLock()
		{
			if (this.mFashionType == FashionType.FT_SKY)
			{
				return this.skySlotValues[this.windIndex] == 1;
			}
			return this.goldSkySlotValues[this.windIndex] == 1;
		}

		// Token: 0x060110D9 RID: 69849 RVA: 0x004E1F70 File Offset: 0x004E0370
		private void Awake()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNormalFashionSelected, new ClientEventSystem.UIEventHandler(this._OnNormalFashionSelected));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnConfirmToFashionMerge, new ClientEventSystem.UIEventHandler(this._OnConfirmToFashionMerge));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionMergeRedCounChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionFastItemBuyFinished, new ClientEventSystem.UIEventHandler(this.OnFashionFastItemBuyFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionNormalItemSelected, new ClientEventSystem.UIEventHandler(this.OnFashionNormalItemSelected));
		}

		// Token: 0x060110DA RID: 69850 RVA: 0x004E209C File Offset: 0x004E049C
		private void Start()
		{
			this._UpdateSkyStatus();
			this._UpdateSlotStatus();
			if (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				this.ActivityFashionMergeBindGoldIndex = 0;
				this.FashionMergeItemIndex = 1;
			}
			else
			{
				this.FashionMergeItemIndex = 0;
			}
		}

		// Token: 0x060110DB RID: 69851 RVA: 0x004E20E8 File Offset: 0x004E04E8
		private void _AssignSpecificSkyValue(List<ulong> guids)
		{
			if (guids != null)
			{
				for (int i = 0; i < guids.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guids[i]);
					if (item != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							int num = this._GetSlotIDByType(tableItem.SubType);
							if (num >= 0 && num < this.skySlotValues.Length && num < this.goldSkySlotValues.Length)
							{
								FashionComposeSkyTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(tableItem.ID, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									if (tableItem2.Occu == DataManager<PlayerBaseData>.GetInstance().JobTableID / 10)
									{
										if (tableItem2.Type == 1)
										{
											this.skySlotValues[num] = 1;
										}
										else if (tableItem2.Type == 2)
										{
											this.goldSkySlotValues[num] = 1;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060110DC RID: 69852 RVA: 0x004E2204 File Offset: 0x004E0604
		private void _AssignSkyValues(List<ulong> guids)
		{
			if (guids != null)
			{
				for (int i = 0; i < guids.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guids[i]);
					if (item != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							int num = this._GetSlotIDByType(tableItem.SubType);
							if (num >= 0 && num < this.skySlotValues.Length && num < this.goldSkySlotValues.Length)
							{
								FashionComposeSkyTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(tableItem.ID, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									if (tableItem2.Occu == DataManager<PlayerBaseData>.GetInstance().JobTableID / 10)
									{
										if (tableItem2.Type == 1)
										{
											this.skySlotValues[num] = 1;
										}
										else if (tableItem2.Type == 2)
										{
											this.goldSkySlotValues[num] = 1;
										}
										else if (tableItem2.Type == 10000)
										{
											this.nationalDaySlotValues[num] = 1;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060110DD RID: 69853 RVA: 0x004E233C File Offset: 0x004E073C
		private void _UpdateSkyStatus()
		{
			for (int i = 0; i < this.goldSkySlotValues.Length; i++)
			{
				this.goldSkySlotValues[i] = 0;
			}
			for (int j = 0; j < this.skySlotValues.Length; j++)
			{
				this.skySlotValues[j] = 0;
			}
			for (int k = 0; k < this.nationalDaySlotValues.Length; k++)
			{
				this.nationalDaySlotValues[k] = 0;
			}
			this._AssignSkyValues(DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Fashion));
			this._AssignSkyValues(DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion));
			int num = 0;
			while (num < this.mSkyStatus.Length && num < this.skySlotValues.Length)
			{
				if (null != this.mSkyStatus[num])
				{
					this.mSkyStatus[num].Key = ((this.skySlotValues[num] != 1) ? this.mStrDisable : this.mStrEnable);
				}
				num++;
			}
			int num2 = 0;
			while (num2 < this.mGoldSkyStatus.Length && num2 < this.goldSkySlotValues.Length)
			{
				if (null != this.mGoldSkyStatus[num2])
				{
					this.mGoldSkyStatus[num2].Key = ((this.goldSkySlotValues[num2] != 1) ? this.mStrDisable : this.mStrEnable);
				}
				num2++;
			}
			if (null != this.mWindStatus && this.mFashionType != FashionType.FT_NATIONALDAY)
			{
				if (this.mFashionType == FashionType.FT_SKY)
				{
					this.mWindStatus.Key = ((this.skySlotValues[this.windIndex] != 1) ? this.mStrDisable : this.mStrEnable);
				}
				else
				{
					this.mWindStatus.Key = ((this.goldSkySlotValues[this.windIndex] != 1) ? this.mStrDisable : this.mStrEnable);
				}
			}
		}

		// Token: 0x060110DE RID: 69854 RVA: 0x004E2538 File Offset: 0x004E0938
		public void AddFashionToMerge()
		{
			if (this.kEquipments == null)
			{
				this.kEquipments = new List<ItemData>();
			}
			ComFashionMergeItemEx.LoadAllEquipments(ref this.kEquipments, this.mFashionPart, this.isLeftPos, true);
			if (this.kEquipments.Count <= 0)
			{
				return;
			}
			if (this.mLeft)
			{
				this.LValue = this.kEquipments[0];
				if (null != this.mEffectLoader)
				{
					this.mEffectLoader.DeActiveEffect(12);
					this.mEffectLoader.LoadEffect(12);
					this.mEffectLoader.ActiveEffect(12);
				}
			}
			else
			{
				this.RValue = this.kEquipments[0];
				if (null != this.mEffectLoader)
				{
					this.mEffectLoader.DeActiveEffect(13);
					this.mEffectLoader.LoadEffect(13);
					this.mEffectLoader.ActiveEffect(13);
				}
			}
		}

		// Token: 0x060110DF RID: 69855 RVA: 0x004E262C File Offset: 0x004E0A2C
		public void TryAutoEquipFashion()
		{
			if (this.kEquipments == null)
			{
				this.kEquipments = new List<ItemData>();
			}
			ComFashionMergeItemEx.LoadAllEquipments(ref this.kEquipments, this.mFashionPart, true, true);
			if (this.kEquipments == null)
			{
				return;
			}
			int i = 0;
			while (i < this.kEquipments.Count)
			{
				ItemData itemData = this.kEquipments[i];
				if (itemData == null || itemData.bFashionItemLocked)
				{
					this.kEquipments.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				if (this.LValue == null && this.kEquipments.Count > 0 && (this.RValue == null || this.kEquipments[0].GUID != this.RValue.GUID))
				{
					this.LValue = this.kEquipments[0];
					if (null != this.mEffectLoader)
					{
						this.mEffectLoader.DeActiveEffect(12);
						this.mEffectLoader.LoadEffect(12);
						this.mEffectLoader.ActiveEffect(12);
					}
				}
				if (this.RValue == null && this.kEquipments.Count > 1 && (this.LValue == null || this.kEquipments[1].GUID != this.LValue.GUID))
				{
					this.RValue = this.kEquipments[1];
					if (null != this.mEffectLoader)
					{
						this.mEffectLoader.DeActiveEffect(13);
						this.mEffectLoader.LoadEffect(13);
						this.mEffectLoader.ActiveEffect(13);
					}
				}
			}
			else if (this.LValue == null && this.kEquipments.Count > 0)
			{
				this.LValue = this.kEquipments[0];
				if (null != this.mEffectLoader)
				{
					this.mEffectLoader.DeActiveEffect(12);
					this.mEffectLoader.LoadEffect(12);
					this.mEffectLoader.ActiveEffect(12);
				}
			}
		}

		// Token: 0x060110E0 RID: 69856 RVA: 0x004E2864 File Offset: 0x004E0C64
		public void AddMergeFashion(bool bLeft)
		{
			this.isLeftPos = bLeft;
			this.mLeft = bLeft;
			FashionItemSelectedType userData = new FashionItemSelectedType
			{
				FashionPart = this.mFashionPart,
				IsLeft = bLeft
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeNewItemFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x060110E1 RID: 69857 RVA: 0x004E28AC File Offset: 0x004E0CAC
		private void _UpdateSlotStatus()
		{
			if (ComFashionMergeDataBinder.lValue != null)
			{
				ComFashionMergeDataBinder.lValue = DataManager<ItemDataManager>.GetInstance().GetItem(ComFashionMergeDataBinder.lValue.GUID);
			}
			if (ComFashionMergeDataBinder.lValue != null && !Utility._CheckFashionCanMerge(ComFashionMergeDataBinder.lValue.GUID))
			{
				ComFashionMergeDataBinder.lValue = null;
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				if (ComFashionMergeDataBinder.rValue != null)
				{
					ComFashionMergeDataBinder.rValue = DataManager<ItemDataManager>.GetInstance().GetItem(ComFashionMergeDataBinder.rValue.GUID);
				}
				if (ComFashionMergeDataBinder.rValue != null && !Utility._CheckFashionCanMerge(ComFashionMergeDataBinder.rValue.GUID))
				{
					ComFashionMergeDataBinder.rValue = null;
				}
			}
			if (null != this.mLSlotStatus)
			{
				if (ComFashionMergeDataBinder.lValue == null)
				{
					this.mLSlotStatus.Key = this.mStrDisable;
				}
				else
				{
					this.mLSlotStatus.Key = this.mStrEnable;
				}
			}
			if (null == this.leftSlot)
			{
				this.leftSlot = ComItemManager.Create(this.goLeftParent);
			}
			if (null != this.leftSlot)
			{
				if (this.LValue != null)
				{
					this.leftSlot.Setup(this.LValue, new ComItem.OnItemClicked(this._OnSlotItemClicked));
				}
				else
				{
					this.leftSlot.Setup(null, null);
				}
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				if (null != this.mRSlotStatus)
				{
					if (ComFashionMergeDataBinder.rValue == null)
					{
						this.mRSlotStatus.Key = this.mStrDisable;
					}
					else
					{
						this.mRSlotStatus.Key = this.mStrEnable;
					}
				}
				if (null == this.rightSlot)
				{
					this.rightSlot = ComItemManager.Create(this.goRightParent);
				}
				if (null != this.rightSlot)
				{
					if (this.RValue != null)
					{
						this.rightSlot.Setup(this.RValue, new ComItem.OnItemClicked(this._OnSlotItemClicked));
					}
					else
					{
						this.rightSlot.Setup(null, null);
					}
				}
			}
		}

		// Token: 0x060110E2 RID: 69858 RVA: 0x004E2AD7 File Offset: 0x004E0ED7
		public void UpdateSlotItems()
		{
			this._UpdateSlotStatus();
		}

		// Token: 0x060110E3 RID: 69859 RVA: 0x004E2AE0 File Offset: 0x004E0EE0
		private void OnDestroy()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNormalFashionSelected, new ClientEventSystem.UIEventHandler(this._OnNormalFashionSelected));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnConfirmToFashionMerge, new ClientEventSystem.UIEventHandler(this._OnConfirmToFashionMerge));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionMergeRedCounChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionFastItemBuyFinished, new ClientEventSystem.UIEventHandler(this.OnFashionFastItemBuyFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionNormalItemSelected, new ClientEventSystem.UIEventHandler(this.OnFashionNormalItemSelected));
			if (null != this.mEffectLoader)
			{
				InvokeMethod.RmoveInvokeIntervalCall(this.mEffectLoader);
			}
			for (int i = 0; i < this.mComItems.Length; i++)
			{
				if (null != this.mComItems[i])
				{
					ComItemManager.Destroy(this.mComItems[i]);
					this.mComItems[i] = null;
				}
			}
			if (null != this.mComItemPreview)
			{
				ComItemManager.Destroy(this.mComItemPreview);
				this.mComItemPreview = null;
			}
			if (null != this.mComItemNormalPreview)
			{
				ComItemManager.Destroy(this.mComItemNormalPreview);
				this.mComItemNormalPreview = null;
			}
			if (null != this.mComBoxItem)
			{
				ComItemManager.Destroy(this.mComBoxItem);
				this.mComBoxItem = null;
			}
			if (null != this.leftSlot)
			{
				ComItemManager.Destroy(this.leftSlot);
				this.leftSlot = null;
			}
			if (null != this.rightSlot)
			{
				ComItemManager.Destroy(this.rightSlot);
				this.rightSlot = null;
			}
			if (this.mIntialized)
			{
				this.mIntialized = false;
			}
			if (this.kEquipments != null)
			{
				this.kEquipments.Clear();
				this.kEquipments = null;
			}
		}

		// Token: 0x060110E4 RID: 69860 RVA: 0x004E2D48 File Offset: 0x004E1148
		private bool _CheckMerge(bool bNeedMsg)
		{
			if (this.LValue == null)
			{
				this.AddMergeFashion(true);
				return false;
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				if (this.RValue == null)
				{
					this.AddMergeFashion(false);
					return false;
				}
			}
			else
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.ActivityFashionMergeBindGolds[this._ActivityFashionMergeBindGoldIndex]);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.ActivityFashionMergeBindGolds[this._ActivityFashionMergeBindGoldIndex], true);
				int slotExpendBindGoldCount = this.GetSlotExpendBindGoldCount();
				if (ownedItemCount < slotExpendBindGoldCount)
				{
					string format = "{0}不足，请前往获取";
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(format, commonItemTableDataByID.GetColorName(string.Empty, false)), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return false;
				}
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Fashion);
			int num = 0;
			if (itemsByPackageType != null)
			{
				num = itemsByPackageType.Count;
			}
			if (DataManager<PlayerBaseData>.GetInstance().PackTotalSize[5] < num + this.mGridKeep)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fashionMerge_grid_is_not_enough", this.mGridKeep), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (null == this.mComBoxItem || this.mComBoxItem.ItemData == null)
			{
				Logger.LogErrorFormat("comBoxItem or itemdata is null !!!", new object[0]);
				return false;
			}
			if (null == this.mComItemNormalPreview || this.mComItemNormalPreview.ItemData == null)
			{
				Logger.LogErrorFormat("mComItemNormalPreview or itemdata is null !!!", new object[0]);
				return false;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeTable>(this.mComItemNormalPreview.ItemData.TableID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("suitId is invalid with tableid = {0}", new object[]
				{
					this.mComItemNormalPreview.ItemData.TableID
				});
				return false;
			}
			if (null == this.mComItemPreview || this.mComItemPreview.ItemData == null)
			{
				Logger.LogErrorFormat("skyTypeId is invalid with tableid = {0}", new object[]
				{
					this.mComItemPreview.ItemData.TableID
				});
				return false;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(this.mComItemPreview.ItemData.TableID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("skyTypeId is invalid with tableid = {0} can not find in FashionComposeSkyTable !!!", new object[]
				{
					this.mComItemPreview.ItemData.TableID
				});
				return false;
			}
			int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mComBoxItem.ItemData.TableID, true);
			int num2 = 1;
			if (ownedItemCount2 < num2)
			{
				if (bNeedMsg)
				{
					if (this._FashionMergeItemIndex == 0)
					{
						this._onFastBuy(this.mComBoxItem.ItemData.TableID);
					}
					else
					{
						ItemComeLink.OnLink(this.mComBoxItem.ItemData.TableID, 0, true, null, false, false, false, null, string.Empty);
					}
				}
				return false;
			}
			if (DataManager<ItemDataManager>.GetInstance().GetItemByTableID(this.mComBoxItem.ItemData.TableID, true, true) == null)
			{
				Logger.LogErrorFormat("can not find merge item !!! for table id = {0}", new object[]
				{
					this.mComBoxItem.ItemData.TableID
				});
				return false;
			}
			return true;
		}

		// Token: 0x060110E5 RID: 69861 RVA: 0x004E307C File Offset: 0x004E147C
		public void OnStopMerge()
		{
			if (null != this.mMergeState)
			{
				this.mMergeState.Key = this.mStrEnable;
			}
			if (null != this.mEffectState)
			{
				this.mEffectState.Key = this.mStrEnable;
			}
		}

		// Token: 0x060110E6 RID: 69862 RVA: 0x004E30CD File Offset: 0x004E14CD
		public void EnableMergeState()
		{
			if (null != this.mMergeState)
			{
				this.mMergeState.Key = this.mStrEnable;
			}
		}

		// Token: 0x060110E7 RID: 69863 RVA: 0x004E30F4 File Offset: 0x004E14F4
		public void OnClickMergeFashion()
		{
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				this.OnMergeFashionClick();
			}
			else
			{
				if (this.LValue == null)
				{
					this.AddMergeFashion(true);
					return;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mComBoxItem.ItemData.TableID, true);
				int num = 1;
				if (ownedItemCount < num)
				{
					ItemComeLink.OnLink(this.mComBoxItem.ItemData.TableID, 0, true, null, false, false, false, null, string.Empty);
					return;
				}
				int nCount = 0;
				ChangeFashionActiveMergeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChangeFashionActiveMergeTable>(this.mComItemNormalPreview.ItemData.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string[] array = tableItem.GoldConsume.Split(new char[]
					{
						'_'
					});
					if (array.Length > 0)
					{
						int.TryParse(array[1], out nCount);
					}
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				costInfo.nCount = nCount;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					this.OnMergeFashionClick();
				}, "common_money_cost", null);
			}
		}

		// Token: 0x060110E8 RID: 69864 RVA: 0x004E321C File Offset: 0x004E161C
		private void OnMergeFashionClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (!this._CheckMerge(true))
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(this.mComItemPreview.ItemData.TableID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("skyTypeId is invalid with tableid = {0} can not find in FashionComposeSkyTable !!!", new object[]
				{
					this.mComItemPreview.ItemData.TableID
				});
				return;
			}
			if (DataManager<ItemDataManager>.GetInstance().GetItemByTableID(this.mComBoxItem.ItemData.TableID, true, true) == null)
			{
				Logger.LogErrorFormat("can not find merge item !!! for table id = {0}", new object[]
				{
					this.mComBoxItem.ItemData.TableID
				});
				return;
			}
			string empty = string.Empty;
			if (!this._HasNeedNotifyFashions(ref empty))
			{
				this._OnConfirmToMerge();
				return;
			}
			SystemNotifyManager.SystemNotify(7029, null, new UnityAction(this._OnConfirmToMerge), new object[]
			{
				empty
			});
		}

		// Token: 0x060110E9 RID: 69865 RVA: 0x004E3324 File Offset: 0x004E1724
		private bool _HasNeedNotifyFashions(ref string ret)
		{
			bool result = false;
			if (this.LValue != null && ComFashionMergeDataBinder.lValue.ThirdType == ItemTable.eThirdType.FASHION_FESTIVAL)
			{
				result = true;
				if (ret != null)
				{
					ret = this.LValue.GetColorName(string.Empty, false);
				}
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType) && this.RValue != null && this.RValue.ThirdType == ItemTable.eThirdType.FASHION_FESTIVAL)
			{
				result = true;
				if (string.IsNullOrEmpty(ret))
				{
					ret = this.RValue.GetColorName(string.Empty, false);
				}
				else
				{
					ret = ret + "、" + this.RValue.GetColorName(string.Empty, false);
				}
			}
			return result;
		}

		// Token: 0x060110EA RID: 69866 RVA: 0x004E33E8 File Offset: 0x004E17E8
		private void _OnConfirmToMerge()
		{
			if (null != this.mEffectState)
			{
				this.mEffectState.Key = this.mStrEnable;
			}
			if (null != this.mMergeState)
			{
				this.mMergeState.Key = this.mStrDisable;
			}
		}

		// Token: 0x060110EB RID: 69867 RVA: 0x004E3439 File Offset: 0x004E1839
		private void _OnAddNewItem(List<Item> items)
		{
			this._UpdateMergeBoxItem();
			this._UpdateSlotStatus();
		}

		// Token: 0x060110EC RID: 69868 RVA: 0x004E3447 File Offset: 0x004E1847
		private void _OnRemoveItem(ItemData data)
		{
			this._UpdateMergeBoxItem();
			this._UpdateSlotStatus();
		}

		// Token: 0x060110ED RID: 69869 RVA: 0x004E3455 File Offset: 0x004E1855
		private void _OnUpdateItem(List<Item> items)
		{
			this._UpdateMergeBoxItem();
			this._UpdateSlotStatus();
		}

		// Token: 0x060110EE RID: 69870 RVA: 0x004E3463 File Offset: 0x004E1863
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._UpdateBindGoldItem();
		}

		// Token: 0x060110EF RID: 69871 RVA: 0x004E346C File Offset: 0x004E186C
		private void _OnNormalFashionSelected(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (itemData != null && null != this.mComItemNormalPreview)
			{
				this.mComItemNormalPreview.Setup(itemData, new ComItem.OnItemClicked(this._OnNormalFashionPartItemClicked));
			}
		}

		// Token: 0x060110F0 RID: 69872 RVA: 0x004E34B4 File Offset: 0x004E18B4
		private void _OnConfirmToFashionMerge(UIEvent uiEvent)
		{
			if (!this._CheckMerge(false))
			{
				return;
			}
			FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(this.mComItemPreview.ItemData.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("skyTypeId is invalid with tableid = {0} can not find in FashionComposeSkyTable !!!", new object[]
				{
					this.mComItemPreview.ItemData.TableID
				});
				return;
			}
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(this.mComBoxItem.ItemData.TableID, false, true);
			if (itemByTableID == null)
			{
				Logger.LogErrorFormat("can not find merge item !!! for table id = {0}", new object[]
				{
					this.mComBoxItem.ItemData.TableID
				});
				return;
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				DataManager<FashionMergeManager>.GetInstance().SendFashionMerge(this.LValue.GUID, this.RValue.GUID, itemByTableID.GUID, tableItem.SuitID, this.mComItemNormalPreview.ItemData.TableID);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(500953U, new Action<MsgDATA>(DataManager<FashionMergeManager>.GetInstance().OnRecvSceneFashionMergeRes), true, 15f, new Action(this._onFashionMergeTimeOut));
			}
			else
			{
				DataManager<FashionMergeManager>.GetInstance().SendChangeFashionMerge(this.LValue.GUID, itemByTableID.GUID, (uint)this.mComItemNormalPreview.ItemData.TableID);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(501030U, new Action<MsgDATA>(DataManager<FashionMergeManager>.GetInstance().OnRecvSceneFashionChangeActiveMergeRet), true, 15f, new Action(this._onFashionMergeTimeOut));
			}
		}

		// Token: 0x060110F1 RID: 69873 RVA: 0x004E3657 File Offset: 0x004E1A57
		private void _onFashionMergeTimeOut()
		{
			this.EnableMergeState();
		}

		// Token: 0x060110F2 RID: 69874 RVA: 0x004E3660 File Offset: 0x004E1A60
		private void _onFastBuy(int id)
		{
			WorldGetMallItemByItemIdReq worldGetMallItemByItemIdReq = new WorldGetMallItemByItemIdReq();
			worldGetMallItemByItemIdReq.itemId = (uint)id;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, worldGetMallItemByItemIdReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(delegate(WorldGetMallItemByItemIdRes msgRet)
			{
				MallItemInfo mallItem = msgRet.mallItem;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItem, string.Empty);
			}, false, 15f, null);
		}

		// Token: 0x060110F3 RID: 69875 RVA: 0x004E36B8 File Offset: 0x004E1AB8
		private void OnFashionNormalItemSelected(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			ComFashionMergeItemEx comFashionMergeItemEx = uiEvent.Param1 as ComFashionMergeItemEx;
			if (null != comFashionMergeItemEx)
			{
				if (this.mLeft)
				{
					this.LValue = comFashionMergeItemEx.ItemData;
					if (null != this.mEffectLoader)
					{
						this.mEffectLoader.DeActiveEffect(12);
						this.mEffectLoader.LoadEffect(12);
						this.mEffectLoader.ActiveEffect(12);
					}
				}
				else
				{
					this.RValue = comFashionMergeItemEx.ItemData;
					if (null != this.mEffectLoader)
					{
						this.mEffectLoader.DeActiveEffect(13);
						this.mEffectLoader.LoadEffect(13);
						this.mEffectLoader.ActiveEffect(13);
					}
				}
			}
		}

		// Token: 0x060110F4 RID: 69876 RVA: 0x004E377E File Offset: 0x004E1B7E
		private void OnFashionFastItemBuyFinished(UIEvent uiEvent)
		{
			this.AddFashionToMerge();
		}

		// Token: 0x0400AF68 RID: 44904
		public GameObject[] goItemParents = new GameObject[0];

		// Token: 0x0400AF69 RID: 44905
		public StateController mWindStatus;

		// Token: 0x0400AF6A RID: 44906
		public StateController mMergeState;

		// Token: 0x0400AF6B RID: 44907
		public StateController[] mSkyStatus = new StateController[0];

		// Token: 0x0400AF6C RID: 44908
		public StateController[] mGoldSkyStatus = new StateController[0];

		// Token: 0x0400AF6D RID: 44909
		public StateController[] mTypeRelationSkyStatus = new StateController[0];

		// Token: 0x0400AF6E RID: 44910
		public GameObject[] mChecks = new GameObject[0];

		// Token: 0x0400AF6F RID: 44911
		private byte[] goldSkySlotValues = new byte[6];

		// Token: 0x0400AF70 RID: 44912
		private byte[] skySlotValues = new byte[6];

		// Token: 0x0400AF71 RID: 44913
		private byte[] nationalDaySlotValues = new byte[5];

		// Token: 0x0400AF72 RID: 44914
		public byte[] fashionAvatarDefaultTypes = new byte[6];

		// Token: 0x0400AF73 RID: 44915
		private int windIndex = 5;

		// Token: 0x0400AF74 RID: 44916
		private string mStrEnable = "Enable";

		// Token: 0x0400AF75 RID: 44917
		private string mStrDisable = "Disable";

		// Token: 0x0400AF76 RID: 44918
		public StateController mLogicPartSelectNode;

		// Token: 0x0400AF77 RID: 44919
		private string mPartFashionWind = "wind";

		// Token: 0x0400AF78 RID: 44920
		private string mPartFashionHead = "head";

		// Token: 0x0400AF79 RID: 44921
		private string mPartFashionSash = "sash";

		// Token: 0x0400AF7A RID: 44922
		private string mPartFashionChest = "chest";

		// Token: 0x0400AF7B RID: 44923
		private string mPartFashionLeg = "leg";

		// Token: 0x0400AF7C RID: 44924
		private string mPartFashionEpaulet = "epaulet";

		// Token: 0x0400AF7D RID: 44925
		public StateController mEffectState;

		// Token: 0x0400AF7E RID: 44926
		public ComEffectLoader mEffectLoader;

		// Token: 0x0400AF7F RID: 44927
		public StateController mEffectFlyState;

		// Token: 0x0400AF80 RID: 44928
		public GameObject mFlyFixedItem;

		// Token: 0x0400AF81 RID: 44929
		public float mFlyLength = 1.2f;

		// Token: 0x0400AF82 RID: 44930
		public UnityEvent mOnFlyStart;

		// Token: 0x0400AF83 RID: 44931
		public float mFadeLength = 0.8f;

		// Token: 0x0400AF84 RID: 44932
		public float mFlightLength = 0.8f;

		// Token: 0x0400AF85 RID: 44933
		public UnityEvent mOnFlightStart;

		// Token: 0x0400AF86 RID: 44934
		public int mGridKeep = 3;

		// Token: 0x0400AF87 RID: 44935
		public Text windProcess;

		// Token: 0x0400AF88 RID: 44936
		public string windProcessString = "{0}/{1}";

		// Token: 0x0400AF89 RID: 44937
		public UnityEvent mOnRedPointOn;

		// Token: 0x0400AF8A RID: 44938
		public UnityEvent mOnRedPointOff;

		// Token: 0x0400AF8B RID: 44939
		public Text mRedCount;

		// Token: 0x0400AF8C RID: 44940
		private bool isLeftPos = true;

		// Token: 0x0400AF8D RID: 44941
		public string mPopContent = string.Empty;

		// Token: 0x0400AF8E RID: 44942
		public string mSpecial0 = "Effects/UI/Prefab/EffUI_shizhuanghecheng/Prefab/EffUI_shizhuanghecheng_qianruzi";

		// Token: 0x0400AF8F RID: 44943
		private GameObject mGoSpecial0;

		// Token: 0x0400AF90 RID: 44944
		public string mSpecial1 = "Effects/UI/Prefab/EffUI_shizhuanghecheng/Prefab/EffUI_shizhuanghecheng_qianrufen";

		// Token: 0x0400AF91 RID: 44945
		private GameObject mGoSpecial1;

		// Token: 0x0400AF92 RID: 44946
		private ComItem[] mComItems = new ComItem[6];

		// Token: 0x0400AF93 RID: 44947
		public GameObject mGoPreviewParent;

		// Token: 0x0400AF94 RID: 44948
		private ComItem mComItemPreview;

		// Token: 0x0400AF95 RID: 44949
		public GameObject mGoNormalPreviewParent;

		// Token: 0x0400AF96 RID: 44950
		private ComItem mComItemNormalPreview;

		// Token: 0x0400AF97 RID: 44951
		public GameObject mGoActivityFashionBindGoldParent;

		// Token: 0x0400AF98 RID: 44952
		private ComItem mComItemActivityFashionBindGlod;

		// Token: 0x0400AF99 RID: 44953
		public StateController mActivityFashionBindGlodCountStatus;

		// Token: 0x0400AF9A RID: 44954
		public Text mActivityFashionBindGlodCount;

		// Token: 0x0400AF9B RID: 44955
		public List<ChangeFashionActivitySlotExpendBindGoldModel> mBindGoldCoinList = new List<ChangeFashionActivitySlotExpendBindGoldModel>();

		// Token: 0x0400AF9C RID: 44956
		public GameObject mGoBoxParent;

		// Token: 0x0400AF9D RID: 44957
		private ComItem mComBoxItem;

		// Token: 0x0400AF9E RID: 44958
		public StateController mBoxCountStatus;

		// Token: 0x0400AF9F RID: 44959
		public Text mBoxCount;

		// Token: 0x0400AFA0 RID: 44960
		public Text mBoxItemName;

		// Token: 0x0400AFA1 RID: 44961
		public int[] ActivityFashionMergeBindGolds = new int[0];

		// Token: 0x0400AFA2 RID: 44962
		private int _ActivityFashionMergeBindGoldIndex;

		// Token: 0x0400AFA3 RID: 44963
		public int[] FashionMergeBoxIds = new int[0];

		// Token: 0x0400AFA4 RID: 44964
		private int _FashionMergeItemIndex;

		// Token: 0x0400AFA5 RID: 44965
		public StateController mLSlotStatus;

		// Token: 0x0400AFA6 RID: 44966
		public StateController mRSlotStatus;

		// Token: 0x0400AFA7 RID: 44967
		private ComItem leftSlot;

		// Token: 0x0400AFA8 RID: 44968
		private ComItem rightSlot;

		// Token: 0x0400AFA9 RID: 44969
		public GameObject goLeftParent;

		// Token: 0x0400AFAA RID: 44970
		public GameObject goRightParent;

		// Token: 0x0400AFAB RID: 44971
		private static ItemData lValue;

		// Token: 0x0400AFAC RID: 44972
		private static ItemData rValue;

		// Token: 0x0400AFAD RID: 44973
		private bool mIntialized;

		// Token: 0x0400AFAE RID: 44974
		private List<ItemData> kEquipments;

		// Token: 0x0400AFAF RID: 44975
		private bool mLeft;

		// Token: 0x0400AFB0 RID: 44976
		public ComModelBinder mModelBinder;

		// Token: 0x0400AFB1 RID: 44977
		public Text mSkySuitName;

		// Token: 0x0400AFB2 RID: 44978
		private FashionType mFashionType = FashionType.FT_SKY;

		// Token: 0x0400AFB3 RID: 44979
		private ItemTable.eSubType mFashionPart = ItemTable.eSubType.FASHION_HEAD;
	}
}
