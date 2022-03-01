using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001528 RID: 5416
	public class ChapterDeadFrame : ChapterBaseFrame
	{
		// Token: 0x0600D2C3 RID: 53955 RVA: 0x00342324 File Offset: 0x00340724
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ChapterDeath";
		}

		// Token: 0x0600D2C4 RID: 53956 RVA: 0x0034232B File Offset: 0x0034072B
		protected sealed override void _loadBg()
		{
		}

		// Token: 0x0600D2C5 RID: 53957 RVA: 0x0034232D File Offset: 0x0034072D
		private void _setRootMutex(bool flag)
		{
			this.mWipeoutRoot.CustomActive(flag);
			this.mNormalRoot.CustomActive(!flag);
		}

		// Token: 0x17001BF5 RID: 7157
		// (get) Token: 0x0600D2C7 RID: 53959 RVA: 0x003423FC File Offset: 0x003407FC
		// (set) Token: 0x0600D2C6 RID: 53958 RVA: 0x0034234C File Offset: 0x0034074C
		private ChapterDeadFrame.eState state
		{
			get
			{
				return this.mState;
			}
			set
			{
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterDeadFrame>(null))
				{
					this.mState = value;
					switch (this.mState)
					{
					case ChapterDeadFrame.eState.Normal:
						this._setRootMutex(false);
						this.mRewardShow.SetItems(new int[0]);
						break;
					case ChapterDeadFrame.eState.Wipeout:
						this._setRootMutex(true);
						this.mButtonRoot.SetActive(true);
						this.mOnWipeOutTittle.SetActive(true);
						break;
					case ChapterDeadFrame.eState.Reaward:
						this._setRootMutex(true);
						this.mButtonRoot.SetActive(false);
						this.mOnWipeOutTittle.SetActive(false);
						break;
					}
				}
			}
		}

		// Token: 0x0600D2C8 RID: 53960 RVA: 0x00342404 File Offset: 0x00340804
		protected sealed override void _bindExUI()
		{
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
			this.mContent = this.mBind.GetCom<RectTransform>("content");
			this.mRedpoint = this.mBind.GetCom<Image>("redpoint");
			this.mViptext = this.mBind.GetCom<Text>("viptext");
			this.mLeftResetCount = this.mBind.GetCom<Text>("leftResetCount");
			this.mLeftTimeRemain = this.mBind.GetCom<ComTime>("leftTimeRemain");
			this.mMyTopLevel = this.mBind.GetCom<Text>("myTopLevel");
			this.mMyTopTime = this.mBind.GetCom<ComTime>("myTopTime");
			this.mBestTopLevel = this.mBind.GetCom<Text>("bestTopLevel");
			this.mBestTopTime = this.mBind.GetCom<ComTime>("bestTopTime");
			this.mRewardShow = this.mBind.GetCom<ComItemList>("rewardShow");
			this.mCurrentLevelText = this.mBind.GetCom<Text>("currentLevelText");
			this.mWipeProcessText = this.mBind.GetCom<Text>("wipeProcessText");
			this.mCostTicket = this.mBind.GetCom<Text>("costTicket");
			this.mButtonRoot = this.mBind.GetGameObject("buttonRoot");
			this.mTextRoot = this.mBind.GetGameObject("textRoot");
			this.mSelectRanklist = this.mBind.GetCom<Button>("selectRanklist");
			this.mSelectRanklist.onClick.AddListener(new UnityAction(this._onSelectRanklistButtonClick));
			this.mSelectChallenge = this.mBind.GetCom<Button>("selectChallenge");
			this.mSelectChallenge.onClick.AddListener(new UnityAction(this._onSelectChallengeButtonClick));
			this.mSelectWipeoutPanle = this.mBind.GetCom<Button>("selectWipeoutPanle");
			this.mSelectWipeoutPanle.onClick.AddListener(new UnityAction(this._onSelectWipeoutPanleButtonClick));
			this.mSelectWipeout = this.mBind.GetCom<Button>("selectWipeout");
			this.mSelectWipeout.onClick.AddListener(new UnityAction(this._onSelectWipeoutButtonClick));
			this.mSelctWipeoutReward = this.mBind.GetCom<Button>("selctWipeoutReward");
			this.mSelctWipeoutReward.onClick.AddListener(new UnityAction(this._onSelctWipeoutRewardButtonClick));
			this.mSelctWipeoutComplete = this.mBind.GetCom<Button>("selctWipeoutComplete");
			this.mSelctWipeoutComplete.onClick.AddListener(new UnityAction(this._onSelctWipeoutCompleteButtonClick));
			this.mSelectReset = this.mBind.GetCom<Button>("selectReset");
			this.mSelectReset.onClick.AddListener(new UnityAction(this._onSelectResetButtonClick));
			this.mWipeoutRoot = this.mBind.GetGameObject("wipeoutRoot");
			this.mNormalRoot = this.mBind.GetGameObject("normalRoot");
			this.mLevelRoot = this.mBind.GetGameObject("levelRoot");
			this.mChapterInfo = this.mBind.GetCom<ComCommonChapterInfo>("chapterInfo");
			for (int i = 0; i < 16; i++)
			{
				this.mNodes[i] = this.mBind.GetGameObject(string.Format("node{0}", i));
			}
			this.mUnlockLine = this.mBind.GetCom<ComChapterSelectUnlock>("unlockLine");
			this.mNormalResetRoot = this.mBind.GetGameObject("normalResetRoot");
			this.mVipResetRoot = this.mBind.GetGameObject("vipResetRoot");
			this.mTextTopLevelRoot = this.mBind.GetGameObject("textTopLevelRoot");
			this.mOnWipeOutTittle = this.mBind.GetGameObject("onWipeOutTittle");
			this.mLimitLevel = this.mBind.GetGameObject("LimitLevel");
			this.mLimitLevelText = this.mBind.GetCom<Text>("LimitLevelText");
			this.mRewardScrollView = this.mBind.GetCom<ScrollRect>("RewardScrollView");
		}

		// Token: 0x0600D2C9 RID: 53961 RVA: 0x00342810 File Offset: 0x00340C10
		protected sealed override void _unbindExUI()
		{
			this.mScroll = null;
			this.mContent = null;
			this.mRedpoint = null;
			this.mViptext = null;
			this.mLeftResetCount = null;
			this.mLeftTimeRemain = null;
			this.mMyTopLevel = null;
			this.mMyTopTime = null;
			this.mBestTopLevel = null;
			this.mBestTopTime = null;
			this.mRewardShow = null;
			this.mCurrentLevelText = null;
			this.mWipeProcessText = null;
			this.mCostTicket = null;
			this.mButtonRoot = null;
			this.mTextRoot = null;
			this.mSelectRanklist.onClick.RemoveListener(new UnityAction(this._onSelectRanklistButtonClick));
			this.mSelectRanklist = null;
			this.mSelectChallenge.onClick.RemoveListener(new UnityAction(this._onSelectChallengeButtonClick));
			this.mSelectChallenge = null;
			this.mSelectWipeoutPanle.onClick.RemoveListener(new UnityAction(this._onSelectWipeoutPanleButtonClick));
			this.mSelectWipeoutPanle = null;
			this.mSelectWipeout.onClick.RemoveListener(new UnityAction(this._onSelectWipeoutButtonClick));
			this.mSelectWipeout = null;
			this.mSelctWipeoutReward.onClick.RemoveListener(new UnityAction(this._onSelctWipeoutRewardButtonClick));
			this.mSelctWipeoutReward = null;
			this.mSelctWipeoutComplete.onClick.RemoveListener(new UnityAction(this._onSelctWipeoutCompleteButtonClick));
			this.mSelctWipeoutComplete = null;
			this.mSelectReset.onClick.RemoveListener(new UnityAction(this._onSelectResetButtonClick));
			this.mSelectReset = null;
			this.mWipeoutRoot = null;
			this.mNormalRoot = null;
			this.mLevelRoot = null;
			this.mChapterInfo = null;
			for (int i = 0; i < 16; i++)
			{
				this.mNodes[i] = null;
			}
			this.mUnlockLine = null;
			this.mNormalResetRoot = null;
			this.mVipResetRoot = null;
			this.mTextTopLevelRoot = null;
			this.mOnWipeOutTittle = null;
			this.mLimitLevel = null;
			this.mLimitLevelText = null;
			this.mRewardScrollView = null;
		}

		// Token: 0x0600D2CA RID: 53962 RVA: 0x003429F2 File Offset: 0x00340DF2
		private void _onSelectRanklistButtonClick()
		{
			this._onClickRankList();
		}

		// Token: 0x0600D2CB RID: 53963 RVA: 0x003429FA File Offset: 0x00340DFA
		private void _onSelectChallengeButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600D2CC RID: 53964 RVA: 0x00342A02 File Offset: 0x00340E02
		private void _onSelectWipeoutPanleButtonClick()
		{
			this._onCloseWipeout();
		}

		// Token: 0x0600D2CD RID: 53965 RVA: 0x00342A0A File Offset: 0x00340E0A
		private void _onSelectWipeoutButtonClick()
		{
			this._onWipeOut();
		}

		// Token: 0x0600D2CE RID: 53966 RVA: 0x00342A12 File Offset: 0x00340E12
		private void _onSelctWipeoutRewardButtonClick()
		{
			this._onWipeOutResulte();
		}

		// Token: 0x0600D2CF RID: 53967 RVA: 0x00342A1C File Offset: 0x00340E1C
		private void _onSelctWipeoutCompleteButtonClick()
		{
			int nCount = this._getCostTicket((int)this.mLeftTimeInSec);
			CostItemManager.CostInfo a_costInfo = new CostItemManager.CostInfo
			{
				nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT),
				nCount = nCount
			};
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(a_costInfo, new Action(this._onWipeOutQuickFinish), "common_money_cost", null);
		}

		// Token: 0x0600D2D0 RID: 53968 RVA: 0x00342A74 File Offset: 0x00340E74
		private void _onSelectResetButtonClick()
		{
			this._onResetWipeOut();
		}

		// Token: 0x0600D2D1 RID: 53969 RVA: 0x00342A7C File Offset: 0x00340E7C
		private int _getNormalLeftCount()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_RESET_REMAIN_TIMES);
		}

		// Token: 0x0600D2D2 RID: 53970 RVA: 0x00342A90 File Offset: 0x00340E90
		private int _getVipResetCount()
		{
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.WARRIOR_TOWER_REBEGIN_NUM);
			if (curVipLevelPrivilegeData <= 0f)
			{
				return 0;
			}
			return (int)curVipLevelPrivilegeData - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_VIP_TOWER_PAY_TIMES);
		}

		// Token: 0x0600D2D3 RID: 53971 RVA: 0x00342AC3 File Offset: 0x00340EC3
		private void _updateRedPoint()
		{
			this.mRedpoint.enabled = (this._getNormalLeftCount() + this._getVipResetCount() > 0);
		}

		// Token: 0x0600D2D4 RID: 53972 RVA: 0x00342AE0 File Offset: 0x00340EE0
		private void _updateVipText()
		{
		}

		// Token: 0x0600D2D5 RID: 53973 RVA: 0x00342AE4 File Offset: 0x00340EE4
		private void _updateResetCount()
		{
			int num = this._getNormalLeftCount();
			int num2 = this._getVipResetCount();
			this.mLeftResetCount.text = string.Format("{0}", num);
			this.mViptext.text = string.Format("{0}", num2);
			this.mNormalResetRoot.SetActive(false);
			this.mVipResetRoot.SetActive(false);
			if (num == 0 && num2 > 0)
			{
				this.mVipResetRoot.SetActive(true);
			}
			else
			{
				this.mNormalResetRoot.SetActive(true);
			}
		}

		// Token: 0x0600D2D6 RID: 53974 RVA: 0x00342B78 File Offset: 0x00340F78
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.NowLevel = 0;
			this._bindEvent();
			this.mLeftTimeInSec = DataManager<PlayerBaseData>.GetInstance().DeathTowerWipeoutEndTime - DataManager<TimeManager>.GetInstance().GetServerTime();
			this._updateResetCount();
			this._updateRedPoint();
			this.mMyTopLevel.text = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR_TOTAL).ToString();
			this.mMyTopTime.SetTime(DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_USED_TIME_TOTAL));
			this._updateTimeRelate();
			this._updateState();
			this._loadAllLevels();
			this._startGetTopRecord();
			this._updateChallengeBtnState();
			this._updateScrollRectPosition();
		}

		// Token: 0x0600D2D7 RID: 53975 RVA: 0x00342C25 File Offset: 0x00341025
		protected void _stopGetTopRecord()
		{
			if (this.mGetTopRecord != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mGetTopRecord);
			}
			this.mGetTopRecord = null;
		}

		// Token: 0x0600D2D8 RID: 53976 RVA: 0x00342C49 File Offset: 0x00341049
		protected void _startGetTopRecord()
		{
			this._stopGetTopRecord();
			this.mGetTopRecord = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._getTopRecord());
		}

		// Token: 0x0600D2D9 RID: 53977 RVA: 0x00342C68 File Offset: 0x00341068
		protected void _updateChallengeBtnState()
		{
			this.mLimitLevel.CustomActive(false);
			if (this.NowLevel != 0 && this.NowLevel != DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv)
			{
				DeathTowerAwardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DeathTowerAwardTable>(this.NowLevel + 1, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				int limitLevel = tableItem.LimitLevel;
				if (limitLevel == 0)
				{
					return;
				}
				if (limitLevel != 0 && limitLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					this.mLimitLevel.CustomActive(true);
					this.mLimitLevelText.text = string.Format("{0}级开启", limitLevel);
					return;
				}
			}
		}

		// Token: 0x0600D2DA RID: 53978 RVA: 0x00342D14 File Offset: 0x00341114
		private void _updateScrollRectPosition()
		{
			float num = (float)this.NowLevel * 1f / 5f / 14f;
			if (num > 1f)
			{
			}
			this.mRewardScrollView.verticalNormalizedPosition = (float)this.NowLevel * 1f / 5f / 14f;
		}

		// Token: 0x0600D2DB RID: 53979 RVA: 0x00342D70 File Offset: 0x00341170
		protected IEnumerator _getTopRecord()
		{
			WorldSortListReq req = new WorldSortListReq
			{
				type = 30,
				start = 0,
				num = 1
			};
			MessageEvents msg = new MessageEvents();
			WorldSortListRet res = new WorldSortListRet();
			this.mBestTopLevel.text = string.Empty;
			this.mBestTopTime.SetTime(0);
			yield return MessageUtility.Wait<WorldSortListReq, WorldSortListRet>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (msg.IsAllMessageReceived())
			{
				MsgDATA messageData = msg.GetMessageData(res.GetMsgID());
				int num = 0;
				BaseSortList baseSortList = SortListDecoder.Decode(messageData.bytes, ref num, messageData.bytes.Length, false);
				if (baseSortList.entries.Count > 0)
				{
					DeathTowerSortListEntry deathTowerSortListEntry = baseSortList.entries[0] as DeathTowerSortListEntry;
					if (deathTowerSortListEntry != null)
					{
						this.mBestTopLevel.text = deathTowerSortListEntry.layer.ToString();
						this.mBestTopTime.SetTime((int)deathTowerSortListEntry.usedTime);
					}
				}
				this._updateChallengeBtnState();
			}
			yield break;
		}

		// Token: 0x0600D2DC RID: 53980 RVA: 0x00342D8C File Offset: 0x0034118C
		private void _updateTimeRelate()
		{
			this.mLeftTimeRemain.SetTime((int)(this.mLeftTimeInSec * 1000U));
			this.mCostTicket.text = this._getCostTicket((int)this.mLeftTimeInSec).ToString();
		}

		// Token: 0x0600D2DD RID: 53981 RVA: 0x00342DD8 File Offset: 0x003411D8
		private void _loadAllLevels()
		{
			this.mLevels.Clear();
			GameObject gameObject = this.mLevelRoot;
			string prefabPath = this.mBind.GetPrefabPath("level");
			for (int i = 0; i < 16; i++)
			{
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
				Utility.AttachTo(gameObject2, this.mNodes[i], false);
				ComChapterDeathItem component = gameObject2.GetComponent<ComChapterDeathItem>();
				component.SetIndex(i);
				List<AwardItemData> list = new List<AwardItemData>();
				int num = i * 5 + 1;
				for (int j = num; j < num + 5; j++)
				{
					DeathTowerAwardTable tableItem = Singleton<TableManager>.instance.GetTableItem<DeathTowerAwardTable>(j, string.Empty, string.Empty);
					if (tableItem != null && tableItem.AwardItem > 0)
					{
						AwardItemData awardItemData = new AwardItemData();
						if (awardItemData != null)
						{
							awardItemData.Num = tableItem.AwardItemNum;
							awardItemData.ID = tableItem.AwardItem;
						}
						list.Add(awardItemData);
					}
				}
				component.SetMask(DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_AWARD_MASK));
				int idx = i;
				component.SetClick(delegate(ComChapterDeathItem.eState state)
				{
					if (state != ComChapterDeathItem.eState.Pass)
					{
						if (state == ComChapterDeathItem.eState.Unlock || state == ComChapterDeathItem.eState.Lock)
						{
							ActiveAwardFrameData userData = new ActiveAwardFrameData
							{
								title = "首次通关奖励",
								datas = list
							};
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveAwardFrame>(FrameLayer.Middle, userData, string.Empty);
						}
					}
					else
					{
						this._sendRewardReq(idx);
					}
				});
				this.mLevels.Add(component);
			}
			this._updateCurrentLevel();
		}

		// Token: 0x0600D2DE RID: 53982 RVA: 0x00342F2A File Offset: 0x0034132A
		private bool _isTop()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR) == 80;
		}

		// Token: 0x0600D2DF RID: 53983 RVA: 0x00342F40 File Offset: 0x00341340
		private void _updateCurrentLevel()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR);
			int count2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR_TOTAL);
			int num = count / 5;
			int num2 = count2 / 5;
			int num3 = num2 + 1;
			LayoutRebuilder.ForceRebuildLayoutImmediate(this.mContent);
			this.mUnlockLine.SetUnlockCount(num + 1);
			for (int i = 0; i < 16; i++)
			{
				this.mLevels[i].SetSelect(false);
				int num4 = i + 1;
				if (num3 == num4)
				{
					this.mLevels[i].SetState(ComChapterDeathItem.eState.Unlock);
				}
				else if (num4 <= num2)
				{
					this.mLevels[i].SetState(ComChapterDeathItem.eState.Pass);
				}
				else
				{
					this.mLevels[i].SetState(ComChapterDeathItem.eState.Lock);
				}
				if (i == num)
				{
					this.mLevels[i].SetSelect(true);
					this.NowLevel = i * 5;
					this.mCurrentLevelText.text = string.Format("{0}-{1}", i * 5 + 1, i * 5 + 5);
					this.mWipeProcessText.text = string.Format("{0}/{1}", count, count2);
					this._updateChallengeBtnState();
				}
			}
			this.mTextRoot.SetActive(true);
			this.mTextTopLevelRoot.SetActive(false);
			if (num == 16)
			{
				this.mCurrentLevelText.text = string.Empty;
				this.mTextRoot.SetActive(false);
				this.mTextTopLevelRoot.SetActive(true);
			}
		}

		// Token: 0x0600D2E0 RID: 53984 RVA: 0x003430D6 File Offset: 0x003414D6
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this._unbindEvent();
			this._stopGetTopRecord();
		}

		// Token: 0x0600D2E1 RID: 53985 RVA: 0x003430EA File Offset: 0x003414EA
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D2E2 RID: 53986 RVA: 0x003430F0 File Offset: 0x003414F0
		private void _sendRewardReq(int f)
		{
			SceneTowerFloorAwardReq cmd = new SceneTowerFloorAwardReq
			{
				floor = (uint)(f * 5 + 5)
			};
			MonoSingleton<NetManager>.instance.SendCommand<SceneTowerFloorAwardReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600D2E3 RID: 53987 RVA: 0x00343120 File Offset: 0x00341520
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.state == ChapterDeadFrame.eState.Wipeout)
			{
				this.mTickTime += Time.unscaledDeltaTime;
				if (this.mTickTime > 1f)
				{
					this.mTickTime -= 1f;
					if (this.mLeftTimeInSec > 0U)
					{
						this.mLeftTimeInSec -= 1U;
						this._updateTimeRelate();
						this._updateState();
					}
				}
			}
		}

		// Token: 0x0600D2E4 RID: 53988 RVA: 0x00343194 File Offset: 0x00341594
		private void _updateState()
		{
			uint deathTowerWipeoutEndTime = DataManager<PlayerBaseData>.GetInstance().DeathTowerWipeoutEndTime;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (deathTowerWipeoutEndTime == 0U)
			{
				this.state = ChapterDeadFrame.eState.Normal;
			}
			else if (deathTowerWipeoutEndTime > serverTime)
			{
				this.state = ChapterDeadFrame.eState.Wipeout;
			}
			else
			{
				this.state = ChapterDeadFrame.eState.Reaward;
				this._onWipeOutResulte();
			}
		}

		// Token: 0x0600D2E5 RID: 53989 RVA: 0x003431EC File Offset: 0x003415EC
		protected sealed override void _loadLeftPanel()
		{
			if (null != this.mChapterInfo)
			{
				ComCommonChapterInfo comCommonChapterInfo = this.mChapterInfo;
				this.mChapterInfoCommon = comCommonChapterInfo;
				this.mChapterInfoDiffculte = comCommonChapterInfo;
				this.mChapterInfoDrops = comCommonChapterInfo;
				this.mChapterPassReward = comCommonChapterInfo;
				this.mChapterScore = comCommonChapterInfo;
				this.mChapterMonsterInfo = comCommonChapterInfo;
				this.mChapterActivityTimes = comCommonChapterInfo;
			}
			this.mChapterInfoDiffculte.SetDiffculte(this.mChapterInfoDiffculte.GetDiffculte(), this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D2E6 RID: 53990 RVA: 0x00343264 File Offset: 0x00341664
		protected override void _updateDropInfo()
		{
			base._updateDropInfo();
			SceneTowerWipeoutQueryResultReq sceneTowerWipeoutQueryResultReq = new SceneTowerWipeoutQueryResultReq();
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR);
			int num = count / 5;
			sceneTowerWipeoutQueryResultReq.beginFloor = (uint)(num * 5 + 1);
			sceneTowerWipeoutQueryResultReq.endFloor = (uint)DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR_TOTAL);
			NetManager netManager = NetManager.Instance();
			if (sceneTowerWipeoutQueryResultReq.endFloor >= sceneTowerWipeoutQueryResultReq.beginFloor)
			{
				netManager.SendCommand<SceneTowerWipeoutQueryResultReq>(ServerType.GATE_SERVER, sceneTowerWipeoutQueryResultReq);
			}
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneTowerWipeoutQueryResultRes>(delegate(SceneTowerWipeoutQueryResultRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				List<ComItemList.Items> list = new List<ComItemList.Items>();
				for (int i = 0; i < msgRet.items.Length; i++)
				{
					bool flag = false;
					for (int j = 0; j < list.Count; j++)
					{
						if (msgRet.items[i].typeId == (uint)list[j].id)
						{
							list[j].count += msgRet.items[i].num;
							flag = true;
						}
					}
					if (!flag)
					{
						list.Add(new ComItemList.Items
						{
							count = msgRet.items[i].num,
							id = (int)msgRet.items[i].typeId
						});
					}
				}
				this.mChapterInfoDrops.UpdateDropCount(list);
			}, false, 15f, null);
		}

		// Token: 0x0600D2E7 RID: 53991 RVA: 0x003432F0 File Offset: 0x003416F0
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._onDeadTowerWipeoutTimeChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._onCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.UpdateLevel));
		}

		// Token: 0x0600D2E8 RID: 53992 RVA: 0x0034334C File Offset: 0x0034174C
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._onDeadTowerWipeoutTimeChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._onCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.UpdateLevel));
		}

		// Token: 0x0600D2E9 RID: 53993 RVA: 0x003433A8 File Offset: 0x003417A8
		private void _onCountValueChange(UIEvent ui)
		{
			string text = ui.Param1 as string;
			if (text == CounterKeys.COUNTER_TOWER_RESET_REMAIN_TIMES)
			{
				this._updateResetCount();
				this._updateRedPoint();
			}
			else if (text == CounterKeys.COUNTER_TOWER_TOP_FLOOR_TOTAL)
			{
				this.mMyTopLevel.text = DataManager<CountDataManager>.GetInstance().GetCount(text).ToString();
				this._updateCurrentLevel();
				this._updateDropInfo();
			}
			else if (text == CounterKeys.COUNTER_TOWER_TOP_FLOOR)
			{
				this._updateCurrentLevel();
				this._updateDropInfo();
			}
			else if (text == CounterKeys.COUNTER_TOWER_USED_TIME_TOTAL)
			{
				this.mMyTopTime.SetTime(DataManager<CountDataManager>.GetInstance().GetCount(text));
			}
			else if (text == CounterKeys.COUNTER_TOWER_AWARD_MASK)
			{
				for (int i = 0; i < this.mLevels.Count; i++)
				{
					this.mLevels[i].SetMask(DataManager<CountDataManager>.GetInstance().GetCount(text));
				}
				this._updateCurrentLevel();
			}
			else if (text == CounterKeys.COUNTER_VIP_TOWER_PAY_TIMES)
			{
				this._updateResetCount();
				this._updateRedPoint();
			}
		}

		// Token: 0x0600D2EA RID: 53994 RVA: 0x003434E2 File Offset: 0x003418E2
		private void UpdateLevel(UIEvent uievent)
		{
			this._UpdateAllLevels();
		}

		// Token: 0x0600D2EB RID: 53995 RVA: 0x003434EC File Offset: 0x003418EC
		private void _UpdateAllLevels()
		{
			GameObject gameObject = this.mLevelRoot;
			string prefabPath = this.mBind.GetPrefabPath("level");
			for (int i = 0; i < 16; i++)
			{
				ComCommonBind componentInChildren = this.mNodes[i].GetComponentInChildren<ComCommonBind>();
				if (componentInChildren != null)
				{
					ComChapterDeathItem component = componentInChildren.gameObject.GetComponent<ComChapterDeathItem>();
					component.UpdateLimitLevel(i);
				}
			}
		}

		// Token: 0x0600D2EC RID: 53996 RVA: 0x00343554 File Offset: 0x00341954
		private int _getCostTicket(int leftSecond)
		{
			SystemValueTable tableItem = Singleton<TableManager>.instance.GetTableItem<SystemValueTable>(19, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<SystemValueTable>(20, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				int num = leftSecond / tableItem.Value + ((leftSecond % tableItem.Value <= 0) ? 0 : 1);
				return num * tableItem2.Value;
			}
			return 0;
		}

		// Token: 0x0600D2ED RID: 53997 RVA: 0x003435C0 File Offset: 0x003419C0
		private void _onDeadTowerWipeoutTimeChange(UIEvent ui)
		{
			this.mLeftTimeInSec = 0U;
			if (DataManager<PlayerBaseData>.GetInstance().DeathTowerWipeoutEndTime > DataManager<TimeManager>.GetInstance().GetServerTime())
			{
				this.mLeftTimeInSec = DataManager<PlayerBaseData>.GetInstance().DeathTowerWipeoutEndTime - DataManager<TimeManager>.GetInstance().GetServerTime();
				this._updateTimeRelate();
			}
			else
			{
				this.mLeftTimeRemain.SetTime(0);
				this.mCostTicket.text = string.Empty;
			}
			this._updateState();
		}

		// Token: 0x0600D2EE RID: 53998 RVA: 0x00343638 File Offset: 0x00341A38
		private IEnumerator _onWipeOutIter()
		{
			SceneTowerWipeoutReq req = new SceneTowerWipeoutReq();
			SceneTowerWipeoutRes res = new SceneTowerWipeoutRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<SceneTowerWipeoutReq, SceneTowerWipeoutRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			this.state = ChapterDeadFrame.eState.Normal;
			if (msg.IsAllMessageReceived())
			{
				if (res.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
				}
				else
				{
					this.state = ChapterDeadFrame.eState.Wipeout;
				}
			}
			yield break;
		}

		// Token: 0x0600D2EF RID: 53999 RVA: 0x00343654 File Offset: 0x00341A54
		private IEnumerator _onWipeOutResulteIter()
		{
			SceneTowerWipeoutResultReq req = new SceneTowerWipeoutResultReq();
			SceneTowerWipeoutResultRes res = new SceneTowerWipeoutResultRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<SceneTowerWipeoutResultReq, SceneTowerWipeoutResultRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			this.state = ChapterDeadFrame.eState.Reaward;
			if (msg.IsAllMessageReceived())
			{
				if (res.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
				}
				else
				{
					this.state = ChapterDeadFrame.eState.Reset;
					List<ComItemList.Items> list = new List<ComItemList.Items>();
					int i;
					for (i = 0; i < res.items.Length; i++)
					{
						ComItemList.Items items = list.Find((ComItemList.Items x) => x.id == (int)res.items[i].typeId);
						if (items != null)
						{
							items.count += res.items[i].num;
						}
						else
						{
							ComItemList.Items item = new ComItemList.Items
							{
								count = res.items[i].num,
								type = ComItemList.eItemType.Custom,
								id = (int)res.items[i].typeId,
								flag = ComItemList.eItemExtraFlag.Normal
							};
							list.Add(item);
						}
					}
					if (this.mRewardShow != null)
					{
						this.mRewardShow.SetItems(list.ToArray());
					}
					for (int j = 0; j < list.Count; j++)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list[j].id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							string msgContent = string.Format("{0} * {1}", tableItem.Name, list[j].count);
							SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, list[j].id);
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600D2F0 RID: 54000 RVA: 0x00343670 File Offset: 0x00341A70
		private IEnumerator _onWipeOutQuickFinisheIter()
		{
			SceneTowerWipeoutQuickFinishReq req = new SceneTowerWipeoutQuickFinishReq();
			SceneTowerWipeoutQuickFinishRes res = new SceneTowerWipeoutQuickFinishRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<SceneTowerWipeoutQuickFinishReq, SceneTowerWipeoutQuickFinishRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			this.state = ChapterDeadFrame.eState.Wipeout;
			if (msg.IsAllMessageReceived())
			{
				if (res.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
				}
				else
				{
					this.state = ChapterDeadFrame.eState.Reaward;
					this._onWipeOutResulte();
				}
			}
			yield break;
		}

		// Token: 0x0600D2F1 RID: 54001 RVA: 0x0034368B File Offset: 0x00341A8B
		private ChapterDeadFrame.eResetType _getResetType()
		{
			if (this._canResetCount())
			{
				return ChapterDeadFrame.eResetType.Normal;
			}
			if (this._canBuyReset())
			{
				return ChapterDeadFrame.eResetType.Vip;
			}
			return ChapterDeadFrame.eResetType.CannotReset;
		}

		// Token: 0x0600D2F2 RID: 54002 RVA: 0x003436A8 File Offset: 0x00341AA8
		private bool _canResetCount()
		{
			return this._getNormalLeftCount() > 0;
		}

		// Token: 0x0600D2F3 RID: 54003 RVA: 0x003436B3 File Offset: 0x00341AB3
		private bool _canBuyReset()
		{
			return this._getVipResetCount() > 0;
		}

		// Token: 0x0600D2F4 RID: 54004 RVA: 0x003436C0 File Offset: 0x00341AC0
		private IEnumerator _onWipeOutReseteIter()
		{
			SceneTowerResetReq req = new SceneTowerResetReq();
			SceneTowerResetRes res = new SceneTowerResetRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<SceneTowerResetReq, SceneTowerResetRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			this.state = ChapterDeadFrame.eState.Normal;
			if (msg.IsAllMessageReceived() && res.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
			}
			yield break;
		}

		// Token: 0x0600D2F5 RID: 54005 RVA: 0x003436DC File Offset: 0x00341ADC
		[ProtocolHandle(typeof(SceneTowerFloorAwardRes))]
		private void _onSceneTowerFloorAwardRes(SceneTowerFloorAwardRes res)
		{
			if (res.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
			}
			else
			{
				for (int i = 0; i < res.items.Length; i++)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)res.items[i].typeId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						string msgContent = string.Format("{0} * {1}", tableItem.Name, res.items[i].num);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, (int)res.items[i].typeId);
					}
				}
			}
		}

		// Token: 0x0600D2F6 RID: 54006 RVA: 0x00343786 File Offset: 0x00341B86
		private void _onClickRankList()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<RanklistFrame>(FrameLayer.Middle, SortListType.SORTLIST_TOWER_OCCU_KUANGZHANSHI, string.Empty);
		}

		// Token: 0x0600D2F7 RID: 54007 RVA: 0x003437A0 File Offset: 0x00341BA0
		private void _onStartButton()
		{
			if (!this._isTop())
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
			}
			else
			{
				SystemNotifyManager.SystemNotify(5019, string.Empty);
			}
		}

		// Token: 0x0600D2F8 RID: 54008 RVA: 0x003437D2 File Offset: 0x00341BD2
		private void _onCloseWipeout()
		{
			if (this.state == ChapterDeadFrame.eState.Reset)
			{
				this.state = ChapterDeadFrame.eState.Normal;
			}
			else if (this.state == ChapterDeadFrame.eState.Wipeout)
			{
			}
		}

		// Token: 0x0600D2F9 RID: 54009 RVA: 0x003437F8 File Offset: 0x00341BF8
		private void _onWipeOut()
		{
			SystemNotifyManager.SystemNotify(5003, delegate()
			{
				if (this.state == ChapterDeadFrame.eState.Normal)
				{
					this.state = ChapterDeadFrame.eState.Wait;
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWipeOutIter());
				}
				else
				{
					Logger.LogErrorFormat("错误状态 {0}", new object[]
					{
						this.state
					});
				}
			});
		}

		// Token: 0x0600D2FA RID: 54010 RVA: 0x00343810 File Offset: 0x00341C10
		private void _onWipeOutResulte()
		{
			if (this.state == ChapterDeadFrame.eState.Reaward)
			{
				this.state = ChapterDeadFrame.eState.Wait;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWipeOutResulteIter());
			}
			else
			{
				Logger.LogErrorFormat("错误状态 {0}", new object[]
				{
					this.state
				});
			}
		}

		// Token: 0x0600D2FB RID: 54011 RVA: 0x00343864 File Offset: 0x00341C64
		private void _onWipeOutQuickFinish()
		{
			if (this.state == ChapterDeadFrame.eState.Wipeout)
			{
				this.state = ChapterDeadFrame.eState.Wait;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWipeOutQuickFinisheIter());
			}
			else
			{
				Logger.LogErrorFormat("错误状态 {0}", new object[]
				{
					this.state
				});
			}
		}

		// Token: 0x0600D2FC RID: 54012 RVA: 0x003438B8 File Offset: 0x00341CB8
		private void _onResetWipeOutCB()
		{
			if (this.state == ChapterDeadFrame.eState.Normal)
			{
				this.state = ChapterDeadFrame.eState.Wait;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWipeOutReseteIter());
			}
			else
			{
				Logger.LogErrorFormat("错误状态 {0}", new object[]
				{
					this.state
				});
			}
		}

		// Token: 0x0600D2FD RID: 54013 RVA: 0x0034390C File Offset: 0x00341D0C
		private void _onResetWipeOut()
		{
			ChapterDeadFrame.eResetType eResetType = this._getResetType();
			if (eResetType != ChapterDeadFrame.eResetType.CannotReset)
			{
				if (eResetType != ChapterDeadFrame.eResetType.Normal)
				{
					if (eResetType == ChapterDeadFrame.eResetType.Vip)
					{
						ulong num = 0UL;
						SystemValueTable tableItem = Singleton<TableManager>.instance.GetTableItem<SystemValueTable>(30, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num = (ulong)((long)tableItem.Value);
						}
						CostItemManager.CostInfo a_costInfo = new CostItemManager.CostInfo
						{
							nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT),
							nCount = (int)num
						};
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(a_costInfo, new Action(this._onResetWipeOutCB), "common_money_cost", null);
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(5004, new UnityAction(this._onResetWipeOutCB));
				}
			}
			else
			{
				SystemNotifyManager.SystemNotify(5014, string.Empty);
			}
		}

		// Token: 0x04007B48 RID: 31560
		private ChapterDeadFrame.eState mState;

		// Token: 0x04007B49 RID: 31561
		private List<ComChapterDeathItem> mLevels = new List<ComChapterDeathItem>();

		// Token: 0x04007B4A RID: 31562
		private int NowLevel;

		// Token: 0x04007B4B RID: 31563
		private ScrollRect mScroll;

		// Token: 0x04007B4C RID: 31564
		private RectTransform mContent;

		// Token: 0x04007B4D RID: 31565
		private Image mRedpoint;

		// Token: 0x04007B4E RID: 31566
		private Text mViptext;

		// Token: 0x04007B4F RID: 31567
		private Text mLeftResetCount;

		// Token: 0x04007B50 RID: 31568
		private ComTime mLeftTimeRemain;

		// Token: 0x04007B51 RID: 31569
		private Text mMyTopLevel;

		// Token: 0x04007B52 RID: 31570
		private ComTime mMyTopTime;

		// Token: 0x04007B53 RID: 31571
		private Text mBestTopLevel;

		// Token: 0x04007B54 RID: 31572
		private ComTime mBestTopTime;

		// Token: 0x04007B55 RID: 31573
		private ComItemList mRewardShow;

		// Token: 0x04007B56 RID: 31574
		private Text mCurrentLevelText;

		// Token: 0x04007B57 RID: 31575
		private Text mWipeProcessText;

		// Token: 0x04007B58 RID: 31576
		private Text mCostTicket;

		// Token: 0x04007B59 RID: 31577
		private GameObject mButtonRoot;

		// Token: 0x04007B5A RID: 31578
		private GameObject mTextRoot;

		// Token: 0x04007B5B RID: 31579
		private Button mSelectRanklist;

		// Token: 0x04007B5C RID: 31580
		private Button mSelectChallenge;

		// Token: 0x04007B5D RID: 31581
		private Button mSelectWipeoutPanle;

		// Token: 0x04007B5E RID: 31582
		private Button mSelectWipeout;

		// Token: 0x04007B5F RID: 31583
		private Button mSelctWipeoutReward;

		// Token: 0x04007B60 RID: 31584
		private Button mSelctWipeoutComplete;

		// Token: 0x04007B61 RID: 31585
		private Button mSelectReset;

		// Token: 0x04007B62 RID: 31586
		private GameObject mWipeoutRoot;

		// Token: 0x04007B63 RID: 31587
		private GameObject mNormalRoot;

		// Token: 0x04007B64 RID: 31588
		private GameObject mLevelRoot;

		// Token: 0x04007B65 RID: 31589
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007B66 RID: 31590
		private GameObject[] mNodes = new GameObject[16];

		// Token: 0x04007B67 RID: 31591
		private ComChapterSelectUnlock mUnlockLine;

		// Token: 0x04007B68 RID: 31592
		private GameObject mNormalResetRoot;

		// Token: 0x04007B69 RID: 31593
		private GameObject mVipResetRoot;

		// Token: 0x04007B6A RID: 31594
		private GameObject mTextTopLevelRoot;

		// Token: 0x04007B6B RID: 31595
		private GameObject mOnWipeOutTittle;

		// Token: 0x04007B6C RID: 31596
		private GameObject mLimitLevel;

		// Token: 0x04007B6D RID: 31597
		private Text mLimitLevelText;

		// Token: 0x04007B6E RID: 31598
		private ScrollRect mRewardScrollView;

		// Token: 0x04007B6F RID: 31599
		protected Coroutine mGetTopRecord;

		// Token: 0x04007B70 RID: 31600
		private float mTickTime;

		// Token: 0x04007B71 RID: 31601
		private uint mLeftTimeInSec;

		// Token: 0x02001529 RID: 5417
		private enum eState
		{
			// Token: 0x04007B73 RID: 31603
			Normal,
			// Token: 0x04007B74 RID: 31604
			Wait,
			// Token: 0x04007B75 RID: 31605
			Wipeout,
			// Token: 0x04007B76 RID: 31606
			Reaward,
			// Token: 0x04007B77 RID: 31607
			Reset
		}

		// Token: 0x0200152A RID: 5418
		private enum eResetType
		{
			// Token: 0x04007B79 RID: 31609
			CannotReset,
			// Token: 0x04007B7A RID: 31610
			Normal,
			// Token: 0x04007B7B RID: 31611
			Vip
		}
	}
}
