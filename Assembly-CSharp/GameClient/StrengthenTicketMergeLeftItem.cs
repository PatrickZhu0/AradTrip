using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCB RID: 7115
	public class StrengthenTicketMergeLeftItem : CustomClientFrameItem, ICustomClientFrameItem<StrengthenTicketMergeFrame, object>
	{
		// Token: 0x06011664 RID: 71268 RVA: 0x0050A367 File Offset: 0x00508767
		protected override void _Init()
		{
			this._LoadTR();
			this._BindUIEvent();
		}

		// Token: 0x06011665 RID: 71269 RVA: 0x0050A378 File Offset: 0x00508778
		protected override void _Clear()
		{
			this._UnBindUIEvent();
			this.mViewModel = null;
			this.mSelfFrame = null;
			if (this.mFirstMaterialItem != null)
			{
				this.mFirstMaterialItem.Clear();
			}
			this.bMaterialMergeItemListInited = false;
			if (this.waitToMaterialMergeItemToggleOn != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToMaterialMergeItemToggleOn);
				this.waitToMaterialMergeItemToggleOn = null;
			}
			if (this.mReadyComItemCustoms != null)
			{
				for (int i = 0; i < this.mReadyComItemCustoms.Count; i++)
				{
					this.mReadyComItemCustoms[i].Clear();
				}
				this.mReadyComItemCustoms.Clear();
			}
			if (this.mComList != null)
			{
				this.mComList.SetElementAmount(0);
			}
			this.mComList = null;
			this.mTitle = null;
			this.mNocache = null;
			this.tr_select_material_merge = string.Empty;
			this.tr_select_tickets_fuse = string.Empty;
			this.tr_notice_fuse_limitlevel_max = string.Empty;
			this.tr_notice_fuse_item_count_format = string.Empty;
		}

		// Token: 0x06011666 RID: 71270 RVA: 0x0050A480 File Offset: 0x00508880
		private void _LoadTR()
		{
			this.tr_select_material_merge = TR.Value("strengthen_merge_material_default_tip");
			this.tr_select_tickets_fuse = TR.Value("strengthen_merge_ticket_default_tip");
			this.tr_notice_fuse_limitlevel_max = TR.Value("strengthen_merge_fuse_limitlevel_max");
			this.tr_notice_fuse_item_count_format = TR.Value("strengthen_merge_fuse_item_count_format");
		}

		// Token: 0x06011667 RID: 71271 RVA: 0x0050A4CD File Offset: 0x005088CD
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectType, new ClientEventSystem.UIEventHandler(this._OnSrengtheTicketMergeSelectType));
		}

		// Token: 0x06011668 RID: 71272 RVA: 0x0050A4EA File Offset: 0x005088EA
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectType, new ClientEventSystem.UIEventHandler(this._OnSrengtheTicketMergeSelectType));
		}

		// Token: 0x06011669 RID: 71273 RVA: 0x0050A508 File Offset: 0x00508908
		private void _RefreshStrengthTicketContent(StrengthenTicketMergeType mergeType)
		{
			if (mergeType != StrengthenTicketMergeType.Material)
			{
				if (mergeType == StrengthenTicketMergeType.StrengthenTicket)
				{
					this._RefreshFuseStrengthenTickets();
					this._SetTitleName(this.tr_select_tickets_fuse);
				}
			}
			else
			{
				this._RefreshMaterialMergeStrengthenTickets();
				this._SetTitleName(this.tr_select_material_merge);
			}
		}

		// Token: 0x0601166A RID: 71274 RVA: 0x0050A558 File Offset: 0x00508958
		private void _RefreshMaterialMergeStrengthenTickets()
		{
			this.mNocache.CustomActive(false);
			List<StrengthenTicketMaterialMergeModel> mDisplayMaterialMergeModels = DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetDisplayMaterialMergeTicketModels();
			if (mDisplayMaterialMergeModels == null || mDisplayMaterialMergeModels.Count == 0)
			{
				this.mNocache.CustomActive(true);
				return;
			}
			this.mViewModel = mDisplayMaterialMergeModels;
			if (this.mComList == null)
			{
				return;
			}
			if (!this.mComList.IsInitialised())
			{
				this.mComList.Initialize();
				this.mComList.onBindItem = ((GameObject go) => go.GetComponent<ComItemCustom>());
			}
			this.mComList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < mDisplayMaterialMergeModels.Count)
				{
					ComItemCustom customItem = var.gameObjectBindScript as ComItemCustom;
					if (customItem == null)
					{
						return;
					}
					StrengthenTicketMaterialMergeModel model = mDisplayMaterialMergeModels[index];
					if (model == null)
					{
						return;
					}
					if (!model.bDisplay)
					{
						return;
					}
					customItem.Init(false, model.displayItemTableId, false, true, true, ComItemCustomClickType.Toggle);
					customItem.SetDescStr(model.name, true);
					customItem.SetCustomItemSelectActive(false);
					customItem.onTitleToggleClick = delegate(bool isOn)
					{
						customItem.SetCustomItemSelectActive(isOn);
						if (isOn)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeSelectTicket, model, null, null, null);
						}
					};
					if (index == 0)
					{
						this.mFirstMaterialItem = customItem;
					}
					else if (index == mDisplayMaterialMergeModels.Count - 1)
					{
						this.bMaterialMergeItemListInited = true;
					}
				}
			};
			this.mComList.OnItemRecycle = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				ComItemCustom comItemCustom = var.gameObjectBindScript as ComItemCustom;
				if (comItemCustom != null)
				{
					comItemCustom.Clear();
				}
			};
			this.mComList.SetElementAmount(mDisplayMaterialMergeModels.Count);
		}

		// Token: 0x0601166B RID: 71275 RVA: 0x0050A66C File Offset: 0x00508A6C
		private void _RefreshFuseStrengthenTickets()
		{
			StrengthenTicketMergeLeftItem.<_RefreshFuseStrengthenTickets>c__AnonStorey3 <_RefreshFuseStrengthenTickets>c__AnonStorey = new StrengthenTicketMergeLeftItem.<_RefreshFuseStrengthenTickets>c__AnonStorey3();
			<_RefreshFuseStrengthenTickets>c__AnonStorey.$this = this;
			this.mNocache.CustomActive(false);
			<_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets = DataManager<StrengthenTicketMergeDataManager>.GetInstance().GetStrengthenTicketFuseItemDatas(false);
			if (<_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets == null || <_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets.Count == 0)
			{
				this.mNocache.CustomActive(true);
			}
			this.mViewModel = <_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets;
			if (this.mReadyComItemCustoms != null)
			{
				for (int i = 0; i < this.mReadyComItemCustoms.Count; i++)
				{
					this.mReadyComItemCustoms[i].Clear();
				}
				this.mReadyComItemCustoms.Clear();
			}
			if (this.mComList == null)
			{
				return;
			}
			if (!this.mComList.IsInitialised())
			{
				this.mComList.Initialize();
				this.mComList.onBindItem = ((GameObject go) => go.GetComponent<ComItemCustom>());
			}
			this.mComList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < <_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets.Count + 1)
				{
					ComItemCustom customItem = var.gameObjectBindScript as ComItemCustom;
					if (customItem == null)
					{
						return;
					}
					if (index >= <_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets.Count)
					{
						customItem.Init(false, null, true, true, ComItemCustomClickType.Button);
						customItem.SetExtendImgsActive(new List<int>
						{
							0,
							1
						});
						customItem.SetCustomItemSelectActive(false);
						customItem.SetDescStr(string.Empty, true);
						customItem.onItemBtnClick = delegate()
						{
							if (<_RefreshFuseStrengthenTickets>c__AnonStorey.mSelfFrame != null)
							{
								int gotoGetBindItemId = <_RefreshFuseStrengthenTickets>c__AnonStorey.mSelfFrame.GetGotoGetBindItemId();
								ItemComeLink.OnLink(gotoGetBindItemId, 0, false, null, false, false, false, null, string.Empty);
							}
						};
						customItem.transform.SetAsLastSibling();
						customItem.CustomActive(true);
						return;
					}
					StrengthenTicketFuseItemData model = <_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets[index];
					if (model == null)
					{
						return;
					}
					if (model.ticketItemData == null)
					{
						return;
					}
					customItem.Init(false, model.ticketItemData, false, true, ComItemCustomClickType.Button);
					customItem.SetDescStr(model.ticketItemData.Name, true);
					customItem.SetCustomItemSelectActive(false);
					<_RefreshFuseStrengthenTickets>c__AnonStorey.$this._SetCustomComItemCountWithFuseTicket(customItem, model);
					customItem.onItemBtnClick = delegate()
					{
						if (!model.canFuse)
						{
							SystemNotifyManager.SysNotifyTextAnimation(<_RefreshFuseStrengthenTickets>c__AnonStorey.tr_notice_fuse_limitlevel_max, CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
						if (DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckFuseTicketCanAdd(model))
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseAddTicket, null, null, null, null);
							if (<_RefreshFuseStrengthenTickets>c__AnonStorey.mReadyComItemCustoms != null)
							{
								<_RefreshFuseStrengthenTickets>c__AnonStorey.mReadyComItemCustoms.Add(customItem);
							}
							<_RefreshFuseStrengthenTickets>c__AnonStorey._SetCustomComItemCountWithFuseTicket(customItem, model);
						}
					};
					customItem.onExtendBtn1Click = delegate()
					{
						if (DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckFuseTicketCanRemove(model))
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseRemoveTicket, null, null, null, null);
							if (<_RefreshFuseStrengthenTickets>c__AnonStorey.mReadyComItemCustoms != null)
							{
								<_RefreshFuseStrengthenTickets>c__AnonStorey.mReadyComItemCustoms.Remove(customItem);
							}
							<_RefreshFuseStrengthenTickets>c__AnonStorey._SetCustomComItemCountWithFuseTicket(customItem, model);
						}
					};
				}
			};
			this.mComList.OnItemRecycle = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				ComItemCustom comItemCustom = var.gameObjectBindScript as ComItemCustom;
				if (comItemCustom != null)
				{
					comItemCustom.Clear();
				}
			};
			this.mComList.SetElementAmount(<_RefreshFuseStrengthenTickets>c__AnonStorey.ownStrengthenTickets.Count + 1);
		}

		// Token: 0x0601166C RID: 71276 RVA: 0x0050A7C8 File Offset: 0x00508BC8
		private void _SetCustomComItemCountWithFuseTicket(ComItemCustom customItem, StrengthenTicketFuseItemData model)
		{
			if (model == null || customItem == null)
			{
				return;
			}
			bool flag = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckFuseTicketOnReady(model);
			if (flag)
			{
				int num = DataManager<StrengthenTicketMergeDataManager>.GetInstance().CheckFuseTicketNumOnReadyByTableId(model);
				customItem.SetCustomItemCount(false, string.Format(this.tr_notice_fuse_item_count_format, num, model.ticketItemData.Count));
				customItem.SetCustomItemSelectActive(true);
			}
			else
			{
				customItem.SetCustomItemCount(true, string.Empty);
				customItem.SetCustomItemSelectActive(false);
			}
		}

		// Token: 0x0601166D RID: 71277 RVA: 0x0050A84D File Offset: 0x00508C4D
		private void _SetTitleName(string title)
		{
			if (this.mTitle)
			{
				this.mTitle.text = title;
			}
		}

		// Token: 0x0601166E RID: 71278 RVA: 0x0050A86B File Offset: 0x00508C6B
		private StrengthenTicketMergeType _GetCurrMergeType()
		{
			if (this.mSelfFrame == null)
			{
				return StrengthenTicketMergeType.Count;
			}
			return this.mSelfFrame.MergeType;
		}

		// Token: 0x0601166F RID: 71279 RVA: 0x0050A888 File Offset: 0x00508C88
		private void _OnSrengtheTicketMergeSelectType(UIEvent _event)
		{
			if (_event == null)
			{
				return;
			}
			StrengthenTicketMergeType mergeType = (StrengthenTicketMergeType)_event.Param1;
			this._RefreshStrengthTicketContent(mergeType);
		}

		// Token: 0x06011670 RID: 71280 RVA: 0x0050A8B0 File Offset: 0x00508CB0
		public void Create(StrengthenTicketMergeFrame frame, GameObject parent)
		{
			this._mParentGo = parent;
			this.mSelfFrame = frame;
			if (this._mSelfGo == null)
			{
				this._mSelfGo = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/StrengthenTicketMerge/StrengthenTicketMergeLeftItem", true, 0U);
			}
			if (this._mSelfGo != null)
			{
				this._mBind = this._mSelfGo.GetComponent<ComCommonBind>();
			}
			if (this._mBind != null)
			{
				this.mComList = this._mBind.GetCom<ComUIListScript>("ComList");
				this.mTitle = this._mBind.GetCom<Text>("Title");
				this.mNocache = this._mBind.GetCom<Text>("nocache");
			}
			Utility.AttachTo(this._mSelfGo, this._mParentGo, false);
			this.mNocache.CustomActive(false);
			if (this._mSelfGo)
			{
				this._mSelfGo.CustomActive(false);
			}
			this._Init();
		}

		// Token: 0x06011671 RID: 71281 RVA: 0x0050A9A8 File Offset: 0x00508DA8
		public void Destroy()
		{
			this._Clear();
			base._ClearBase();
		}

		// Token: 0x06011672 RID: 71282 RVA: 0x0050A9B6 File Offset: 0x00508DB6
		public void RefreshView(object model)
		{
			if (this._GetCurrMergeType() == StrengthenTicketMergeType.StrengthenTicket)
			{
				this._RefreshFuseStrengthenTickets();
			}
		}

		// Token: 0x06011673 RID: 71283 RVA: 0x0050A9CA File Offset: 0x00508DCA
		public object GetViewModel()
		{
			return this.mViewModel;
		}

		// Token: 0x06011674 RID: 71284 RVA: 0x0050A9D2 File Offset: 0x00508DD2
		public void Show()
		{
			this._mSelfGo.CustomActive(true);
		}

		// Token: 0x06011675 RID: 71285 RVA: 0x0050A9E0 File Offset: 0x00508DE0
		public void Hide()
		{
			this._mSelfGo.CustomActive(false);
		}

		// Token: 0x06011676 RID: 71286 RVA: 0x0050A9F0 File Offset: 0x00508DF0
		public void SetStrengthenTicketFuseRemoveTicket(StrengthenTicketFuseItemData ticketFuseItemData)
		{
			if (this.mReadyComItemCustoms == null)
			{
				return;
			}
			if (ticketFuseItemData == null || ticketFuseItemData.ticketItemData == null)
			{
				return;
			}
			for (int i = 0; i < this.mReadyComItemCustoms.Count; i++)
			{
				ComItemCustom comItemCustom = this.mReadyComItemCustoms[i];
				if (!(comItemCustom == null) && comItemCustom.M_ItemData != null)
				{
					if (comItemCustom.M_ItemData.TableID.Equals(ticketFuseItemData.ticketItemData.TableID))
					{
						this._SetCustomComItemCountWithFuseTicket(comItemCustom, ticketFuseItemData);
						this.mReadyComItemCustoms.Remove(comItemCustom);
						break;
					}
				}
			}
		}

		// Token: 0x06011677 RID: 71287 RVA: 0x0050AA9D File Offset: 0x00508E9D
		public void SetStrengthenTicketFuseAddTicket()
		{
		}

		// Token: 0x06011678 RID: 71288 RVA: 0x0050AA9F File Offset: 0x00508E9F
		public void SetStrengthenTicketFuseSuccess()
		{
			this._RefreshFuseStrengthenTickets();
		}

		// Token: 0x06011679 RID: 71289 RVA: 0x0050AAA7 File Offset: 0x00508EA7
		public void SetResetItemSelect()
		{
			if (this.waitToMaterialMergeItemToggleOn != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToMaterialMergeItemToggleOn);
			}
			this.waitToMaterialMergeItemToggleOn = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToSetFirstMaterialItemToggleOn());
		}

		// Token: 0x0601167A RID: 71290 RVA: 0x0050AADC File Offset: 0x00508EDC
		private IEnumerator _WaitToSetFirstMaterialItemToggleOn()
		{
			float waitTime = 0.2f;
			if (this.mSelfFrame != null)
			{
				waitTime = this.mSelfFrame.GetWaitToSelectMaterialFirstItemTime();
			}
			yield return Yielders.GetWaitForSeconds(waitTime);
			if (this.mFirstMaterialItem != null && this.bMaterialMergeItemListInited)
			{
				this.mFirstMaterialItem.SetCustomItemToggleOn(true);
			}
			yield break;
		}

		// Token: 0x0400B491 RID: 46225
		private object mViewModel;

		// Token: 0x0400B492 RID: 46226
		private StrengthenTicketMergeFrame mSelfFrame;

		// Token: 0x0400B493 RID: 46227
		private ComItemCustom mFirstMaterialItem;

		// Token: 0x0400B494 RID: 46228
		private bool bMaterialMergeItemListInited;

		// Token: 0x0400B495 RID: 46229
		private Coroutine waitToMaterialMergeItemToggleOn;

		// Token: 0x0400B496 RID: 46230
		private List<ComItemCustom> mReadyComItemCustoms = new List<ComItemCustom>();

		// Token: 0x0400B497 RID: 46231
		private string tr_select_material_merge = "选择要合成的强化券";

		// Token: 0x0400B498 RID: 46232
		private string tr_select_tickets_fuse = "选择2张需要融合的强化券";

		// Token: 0x0400B499 RID: 46233
		private string tr_notice_fuse_limitlevel_max = "此强化券不能进行融合";

		// Token: 0x0400B49A RID: 46234
		private string tr_notice_fuse_item_count_format = "<color=#ff0000ff>{0}</color>/{1}";

		// Token: 0x0400B49B RID: 46235
		private ComUIListScript mComList;

		// Token: 0x0400B49C RID: 46236
		private Text mTitle;

		// Token: 0x0400B49D RID: 46237
		private Text mNocache;
	}
}
