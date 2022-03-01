using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCC RID: 7116
	public class StrengthenTicketMergeRightItem : CustomClientFrameItem, ICustomClientFrameItem<StrengthenTicketMergeFrame, object>
	{
		// Token: 0x06011680 RID: 71296 RVA: 0x0050B1EB File Offset: 0x005095EB
		protected override void _Init()
		{
			this._LoadTR();
			this._BindUIEvent();
			this._CreateCustomGrids();
			if (this.mSkipAnimToggle)
			{
				this.mSkipAnimToggle.isOn = false;
			}
			this._PlayToNotReadyStageAnims();
			this._OnUpdateUseTime();
		}

		// Token: 0x06011681 RID: 71297 RVA: 0x0050B228 File Offset: 0x00509628
		protected override void _Clear()
		{
			if (this.waitToReqFuseTicket != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToReqFuseTicket);
				this.waitToReqFuseTicket = null;
			}
			if (this.waitToReqMergeTicket != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToReqMergeTicket);
				this.waitToReqMergeTicket = null;
			}
			this.bSkipAnim = false;
			if (this.waitToPlayNextAnim != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayNextAnim);
				this.waitToPlayNextAnim = null;
			}
			this._UnBindUIEvent();
			this.mViewModel = null;
			this.mSelfFrame = null;
			if (this.mCustomItemGrids != null)
			{
				for (int i = 0; i < this.mCustomItemGrids.Count; i++)
				{
					this.mCustomItemGrids[i].Clear();
				}
				this.mCustomItemGrids.Clear();
			}
			this.bMaterialMergeGridInited = false;
			if (this.mDefaultMergeMaterialItemIds != null)
			{
				this.mDefaultMergeMaterialItemIds.Clear();
			}
			if (this.mDefaultFuseMaterialItemIds != null)
			{
				this.mDefaultFuseMaterialItemIds.Clear();
			}
			if (this.mDefaultMergeOnlyShowNeedItemIds != null)
			{
				this.mDefaultMergeOnlyShowNeedItemIds.Clear();
			}
			if (this.mNeedFastBuyItemIds != null)
			{
				this.mNeedFastBuyItemIds.Clear();
			}
			if (this.waitToCreateGrids != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCreateGrids);
				this.waitToCreateGrids = null;
			}
			if (null != this.mBtnMerge)
			{
				this.mBtnMerge.onClick.RemoveListener(new UnityAction(this._onBtnMergeButtonClick));
			}
			this.mBtnMerge = null;
			if (null != this.mSkipAnimToggle)
			{
				this.mSkipAnimToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSkipAnimToggleToggleValueChange));
			}
			this.mSkipAnimToggle = null;
			this.mMaterialItemRoot = null;
			this.mMaterialTips = null;
			if (this.mIncreaseRateDrop != null)
			{
				this.mIncreaseRateDrop.Clear();
				this.mIncreaseRateDrop = null;
			}
			this.mResultPlaneComAnim = null;
			if (null != this.mMergeBtnMask)
			{
				this.mMergeBtnMask.onClick.RemoveListener(new UnityAction(this._onMergeBtnMaskButtonClick));
			}
			this.mMergeBtnMask = null;
			this.mBtnMergeCD = null;
			this.mTipTxt = null;
			this.tr_notice_select_left_tickets_merge = string.Empty;
			this.tr_notice_select_left_tickets_fuse = string.Empty;
			this.tr_notice_preview_material_merge = string.Empty;
			this.tr_notice_preview_ticket_fuse = string.Empty;
			this.tr_notice_material_item_count_format = string.Empty;
			this.tr_notice_please_select_ticket = string.Empty;
			this.tr_notice_desc_less_color_format = string.Empty;
			this.tr_notice_desc_normal_color_format = string.Empty;
			this.tr_notice_merge_material_not_enough = string.Empty;
			this.tr_stengthen_tick_mrger_notice_tip = string.Empty;
			this.iMaterialGrowthValue = 1;
		}

		// Token: 0x06011682 RID: 71298 RVA: 0x0050B4D4 File Offset: 0x005098D4
		private void _LoadTR()
		{
			this.tr_notice_select_left_tickets_merge = TR.Value("strengthen_merge_select_left_tickets_merge");
			this.tr_notice_select_left_tickets_fuse = TR.Value("strengthen_merge_select_left_tickets_fuse");
			this.tr_notice_material_item_count_format = TR.Value("strengthen_merge_material_count_format");
			this.tr_notice_preview_material_merge = TR.Value("strengthen_merge_material_preview_tip");
			this.tr_notice_preview_ticket_fuse = TR.Value("strengthen_merge_ticket_preview_tip");
			this.tr_notice_please_select_ticket = TR.Value("strengthen_merge_plase_select_ticket");
			this.tr_notice_desc_less_color_format = TR.Value("strengthen_merge_desc_less_color_format");
			this.tr_notice_desc_normal_color_format = TR.Value("strengthen_merge_desc_normal_color_format");
			this.tr_notice_merge_material_not_enough = TR.Value("strengthen_merge_material_not_enough");
			this.tr_stengthen_tick_mrger_notice_tip = DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetPrayTaskDes();
		}

		// Token: 0x06011683 RID: 71299 RVA: 0x0050B584 File Offset: 0x00509984
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectType, new ClientEventSystem.UIEventHandler(this._OnSrengtheTicketMergeSelectType));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateUseTime));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeStateUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdatePrayActivityState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFreshView, new ClientEventSystem.UIEventHandler(this._OnStengthenTickFreshView));
		}

		// Token: 0x06011684 RID: 71300 RVA: 0x0050B600 File Offset: 0x00509A00
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectType, new ClientEventSystem.UIEventHandler(this._OnSrengtheTicketMergeSelectType));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateUseTime));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeStateUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdatePrayActivityState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFreshView, new ClientEventSystem.UIEventHandler(this._OnStengthenTickFreshView));
		}

		// Token: 0x06011685 RID: 71301 RVA: 0x0050B679 File Offset: 0x00509A79
		private StrengthenTicketMergeType _GetCurrMergeType()
		{
			if (this.mSelfFrame == null)
			{
				return StrengthenTicketMergeType.Count;
			}
			return this.mSelfFrame.MergeType;
		}

		// Token: 0x06011686 RID: 71302 RVA: 0x0050B694 File Offset: 0x00509A94
		private void _CreateCustomGrids()
		{
			if (this.mSelfFrame != null)
			{
				List<int> specialMergeBindItemIds = this.mSelfFrame.GetSpecialMergeBindItemIds();
				if (specialMergeBindItemIds != null)
				{
					specialMergeBindItemIds.AddRange(this.mSelfFrame.GetMergeBindItemIds());
				}
				this.mDefaultMergeMaterialItemIds = specialMergeBindItemIds;
				this.mDefaultFuseMaterialItemIds = this.mSelfFrame.GetFuseBindItemIds();
				this.mDefaultMergeOnlyShowNeedItemIds = this.mSelfFrame.GetMergeOnlyShowNeedCountItemIds();
				this.mNeedFastBuyItemIds = this.mSelfFrame.GetNeedFastBuyItemIds();
			}
			if (this.waitToCreateGrids != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCreateGrids);
			}
			this.waitToCreateGrids = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToCreateGrids());
		}

		// Token: 0x06011687 RID: 71303 RVA: 0x0050B73C File Offset: 0x00509B3C
		private IEnumerator _WaitToCreateGrids()
		{
			if (this.mSelfFrame == null)
			{
				yield break;
			}
			if (this.mDefaultMergeMaterialItemIds == null || this.mDefaultMergeMaterialItemIds.Count == 0)
			{
				yield break;
			}
			int index = 0;
			while (index < this.mDefaultMergeMaterialItemIds.Count)
			{
				GameObject grid = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/StrengthenTicketMerge/ComItemCustom", true, 0U);
				if (!(grid == null))
				{
					Utility.AttachTo(grid, this.mMaterialItemRoot, false);
					ComItemCustom customItem = grid.GetComponent<ComItemCustom>();
					if (customItem != null)
					{
						customItem.Init(false, this.mDefaultMergeMaterialItemIds[index], false, true, true, ComItemCustomClickType.Button);
						customItem.SetDescStr(string.Empty, true);
						customItem.CustomActive(true);
					}
					if (this.mCustomItemGrids != null && customItem != null)
					{
						this.mCustomItemGrids.Add(customItem);
					}
					index++;
					yield return null;
				}
			}
			this.bMaterialMergeGridInited = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeSelectReset, null, null, null, null);
			yield break;
		}

		// Token: 0x06011688 RID: 71304 RVA: 0x0050B758 File Offset: 0x00509B58
		private void _ResetStrengthTicketContent(StrengthenTicketMergeType mergeType)
		{
			if (mergeType != StrengthenTicketMergeType.Material)
			{
				if (mergeType == StrengthenTicketMergeType.StrengthenTicket)
				{
					if (this.mSelfFrame != null)
					{
						this.mSelfFrame.SetComConsumeItemsActive(false);
					}
					this._SetMaterialDropdownActive(false);
					this._ResetOwnTicketsPreview();
				}
			}
			else
			{
				if (this.mSelfFrame != null)
				{
					this.mSelfFrame.SetComConsumeItemsActive(false);
				}
				this._SetMaterialDropdownActive(true);
				if (this.bMaterialMergeGridInited)
				{
					this._ResetMaterialPreview();
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeSelectReset, null, null, null, null);
				}
			}
		}

		// Token: 0x06011689 RID: 71305 RVA: 0x0050B7E8 File Offset: 0x00509BE8
		private void _ResetMaterialPreview()
		{
			if (this.mCustomItemGrids == null || this.mDefaultMergeMaterialItemIds == null)
			{
				return;
			}
			for (int i = 0; i < this.mCustomItemGrids.Count; i++)
			{
				ComItemCustom comItemCustom = this.mCustomItemGrids[i];
				if (comItemCustom != null && i < this.mDefaultMergeMaterialItemIds.Count)
				{
					if (this.mSelfFrame != null)
					{
						this.mSelfFrame.SetComConsumeItemActive(this.mDefaultMergeMaterialItemIds[i], true);
					}
					comItemCustom.Init(false, this.mDefaultMergeMaterialItemIds[i], false, true, true, ComItemCustomClickType.Button);
					comItemCustom.SetDescStr(string.Empty, true);
					comItemCustom.CustomActive(true);
				}
			}
			this._SetTipView(this.tr_notice_select_left_tickets_merge);
			this._EnableMaterialDropdown(false);
			this._PlayToNotReadyStageAnims();
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().ClearCurrSelectMaterialMergeModel();
		}

		// Token: 0x0601168A RID: 71306 RVA: 0x0050B8C4 File Offset: 0x00509CC4
		private void _ResetOwnTicketsPreview()
		{
			if (this.mCustomItemGrids == null)
			{
				return;
			}
			if (this.mSelfFrame == null)
			{
				return;
			}
			int fuseMaterialGridCount = this.mSelfFrame.GetFuseMaterialGridCount();
			for (int i = this.mCustomItemGrids.Count; i > fuseMaterialGridCount; i--)
			{
				this.mCustomItemGrids[i - 1].CustomActive(false);
			}
			for (int j = 0; j < fuseMaterialGridCount; j++)
			{
				ComItemCustom comItemCustom = this.mCustomItemGrids[j];
				if (!(comItemCustom == null))
				{
					if (j < this.mDefaultFuseMaterialItemIds.Count)
					{
						if (this.mSelfFrame != null)
						{
							this.mSelfFrame.SetComConsumeItemActive(this.mDefaultFuseMaterialItemIds[j], true);
						}
						comItemCustom.Init(false, this.mDefaultFuseMaterialItemIds[j], false, true, true, ComItemCustomClickType.Button);
						comItemCustom.SetDescStr(string.Empty, true);
						comItemCustom.CustomActive(true);
					}
					else
					{
						comItemCustom.Init(false, null, false, true, true, ComItemCustomClickType.Button);
						comItemCustom.SetExtendImgsActive(new List<int>
						{
							0
						});
						comItemCustom.SetDescStr(this.tr_notice_please_select_ticket, true);
						comItemCustom.CustomActive(true);
					}
				}
			}
			this._SetTipView(this.tr_notice_select_left_tickets_fuse);
			this._PlayToNotReadyStageAnims();
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().ClearTempMaterialFuseModel();
		}

		// Token: 0x0601168B RID: 71307 RVA: 0x0050BA0C File Offset: 0x00509E0C
		private void _RefreshMaterialSelected(StrengthenTicketMaterialMergeModel model)
		{
			if (this.mCustomItemGrids == null)
			{
				return;
			}
			if (model == null)
			{
				return;
			}
			StrengthenTicketMergeMaterial needMaterialModel = model.needMaterialModel;
			if (needMaterialModel == null)
			{
				return;
			}
			List<StrengthenTicketMergeItemData> needMaterialDatas = needMaterialModel.needMaterialDatas;
			if (needMaterialDatas == null)
			{
				return;
			}
			if (needMaterialDatas.Count > this.mCustomItemGrids.Count)
			{
				Logger.LogError("[StrengthenTicketMergeRightItem] - _RefreshMaterialSelected MaterialsCount > GridCount !!!");
				return;
			}
			if (this.mSelfFrame != null)
			{
				this.mSelfFrame.SetComConsumeItemsActive(false);
			}
			for (int i = 0; i < this.mCustomItemGrids.Count; i++)
			{
				ComItemCustom comItemCustom = this.mCustomItemGrids[i];
				if (comItemCustom != null && i < needMaterialDatas.Count)
				{
					if (this.mSelfFrame != null && needMaterialDatas[i] != null && needMaterialDatas[i].tempItemData != null)
					{
						this.mSelfFrame.SetComConsumeItemActive(needMaterialDatas[i].tempItemData.ItemID, true);
					}
					comItemCustom.Init(false, needMaterialDatas[i].tempItemData, false, true, true, ComItemCustomClickType.Button);
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(needMaterialDatas[i].tempItemData.ItemID, false);
					int count = needMaterialDatas[i].tempItemData.Count;
					int needItemId = needMaterialDatas[i].tempItemData.ItemID;
					if (ownedItemCount < count)
					{
						comItemCustom.onItemBtnClick = delegate()
						{
							if (this.mNeedFastBuyItemIds != null && this.mNeedFastBuyItemIds.Contains(needItemId))
							{
								DataManager<StrengthenTicketMergeDataManager>.GetInstance().ReqFastMallBuy(needItemId);
							}
							else
							{
								ItemComeLink.OnLink(needItemId, 0, false, null, false, true, false, null, string.Empty);
							}
						};
					}
					comItemCustom.SetDescStr(this._FormatCustomComItemCount(ownedItemCount, count, needItemId), false);
					comItemCustom.CustomActive(true);
				}
				else
				{
					comItemCustom.Clear();
					comItemCustom.CustomActive(false);
				}
			}
			this._SetTipView(string.Format(this.tr_notice_preview_material_merge, model.strengthenLevel, model.previewMinPercent, model.previewMaxPercent));
			bool flag = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckMaterialMergeIsEnough();
			if (flag)
			{
				this._PlayToWaitingStageAnims();
			}
			else
			{
				this._PlayToNotReadyStageAnims();
			}
		}

		// Token: 0x0601168C RID: 71308 RVA: 0x0050BC18 File Offset: 0x0050A018
		private void _RefreshMaterialSelected(int index)
		{
			this.iMaterialGrowthValue = index;
			StrengthenTicketMaterialMergeModel mergeModel = this.mViewModel as StrengthenTicketMaterialMergeModel;
			StrengthenTicketMaterialMergeModel materialMergeStrengthenTicketTableId = DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetMaterialMergeStrengthenTicketTableId(mergeModel, index);
			this._RefreshMaterialSelected(materialMergeStrengthenTicketTableId);
		}

		// Token: 0x0601168D RID: 71309 RVA: 0x0050BC4C File Offset: 0x0050A04C
		private string _FormatCustomComItemCount(int ownCount, int needCount, int needItemId)
		{
			string arg = ownCount.ToString();
			string text = needCount.ToString();
			if (ownCount < needCount)
			{
				arg = string.Format(this.tr_notice_desc_less_color_format, arg);
			}
			else
			{
				arg = string.Format(this.tr_notice_desc_normal_color_format, arg);
			}
			if (this.mDefaultMergeOnlyShowNeedItemIds != null)
			{
				for (int i = 0; i < this.mDefaultMergeOnlyShowNeedItemIds.Count; i++)
				{
					if (this.mDefaultMergeOnlyShowNeedItemIds[i] == needItemId)
					{
						if (ownCount < needCount)
						{
							text = string.Format(this.tr_notice_desc_less_color_format, text);
						}
						else
						{
							text = string.Format(this.tr_notice_desc_normal_color_format, text);
						}
						return text;
					}
				}
			}
			text = string.Format(this.tr_notice_desc_normal_color_format, needCount.ToString());
			return string.Format(this.tr_notice_material_item_count_format, arg, text);
		}

		// Token: 0x0601168E RID: 71310 RVA: 0x0050BD28 File Offset: 0x0050A128
		private void _RefreshTicketsSelected()
		{
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().TryAddFuseMaterialCanUse();
			if (this.mCustomItemGrids == null)
			{
				return;
			}
			StrengthenTicketMaterialFuseModel tempMaterialFuseModel = DataManager<StrengthenTicketMergeDataManager>.GetInstance().TempMaterialFuseModel;
			if (tempMaterialFuseModel == null)
			{
				return;
			}
			List<StrengthenTicketFuseSpecialMaterial> materialModels = tempMaterialFuseModel.materialModels;
			List<StrengthenTicketFuseItemData> ticketModels = tempMaterialFuseModel.ticketModels;
			if (materialModels == null || ticketModels == null)
			{
				return;
			}
			int count = materialModels.Count;
			int ticketFuseReadyCapacity = DataManager<StrengthenTicketMergeDataManager>.GetInstance().TicketFuseReadyCapacity;
			if (count + ticketFuseReadyCapacity > this.mCustomItemGrids.Count)
			{
				Logger.LogError("[StrengthenTicketMergeRightItem] - _RefreshMaterialSelected Total MaterialsCount > GridCount !!!");
				return;
			}
			if (this.mSelfFrame != null)
			{
				this.mSelfFrame.SetComConsumeItemsActive(false);
			}
			for (int i = 0; i < this.mCustomItemGrids.Count; i++)
			{
				ComItemCustom comItemCustom = this.mCustomItemGrids[i];
				if (!(comItemCustom == null))
				{
					if (i < count)
					{
						StrengthenTicketFuseSpecialMaterial strengthenTicketFuseSpecialMaterial = materialModels[i];
						if (strengthenTicketFuseSpecialMaterial.fuseNeedItemData != null)
						{
							if (this.mSelfFrame != null)
							{
								this.mSelfFrame.SetComConsumeItemActive(strengthenTicketFuseSpecialMaterial.fuseNeedItemData.ItemID, true);
							}
							comItemCustom.Init(false, strengthenTicketFuseSpecialMaterial.fuseNeedItemData, false, true, true, ComItemCustomClickType.Button);
							int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(strengthenTicketFuseSpecialMaterial.fuseNeedItemData.ItemID, false);
							int count2 = strengthenTicketFuseSpecialMaterial.fuseNeedItemData.Count;
							int needItemId = strengthenTicketFuseSpecialMaterial.fuseNeedItemData.ItemID;
							if (ownedItemCount < count2)
							{
								comItemCustom.onItemBtnClick = delegate()
								{
									if (this.mNeedFastBuyItemIds != null && this.mNeedFastBuyItemIds.Contains(needItemId))
									{
										DataManager<StrengthenTicketMergeDataManager>.GetInstance().ReqFastMallBuy(needItemId);
									}
									else
									{
										ItemComeLink.OnLink(needItemId, 0, false, null, false, true, false, null, string.Empty);
									}
								};
							}
							comItemCustom.SetDescStr(this._FormatCustomComItemCount(ownedItemCount, count2, needItemId), false);
							comItemCustom.CustomActive(true);
						}
					}
					else if (i >= count && i < count + ticketFuseReadyCapacity)
					{
						int num = i - count;
						if (comItemCustom != null && num < ticketModels.Count)
						{
							StrengthenTicketFuseItemData fuseTicket = ticketModels[num];
							if (fuseTicket == null || fuseTicket.ticketItemData == null)
							{
								return;
							}
							if (this.mSelfFrame != null)
							{
								this.mSelfFrame.SetComConsumeItemActive(fuseTicket.ticketItemData.TableID, true);
							}
							comItemCustom.Init(false, fuseTicket.ticketItemData, true, true, ComItemCustomClickType.Button);
							comItemCustom.onItemBtnClick = delegate()
							{
								if (DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckFuseTicketCanRemove(fuseTicket))
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseRemoveTicket, fuseTicket, null, null, null);
								}
							};
							comItemCustom.SetDescStr(fuseTicket.ticketItemData.Name, true);
							comItemCustom.SetExtendBtn1ShowAndEnable(true, false);
							comItemCustom.CustomActive(true);
						}
						else
						{
							comItemCustom.Init(false, null, true, true, ComItemCustomClickType.Button);
							comItemCustom.SetExtendImgsActive(new List<int>
							{
								0
							});
							comItemCustom.SetDescStr(string.Empty, true);
							comItemCustom.CustomActive(true);
						}
					}
					else
					{
						comItemCustom.Clear();
						comItemCustom.CustomActive(false);
					}
				}
			}
			if (!DataManager<StrengthenTicketMergeDataManager>.GetInstance().TryCalculateFuseOutputProbabilityInterval())
			{
				this._SetTipView(this.tr_notice_select_left_tickets_fuse);
			}
			bool flag = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckMaterialFuseIsEnough(null, null);
			if (flag)
			{
				this._PlayToWaitingStageAnims();
			}
			else
			{
				this._PlayToNotReadyStageAnims();
			}
		}

		// Token: 0x0601168F RID: 71311 RVA: 0x0050C064 File Offset: 0x0050A464
		private void _OnUpdateUseTime()
		{
			if (this.mTipTxt != null)
			{
				if (DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.BUFF_PRAY_ACTIVITY) == null)
				{
					this.mTipTxt.CustomActive(false);
				}
				else
				{
					bool prayActivityIsFinish = DataManager<StrengthenTicketMergeDataManager>.GetInstance().PrayActivityIsFinish;
					this.mTipTxt.CustomActive(!prayActivityIsFinish);
					if (!prayActivityIsFinish)
					{
						this.mTipTxt.text = string.Format(this.tr_stengthen_tick_mrger_notice_tip, DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetLeftPrayeTimer());
					}
				}
			}
		}

		// Token: 0x06011690 RID: 71312 RVA: 0x0050C0EE File Offset: 0x0050A4EE
		private void _SetTipView(string tip)
		{
			if (this.mMaterialTips)
			{
				this.mMaterialTips.text = tip;
			}
		}

		// Token: 0x06011691 RID: 71313 RVA: 0x0050C10C File Offset: 0x0050A50C
		private void _SetMaterialDropdownActive(bool bShow)
		{
			if (this.mIncreaseRateDrop)
			{
				this.mIncreaseRateDrop.CustomActive(bShow);
			}
		}

		// Token: 0x06011692 RID: 71314 RVA: 0x0050C12C File Offset: 0x0050A52C
		private void _RefreshMaterialDropdown(List<string> descList)
		{
			if (this.mIncreaseRateDrop != null)
			{
				this.mIncreaseRateDrop.Clear();
				this.mIncreaseRateDrop.Init(descList);
				this.mIncreaseRateDrop.onSelectIndex = delegate(int index)
				{
					this._RefreshMaterialSelected(index);
				};
				this.mIncreaseRateDrop.onDisabledHandle = delegate()
				{
					SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_select_left_tickets_merge, CommonTipsDesc.eShowMode.SI_UNIQUE);
				};
			}
		}

		// Token: 0x06011693 RID: 71315 RVA: 0x0050C18F File Offset: 0x0050A58F
		private void _EnableMaterialDropdown(bool enabled)
		{
			if (this.mIncreaseRateDrop != null)
			{
				this.mIncreaseRateDrop.SetEnable(enabled);
			}
		}

		// Token: 0x06011694 RID: 71316 RVA: 0x0050C1AE File Offset: 0x0050A5AE
		private void _ResetMaterialDropdownIndex()
		{
			if (this.mIncreaseRateDrop != null)
			{
				this.mIncreaseRateDrop.ResetFirstIndex();
			}
		}

		// Token: 0x06011695 RID: 71317 RVA: 0x0050C1CC File Offset: 0x0050A5CC
		private int _GetDropdownFirstIndex()
		{
			if (this.mIncreaseRateDrop != null)
			{
				return this.mIncreaseRateDrop.GetFirstIndex();
			}
			return 1;
		}

		// Token: 0x06011696 RID: 71318 RVA: 0x0050C1EC File Offset: 0x0050A5EC
		private void _CheckCurrMergeStage()
		{
			if (this.mSelfFrame == null)
			{
				return;
			}
			switch (this.mSelfFrame.CurrMergeStage)
			{
			case StrengthenTicketMergeStage.NotReady:
				this._SetMergeBtnMaskBtnActive(true, true);
				break;
			case StrengthenTicketMergeStage.Ready:
				this._SetMergeBtnMaskBtnActive(true, false);
				break;
			case StrengthenTicketMergeStage.Waiting:
				this._SetMergeBtnMaskBtnActive(false, false);
				break;
			case StrengthenTicketMergeStage.Process:
				this._SetMergeBtnMaskBtnActive(true, false);
				break;
			case StrengthenTicketMergeStage.ReverseReady:
				this._SetMergeBtnMaskBtnActive(true, false);
				break;
			}
		}

		// Token: 0x06011697 RID: 71319 RVA: 0x0050C271 File Offset: 0x0050A671
		private void _SetMergeBtnMaskBtnActive(bool bActive, bool bEnable = false)
		{
			if (this.mMergeBtnMask)
			{
				this.mMergeBtnMask.CustomActive(bActive);
				this.mMergeBtnMask.enabled = bEnable;
			}
		}

		// Token: 0x06011698 RID: 71320 RVA: 0x0050C29B File Offset: 0x0050A69B
		private void _onBtnMergeButtonClick()
		{
			if (this.mBtnMergeCD == null || !this.mBtnMergeCD.IsBtnWork())
			{
				return;
			}
			this._Merge();
		}

		// Token: 0x06011699 RID: 71321 RVA: 0x0050C2C8 File Offset: 0x0050A6C8
		private void _OnReqMaterialMergeStrengthenTicket()
		{
			ItemSimpleData itemSimpleData = DataManager<StrengthenTicketMergeDataManager>.GetInstance().TryGetFirstCoinItemDataInMaterials();
			if (itemSimpleData != null)
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = itemSimpleData.ItemID,
					nCount = itemSimpleData.Count
				}, delegate
				{
					this._StartReqMergeTicket();
				}, "common_money_cost", null);
			}
		}

		// Token: 0x0601169A RID: 71322 RVA: 0x0050C321 File Offset: 0x0050A721
		private void OnUpdateSyntheticFrameTip(bool value)
		{
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().BSyntheticFrameTip = value;
		}

		// Token: 0x0601169B RID: 71323 RVA: 0x0050C330 File Offset: 0x0050A730
		private void _Merge()
		{
			if (this._GetCurrMergeType() == StrengthenTicketMergeType.Material)
			{
				if (!DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckMaterialMergeIsEnough())
				{
					SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_merge_material_not_enough, CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (!DataManager<StrengthenTicketMergeDataManager>.GetInstance().BSyntheticFrameTip && this.iMaterialGrowthValue == 1)
				{
					SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(new CommonMsgBoxOkCancelNewParamData
					{
						ContentLabel = TR.Value("strengthen_tick_merge_desc"),
						IsShowNotify = true,
						IsDefaultCheck = true,
						OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateSyntheticFrameTip),
						LeftButtonText = TR.Value("common_data_cancel"),
						RightButtonText = TR.Value("common_data_sure_2"),
						OnRightButtonClickCallBack = new Action(this._OnReqMaterialMergeStrengthenTicket)
					});
					return;
				}
				this._OnReqMaterialMergeStrengthenTicket();
			}
			else if (this._GetCurrMergeType() == StrengthenTicketMergeType.StrengthenTicket && !DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckMaterialFuseIsEnough(new Action<ulong, ulong>(this._StartReqFuseTickets), delegate
			{
				this.mBtnMergeCD.StopBtCD();
			}))
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_merge_material_not_enough, CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			this.mBtnMergeCD.StartBtCD();
		}

		// Token: 0x0601169C RID: 71324 RVA: 0x0050C447 File Offset: 0x0050A847
		private void _StartReqFuseTickets(ulong aGUID, ulong bGUID)
		{
			if (this.waitToReqFuseTicket != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToReqFuseTicket);
			}
			this.waitToReqFuseTicket = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToReqFuseTickets(aGUID, bGUID));
		}

		// Token: 0x0601169D RID: 71325 RVA: 0x0050C47C File Offset: 0x0050A87C
		private IEnumerator _WaitToReqFuseTickets(ulong aGUID, ulong bGUID)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketStartMerge, null, null, null, null);
			float animDuration = this._PlayToProcessStageAnims();
			yield return Yielders.GetWaitForSeconds(animDuration);
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().ReqFuseStrengthenTicket(aGUID, bGUID);
			yield break;
		}

		// Token: 0x0601169E RID: 71326 RVA: 0x0050C4A5 File Offset: 0x0050A8A5
		private void _StartReqMergeTicket()
		{
			if (this.waitToReqFuseTicket != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToReqFuseTicket);
			}
			this.waitToReqFuseTicket = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToReqMergeTicket());
		}

		// Token: 0x0601169F RID: 71327 RVA: 0x0050C4D8 File Offset: 0x0050A8D8
		private IEnumerator _WaitToReqMergeTicket()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketStartMerge, null, null, null, null);
			float animDuration = this._PlayToProcessStageAnims();
			yield return Yielders.GetWaitForSeconds(animDuration);
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().ReqMaterialMergeStrengthenTicket();
			yield break;
		}

		// Token: 0x060116A0 RID: 71328 RVA: 0x0050C4F3 File Offset: 0x0050A8F3
		private void _onSkipAnimToggleToggleValueChange(bool changed)
		{
			this.bSkipAnim = changed;
		}

		// Token: 0x060116A1 RID: 71329 RVA: 0x0050C4FC File Offset: 0x0050A8FC
		private void _onMergeBtnMaskButtonClick()
		{
			SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_merge_material_not_enough, CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x060116A2 RID: 71330 RVA: 0x0050C50C File Offset: 0x0050A90C
		private void _OnSrengtheTicketMergeSelectType(UIEvent _event)
		{
			if (_event == null)
			{
				return;
			}
			StrengthenTicketMergeType strengthenTicketMergeType = (StrengthenTicketMergeType)_event.Param1;
			this._ResetStrengthTicketContent(strengthenTicketMergeType);
			if (strengthenTicketMergeType == StrengthenTicketMergeType.StrengthenTicket)
			{
				this.mTipTxt.CustomActive(false);
			}
			else if (strengthenTicketMergeType == StrengthenTicketMergeType.Material)
			{
				this.mTipTxt.CustomActive(!DataManager<StrengthenTicketMergeDataManager>.GetInstance().PrayActivityIsFinish);
			}
		}

		// Token: 0x060116A3 RID: 71331 RVA: 0x0050C569 File Offset: 0x0050A969
		private void _OnUpdateUseTime(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			this._OnUpdateUseTime();
		}

		// Token: 0x060116A4 RID: 71332 RVA: 0x0050C578 File Offset: 0x0050A978
		private void _OnUpdatePrayActivityState(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			this.mTipTxt.CustomActive(!DataManager<StrengthenTicketMergeDataManager>.GetInstance().PrayActivityIsFinish);
		}

		// Token: 0x060116A5 RID: 71333 RVA: 0x0050C599 File Offset: 0x0050A999
		private void _OnStengthenTickFreshView(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			this.RefreshView(null);
		}

		// Token: 0x060116A6 RID: 71334 RVA: 0x0050C5AC File Offset: 0x0050A9AC
		private AnimationClip _PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage stage, bool bReverse = false)
		{
			if (this.mResultPlaneComAnim == null || this.mResultPlaneComAnim.animator == null)
			{
				return null;
			}
			int num = (int)stage;
			if (this.mSelfFrame == null)
			{
				return null;
			}
			AnimationClip[] animationClips = this.mResultPlaneComAnim.animator.runtimeAnimatorController.animationClips;
			if (animationClips == null)
			{
				return null;
			}
			if (stage == StrengthenTicketMergeStage.ReverseReady)
			{
				num = 1;
			}
			if (num > animationClips.Length)
			{
				Logger.LogError("[StrengthenTicketMergeRightItem] - PlayResPlaneAnimByMergeStage currIndex is more than animClipLength");
				return null;
			}
			AnimationClip animationClip = animationClips[num];
			if (animationClip == null)
			{
				return null;
			}
			if (bReverse)
			{
				this.mResultPlaneComAnim.animator.SetFloat(this.mResultPlaneComAnim.animSpeedMutifulParam_2, this.mResultPlaneComAnim.animSpeedMutiful_2);
			}
			else
			{
				this.mResultPlaneComAnim.animator.SetFloat(this.mResultPlaneComAnim.animSpeedMutifulParam_2, -this.mResultPlaneComAnim.animSpeedMutiful_2);
			}
			this.mResultPlaneComAnim.animator.Play(animationClip.name, 0, 0f);
			this.mSelfFrame.CurrMergeStage = stage;
			this._CheckCurrMergeStage();
			return animationClip;
		}

		// Token: 0x060116A7 RID: 71335 RVA: 0x0050C6C8 File Offset: 0x0050AAC8
		private void _PlayToWaitingStageAnims()
		{
			if (this.mSelfFrame == null)
			{
				return;
			}
			if (this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.NotReady || this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.Waiting || this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.ReverseReady || this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.Ready)
			{
				AnimationClip animationClip = this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.Ready, false);
				if (animationClip != null)
				{
					this._StartWaitToPlayStageAnim(animationClip.length, StrengthenTicketMergeStage.Waiting, false);
				}
			}
			else if (this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.Process)
			{
				this._StartPlayWaitingAnim();
			}
		}

		// Token: 0x060116A8 RID: 71336 RVA: 0x0050C764 File Offset: 0x0050AB64
		private void _PlayToNotReadyStageAnims()
		{
			if (this.mSelfFrame == null)
			{
				return;
			}
			if (this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.Waiting || this.mSelfFrame.CurrMergeStage == StrengthenTicketMergeStage.Ready)
			{
				AnimationClip animationClip = this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.ReverseReady, true);
				if (animationClip != null)
				{
					this._StartWaitToPlayStageAnim(animationClip.length, StrengthenTicketMergeStage.NotReady, false);
				}
			}
			else
			{
				this._StartPlayNotReadyAnim();
			}
		}

		// Token: 0x060116A9 RID: 71337 RVA: 0x0050C7D0 File Offset: 0x0050ABD0
		private float _PlayToProcessStageAnims()
		{
			float result = 0f;
			if (this.mSelfFrame == null)
			{
				return result;
			}
			if (this.mSelfFrame.CurrMergeStage != StrengthenTicketMergeStage.NotReady && !this.bSkipAnim)
			{
				AnimationClip animationClip = this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.Process, false);
				if (animationClip == null)
				{
					return result;
				}
				result = animationClip.length;
			}
			return result;
		}

		// Token: 0x060116AA RID: 71338 RVA: 0x0050C82A File Offset: 0x0050AC2A
		private void _StartWaitToPlayStageAnim(float waitTime, StrengthenTicketMergeStage stage, bool bReverse = false)
		{
			if (this.waitToPlayNextAnim != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayNextAnim);
			}
			this.waitToPlayNextAnim = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToPlayStageAnim(waitTime, stage, bReverse));
		}

		// Token: 0x060116AB RID: 71339 RVA: 0x0050C860 File Offset: 0x0050AC60
		private IEnumerator _WaitToPlayStageAnim(float waitTime, StrengthenTicketMergeStage stage, bool bReverse = false)
		{
			yield return Yielders.GetWaitForSeconds(waitTime);
			this._PlayResPlaneAnimByMergeStage(stage, bReverse);
			yield break;
		}

		// Token: 0x060116AC RID: 71340 RVA: 0x0050C890 File Offset: 0x0050AC90
		private void _StartPlayNotReadyAnim()
		{
			this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.NotReady, false);
		}

		// Token: 0x060116AD RID: 71341 RVA: 0x0050C89B File Offset: 0x0050AC9B
		private void _StartPlayReadyAnim()
		{
			this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.Ready, false);
		}

		// Token: 0x060116AE RID: 71342 RVA: 0x0050C8A6 File Offset: 0x0050ACA6
		private void _StartPlayWaitingAnim()
		{
			this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.Waiting, false);
		}

		// Token: 0x060116AF RID: 71343 RVA: 0x0050C8B1 File Offset: 0x0050ACB1
		private void _StartPlayProcessAnim()
		{
			this._PlayResPlaneAnimByMergeStage(StrengthenTicketMergeStage.Process, false);
		}

		// Token: 0x060116B0 RID: 71344 RVA: 0x0050C8BC File Offset: 0x0050ACBC
		public void Create(StrengthenTicketMergeFrame frame, GameObject parent)
		{
			this._mParentGo = parent;
			this.mSelfFrame = frame;
			if (this._mSelfGo == null)
			{
				this._mSelfGo = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/StrengthenTicketMerge/StrengthenTicketMergeRightItem", true, 0U);
			}
			if (this._mSelfGo != null)
			{
				this._mBind = this._mSelfGo.GetComponent<ComCommonBind>();
			}
			if (this._mBind != null)
			{
				this.mBtnMerge = this._mBind.GetCom<Button>("BtnMerge");
				if (null != this.mBtnMerge)
				{
					this.mBtnMerge.onClick.AddListener(new UnityAction(this._onBtnMergeButtonClick));
				}
				this.mSkipAnimToggle = this._mBind.GetCom<Toggle>("SkipAnimToggle");
				if (null != this.mSkipAnimToggle)
				{
					this.mSkipAnimToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onSkipAnimToggleToggleValueChange));
				}
				this.mMaterialItemRoot = this._mBind.GetGameObject("MaterialItemRoot");
				this.mMaterialTips = this._mBind.GetCom<Text>("MaterialTips");
				this.mIncreaseRateDrop = this._mBind.GetCom<ComDropDownCustom>("IncreaseRateDrop");
				this.mResultPlaneComAnim = this._mBind.GetCom<ComStrengthenTicketAnim>("ResultPlaneComAnim");
				this.mMergeBtnMask = this._mBind.GetCom<Button>("MergeBtnMask");
				if (null != this.mMergeBtnMask)
				{
					this.mMergeBtnMask.onClick.AddListener(new UnityAction(this._onMergeBtnMaskButtonClick));
				}
				if (this.mBtnMerge != null)
				{
					this.mBtnMergeCD = this.mBtnMerge.gameObject.GetComponent<SetComButtonCD>();
				}
				this.mTipTxt = this._mBind.GetCom<Text>("TipTxt");
			}
			Utility.AttachTo(this._mSelfGo, this._mParentGo, false);
			if (this._mSelfGo)
			{
				this._mSelfGo.CustomActive(false);
			}
			this._Init();
		}

		// Token: 0x060116B1 RID: 71345 RVA: 0x0050CAC4 File Offset: 0x0050AEC4
		public void Destroy()
		{
			this._Clear();
			base._ClearBase();
		}

		// Token: 0x060116B2 RID: 71346 RVA: 0x0050CAD4 File Offset: 0x0050AED4
		public void RefreshView(object model)
		{
			if (this._GetCurrMergeType() == StrengthenTicketMergeType.Material)
			{
				StrengthenTicketMaterialMergeModel currSelectMaterialMergeModel = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CurrSelectMaterialMergeModel;
				if (currSelectMaterialMergeModel == null)
				{
					return;
				}
				this._RefreshMaterialSelected(currSelectMaterialMergeModel);
			}
			else if (this._GetCurrMergeType() == StrengthenTicketMergeType.StrengthenTicket)
			{
				this._RefreshTicketsSelected();
			}
		}

		// Token: 0x060116B3 RID: 71347 RVA: 0x0050CB1C File Offset: 0x0050AF1C
		public void Show()
		{
			this._mSelfGo.CustomActive(true);
		}

		// Token: 0x060116B4 RID: 71348 RVA: 0x0050CB2A File Offset: 0x0050AF2A
		public void Hide()
		{
			this._mSelfGo.CustomActive(false);
		}

		// Token: 0x060116B5 RID: 71349 RVA: 0x0050CB38 File Offset: 0x0050AF38
		public object GetViewModel()
		{
			return this.mViewModel;
		}

		// Token: 0x060116B6 RID: 71350 RVA: 0x0050CB40 File Offset: 0x0050AF40
		public void SetStrengthenTicketMergeSelectTicket(StrengthenTicketMaterialMergeModel mergeModel)
		{
			this.mViewModel = mergeModel;
			if (this.mViewModel == null)
			{
				return;
			}
			List<string> materialMergeIncreaseLevelDescList = DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetMaterialMergeIncreaseLevelDescList(mergeModel);
			this._RefreshMaterialDropdown(materialMergeIncreaseLevelDescList);
			this._EnableMaterialDropdown(true);
			this._ResetMaterialDropdownIndex();
			this._RefreshMaterialSelected(this._GetDropdownFirstIndex());
		}

		// Token: 0x060116B7 RID: 71351 RVA: 0x0050CB8C File Offset: 0x0050AF8C
		public void SetStrengthenTicketFuseRemoveTicket()
		{
			this._RefreshTicketsSelected();
		}

		// Token: 0x060116B8 RID: 71352 RVA: 0x0050CB94 File Offset: 0x0050AF94
		public void SetStrengthenTicketFuseAddTicket()
		{
			this._RefreshTicketsSelected();
		}

		// Token: 0x060116B9 RID: 71353 RVA: 0x0050CB9C File Offset: 0x0050AF9C
		public void SetStrengthenTicketMergeSuccess()
		{
			StrengthenTicketMaterialMergeModel currSelectMaterialMergeModel = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CurrSelectMaterialMergeModel;
			if (currSelectMaterialMergeModel == null)
			{
				return;
			}
			this._RefreshMaterialSelected(currSelectMaterialMergeModel);
		}

		// Token: 0x060116BA RID: 71354 RVA: 0x0050CBC2 File Offset: 0x0050AFC2
		public void SetStrengthenTicketFuseSuccess()
		{
			this._ResetOwnTicketsPreview();
		}

		// Token: 0x060116BB RID: 71355 RVA: 0x0050CBCC File Offset: 0x0050AFCC
		public void SetStrengthenTicketMergeFailed()
		{
			StrengthenTicketMaterialMergeModel currSelectMaterialMergeModel = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CurrSelectMaterialMergeModel;
			if (currSelectMaterialMergeModel == null)
			{
				return;
			}
			this._RefreshMaterialSelected(currSelectMaterialMergeModel);
		}

		// Token: 0x060116BC RID: 71356 RVA: 0x0050CBF2 File Offset: 0x0050AFF2
		public void SetStrengthenTicketFuseFailed()
		{
			this._RefreshTicketsSelected();
		}

		// Token: 0x060116BD RID: 71357 RVA: 0x0050CBFC File Offset: 0x0050AFFC
		public void SetStrengthenTicketFuseCalPercent()
		{
			StrengthenTicketMaterialFuseModel tempMaterialFuseModel = DataManager<StrengthenTicketMergeDataManager>.GetInstance().TempMaterialFuseModel;
			if (tempMaterialFuseModel == null)
			{
				return;
			}
			this._SetTipView(string.Format(this.tr_notice_preview_ticket_fuse, new object[]
			{
				tempMaterialFuseModel.predictMinLevel,
				tempMaterialFuseModel.perdictMinPercent,
				tempMaterialFuseModel.predictMaxLevel,
				tempMaterialFuseModel.perdictMaxPercent
			}));
		}

		// Token: 0x0400B4A2 RID: 46242
		private Coroutine waitToReqMergeTicket;

		// Token: 0x0400B4A3 RID: 46243
		private Coroutine waitToReqFuseTicket;

		// Token: 0x0400B4A4 RID: 46244
		private bool bSkipAnim;

		// Token: 0x0400B4A5 RID: 46245
		private Coroutine waitToPlayNextAnim;

		// Token: 0x0400B4A6 RID: 46246
		private object mViewModel;

		// Token: 0x0400B4A7 RID: 46247
		private StrengthenTicketMergeFrame mSelfFrame;

		// Token: 0x0400B4A8 RID: 46248
		private List<ComItemCustom> mCustomItemGrids = new List<ComItemCustom>();

		// Token: 0x0400B4A9 RID: 46249
		private List<int> mDefaultMergeMaterialItemIds = new List<int>();

		// Token: 0x0400B4AA RID: 46250
		private List<int> mDefaultFuseMaterialItemIds = new List<int>();

		// Token: 0x0400B4AB RID: 46251
		private List<int> mDefaultMergeOnlyShowNeedItemIds = new List<int>();

		// Token: 0x0400B4AC RID: 46252
		private List<int> mNeedFastBuyItemIds = new List<int>();

		// Token: 0x0400B4AD RID: 46253
		private Coroutine waitToCreateGrids;

		// Token: 0x0400B4AE RID: 46254
		private bool bMaterialMergeGridInited;

		// Token: 0x0400B4AF RID: 46255
		private bool bSelectMergeLevelBtnEnable;

		// Token: 0x0400B4B0 RID: 46256
		private int iMaterialGrowthValue = 1;

		// Token: 0x0400B4B1 RID: 46257
		private string tr_notice_select_left_tickets_merge = "请在左侧选择要合成的强化券";

		// Token: 0x0400B4B2 RID: 46258
		private string tr_notice_select_left_tickets_fuse = "请在左侧选择作为材料的强化券";

		// Token: 0x0400B4B3 RID: 46259
		private string tr_notice_material_item_count_format = "{0}/{1}";

		// Token: 0x0400B4B4 RID: 46260
		private string tr_notice_preview_material_merge = "+{0}({1}% - {2}%)";

		// Token: 0x0400B4B5 RID: 46261
		private string tr_notice_preview_ticket_fuse = "最低+{0}({1}%) - 最高+{2}({3}%)";

		// Token: 0x0400B4B6 RID: 46262
		private string tr_notice_please_select_ticket = "请选择强化券";

		// Token: 0x0400B4B7 RID: 46263
		private string tr_notice_desc_less_color_format = "<color=#ff0000ff>{0}</color>";

		// Token: 0x0400B4B8 RID: 46264
		private string tr_notice_desc_normal_color_format = "<color=#ffffffff>{0}</color>";

		// Token: 0x0400B4B9 RID: 46265
		private string tr_notice_merge_material_not_enough = "合成材料不足";

		// Token: 0x0400B4BA RID: 46266
		private string tr_stengthen_tick_mrger_notice_tip = "合成所需的金币减少30%,绑金减少15%（剩余{0}次）";

		// Token: 0x0400B4BB RID: 46267
		private bool mIsNotShowSkillConfigTip;

		// Token: 0x0400B4BC RID: 46268
		private Button mBtnMerge;

		// Token: 0x0400B4BD RID: 46269
		private Toggle mSkipAnimToggle;

		// Token: 0x0400B4BE RID: 46270
		private GameObject mMaterialItemRoot;

		// Token: 0x0400B4BF RID: 46271
		private Text mMaterialTips;

		// Token: 0x0400B4C0 RID: 46272
		private ComDropDownCustom mIncreaseRateDrop;

		// Token: 0x0400B4C1 RID: 46273
		private ComStrengthenTicketAnim mResultPlaneComAnim;

		// Token: 0x0400B4C2 RID: 46274
		private Button mMergeBtnMask;

		// Token: 0x0400B4C3 RID: 46275
		private SetComButtonCD mBtnMergeCD;

		// Token: 0x0400B4C4 RID: 46276
		private Text mTipTxt;
	}
}
