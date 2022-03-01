using System;
using System.Collections.Generic;
using Parser;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD6 RID: 7126
	public class TAPLearningFrame : ClientFrame
	{
		// Token: 0x06011742 RID: 71490 RVA: 0x005113F8 File Offset: 0x0050F7F8
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPLearning";
		}

		// Token: 0x06011743 RID: 71491 RVA: 0x005113FF File Offset: 0x0050F7FF
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.relationData = (RelationData)this.userData;
			}
			this._RegisterUIEvent();
			this._InitComUIList();
			this._InitData();
		}

		// Token: 0x06011744 RID: 71492 RVA: 0x0051142F File Offset: 0x0050F82F
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnRegisterUIEvent();
		}

		// Token: 0x06011745 RID: 71493 RVA: 0x0051143D File Offset: 0x0050F83D
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPLearningUpdate, new ClientEventSystem.UIEventHandler(this._OnTAPLearningUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x06011746 RID: 71494 RVA: 0x00511475 File Offset: 0x0050F875
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPLearningUpdate, new ClientEventSystem.UIEventHandler(this._OnTAPLearningUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x06011747 RID: 71495 RVA: 0x005114AD File Offset: 0x0050F8AD
		private void _InitComUIList()
		{
		}

		// Token: 0x06011748 RID: 71496 RVA: 0x005114B0 File Offset: 0x0050F8B0
		private void _InitData()
		{
			this.rewardItemList.Clear();
			this.rewardRoot.Clear();
			this._InitUI();
			if (this.relationData.tapType == TAPType.Teacher)
			{
				this.tempData = DataManager<TAPNewDataManager>.GetInstance().myTAPData;
				this._UpdateLearningData(this.tempData);
				this.mLevel.text = string.Format("出师等级：{0}/50", DataManager<PlayerBaseData>.GetInstance().Level);
				this.mScoreBarGo.CustomActive(false);
				this.mLearningValue.text = TR.Value("tap_pupil_learningframe_tips");
				if (DataManager<PlayerBaseData>.GetInstance().Level >= 50)
				{
					this.mGraduation.CustomActive(true);
				}
				else
				{
					this.mGraduation.CustomActive(false);
				}
				for (int i = 0; i < this.rewardItemList.Count; i++)
				{
					this.rewardItemList[i].UpdateState((int)this.tempData.academicTotalGrowth);
				}
			}
			else
			{
				this.tempData = DataManager<TAPNewDataManager>.GetInstance().GetMyPupilData(this.relationData.uid);
				this._UpdateLearningData(this.tempData);
				this.mScoreBarGo.CustomActive(false);
				this.mLearningValue.text = TR.Value("tap_teacher_learningframe_tips");
				this.mLevel.text = string.Format("出师等级：{0}/50", this.relationData.level);
				if (this.relationData.level >= 50)
				{
					this.mGraduation.CustomActive(true);
				}
				else
				{
					this.mGraduation.CustomActive(false);
				}
			}
		}

		// Token: 0x06011749 RID: 71497 RVA: 0x00511654 File Offset: 0x0050FA54
		private void _UpdateLearningData(MasterTaskShareData pupilData)
		{
			if (pupilData == null)
			{
				return;
			}
			this.mScore.text = string.Format("成长值：{0}", pupilData.academicTotalGrowth);
			this.mSchedule1.text = string.Format("{0}", pupilData.masterDailyTaskGrowth);
			this.mSchedule2.text = string.Format("{0}", pupilData.masterAcademicTaskGrowth);
			this.mSchedule3.text = string.Format("{0}", pupilData.masterGiveEquipGrowth);
			this.mSchedule4.text = string.Format("{0}", pupilData.masterTeamClearDungeonGrowth);
			this.mSchedule5.text = string.Format("{0}", pupilData.masterUplevelGrowth);
			this.mGoLearning.onClick.RemoveAllListeners();
			this.mGoLearning.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPGrade>(FrameLayer.Middle, pupilData.academicTasks.ToList<MissionInfo>(), string.Empty);
			});
			this.mFront.value = this.mScoreBar.GetValue(pupilData.academicTotalGrowth);
			this.graduationScore = (int)pupilData.academicTotalGrowth;
		}

		// Token: 0x0601174A RID: 71498 RVA: 0x005117B8 File Offset: 0x0050FBB8
		private void _ClearData()
		{
			this.rewardItemList.Clear();
			this.rewardRoot.Clear();
			this.relationData = null;
		}

		// Token: 0x0601174B RID: 71499 RVA: 0x005117D8 File Offset: 0x0050FBD8
		private void _InitUI()
		{
			this.rewardRoot.Add(this.mRoot1);
			this.rewardRoot.Add(this.mRoot2);
			this.rewardRoot.Add(this.mRoot3);
			this.rewardRoot.Add(this.mRoot4);
			this.rewardRoot.Add(this.mRoot5);
		}

		// Token: 0x0601174C RID: 71500 RVA: 0x0051183A File Offset: 0x0050FC3A
		private void _OnTAPLearningUpdate(UIEvent uiEvent)
		{
			if ((RelationData)uiEvent.Param1 != null)
			{
				this.relationData = (RelationData)uiEvent.Param1;
			}
			this._InitData();
		}

		// Token: 0x0601174D RID: 71501 RVA: 0x00511864 File Offset: 0x0050FC64
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.relationData.tapType == TAPType.Teacher)
			{
				for (int i = 0; i < this.rewardItemList.Count; i++)
				{
					this.rewardItemList[i].UpdateState((int)this.tempData.academicTotalGrowth);
				}
			}
		}

		// Token: 0x0601174E RID: 71502 RVA: 0x005118BC File Offset: 0x0050FCBC
		protected override void _bindExUI()
		{
			this.mScore = this.mBind.GetCom<Text>("Score");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mFront = this.mBind.GetCom<Slider>("Front");
			this.mRoot1 = this.mBind.GetGameObject("root1");
			this.mRoot2 = this.mBind.GetGameObject("root2");
			this.mRoot3 = this.mBind.GetGameObject("root3");
			this.mRoot4 = this.mBind.GetGameObject("root4");
			this.mRoot5 = this.mBind.GetGameObject("root5");
			this.mSchedule1 = this.mBind.GetCom<Text>("Schedule1");
			this.mSchedule2 = this.mBind.GetCom<Text>("Schedule2");
			this.mSchedule3 = this.mBind.GetCom<Text>("Schedule3");
			this.mSchedule4 = this.mBind.GetCom<Text>("Schedule4");
			this.mSchedule5 = this.mBind.GetCom<Text>("Schedule5");
			this.mGoMission = this.mBind.GetCom<Button>("goMission");
			if (null != this.mGoMission)
			{
				this.mGoMission.onClick.AddListener(new UnityAction(this._onGoMissionButtonClick));
			}
			this.mGoLearning = this.mBind.GetCom<Button>("goLearning");
			if (null != this.mGoLearning)
			{
				this.mGoLearning.onClick.AddListener(new UnityAction(this._onGoLearningButtonClick));
			}
			this.mGoReward = this.mBind.GetCom<Button>("goReward");
			if (null != this.mGoReward)
			{
				this.mGoReward.onClick.AddListener(new UnityAction(this._onGoRewardButtonClick));
			}
			this.mScoreBarGo = this.mBind.GetGameObject("ScoreBarGo");
			this.mLearningValue = this.mBind.GetCom<Text>("LearningValue");
			this.mGraduation = this.mBind.GetCom<Button>("graduation");
			if (null != this.mGraduation)
			{
				this.mGraduation.onClick.AddListener(new UnityAction(this._onGraduationButtonClick));
			}
			this.mScoreBar = this.mBind.GetCom<GetAniValue>("ScoreBar");
		}

		// Token: 0x0601174F RID: 71503 RVA: 0x00511B38 File Offset: 0x0050FF38
		protected override void _unbindExUI()
		{
			this.mScore = null;
			this.mLevel = null;
			this.mFront = null;
			this.mRoot1 = null;
			this.mRoot2 = null;
			this.mRoot3 = null;
			this.mRoot4 = null;
			this.mRoot5 = null;
			this.mSchedule1 = null;
			this.mSchedule2 = null;
			this.mSchedule3 = null;
			this.mSchedule4 = null;
			this.mSchedule5 = null;
			if (null != this.mGoMission)
			{
				this.mGoMission.onClick.RemoveListener(new UnityAction(this._onGoMissionButtonClick));
			}
			this.mGoMission = null;
			if (null != this.mGoLearning)
			{
				this.mGoLearning.onClick.RemoveListener(new UnityAction(this._onGoLearningButtonClick));
			}
			this.mGoLearning = null;
			if (null != this.mGoReward)
			{
				this.mGoReward.onClick.RemoveListener(new UnityAction(this._onGoRewardButtonClick));
			}
			this.mGoReward = null;
			this.mScoreBarGo = null;
			this.mLearningValue = null;
			if (null != this.mGraduation)
			{
				this.mGraduation.onClick.RemoveListener(new UnityAction(this._onGraduationButtonClick));
			}
			this.mGraduation = null;
			this.mScoreBar = null;
		}

		// Token: 0x06011750 RID: 71504 RVA: 0x00511C88 File Offset: 0x00510088
		private void _onGoMissionButtonClick()
		{
			int num = 0;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReSelectTAPToggle, num, null, null, null);
		}

		// Token: 0x06011751 RID: 71505 RVA: 0x00511CAF File Offset: 0x005100AF
		private void _onGoLearningButtonClick()
		{
		}

		// Token: 0x06011752 RID: 71506 RVA: 0x00511CB1 File Offset: 0x005100B1
		private void _onGoRewardButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPGraduationFrame>(FrameLayer.Middle, this.relationData, string.Empty);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPGraduationScoreChange, this.graduationScore, null, null, null);
		}

		// Token: 0x06011753 RID: 71507 RVA: 0x00511CE7 File Offset: 0x005100E7
		private void _onGraduationButtonClick()
		{
			NpcParser.OnClickLinkByNpcId(2020);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<RelationFrameNew>(null, false);
		}

		// Token: 0x0400B53F RID: 46399
		private RelationData relationData;

		// Token: 0x0400B540 RID: 46400
		private List<TAPLearningRewardItem> rewardItemList = new List<TAPLearningRewardItem>();

		// Token: 0x0400B541 RID: 46401
		private List<GameObject> rewardRoot = new List<GameObject>();

		// Token: 0x0400B542 RID: 46402
		private MasterTaskShareData tempData = new MasterTaskShareData();

		// Token: 0x0400B543 RID: 46403
		private int graduationScore;

		// Token: 0x0400B544 RID: 46404
		private Text mScore;

		// Token: 0x0400B545 RID: 46405
		private Text mLevel;

		// Token: 0x0400B546 RID: 46406
		private Slider mFront;

		// Token: 0x0400B547 RID: 46407
		private GameObject mRoot1;

		// Token: 0x0400B548 RID: 46408
		private GameObject mRoot2;

		// Token: 0x0400B549 RID: 46409
		private GameObject mRoot3;

		// Token: 0x0400B54A RID: 46410
		private GameObject mRoot4;

		// Token: 0x0400B54B RID: 46411
		private GameObject mRoot5;

		// Token: 0x0400B54C RID: 46412
		private Text mSchedule1;

		// Token: 0x0400B54D RID: 46413
		private Text mSchedule2;

		// Token: 0x0400B54E RID: 46414
		private Text mSchedule3;

		// Token: 0x0400B54F RID: 46415
		private Text mSchedule4;

		// Token: 0x0400B550 RID: 46416
		private Text mSchedule5;

		// Token: 0x0400B551 RID: 46417
		private Button mGoMission;

		// Token: 0x0400B552 RID: 46418
		private Button mGoLearning;

		// Token: 0x0400B553 RID: 46419
		private Button mGoReward;

		// Token: 0x0400B554 RID: 46420
		private GameObject mScoreBarGo;

		// Token: 0x0400B555 RID: 46421
		private Text mLearningValue;

		// Token: 0x0400B556 RID: 46422
		private Button mGraduation;

		// Token: 0x0400B557 RID: 46423
		private GetAniValue mScoreBar;
	}
}
