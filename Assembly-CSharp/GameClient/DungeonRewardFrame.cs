using System;
using System.Collections;
using ActivityLimitTime;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010B3 RID: 4275
	[LoggerModel("Chapter")]
	public class DungeonRewardFrame : ClientFrame
	{
		// Token: 0x1700199B RID: 6555
		// (get) Token: 0x0600A147 RID: 41287 RVA: 0x0020B2E8 File Offset: 0x002096E8
		// (set) Token: 0x0600A148 RID: 41288 RVA: 0x0020B2F0 File Offset: 0x002096F0
		public DungeonTable.eCardType mCurCarType
		{
			get
			{
				return this._mCurCarType;
			}
			set
			{
				this._mCurCarType = value;
			}
		}

		// Token: 0x1700199C RID: 6556
		// (get) Token: 0x0600A149 RID: 41289 RVA: 0x0020B2F9 File Offset: 0x002096F9
		// (set) Token: 0x0600A14A RID: 41290 RVA: 0x0020B301 File Offset: 0x00209701
		private DungeonRewardFrame.eFlipProcess mCurProcessStatus
		{
			get
			{
				return this._mCurprocess;
			}
			set
			{
				this._mCurprocess = value;
			}
		}

		// Token: 0x0600A14B RID: 41291 RVA: 0x0020B30C File Offset: 0x0020970C
		protected override void _bindExUI()
		{
			this.mCount10 = this.mBind.GetCom<ComCountScript>("count10");
			this.mNormalGroup = this.mBind.GetCom<HorizontalLayoutGroup>("NormalGroup");
			this.mAnotherGrayGroup = this.mBind.GetCom<UIGray>("AnotherGrayGroup");
			this.mNormalRewardList[0] = this.mBind.GetCom<Button>("NormalReward0");
			this.mNormalRewardList[0].onClick.AddListener(new UnityAction(this._onNormalReward0ButtonClick));
			this.mNormalRewardList[1] = this.mBind.GetCom<Button>("NormalReward1");
			this.mNormalRewardList[1].onClick.AddListener(new UnityAction(this._onNormalReward1ButtonClick));
			this.mNormalRewardList[2] = this.mBind.GetCom<Button>("NormalReward2");
			this.mNormalRewardList[2].onClick.AddListener(new UnityAction(this._onNormalReward2ButtonClick));
			this.mNormalRewardList[3] = this.mBind.GetCom<Button>("NormalReward3");
			this.mNormalRewardList[3].onClick.AddListener(new UnityAction(this._onNormalReward3ButtonClick));
			this.mAnotherRewardList[0] = this.mBind.GetCom<Button>("AnotherReward0");
			this.mAnotherRewardList[0].onClick.AddListener(new UnityAction(this._onAnotherReward0ButtonClick));
			this.mAnotherRewardList[1] = this.mBind.GetCom<Button>("AnotherReward1");
			this.mAnotherRewardList[1].onClick.AddListener(new UnityAction(this._onAnotherReward1ButtonClick));
			this.mAnotherRewardList[2] = this.mBind.GetCom<Button>("AnotherReward2");
			this.mAnotherRewardList[2].onClick.AddListener(new UnityAction(this._onAnotherReward2ButtonClick));
			this.mAnotherRewardList[3] = this.mBind.GetCom<Button>("AnotherReward3");
			this.mAnotherRewardList[3].onClick.AddListener(new UnityAction(this._onAnotherReward3ButtonClick));
			this.mAnotherRewardCostList[0] = this.mBind.GetCom<Text>("AnotherRewardCost0");
			this.mAnotherRewardCostList[1] = this.mBind.GetCom<Text>("AnotherRewardCost1");
			this.mAnotherRewardCostList[2] = this.mBind.GetCom<Text>("AnotherRewardCost2");
			this.mAnotherRewardCostList[3] = this.mBind.GetCom<Text>("AnotherRewardCost3");
			this.mTip = this.mBind.GetCom<Text>("Tip");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mNormalRoot = this.mBind.GetGameObject("NormalRoot");
			this.mVipRoot = this.mBind.GetGameObject("VipRoot");
			this.mVipLevel = this.mBind.GetCom<Text>("VipLevel");
			this.mVipLeft = this.mBind.GetCom<Text>("VipLeft");
			this.mVipSum = this.mBind.GetCom<Text>("VipSum");
			this.mCostTypeName = this.mBind.GetCom<Text>("CostTypeName");
			this.mAnotherRewardCostIconList[0] = this.mBind.GetCom<Image>("AnotherRewardCostIcon0");
			this.mAnotherRewardCostIconList[1] = this.mBind.GetCom<Image>("AnotherRewardCostIcon1");
			this.mAnotherRewardCostIconList[2] = this.mBind.GetCom<Image>("AnotherRewardCostIcon2");
			this.mAnotherRewardCostIconList[3] = this.mBind.GetCom<Image>("AnotherRewardCostIcon3");
			this.mHellCostTypeName = this.mBind.GetCom<Text>("HellCostTypeName");
			this.mHellRoot = this.mBind.GetGameObject("HellRoot");
			this.mCentTextRoot = this.mBind.GetGameObject("centTextRoot");
			this.mNotOpenRoot = this.mBind.GetGameObject("NotOpenRoot");
			this.mNotOpenLevel = this.mBind.GetCom<Text>("NotOpenLevel");
			this.mCountRoot = this.mBind.GetGameObject("CountRoot");
			this.mNormalVipRewards[0] = this.mBind.GetCom<Button>("NormalVipReward0");
			this.mNormalVipRewards[0].onClick.AddListener(new UnityAction(this._onNormalVipReward0ButtonClick));
			this.mNormalVipRewards[1] = this.mBind.GetCom<Button>("NormalVipReward1");
			this.mNormalVipRewards[1].onClick.AddListener(new UnityAction(this._onNormalVipReward1ButtonClick));
			this.mNormalVipRewards[2] = this.mBind.GetCom<Button>("NormalVipReward2");
			this.mNormalVipRewards[2].onClick.AddListener(new UnityAction(this._onNormalVipReward2ButtonClick));
			this.mNormalVipRewards[3] = this.mBind.GetCom<Button>("NormalVipReward3");
			this.mNormalVipRewards[3].onClick.AddListener(new UnityAction(this._onNormalVipReward3ButtonClick));
			this.mInfomationCanvasGroup = this.mBind.GetCom<CanvasGroup>("InfomationCanvasGroup");
			this.mFatigueCombustionRoot = this.mBind.GetGameObject("FatigueCombustionRoot");
			this.mCrossServiceFlipCardNumberRoot = this.mBind.GetGameObject("CrossServiceFlipCardNumberRoot");
			this.mMidRoot = this.mBind.GetGameObject("MidRoot");
			this.mAnotherWorldCardRoot = this.mBind.GetGameObject("AnotherWorldCardRoot");
			this.mTitleRoot = this.mBind.GetGameObject("Title");
			this.mYiJieTitleRoot = this.mBind.GetGameObject("YiJieTitle");
			this.mCard2Root = this.mBind.GetGameObject("Card2Root");
			this.mCard3Root = this.mBind.GetGameObject("Card3Root");
		}

		// Token: 0x0600A14C RID: 41292 RVA: 0x0020B8BC File Offset: 0x00209CBC
		protected override void _unbindExUI()
		{
			this.mCount10 = null;
			this.mNormalGroup = null;
			this.mAnotherGrayGroup = null;
			this.mNormalRewardList[0].onClick.RemoveListener(new UnityAction(this._onNormalReward0ButtonClick));
			this.mNormalRewardList[0] = null;
			this.mNormalRewardList[1].onClick.RemoveListener(new UnityAction(this._onNormalReward1ButtonClick));
			this.mNormalRewardList[1] = null;
			this.mNormalRewardList[2].onClick.RemoveListener(new UnityAction(this._onNormalReward2ButtonClick));
			this.mNormalRewardList[2] = null;
			this.mNormalRewardList[3].onClick.RemoveListener(new UnityAction(this._onNormalReward3ButtonClick));
			this.mNormalRewardList[3] = null;
			this.mAnotherRewardList[0].onClick.RemoveListener(new UnityAction(this._onAnotherReward0ButtonClick));
			this.mAnotherRewardList[0] = null;
			this.mAnotherRewardList[1].onClick.RemoveListener(new UnityAction(this._onAnotherReward1ButtonClick));
			this.mAnotherRewardList[1] = null;
			this.mAnotherRewardList[2].onClick.RemoveListener(new UnityAction(this._onAnotherReward2ButtonClick));
			this.mAnotherRewardList[2] = null;
			this.mAnotherRewardList[3].onClick.RemoveListener(new UnityAction(this._onAnotherReward3ButtonClick));
			this.mAnotherRewardList[3] = null;
			this.mAnotherRewardCostList[0] = null;
			this.mAnotherRewardCostList[1] = null;
			this.mAnotherRewardCostList[2] = null;
			this.mAnotherRewardCostList[3] = null;
			this.mTip = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mNormalRoot = null;
			this.mVipRoot = null;
			this.mVipLevel = null;
			this.mVipLeft = null;
			this.mVipSum = null;
			this.mCostTypeName = null;
			this.mAnotherRewardCostIconList[0] = null;
			this.mAnotherRewardCostIconList[1] = null;
			this.mAnotherRewardCostIconList[2] = null;
			this.mAnotherRewardCostIconList[3] = null;
			this.mHellCostTypeName = null;
			this.mHellRoot = null;
			this.mCentTextRoot = null;
			this.mNotOpenRoot = null;
			this.mNotOpenLevel = null;
			this.mCountRoot = null;
			this.mNormalVipRewards[0].onClick.RemoveListener(new UnityAction(this._onNormalVipReward0ButtonClick));
			this.mNormalVipRewards[0] = null;
			this.mNormalVipRewards[1].onClick.RemoveListener(new UnityAction(this._onNormalVipReward1ButtonClick));
			this.mNormalVipRewards[1] = null;
			this.mNormalVipRewards[2].onClick.RemoveListener(new UnityAction(this._onNormalVipReward2ButtonClick));
			this.mNormalVipRewards[2] = null;
			this.mNormalVipRewards[3].onClick.RemoveListener(new UnityAction(this._onNormalVipReward3ButtonClick));
			this.mNormalVipRewards[3] = null;
			this.mInfomationCanvasGroup = null;
			this.mFatigueCombustionRoot = null;
			this.mCrossServiceFlipCardNumberRoot = null;
			this.mMidRoot = null;
			this.mAnotherWorldCardRoot = null;
			this.mTitleRoot = null;
			this.mYiJieTitleRoot = null;
			this.mCard2Root = null;
			this.mCard3Root = null;
		}

		// Token: 0x0600A14D RID: 41293 RVA: 0x0020BBB7 File Offset: 0x00209FB7
		private void _onNormalReward0ButtonClick()
		{
			this._onClickReward(0);
		}

		// Token: 0x0600A14E RID: 41294 RVA: 0x0020BBC0 File Offset: 0x00209FC0
		private void _onNormalReward1ButtonClick()
		{
			this._onClickReward(1);
		}

		// Token: 0x0600A14F RID: 41295 RVA: 0x0020BBC9 File Offset: 0x00209FC9
		private void _onNormalReward2ButtonClick()
		{
			this._onClickReward(2);
		}

		// Token: 0x0600A150 RID: 41296 RVA: 0x0020BBD2 File Offset: 0x00209FD2
		private void _onNormalReward3ButtonClick()
		{
			this._onClickReward(3);
		}

		// Token: 0x0600A151 RID: 41297 RVA: 0x0020BBDB File Offset: 0x00209FDB
		private void _onAnotherReward0ButtonClick()
		{
			this._onClickAnotherReward(0);
		}

		// Token: 0x0600A152 RID: 41298 RVA: 0x0020BBE4 File Offset: 0x00209FE4
		private void _onAnotherReward1ButtonClick()
		{
			this._onClickAnotherReward(1);
		}

		// Token: 0x0600A153 RID: 41299 RVA: 0x0020BBED File Offset: 0x00209FED
		private void _onAnotherReward2ButtonClick()
		{
			this._onClickAnotherReward(2);
		}

		// Token: 0x0600A154 RID: 41300 RVA: 0x0020BBF6 File Offset: 0x00209FF6
		private void _onAnotherReward3ButtonClick()
		{
			this._onClickAnotherReward(3);
		}

		// Token: 0x0600A155 RID: 41301 RVA: 0x0020BBFF File Offset: 0x00209FFF
		private void _onCloseButtonClick()
		{
			this.CloseTimeCount();
			this._timeOutClick();
		}

		// Token: 0x0600A156 RID: 41302 RVA: 0x0020BC0D File Offset: 0x0020A00D
		private void CloseTimeCount()
		{
			this.mCount10.PauseCount();
			this.mCount10.CustomActive(false);
		}

		// Token: 0x0600A157 RID: 41303 RVA: 0x0020BC26 File Offset: 0x0020A026
		private void _onNormalVipReward0ButtonClick()
		{
			this._showNoneVipTips();
		}

		// Token: 0x0600A158 RID: 41304 RVA: 0x0020BC2E File Offset: 0x0020A02E
		private void _onNormalVipReward1ButtonClick()
		{
			this._showNoneVipTips();
		}

		// Token: 0x0600A159 RID: 41305 RVA: 0x0020BC36 File Offset: 0x0020A036
		private void _onNormalVipReward2ButtonClick()
		{
			this._showNoneVipTips();
		}

		// Token: 0x0600A15A RID: 41306 RVA: 0x0020BC3E File Offset: 0x0020A03E
		private void _onNormalVipReward3ButtonClick()
		{
			this._showNoneVipTips();
		}

		// Token: 0x0600A15B RID: 41307 RVA: 0x0020BC46 File Offset: 0x0020A046
		private void _onAnotherWorldReward0ButtonClick()
		{
			this._onAnotherWorldClickReward(0);
		}

		// Token: 0x0600A15C RID: 41308 RVA: 0x0020BC4F File Offset: 0x0020A04F
		private void _onAnotherWorldReward1ButtonClick()
		{
			this._onAnotherWorldClickReward(1);
		}

		// Token: 0x0600A15D RID: 41309 RVA: 0x0020BC58 File Offset: 0x0020A058
		private void _onAnotherWorldReward2ButtonClick()
		{
			this._onAnotherWorldClickReward(2);
		}

		// Token: 0x0600A15E RID: 41310 RVA: 0x0020BC61 File Offset: 0x0020A061
		private void _onAnotherWorldReward3ButtonClick()
		{
			this._onAnotherWorldClickReward(3);
		}

		// Token: 0x0600A15F RID: 41311 RVA: 0x0020BC6A File Offset: 0x0020A06A
		private void _showNoneVipTips()
		{
			if (!this._isLocalPlayerMonthCard())
			{
				SystemNotifyManager.SystemNotify(1248, string.Empty);
			}
		}

		// Token: 0x0600A160 RID: 41312 RVA: 0x0020BC86 File Offset: 0x0020A086
		private bool _isLocalPlayerMonthCard()
		{
			return BattleMain.instance != null && BattleMain.instance.GetLocalPlayer(0UL) != null && BattleMain.instance.GetLocalPlayer(0UL).IsPlayerMonthCard();
		}

		// Token: 0x0600A161 RID: 41313 RVA: 0x0020BCB6 File Offset: 0x0020A0B6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Reward/DungeonReward";
		}

		// Token: 0x0600A162 RID: 41314 RVA: 0x0020BCBD File Offset: 0x0020A0BD
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A163 RID: 41315 RVA: 0x0020BCC0 File Offset: 0x0020A0C0
		protected override void _OnOpenFrame()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRebornFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(null, false);
			}
			this._bindEvent();
			if (!this._bindCountCallback())
			{
				return;
			}
			this._updateAnotherFlipType();
			this.mIsGetAnotherWorldReward = false;
			this.mIsAnotherWorldRealGetReward = false;
			this.mIsRealGetAnotherReward = false;
			this.mIsRealGetNormalReward = false;
			this.mIsGetAnotherReward = false;
			this.mIsGetNormalReward = false;
			this.mIsClosed = false;
			this.mCurProcessStatus = DungeonRewardFrame.eFlipProcess.WaitFlip;
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLICK_CARD, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentAreaID(), string.Empty);
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRewardFrameOpen, null, null, null, null);
			this.mFatigueCombustionRoot.CustomActive(DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.fatigueBurnType == 2);
			if (this._ismCrossServiceFlipCardNumberRoot())
			{
				this.mCrossServiceFlipCardNumberRoot.CustomActive(true);
				this.RefreshCrossServiceFlipCardNumber();
			}
		}

		// Token: 0x0600A164 RID: 41316 RVA: 0x0020BDC4 File Offset: 0x0020A1C4
		protected override void _OnCloseFrame()
		{
			this._unbindEvent();
			if (null != this.mNormalVIPSelect)
			{
				Object.Destroy(this.mNormalVIPSelect);
				this.mNormalVIPSelect = null;
			}
			if (null != this.mNormalSelect)
			{
				Object.Destroy(this.mNormalSelect);
				this.mNormalSelect = null;
			}
			if (null != this.mAnotherSelect)
			{
				Object.Destroy(this.mAnotherSelect);
				this.mAnotherSelect = null;
			}
			if (this.mTimeOut != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mTimeOut);
			}
			this._stopDelayClose();
			this.number = 0;
		}

		// Token: 0x0600A165 RID: 41317 RVA: 0x0020BE68 File Offset: 0x0020A268
		private void _initCardArray()
		{
			for (int i = 0; i < 4; i++)
			{
				this.mNormalRewardImageList[i] = this.mNormalRewardList[i].GetComponent<Image>();
				this.mNormalRewardVIPImageList[i] = this.mNormalVipRewards[i].GetComponent<Image>();
				this.mAnotherRewardImageList[i] = this.mAnotherRewardList[i].GetComponent<Image>();
			}
		}

		// Token: 0x0600A166 RID: 41318 RVA: 0x0020BEC8 File Offset: 0x0020A2C8
		private void _setAnotherFlipSprite(string spriteName)
		{
			for (int i = 0; i < 4; i++)
			{
				this.mBind.GetSprite(spriteName, ref this.mAnotherRewardImageList[i]);
			}
		}

		// Token: 0x0600A167 RID: 41319 RVA: 0x0020BF00 File Offset: 0x0020A300
		private void _setAnotherFlipCostSprite(string spriteName)
		{
			for (int i = 0; i < 4; i++)
			{
				ETCImageLoader.LoadSprite(ref this.mAnotherRewardCostIconList[i], spriteName, true);
			}
		}

		// Token: 0x0600A168 RID: 41320 RVA: 0x0020BF34 File Offset: 0x0020A334
		private void _setAnotherFlipText(string text)
		{
			for (int i = 0; i < 4; i++)
			{
				this.mAnotherRewardCostList[i].text = text;
			}
		}

		// Token: 0x0600A169 RID: 41321 RVA: 0x0020BF64 File Offset: 0x0020A364
		private void _setAnotherFlipEnable(bool enable)
		{
			this.mAnotherGrayGroup.enabled = !enable;
			for (int i = 0; i < 4; i++)
			{
				this.mAnotherRewardImageList[i].raycastTarget = enable;
				this.mAnotherRewardList[i].interactable = enable;
			}
		}

		// Token: 0x0600A16A RID: 41322 RVA: 0x0020BFB0 File Offset: 0x0020A3B0
		private void _updateAnotherFlipType()
		{
			this._initCardArray();
			DungeonRewardFrame.eAnotherCardFlipType eAnotherCardFlipType = this._getAnotherFlipType();
			this.mNormalRoot.SetActive(false);
			this.mVipRoot.SetActive(false);
			this.mHellRoot.SetActive(false);
			this.mNotOpenRoot.SetActive(false);
			int itemId = (int)DataManager<BattleDataManager>.GetInstance().chestInfo.itemId;
			int count = (int)DataManager<BattleDataManager>.GetInstance().chestInfo.count;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mCostTypeName.text = tableItem.Name;
				this.mHellCostTypeName.text = tableItem.Name;
				this._setAnotherFlipCostSprite(tableItem.Icon);
			}
			this._setAnotherFlipEnable(true);
			this._setAnotherFlipSprite("normalcard");
			this._setAnotherFlipText(string.Format("{0}", count));
			switch (eAnotherCardFlipType)
			{
			case DungeonRewardFrame.eAnotherCardFlipType.None:
			case DungeonRewardFrame.eAnotherCardFlipType.NotOpen:
				this._setAnotherFlipEnable(false);
				this.mNotOpenRoot.SetActive(true);
				this.mNotOpenLevel.text = string.Format("{0}", this._getAnotherFlipOpenLevel());
				this._setAnotherFlipText(string.Format("{0}级开启", this._getAnotherFlipOpenLevel()));
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.VipFree:
				this._setAnotherFlipText("免费");
				this.mVipRoot.SetActive(true);
				this._updateVipRootInfo();
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.TicketCost:
				this.mHellRoot.SetActive(true);
				this._setAnotherFlipSprite("hellcard");
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.GoldCost:
				this.mNormalRoot.SetActive(true);
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.NotCostGoldItem:
				this._setAnotherFlipEnable(false);
				this.mNormalRoot.SetActive(true);
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.NotCostTicketItem:
				this._setAnotherFlipEnable(false);
				this.mHellRoot.SetActive(true);
				this._setAnotherFlipSprite("hellcard");
				break;
			case DungeonRewardFrame.eAnotherCardFlipType.Aniversary_Forbidden:
				this._setAnotherFlipEnable(false);
				break;
			}
			this._InitCard2Card3LabelRootIsShow();
		}

		// Token: 0x0600A16B RID: 41323 RVA: 0x0020C1A8 File Offset: 0x0020A5A8
		private void _updateVipRootInfo()
		{
			int num = this._getVipGoldLeft();
			int num2 = this._getVipGoldSum();
			this.mVipRoot.SetActive(true);
			this.mVipLeft.text = num.ToString();
			this.mVipSum.text = num2.ToString();
			this.mVipLevel.text = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
		}

		// Token: 0x0600A16C RID: 41324 RVA: 0x0020C21F File Offset: 0x0020A61F
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._updateVipLeftCount));
			NetProcess.AddMsgHandler(506814U, new Action<MsgDATA>(this._onSceneDungeonOpenChestResDATA));
		}

		// Token: 0x0600A16D RID: 41325 RVA: 0x0020C252 File Offset: 0x0020A652
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._updateVipLeftCount));
			NetProcess.RemoveMsgHandler(506814U, new Action<MsgDATA>(this._onSceneDungeonOpenChestResDATA));
		}

		// Token: 0x0600A16E RID: 41326 RVA: 0x0020C288 File Offset: 0x0020A688
		private void _updateVipLeftCount(UIEvent ui)
		{
			string a = ui.Param1 as string;
			if (a == CounterKeys.COUNTER_VIP_FREE_GOLD_CHEST_TIMES)
			{
				this._updateVipRootInfo();
			}
		}

		// Token: 0x0600A16F RID: 41327 RVA: 0x0020C2B8 File Offset: 0x0020A6B8
		private DungeonRewardFrame.eAnotherCardFlipType _getAnotherFlipType()
		{
			if (BeUtility.CheckDungeonIsLimitTimeHell())
			{
				return DungeonRewardFrame.eAnotherCardFlipType.GoldCost;
			}
			DungeonRewardFrame.eAnotherCardFlipType result;
			if (!this._isAnotherFlipOpen())
			{
				result = DungeonRewardFrame.eAnotherCardFlipType.NotOpen;
			}
			else if (this._isHellMode())
			{
				if (this._canUseCostItem2FlipAnother())
				{
					result = DungeonRewardFrame.eAnotherCardFlipType.TicketCost;
				}
				else
				{
					result = DungeonRewardFrame.eAnotherCardFlipType.NotCostTicketItem;
				}
			}
			else if (BattleMain.battleType == BattleType.AnniversaryPVE_III)
			{
				result = DungeonRewardFrame.eAnotherCardFlipType.Aniversary_Forbidden;
			}
			else if (this._getVipGoldLeft() > 0)
			{
				result = DungeonRewardFrame.eAnotherCardFlipType.VipFree;
			}
			else if (this._canUseCostItem2FlipAnother())
			{
				result = DungeonRewardFrame.eAnotherCardFlipType.GoldCost;
			}
			else
			{
				result = DungeonRewardFrame.eAnotherCardFlipType.NotCostGoldItem;
			}
			return result;
		}

		// Token: 0x0600A170 RID: 41328 RVA: 0x0020C344 File Offset: 0x0020A744
		private bool _canFlipAnotherFlipType()
		{
			DungeonRewardFrame.eAnotherCardFlipType eAnotherCardFlipType = this._getAnotherFlipType();
			return eAnotherCardFlipType == DungeonRewardFrame.eAnotherCardFlipType.GoldCost || eAnotherCardFlipType == DungeonRewardFrame.eAnotherCardFlipType.TicketCost || eAnotherCardFlipType == DungeonRewardFrame.eAnotherCardFlipType.VipFree;
		}

		// Token: 0x0600A171 RID: 41329 RVA: 0x0020C36D File Offset: 0x0020A76D
		private bool _isHellMode()
		{
			return BattleMain.battleType == BattleType.Hell;
		}

		// Token: 0x0600A172 RID: 41330 RVA: 0x0020C378 File Offset: 0x0020A778
		private bool _canUseCostItem2FlipAnother()
		{
			int count = (int)DataManager<BattleDataManager>.GetInstance().chestInfo.count;
			int itemId = (int)DataManager<BattleDataManager>.GetInstance().chestInfo.itemId;
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemId, true) >= count;
		}

		// Token: 0x0600A173 RID: 41331 RVA: 0x0020C3B7 File Offset: 0x0020A7B7
		private int _getAnotherFlipOpenLevel()
		{
			return 10;
		}

		// Token: 0x0600A174 RID: 41332 RVA: 0x0020C3BB File Offset: 0x0020A7BB
		private bool _isAnotherFlipOpen()
		{
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this._getAnotherFlipOpenLevel();
		}

		// Token: 0x0600A175 RID: 41333 RVA: 0x0020C3D4 File Offset: 0x0020A7D4
		private int _getVipGoldSum()
		{
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.GOLDBOX_FREEOPEN_NUM);
			if (curVipLevelPrivilegeData > 0f)
			{
				return (int)curVipLevelPrivilegeData;
			}
			return 0;
		}

		// Token: 0x0600A176 RID: 41334 RVA: 0x0020C3F8 File Offset: 0x0020A7F8
		private int _getVipGoldLeft()
		{
			int num = this._getVipGoldSum();
			if (num <= 0)
			{
				return -1;
			}
			return num - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_VIP_FREE_GOLD_CHEST_TIMES);
		}

		// Token: 0x0600A177 RID: 41335 RVA: 0x0020C428 File Offset: 0x0020A828
		private void _startNormalVIPSelect(int idx, UnityAction callback, BattlePlayer player = null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (idx == i)
				{
					this.mNormalRewardVIPImageList[i].color = Color.clear;
					this._hiddenAllChild(this.mNormalRewardVIPImageList[i].gameObject);
					string path = string.Empty;
					if (player != null)
					{
						if (player.IsPlayerMonthCard())
						{
							path = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian";
						}
						else
						{
							path = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian_huise";
						}
					}
					this.mNormalVIPSelect = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
					Utility.AttachTo(this.mNormalVIPSelect, this.mNormalRewardVIPImageList[i].gameObject, false);
					this.mNormalVIPSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.RemoveAllListeners();
					this.mNormalVIPSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.AddListener(callback);
				}
				else if (this.mIsRealGetNormalReward)
				{
					this.mNormalRewardVIPImageList[i].raycastTarget = false;
				}
			}
		}

		// Token: 0x0600A178 RID: 41336 RVA: 0x0020C510 File Offset: 0x0020A910
		private void _hiddenAllChild(GameObject root)
		{
			if (null == root)
			{
				return;
			}
			int childCount = root.transform.GetChildCount();
			for (int i = 0; i < childCount; i++)
			{
				Transform child = root.transform.GetChild(i);
				if (null != child && null != child.gameObject)
				{
					child.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600A179 RID: 41337 RVA: 0x0020C580 File Offset: 0x0020A980
		private void _startNormalSelect(int idx, UnityAction callback)
		{
			for (int i = 0; i < 4; i++)
			{
				if (idx == i)
				{
					if (this.mNormalRewardImageList[i] != null)
					{
						this.mNormalRewardImageList[i].color = Color.clear;
						this._hiddenAllChild(this.mNormalRewardImageList[i].gameObject);
						this.mNormalSelect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian", true, 0U);
						Utility.AttachTo(this.mNormalSelect, this.mNormalRewardImageList[i].gameObject, false);
						this.mNormalSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.RemoveAllListeners();
						this.mNormalSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.AddListener(callback);
					}
				}
				else if (this.mIsRealGetNormalReward && this.mNormalRewardImageList[i] != null)
				{
					this.mNormalRewardImageList[i].raycastTarget = false;
				}
			}
		}

		// Token: 0x0600A17A RID: 41338 RVA: 0x0020C66C File Offset: 0x0020AA6C
		private void _startAnotherSelect(int idx, UnityAction callback)
		{
			for (int i = 0; i < 4; i++)
			{
				if (idx == i)
				{
					this.mAnotherRewardImageList[i].color = Color.clear;
					this._hiddenAllChild(this.mAnotherRewardImageList[i].gameObject);
					this.mAnotherSelect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian", true, 0U);
					Utility.AttachTo(this.mAnotherSelect, this.mAnotherRewardImageList[i].gameObject, false);
					if (callback != null)
					{
						this.mAnotherSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.RemoveAllListeners();
						this.mAnotherSelect.GetComponent<ComAnimatorAutoClose>().mOnFinishCallback.AddListener(callback);
					}
				}
				else if (this.mIsRealGetAnotherReward)
				{
					this.mAnotherRewardImageList[i].raycastTarget = false;
				}
			}
		}

		// Token: 0x0600A17B RID: 41339 RVA: 0x0020C738 File Offset: 0x0020AB38
		private bool _bindCountCallback()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			if (BattleMain.instance.GetPlayerManager() == null)
			{
				return false;
			}
			if (BattleMain.instance.GetPlayerManager().GetAllPlayers() == null)
			{
				return false;
			}
			this.mCount10 = this.mBind.GetCom<ComCountScript>("count10");
			this.mCountRoot.SetActive(true);
			if (Singleton<NewbieGuideManager>.instance.IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide))
			{
				this.mCountRoot.SetActive(false);
				return true;
			}
			int leftTime = 5;
			if (BattleMain.instance.GetPlayerManager().GetAllPlayers().Count > 1)
			{
				leftTime = 9;
			}
			this.mCount10.StartCount(new UnityAction(this._timeOutClick), leftTime);
			return true;
		}

		// Token: 0x0600A17C RID: 41340 RVA: 0x0020C7F0 File Offset: 0x0020ABF0
		private void _timeOutClick()
		{
			if (this.countTimeOut)
			{
				return;
			}
			this.mClose.CustomActive(false);
			if (this.mIsRealGetNormalReward || this.mIsAnotherWorldRealGetReward)
			{
				this.kCloseWaitTime = 0.5f;
			}
			else
			{
				this.kCloseWaitTime = 1.5f;
			}
			if (!this.mIsGetAnotherReward)
			{
				this._startAnotherSelect(-1, null);
			}
			this._onSceneDungeonOpenChestReq(-1, false);
			this.countTimeOut = true;
			if (this.mIsRealGetNormalReward || this.mIsAnotherWorldRealGetReward)
			{
				this.mCurProcessStatus = DungeonRewardFrame.eFlipProcess.WaitClose;
			}
			this._startDelayClose(this.kCloseWaitTime);
		}

		// Token: 0x0600A17D RID: 41341 RVA: 0x0020C894 File Offset: 0x0020AC94
		private void _startDelayClose(float time)
		{
			if (Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID() == NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide)
			{
				Singleton<NewbieGuideManager>.GetInstance().ManagerFinishGuide(Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID());
			}
			this._stopDelayClose();
			this.mDelayClose = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._delayClose(time));
		}

		// Token: 0x0600A17E RID: 41342 RVA: 0x0020C8E2 File Offset: 0x0020ACE2
		private void _stopDelayClose()
		{
			if (this.mDelayClose != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDelayClose);
			}
			this.mDelayClose = null;
		}

		// Token: 0x0600A17F RID: 41343 RVA: 0x0020C908 File Offset: 0x0020AD08
		private bool _onSceneDungeonOpenChestReq(int id, bool another = false)
		{
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLICK_CARD, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentAreaID(), string.Format("{0}", id));
			if (another)
			{
				if (this.mIsGetAnotherReward)
				{
					return false;
				}
				this.mIsGetAnotherReward = true;
				this.mAnotherClickIndex = id;
			}
			else
			{
				switch (this.mCurCarType)
				{
				case DungeonTable.eCardType.Golden_Card:
					if (this.mIsGetNormalReward)
					{
						return false;
					}
					this.mIsGetNormalReward = true;
					this.mNormalClickIndex = id;
					if (!Singleton<NewbieGuideManager>.instance.IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide))
					{
						if (this.mTimeOut != null)
						{
							MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mTimeOut);
						}
						this.mTimeOut = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._timeOut(10f));
					}
					break;
				case DungeonTable.eCardType.Yijie_Card:
					if (this.mIsGetAnotherWorldReward)
					{
						return false;
					}
					this.mIsGetAnotherWorldReward = true;
					this.mAnotherWorldClickIndex = id;
					if (!Singleton<NewbieGuideManager>.instance.IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide))
					{
						if (this.mTimeOut != null)
						{
							MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mTimeOut);
						}
						this.mTimeOut = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._timeOut(10f));
					}
					break;
				}
			}
			SceneDungeonOpenChestReq sceneDungeonOpenChestReq = new SceneDungeonOpenChestReq();
			sceneDungeonOpenChestReq.pos = (byte)((!another) ? id : (id + 4));
			NetManager.Instance().SendCommand<SceneDungeonOpenChestReq>(ServerType.GATE_SERVER, sceneDungeonOpenChestReq);
			return true;
		}

		// Token: 0x0600A180 RID: 41344 RVA: 0x0020CAB4 File Offset: 0x0020AEB4
		private void _onSceneDungeonOpenChestResDATA(MsgDATA data)
		{
			SceneDungeonOpenChestRes sceneDungeonOpenChestRes = new SceneDungeonOpenChestRes();
			sceneDungeonOpenChestRes.decode(data.bytes);
			this._onSceneDungeonOpenChestRes(sceneDungeonOpenChestRes);
		}

		// Token: 0x0600A181 RID: 41345 RVA: 0x0020CADC File Offset: 0x0020AEDC
		private void _onSceneDungeonOpenChestRes(SceneDungeonOpenChestRes res)
		{
			DungeonChest chest = res.chest;
			string playerName = string.Empty;
			bool isOurself = false;
			BattlePlayer battlePlayer = null;
			if (BattleMain.instance != null)
			{
				battlePlayer = BattleMain.instance.GetPlayerManager().GetPlayerByRoleID(res.owner);
				if (battlePlayer != null)
				{
					playerName = battlePlayer.playerInfo.name;
					if (battlePlayer.playerActor.isLocalActor)
					{
						isOurself = true;
					}
				}
			}
			if (res.pos < 4)
			{
				this.normalChestCount++;
			}
			else
			{
				this.goldChestCount++;
			}
			this.opened[(int)res.pos] = true;
			int count = BattleMain.instance.GetPlayerManager().GetAllPlayers().Count;
			this._onOpenReward((int)res.pos, chest.num, chest.itemId, chest.goldReward, (uint)chest.strenth, playerName, isOurself, (EEquipType)chest.equipType, battlePlayer);
			if (!Singleton<NewbieGuideManager>.instance.IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide))
			{
				if ((!this.countTimeOut && this.openChestCount >= count * 2) || (this.countTimeOut && this.normalChestCount >= count))
				{
					if (!this.countTimeOut)
					{
						this.CloseTimeCount();
						this.mClose.CustomActive(false);
					}
					this._startDelayClose(this.kCloseWaitTime);
				}
			}
		}

		// Token: 0x0600A182 RID: 41346 RVA: 0x0020CC2C File Offset: 0x0020B02C
		private bool IsOpened(int index)
		{
			return this.opened[index];
		}

		// Token: 0x0600A183 RID: 41347 RVA: 0x0020CC38 File Offset: 0x0020B038
		private void _onClickReward(int idx)
		{
			if (this.IsOpened(idx))
			{
				return;
			}
			if (this.mIsGetNormalReward || this.mIsRealGetNormalReward)
			{
				return;
			}
			this._onSceneDungeonOpenChestReq(idx, false);
			if (Singleton<NewbieGuideManager>.instance.IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.DungeonRewardGuide))
			{
				this.mIsGuide = true;
			}
		}

		// Token: 0x0600A184 RID: 41348 RVA: 0x0020CC8C File Offset: 0x0020B08C
		private void _onAnotherWorldClickReward(int idx)
		{
			if (this.IsOpened(idx))
			{
				return;
			}
			if (this.mIsAnotherWorldRealGetReward || this.mIsGetAnotherWorldReward)
			{
				return;
			}
			this._onSceneDungeonOpenChestReq(idx, false);
			if (this.mAnotherWorldDungeonRewardView != null)
			{
				this.mAnotherWorldDungeonRewardView.SetEffectAnotherWorldBtn(idx);
			}
		}

		// Token: 0x0600A185 RID: 41349 RVA: 0x0020CCE4 File Offset: 0x0020B0E4
		private void _onClickAnotherReward(int idx)
		{
			if (this.IsOpened(idx + 4))
			{
				return;
			}
			if (this.mIsGetAnotherReward || this.mIsRealGetAnotherReward)
			{
				return;
			}
			this._onSceneDungeonOpenChestReq(idx, true);
			if (this.mIsGuide)
			{
				this.mTip.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600A186 RID: 41350 RVA: 0x0020CD3C File Offset: 0x0020B13C
		private void _showReward(string path, GameObject root, uint num, uint itemID, uint glod, uint strenthLevel, DungeonRewardFrame.eType type, string playerName, bool isSelf, bool isAnother, EEquipType equipType, BattlePlayer player = null)
		{
			if (root == null)
			{
				Logger.LogErrorFormat("root == null in [_showReward]. path = {0}, itemID = {1}, playerName = {2}, isSelf = {3}, isAnother = {4}", new object[]
				{
					path,
					itemID,
					playerName,
					isSelf,
					isAnother
				});
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("cardUnit == null in [_showReward]. path = {0}, itemID = {1}, playerName = {2}, isSelf = {3}, isAnother = {4}", new object[]
				{
					path,
					itemID,
					playerName,
					isSelf,
					isAnother
				});
				return;
			}
			Utility.AttachTo(gameObject, root, false);
			GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_iconchuxian", true, 0U);
			bool flag = false;
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (null != component)
			{
				Text com = component.GetCom<Text>("name");
				Text com2 = component.GetCom<Text>("coin");
				GameObject gameObject3 = component.GetGameObject("coinroot");
				Image com3 = component.GetCom<Image>("iconbg");
				Image com4 = component.GetCom<Image>("icon");
				Text com5 = component.GetCom<Text>("iconcount");
				Text com6 = component.GetCom<Text>("iconlevel");
				Text com7 = component.GetCom<Text>("upOwner");
				Image com8 = component.GetCom<Image>("upOwnerBg");
				Image com9 = component.GetCom<Image>("bg");
				GameObject gameObject4 = component.GetGameObject("upRewardRoot");
				GameObject gameObject5 = component.GetGameObject("EffectRoot");
				Text com10 = component.GetCom<Text>("strenth");
				GameObject gameObject6 = component.GetGameObject("VipDescRoot");
				Text com11 = component.GetCom<Text>("VipDesc");
				GameObject gameObject7 = component.GetGameObject("breathMark");
				GameObject gameObject8 = component.GetGameObject("VipBg");
				if (gameObject8 != null)
				{
					gameObject8.CustomActive(false);
				}
				if (gameObject7 != null)
				{
					gameObject7.CustomActive(equipType == EEquipType.ET_BREATH);
				}
				string text = null;
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)itemID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, tableItem.Color2);
					if (com != null)
					{
						com.text = ((strenthLevel <= 0U) ? string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, tableItem.Name) : string.Format("<color={0}>+{1}{2}</color>", qualityInfo.ColStr, strenthLevel, tableItem.Name));
					}
					if (com4 != null)
					{
						ETCImageLoader.LoadSprite(ref com4, tableItem.Icon, true);
					}
					if (com3 != null)
					{
						ETCImageLoader.LoadSprite(ref com3, qualityInfo.Background, true);
						if (gameObject2 != null)
						{
							DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonIDWithOutDiff, string.Empty, string.Empty);
							if (tableItem2 != null && tableItem2.SubType == DungeonTable.eSubType.S_DEVILDDOM)
							{
								Utility.AttachTo(gameObject2, com3.gameObject, false);
							}
						}
					}
					if (com10 != null)
					{
						com10.CustomActive(strenthLevel > 0U);
						if (strenthLevel > 0U)
						{
							com10.text = string.Format("+{0}", strenthLevel);
						}
					}
					if (com6 != null)
					{
						com6.text = string.Format("Lv.{0}", tableItem.NeedLevel);
					}
					if (tableItem.Color == ItemTable.eColor.PINK)
					{
						text = component.GetPrefabPath("fense");
					}
					else if (tableItem.Color == ItemTable.eColor.PURPLE)
					{
						text = component.GetPrefabPath("zise");
					}
					else if (tableItem.Color == ItemTable.eColor.GREEN)
					{
						text = component.GetPrefabPath("lvse");
					}
					if (text != null)
					{
						GameObject gameObject9 = Singleton<AssetLoader>.instance.LoadResAsGameObject(text, true, 0U);
						if (gameObject9 != null && gameObject5 != null)
						{
							Utility.AttachTo(gameObject9, gameObject5, false);
						}
					}
				}
				else
				{
					Logger.LogErrorFormat("[翻牌] 道具无法再道具表中找到 {0}", new object[]
					{
						itemID
					});
					if (com != null)
					{
						com.text = string.Empty;
					}
				}
				if (num > 0U)
				{
					if (num > 1U)
					{
						if (com5 != null)
						{
							com5.text = string.Format("{0}", num);
						}
					}
					else if (com5 != null)
					{
						com5.text = string.Empty;
					}
				}
				else
				{
					if (com3 != null)
					{
						com3.color = Color.clear;
					}
					if (com4 != null)
					{
						com4.color = Color.clear;
					}
					if (com6 != null)
					{
						com6.text = string.Empty;
					}
					if (com5 != null)
					{
						com5.text = string.Empty;
					}
					if (com != null)
					{
						com.text = string.Empty;
					}
				}
				if (gameObject4 != null)
				{
					gameObject4.SetActive(DungeonRewardFrame.eType.Vip != type);
				}
				if (type == DungeonRewardFrame.eType.Normal)
				{
					if (com2 != null)
					{
						com2.text = string.Format("{0}", glod);
					}
				}
				else if (type == DungeonRewardFrame.eType.AnotherWorld)
				{
					if (com2 != null)
					{
						com2.text = string.Format("{0}", glod);
					}
				}
				else if (gameObject3 != null)
				{
					gameObject3.SetActive(false);
				}
				if (com7 != null)
				{
					com7.text = playerName;
				}
				if (com8 != null)
				{
					if (isSelf)
					{
						component.GetSprite("self", ref com8);
					}
					else
					{
						component.GetSprite("notself", ref com8);
					}
					if (isSelf)
					{
						com8.gameObject.SetActive(BattleMain.IsModeMultiplayer(BattleMain.mode) && !BattleMain.IsModePvP(BattleMain.battleType));
					}
				}
				if (type != DungeonRewardFrame.eType.AnotherWorld && com9 != null)
				{
					if (isAnother)
					{
						component.GetSprite("special", ref com9);
					}
					else
					{
						component.GetSprite("normal", ref com9);
					}
				}
				GameObject gameObject10 = component.GetGameObject("vipFlag");
				if (player != null)
				{
					if (player.IsPlayerMonthCard())
					{
						if (gameObject10 != null)
						{
							gameObject10.SetActive(type == DungeonRewardFrame.eType.Vip);
						}
						if (gameObject8 != null)
						{
							gameObject8.CustomActive(false);
						}
					}
					else
					{
						if (gameObject6 != null)
						{
							gameObject6.CustomActive(type == DungeonRewardFrame.eType.Vip);
						}
						if (tableItem != null)
						{
							flag = DataManager<MonthCardRewardLockersDataManager>.GetInstance().IsNewItemQualityAbleToEnterLockers(tableItem.Color);
							if (com11 != null)
							{
								if (flag)
								{
									com11.text = TR.Value("monthCard_greaterthan_purple");
								}
								else
								{
									com11.text = TR.Value("monthCard_Lessthan_purple");
								}
							}
						}
						if (type == DungeonRewardFrame.eType.Vip)
						{
							if (gameObject3 != null)
							{
								gameObject3.SetActive(false);
							}
							if (gameObject8 != null)
							{
								gameObject8.CustomActive(true);
							}
						}
					}
				}
				if (this._ismCrossServiceFlipCardNumberRoot())
				{
					this.RefreshCrossServiceFlipCardNumber();
					GameObject gameObject11 = component.GetGameObject("doubleflag");
					if (gameObject11 != null)
					{
						gameObject11.CustomActive(DataManager<GuildDataManager>.GetInstance().chestDoubleFlag > 0 && DataManager<PlayerBaseData>.GetInstance().Name == playerName);
					}
				}
			}
			if (type == DungeonRewardFrame.eType.Vip && flag)
			{
				DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqMonthCardRewardLockersItems();
			}
		}

		// Token: 0x0600A187 RID: 41351 RVA: 0x0020D4EC File Offset: 0x0020B8EC
		private bool _ismCrossServiceFlipCardNumberRoot()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(DataManager<GuildDataManager>.GetInstance().myGuild.nSelfCrossManorID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string[] array = tableItem.ChestDoubleDungeons.Split(new char[]
					{
						'|'
					});
					if (array != null)
					{
						for (int i = 0; i < array.Length; i++)
						{
							int num = 0;
							if (int.TryParse(array[i], out num))
							{
								if (num == BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonIDWithOutDiff)
								{
									int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_terr_dungeon_num");
									this.number = tableItem.DailyChestDoubleTimes - (count - 1);
									if (this.number > 0 && DataManager<GuildDataManager>.GetInstance().chestDoubleFlag > 0)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600A188 RID: 41352 RVA: 0x0020D5D9 File Offset: 0x0020B9D9
		private bool _isCardSlot(int idx, int offset)
		{
			return idx >= offset && idx < 4 + offset;
		}

		// Token: 0x0600A189 RID: 41353 RVA: 0x0020D5EB File Offset: 0x0020B9EB
		private bool _isNormalCardSlot(int idx)
		{
			return this._isCardSlot(idx, 0);
		}

		// Token: 0x0600A18A RID: 41354 RVA: 0x0020D5F5 File Offset: 0x0020B9F5
		private bool _isGoldCardSlot(int idx)
		{
			return this._isCardSlot(idx, 4);
		}

		// Token: 0x0600A18B RID: 41355 RVA: 0x0020D5FF File Offset: 0x0020B9FF
		private bool _isVipCardSlot(int idx)
		{
			return this._isCardSlot(idx, 8);
		}

		// Token: 0x0600A18C RID: 41356 RVA: 0x0020D60C File Offset: 0x0020BA0C
		private void _onOpenReward(int idx, uint num, uint itemID, uint glod, uint strenthLevel, string playerName, bool isOurself, EEquipType equipType, BattlePlayer player = null)
		{
			int realIdx = idx % 4;
			string cardPath = string.Empty;
			switch (this.mCurCarType)
			{
			case DungeonTable.eCardType.Golden_Card:
				cardPath = this.mBind.GetPrefabPath("unit");
				if (this._isNormalCardSlot(idx))
				{
					this.openChestCount++;
					if (this.mNormalVipRewards[realIdx] != null)
					{
						this.mNormalVipRewards[realIdx].gameObject.SetActive(true);
						if (player == null || !player.IsPlayerMonthCard())
						{
							UIGray uigray = this.mNormalVipRewards[realIdx].gameObject.SafeAddComponent(true);
							if (uigray != null)
							{
								uigray.enabled = true;
							}
						}
						DOTweenAnimation component = this.mNormalVipRewards[realIdx].GetComponent<DOTweenAnimation>();
						if (null != component && component.onComplete != null)
						{
							component.onComplete.AddListener(delegate()
							{
								if (isOurself)
								{
									this.mIsRealGetNormalReward = true;
									if (this.mIsRealGetAnotherReward || !this._canFlipAnotherFlipType())
									{
										this.mCurProcessStatus = DungeonRewardFrame.eFlipProcess.WaitClose;
									}
								}
							});
						}
					}
					this._startNormalSelect(realIdx, delegate
					{
						this._showReward(cardPath, this.mNormalRewardImageList[realIdx].gameObject, num, itemID, glod, strenthLevel, DungeonRewardFrame.eType.Normal, playerName, isOurself, false, equipType, player);
						if (isOurself)
						{
						}
						if (this.mIsGetNormalReward && this.mNormalClickIndex == idx)
						{
							this.mIsGetNormalReward = false;
						}
					});
				}
				else if (this._isVipCardSlot(idx))
				{
					DOTweenAnimation component2 = this.mNormalVipRewards[realIdx].GetComponent<DOTweenAnimation>();
					if (null != component2)
					{
						if (component2.onComplete != null)
						{
							component2.onComplete.AddListener(delegate()
							{
								this._startNormalVIPSelect(realIdx, delegate
								{
									this._showReward(cardPath, this.mNormalVipRewards[realIdx].gameObject, num, itemID, glod, strenthLevel, DungeonRewardFrame.eType.Vip, playerName, isOurself, true, equipType, player);
								}, player);
							});
						}
					}
					else
					{
						this._startNormalVIPSelect(realIdx, delegate
						{
							this._showReward(cardPath, this.mNormalVipRewards[realIdx].gameObject, num, itemID, glod, strenthLevel, DungeonRewardFrame.eType.Vip, playerName, isOurself, true, equipType, player);
						}, player);
					}
				}
				else if (this._isGoldCardSlot(idx))
				{
					this.openChestCount++;
					TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To(() => 1f, delegate(float x)
					{
						this.mInfomationCanvasGroup.alpha = x;
					}, 0f, 2f), 6);
					this._startAnotherSelect(realIdx, delegate
					{
						this._showReward(cardPath, this.mAnotherRewardImageList[realIdx].gameObject, num, itemID, glod, strenthLevel, DungeonRewardFrame.eType.Another, playerName, isOurself, true, equipType, player);
						if (isOurself)
						{
							this.mIsRealGetAnotherReward = true;
							if (this.mIsRealGetNormalReward)
							{
								this.mCurProcessStatus = DungeonRewardFrame.eFlipProcess.WaitClose;
							}
						}
						if (this.mIsGetAnotherReward && this.mAnotherClickIndex == realIdx)
						{
							this.mIsGetAnotherReward = false;
						}
					});
				}
				else
				{
					Logger.LogErrorFormat("[翻牌] 索引超出范围 {0}", new object[]
					{
						idx
					});
				}
				break;
			case DungeonTable.eCardType.Yijie_Card:
				cardPath = this.mBind.GetPrefabPath("anotherworldunit");
				if (this._isNormalCardSlot(idx))
				{
					this.openChestCount++;
					if (this.mAnotherWorldDungeonRewardView != null)
					{
						this.mAnotherWorldDungeonRewardView.StartAnotherWorldSelect(idx, delegate
						{
							this._showReward(cardPath, this.mAnotherWorldDungeonRewardView.mAnotherWorldRewardImageList[realIdx].gameObject, num, itemID, glod, strenthLevel, DungeonRewardFrame.eType.AnotherWorld, playerName, isOurself, true, equipType, player);
							if (isOurself)
							{
								this.mIsAnotherWorldRealGetReward = true;
								if (this.mIsAnotherWorldRealGetReward || !this._canFlipAnotherFlipType())
								{
									this.mCurProcessStatus = DungeonRewardFrame.eFlipProcess.WaitClose;
								}
							}
							if (this.mIsGetAnotherWorldReward && this.mAnotherWorldClickIndex == idx)
							{
								this.mIsGetAnotherWorldReward = false;
							}
						});
					}
				}
				break;
			}
		}

		// Token: 0x0600A18D RID: 41357 RVA: 0x0020D944 File Offset: 0x0020BD44
		private IEnumerator _timeOut(float time)
		{
			yield return Yielders.GetWaitForSeconds(time);
			if (!this.mIsRealGetNormalReward && this.mIsGetNormalReward)
			{
				Logger.LogError("wait the net message time out error dropboxtable config");
			}
			if (!this.mIsClosed)
			{
				this._onClose();
			}
			yield break;
		}

		// Token: 0x0600A18E RID: 41358 RVA: 0x0020D968 File Offset: 0x0020BD68
		private IEnumerator _delayClose(float time)
		{
			yield return Yielders.GetWaitForSeconds(time);
			if (!this.mIsClosed)
			{
				this._onClose();
			}
			yield break;
		}

		// Token: 0x0600A18F RID: 41359 RVA: 0x0020D98A File Offset: 0x0020BD8A
		private void _onClose()
		{
			this.mIsClosed = true;
			this.frameMgr.CloseFrame<DungeonRewardFrame>(this, false);
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRewardFrameClose, null, null, null, null);
		}

		// Token: 0x0600A190 RID: 41360 RVA: 0x0020D9B3 File Offset: 0x0020BDB3
		private void _onHandle()
		{
			if (this.mCurProcessStatus == DungeonRewardFrame.eFlipProcess.WaitClose)
			{
			}
		}

		// Token: 0x0600A191 RID: 41361 RVA: 0x0020D9C4 File Offset: 0x0020BDC4
		private void _InitCard2Card3LabelRootIsShow()
		{
			this.mCurCarType = this.GetCardType();
			switch (this.mCurCarType)
			{
			case DungeonTable.eCardType.Golden_Card:
				if (this.CheckDungeonIsMonopolyCheckpoint())
				{
					this.mCard2Root.CustomActive(false);
					this.mCard3Root.CustomActive(false);
					this.mCentTextRoot.CustomActive(false);
				}
				break;
			case DungeonTable.eCardType.Yijie_Card:
				this.mMidRoot.CustomActive(false);
				this.mTitleRoot.CustomActive(false);
				this.LoadAnotherWorldDungeonRewardView();
				if (this.mAnotherWorldDungeonRewardView != null)
				{
					this.mAnotherWorldDungeonRewardView.InitView(new OnAnotherWorldRewardClick(this._onAnotherWorldClickReward));
				}
				break;
			}
		}

		// Token: 0x0600A192 RID: 41362 RVA: 0x0020DA90 File Offset: 0x0020BE90
		private void LoadAnotherWorldDungeonRewardView()
		{
			UIPrefabWrapper component = this.mAnotherWorldCardRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab(this.mAnotherWorldCardRoot.transform);
				if (gameObject != null)
				{
					this.mAnotherWorldDungeonRewardView = gameObject.GetComponent<AnotherWorldDungeonRewardView>();
				}
			}
		}

		// Token: 0x0600A193 RID: 41363 RVA: 0x0020DAE0 File Offset: 0x0020BEE0
		private void RefreshCrossServiceFlipCardNumber()
		{
			if (this.mCrossServiceFlipCardNumberBind == null)
			{
				this.mCrossServiceFlipCardNumberBind = this.LoadCrossServiceFlipCardNumber();
				if (this.mCrossServiceFlipCardNumberBind != null)
				{
					Text com = this.mCrossServiceFlipCardNumberBind.GetCom<Text>("count");
					if (com != null)
					{
						com.text = this.number.ToString();
					}
				}
			}
			else
			{
				Text com2 = this.mCrossServiceFlipCardNumberBind.GetCom<Text>("count");
				if (com2 != null)
				{
					com2.text = this.number.ToString();
				}
			}
		}

		// Token: 0x0600A194 RID: 41364 RVA: 0x0020DB88 File Offset: 0x0020BF88
		private ComCommonBind LoadCrossServiceFlipCardNumber()
		{
			ComCommonBind result = null;
			UIPrefabWrapper component = this.mCrossServiceFlipCardNumberRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab(this.mCrossServiceFlipCardNumberRoot.transform);
				if (gameObject != null)
				{
					result = gameObject.GetComponent<ComCommonBind>();
				}
			}
			return result;
		}

		// Token: 0x0600A195 RID: 41365 RVA: 0x0020DBD8 File Offset: 0x0020BFD8
		private DungeonTable.eCardType GetCardType()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonIDWithOutDiff, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.CardType;
			}
			return DungeonTable.eCardType.Golden_Card;
		}

		// Token: 0x0600A196 RID: 41366 RVA: 0x0020DC24 File Offset: 0x0020C024
		private bool CheckDungeonIsMonopolyCheckpoint()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonIDWithOutDiff, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_PLAYGAME;
		}

		// Token: 0x040059C2 RID: 22978
		private DungeonTable.eCardType _mCurCarType = DungeonTable.eCardType.Golden_Card;

		// Token: 0x040059C3 RID: 22979
		private DungeonRewardFrame.eFlipProcess _mCurprocess;

		// Token: 0x040059C4 RID: 22980
		private Button[] mNormalRewardList = new Button[4];

		// Token: 0x040059C5 RID: 22981
		private Button[] mAnotherRewardList = new Button[4];

		// Token: 0x040059C6 RID: 22982
		private Text[] mAnotherRewardCostList = new Text[4];

		// Token: 0x040059C7 RID: 22983
		private Image[] mAnotherRewardCostIconList = new Image[4];

		// Token: 0x040059C8 RID: 22984
		private int number;

		// Token: 0x040059C9 RID: 22985
		private ComCountScript mCount10;

		// Token: 0x040059CA RID: 22986
		private HorizontalLayoutGroup mNormalGroup;

		// Token: 0x040059CB RID: 22987
		private UIGray mAnotherGrayGroup;

		// Token: 0x040059CC RID: 22988
		private Text mTip;

		// Token: 0x040059CD RID: 22989
		private Button mClose;

		// Token: 0x040059CE RID: 22990
		private GameObject mNormalRoot;

		// Token: 0x040059CF RID: 22991
		private GameObject mVipRoot;

		// Token: 0x040059D0 RID: 22992
		private Text mVipLevel;

		// Token: 0x040059D1 RID: 22993
		private Text mVipLeft;

		// Token: 0x040059D2 RID: 22994
		private Text mVipSum;

		// Token: 0x040059D3 RID: 22995
		private Text mCostTypeName;

		// Token: 0x040059D4 RID: 22996
		private Text mHellCostTypeName;

		// Token: 0x040059D5 RID: 22997
		private GameObject mHellRoot;

		// Token: 0x040059D6 RID: 22998
		private GameObject mCentTextRoot;

		// Token: 0x040059D7 RID: 22999
		private GameObject mNotOpenRoot;

		// Token: 0x040059D8 RID: 23000
		private Text mNotOpenLevel;

		// Token: 0x040059D9 RID: 23001
		private GameObject mCountRoot;

		// Token: 0x040059DA RID: 23002
		private Button[] mNormalVipRewards = new Button[4];

		// Token: 0x040059DB RID: 23003
		private CanvasGroup mInfomationCanvasGroup;

		// Token: 0x040059DC RID: 23004
		private GameObject mFatigueCombustionRoot;

		// Token: 0x040059DD RID: 23005
		private GameObject mCrossServiceFlipCardNumberRoot;

		// Token: 0x040059DE RID: 23006
		private GameObject mYijieLabelRoot;

		// Token: 0x040059DF RID: 23007
		private GameObject mMidRoot;

		// Token: 0x040059E0 RID: 23008
		private GameObject mAnotherWorldCardRoot;

		// Token: 0x040059E1 RID: 23009
		private GameObject mTitleRoot;

		// Token: 0x040059E2 RID: 23010
		private GameObject mYiJieTitleRoot;

		// Token: 0x040059E3 RID: 23011
		private GameObject mCard2Root;

		// Token: 0x040059E4 RID: 23012
		private GameObject mCard3Root;

		// Token: 0x040059E5 RID: 23013
		private const string kOpenFrameSoundPath = "Sound/SE/reward_divide";

		// Token: 0x040059E6 RID: 23014
		private const int kDefaultSelectedIdx = -1;

		// Token: 0x040059E7 RID: 23015
		private const int kRewardButtonCount = 4;

		// Token: 0x040059E8 RID: 23016
		private const int kTotalRewardButtonCount = 12;

		// Token: 0x040059E9 RID: 23017
		private const int kAnotherRewardButtonOffset = 4;

		// Token: 0x040059EA RID: 23018
		private const int kVipNormalRewardButtonOffset = 8;

		// Token: 0x040059EB RID: 23019
		private float kCloseWaitTime = 1.5f;

		// Token: 0x040059EC RID: 23020
		private const string kEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian";

		// Token: 0x040059ED RID: 23021
		private const string kGoldCardEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian02";

		// Token: 0x040059EE RID: 23022
		private const string kAnotherWorldEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian_yijie";

		// Token: 0x040059EF RID: 23023
		private const string kIconEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_iconchuxian";

		// Token: 0x040059F0 RID: 23024
		private const string kEffectHuisePath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian_huise";

		// Token: 0x040059F1 RID: 23025
		private const bool kLocalTest = false;

		// Token: 0x040059F2 RID: 23026
		private bool mIsGetNormalReward;

		// Token: 0x040059F3 RID: 23027
		private bool mIsGetAnotherReward;

		// Token: 0x040059F4 RID: 23028
		private bool mIsGetAnotherWorldReward;

		// Token: 0x040059F5 RID: 23029
		private bool mIsRealGetNormalReward;

		// Token: 0x040059F6 RID: 23030
		private bool mIsRealGetAnotherReward;

		// Token: 0x040059F7 RID: 23031
		private bool mIsAnotherWorldRealGetReward;

		// Token: 0x040059F8 RID: 23032
		private int mNormalClickIndex = -1;

		// Token: 0x040059F9 RID: 23033
		private int mAnotherClickIndex = -1;

		// Token: 0x040059FA RID: 23034
		private int mAnotherWorldClickIndex = -1;

		// Token: 0x040059FB RID: 23035
		private bool mIsClosed;

		// Token: 0x040059FC RID: 23036
		private bool mIsGuide;

		// Token: 0x040059FD RID: 23037
		private bool[] isCardOpened = new bool[12];

		// Token: 0x040059FE RID: 23038
		private int openChestCount;

		// Token: 0x040059FF RID: 23039
		private int normalChestCount;

		// Token: 0x04005A00 RID: 23040
		private int goldChestCount;

		// Token: 0x04005A01 RID: 23041
		private bool countTimeOut;

		// Token: 0x04005A02 RID: 23042
		private bool[] opened = new bool[12];

		// Token: 0x04005A03 RID: 23043
		private AnotherWorldDungeonRewardView mAnotherWorldDungeonRewardView;

		// Token: 0x04005A04 RID: 23044
		private ComCommonBind mCrossServiceFlipCardNumberBind;

		// Token: 0x04005A05 RID: 23045
		private Image[] mNormalRewardImageList = new Image[4];

		// Token: 0x04005A06 RID: 23046
		private Image[] mNormalRewardVIPImageList = new Image[4];

		// Token: 0x04005A07 RID: 23047
		private Image[] mAnotherRewardImageList = new Image[4];

		// Token: 0x04005A08 RID: 23048
		private GameObject mNormalSelect;

		// Token: 0x04005A09 RID: 23049
		private GameObject mNormalVIPSelect;

		// Token: 0x04005A0A RID: 23050
		private GameObject mAnotherSelect;

		// Token: 0x04005A0B RID: 23051
		private Coroutine mDelayClose;

		// Token: 0x04005A0C RID: 23052
		private Coroutine mTimeOut;

		// Token: 0x020010B4 RID: 4276
		private enum eType
		{
			// Token: 0x04005A0F RID: 23055
			None,
			// Token: 0x04005A10 RID: 23056
			Normal,
			// Token: 0x04005A11 RID: 23057
			Another,
			// Token: 0x04005A12 RID: 23058
			Vip,
			// Token: 0x04005A13 RID: 23059
			AnotherWorld
		}

		// Token: 0x020010B5 RID: 4277
		private enum eAnotherCardFlipType
		{
			// Token: 0x04005A15 RID: 23061
			None,
			// Token: 0x04005A16 RID: 23062
			VipFree,
			// Token: 0x04005A17 RID: 23063
			TicketCost,
			// Token: 0x04005A18 RID: 23064
			GoldCost,
			// Token: 0x04005A19 RID: 23065
			NotCostGoldItem,
			// Token: 0x04005A1A RID: 23066
			NotCostTicketItem,
			// Token: 0x04005A1B RID: 23067
			NotOpen,
			// Token: 0x04005A1C RID: 23068
			Aniversary_Forbidden
		}

		// Token: 0x020010B6 RID: 4278
		private enum eFlipProcess
		{
			// Token: 0x04005A1E RID: 23070
			None,
			// Token: 0x04005A1F RID: 23071
			WaitFlip,
			// Token: 0x04005A20 RID: 23072
			WaitClose,
			// Token: 0x04005A21 RID: 23073
			Finish
		}
	}
}
