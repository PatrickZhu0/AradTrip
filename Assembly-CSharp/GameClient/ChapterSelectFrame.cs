using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ActivityLimitTime;
using Battle;
using DG.Tweening;
using ProtoTable;
using TMEngine.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace GameClient
{
	// Token: 0x02001537 RID: 5431
	[LoggerModel("Chapter")]
	public class ChapterSelectFrame : ClientFrame
	{
		// Token: 0x0600D3D0 RID: 54224 RVA: 0x0034B12C File Offset: 0x0034952C
		public ChapterSelectFrame()
		{
			if (ChapterSelectFrame.<>f__mg$cache0 == null)
			{
				ChapterSelectFrame.<>f__mg$cache0 = new OnAssetLoadSuccess(ChapterSelectFrame._OnSuccess);
			}
			OnAssetLoadSuccess onSuccess = ChapterSelectFrame.<>f__mg$cache0;
			if (ChapterSelectFrame.<>f__mg$cache1 == null)
			{
				ChapterSelectFrame.<>f__mg$cache1 = new OnAssetLoadFailure(ChapterSelectFrame._OnFailed);
			}
			this.mAssetLoaderCallback = new AssetLoadCallbacks(onSuccess, ChapterSelectFrame.<>f__mg$cache1);
			base..ctor();
		}

		// Token: 0x0600D3D1 RID: 54225 RVA: 0x0034B1B8 File Offset: 0x003495B8
		public static void SetSceneID(int id)
		{
			ChapterSelectFrame.sNodes.Clear();
			ChapterSelectFrame.sSceneID = id;
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.ChapterData.Count; i++)
				{
					ChapterSelectFrame.AppendChapter(tableItem.ChapterData[i]);
					if (ChapterSelectFrame.sNodes != null && i >= 0 && i < ChapterSelectFrame.sNodes.Count && ChapterSelectFrame.sNodes[i].dungeonIDs != null && ChapterSelectFrame.sNodes[i].dungeonIDs.Count > 0 && ChapterUtility.GetDungeonState(ChapterSelectFrame.sNodes[i].dungeonIDs[0]) != ComChapterDungeonUnit.eState.Locked)
					{
						ChapterSelectFrame.selectChapterIdx = i;
					}
				}
			}
		}

		// Token: 0x0600D3D2 RID: 54226 RVA: 0x0034B298 File Offset: 0x00349698
		public static void AppendChapter(string path)
		{
			DChapterData dchapterData = Singleton<AssetLoader>.instance.LoadRes(path, typeof(DChapterData), true, 0U).obj as DChapterData;
			if (dchapterData != null)
			{
				ChapterSelectFrame.Node node = new ChapterSelectFrame.Node();
				node.path = path;
				node.data = dchapterData;
				for (int i = 0; i < dchapterData.chapterList.Length; i++)
				{
					node.dungeonIDs.Add(dchapterData.chapterList[i].dungeonID);
				}
				ChapterSelectFrame.sNodes.Add(node);
			}
		}

		// Token: 0x0600D3D3 RID: 54227 RVA: 0x0034B324 File Offset: 0x00349724
		public static void SetDungeonID(int id)
		{
			if (ChapterSelectFrame.sDungeonID != id)
			{
				ChapterSelectFrame.sDungeonID = id;
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterSelectFrame>(null) && id != 999999)
				{
					ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
					ChapterSelectFrame.mDungeonID.dungeonID = ChapterSelectFrame.sDungeonID;
					for (int i = 0; i < ChapterSelectFrame.sNodes.Count; i++)
					{
						for (int j = 0; j < ChapterSelectFrame.sNodes[i].dungeonIDs.Count; j++)
						{
							if (ChapterSelectFrame.sNodes[i].dungeonIDs[j] == ChapterSelectFrame.mDungeonID.dungeonIDWithOutPrestory)
							{
								chapterSelectFrame.mEnterWay = ChapterSelectFrame.eEnterWay.onGuide;
								chapterSelectFrame._changeChapter(i);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x17001BF6 RID: 7158
		// (get) Token: 0x0600D3D4 RID: 54228 RVA: 0x0034B3FF File Offset: 0x003497FF
		// (set) Token: 0x0600D3D5 RID: 54229 RVA: 0x0034B424 File Offset: 0x00349824
		private static int selectChapterIdx
		{
			get
			{
				ChapterSelectFrame.mSelectChapterIdx = Mathf.Clamp(ChapterSelectFrame.mSelectChapterIdx, 0, ChapterSelectFrame.sNodes.Count - 1);
				return ChapterSelectFrame.mSelectChapterIdx;
			}
			set
			{
				int num = Mathf.Clamp(value, 0, ChapterSelectFrame.sNodes.Count - 1);
				if (value == num)
				{
					ChapterSelectFrame.mSelectChapterIdx = num;
				}
			}
		}

		// Token: 0x0600D3D6 RID: 54230 RVA: 0x0034B454 File Offset: 0x00349854
		private static int _getChapterIdByIdx(int idx)
		{
			if (ChapterSelectFrame.sNodes.Count > idx && idx >= 0)
			{
				List<int> dungeonIDs = ChapterSelectFrame.sNodes[idx].dungeonIDs;
				if (null != ChapterSelectFrame.sNodes[idx].data)
				{
					return ChapterSelectFrame.sNodes[idx].data.nameNumberIdx;
				}
			}
			return -1;
		}

		// Token: 0x0600D3D7 RID: 54231 RVA: 0x0034B4BB File Offset: 0x003498BB
		public static int GetCurrentSelectChapter()
		{
			return ChapterSelectFrame._getChapterIdByIdx(ChapterSelectFrame.selectChapterIdx);
		}

		// Token: 0x0600D3D8 RID: 54232 RVA: 0x0034B4C8 File Offset: 0x003498C8
		public List<int> GetCurrentChapterDungeonIDs()
		{
			if (this.mCurrent == null || this.mCurrent.node == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			list.AddRange(this.mCurrent.node.dungeonIDs);
			return list;
		}

		// Token: 0x0600D3D9 RID: 54233 RVA: 0x0034B510 File Offset: 0x00349910
		public static bool IsCurrentSelectChapterShowReward()
		{
			int currentSelectChapter = ChapterSelectFrame.GetCurrentSelectChapter();
			ChapterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChapterTable>(currentSelectChapter, string.Empty, string.Empty);
			return tableItem != null && tableItem.RewardIsOpen == 1;
		}

		// Token: 0x17001BF7 RID: 7159
		// (get) Token: 0x0600D3DA RID: 54234 RVA: 0x0034B550 File Offset: 0x00349950
		private static bool isSelectChapterLeftMost
		{
			get
			{
				return ChapterSelectFrame.selectChapterIdx == 0;
			}
		}

		// Token: 0x17001BF8 RID: 7160
		// (get) Token: 0x0600D3DB RID: 54235 RVA: 0x0034B55A File Offset: 0x0034995A
		private static bool isSelectChapterRightMost
		{
			get
			{
				return ChapterSelectFrame.selectChapterIdx == ChapterSelectFrame.sNodes.Count - 1;
			}
		}

		// Token: 0x0600D3DC RID: 54236 RVA: 0x0034B570 File Offset: 0x00349970
		protected sealed override void _bindExUI()
		{
			this.mSelectUnlock = this.mBind.GetCom<ComChapterSelectUnlock>("SelectUnlock");
			this.mToggleGroup = this.mBind.GetCom<ToggleGroup>("ToggleGroup");
			this.mLeftBackground = this.mBind.GetCom<Image>("LeftBackground");
			this.mLeftMid = this.mBind.GetCom<Image>("LeftMid");
			this.mRRecttransform = this.mBind.GetCom<RectTransform>("RRecttransform");
			this.mRewardRedPoint = this.mBind.GetGameObject("RewardRedPoint");
			this.mLeftButton = this.mBind.GetCom<UIGray>("LeftButton");
			this.mRightButton = this.mBind.GetCom<UIGray>("RightButton");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mReward = this.mBind.GetCom<Button>("Reward");
			if (null != this.mReward)
			{
				this.mReward.onClick.AddListener(new UnityAction(this._onRewardButtonClick));
			}
			this.mSelectLeft = this.mBind.GetCom<Button>("SelectLeft");
			if (null != this.mSelectLeft)
			{
				this.mSelectLeft.onClick.AddListener(new UnityAction(this._onSelectLeftButtonClick));
			}
			this.mSelectRight = this.mBind.GetCom<Button>("SelectRight");
			if (null != this.mSelectRight)
			{
				this.mSelectRight.onClick.AddListener(new UnityAction(this._onSelectRightButtonClick));
			}
			this.mUnitRoot = this.mBind.GetGameObject("UnitRoot");
			this.mChapterName = this.mBind.GetCom<Text>("ChapterName");
			this.mChapterNameImage = this.mBind.GetCom<Image>("ChapterNameImage");
			this.mChapterIndex = this.mBind.GetCom<Text>("ChapterIndex");
			this.mPointRoot = this.mBind.GetGameObject("PointRoot");
			this.mPointRootGroup = this.mBind.GetCom<ToggleGroup>("PointRootGroup");
			this.mLeftRed = this.mBind.GetGameObject("LeftRed");
			this.mRightRed = this.mBind.GetGameObject("RightRed");
			this.mNodeRoot = this.mBind.GetGameObject("NodeRoot");
			this.mChapterSelectAnimate = this.mBind.GetCom<ComChapterSelectAnimate>("ChapterSelectAnimate");
			this.mChapterRewardCount = this.mBind.GetCom<Text>("chapterRewardCount");
			this.mChapterRewardSum = this.mBind.GetCom<Text>("chapterRewardSum");
			this.mRedPoint = this.mBind.GetGameObject("RedPoint");
			this.mRedPointSum = this.mBind.GetCom<Text>("RedPointSum");
			this.mRewardComplete = this.mBind.GetGameObject("RewardComplete");
			this.mFatigueCombustionRoot = this.mBind.GetGameObject("FatigueCombustionRoot");
			this.mRewardAnimation = this.mBind.GetCom<DOTweenAnimation>("RewardAnimation");
			this.mExchangeShopRoot = this.mBind.GetGameObject("ExchangeShopRoot");
			this.mEffectRoot = this.mBind.GetGameObject("effectRoot");
			this.mTitleBg = this.mBind.GetGameObject("TitleBg");
			this.mChapter = this.mBind.GetGameObject("Chapter");
			this.mYijieTitleBg = this.mBind.GetGameObject("YijieTitleBg");
			this.yijieChallengeNumRoot = this.mBind.GetGameObject("yijieChallengeNumRoot");
			this.yijieChallengeNumInfo = this.mBind.GetCom<Text>("numInfo");
			this.mChapterIndexParentGo = this.mBind.GetGameObject("ChapterIndexParent");
		}

		// Token: 0x0600D3DD RID: 54237 RVA: 0x0034B960 File Offset: 0x00349D60
		protected sealed override void _unbindExUI()
		{
			this.mSelectUnlock = null;
			this.mToggleGroup = null;
			this.mLeftBackground = null;
			this.mLeftMid = null;
			this.mRRecttransform = null;
			this.mRewardRedPoint = null;
			this.mLeftButton = null;
			this.mRightButton = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			if (null != this.mReward)
			{
				this.mReward.onClick.RemoveListener(new UnityAction(this._onRewardButtonClick));
			}
			this.mReward = null;
			if (null != this.mSelectLeft)
			{
				this.mSelectLeft.onClick.RemoveListener(new UnityAction(this._onSelectLeftButtonClick));
			}
			this.mSelectLeft = null;
			if (null != this.mSelectRight)
			{
				this.mSelectRight.onClick.RemoveListener(new UnityAction(this._onSelectRightButtonClick));
			}
			this.mSelectRight = null;
			this.mUnitRoot = null;
			this.mChapterName = null;
			this.mChapterNameImage = null;
			this.mChapterIndex = null;
			this.mPointRoot = null;
			this.mPointRootGroup = null;
			this.mLeftRed = null;
			this.mRightRed = null;
			this.mNodeRoot = null;
			this.mChapterSelectAnimate = null;
			this.mChapterRewardCount = null;
			this.mChapterRewardSum = null;
			this.mRedPoint = null;
			this.mRedPointSum = null;
			this.mRewardComplete = null;
			this.mFatigueCombustionRoot = null;
			this.mRewardAnimation = null;
			this.mExchangeShopRoot = null;
			this.mEffectRoot = null;
			this.mTitleBg = null;
			this.mChapter = null;
			this.mYijieTitleBg = null;
			this.yijieChallengeNumRoot = null;
			this.yijieChallengeNumInfo = null;
			this.mChapterIndexParentGo = null;
		}

		// Token: 0x0600D3DE RID: 54238 RVA: 0x0034BB24 File Offset: 0x00349F24
		private void _onCloseButtonClick()
		{
			this._closeFrame();
		}

		// Token: 0x0600D3DF RID: 54239 RVA: 0x0034BB2C File Offset: 0x00349F2C
		private void _onRewardButtonClick()
		{
			if (ChapterSelectFrame.sSceneID == this.mSpringFestivalSceneID)
			{
				int num = 0;
				int.TryParse(TR.Value("treasurehunt_activity_id"), out num);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeActivityFrame>(FrameLayer.Middle, num, string.Empty);
			}
			else
			{
				this._onDungeonReward();
			}
		}

		// Token: 0x0600D3E0 RID: 54240 RVA: 0x0034BB7F File Offset: 0x00349F7F
		private void _onSelectLeftButtonClick()
		{
			if (this._isUnlockChapter(ChapterSelectFrame.selectChapterIdx - 1))
			{
				this._onLeft();
			}
		}

		// Token: 0x0600D3E1 RID: 54241 RVA: 0x0034BB99 File Offset: 0x00349F99
		private void _onSelectRightButtonClick()
		{
			if (this._isUnlockChapter(ChapterSelectFrame.selectChapterIdx + 1))
			{
				this._onRight();
			}
		}

		// Token: 0x0600D3E2 RID: 54242 RVA: 0x0034BBB4 File Offset: 0x00349FB4
		protected sealed override void _OnLoadPrefabFinish()
		{
			if (ChapterSelectFrame.sNodes != null && ChapterSelectFrame.selectChapterIdx >= 0 && ChapterSelectFrame.selectChapterIdx < ChapterSelectFrame.sNodes.Count)
			{
				if (this.mCurrent != null)
				{
					this.mCurrent.SetNode(ChapterSelectFrame.sNodes[ChapterSelectFrame.selectChapterIdx]);
				}
				else
				{
					Logger.LogErrorFormat("mCurrent == null,selectChapterIdx = {0}", new object[]
					{
						ChapterSelectFrame.selectChapterIdx
					});
				}
			}
			else if (ChapterSelectFrame.sNodes == null)
			{
				Logger.LogErrorFormat("ChapterSelectFrame [_OnLoadPrefabFinish] sNodes == null, selectChapterIdx = {0}", new object[]
				{
					ChapterSelectFrame.selectChapterIdx
				});
			}
			else
			{
				Logger.LogErrorFormat("ChapterSelectFrame [_OnLoadPrefabFinish] Argument is out of range, selectChapterIdx = {0},sNodes.Count = {1}", new object[]
				{
					ChapterSelectFrame.selectChapterIdx,
					ChapterSelectFrame.sNodes.Count
				});
			}
			if (ChapterSelectFrame.mDungeonID != null)
			{
				ChapterSelectFrame.mDungeonID.dungeonID = ChapterSelectFrame.sDungeonID;
				if (this.mCurrent != null)
				{
					this.mCurrent.UpdateIndex(ChapterSelectFrame.mDungeonID.dungeonIDWithOutPrestory);
				}
			}
			DChapterData dchapterData = null;
			if (this.mCurrent != null)
			{
				dchapterData = this.mCurrent.GetData();
			}
			if (dchapterData == null)
			{
				Logger.LogError("mData is nil");
			}
			if (dchapterData.chapterList == null)
			{
				Logger.LogError("chapterList is nil");
			}
			int num = 0;
			if (dchapterData.chapterList != null)
			{
				num = dchapterData.chapterList.Length;
			}
			if (num <= 0)
			{
				Logger.LogErrorFormat("data.chapterList.Length = {0}", new object[]
				{
					num
				});
			}
			if (num > 0)
			{
				this.mToggleList = new Toggle[num];
				this.mToggleGameUnitList = new ComChapterDungeonUnit[num];
			}
			if (this.mBind != null)
			{
				string prefabPath = this.mBind.GetPrefabPath("unit");
				this.mBind.ClearCacheBinds(prefabPath);
				for (int i = 0; i < num; i++)
				{
					ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
					if (null != comCommonBind)
					{
						if (this.mNodeRoot != null)
						{
							global::Utility.AttachTo(comCommonBind.gameObject, this.mNodeRoot, false);
						}
						comCommonBind.gameObject.name = string.Format("Level{0}", i);
						ComChapterDungeonUnit com = comCommonBind.GetCom<ComChapterDungeonUnit>("DungeonUnit");
						Toggle com2 = comCommonBind.GetCom<Toggle>("Select");
						Text com3 = comCommonBind.GetCom<Text>("OrderNumber");
						if (com3 != null)
						{
							com3.text = string.Format("{0}", i + 1);
						}
						this.mToggleGameUnitList[i] = com;
						this.mToggleList[i] = com2;
					}
				}
			}
		}

		// Token: 0x0600D3E3 RID: 54243 RVA: 0x0034BE65 File Offset: 0x0034A265
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Select/ChapterSelect";
		}

		// Token: 0x0600D3E4 RID: 54244 RVA: 0x0034BE6C File Offset: 0x0034A26C
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D3E5 RID: 54245 RVA: 0x0034BE6F File Offset: 0x0034A26F
		protected sealed override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600D3E6 RID: 54246 RVA: 0x0034BE71 File Offset: 0x0034A271
		protected sealed override void _OnCloseFrame()
		{
			this._onUnbind();
			this._clearAll();
			this.YiJieEffectObj = null;
			this.bInitEffect = false;
		}

		// Token: 0x0600D3E7 RID: 54247 RVA: 0x0034BE8D File Offset: 0x0034A28D
		private void _updateRewardButtonStatus()
		{
			this.mReward.gameObject.SetActive(ChapterSelectFrame.IsCurrentSelectChapterShowReward());
		}

		// Token: 0x0600D3E8 RID: 54248 RVA: 0x0034BEA4 File Offset: 0x0034A2A4
		private void _updateRewardRedPoint()
		{
			bool flag = ChapterUtility.IsChapterCanGetChapterReward(ChapterSelectFrame.GetCurrentSelectChapter());
			KeyValuePair<int, int> chapterRewardByChapterIdx = ChapterUtility.GetChapterRewardByChapterIdx(ChapterSelectFrame.GetCurrentSelectChapter());
			int chapterCanGetByChapterIdx = ChapterUtility.GetChapterCanGetByChapterIdx(ChapterSelectFrame.GetCurrentSelectChapter());
			if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key == 0)
			{
				this.mRewardRedPoint.CustomActive(false);
				this.mRewardAnimation.DOPause();
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx != 0)
			{
				this.mRewardRedPoint.CustomActive(false);
				this.mRedPoint.CustomActive(true);
				this._updateRedPointNum(chapterCanGetByChapterIdx);
				this.mRewardAnimation.DOPause();
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key > 0 && flag)
			{
				this.mRewardRedPoint.CustomActive(true);
				this.mRedPoint.CustomActive(false);
				this.mRewardAnimation.DOPlayForward();
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key == chapterRewardByChapterIdx.Value && !flag)
			{
				this.mRewardRedPoint.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardAnimation.DOPause();
				this.mRewardComplete.CustomActive(true);
			}
			else
			{
				this.mRewardRedPoint.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardAnimation.DOPause();
				this.mRewardComplete.CustomActive(false);
			}
			this.mChapterRewardCount.text = chapterRewardByChapterIdx.Key.ToString();
			this.mChapterRewardSum.text = chapterRewardByChapterIdx.Value.ToString();
			this.mLeftRed.SetActive(ChapterUtility.IsChapterCanGetChapterReward(ChapterSelectFrame._getChapterIdByIdx(ChapterSelectFrame.selectChapterIdx - 1)));
			this.mRightRed.SetActive(ChapterUtility.IsChapterCanGetChapterReward(ChapterSelectFrame._getChapterIdByIdx(ChapterSelectFrame.selectChapterIdx + 1)));
			if (ChapterSelectFrame.sSceneID == this.mAnniversaryPartySceneID || ChapterSelectFrame.sSceneID == this.mSpringFestivalSceneID)
			{
				this.mRewardRedPoint.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardAnimation.DOPause();
				this.mRewardComplete.CustomActive(false);
			}
		}

		// Token: 0x0600D3E9 RID: 54249 RVA: 0x0034C0E4 File Offset: 0x0034A4E4
		private void _updateRedPointNum(int RedPointSum)
		{
			this.mRedPointSum.text = RedPointSum.ToString();
		}

		// Token: 0x0600D3EA RID: 54250 RVA: 0x0034C0FE File Offset: 0x0034A4FE
		private static void _OnSuccess(string path, object asset, int taskGrpID, float duration, object userData)
		{
		}

		// Token: 0x0600D3EB RID: 54251 RVA: 0x0034C100 File Offset: 0x0034A500
		private static void _OnFailed(string path, AssetLoadErrorCode errorCode, string message, object userData)
		{
		}

		// Token: 0x0600D3EC RID: 54252 RVA: 0x0034C104 File Offset: 0x0034A504
		protected sealed override void _OnOpenFrame()
		{
			this.mAnimateState = ChapterSelectFrame.eAnimateState.onNone;
			if (SwitchFunctionUtility.IsOpen(110))
			{
				AssetLoader.LoadResAsync("UIFlatten/Prefabs/Chapter/Normal/ChapterNormalHalf.prefab", typeof(GameObject), this.mAssetLoaderCallback, null, 0U, 0U);
			}
			this._onBind();
			this._loadChapterData(this.mCurrent.GetData());
			this._InitBgImage();
			this._updateUnlockChapter();
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl() && !Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.GuanKaGuide))
			{
				Singleton<NewbieGuideManager>.GetInstance().ManagerFinishGuide(Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID());
			}
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.GuankaFrameOpen, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuankaFrameOpen, null, null, null, null);
			this._updateMissionStatus();
			this._updateRewardRedPoint();
			this._updateRewardButtonStatus();
			this._updateTipsPoint();
			this._updateSelectButton();
			this._InitExchangeShopRoot();
			this._InitYiJieEffect();
			this.UpdateYiJieChallengeTimes();
			Singleton<GameStatisticManager>.instance.DoStatLevelChoose(StatLevelChooseType.ENTER_SELECT, ChapterSelectFrame.sSceneID, 0, 0, null);
			this.HideSomething();
		}

		// Token: 0x0600D3ED RID: 54253 RVA: 0x0034C208 File Offset: 0x0034A608
		private void UpdateYiJieChallengeTimes()
		{
			int dungeonId = 0;
			ChaptertDungeonUnit[] chapterList = this.mCurrent.GetData().chapterList;
			if (chapterList != null && chapterList.Length > 0)
			{
				dungeonId = chapterList[0].dungeonID;
			}
			if (this._GetChapterIndex() != 31)
			{
				return;
			}
			if (this.yijieChallengeNumRoot == null)
			{
				return;
			}
			int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(dungeonId);
			this.yijieChallengeNumRoot.CustomActive(true);
			if (this.yijieChallengeNumInfo != null)
			{
				int num = this._getLeftTimes();
				this.yijieChallengeNumInfo.text = string.Format(TR.Value("resist_magic_challenge_times"), num, dungeonDailyBaseTimes);
			}
		}

		// Token: 0x0600D3EE RID: 54254 RVA: 0x0034C2B4 File Offset: 0x0034A6B4
		private int _getLeftTimes()
		{
			int dungeonId = 0;
			ChaptertDungeonUnit[] chapterList = this.mCurrent.GetData().chapterList;
			if (chapterList != null && chapterList.Length > 0)
			{
				dungeonId = chapterList[0].dungeonID;
			}
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(dungeonId);
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(dungeonId);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600D3EF RID: 54255 RVA: 0x0034C30C File Offset: 0x0034A70C
		private void _InitYiJieEffect()
		{
			if (this._GetChapterIndex() != 31)
			{
				return;
			}
			if (this.bInitEffect)
			{
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(75, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (!global::Utility.IsUnLockArea(tableItem.AreaID))
			{
				return;
			}
			this.YiJieEffectObj = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Yijie/Prefab/Eff_UI_YiJie", true, 0U);
			if (this.YiJieEffectObj != null)
			{
				global::Utility.AttachTo(this.YiJieEffectObj, this.mEffectRoot, false);
				this.bInitEffect = true;
			}
		}

		// Token: 0x0600D3F0 RID: 54256 RVA: 0x0034C3A4 File Offset: 0x0034A7A4
		private void _InitBgImage()
		{
			this.mChapterNameImage.CustomActive(this._GetChapterIndex() != 31);
			this.mTitleBg.CustomActive(this._GetChapterIndex() != 31);
			this.mChapter.CustomActive(this._GetChapterIndex() != 31);
			this.mYijieTitleBg.CustomActive(this._GetChapterIndex() == 31);
		}

		// Token: 0x0600D3F1 RID: 54257 RVA: 0x0034C410 File Offset: 0x0034A810
		private void _InitExchangeShopRoot()
		{
			this.mExchangeShopRoot.CustomActive(false);
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(ChapterSelectFrame.sSceneID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.ExchangeStoreEntrance != string.Empty)
			{
				string[] array = tableItem.ExchangeStoreEntrance.Split(new char[]
				{
					'|'
				});
				if (array.Length == 3)
				{
					bool bActive = int.Parse(array[0]) == 1;
					int iShopID = int.Parse(array[1]);
					string path = array[2];
					this.mExchangeShopRoot.CustomActive(bActive);
					ComCommonBind component = this.mExchangeShopRoot.GetComponent<ComCommonBind>();
					Image com = component.GetCom<Image>("Icon");
					Button com2 = component.GetCom<Button>("ExchangeShop");
					Text com3 = component.GetCom<Text>("text");
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						this.OnShopButtonClick(iShopID);
					});
					if (com != null)
					{
						ETCImageLoader.LoadSprite(ref com, path, true);
					}
					this.InitShopName(iShopID, ref com3);
				}
			}
		}

		// Token: 0x0600D3F2 RID: 54258 RVA: 0x0034C538 File Offset: 0x0034A938
		private void InitShopName(int shopId, ref Text nameText)
		{
			if (nameText != null && shopId == 23)
			{
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					nameText.text = tableItem.ShopName;
				}
			}
		}

		// Token: 0x0600D3F3 RID: 54259 RVA: 0x0034C583 File Offset: 0x0034A983
		private void OnShopButtonClick(int shopId)
		{
			if (shopId == 23)
			{
				DataManager<ShopNewDataManager>.GetInstance().JumpToShopById(shopId);
			}
			else
			{
				DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(24, shopId, 0, -1);
			}
		}

		// Token: 0x0600D3F4 RID: 54260 RVA: 0x0034C5AC File Offset: 0x0034A9AC
		private void _onUpdateMission(uint taskID)
		{
			this._updateRewardRedPoint();
		}

		// Token: 0x0600D3F5 RID: 54261 RVA: 0x0034C5B4 File Offset: 0x0034A9B4
		private void _updateTipsPoint()
		{
			string prefabPath = this.mBind.GetPrefabPath("pointunit");
			this.mBind.ClearCacheBinds(prefabPath);
			for (int i = 0; i < ChapterSelectFrame.sNodes.Count; i++)
			{
				if (this._isUnlockChapter(i))
				{
					ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
					if (null != comCommonBind)
					{
						global::Utility.AttachTo(comCommonBind.gameObject, this.mPointRoot, false);
						Toggle com = comCommonBind.GetCom<Toggle>("select");
						com.group = this.mPointRootGroup;
						com.isOn = (ChapterSelectFrame.selectChapterIdx == i);
					}
				}
			}
		}

		// Token: 0x0600D3F6 RID: 54262 RVA: 0x0034C658 File Offset: 0x0034AA58
		private void _updateUnlockChapter()
		{
			List<DungeonHardInfo> allHardInfo = DataManager<BattleDataManager>.GetInstance().ChapterInfo.allHardInfo;
			ChaptertDungeonUnit[] chapterList = this.mCurrent.GetData().chapterList;
			this.mCurrent.unlockCount = 0;
			DungeonID dungeonID = new DungeonID(0);
			for (int i = 0; i < chapterList.Length; i++)
			{
				ChaptertDungeonUnit chaptertDungeonUnit = chapterList[i];
				dungeonID.dungeonID = ChapterUtility.GetReadyDungeonID(chaptertDungeonUnit.dungeonID, 0);
				ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID.dungeonID);
				if (dungeonID.prestoryID > 0)
				{
					this.mToggleGameUnitList[i].SetDungeonType(ComChapterDungeonUnit.eDungeonType.Prestory);
				}
				else
				{
					this.mToggleGameUnitList[i].SetDungeonType(ComChapterDungeonUnit.eDungeonType.Normal);
				}
				this.mToggleGameUnitList[i].SetDungeonID(chaptertDungeonUnit.dungeonID);
				this.mToggleGameUnitList[i].SetState(dungeonState);
				if (dungeonState == ComChapterDungeonUnit.eState.Locked)
				{
					if (TeamUtility.IsEliteDungeonID(chaptertDungeonUnit.dungeonID))
					{
						this.mToggleGameUnitList[i].ShowDungeonLvLimit(false);
						this.mToggleGameUnitList[i].SetExtarLockTipText(TR.Value("elite_dungeon_unlock_tip"));
					}
					else
					{
						this.mToggleGameUnitList[i].ShowDungeonLvLimit(true);
						this.mToggleGameUnitList[i].SetExtarLockTipText(string.Empty);
					}
				}
				else
				{
					this.mToggleGameUnitList[i].ShowDungeonLvLimit(true);
					this.mToggleGameUnitList[i].SetExtarLockTipText(string.Empty);
				}
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID.dungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.mToggleGameUnitList[i].SetBackgroud(tableItem.TumbPath);
					this.mToggleGameUnitList[i].SetCharactorSprite(tableItem.TumbChPath);
				}
				else
				{
					DungeonTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(chaptertDungeonUnit.dungeonID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						this.mToggleGameUnitList[i].SetBackgroud(tableItem2.TumbPath);
						this.mToggleGameUnitList[i].SetCharactorSprite(tableItem2.TumbChPath);
					}
				}
			}
		}

		// Token: 0x0600D3F7 RID: 54263 RVA: 0x0034C845 File Offset: 0x0034AC45
		public static bool IsInChallenge(int dungeonID)
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(string.Format("dp_{0}", dungeonID)) > 0;
		}

		// Token: 0x0600D3F8 RID: 54264 RVA: 0x0034C864 File Offset: 0x0034AC64
		private void _updateMissionStatus()
		{
			for (int i = 0; i < this.mCurrent.GetData().chapterList.Length; i++)
			{
				int dungeonID = this.mCurrent.GetData().chapterList[i].dungeonID;
				int readyDungeonID = ChapterUtility.GetReadyDungeonID(dungeonID, 0);
				if (this._GetChapterIndex() == 31)
				{
					this.mToggleGameUnitList[i].SetIsChallenging(ChapterSelectFrame.IsInChallenge(dungeonID));
				}
				else
				{
					this.mToggleGameUnitList[i].SetIsChallenging(false);
				}
				this.mToggleGameUnitList[i].SetDungeonID(dungeonID);
				if (TeamUtility.IsEliteDungeonID(dungeonID))
				{
					this.mToggleGameUnitList[i].ShowEliteBg(true);
				}
				else
				{
					this.mToggleGameUnitList[i].ShowEliteBg(false);
				}
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(readyDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.mToggleGameUnitList[i].SetName(tableItem.Name, tableItem.RecommendLevel);
					this.mToggleGameUnitList[i].SetType(ComChapterDungeonUnit.eMissionType.None);
					if (ChapterUtility.HasMissionByDungeonID(readyDungeonID))
					{
						this.mToggleGameUnitList[i].SetType(ComChapterDungeonUnit.eMissionType.Main);
					}
				}
				else
				{
					DungeonTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						this.mToggleGameUnitList[i].SetName(tableItem2.Name, tableItem2.RecommendLevel);
					}
					else
					{
						this.mToggleGameUnitList[i].SetName(string.Empty, string.Empty);
					}
				}
			}
		}

		// Token: 0x0600D3F9 RID: 54265 RVA: 0x0034C9D8 File Offset: 0x0034ADD8
		private void _loadChapterData(DChapterData data)
		{
			if (null == data)
			{
				return;
			}
			Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(data.backgroundPath, typeof(Sprite), true, 0U).obj as Sprite;
			this.mLeftBackground.enabled = false;
			if (sprite != null)
			{
				this.mLeftBackground.enabled = true;
				ETCImageLoader.LoadSprite(ref this.mLeftBackground, data.backgroundPath, true);
			}
			Sprite sprite2 = null;
			if (!string.IsNullOrEmpty(data.middlegroudnPath))
			{
				sprite2 = (Singleton<AssetLoader>.instance.LoadRes(data.middlegroudnPath, typeof(Sprite), true, 0U).obj as Sprite);
			}
			this.mLeftMid.enabled = false;
			if (sprite2 != null)
			{
				this.mLeftMid.enabled = true;
				ETCImageLoader.LoadSprite(ref this.mLeftMid, data.middlegroudnPath, true);
				this.mLeftMid.SetNativeSize();
				this.mLeftMid.GetComponent<RectTransform>().localPosition = data.middlePos;
			}
			this.mChapterName.text = data.name;
			ETCImageLoader.LoadSprite(ref this.mChapterNameImage, data.namePath, true);
			this.mChapterNameImage.SetNativeSize();
			this.mChapterIndex.text = data.nameNumberIdx.ToString();
			int num = this._getMaxUnlockDungeonIndex(data);
			for (int i = 0; i < data.chapterList.Length; i++)
			{
				GameObject gameObject = this.mToggleGameUnitList[i].gameObject;
				ChaptertDungeonUnit chaptertDungeonUnit = data.chapterList[i];
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				RectTransform com = component.GetCom<RectTransform>("sourcePosition");
				RectTransform com2 = component.GetCom<RectTransform>("targetPosition");
				TriangleGraph com3 = component.GetCom<TriangleGraph>("angleGraph");
				RectTransform com4 = component.GetCom<RectTransform>("thumbRoot");
				RectTransform com5 = component.GetCom<RectTransform>("targetRightPosition");
				Toggle toggle = this.mToggleList[i];
				gameObject.transform.localPosition = data.chapterList[i].position;
				com.localPosition = data.chapterList[i].angleSourcePosition;
				com2.localPosition = data.chapterList[i].angleTargetPosition;
				com5.localPosition = data.chapterList[i].angleTargetRightPosition;
				com4.localPosition = data.chapterList[i].thumbOffset;
				toggle.group = this.mToggleGroup;
				if (this.mCurrent.index < 0)
				{
					toggle.isOn = (num == i);
				}
				else
				{
					toggle.isOn = (this.mCurrent.index == i);
				}
				int idx = i;
				toggle.onValueChanged.AddListener(delegate(bool value)
				{
					this._onSelected(idx, value);
				});
				Text com6 = component.GetCom<Text>("Times");
				if (ChapterSelectFrame.sSceneID == this.mAnniversaryPartySceneID)
				{
					com6.CustomActive(true);
					this.UpdateLevelChallengeTimes(data.chapterList[i].dungeonID, com6);
				}
				else
				{
					com6.CustomActive(false);
				}
			}
		}

		// Token: 0x0600D3FA RID: 54266 RVA: 0x0034CCE4 File Offset: 0x0034B0E4
		private void UpdateLevelChallengeTimes(int dungeonId, Text timeTxt)
		{
			int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(dungeonId);
			if (timeTxt != null)
			{
				if (dungeonDailyBaseTimes <= 0)
				{
					timeTxt.CustomActive(false);
				}
				int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(dungeonId);
				int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(dungeonId);
				int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
				if (num < 0)
				{
					num = 0;
				}
				timeTxt.text = string.Format(TR.Value("AnniversaryParty_Times"), num, dungeonDailyBaseTimes);
			}
		}

		// Token: 0x0600D3FB RID: 54267 RVA: 0x0034CD50 File Offset: 0x0034B150
		private int _getMaxUnlockDungeonIndex(DChapterData data)
		{
			int result = 0;
			for (int i = 0; i < data.chapterList.Length; i++)
			{
				int dungeonID2Enter = ChapterUtility.GetDungeonID2Enter(data.chapterList[i].dungeonID);
				if (ChapterUtility.GetDungeonCanEnter(dungeonID2Enter, false, true, true))
				{
					result = i;
				}
			}
			return result;
		}

		// Token: 0x0600D3FC RID: 54268 RVA: 0x0034CD9C File Offset: 0x0034B19C
		private void _autoOpenFrame()
		{
			this._onEnterButton();
		}

		// Token: 0x0600D3FD RID: 54269 RVA: 0x0034CDA4 File Offset: 0x0034B1A4
		private IEnumerator _onSelectNextToggle(bool isLeft)
		{
			int len = this.mCurrent.GetData().chapterList.Length;
			int idx = this.mCurrent.index;
			if (isLeft)
			{
				idx--;
			}
			else
			{
				idx++;
			}
			idx = Mathf.Clamp(idx, 0, len - 1);
			if (idx == this.mCurrent.index)
			{
				yield break;
			}
			int readyId = ChapterUtility.GetReadyDungeonID(this.mCurrent.GetData().chapterList[idx].dungeonID, 0);
			if (ChapterUtility.GetDungeonState(readyId) == ComChapterDungeonUnit.eState.Locked)
			{
				yield break;
			}
			ChapterNormalHalfFrame normalHalfFrame = this.frameMgr.GetFrame(typeof(ChapterNormalHalfFrame)) as ChapterNormalHalfFrame;
			normalHalfFrame.SetMask(true);
			while (this.mAnimateState != ChapterSelectFrame.eAnimateState.onNone)
			{
				yield return null;
			}
			this.mToggleList[idx].isOn = true;
			while (this.mAnimateState != ChapterSelectFrame.eAnimateState.onNone)
			{
				yield return null;
			}
			normalHalfFrame.SetMask(false);
			if (this.frameMgr.IsFrameOpen<ChapterNormalHalfFrame>(null))
			{
				this.frameMgr.CloseFrame<ChapterNormalHalfFrame>(null, false);
			}
			this.frameMgr.OpenFrame<ChapterNormalHalfFrame>(FrameLayer.Middle, null, string.Empty);
			yield break;
		}

		// Token: 0x0600D3FE RID: 54270 RVA: 0x0034CDC6 File Offset: 0x0034B1C6
		public int _GetChapterIndex()
		{
			return this.mCurrent.GetData().nameNumberIdx;
		}

		// Token: 0x0600D3FF RID: 54271 RVA: 0x0034CDD8 File Offset: 0x0034B1D8
		public bool IsCanSelectLeftDungeon()
		{
			return this._isCanSelectDungeon(true);
		}

		// Token: 0x0600D400 RID: 54272 RVA: 0x0034CDE1 File Offset: 0x0034B1E1
		public bool IsCanSelectRightDungeon()
		{
			return this._isCanSelectDungeon(false);
		}

		// Token: 0x0600D401 RID: 54273 RVA: 0x0034CDEC File Offset: 0x0034B1EC
		private bool _isCanSelectDungeon(bool isLeft)
		{
			int num = this.mCurrent.GetData().chapterList.Length;
			int num2 = this.mCurrent.index;
			if (isLeft)
			{
				num2--;
			}
			else
			{
				num2++;
			}
			if (num2 < 0 || num2 >= num)
			{
				return false;
			}
			int readyDungeonID = ChapterUtility.GetReadyDungeonID(this.mCurrent.GetData().chapterList[num2].dungeonID, 0);
			return ComChapterDungeonUnit.eState.Locked != ChapterUtility.GetDungeonState(readyDungeonID);
		}

		// Token: 0x0600D402 RID: 54274 RVA: 0x0034CE68 File Offset: 0x0034B268
		private void _onSelectNextToggle(UIEvent ui)
		{
			bool isLeft = (bool)ui.Param1;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onSelectNextToggle(isLeft));
		}

		// Token: 0x0600D403 RID: 54275 RVA: 0x0034CE93 File Offset: 0x0034B293
		private void _OnSelectEnterDungeon(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1 != null && uiEvent.Param1 is int)
			{
				this._onSelected((int)uiEvent.Param1, true);
			}
		}

		// Token: 0x0600D404 RID: 54276 RVA: 0x0034CEC8 File Offset: 0x0034B2C8
		private void _OnSceneChanged(UIEvent uiEvent)
		{
			if (uiEvent.EventParams.CurrentSceneID != ChapterSelectFrame.sSceneID)
			{
				this.frameMgr.CloseFrame<ChapterSelectFrame>(this, false);
				this.mEnterWay = ChapterSelectFrame.eEnterWay.onNone;
			}
		}

		// Token: 0x0600D405 RID: 54277 RVA: 0x0034CEF4 File Offset: 0x0034B2F4
		private void _onBind()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChapterNextDungeon, new ClientEventSystem.UIEventHandler(this._onSelectNextToggle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChapterNormalHalfFrameOpen, new ClientEventSystem.UIEventHandler(this._onChapterNormalHalfOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChapterNormalHalfFrameClose, new ClientEventSystem.UIEventHandler(this._onChapterNormalHalfClose));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SelectEnterDungeon, new ClientEventSystem.UIEventHandler(this._OnSelectEnterDungeon));
		}

		// Token: 0x0600D406 RID: 54278 RVA: 0x0034CFD8 File Offset: 0x0034B3D8
		private void _onUnbind()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChapterNextDungeon, new ClientEventSystem.UIEventHandler(this._onSelectNextToggle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChapterNormalHalfFrameOpen, new ClientEventSystem.UIEventHandler(this._onChapterNormalHalfOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChapterNormalHalfFrameClose, new ClientEventSystem.UIEventHandler(this._onChapterNormalHalfClose));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RemoveSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SelectEnterDungeon, new ClientEventSystem.UIEventHandler(this._OnSelectEnterDungeon));
		}

		// Token: 0x0600D407 RID: 54279 RVA: 0x0034D0BC File Offset: 0x0034B4BC
		private void _onChapterNormalHalfOpen(UIEvent ui)
		{
		}

		// Token: 0x0600D408 RID: 54280 RVA: 0x0034D0C0 File Offset: 0x0034B4C0
		private void _onChapterNormalHalfClose(UIEvent ui)
		{
			if (this.mAnimateState != ChapterSelectFrame.eAnimateState.onBackAnimate)
			{
				if (this.mRevertAnimate != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mRevertAnimate);
					this.mRevertAnimate = null;
				}
				this.mRevertAnimate = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._revertAnimate());
			}
			if (this._GetChapterIndex() == 31 && this.YiJieEffectObj != null)
			{
				this.YiJieEffectObj.CustomActive(true);
			}
		}

		// Token: 0x0600D409 RID: 54281 RVA: 0x0034D13C File Offset: 0x0034B53C
		private IEnumerator _revertAnimate()
		{
			while (this.mAnimateState != ChapterSelectFrame.eAnimateState.onNone)
			{
				yield return null;
			}
			this.mAnimateState = ChapterSelectFrame.eAnimateState.onBackAnimate;
			yield return this.mChapterSelectAnimate.RevertAnimate();
			this.mAnimateState = ChapterSelectFrame.eAnimateState.onNone;
			yield break;
		}

		// Token: 0x0600D40A RID: 54282 RVA: 0x0034D158 File Offset: 0x0034B558
		private void _clearAll()
		{
			int i = 0;
			int num = this.mToggleList.Length;
			while (i < num)
			{
				Toggle toggle = this.mToggleList[i];
				if (null != toggle)
				{
					toggle.onValueChanged.RemoveAllListeners();
				}
				i++;
			}
			for (int j = 0; j < this.mToggleGameUnitList.Length; j++)
			{
				if (this.mToggleGameUnitList[j] != null)
				{
					this.mToggleGameUnitList[j].SetCharactorSprite(null);
					this.mToggleGameUnitList[j].SetBackgroud(null);
					Object.Destroy(this.mToggleGameUnitList[j].gameObject);
					this.mToggleGameUnitList[j] = null;
				}
			}
			this.mBisFlag = false;
			this.data = null;
		}

		// Token: 0x0600D40B RID: 54283 RVA: 0x0034D214 File Offset: 0x0034B614
		private DungeonTable _getDungeonTable(int id)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem;
			}
			Logger.LogErrorFormat("can't find item with id {0} in DungeonTable", new object[]
			{
				id
			});
			return null;
		}

		// Token: 0x0600D40C RID: 54284 RVA: 0x0034D25C File Offset: 0x0034B65C
		private void _onSelected(int id, bool bstate)
		{
			if (this.mAnimateState == ChapterSelectFrame.eAnimateState.onSelectAnimate)
			{
				return;
			}
			if (this.YiJieEffectObj != null)
			{
				this.YiJieEffectObj.CustomActive(false);
			}
			this.mCurrent.index = -1;
			if (this.mSetRewardBtCD != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mSetRewardBtCD);
			}
			this.mSetRewardBtCD = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._setRewardBtCD());
			if (bstate)
			{
				this.mCurrent.index = id;
				if (ChapterSelectFrame.sDungeonID <= 0 || (this.mEnterWay == ChapterSelectFrame.eEnterWay.onGuide && ChapterSelectFrame.sDungeonID > 0))
				{
					DungeonID dungeonID = new DungeonID(ChapterSelectFrame.sDungeonID);
					int readyDungeonID = ChapterUtility.GetReadyDungeonID(this.mCurrent.CurrentDungeonID(), 0);
					if (dungeonID != null && dungeonID.dungeonIDWithOutDiff != readyDungeonID)
					{
						ChapterSelectFrame.sDungeonID = ChapterUtility.GetReadyDungeonID(this.mCurrent.CurrentDungeonID(), 0);
					}
				}
				if (this.mDelayOpen != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mDelayOpen);
				}
				this.mEnterWay = ChapterSelectFrame.eEnterWay.onClick;
				this.mDelayOpen = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._delayOpenButton(id));
			}
		}

		// Token: 0x0600D40D RID: 54285 RVA: 0x0034D384 File Offset: 0x0034B784
		private IEnumerator _setRewardBtCD()
		{
			if (this.mReward != null)
			{
				this.mReward.interactable = false;
			}
			yield return new WaitForSeconds(2f);
			if (this.mReward != null)
			{
				this.mReward.interactable = true;
			}
			yield break;
		}

		// Token: 0x0600D40E RID: 54286 RVA: 0x0034D3A0 File Offset: 0x0034B7A0
		private IEnumerator _delayOpenButton(int idx)
		{
			if (ChapterSelectFrame.sDungeonID > 0 && this._canEnterDungeonByID(ChapterSelectFrame.sDungeonID))
			{
				while (this.mAnimateState != ChapterSelectFrame.eAnimateState.onNone)
				{
					yield return null;
				}
				this.mAnimateState = ChapterSelectFrame.eAnimateState.onSelectAnimate;
				yield return this.mChapterSelectAnimate.NormalAnimate(this.mToggleGameUnitList[idx].rectTransform());
				this.mAnimateState = ChapterSelectFrame.eAnimateState.onNone;
			}
			this._onEnterButton();
			yield break;
		}

		// Token: 0x0600D40F RID: 54287 RVA: 0x0034D3C4 File Offset: 0x0034B7C4
		private bool _canEnterDungeonByID(int dungeonID)
		{
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			return ChapterUtility.GetDungeonState(dungeonID2.dungeonIDWithOutDiff) != ComChapterDungeonUnit.eState.Locked;
		}

		// Token: 0x0600D410 RID: 54288 RVA: 0x0034D3EC File Offset: 0x0034B7EC
		private void _onEnterButton()
		{
			if (ChapterSelectFrame.sDungeonID > 0)
			{
				if (ChapterSelectFrame.sDungeonID == 999999)
				{
					this._onDungeonReward();
					ChapterSelectFrame.sDungeonID = -1;
					return;
				}
				DungeonID dungeonID = new DungeonID(ChapterSelectFrame.sDungeonID);
				this.mCurrent.UpdateIndex(dungeonID.dungeonIDWithOutPrestory);
				int num = this.mCurrent.CurrentDungeonID();
				num = ChapterUtility.GetReadyDungeonID(num, 0);
				if (num > 0 && this._canEnterDungeonByID(num) && this.mEnterWay == ChapterSelectFrame.eEnterWay.onClick)
				{
					this._openFrame(ChapterSelectFrame.sDungeonID);
				}
				else
				{
					Logger.LogErrorFormat("[ChapterNode] 妄图打开为未解锁关卡 {0}, PS: 肯定是任务的解锁和关卡的解锁不匹配，原因有2\n1. 使用不当的GM命令解锁r任务，但是对应副本么有解锁\n2.新加的主线任务在老的账号中突然出现！！", new object[]
					{
						ChapterSelectFrame.sDungeonID
					});
				}
				ChapterSelectFrame.sDungeonID = -1;
			}
		}

		// Token: 0x0600D411 RID: 54289 RVA: 0x0034D4A2 File Offset: 0x0034B8A2
		private void _openFrame(int dungeonID)
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterSelectFrame>(null))
			{
				ChapterBaseFrame.sDungeonID = dungeonID;
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterNormalHalfFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600D412 RID: 54290 RVA: 0x0034D4CC File Offset: 0x0034B8CC
		private void _closeFrame()
		{
			if (ChapterSelectFrame.sSceneID == this.mAnniversaryPartySceneID || ChapterSelectFrame.sSceneID == this.mSpringFestivalSceneID)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChapterSelectFrame>(null, false);
			}
			else
			{
				if (ChapterSelectFrame.sSceneID < 0)
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<ChapterSelectFrame>(this, false);
					return;
				}
				ChapterSelectFrame.sDungeonID = -1;
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null)
				{
					clientSystemTown.ReturnToTown();
				}
				else
				{
					Logger.LogError("Current System is not Town!!!");
				}
			}
		}

		// Token: 0x0600D413 RID: 54291 RVA: 0x0034D554 File Offset: 0x0034B954
		private bool _isUnlockChapter(int chapterIdx)
		{
			if (chapterIdx >= 0 && chapterIdx < ChapterSelectFrame.sNodes.Count && ChapterSelectFrame.sNodes[chapterIdx].dungeonIDs.Count > 0)
			{
				int readyDungeonID = ChapterUtility.GetReadyDungeonID(ChapterSelectFrame.sNodes[chapterIdx].dungeonIDs[0], 0);
				return ChapterUtility.GetDungeonCanEnter(readyDungeonID, false, true, true);
			}
			return false;
		}

		// Token: 0x0600D414 RID: 54292 RVA: 0x0034D5BB File Offset: 0x0034B9BB
		private void _updateSelectButton()
		{
			this.mLeftButton.gameObject.SetActive(this._isUnlockChapter(ChapterSelectFrame.selectChapterIdx - 1));
			this.mRightButton.gameObject.SetActive(this._isUnlockChapter(ChapterSelectFrame.selectChapterIdx + 1));
		}

		// Token: 0x0600D415 RID: 54293 RVA: 0x0034D5F8 File Offset: 0x0034B9F8
		private IEnumerator _reloadChapter()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterNormalHalfFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<ChapterNormalHalfFrame>(null, false);
			}
			this._onUnbind();
			this._clearAll();
			this._OnLoadPrefabFinish();
			this._OnOpenFrame();
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600D416 RID: 54294 RVA: 0x0034D613 File Offset: 0x0034BA13
		private void _changeChapter(int val)
		{
			ChapterSelectFrame.selectChapterIdx = val;
			if (val == ChapterSelectFrame.selectChapterIdx)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._reloadChapter());
			}
		}

		// Token: 0x0600D417 RID: 54295 RVA: 0x0034D637 File Offset: 0x0034BA37
		private void _onLeft()
		{
			this._changeChapter(ChapterSelectFrame.selectChapterIdx - 1);
		}

		// Token: 0x0600D418 RID: 54296 RVA: 0x0034D646 File Offset: 0x0034BA46
		private void _onRight()
		{
			this._changeChapter(ChapterSelectFrame.selectChapterIdx + 1);
		}

		// Token: 0x0600D419 RID: 54297 RVA: 0x0034D658 File Offset: 0x0034BA58
		private void _onDungeonReward()
		{
			if (ChapterSelectFrame.IsCurrentSelectChapterShowReward())
			{
				int currentSelectChapter = ChapterSelectFrame.GetCurrentSelectChapter();
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterRewardFrame>(FrameLayer.Middle, currentSelectChapter, string.Empty);
			}
		}

		// Token: 0x0600D41A RID: 54298 RVA: 0x0034D68C File Offset: 0x0034BA8C
		private void _InitFatigueCombustionGameObject(GameObject mFatigueCombustionRoot)
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.FindFatigueCombustionActivityIsOpen(ref this.mBisFlag, ref this.data);
			if (this.mBisFlag && this.data != null)
			{
				mFatigueCombustionRoot.CustomActive(true);
				this._InitFatigueCombustionInfo(mFatigueCombustionRoot, this.data);
			}
			else
			{
				mFatigueCombustionRoot.CustomActive(false);
			}
		}

		// Token: 0x0600D41B RID: 54299 RVA: 0x0034D6EC File Offset: 0x0034BAEC
		private void _InitFatigueCombustionInfo(GameObject go, ActivityLimitTimeData activityData)
		{
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			uint activityId = activityData.DataId;
			Text com = component.GetCom<Text>("Time");
			Button com2 = component.GetCom<Button>("Open");
			Button com3 = component.GetCom<Button>("Stop");
			GameObject gameObject = component.GetGameObject("OrdinaryName");
			GameObject gameObject2 = component.GetGameObject("SeniorName");
			SetButtonGrayCD mCDGray = component.GetCom<SetButtonGrayCD>("CDGray");
			gameObject.CustomActive(false);
			gameObject2.CustomActive(false);
			for (int i = 0; i < activityData.activityDetailDataList.Count; i++)
			{
				if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Init && activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.UnFinish)
				{
					this.mData = activityData.activityDetailDataList[i];
					uint mTaskId = this.mData.DataId;
					string text = mTaskId.ToString();
					string s = text.Substring(text.Length - 1);
					int num = 0;
					if (int.TryParse(s, out num))
					{
						if (num == 1)
						{
							gameObject.CustomActive(true);
							gameObject2.CustomActive(false);
						}
						else
						{
							gameObject2.CustomActive(true);
							gameObject.CustomActive(false);
						}
					}
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					com3.onClick.RemoveAllListeners();
					com3.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					this._UpdateFatigueCombustionData(go, this.mData);
					if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Failed)
					{
						return;
					}
				}
			}
		}

		// Token: 0x0600D41C RID: 54300 RVA: 0x0034D8DC File Offset: 0x0034BCDC
		private void _UpdateFatigueCombustionData(GameObject go, ActivityLimitTimeDetailData activityData)
		{
			if (go == null || activityData == null)
			{
				return;
			}
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mTime = component.GetCom<Text>("Time");
			Button com = component.GetCom<Button>("Open");
			Button com2 = component.GetCom<Button>("Stop");
			com.CustomActive(false);
			com2.CustomActive(false);
			this.mFatigueCombustionTimeIsOpen = false;
			switch (activityData.ActivityDetailState)
			{
			case ActivityTaskState.Init:
			case ActivityTaskState.UnFinish:
				com.CustomActive(true);
				this.mTime.text = Function.GetLastsTimeStr((double)this.mData.DoneNum);
				break;
			case ActivityTaskState.Finished:
				com2.CustomActive(true);
				this.mFatigueCombustionTimeIsOpen = true;
				this.mFatigueCombustionTime = this.mData.DoneNum;
				break;
			case ActivityTaskState.Failed:
				this.mTime.text = Function.GetLastsTimeStr((double)this.mData.DoneNum);
				com.CustomActive(true);
				break;
			}
		}

		// Token: 0x0600D41D RID: 54301 RVA: 0x0034D9E4 File Offset: 0x0034BDE4
		private void _SetFatigueCombustionTime()
		{
			if (this.mFatigueCombustionTimeIsOpen && this.mTime != null)
			{
				if (this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
				{
					this.mTime.text = Function.GetLastsTimeStr((double)(this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime()));
				}
				else
				{
					this.mFatigueCombustionRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x0600D41E RID: 54302 RVA: 0x0034DA57 File Offset: 0x0034BE57
		private void _OnTaskChange()
		{
		}

		// Token: 0x0600D41F RID: 54303 RVA: 0x0034DA5C File Offset: 0x0034BE5C
		private void HideSomething()
		{
			if (ChapterSelectFrame.sSceneID == this.mAnniversaryPartySceneID)
			{
				this.mReward.CustomActive(false);
				this.mChapterIndexParentGo.CustomActive(false);
			}
			else if (ChapterSelectFrame.sSceneID == this.mSpringFestivalSceneID)
			{
				this.mChapterIndexParentGo.CustomActive(false);
				this.mRedPoint.CustomActive(false);
			}
		}

		// Token: 0x04007C2B RID: 31787
		private ChapterSelectFrame.eAnimateState mAnimateState;

		// Token: 0x04007C2C RID: 31788
		private bool mBisFlag;

		// Token: 0x04007C2D RID: 31789
		private ActivityLimitTimeData data;

		// Token: 0x04007C2E RID: 31790
		private ActivityLimitTimeDetailData mData;

		// Token: 0x04007C2F RID: 31791
		private bool mFatigueCombustionTimeIsOpen;

		// Token: 0x04007C30 RID: 31792
		private Text mTime;

		// Token: 0x04007C31 RID: 31793
		private int mFatigueCombustionTime = -1;

		// Token: 0x04007C32 RID: 31794
		private GameObject YiJieEffectObj;

		// Token: 0x04007C33 RID: 31795
		private bool bInitEffect;

		// Token: 0x04007C34 RID: 31796
		private int mAnniversaryPartySceneID = 6038;

		// Token: 0x04007C35 RID: 31797
		private int mSpringFestivalSceneID = 6039;

		// Token: 0x04007C36 RID: 31798
		private static List<ChapterSelectFrame.Node> sNodes = new List<ChapterSelectFrame.Node>();

		// Token: 0x04007C37 RID: 31799
		public static int sSceneID = -1;

		// Token: 0x04007C38 RID: 31800
		private ChapterSelectFrame.ChapterNode mCurrent = new ChapterSelectFrame.ChapterNode();

		// Token: 0x04007C39 RID: 31801
		private static int mSelectChapterIdx = 0;

		// Token: 0x04007C3A RID: 31802
		private static int sDungeonID = -1;

		// Token: 0x04007C3B RID: 31803
		private static DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x04007C3C RID: 31804
		private bool mIsFindMission;

		// Token: 0x04007C3D RID: 31805
		private Toggle[] mToggleList = new Toggle[0];

		// Token: 0x04007C3E RID: 31806
		private ComChapterDungeonUnit[] mToggleGameUnitList;

		// Token: 0x04007C3F RID: 31807
		private ComChapterSelectUnlock mSelectUnlock;

		// Token: 0x04007C40 RID: 31808
		private ToggleGroup mToggleGroup;

		// Token: 0x04007C41 RID: 31809
		private Image mLeftBackground;

		// Token: 0x04007C42 RID: 31810
		private Image mLeftMid;

		// Token: 0x04007C43 RID: 31811
		private RectTransform mRRecttransform;

		// Token: 0x04007C44 RID: 31812
		private GameObject mRewardRedPoint;

		// Token: 0x04007C45 RID: 31813
		private UIGray mLeftButton;

		// Token: 0x04007C46 RID: 31814
		private UIGray mRightButton;

		// Token: 0x04007C47 RID: 31815
		private Button mClose;

		// Token: 0x04007C48 RID: 31816
		private Button mReward;

		// Token: 0x04007C49 RID: 31817
		private Button mSelectLeft;

		// Token: 0x04007C4A RID: 31818
		private Button mSelectRight;

		// Token: 0x04007C4B RID: 31819
		private GameObject mUnitRoot;

		// Token: 0x04007C4C RID: 31820
		private Text mChapterName;

		// Token: 0x04007C4D RID: 31821
		private Image mChapterNameImage;

		// Token: 0x04007C4E RID: 31822
		private Text mChapterIndex;

		// Token: 0x04007C4F RID: 31823
		private GameObject mPointRoot;

		// Token: 0x04007C50 RID: 31824
		private ToggleGroup mPointRootGroup;

		// Token: 0x04007C51 RID: 31825
		private GameObject mLeftRed;

		// Token: 0x04007C52 RID: 31826
		private GameObject mRightRed;

		// Token: 0x04007C53 RID: 31827
		private GameObject mNodeRoot;

		// Token: 0x04007C54 RID: 31828
		private ComChapterSelectAnimate mChapterSelectAnimate;

		// Token: 0x04007C55 RID: 31829
		private Text mChapterRewardCount;

		// Token: 0x04007C56 RID: 31830
		private Text mChapterRewardSum;

		// Token: 0x04007C57 RID: 31831
		private GameObject mRedPoint;

		// Token: 0x04007C58 RID: 31832
		private Text mRedPointSum;

		// Token: 0x04007C59 RID: 31833
		private GameObject mRewardComplete;

		// Token: 0x04007C5A RID: 31834
		private GameObject mFatigueCombustionRoot;

		// Token: 0x04007C5B RID: 31835
		private DOTweenAnimation mRewardAnimation;

		// Token: 0x04007C5C RID: 31836
		private GameObject mExchangeShopRoot;

		// Token: 0x04007C5D RID: 31837
		private GameObject mEffectRoot;

		// Token: 0x04007C5E RID: 31838
		private GameObject mTitleBg;

		// Token: 0x04007C5F RID: 31839
		private GameObject mChapter;

		// Token: 0x04007C60 RID: 31840
		private GameObject mYijieTitleBg;

		// Token: 0x04007C61 RID: 31841
		private GameObject yijieChallengeNumRoot;

		// Token: 0x04007C62 RID: 31842
		private Text yijieChallengeNumInfo;

		// Token: 0x04007C63 RID: 31843
		private GameObject mChapterIndexParentGo;

		// Token: 0x04007C64 RID: 31844
		private AssetLoadCallbacks mAssetLoaderCallback;

		// Token: 0x04007C65 RID: 31845
		public const int yijieChapterIndex = 31;

		// Token: 0x04007C66 RID: 31846
		protected Coroutine mRevertAnimate;

		// Token: 0x04007C67 RID: 31847
		private Coroutine mSetRewardBtCD;

		// Token: 0x04007C68 RID: 31848
		private Coroutine mDelayOpen;

		// Token: 0x04007C69 RID: 31849
		private ChapterSelectFrame.eEnterWay mEnterWay;

		// Token: 0x04007C6A RID: 31850
		[CompilerGenerated]
		private static OnAssetLoadSuccess <>f__mg$cache0;

		// Token: 0x04007C6B RID: 31851
		[CompilerGenerated]
		private static OnAssetLoadFailure <>f__mg$cache1;

		// Token: 0x02001538 RID: 5432
		private enum eAnimateState
		{
			// Token: 0x04007C6D RID: 31853
			onNone,
			// Token: 0x04007C6E RID: 31854
			onSelectAnimate,
			// Token: 0x04007C6F RID: 31855
			onBackAnimate
		}

		// Token: 0x02001539 RID: 5433
		private class Node
		{
			// Token: 0x04007C70 RID: 31856
			public string path = string.Empty;

			// Token: 0x04007C71 RID: 31857
			public DChapterData data;

			// Token: 0x04007C72 RID: 31858
			public List<int> dungeonIDs = new List<int>();
		}

		// Token: 0x0200153A RID: 5434
		private class ChapterNode
		{
			// Token: 0x0600D423 RID: 54307 RVA: 0x0034DB14 File Offset: 0x0034BF14
			public void SetNode(ChapterSelectFrame.Node node)
			{
				this.node = node;
				this.index = -1;
				this.unlockCount = 0;
			}

			// Token: 0x0600D424 RID: 54308 RVA: 0x0034DB2B File Offset: 0x0034BF2B
			public DChapterData GetData()
			{
				if (this.node != null)
				{
					return this.node.data;
				}
				return null;
			}

			// Token: 0x0600D425 RID: 54309 RVA: 0x0034DB45 File Offset: 0x0034BF45
			public ChaptertDungeonUnit[] Chapters()
			{
				if (this.node != null)
				{
					return this.node.data.chapterList;
				}
				return null;
			}

			// Token: 0x0600D426 RID: 54310 RVA: 0x0034DB64 File Offset: 0x0034BF64
			public void UpdateIndex(int dungeonID)
			{
				if (this.node != null && this.node.dungeonIDs != null)
				{
					for (int i = 0; i < this.node.dungeonIDs.Count; i++)
					{
						if (this.node.dungeonIDs[i] == dungeonID)
						{
							this.index = i;
						}
					}
				}
			}

			// Token: 0x0600D427 RID: 54311 RVA: 0x0034DBCC File Offset: 0x0034BFCC
			public int CurrentDungeonID()
			{
				if (this.node == null || this.index < 0 || this.index >= this.node.dungeonIDs.Count)
				{
					return -1;
				}
				return this.node.dungeonIDs[this.index];
			}

			// Token: 0x04007C73 RID: 31859
			public ChapterSelectFrame.Node node;

			// Token: 0x04007C74 RID: 31860
			public int index = -1;

			// Token: 0x04007C75 RID: 31861
			public int unlockCount;
		}

		// Token: 0x0200153B RID: 5435
		public enum eEnterWay
		{
			// Token: 0x04007C77 RID: 31863
			onNone,
			// Token: 0x04007C78 RID: 31864
			onClick,
			// Token: 0x04007C79 RID: 31865
			onGuide
		}
	}
}
