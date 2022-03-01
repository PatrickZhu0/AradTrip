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
	// Token: 0x020014B3 RID: 5299
	public class ChallengeChapterView : MonoBehaviour
	{
		// Token: 0x0600CD4F RID: 52559 RVA: 0x00327A81 File Offset: 0x00325E81
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CD50 RID: 52560 RVA: 0x00327A89 File Offset: 0x00325E89
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CD51 RID: 52561 RVA: 0x00327A98 File Offset: 0x00325E98
		private void BindEvents()
		{
			if (this.leftChapterButton != null)
			{
				this.leftChapterButton.onClick.RemoveAllListeners();
				this.leftChapterButton.onClick.AddListener(new UnityAction(this.OnLeftChapterButtonClick));
			}
			if (this.rightChapterButton != null)
			{
				this.rightChapterButton.onClick.RemoveAllListeners();
				this.rightChapterButton.onClick.AddListener(new UnityAction(this.OnRightChapterButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.mDropButton != null)
			{
				this.mDropButton.onClick.RemoveAllListeners();
				this.mDropButton.onClick.AddListener(new UnityAction(this.OnDropButtonClick));
			}
			if (this.mStartContinueButton != null)
			{
				this.mStartContinueButton.onClick.RemoveAllListeners();
				this.mStartContinueButton.onClick.AddListener(new UnityAction(this.OnStartContinueButtonClick));
			}
			if (this.mStrategySkillsButton != null)
			{
				this.mStrategySkillsButton.onClick.RemoveAllListeners();
				this.mStrategySkillsButton.onClick.AddListener(new UnityAction(this.OnStrategySkillsBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChallengeChapterFinishChange, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFinishChange));
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(568, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.failureReturnValue = tableItem.Value;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateChapterDropProgress));
		}

		// Token: 0x0600CD52 RID: 52562 RVA: 0x00327C78 File Offset: 0x00326078
		private void UnBindEvents()
		{
			if (this.leftChapterButton != null)
			{
				this.leftChapterButton.onClick.RemoveAllListeners();
			}
			if (this.rightChapterButton != null)
			{
				this.rightChapterButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.mDropButton != null)
			{
				this.mDropButton.onClick.RemoveAllListeners();
			}
			if (this.mStartContinueButton != null)
			{
				this.mStartContinueButton.onClick.RemoveAllListeners();
			}
			if (this.mStrategySkillsButton != null)
			{
				this.mStrategySkillsButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChallengeChapterFinishChange, new ClientEventSystem.UIEventHandler(this.OnChallengeChapterFinishChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnUpdateChapterDropProgress));
		}

		// Token: 0x0600CD53 RID: 52563 RVA: 0x00327D84 File Offset: 0x00326184
		private void ClearData()
		{
			this._chapterParamDataModel = null;
			this._chapterIdList = null;
			this._baseChapterIndex = 0;
			this._mapItemId = 0;
			this._baseChapterId = 0;
			this._selectedChapterId = 0;
			this._dungeonTable = null;
			this._chapterLevelDataModelList = null;
			this._modelType = DungeonModelTable.eType.Type_None;
			this._chapterShopId = 0;
			this.failureReturnValue = 0;
		}

		// Token: 0x0600CD54 RID: 52564 RVA: 0x00327DE0 File Offset: 0x003261E0
		public void InitView(ChallengeChapterParamDataModel chapterParamDataModel)
		{
			this._chapterParamDataModel = chapterParamDataModel;
			if (chapterParamDataModel == null)
			{
				Logger.LogErrorFormat("ChapterParamDataModel is null", new object[0]);
				return;
			}
			this._mapItemId = chapterParamDataModel.BaseChapterId;
			this._baseChapterId = chapterParamDataModel.BaseChapterId;
			this._selectedChapterId = chapterParamDataModel.SelectedChapterId;
			this._chapterIdList = chapterParamDataModel.ChapterIdList;
			this._modelType = chapterParamDataModel.ModelType;
			this.UpdateChapterIdOfWeekHell();
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._selectedChapterId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("DungeonTable is null and selectedChapterId is {0}", new object[]
				{
					this._selectedChapterId
				});
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CD55 RID: 52565 RVA: 0x00327EA2 File Offset: 0x003262A2
		private void InitContent()
		{
			this.InitChapterMoney();
			this.InitChapterLevel();
			this.InitChapterSelectButtonInfo();
			this.UpdateChapterExtraControl();
			this.InitFailDesc();
		}

		// Token: 0x0600CD56 RID: 52566 RVA: 0x00327EC2 File Offset: 0x003262C2
		private void InitChapterMoney()
		{
			if (this.chapterMoneyControl != null)
			{
				this.chapterMoneyControl.InitMoneyControl(this._dungeonTable);
			}
		}

		// Token: 0x0600CD57 RID: 52567 RVA: 0x00327EE6 File Offset: 0x003262E6
		private void InitChapterSelectButtonInfo()
		{
			this.InitChapterSelectIndex();
			this.UpdateChapterSelectButton();
		}

		// Token: 0x0600CD58 RID: 52568 RVA: 0x00327EF4 File Offset: 0x003262F4
		private void InitChapterSelectIndex()
		{
			if (this._chapterIdList == null || this._chapterIdList.Count <= 0)
			{
				return;
			}
			this._baseChapterIndex = 0;
			for (int i = 0; i < this._chapterIdList.Count; i++)
			{
				if (this._chapterIdList[i] == this._baseChapterId)
				{
					this._baseChapterIndex = i;
					return;
				}
			}
		}

		// Token: 0x0600CD59 RID: 52569 RVA: 0x00327F60 File Offset: 0x00326360
		private void InitChapterLevel()
		{
			this.UpdateChapterLevelControl();
			this.UpdateChapterContent();
		}

		// Token: 0x0600CD5A RID: 52570 RVA: 0x00327F70 File Offset: 0x00326370
		private void UpdateChapterLevelControl()
		{
			DungeonID dungeonID = new DungeonID(0);
			dungeonID.dungeonID = this._baseChapterId;
			if (this._chapterLevelDataModelList == null)
			{
				this._chapterLevelDataModelList = new List<ChallengeChapterLevelDataModel>();
			}
			this._chapterLevelDataModelList.Clear();
			if (DungeonUtility.IsWeekHellEntryDungeon(dungeonID.dungeonID) || DungeonUtility.IsWeekHellPreDungeon(dungeonID.dungeonID) || DungeonUtility.IsLimitTimeHellDungeon(dungeonID.dungeonID))
			{
				ChallengeChapterLevelDataModel challengeChapterLevelDataModel = new ChallengeChapterLevelDataModel(0, dungeonID.dungeonID, false);
				challengeChapterLevelDataModel.IsSelected = true;
				this._chapterLevelDataModelList.Add(challengeChapterLevelDataModel);
			}
			else
			{
				int dungeonTopHard = ChapterUtility.GetDungeonTopHard(dungeonID.dungeonIDWithOutDiff);
				for (int i = 0; i <= dungeonTopHard; i++)
				{
					dungeonID.diffID = i;
					ChallengeChapterLevelDataModel challengeChapterLevelDataModel2 = new ChallengeChapterLevelDataModel(i, dungeonID.dungeonID, false);
					if (this._selectedChapterId == dungeonID.dungeonID)
					{
						challengeChapterLevelDataModel2.IsSelected = true;
					}
					this._chapterLevelDataModelList.Add(challengeChapterLevelDataModel2);
				}
			}
			if (this.chapterLevelControl != null)
			{
				this.chapterLevelControl.InitLevelControl(this._chapterLevelDataModelList, new OnChapterLevelButtonClick(this.OnChapterLevelButtonClick));
			}
		}

		// Token: 0x0600CD5B RID: 52571 RVA: 0x0032808F File Offset: 0x0032648F
		private void OnChapterLevelButtonClick(int levelId, int dungeonId)
		{
			this._selectedChapterId = dungeonId;
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (this._dungeonTable != null)
			{
				this.UpdateChapterContent();
			}
		}

		// Token: 0x0600CD5C RID: 52572 RVA: 0x003280C4 File Offset: 0x003264C4
		private void UpdateChapterContent()
		{
			this.UpdateChapterNormalControl();
			this.UpdateChapterDropControl();
			this.UpdateChapterEntry();
			this.UpdateChapterDrug();
			this.RefreshYiJieShowInfo();
		}

		// Token: 0x0600CD5D RID: 52573 RVA: 0x003280E4 File Offset: 0x003264E4
		private void UpdateChapterNormalControl()
		{
			if (this.chapterNormalControl != null)
			{
				this.chapterNormalControl.UpdateNormalControl(this._selectedChapterId, this._dungeonTable);
			}
		}

		// Token: 0x0600CD5E RID: 52574 RVA: 0x0032810E File Offset: 0x0032650E
		private void UpdateChapterDropControl()
		{
			if (this.chapterDropControl != null)
			{
				this.chapterDropControl.InitDropControl(this._selectedChapterId, this._mapItemId);
			}
		}

		// Token: 0x0600CD5F RID: 52575 RVA: 0x00328138 File Offset: 0x00326538
		private void UpdateChapterEntry()
		{
			if (this.chapterEntryControl != null)
			{
				this.chapterEntryControl.UpdateEntryControl(this._selectedChapterId, this._dungeonTable, this._baseChapterId, new UnityAction(this.OnStartContinueButtonClick));
			}
		}

		// Token: 0x0600CD60 RID: 52576 RVA: 0x00328174 File Offset: 0x00326574
		private void UpdateChapterDrug()
		{
			if (this.chapterDrugControl != null)
			{
				this.chapterDrugControl.UpdateDrugControl(this._baseChapterId);
			}
		}

		// Token: 0x0600CD61 RID: 52577 RVA: 0x00328198 File Offset: 0x00326598
		private void OnLeftChapterButtonClick()
		{
			if (this._chapterIdList == null || this._chapterIdList.Count <= 0)
			{
				Logger.LogError("ChapterIDList is null");
				return;
			}
			if (this._baseChapterIndex <= 0)
			{
				return;
			}
			this.DealWithStateByChapterButtonClick(true);
		}

		// Token: 0x0600CD62 RID: 52578 RVA: 0x003281D8 File Offset: 0x003265D8
		private void OnRightChapterButtonClick()
		{
			if (this._chapterIdList == null || this._chapterIdList.Count <= 0)
			{
				Logger.LogError("ChapterIDList is null");
				return;
			}
			if (this._baseChapterIndex >= this._chapterIdList.Count - 1)
			{
				return;
			}
			this.DealWithStateByChapterButtonClick(false);
		}

		// Token: 0x0600CD63 RID: 52579 RVA: 0x0032822C File Offset: 0x0032662C
		private void DealWithStateByChapterButtonClick(bool isLeft)
		{
			if (isLeft)
			{
				this._baseChapterIndex--;
			}
			else
			{
				this._baseChapterIndex++;
			}
			if (this._baseChapterIndex < 0)
			{
				this._baseChapterIndex = 0;
			}
			if (this._baseChapterIndex > this._chapterIdList.Count - 1)
			{
				this._baseChapterIndex = this._chapterIdList.Count - 1;
			}
			this.UpdateFrameMask(true);
			this.UpdateChapterSelectButton();
			int num = this._chapterIdList[this._baseChapterIndex];
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChallengeChapterBeginChange, this._modelType, num, null, null);
		}

		// Token: 0x0600CD64 RID: 52580 RVA: 0x003282DF File Offset: 0x003266DF
		private void UpdateFrameMask(bool flag)
		{
			if (this.frameMask != null)
			{
				this.frameMask.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CD65 RID: 52581 RVA: 0x00328304 File Offset: 0x00326704
		private void OnChallengeChapterFinishChange(UIEvent uiEvent)
		{
			this.UpdateFrameMask(false);
			if (this._chapterIdList == null || this._chapterIdList.Count <= 0 || this._baseChapterIndex < 0 || this._baseChapterIndex >= this._chapterIdList.Count)
			{
				Logger.LogErrorFormat("ChapterFinishChange is Error", new object[0]);
				return;
			}
			this._mapItemId = this._chapterIdList[this._baseChapterIndex];
			this._baseChapterId = this._chapterIdList[this._baseChapterIndex];
			this._selectedChapterId = this._chapterIdList[this._baseChapterIndex];
			this.UpdateChapterIdOfWeekHell();
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._selectedChapterId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("ChapterFinishChange and dungeonTable is null selectedChapterIndex is {0}, _chapterId is {1}", new object[]
				{
					this._baseChapterIndex,
					this._selectedChapterId
				});
				return;
			}
			this.InitChapterLevel();
			this.UpdateChapterExtraControl();
			this.RefreshYiJieShowInfo();
		}

		// Token: 0x0600CD66 RID: 52582 RVA: 0x0032841C File Offset: 0x0032681C
		private void OnUpdateChapterDropProgress(UIEvent ui)
		{
			if (this._modelType == DungeonModelTable.eType.VoidCrackModel)
			{
				this.UpdateLevelChallengeTimes(this._selectedChapterId);
			}
			this.UpdateDropProgress(this._selectedChapterId);
		}

		// Token: 0x0600CD67 RID: 52583 RVA: 0x00328444 File Offset: 0x00326844
		private void UpdateChapterSelectButton()
		{
			if (this._chapterIdList == null || this._chapterIdList.Count <= 0)
			{
				ChallengeUtility.UpdateButtonState(this.leftChapterButton, this.leftChapterButtonGray, false);
				ChallengeUtility.UpdateButtonState(this.rightChapterButton, this.rightChapterButtonGray, false);
				return;
			}
			if (this._baseChapterIndex <= 0)
			{
				ChallengeUtility.UpdateButtonState(this.leftChapterButton, this.leftChapterButtonGray, false);
			}
			else
			{
				ChallengeUtility.UpdateButtonState(this.leftChapterButton, this.leftChapterButtonGray, true);
			}
			if (this._baseChapterIndex >= this._chapterIdList.Count - 1)
			{
				ChallengeUtility.UpdateButtonState(this.rightChapterButton, this.rightChapterButtonGray, false);
			}
			else
			{
				ChallengeUtility.UpdateButtonState(this.rightChapterButton, this.rightChapterButtonGray, true);
			}
		}

		// Token: 0x0600CD68 RID: 52584 RVA: 0x00328508 File Offset: 0x00326908
		private void UpdateChapterIdOfWeekHell()
		{
			if (DungeonUtility.IsWeekHellEntryDungeon(this._baseChapterId))
			{
				this._selectedChapterId = this._baseChapterId;
				if (DungeonUtility.GetWeekHellPreTaskState(this._baseChapterId) == WeekHellPreTaskState.IsProcessing)
				{
					this._baseChapterId = DungeonUtility.GetWeekHellPreTaskDungeonId(this._baseChapterId);
					this._selectedChapterId = this._baseChapterId;
				}
			}
		}

		// Token: 0x0600CD69 RID: 52585 RVA: 0x0032855F File Offset: 0x0032695F
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChallengeChapterFrameClose, this._modelType, null, null, null);
			ChallengeUtility.OnCloseChallengeChapterFrame();
		}

		// Token: 0x0600CD6A RID: 52586 RVA: 0x00328584 File Offset: 0x00326984
		private void OnDropButtonClick()
		{
			ChapterDropProgressFrame chapterDropProgressFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDropProgressFrame>(FrameLayer.Middle, null, string.Empty) as ChapterDropProgressFrame;
			chapterDropProgressFrame.SetData(this._selectedChapterId, this.mAreaIndex);
		}

		// Token: 0x0600CD6B RID: 52587 RVA: 0x003285BC File Offset: 0x003269BC
		private void OnStartContinueButtonClick()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("can_not_enter_dungeon_in_cross_scene"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.mDropProgress != null && this.mDropProgress.activeSelf && this.GetLeftTimes() <= 0)
			{
				if (!ChapterNormalHalfFrame.IsYiJieDungeon(this._selectedChapterId) || !this.IsCurrentDungeonInChallenge())
				{
					this._usePassItem();
					return;
				}
			}
			if (this.chapterEntryControl != null)
			{
				this.chapterEntryControl.OnStartButtonClick();
			}
		}

		// Token: 0x0600CD6C RID: 52588 RVA: 0x0032865C File Offset: 0x00326A5C
		private void OnStrategySkillsBtnClick()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._selectedChapterId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CheckPointHelpFrame>(FrameLayer.Middle, tableItem.PlayingDescription, string.Empty);
		}

		// Token: 0x0600CD6D RID: 52589 RVA: 0x003286A2 File Offset: 0x00326AA2
		private void UpdateChapterExtraControl()
		{
			if (this.chapterShopControl != null)
			{
				this.chapterShopControl.InitShopControl(this._baseChapterId);
			}
		}

		// Token: 0x0600CD6E RID: 52590 RVA: 0x003286C8 File Offset: 0x00326AC8
		private void InitFailDesc()
		{
			if (this.mFailDesc != null)
			{
				this.mFailDesc.gameObject.CustomActive(this._modelType == DungeonModelTable.eType.WeekHellModel);
				this.mFailDesc.text = string.Format(this.failDesc, this.failureReturnValue);
			}
		}

		// Token: 0x0600CD6F RID: 52591 RVA: 0x00328720 File Offset: 0x00326B20
		private void UpdateDungeonMissionInfo()
		{
			this.mMissionInfoRoot.CustomActive(false);
			if (ChapterUtility.GetDungeonMissionState(this._selectedChapterId))
			{
				int missionIDByDungeonID = (int)ChapterUtility.GetMissionIDByDungeonID(this._selectedChapterId);
				this.mMissionInfoRoot.CustomActive(true);
				this.mMissionInfo.text = ChapterUtility.GetDungeonMissionInfo(this._selectedChapterId);
				this.mDungeonUnitInfo.SetType(ChapterUtility.GetMissionType(missionIDByDungeonID));
				this.mMissionContent.SetText(Utility.ParseMissionText(missionIDByDungeonID, true, false, false), true);
			}
			else
			{
				this.mDungeonUnitInfo.SetType(ComChapterDungeonUnit.eMissionType.None);
			}
			this.mDungeonUnitInfo.SetEffect("Effects/UI/Prefab/EffUI_Yijie/Prefab/Eff_UI_YiJie_fangjian");
		}

		// Token: 0x0600CD70 RID: 52592 RVA: 0x003287C0 File Offset: 0x00326BC0
		private void UpdateLevelChallengeTimes(int dungeonId)
		{
			if (this.mlevelChallengeTimesRoot == null)
			{
				return;
			}
			int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(dungeonId);
			if (dungeonDailyBaseTimes <= 0)
			{
				this.mlevelChallengeTimesRoot.CustomActive(false);
			}
			else
			{
				this.mlevelChallengeTimesRoot.CustomActive(true);
				if (this.mLevelChallengeTimesNumber != null)
				{
					int leftTimes = this.GetLeftTimes();
					this.mLevelChallengeTimesNumber.text = string.Format(TR.Value("resist_magic_challenge_times"), leftTimes, dungeonDailyBaseTimes);
				}
			}
		}

		// Token: 0x0600CD71 RID: 52593 RVA: 0x00328848 File Offset: 0x00326C48
		private int GetLeftTimes()
		{
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(this._selectedChapterId);
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(this._selectedChapterId);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600CD72 RID: 52594 RVA: 0x0032887C File Offset: 0x00326C7C
		private void UpdateDropProgress(int dungeonId)
		{
			if (this.mDropProgress == null)
			{
				return;
			}
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SubType != DungeonTable.eSubType.S_DEVILDDOM)
			{
				this.mDropProgress.CustomActive(false);
			}
			else
			{
				this.mDropProgress.CustomActive(true);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWorldDungeonGetAreaIndex());
			}
		}

		// Token: 0x0600CD73 RID: 52595 RVA: 0x003288F4 File Offset: 0x00326CF4
		private IEnumerator _onWorldDungeonGetAreaIndex()
		{
			WorldDungeonGetAreaIndexReq req = new WorldDungeonGetAreaIndexReq();
			req.dungeonId = (uint)this._selectedChapterId;
			WorldDungeonGetAreaIndexRes res = new WorldDungeonGetAreaIndexRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<WorldDungeonGetAreaIndexReq, WorldDungeonGetAreaIndexRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (msg.IsAllMessageReceived())
			{
				this.mAreaIndex = res.areaIndex >> 1;
				this.mDropButtonEffect.CustomActive(this.mAreaIndex > 0U);
			}
			yield break;
		}

		// Token: 0x0600CD74 RID: 52596 RVA: 0x00328910 File Offset: 0x00326D10
		public bool IsCurrentDungeonInChallenge()
		{
			DungeonID dungeonID = new DungeonID(this._selectedChapterId);
			if (dungeonID != null)
			{
				dungeonID.diffID = 0;
				return ChapterSelectFrame.IsInChallenge(dungeonID.dungeonID);
			}
			return false;
		}

		// Token: 0x0600CD75 RID: 52597 RVA: 0x00328948 File Offset: 0x00326D48
		private void RefreshYiJieShowInfo()
		{
			if (this._modelType == DungeonModelTable.eType.VoidCrackModel)
			{
				this.UpdateDungeonMissionInfo();
				this.UpdateLevelChallengeTimes(this._selectedChapterId);
				this.UpdateDropProgress(this._selectedChapterId);
				this.UpdateStrategySkillsBtn();
				if (ChapterNormalHalfFrame.IsYiJieDungeon(this._selectedChapterId))
				{
					bool flag = this.IsCurrentDungeonInChallenge();
					this.mStartContinueButtonRoot.CustomActive(flag);
					this.mStartButtonRoot.CustomActive(!flag);
				}
				this.mDetailButtonRoot.CustomActive(false);
				this.mTicketConsumeRoot.CustomActive(false);
			}
			else
			{
				this.mMissionInfoRoot.CustomActive(false);
				this.mDropProgress.CustomActive(false);
				this.mStrategySkillsButton.CustomActive(false);
				this.mDetailButtonRoot.CustomActive(true);
			}
		}

		// Token: 0x0600CD76 RID: 52598 RVA: 0x00328A04 File Offset: 0x00326E04
		private void _usePassItem()
		{
			bool flag = false;
			foreach (int num in new int[]
			{
				800000798,
				330000200,
				330000194
			})
			{
				if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true) >= 1)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(num, true, true);
					if (item != null)
					{
						if (item.GetCurrentRemainUseTime() > 0)
						{
							SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("drop_progress_challenge_times_not_enough_has_item"), delegate()
							{
								DataManager<ItemDataManager>.GetInstance().UseItemWithoutDoubleCheck(item, false, 0, 0);
							}, null, 0f, false);
							return;
						}
						flag = true;
					}
				}
			}
			if (flag)
			{
				SystemNotifyManager.SystemNotify(1226, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_redpacket_has_no_cost_time"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600CD77 RID: 52599 RVA: 0x00328AE0 File Offset: 0x00326EE0
		private void UpdateStrategySkillsBtn()
		{
			bool bActive = this.StrategySkillsBtnIsShow();
			this.mStrategySkillsButton.CustomActive(bActive);
		}

		// Token: 0x0600CD78 RID: 52600 RVA: 0x00328B00 File Offset: 0x00326F00
		private bool StrategySkillsBtnIsShow()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._selectedChapterId, string.Empty, string.Empty);
			return tableItem != null && !(tableItem.PlayingDescription == string.Empty) && tableItem.PlayingDescription != null;
		}

		// Token: 0x040077AE RID: 30638
		private ChallengeChapterParamDataModel _chapterParamDataModel;

		// Token: 0x040077AF RID: 30639
		private DungeonModelTable.eType _modelType;

		// Token: 0x040077B0 RID: 30640
		private int _mapItemId;

		// Token: 0x040077B1 RID: 30641
		private int _baseChapterId;

		// Token: 0x040077B2 RID: 30642
		private int _selectedChapterId;

		// Token: 0x040077B3 RID: 30643
		private List<int> _chapterIdList;

		// Token: 0x040077B4 RID: 30644
		private int _chapterShopId;

		// Token: 0x040077B5 RID: 30645
		private int _baseChapterIndex;

		// Token: 0x040077B6 RID: 30646
		private DungeonTable _dungeonTable;

		// Token: 0x040077B7 RID: 30647
		private List<ChallengeChapterLevelDataModel> _chapterLevelDataModelList;

		// Token: 0x040077B8 RID: 30648
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x040077B9 RID: 30649
		[Space(10f)]
		[Header("LeftPanel")]
		[Space(10f)]
		[SerializeField]
		private Button leftChapterButton;

		// Token: 0x040077BA RID: 30650
		[SerializeField]
		private UIGray leftChapterButtonGray;

		// Token: 0x040077BB RID: 30651
		[SerializeField]
		private Button rightChapterButton;

		// Token: 0x040077BC RID: 30652
		[SerializeField]
		private UIGray rightChapterButtonGray;

		// Token: 0x040077BD RID: 30653
		[SerializeField]
		private GameObject frameMask;

		// Token: 0x040077BE RID: 30654
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private ChallengeChapterMoneyControl chapterMoneyControl;

		// Token: 0x040077BF RID: 30655
		[SerializeField]
		private ChallengeChapterNormalControl chapterNormalControl;

		// Token: 0x040077C0 RID: 30656
		[SerializeField]
		private ChallengeChapterLevelControl chapterLevelControl;

		// Token: 0x040077C1 RID: 30657
		[SerializeField]
		private ChallengeChapterDropControl chapterDropControl;

		// Token: 0x040077C2 RID: 30658
		[SerializeField]
		private ChallengeChapterEntryControl chapterEntryControl;

		// Token: 0x040077C3 RID: 30659
		[SerializeField]
		private ChallengeChapterDrugControl chapterDrugControl;

		// Token: 0x040077C4 RID: 30660
		[SerializeField]
		private ChallengeChapterRewardControl chapterRewardControl;

		// Token: 0x040077C5 RID: 30661
		[SerializeField]
		private ChallengeChapterShopControl chapterShopControl;

		// Token: 0x040077C6 RID: 30662
		[SerializeField]
		private Text mFailDesc;

		// Token: 0x040077C7 RID: 30663
		[SerializeField]
		private string failDesc = "(失败返回{0})";

		// Token: 0x040077C8 RID: 30664
		[Space(10f)]
		[Header("YIJieInfo")]
		[Space(10f)]
		[SerializeField]
		private GameObject mMissionInfoRoot;

		// Token: 0x040077C9 RID: 30665
		[SerializeField]
		private Text mMissionInfo;

		// Token: 0x040077CA RID: 30666
		[SerializeField]
		private LinkParse mMissionContent;

		// Token: 0x040077CB RID: 30667
		[SerializeField]
		private ComChapterDungeonUnit mDungeonUnitInfo;

		// Token: 0x040077CC RID: 30668
		[SerializeField]
		private GameObject mDetailButtonRoot;

		// Token: 0x040077CD RID: 30669
		[SerializeField]
		private GameObject mDropProgress;

		// Token: 0x040077CE RID: 30670
		[SerializeField]
		private Button mDropButton;

		// Token: 0x040077CF RID: 30671
		[SerializeField]
		private GameObject mDropButtonEffect;

		// Token: 0x040077D0 RID: 30672
		[SerializeField]
		private GameObject mlevelChallengeTimesRoot;

		// Token: 0x040077D1 RID: 30673
		[SerializeField]
		private Text mLevelChallengeTimesNumber;

		// Token: 0x040077D2 RID: 30674
		[SerializeField]
		private GameObject mTicketConsumeRoot;

		// Token: 0x040077D3 RID: 30675
		[SerializeField]
		private GameObject mStartButtonRoot;

		// Token: 0x040077D4 RID: 30676
		[SerializeField]
		private GameObject mStartContinueButtonRoot;

		// Token: 0x040077D5 RID: 30677
		[SerializeField]
		private Button mStartContinueButton;

		// Token: 0x040077D6 RID: 30678
		[SerializeField]
		private Button mStrategySkillsButton;

		// Token: 0x040077D7 RID: 30679
		private int failureReturnValue;

		// Token: 0x040077D8 RID: 30680
		private uint mAreaIndex;
	}
}
