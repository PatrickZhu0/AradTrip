using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B69 RID: 7017
	public class MagicCardMergeView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x0601130F RID: 70415 RVA: 0x004F1D6C File Offset: 0x004F016C
		private void Awake()
		{
			this.BindUIEvent();
			this.InitMagicCardUIListScript();
			if (this.mBtnMergeCard != null)
			{
				this.mBtnMergeCard.onClick.RemoveAllListeners();
				this.mBtnMergeCard.onClick.AddListener(new UnityAction(this.OnMergeCardClick));
			}
			if (this.mBtnOneKeyMergeCard != null)
			{
				this.mBtnOneKeyMergeCard.onClick.RemoveAllListeners();
				this.mBtnOneKeyMergeCard.onClick.AddListener(new UnityAction(this.OnOneKeyMergeCardClick));
			}
			if (this.mBtnMergePreview != null)
			{
				this.mBtnMergePreview.onClick.RemoveAllListeners();
				this.mBtnMergePreview.onClick.AddListener(new UnityAction(this.OnPreViewBtnClick));
			}
		}

		// Token: 0x06011310 RID: 70416 RVA: 0x004F1E3C File Offset: 0x004F023C
		private void OnDestroy()
		{
			this.UnBindUIEvent();
			this.UnInitMagicCardUIListScript();
			this.dataMerge = null;
			this.mAllMagicCardItems.Clear();
			this.mCurrentSelectedMagicCardQuality = 0;
		}

		// Token: 0x06011311 RID: 70417 RVA: 0x004F1E63 File Offset: 0x004F0263
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.InitMagicCardMergeView();
		}

		// Token: 0x06011312 RID: 70418 RVA: 0x004F1E6B File Offset: 0x004F026B
		public void OnEnableView()
		{
			this.LoadAllMagicCard();
		}

		// Token: 0x06011313 RID: 70419 RVA: 0x004F1E73 File Offset: 0x004F0273
		public void OnDisableView()
		{
		}

		// Token: 0x06011314 RID: 70420 RVA: 0x004F1E78 File Offset: 0x004F0278
		public void InitMagicCardMergeView()
		{
			this.mMergeCardItemA.InitMergeCardItem(new OnEmptyClick(this.OnEmptyClick));
			this.mMergeCardItemB.InitMergeCardItem(new OnEmptyClick(this.OnEmptyClick));
			this.mComMergeMoneyControl.SetState(ComMergeMoneyControl.CMMC.CMMC_NOT_ENOUGH);
			this.mComMergeMoneyControl.SetCost(this.GetMergeCostMoneyID(null), 0);
			this.LoadAllMagicCard();
		}

		// Token: 0x06011315 RID: 70421 RVA: 0x004F1ED8 File Offset: 0x004F02D8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMergeSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsMergeChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOneKeyMergeSuccess, new ClientEventSystem.UIEventHandler(this.OnOneKeyMergeSucceed));
		}

		// Token: 0x06011316 RID: 70422 RVA: 0x004F1F10 File Offset: 0x004F0310
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMergeSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsMergeChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOneKeyMergeSuccess, new ClientEventSystem.UIEventHandler(this.OnOneKeyMergeSucceed));
		}

		// Token: 0x06011317 RID: 70423 RVA: 0x004F1F48 File Offset: 0x004F0348
		private void OnSlotItemsMergeChanged(UIEvent uiEvent)
		{
			this.dataMerge.leftItem = null;
			this.dataMerge.rightItem = null;
			this.mCurrentSelectedMagicCardQuality = 0;
			this.mMergePreviewRoot.CustomActive(false);
			this.mMergeCardItemA.Reset();
			this.mMergeCardItemB.Reset();
			this.UpdateMoneyInfo();
			this.LoadAllMagicCard();
		}

		// Token: 0x06011318 RID: 70424 RVA: 0x004F1FA4 File Offset: 0x004F03A4
		private void OnOneKeyMergeSucceed(UIEvent uiEvent)
		{
			this.ResetMagicCardMergeSelectedItem();
			this.mMergeCardItemA.Reset();
			this.mMergeCardItemB.Reset();
			this.mMergeCardItemA.UpdateMergeCardItem(this.dataMerge.leftItem);
			this.mMergeCardItemB.UpdateMergeCardItem(this.dataMerge.rightItem);
			this.UpdateMoneyInfo();
			this.LoadAllMagicCard();
		}

		// Token: 0x06011319 RID: 70425 RVA: 0x004F2008 File Offset: 0x004F0408
		private void ResetMagicCardMergeSelectedItem()
		{
			if (this.dataMerge == null)
			{
				return;
			}
			if (this.dataMerge.leftItem != null && DataManager<ItemDataManager>.GetInstance().GetItem(this.dataMerge.leftItem.GUID) == null)
			{
				this.dataMerge.leftItem = null;
			}
			if (this.dataMerge.rightItem != null)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.dataMerge.rightItem.GUID);
				if (item == null)
				{
					this.dataMerge.rightItem = null;
				}
				else if (item.Count <= 1 && this.dataMerge.leftItem != null && this.dataMerge.leftItem.GUID == item.GUID)
				{
					this.dataMerge.rightItem = null;
				}
			}
		}

		// Token: 0x0601131A RID: 70426 RVA: 0x004F20E4 File Offset: 0x004F04E4
		private void InitMagicCardUIListScript()
		{
			if (this.mMagicCardUIListScript != null)
			{
				this.mMagicCardUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mMagicCardUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMagicCardUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0601131B RID: 70427 RVA: 0x004F215C File Offset: 0x004F055C
		private void UnInitMagicCardUIListScript()
		{
			if (this.mMagicCardUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mMagicCardUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMagicCardUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0601131C RID: 70428 RVA: 0x004F21C8 File Offset: 0x004F05C8
		private MagicCardMergeItemElement OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MagicCardMergeItemElement>();
		}

		// Token: 0x0601131D RID: 70429 RVA: 0x004F21D0 File Offset: 0x004F05D0
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			MagicCardMergeItemElement magicCardMergeItemElement = item.gameObjectBindScript as MagicCardMergeItemElement;
			if (magicCardMergeItemElement != null && item.m_index >= 0 && item.m_index < this.mAllMagicCardItems.Count)
			{
				magicCardMergeItemElement.OnItemVisiable(this.mAllMagicCardItems[item.m_index], this.mCurrentSelectedMagicCardQuality, new OnMagicCardMergeItemClick(this.UpdatePutMagicCardInfo), this.dataMerge);
			}
		}

		// Token: 0x0601131E RID: 70430 RVA: 0x004F2248 File Offset: 0x004F0648
		public void LoadAllMagicCard()
		{
			if (this.mAllMagicCardItems == null)
			{
				this.mAllMagicCardItems = new List<ItemData>();
			}
			this.mAllMagicCardItems.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByType[i]);
				if (item != null)
				{
					if (item.SubType == 25)
					{
						if (item.PackageType != EPackageType.Storage)
						{
							if (item.PackageType != EPackageType.RoleStorage)
							{
								this.mAllMagicCardItems.Add(item);
							}
						}
					}
				}
			}
			this.mAllMagicCardItems.Sort(new Comparison<ItemData>(this.Sort));
			this.mMagicCardUIListScript.SetElementAmount(this.mAllMagicCardItems.Count);
		}

		// Token: 0x0601131F RID: 70431 RVA: 0x004F2324 File Offset: 0x004F0724
		private void SetElementAmount()
		{
			this.mMagicCardUIListScript.SetElementAmount(this.mAllMagicCardItems.Count);
		}

		// Token: 0x06011320 RID: 70432 RVA: 0x004F233C File Offset: 0x004F073C
		public int Sort(ItemData left, ItemData right)
		{
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x06011321 RID: 70433 RVA: 0x004F236C File Offset: 0x004F076C
		private void UpdatePutMagicCardInfo(ItemData itemData, MagicCardMergeItemElement element)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.dataMerge.leftItem != null && this.dataMerge.rightItem != null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("选择数量已达上限", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mCurrentSelectedMagicCardQuality != 0 && this.mCurrentSelectedMagicCardQuality != (int)itemData.Quality)
			{
				SystemNotifyManager.SysNotifyTextAnimation("该附魔卡与已放入的附魔卡品质不同，无法放入", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int count = itemData.Count;
			int num = 0;
			if (this.dataMerge.leftItem != null && this.dataMerge.leftItem.GUID == itemData.GUID)
			{
				num++;
			}
			if (this.dataMerge.rightItem != null && this.dataMerge.rightItem.GUID == itemData.GUID)
			{
				num++;
			}
			if (num >= count)
			{
				SystemNotifyManager.SysNotifyTextAnimation("放入失败，该附魔卡已全部放入合成区", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			this.mCurrentSelectedMagicCardQuality = (int)itemData.Quality;
			bool flag = false;
			if (this.dataMerge.leftItem == null)
			{
				flag = true;
			}
			if (flag)
			{
				this.dataMerge.leftItem = itemData;
			}
			else
			{
				this.dataMerge.rightItem = itemData;
			}
			this.mMergeCardItemA.UpdateMergeCardItem(this.dataMerge.leftItem);
			this.mMergeCardItemB.UpdateMergeCardItem(this.dataMerge.rightItem);
			if (element != null)
			{
				element.SetCheckMaskRoot(true);
			}
			if (this.dataMerge.leftItem != null && this.dataMerge.rightItem != null)
			{
				this.mMergePreviewRoot.CustomActive(true);
			}
			this.UpdateMoneyInfo();
			this.SetElementAmount();
		}

		// Token: 0x06011322 RID: 70434 RVA: 0x004F2508 File Offset: 0x004F0908
		private void UpdateMoneyInfo()
		{
			if (this.dataMerge.leftItem != null || this.dataMerge.rightItem != null)
			{
				ItemData itemData = (this.dataMerge.leftItem == null) ? this.dataMerge.rightItem : this.dataMerge.leftItem;
				this.mComMergeMoneyControl.SetState(ComMergeMoneyControl.CMMC.CMMC_ENOUGH);
				int mergeCardCost = this.GetMergeCardCost(itemData);
				this.mComMergeMoneyControl.SetCost(this.GetMergeCostMoneyID(itemData), mergeCardCost);
			}
			else
			{
				this.mComMergeMoneyControl.SetState(ComMergeMoneyControl.CMMC.CMMC_NOT_ENOUGH);
			}
		}

		// Token: 0x06011323 RID: 70435 RVA: 0x004F259C File Offset: 0x004F099C
		private void OnEmptyClick(bool isCardA)
		{
			if (isCardA)
			{
				this.dataMerge.leftItem = null;
			}
			else
			{
				this.dataMerge.rightItem = null;
			}
			this.mMergePreviewRoot.CustomActive(false);
			if (this.dataMerge.leftItem == null && this.dataMerge.rightItem == null)
			{
				this.mCurrentSelectedMagicCardQuality = 0;
			}
			this.UpdateMoneyInfo();
			this.SetElementAmount();
		}

		// Token: 0x06011324 RID: 70436 RVA: 0x004F260C File Offset: 0x004F0A0C
		private int GetMergeCostMoneyID(ItemData item)
		{
			if (item != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.iMoneyID = tableItem.CostItemId;
				}
			}
			return this.iMoneyID;
		}

		// Token: 0x06011325 RID: 70437 RVA: 0x004F2654 File Offset: 0x004F0A54
		private int GetMergeCardCost(ItemData left)
		{
			int result = 0;
			if (left != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(left.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.CostNum;
				}
			}
			return result;
		}

		// Token: 0x06011326 RID: 70438 RVA: 0x004F2692 File Offset: 0x004F0A92
		private void OnMergeCardClick()
		{
			if (this.m_bInMerge)
			{
				return;
			}
			this.m_bInMerge = true;
			this.OnClickFunctionMerge();
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				this.m_bInMerge = false;
			});
		}

		// Token: 0x06011327 RID: 70439 RVA: 0x004F26C4 File Offset: 0x004F0AC4
		private void OnClickFunctionMerge()
		{
			if (this.dataMerge != null)
			{
				if (this.dataMerge.leftItem != null && this.dataMerge.rightItem != null)
				{
					if (this.dataMerge.leftItem.Quality != this.dataMerge.rightItem.Quality)
					{
						SystemNotifyManager.SystemNotify(1072, string.Empty);
						return;
					}
					if (this.dataMerge.leftItem.Quality > ItemTable.eColor.PURPLE)
					{
						SystemNotifyManager.SystemNotify(1264, new UnityAction(this._ConfirmToMergeCard));
					}
					else if (MagicCardMergeUtility.GetMagicCardStrengthLevel(this.dataMerge.leftItem) >= 1 || MagicCardMergeUtility.GetMagicCardStrengthLevel(this.dataMerge.rightItem) >= 1)
					{
						bool flag = MagicCardMergeUtility.IsShowMagicCardMergeLevelTip();
						if (flag)
						{
							MagicCardMergeUtility.OnShowMagicCardMergeLevelTip(new Action(this._ConfirmToMergeCard), new OnCommonMsgBoxToggleClick(this.OnMagicCardMergeLevelTipSetting));
						}
						else
						{
							this._ConfirmToMergeCard();
						}
					}
					else
					{
						this._ConfirmToMergeCard();
					}
				}
				else if (this.dataMerge.leftItem == null)
				{
					SystemNotifyManager.SystemNotify(1070, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(1071, string.Empty);
				}
			}
		}

		// Token: 0x06011328 RID: 70440 RVA: 0x004F2808 File Offset: 0x004F0C08
		private void _ConfirmToMergeCard()
		{
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = this.GetMergeCostMoneyID(this.dataMerge.leftItem),
				nCount = this.GetMergeCardCost(this.dataMerge.leftItem)
			}, new Action(this.OnConfirmMagicCardBindMethod), "common_money_cost", null);
		}

		// Token: 0x06011329 RID: 70441 RVA: 0x004F2866 File Offset: 0x004F0C66
		private void OnConfirmMagicCardBindMethod()
		{
			this.OnFinalSendMagicCardMergeReq();
		}

		// Token: 0x0601132A RID: 70442 RVA: 0x004F286E File Offset: 0x004F0C6E
		private void OnFinalSendMagicCardMergeReq()
		{
			if (PackageUtility.IsPackageFullByType(EPackageType.Consumable))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_merge_package_is_full"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.OnSendMagicCardMergeReq();
		}

		// Token: 0x0601132B RID: 70443 RVA: 0x004F2894 File Offset: 0x004F0C94
		private void OnSendMagicCardMergeReq()
		{
			if (this.dataMerge == null || this.dataMerge.leftItem == null || this.dataMerge.rightItem == null)
			{
				return;
			}
			DataManager<EnchantmentsCardManager>.GetInstance().SendMergeCard(this.dataMerge.leftItem.GUID, this.dataMerge.rightItem.GUID);
		}

		// Token: 0x0601132C RID: 70444 RVA: 0x004F28F7 File Offset: 0x004F0CF7
		private void OnMagicCardMergeLevelTipSetting(bool value)
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().IsNotShowMagicCardMergeLevelTip = value;
		}

		// Token: 0x0601132D RID: 70445 RVA: 0x004F2904 File Offset: 0x004F0D04
		private void OnOneKeyMergeCardClick()
		{
			MagicCardMergeUtility.OnOpenMagicCardOneKeyMergeTipFrame(new Action(this.OnMagicCardOneKeyMergeAction));
		}

		// Token: 0x0601132E RID: 70446 RVA: 0x004F2918 File Offset: 0x004F0D18
		private void OnMagicCardOneKeyMergeAction()
		{
			if (!DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseWhiteCard && !DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseBlueCard)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_one_key_merge_quality_not_selected"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (PackageUtility.IsPackageFullByType(EPackageType.Consumable))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_merge_package_is_full"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			MagicCardMergeUtility.GetMagicCardOneKeyMergeInfo(ref num, ref num3, ref num2, ref num4);
			if (num <= 1 && num3 <= 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_one_key_merge_item_number_is_not_enough"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ulong num5 = DataManager<PlayerBaseData>.GetInstance().BindGold;
			if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold)
			{
				num5 += DataManager<PlayerBaseData>.GetInstance().Gold;
			}
			if (num2 > 0)
			{
				if (num5 < (ulong)((long)num2))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_merge_bind_gold_less"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			else if (num4 > 0 && num5 < (ulong)((long)num4))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("magic_card_merge_bind_gold_less"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			string magicCardOneKeyMergeTipContent = MagicCardMergeUtility.GetMagicCardOneKeyMergeTipContent(num, num2, num3, num4);
			MagicCardMergeUtility.OnShowOneKeyMergeTipContent(magicCardOneKeyMergeTipContent, new Action(this.OnSendMagicCardOneKeyMergeReq));
		}

		// Token: 0x0601132F RID: 70447 RVA: 0x004F2A38 File Offset: 0x004F0E38
		private void OnSendMagicCardOneKeyMergeReq()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().SendMagicCardOneKeyMergeReq();
		}

		// Token: 0x06011330 RID: 70448 RVA: 0x004F2A44 File Offset: 0x004F0E44
		private void OnPreViewBtnClick()
		{
			List<ItemData> preViewMagicCardList = this.GetPreViewMagicCardList();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicCardPreViewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicCardPreViewFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MagicCardPreViewFrame>(FrameLayer.Middle, preViewMagicCardList, string.Empty);
		}

		// Token: 0x06011331 RID: 70449 RVA: 0x004F2A88 File Offset: 0x004F0E88
		private List<ItemData> GetPreViewMagicCardList()
		{
			List<ItemData> list = new List<ItemData>();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MagicCardTable>())
			{
				MagicCardTable magicCardTable = keyValuePair.Value as MagicCardTable;
				if (magicCardTable.Weight != 0)
				{
					ItemData commonItemTableDataByID;
					if (this.dataMerge.leftItem == null && this.dataMerge.rightItem == null)
					{
						commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
					}
					else if (this.dataMerge.leftItem != null && this.dataMerge.rightItem == null)
					{
						if (this.dataMerge.leftItem.Quality == ItemTable.eColor.PURPLE)
						{
							if (magicCardTable.Color != (int)this.dataMerge.leftItem.Quality && magicCardTable.Color != 5)
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
						else if (this.dataMerge.leftItem.Quality == ItemTable.eColor.PINK)
						{
							if (magicCardTable.Color != 5)
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
						else
						{
							if (magicCardTable.Color != (int)this.dataMerge.leftItem.Quality && magicCardTable.Color != (int)(this.dataMerge.leftItem.Quality + 1))
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
					}
					else if (this.dataMerge.leftItem == null && this.dataMerge.rightItem != null)
					{
						if (this.dataMerge.rightItem.Quality == ItemTable.eColor.PURPLE)
						{
							if (magicCardTable.Color != (int)this.dataMerge.rightItem.Quality && magicCardTable.Color != 5)
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
						else if (this.dataMerge.rightItem.Quality == ItemTable.eColor.PINK)
						{
							if (magicCardTable.Color != 5)
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
						else
						{
							if (magicCardTable.Color != (int)this.dataMerge.rightItem.Quality && magicCardTable.Color != (int)(this.dataMerge.rightItem.Quality + 1))
							{
								continue;
							}
							commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
						}
					}
					else if (this.dataMerge.leftItem.Quality == ItemTable.eColor.PURPLE)
					{
						if (magicCardTable.Color != (int)this.dataMerge.leftItem.Quality && magicCardTable.Color != 5)
						{
							continue;
						}
						commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
					}
					else if (this.dataMerge.leftItem.Quality == ItemTable.eColor.PINK)
					{
						if (magicCardTable.Color != 5)
						{
							continue;
						}
						commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
					}
					else
					{
						if (magicCardTable.Color != (int)this.dataMerge.leftItem.Quality && magicCardTable.Color != (int)(this.dataMerge.leftItem.Quality + 1))
						{
							continue;
						}
						commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(magicCardTable.ID);
					}
					list.Add(commonItemTableDataByID);
				}
			}
			return list;
		}

		// Token: 0x0400B17E RID: 45438
		[SerializeField]
		private ComUIListScript mMagicCardUIListScript;

		// Token: 0x0400B17F RID: 45439
		[SerializeField]
		private MergeCardItem mMergeCardItemA;

		// Token: 0x0400B180 RID: 45440
		[SerializeField]
		private MergeCardItem mMergeCardItemB;

		// Token: 0x0400B181 RID: 45441
		[SerializeField]
		private ComMergeMoneyControl mComMergeMoneyControl;

		// Token: 0x0400B182 RID: 45442
		[SerializeField]
		private Button mBtnMergeCard;

		// Token: 0x0400B183 RID: 45443
		[SerializeField]
		private Button mBtnOneKeyMergeCard;

		// Token: 0x0400B184 RID: 45444
		[SerializeField]
		private Button mBtnMergePreview;

		// Token: 0x0400B185 RID: 45445
		[SerializeField]
		private GameObject mMergePreviewRoot;

		// Token: 0x0400B186 RID: 45446
		[SerializeField]
		private int iMoneyID = 600000007;

		// Token: 0x0400B187 RID: 45447
		private EnchantmentsFunctionData dataMerge = new EnchantmentsFunctionData();

		// Token: 0x0400B188 RID: 45448
		private List<ItemData> mAllMagicCardItems = new List<ItemData>();

		// Token: 0x0400B189 RID: 45449
		private int mCurrentSelectedMagicCardQuality;

		// Token: 0x0400B18A RID: 45450
		private bool m_bInMerge;
	}
}
