using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCA RID: 7114
	public class StrengthenTicketMergeFrame : ClientFrame
	{
		// Token: 0x17001DAD RID: 7597
		// (get) Token: 0x06011638 RID: 71224 RVA: 0x00509820 File Offset: 0x00507C20
		public StrengthenTicketMergeType MergeType
		{
			get
			{
				return this.mergeType;
			}
		}

		// Token: 0x17001DAE RID: 7598
		// (get) Token: 0x06011639 RID: 71225 RVA: 0x00509828 File Offset: 0x00507C28
		// (set) Token: 0x0601163A RID: 71226 RVA: 0x00509830 File Offset: 0x00507C30
		public StrengthenTicketMergeStage CurrMergeStage
		{
			get
			{
				return this.currMergeStage;
			}
			set
			{
				this.currMergeStage = value;
			}
		}

		// Token: 0x0601163B RID: 71227 RVA: 0x00509839 File Offset: 0x00507C39
		protected override void _OnOpenFrame()
		{
			this._Init();
			this._BindUIEvent();
		}

		// Token: 0x0601163C RID: 71228 RVA: 0x00509847 File Offset: 0x00507C47
		protected override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
			this._Clear();
		}

		// Token: 0x0601163D RID: 71229 RVA: 0x00509858 File Offset: 0x00507C58
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSelectTicket));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFuseAddTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseAddTicket));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFuseRemoveTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseRemoveTicket));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSuccess, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFuseSuccess, new ClientEventSystem.UIEventHandler(this._OnStrengtheTicketFuseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeFailed, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFuseFailed, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketFuseCalPercent, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseCalPercent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectReset, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSelectReset));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketStartMerge, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketStartMerge));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this._OnGoldChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BindGoldChanged, new ClientEventSystem.UIEventHandler(this._OnBindGoldChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMallBuySuccess, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMallBuySuccess));
		}

		// Token: 0x0601163E RID: 71230 RVA: 0x005099C0 File Offset: 0x00507DC0
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSelectTicket));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFuseRemoveTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseRemoveTicket));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFuseAddTicket, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseAddTicket));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSuccess, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFuseSuccess, new ClientEventSystem.UIEventHandler(this._OnStrengtheTicketFuseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeFailed, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFuseFailed, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketFuseCalPercent, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketFuseCalPercent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeSelectReset, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMergeSelectReset));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketStartMerge, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketStartMerge));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this._OnGoldChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BindGoldChanged, new ClientEventSystem.UIEventHandler(this._OnBindGoldChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMallBuySuccess, new ClientEventSystem.UIEventHandler(this._OnStrengthenTicketMallBuySuccess));
		}

		// Token: 0x0601163F RID: 71231 RVA: 0x00509B26 File Offset: 0x00507F26
		private void _Init()
		{
			this._SetMergeTypeTogglesInteractable(false);
			if (this._waitToInitFrame != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._waitToInitFrame);
			}
			this._waitToInitFrame = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToInitView());
		}

		// Token: 0x06011640 RID: 71232 RVA: 0x00509B60 File Offset: 0x00507F60
		private void _InitLeftItem()
		{
			if (this._mStrengthenTicketMergeLeftItem == null)
			{
				this._mStrengthenTicketMergeLeftItem = new StrengthenTicketMergeLeftItem();
				this._mStrengthenTicketMergeLeftItem.Create(this, this.mLeftView);
				this._mStrengthenTicketMergeLeftItem.Show();
			}
		}

		// Token: 0x06011641 RID: 71233 RVA: 0x00509B95 File Offset: 0x00507F95
		private void _InitRightItem()
		{
			if (this._mStrengthenTicketMergeRightItem == null)
			{
				this._mStrengthenTicketMergeRightItem = new StrengthenTicketMergeRightItem();
				this._mStrengthenTicketMergeRightItem.Create(this, this.mRightView);
				this._mStrengthenTicketMergeRightItem.Show();
			}
		}

		// Token: 0x06011642 RID: 71234 RVA: 0x00509BCC File Offset: 0x00507FCC
		private IEnumerator _WaitToInitView()
		{
			this._InitLeftItem();
			this._InitRightItem();
			yield return null;
			this._SetMergeTypeTogglesInteractable(true);
			this.mergeType = StrengthenTicketMergeType.Material;
			if (this.LevelTypes != null && this.LevelTypes.Length == 2)
			{
				this.LevelTypes[(int)this.mergeType].isOn = true;
			}
			yield break;
		}

		// Token: 0x06011643 RID: 71235 RVA: 0x00509BE8 File Offset: 0x00507FE8
		private void _Clear()
		{
			this.mergeType = StrengthenTicketMergeType.Count;
			if (this._mStrengthenTicketMergeLeftItem != null)
			{
				this._mStrengthenTicketMergeLeftItem.Destroy();
				this._mStrengthenTicketMergeLeftItem = null;
			}
			if (this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.Destroy();
				this._mStrengthenTicketMergeRightItem = null;
			}
			if (this._waitToInitFrame != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._waitToInitFrame);
				this._waitToInitFrame = null;
			}
		}

		// Token: 0x06011644 RID: 71236 RVA: 0x00509C58 File Offset: 0x00508058
		[UIEventHandle("Titleback/Tab{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void _OnSelectMergeType(int iIndex, bool isOn)
		{
			if (this.currMergeStage == StrengthenTicketMergeStage.Process)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_merge_be_process_stage"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (iIndex < 0 || !isOn)
			{
				return;
			}
			this.mergeType = (StrengthenTicketMergeType)iIndex;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeSelectType, iIndex, null, null, null);
		}

		// Token: 0x06011645 RID: 71237 RVA: 0x00509CB0 File Offset: 0x005080B0
		private void _SetMergeTypeTogglesInteractable(bool ineractable)
		{
			if (this.LevelTypes == null || this.LevelTypes.Length != 2)
			{
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				this.LevelTypes[i].interactable = ineractable;
			}
		}

		// Token: 0x06011646 RID: 71238 RVA: 0x00509CF8 File Offset: 0x005080F8
		private void _OnStrengthenTicketMergeSelectTicket(UIEvent _event)
		{
			if (_event == null)
			{
				return;
			}
			if (this.mergeType == StrengthenTicketMergeType.Material)
			{
				StrengthenTicketMaterialMergeModel strengthenTicketMergeSelectTicket = _event.Param1 as StrengthenTicketMaterialMergeModel;
				if (this._mStrengthenTicketMergeRightItem != null)
				{
					this._mStrengthenTicketMergeRightItem.SetStrengthenTicketMergeSelectTicket(strengthenTicketMergeSelectTicket);
				}
			}
		}

		// Token: 0x06011647 RID: 71239 RVA: 0x00509D3C File Offset: 0x0050813C
		private void _OnStrengthenTicketFuseRemoveTicket(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.StrengthenTicket)
			{
				if (this._mStrengthenTicketMergeRightItem != null)
				{
					this._mStrengthenTicketMergeRightItem.SetStrengthenTicketFuseRemoveTicket();
				}
				if (this._mStrengthenTicketMergeLeftItem != null && _event != null && _event.Param1 != null)
				{
					StrengthenTicketFuseItemData strengthenTicketFuseRemoveTicket = _event.Param1 as StrengthenTicketFuseItemData;
					this._mStrengthenTicketMergeLeftItem.SetStrengthenTicketFuseRemoveTicket(strengthenTicketFuseRemoveTicket);
				}
			}
		}

		// Token: 0x06011648 RID: 71240 RVA: 0x00509D9F File Offset: 0x0050819F
		private void _OnStrengthenTicketFuseAddTicket(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.StrengthenTicket)
			{
				if (this._mStrengthenTicketMergeRightItem != null)
				{
					this._mStrengthenTicketMergeRightItem.SetStrengthenTicketFuseAddTicket();
				}
				if (this._mStrengthenTicketMergeLeftItem != null)
				{
					this._mStrengthenTicketMergeLeftItem.SetStrengthenTicketFuseAddTicket();
				}
			}
		}

		// Token: 0x06011649 RID: 71241 RVA: 0x00509DD9 File Offset: 0x005081D9
		private void _OnStrengthenTicketMergeSuccess(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.Material && this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.SetStrengthenTicketMergeSuccess();
			}
			this._SetMergeTypeTogglesInteractable(true);
		}

		// Token: 0x0601164A RID: 71242 RVA: 0x00509E04 File Offset: 0x00508204
		private void _OnStrengtheTicketFuseSuccess(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.StrengthenTicket)
			{
				if (this._mStrengthenTicketMergeRightItem != null)
				{
					this._mStrengthenTicketMergeRightItem.SetStrengthenTicketFuseSuccess();
				}
				if (this._mStrengthenTicketMergeLeftItem != null)
				{
					this._mStrengthenTicketMergeLeftItem.SetStrengthenTicketFuseSuccess();
				}
			}
			this._SetMergeTypeTogglesInteractable(true);
		}

		// Token: 0x0601164B RID: 71243 RVA: 0x00509E50 File Offset: 0x00508250
		private void _OnStrengthenTicketMergeFailed(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.Material && this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.SetStrengthenTicketMergeFailed();
			}
			this._SetMergeTypeTogglesInteractable(true);
		}

		// Token: 0x0601164C RID: 71244 RVA: 0x00509E7A File Offset: 0x0050827A
		private void _OnStrengthenTicketFuseFailed(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.StrengthenTicket && this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.SetStrengthenTicketFuseFailed();
			}
			this._SetMergeTypeTogglesInteractable(true);
		}

		// Token: 0x0601164D RID: 71245 RVA: 0x00509EA5 File Offset: 0x005082A5
		private void _OnStrengthenTicketFuseCalPercent(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.StrengthenTicket && this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.SetStrengthenTicketFuseCalPercent();
			}
		}

		// Token: 0x0601164E RID: 71246 RVA: 0x00509EC9 File Offset: 0x005082C9
		private void _OnStrengthenTicketMergeSelectReset(UIEvent _event)
		{
			if (this.mergeType == StrengthenTicketMergeType.Material && this._mStrengthenTicketMergeLeftItem != null)
			{
				this._mStrengthenTicketMergeLeftItem.SetResetItemSelect();
			}
		}

		// Token: 0x0601164F RID: 71247 RVA: 0x00509EEC File Offset: 0x005082EC
		private void _OnStrengthenTicketStartMerge(UIEvent _event)
		{
			this._SetMergeTypeTogglesInteractable(false);
		}

		// Token: 0x06011650 RID: 71248 RVA: 0x00509EF5 File Offset: 0x005082F5
		private void _OnGoldChanged(UIEvent _event)
		{
			if (this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.RefreshView(null);
			}
		}

		// Token: 0x06011651 RID: 71249 RVA: 0x00509F0E File Offset: 0x0050830E
		private void _OnBindGoldChanged(UIEvent _event)
		{
			if (this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.RefreshView(null);
			}
		}

		// Token: 0x06011652 RID: 71250 RVA: 0x00509F27 File Offset: 0x00508327
		private void _OnStrengthenTicketMallBuySuccess(UIEvent _event)
		{
			if (this._mStrengthenTicketMergeRightItem != null)
			{
				this._mStrengthenTicketMergeRightItem.RefreshView(null);
			}
		}

		// Token: 0x06011653 RID: 71251 RVA: 0x00509F40 File Offset: 0x00508340
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/StrengthenTicketMerge/StrengthenTicketMergeFrame";
		}

		// Token: 0x06011654 RID: 71252 RVA: 0x00509F47 File Offset: 0x00508347
		public List<int> GetMergeBindItemIds()
		{
			if (this.mComBindItemIds == null)
			{
				return new List<int>();
			}
			return this.mComBindItemIds.mergeBindItemIds;
		}

		// Token: 0x06011655 RID: 71253 RVA: 0x00509F6B File Offset: 0x0050836B
		public List<int> GetSpecialMergeBindItemIds()
		{
			if (this.mComBindItemIds == null)
			{
				return new List<int>();
			}
			return this.mComBindItemIds.specialMergeItemIds;
		}

		// Token: 0x06011656 RID: 71254 RVA: 0x00509F8F File Offset: 0x0050838F
		public List<int> GetFuseBindItemIds()
		{
			if (this.mComBindItemIds == null)
			{
				return new List<int>();
			}
			return this.mComBindItemIds.fuseBindItemIds;
		}

		// Token: 0x06011657 RID: 71255 RVA: 0x00509FB3 File Offset: 0x005083B3
		public int GetGotoGetBindItemId()
		{
			if (this.mComBindItemIds == null)
			{
				return 0;
			}
			return this.mComBindItemIds.getBindItemId;
		}

		// Token: 0x06011658 RID: 71256 RVA: 0x00509FD3 File Offset: 0x005083D3
		public List<int> GetMergeOnlyShowNeedCountItemIds()
		{
			if (this.mComBindItemIds == null)
			{
				return new List<int>();
			}
			return this.mComBindItemIds.onlyShowNeedCountItemIds;
		}

		// Token: 0x06011659 RID: 71257 RVA: 0x00509FF8 File Offset: 0x005083F8
		public int GetFuseMaterialGridCount()
		{
			if (this.mComBindItemIds == null)
			{
				return 0;
			}
			int fuseTicketCount = this.GetFuseTicketCount();
			int num = 0;
			List<int> fuseBindItemIds = this.GetFuseBindItemIds();
			if (fuseBindItemIds != null)
			{
				num = fuseBindItemIds.Count;
			}
			return fuseTicketCount + num;
		}

		// Token: 0x0601165A RID: 71258 RVA: 0x0050A038 File Offset: 0x00508438
		public int GetFuseTicketCount()
		{
			if (this.mComBindItemIds == null)
			{
				return 2;
			}
			return this.mComBindItemIds.fuseTicketCount;
		}

		// Token: 0x0601165B RID: 71259 RVA: 0x0050A058 File Offset: 0x00508458
		public float GetWaitToLoadEffectPlaneTime()
		{
			if (this.mComBindItemIds == null)
			{
				return 0f;
			}
			return this.mComBindItemIds.waitToLoadEffectPlane;
		}

		// Token: 0x0601165C RID: 71260 RVA: 0x0050A07C File Offset: 0x0050847C
		public void SetComConsumeItemActive(int itemId, bool active)
		{
			if (this.mComConsumeGroup != null)
			{
				this.mComConsumeGroup.SetItemActiveByItemId(itemId, active);
			}
		}

		// Token: 0x0601165D RID: 71261 RVA: 0x0050A09C File Offset: 0x0050849C
		public void SetComConsumeItemsActive(bool active)
		{
			if (this.mComConsumeGroup != null)
			{
				this.mComConsumeGroup.SetAllItemActive(active);
			}
		}

		// Token: 0x0601165E RID: 71262 RVA: 0x0050A0BB File Offset: 0x005084BB
		public float GetWaitToSelectMaterialFirstItemTime()
		{
			if (this.mComBindItemIds == null)
			{
				return 0.2f;
			}
			return this.mComBindItemIds.waitToSelectMaterialFirstItem;
		}

		// Token: 0x0601165F RID: 71263 RVA: 0x0050A0DF File Offset: 0x005084DF
		public List<int> GetNeedFastBuyItemIds()
		{
			if (this.mComBindItemIds == null)
			{
				return new List<int>();
			}
			return this.mComBindItemIds.needFastButItemIds;
		}

		// Token: 0x06011660 RID: 71264 RVA: 0x0050A104 File Offset: 0x00508504
		protected override void _bindExUI()
		{
			this.mNocache = this.mBind.GetGameObject("nocache");
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mLeftView = this.mBind.GetGameObject("leftView");
			this.mRightView = this.mBind.GetGameObject("rightView");
			this.mComBindItemIds = this.mBind.GetCom<ComDefaultBindItemIds>("comBindItemIds");
			this.mComConsumeGroup = this.mBind.GetCom<ComConsumeItemGroup>("ComConsumeGroup");
		}

		// Token: 0x06011661 RID: 71265 RVA: 0x0050A1C4 File Offset: 0x005085C4
		protected override void _unbindExUI()
		{
			this.mNocache = null;
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnClose = null;
			this.mLeftView = null;
			this.mRightView = null;
			this.mComBindItemIds = null;
			this.mComConsumeGroup = null;
		}

		// Token: 0x06011662 RID: 71266 RVA: 0x0050A228 File Offset: 0x00508628
		private void _onBtnCloseButtonClick()
		{
			this.frameMgr.CloseFrame<StrengthenTicketMergeFrame>(this, false);
		}

		// Token: 0x0400B482 RID: 46210
		public const string LEFT_VIEW_FRAME_RES_PATH = "UIFlatten/Prefabs/StrengthenTicketMerge/StrengthenTicketMergeLeftItem";

		// Token: 0x0400B483 RID: 46211
		public const string RIGHT_VIEW_FRAME_RES_PATH = "UIFlatten/Prefabs/StrengthenTicketMerge/StrengthenTicketMergeRightItem";

		// Token: 0x0400B484 RID: 46212
		public const string CUSTOM_COM_ITEM_RES_PATH = "UIFlatten/Prefabs/StrengthenTicketMerge/ComItemCustom";

		// Token: 0x0400B485 RID: 46213
		private StrengthenTicketMergeType mergeType = StrengthenTicketMergeType.Count;

		// Token: 0x0400B486 RID: 46214
		private StrengthenTicketMergeStage currMergeStage;

		// Token: 0x0400B487 RID: 46215
		private StrengthenTicketMergeLeftItem _mStrengthenTicketMergeLeftItem;

		// Token: 0x0400B488 RID: 46216
		private StrengthenTicketMergeRightItem _mStrengthenTicketMergeRightItem;

		// Token: 0x0400B489 RID: 46217
		private Coroutine _waitToInitFrame;

		// Token: 0x0400B48A RID: 46218
		[UIControl("Titleback/Tab{0}", typeof(Toggle), 1)]
		private Toggle[] LevelTypes = new Toggle[2];

		// Token: 0x0400B48B RID: 46219
		private GameObject mNocache;

		// Token: 0x0400B48C RID: 46220
		private Button mBtnClose;

		// Token: 0x0400B48D RID: 46221
		private GameObject mLeftView;

		// Token: 0x0400B48E RID: 46222
		private GameObject mRightView;

		// Token: 0x0400B48F RID: 46223
		private ComDefaultBindItemIds mComBindItemIds;

		// Token: 0x0400B490 RID: 46224
		private ComConsumeItemGroup mComConsumeGroup;
	}
}
