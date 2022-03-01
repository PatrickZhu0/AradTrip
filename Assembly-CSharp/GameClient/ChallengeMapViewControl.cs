using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014D2 RID: 5330
	public class ChallengeMapViewControl : MonoBehaviour
	{
		// Token: 0x0600CE98 RID: 52888 RVA: 0x0032EABC File Offset: 0x0032CEBC
		private void Awake()
		{
			this.InitData();
			this.BindUiEvents();
		}

		// Token: 0x0600CE99 RID: 52889 RVA: 0x0032EACA File Offset: 0x0032CECA
		private void OnDestroy()
		{
			this.ClearData();
			this.UnBindUiEvents();
		}

		// Token: 0x0600CE9A RID: 52890 RVA: 0x0032EAD8 File Offset: 0x0032CED8
		private void BindUiEvents()
		{
			if (this.legendButton != null)
			{
				this.legendButton.onClick.RemoveAllListeners();
				this.legendButton.onClick.AddListener(new UnityAction(this.OnLegendButtonClicked));
			}
		}

		// Token: 0x0600CE9B RID: 52891 RVA: 0x0032EB17 File Offset: 0x0032CF17
		private void UnBindUiEvents()
		{
			if (this.legendButton != null)
			{
				this.legendButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CE9C RID: 52892 RVA: 0x0032EB3A File Offset: 0x0032CF3A
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600CE9D RID: 52893 RVA: 0x0032EB42 File Offset: 0x0032CF42
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600CE9E RID: 52894 RVA: 0x0032EB4C File Offset: 0x0032CF4C
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChallengeChapterFrameClose, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFrameClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChallengeChapterBeginChange, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterBeginChange));
		}

		// Token: 0x0600CE9F RID: 52895 RVA: 0x0032EBAC File Offset: 0x0032CFAC
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChallengeChapterFrameClose, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFrameClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChallengeChapterBeginChange, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterBeginChange));
		}

		// Token: 0x0600CEA0 RID: 52896 RVA: 0x0032EC0A File Offset: 0x0032D00A
		private void InitData()
		{
			if (this._chapterIdList == null)
			{
				this._chapterIdList = new List<int>();
			}
			if (this._mapItemList == null)
			{
				this._mapItemList = new List<ChallengeMapItem>();
			}
		}

		// Token: 0x0600CEA1 RID: 52897 RVA: 0x0032EC38 File Offset: 0x0032D038
		private void ClearData()
		{
			this._modelType = DungeonModelTable.eType.Type_None;
			this._challengeParamDataModel = null;
			this._challengeSceneId = 0;
			this._defaultChapterId = 0;
			this._chapterData = null;
			this._activityDungeonSubList = null;
			if (this._mapItemList != null)
			{
				this._mapItemList.Clear();
				this._mapItemList = null;
			}
			if (this._chapterIdList != null)
			{
				this._chapterIdList.Clear();
				this._chapterIdList = null;
			}
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
			this._delayOpenFrameCoroutine = null;
			this._chapterFrameCloseCoroutine = null;
			this._chapterFrameChangeCoroutine = null;
			this._onContentEffectAction = null;
			this.effectRoot = null;
		}

		// Token: 0x0600CEA2 RID: 52898 RVA: 0x0032ECD4 File Offset: 0x0032D0D4
		public void InitMapModelControl(DungeonModelTable.eType modelType, ChallengeMapParamDataModel paramDataModel, OnContentEffectAction onContentEffectAction = null)
		{
			this._modelType = modelType;
			this._challengeParamDataModel = paramDataModel;
			this._challengeSceneId = ChallengeUtility.GetChallengeDungeonMapIdByModelType(this._modelType);
			this._onContentEffectAction = onContentEffectAction;
			if (this._challengeParamDataModel != null)
			{
				this._defaultChapterId = this._challengeParamDataModel.BaseDungeonId;
			}
			this.InitTopRightContent();
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(this._challengeSceneId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("CitySceneTable is null and challengeId is {0}", new object[]
				{
					this._challengeSceneId
				});
				return;
			}
			if (tableItem.ChapterData == null || tableItem.ChapterData.Count <= 0)
			{
				Logger.LogErrorFormat("CitySceneTable ChapterData is null or count is zero", new object[0]);
				return;
			}
			string text = tableItem.ChapterData[0];
			this._chapterData = (Singleton<AssetLoader>.instance.LoadRes(text, typeof(DChapterData), true, 0U).obj as DChapterData);
			if (this._chapterData == null)
			{
				Logger.LogErrorFormat("ChapterData is null and chapterDataPath is {0}", new object[]
				{
					text
				});
				return;
			}
			if (this._chapterData.chapterList == null || this._chapterData.chapterList.Length <= 0)
			{
				Logger.LogErrorFormat("ChapterList is null or count is zero", new object[0]);
				return;
			}
			this.yijieChallengeNumRoot.CustomActive(false);
			if (this._modelType == DungeonModelTable.eType.VoidCrackModel)
			{
				int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(this._chapterData.chapterList[0].dungeonID);
				if (dungeonDailyBaseTimes <= 0)
				{
					this.yijieChallengeNumRoot.CustomActive(false);
				}
				else
				{
					this.yijieChallengeNumRoot.CustomActive(true);
					if (this.yijieChallengeNumInfo != null)
					{
						int leftTimes = this.GetLeftTimes();
						this.yijieChallengeNumInfo.text = string.Format(TR.Value("resist_magic_challenge_times"), leftTimes, dungeonDailyBaseTimes);
					}
				}
				this.YiJieEffectObj = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Yijie/Prefab/Eff_UI_YiJie", true, 0U);
				if (this.YiJieEffectObj != null)
				{
					Utility.AttachTo(this.YiJieEffectObj, this.effectRoot, false);
				}
			}
			this.InitDefaultChapterId();
			this._activityDungeonSubList = ChallengeUtility.GetDailyUnitActivitySubs(this._defaultChapterId);
			this.InitMapModelView();
			this.DefaultOpenChallengeDungeonFrame();
		}

		// Token: 0x0600CEA3 RID: 52899 RVA: 0x0032EF14 File Offset: 0x0032D314
		private void InitTopRightContent()
		{
			CommonUtility.UpdateGameObjectVisible(this.topRightRoot, true);
			if (this._modelType == DungeonModelTable.eType.AncientModel)
			{
				if (this.commonShopButtonControl != null)
				{
					CommonUtility.UpdateGameObjectVisible(this.commonShopButtonControl.gameObject, false);
				}
				CommonUtility.UpdateButtonVisible(this.legendButton, true);
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.legendButton, false);
				if (this.commonShopButtonControl != null)
				{
					CommonUtility.UpdateGameObjectVisible(this.commonShopButtonControl.gameObject, true);
					if (this._modelType == DungeonModelTable.eType.DeepModel)
					{
						this.commonShopButtonControl.SetShopId(9);
					}
					else if (this._modelType == DungeonModelTable.eType.WeekHellModel)
					{
						this.commonShopButtonControl.SetShopId(28);
					}
					else if (this._modelType == DungeonModelTable.eType.VoidCrackModel)
					{
						this.commonShopButtonControl.SetShopId(23);
					}
					else
					{
						CommonUtility.UpdateGameObjectVisible(this.commonShopButtonControl.gameObject, false);
					}
				}
			}
		}

		// Token: 0x0600CEA4 RID: 52900 RVA: 0x0032F008 File Offset: 0x0032D408
		private int GetLeftTimes()
		{
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(this._chapterData.chapterList[0].dungeonID);
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(this._chapterData.chapterList[0].dungeonID);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600CEA5 RID: 52901 RVA: 0x0032F053 File Offset: 0x0032D453
		public void OnEnableView()
		{
			this.UpdateActivityDungeonItemList();
		}

		// Token: 0x0600CEA6 RID: 52902 RVA: 0x0032F05C File Offset: 0x0032D45C
		private void InitDefaultChapterId()
		{
			if (this._defaultChapterId == 0)
			{
				this.SetDefaultChapterId();
			}
			else
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._defaultChapterId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					this.SetDefaultChapterId();
					return;
				}
				if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER)
				{
					for (int i = 0; i < this._chapterData.chapterList.Length; i++)
					{
						ChaptertDungeonUnit chaptertDungeonUnit = this._chapterData.chapterList[i];
						if (chaptertDungeonUnit != null)
						{
							DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(chaptertDungeonUnit.dungeonID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
								{
									MissionTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(tableItem2.PreTaskID, string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										if (tableItem3.MapID == this._defaultChapterId)
										{
											this._defaultChapterId = chaptertDungeonUnit.dungeonID;
											return;
										}
									}
								}
							}
						}
					}
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL)
				{
					this._defaultChapterId = tableItem.ownerEntryId;
				}
				bool flag = false;
				for (int j = 0; j < this._chapterData.chapterList.Length; j++)
				{
					ChaptertDungeonUnit chaptertDungeonUnit2 = this._chapterData.chapterList[j];
					if (chaptertDungeonUnit2 != null)
					{
						if (chaptertDungeonUnit2.dungeonID == this._defaultChapterId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.SetDefaultChapterId();
				}
			}
		}

		// Token: 0x0600CEA7 RID: 52903 RVA: 0x0032F1F5 File Offset: 0x0032D5F5
		private void SetDefaultChapterId()
		{
			if (this._chapterData.chapterList[0] != null)
			{
				this._defaultChapterId = this._chapterData.chapterList[0].dungeonID;
			}
		}

		// Token: 0x0600CEA8 RID: 52904 RVA: 0x0032F224 File Offset: 0x0032D624
		private void InitMapModelView()
		{
			if (this.backgroundImage != null)
			{
				this.backgroundImage.gameObject.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.backgroundImage, this._chapterData.backgroundPath, true);
			}
			if (this.titleImage != null)
			{
				this.titleImage.gameObject.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.titleImage, this._chapterData.namePath, true);
			}
			this.InitChallengeMapItem();
		}

		// Token: 0x0600CEA9 RID: 52905 RVA: 0x0032F2AC File Offset: 0x0032D6AC
		private void InitChallengeMapItem()
		{
			if (this.mapItemPrefab == null || this.mapItemRoot == null)
			{
				Logger.LogErrorFormat("ChapterItemPrefab is null or ChapterItemRoot is null", new object[0]);
				return;
			}
			for (int i = 0; i < this._chapterData.chapterList.Length; i++)
			{
				ChaptertDungeonUnit chaptertDungeonUnit = this._chapterData.chapterList[i];
				if (chaptertDungeonUnit != null)
				{
					ActivityDungeonSub dungeonSubDataByDungeonId = ChallengeUtility.GetDungeonSubDataByDungeonId(chaptertDungeonUnit.dungeonID, this._activityDungeonSubList);
					if (this._modelType != DungeonModelTable.eType.VoidCrackModel && dungeonSubDataByDungeonId == null)
					{
						Logger.LogErrorFormat("ActivityDungeonSub is null and dungeonId is {0}", new object[]
						{
							chaptertDungeonUnit.dungeonID
						});
					}
					else
					{
						if (DungeonUtility.IsLimitTimeHellDungeon(chaptertDungeonUnit.dungeonID))
						{
							if (dungeonSubDataByDungeonId.state == eActivityDungeonState.End || dungeonSubDataByDungeonId.state == eActivityDungeonState.None)
							{
								goto IL_1B6;
							}
							if (DataManager<TimeManager>.GetInstance().GetServerTime() > dungeonSubDataByDungeonId.endtime)
							{
								goto IL_1B6;
							}
						}
						GameObject gameObject = Object.Instantiate<GameObject>(this.mapItemPrefab);
						if (!(gameObject == null))
						{
							gameObject.CustomActive(true);
							Utility.AttachTo(gameObject, this.mapItemRoot, false);
							ChallengeMapItem component = gameObject.GetComponent<ChallengeMapItem>();
							if (component == null)
							{
								Logger.LogErrorFormat("ChallengeChapterItem is null", new object[0]);
								gameObject.CustomActive(false);
							}
							else
							{
								bool isDefaultSelected = chaptertDungeonUnit.dungeonID == this._defaultChapterId;
								component.InitItem(chaptertDungeonUnit, new OnChallengeMapItemClicked(this.OnChallengeMapItemClick), dungeonSubDataByDungeonId, isDefaultSelected);
								this._mapItemList.Add(component);
								if (this._modelType != DungeonModelTable.eType.VoidCrackModel)
								{
									if (ChallengeUtility.IsChallengeChapterCanSlider(dungeonSubDataByDungeonId))
									{
										this.AddSliderChapterId(dungeonSubDataByDungeonId.dungeonId);
									}
									ChallengeUtility.SortChapterIdListByLevel(this._chapterIdList);
								}
								else
								{
									this.AddSliderChapterId(chaptertDungeonUnit.dungeonID);
								}
							}
						}
					}
				}
				IL_1B6:;
			}
		}

		// Token: 0x0600CEAA RID: 52906 RVA: 0x0032F486 File Offset: 0x0032D886
		private void OnActivityDungeonUpdate(UIEvent uiEvent)
		{
			this.UpdateActivityDungeonItemList();
		}

		// Token: 0x0600CEAB RID: 52907 RVA: 0x0032F490 File Offset: 0x0032D890
		private void UpdateActivityDungeonItemList()
		{
			if (this._mapItemList == null || this._mapItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._mapItemList.Count; i++)
			{
				ChallengeMapItem challengeMapItem = this._mapItemList[i];
				if (challengeMapItem != null)
				{
					challengeMapItem.UpdateDungeonItemContent();
				}
			}
			this.UpdateSliderChapterIdList();
		}

		// Token: 0x0600CEAC RID: 52908 RVA: 0x0032F4FC File Offset: 0x0032D8FC
		private void UpdateSliderChapterIdList()
		{
			for (int i = 0; i < this._activityDungeonSubList.Count; i++)
			{
				ActivityDungeonSub activityDungeonSub = this._activityDungeonSubList[i];
				if (activityDungeonSub != null)
				{
					if (this._modelType != DungeonModelTable.eType.VoidCrackModel && ChallengeUtility.IsChallengeChapterCanSlider(activityDungeonSub))
					{
						this.AddSliderChapterId(activityDungeonSub.dungeonId);
					}
				}
			}
		}

		// Token: 0x0600CEAD RID: 52909 RVA: 0x0032F560 File Offset: 0x0032D960
		private void AddSliderChapterId(int dungeonId)
		{
			if (this._chapterIdList == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this._chapterIdList.Count; i++)
			{
				if (this._chapterIdList[i] == dungeonId)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this._chapterIdList.Add(dungeonId);
			}
		}

		// Token: 0x0600CEAE RID: 52910 RVA: 0x0032F5C2 File Offset: 0x0032D9C2
		private void OnChallengeMapItemClick(int chapterId)
		{
			this.OnOpenChallengeDungeonFrame(chapterId, chapterId);
		}

		// Token: 0x0600CEAF RID: 52911 RVA: 0x0032F5CC File Offset: 0x0032D9CC
		private void OnOpenChallengeDungeonFrame(int baseDungeonId, int selectDungeonId)
		{
			if (this.effectRoot != null)
			{
				this.effectRoot.CustomActive(false);
			}
			CommonUtility.UpdateGameObjectVisible(this.topRightRoot, false);
			this.OnUpdateChallengeMapItemList(baseDungeonId);
			this.UpdateContentEffectAction(false);
			if (this.comChapterSelectAnimate == null)
			{
				ChallengeUtility.OnOpenChallengeChapterFrame(this._modelType, baseDungeonId, selectDungeonId, this._chapterIdList);
				return;
			}
			if (this._eChapterSelectAnimateState == EChapterSelectAnimateState.OnSelectAnimate)
			{
				return;
			}
			if (this._delayOpenFrameCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._delayOpenFrameCoroutine);
				this._delayOpenFrameCoroutine = null;
			}
			this._delayOpenFrameCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.DelayOpenFrame(baseDungeonId, selectDungeonId));
		}

		// Token: 0x0600CEB0 RID: 52912 RVA: 0x0032F67C File Offset: 0x0032DA7C
		private IEnumerator DelayOpenFrame(int baseDungeonId, int selectDungeonId)
		{
			if (baseDungeonId > 0)
			{
				ChallengeMapItem chapterMapItem = this.GetChallengeMapItemByChapterId(baseDungeonId);
				if (chapterMapItem != null)
				{
					while (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnNone)
					{
						yield return null;
					}
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnSelectAnimate;
					yield return this.comChapterSelectAnimate.NormalAnimate(chapterMapItem.rectTransform());
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
				}
			}
			ChallengeUtility.OnOpenChallengeChapterFrame(this._modelType, baseDungeonId, selectDungeonId, this._chapterIdList);
			yield break;
		}

		// Token: 0x0600CEB1 RID: 52913 RVA: 0x0032F6A8 File Offset: 0x0032DAA8
		private void OnChallengeChapterFrameClose(UIEvent uiEvent)
		{
			this.UpdateActivityDungeonItemList();
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			if (this._modelType != (DungeonModelTable.eType)uiEvent.Param1)
			{
				return;
			}
			if (this.comChapterSelectAnimate == null)
			{
				return;
			}
			if (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnBackAnimate)
			{
				if (this._chapterFrameCloseCoroutine != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._chapterFrameCloseCoroutine);
					this._chapterFrameCloseCoroutine = null;
				}
				this._chapterFrameCloseCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.RevertMapAnimate());
			}
			if (this._modelType == DungeonModelTable.eType.VoidCrackModel && this.effectRoot != null)
			{
				this.effectRoot.CustomActive(true);
			}
			CommonUtility.UpdateGameObjectVisible(this.topRightRoot, true);
		}

		// Token: 0x0600CEB2 RID: 52914 RVA: 0x0032F770 File Offset: 0x0032DB70
		private IEnumerator RevertMapAnimate()
		{
			while (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnNone)
			{
				yield return null;
			}
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnBackAnimate;
			yield return this.comChapterSelectAnimate.RevertAnimate();
			this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
			this.UpdateContentEffectAction(true);
			yield break;
		}

		// Token: 0x0600CEB3 RID: 52915 RVA: 0x0032F78C File Offset: 0x0032DB8C
		private void OnChallengeChapterBeginChange(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null || this.comChapterSelectAnimate == null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChallengeChapterFinishChange, null, null, null, null);
				return;
			}
			if (this._modelType != (DungeonModelTable.eType)uiEvent.Param1)
			{
				return;
			}
			int chapterId = (int)uiEvent.Param2;
			this.OnUpdateChallengeMapItemList(chapterId);
			if (this._eChapterSelectAnimateState == EChapterSelectAnimateState.OnSelectAnimate)
			{
				return;
			}
			if (this._chapterFrameChangeCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._chapterFrameChangeCoroutine);
				this._chapterFrameChangeCoroutine = null;
			}
			this._chapterFrameChangeCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.DelayChapterFrameChange(chapterId));
		}

		// Token: 0x0600CEB4 RID: 52916 RVA: 0x0032F84C File Offset: 0x0032DC4C
		private IEnumerator DelayChapterFrameChange(int chapterId)
		{
			if (chapterId > 0)
			{
				ChallengeMapItem chapterMapItem = this.GetChallengeMapItemByChapterId(chapterId);
				if (chapterMapItem != null)
				{
					while (this._eChapterSelectAnimateState != EChapterSelectAnimateState.OnNone)
					{
						yield return null;
					}
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnSelectAnimate;
					yield return this.comChapterSelectAnimate.NormalAnimate(chapterMapItem.rectTransform());
					this._eChapterSelectAnimateState = EChapterSelectAnimateState.OnNone;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChallengeChapterFinishChange, null, null, null, null);
			yield break;
		}

		// Token: 0x0600CEB5 RID: 52917 RVA: 0x0032F870 File Offset: 0x0032DC70
		private void OnUpdateChallengeMapItemList(int chapterId)
		{
			if (this._mapItemList != null)
			{
				for (int i = 0; i < this._mapItemList.Count; i++)
				{
					ChallengeMapItem challengeMapItem = this._mapItemList[i];
					if (challengeMapItem != null)
					{
						challengeMapItem.UpdateSelectedStateByDungeonId(chapterId);
					}
				}
			}
		}

		// Token: 0x0600CEB6 RID: 52918 RVA: 0x0032F8C4 File Offset: 0x0032DCC4
		private ChallengeMapItem GetChallengeMapItemByChapterId(int chapterId)
		{
			if (this._mapItemList != null)
			{
				for (int i = 0; i < this._mapItemList.Count; i++)
				{
					ChallengeMapItem challengeMapItem = this._mapItemList[i];
					if (challengeMapItem != null && challengeMapItem.GetChapterDungeonId() == chapterId)
					{
						return challengeMapItem;
					}
				}
			}
			return null;
		}

		// Token: 0x0600CEB7 RID: 52919 RVA: 0x0032F920 File Offset: 0x0032DD20
		private void DefaultOpenChallengeDungeonFrame()
		{
			if (this._challengeParamDataModel == null)
			{
				return;
			}
			if (this._challengeParamDataModel.DetailDungeonId <= 0)
			{
				return;
			}
			int defaultChapterId = this._defaultChapterId;
			ActivityDungeonSub dungeonSubDataByDungeonId = ChallengeUtility.GetDungeonSubDataByDungeonId(defaultChapterId, this._activityDungeonSubList);
			if (dungeonSubDataByDungeonId == null)
			{
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < dungeonSubDataByDungeonId.level)
			{
				return;
			}
			if (DungeonUtility.IsWeekHellEntryDungeon(defaultChapterId))
			{
				if (DungeonUtility.IsWeekHellPreDungeon(this._challengeParamDataModel.DetailDungeonId))
				{
					WeekHellPreTaskState weekHellPreTaskState = DungeonUtility.GetWeekHellPreTaskState(defaultChapterId);
					if (weekHellPreTaskState != WeekHellPreTaskState.IsProcessing)
					{
						return;
					}
				}
				else
				{
					if (DungeonUtility.GetDungeonWeekLeftTimes(defaultChapterId) <= 0)
					{
						return;
					}
					if (DungeonUtility.GetDungeonDailyLeftTimes(defaultChapterId) <= 0)
					{
						return;
					}
				}
			}
			if (DungeonUtility.IsLimitTimeHellDungeon(defaultChapterId))
			{
				if (dungeonSubDataByDungeonId.isfinish)
				{
					return;
				}
				if (DungeonUtility.GetDungeonDailyLeftTimes(defaultChapterId) <= 0)
				{
					return;
				}
				if (DataManager<TimeManager>.GetInstance().GetServerTime() > dungeonSubDataByDungeonId.endtime)
				{
					return;
				}
			}
			if (this._challengeParamDataModel != null && this._challengeParamDataModel.DetailDungeonId > 0)
			{
				this.OpenChallengeDungeonFrameByDetailDungeonId(this._defaultChapterId, this._challengeParamDataModel.DetailDungeonId);
				this._challengeParamDataModel.DetailDungeonId = 0;
			}
		}

		// Token: 0x0600CEB8 RID: 52920 RVA: 0x0032FA44 File Offset: 0x0032DE44
		private void OpenChallengeDungeonFrameByDetailDungeonId(int baseDungeonId, int selectDungeonId)
		{
			this.OnUpdateChallengeMapItemList(baseDungeonId);
			if (this.comChapterSelectAnimate != null)
			{
				ChallengeMapItem challengeMapItemByChapterId = this.GetChallengeMapItemByChapterId(baseDungeonId);
				if (challengeMapItemByChapterId != null)
				{
					this.comChapterSelectAnimate.NormalAnimateWithAction(challengeMapItemByChapterId.rectTransform());
				}
			}
			this.UpdateContentEffectAction(false);
			ChallengeUtility.OnOpenChallengeChapterFrame(this._modelType, baseDungeonId, selectDungeonId, this._chapterIdList);
		}

		// Token: 0x0600CEB9 RID: 52921 RVA: 0x0032FAA8 File Offset: 0x0032DEA8
		private void UpdateContentEffectAction(bool flag)
		{
			if (this._onContentEffectAction != null)
			{
				this._onContentEffectAction(flag);
			}
		}

		// Token: 0x0600CEBA RID: 52922 RVA: 0x0032FAC1 File Offset: 0x0032DEC1
		private void OnLegendButtonClicked()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LegendFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LegendFrame>(null, true);
			}
			LegendFrame.CommandOpen(null);
		}

		// Token: 0x040078AD RID: 30893
		private DungeonModelTable.eType _modelType;

		// Token: 0x040078AE RID: 30894
		private ChallengeMapParamDataModel _challengeParamDataModel;

		// Token: 0x040078AF RID: 30895
		private int _challengeSceneId;

		// Token: 0x040078B0 RID: 30896
		private int _defaultChapterId;

		// Token: 0x040078B1 RID: 30897
		private List<ChallengeMapItem> _mapItemList;

		// Token: 0x040078B2 RID: 30898
		private List<int> _chapterIdList;

		// Token: 0x040078B3 RID: 30899
		private DChapterData _chapterData;

		// Token: 0x040078B4 RID: 30900
		private List<ActivityDungeonSub> _activityDungeonSubList;

		// Token: 0x040078B5 RID: 30901
		private EChapterSelectAnimateState _eChapterSelectAnimateState;

		// Token: 0x040078B6 RID: 30902
		private Coroutine _delayOpenFrameCoroutine;

		// Token: 0x040078B7 RID: 30903
		private Coroutine _chapterFrameCloseCoroutine;

		// Token: 0x040078B8 RID: 30904
		private Coroutine _chapterFrameChangeCoroutine;

		// Token: 0x040078B9 RID: 30905
		private OnContentEffectAction _onContentEffectAction;

		// Token: 0x040078BA RID: 30906
		[Space(10f)]
		[Header("Image")]
		[Space(10f)]
		[SerializeField]
		private Image titleImage;

		// Token: 0x040078BB RID: 30907
		[SerializeField]
		private Image backgroundImage;

		// Token: 0x040078BC RID: 30908
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject contentRoot;

		// Token: 0x040078BD RID: 30909
		[SerializeField]
		private GameObject mapItemRoot;

		// Token: 0x040078BE RID: 30910
		[SerializeField]
		private GameObject mapItemPrefab;

		// Token: 0x040078BF RID: 30911
		[Space(10f)]
		[Header("Action")]
		[Space(10f)]
		[SerializeField]
		private ComChapterSelectAnimate comChapterSelectAnimate;

		// Token: 0x040078C0 RID: 30912
		[Space(10f)]
		[Header("YiJieChallengeNum")]
		[SerializeField]
		private GameObject yijieChallengeNumRoot;

		// Token: 0x040078C1 RID: 30913
		[SerializeField]
		private Text yijieChallengeNumInfo;

		// Token: 0x040078C2 RID: 30914
		[SerializeField]
		private GameObject effectRoot;

		// Token: 0x040078C3 RID: 30915
		[Space(10f)]
		[Header("TopRight")]
		[Space(10f)]
		[SerializeField]
		private GameObject topRightRoot;

		// Token: 0x040078C4 RID: 30916
		[SerializeField]
		private CommonShopButtonControl commonShopButtonControl;

		// Token: 0x040078C5 RID: 30917
		[SerializeField]
		private Button legendButton;

		// Token: 0x040078C6 RID: 30918
		private GameObject YiJieEffectObj;
	}
}
