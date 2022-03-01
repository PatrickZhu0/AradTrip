using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014C9 RID: 5321
	public class ChallengeMapItem : MonoBehaviour
	{
		// Token: 0x0600CE3E RID: 52798 RVA: 0x0032D046 File Offset: 0x0032B446
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE3F RID: 52799 RVA: 0x0032D04E File Offset: 0x0032B44E
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE40 RID: 52800 RVA: 0x0032D05C File Offset: 0x0032B45C
		private void BindEvents()
		{
			if (this.chapterButton != null)
			{
				this.chapterButton.onClick.RemoveAllListeners();
				this.chapterButton.onClick.AddListener(new UnityAction(this.OnChapterItemClick));
			}
			if (this.chapterSettingButton != null)
			{
				this.chapterSettingButton.onClick.RemoveAllListeners();
				this.chapterSettingButton.onClick.AddListener(new UnityAction(this.OnChapterItemClick));
			}
		}

		// Token: 0x0600CE41 RID: 52801 RVA: 0x0032D0E4 File Offset: 0x0032B4E4
		private void UnBindEvents()
		{
			if (this.chapterButton != null)
			{
				this.chapterButton.onClick.RemoveAllListeners();
			}
			if (this.chapterSettingButton != null)
			{
				this.chapterSettingButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CE42 RID: 52802 RVA: 0x0032D133 File Offset: 0x0032B533
		private void ClearData()
		{
			this._dungeonId = 0;
			this._dungeonTable = null;
			this._activityDungeonSub = null;
		}

		// Token: 0x0600CE43 RID: 52803 RVA: 0x0032D14A File Offset: 0x0032B54A
		private void OnEnable()
		{
		}

		// Token: 0x0600CE44 RID: 52804 RVA: 0x0032D14C File Offset: 0x0032B54C
		private void OnDisable()
		{
		}

		// Token: 0x0600CE45 RID: 52805 RVA: 0x0032D150 File Offset: 0x0032B550
		public void InitItem(ChaptertDungeonUnit chapterDungeonUnit, OnChallengeMapItemClicked onMapItemClicked, ActivityDungeonSub activityDungeonSub = null, bool isDefaultSelected = false)
		{
			if (chapterDungeonUnit == null)
			{
				Logger.LogErrorFormat("ChapterDungeonUnit is null", new object[0]);
				return;
			}
			this._dungeonUnit = chapterDungeonUnit;
			this._dungeonId = this._dungeonUnit.dungeonID;
			this._onMapItemClicked = onMapItemClicked;
			this._activityDungeonSub = activityDungeonSub;
			this._isSelected = isDefaultSelected;
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._dungeonId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("dungeonTable is null", new object[0]);
				return;
			}
			if (this.commonHelpNewAssistant != null)
			{
				this.commonHelpNewAssistant.HelpId = this._dungeonId;
			}
			this.InitView();
		}

		// Token: 0x0600CE46 RID: 52806 RVA: 0x0032D206 File Offset: 0x0032B606
		private void InitView()
		{
			this.InitItemPosition();
			this.InitItemImage();
			this.InitItemContent();
			this.UpdateItemSelected();
		}

		// Token: 0x0600CE47 RID: 52807 RVA: 0x0032D220 File Offset: 0x0032B620
		private void InitItemPosition()
		{
			base.gameObject.transform.localPosition = this._dungeonUnit.position;
			this.sourcePosition.localPosition = this._dungeonUnit.angleSourcePosition;
			this.targetPosition.localPosition = this._dungeonUnit.angleTargetPosition;
			this.targetRightPosition.localPosition = this._dungeonUnit.angleTargetRightPosition;
			this.contentRoot.localPosition = this._dungeonUnit.thumbOffset;
		}

		// Token: 0x0600CE48 RID: 52808 RVA: 0x0032D2A0 File Offset: 0x0032B6A0
		private void InitItemContent()
		{
			if (this.name != null)
			{
				this.name.text = this._dungeonTable.Name;
			}
			if (this.comChapterDungeonUnit != null)
			{
				this.comChapterDungeonUnit.SetType(ComChapterDungeonUnit.eMissionType.None);
			}
			if (this._dungeonTable.SubType == DungeonTable.eSubType.S_DEVILDDOM)
			{
				if (this.recommendLevelText != null)
				{
					this.recommendLevelText.text = string.Format(TR.Value("challenge_chapter_recommend_level"), this._dungeonTable.RecommendLevel);
				}
				if (this.challengeFlag != null)
				{
					this.challengeFlag.CustomActive(ChapterSelectFrame.IsInChallenge(this._dungeonId));
				}
				if (ChapterUtility.HasMissionByDungeonID(this._dungeonId) && this.comChapterDungeonUnit != null)
				{
					this.comChapterDungeonUnit.SetType(ComChapterDungeonUnit.eMissionType.Main);
				}
				if (this.commonHelpNewAssistant != null)
				{
					this.commonHelpNewAssistant.gameObject.CustomActive(false);
				}
			}
			else
			{
				if (this.recommendLevelText != null)
				{
					this.recommendLevelText.text = this._dungeonTable.RecommendLevel;
				}
				if (this.challengeFlag != null)
				{
					this.challengeFlag.CustomActive(false);
				}
				if (this.commonHelpNewAssistant != null)
				{
					this.commonHelpNewAssistant.gameObject.CustomActive(true);
				}
			}
			this.UpdateDungeonItemContent();
		}

		// Token: 0x0600CE49 RID: 52809 RVA: 0x0032D420 File Offset: 0x0032B820
		public void UpdateDungeonItemContent()
		{
			if (this._activityDungeonSub == null)
			{
				return;
			}
			if (DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId))
			{
				if (this._activityDungeonSub.state == eActivityDungeonState.End || this._activityDungeonSub.state == eActivityDungeonState.None)
				{
					base.gameObject.CustomActive(false);
					return;
				}
				if (DataManager<TimeManager>.GetInstance().GetServerTime() > this._activityDungeonSub.endtime)
				{
					base.gameObject.CustomActive(false);
					return;
				}
			}
			this.ResetItemContent();
			if (this.chapterDropText != null)
			{
				this.chapterDropText.text = this._activityDungeonSub.table.ExtraDescription;
			}
			this.UpdateDungeonItemNumberAndTimes();
			this.UpdateDungeonItemState();
		}

		// Token: 0x0600CE4A RID: 52810 RVA: 0x0032D4E0 File Offset: 0x0032B8E0
		private void UpdateDungeonItemNumberAndTimes()
		{
			if (this._activityDungeonSub.table == null)
			{
				return;
			}
			if (this.chapterNumberRoot != null)
			{
				this.chapterNumberRoot.gameObject.CustomActive(this._activityDungeonSub.table.ShowCount);
			}
			this.UpdateItemNumbers(false);
			if (this._activityDungeonSub.table.ShowCount)
			{
				int num = 0;
				int maxTime = 0;
				if (!DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId))
				{
					num = DungeonUtility.GetDungeonDailyLeftTimes(this._dungeonId);
					maxTime = DungeonUtility.GetDungeonDailyMaxTimes(this._dungeonId);
					this.UpdateDungeonDailyNumber(num, maxTime);
				}
				if (DungeonUtility.IsWeekHellEntryDungeon(this._dungeonId))
				{
					if (DungeonUtility.GetWeekHellPreTaskState(this._dungeonId) == WeekHellPreTaskState.IsFinished && ChapterUtility.GetDungeonState(this._dungeonId) != ComChapterDungeonUnit.eState.Locked)
					{
						int dungeonWeekLeftTimes = DungeonUtility.GetDungeonWeekLeftTimes(this._dungeonId);
						int dungeonWeekMaxTimes = DungeonUtility.GetDungeonWeekMaxTimes(this._dungeonId);
						this.UpdateDungeonWeekNumber(dungeonWeekLeftTimes, dungeonWeekMaxTimes);
						if (num > dungeonWeekLeftTimes)
						{
							num = dungeonWeekLeftTimes;
							this.UpdateDungeonDailyNumber(num, maxTime);
						}
					}
					else
					{
						this.UpdateItemNumbers(false);
					}
				}
			}
			if (DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId))
			{
				if (this.chapterActivityRoot != null)
				{
					this.chapterActivityRoot.gameObject.CustomActive(true);
				}
				if (this.simpleTimer != null)
				{
					this.simpleTimer.SetCountdown((int)(this._activityDungeonSub.endtime - DataManager<TimeManager>.GetInstance().GetServerTime()));
					this.simpleTimer.StartTimer();
				}
			}
		}

		// Token: 0x0600CE4B RID: 52811 RVA: 0x0032D65C File Offset: 0x0032BA5C
		private void UpdateDungeonItemState()
		{
			if (this._activityDungeonSub == null)
			{
				return;
			}
			this._isLocked = false;
			eActivityDungeonState state = this._activityDungeonSub.state;
			if (state != eActivityDungeonState.Start)
			{
				if (state == eActivityDungeonState.None || state == eActivityDungeonState.LevelLimit)
				{
					this._isLocked = true;
					if (this.itemLock != null)
					{
						this.itemLock.gameObject.CustomActive(true);
					}
					if (this.lockLevelText != null)
					{
						this.lockLevelText.gameObject.CustomActive(true);
						this.lockLevelText.text = string.Format(TR.Value("challenge_chapter_level_unlock"), this._activityDungeonSub.level);
					}
					this.UpdateItemNumbers(false);
				}
			}
			else if (this.recommendLevelText != null)
			{
				this.recommendLevelText.gameObject.CustomActive(true);
				this.recommendLevelText.text = string.Format(TR.Value("challenge_chapter_recommend_level"), this._activityDungeonSub.GetDungeonRecommendLevel());
			}
		}

		// Token: 0x0600CE4C RID: 52812 RVA: 0x0032D770 File Offset: 0x0032BB70
		private void ResetItemContent()
		{
			if (this.itemLock != null)
			{
				this.itemLock.gameObject.CustomActive(false);
			}
			if (this.recommendLevelText != null)
			{
				this.recommendLevelText.gameObject.CustomActive(false);
			}
			if (this.lockLevelText != null)
			{
				this.lockLevelText.gameObject.CustomActive(false);
			}
			if (this.chapterNumberRoot != null)
			{
				this.chapterNumberRoot.gameObject.CustomActive(false);
			}
			if (this.chapterActivityRoot != null)
			{
				this.chapterActivityRoot.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600CE4D RID: 52813 RVA: 0x0032D828 File Offset: 0x0032BC28
		private void InitItemImage()
		{
			if (this.backImage != null)
			{
				if (string.IsNullOrEmpty(this._dungeonTable.TumbPath))
				{
					this.backImage.sprite = null;
				}
				else
				{
					ETCImageLoader.LoadSprite(ref this.backImage, this._dungeonTable.TumbPath, true);
				}
			}
			if (this._dungeonTable.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
			{
				this.UpdateSpecialFrame(true);
			}
			else
			{
				this.UpdateSpecialFrame(false);
			}
		}

		// Token: 0x0600CE4E RID: 52814 RVA: 0x0032D8A9 File Offset: 0x0032BCA9
		private void UpdateItemSelected()
		{
			this.UpdateItemSelectedEffect(this._isSelected);
		}

		// Token: 0x0600CE4F RID: 52815 RVA: 0x0032D8B8 File Offset: 0x0032BCB8
		public void UpdateSelectedStateByDungeonId(int selectedDungeonId)
		{
			if (this._dungeonId == selectedDungeonId)
			{
				if (!this._isSelected)
				{
					this._isSelected = true;
					this.UpdateItemSelectedEffect(this._isSelected);
				}
			}
			else
			{
				this._isSelected = false;
				this.UpdateItemSelectedEffect(this._isSelected);
			}
		}

		// Token: 0x0600CE50 RID: 52816 RVA: 0x0032D907 File Offset: 0x0032BD07
		private void UpdateItemSelectedEffect(bool flag)
		{
		}

		// Token: 0x0600CE51 RID: 52817 RVA: 0x0032D90C File Offset: 0x0032BD0C
		private void UpdateItemNumbers(bool flag)
		{
			if (this.todayNumberText != null)
			{
				this.todayNumberText.gameObject.CustomActive(flag);
			}
			if (this.weekNumberText != null)
			{
				this.weekNumberText.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CE52 RID: 52818 RVA: 0x0032D960 File Offset: 0x0032BD60
		private void OnChapterItemClick()
		{
			if (this._isLocked)
			{
				return;
			}
			if (this._activityDungeonSub != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < this._activityDungeonSub.level)
			{
				SystemNotifyManager.SystemNotify(1008, string.Empty);
				return;
			}
			if (DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId))
			{
				if (this._activityDungeonSub != null && this._activityDungeonSub.isfinish)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fallen_hell_num_des"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (DungeonUtility.GetDungeonDailyLeftTimes(this._dungeonId) <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fallen_hell_num_des"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (this._activityDungeonSub != null && DataManager<TimeManager>.GetInstance().GetServerTime() > this._activityDungeonSub.endtime)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("activity_limit_time_over_tip"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
			}
			if (DungeonUtility.IsWeekHellEntryDungeon(this._dungeonId))
			{
				WeekHellPreTaskState weekHellPreTaskState = DungeonUtility.GetWeekHellPreTaskState(this._dungeonId);
				if (weekHellPreTaskState == WeekHellPreTaskState.None)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("activity_week_hell_pre_task_not_exist"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (weekHellPreTaskState == WeekHellPreTaskState.UnReceived)
				{
					ChallengeUtility.OnShowWeekHellPreTaskUnReceivedTip(this._dungeonId);
					return;
				}
				if (weekHellPreTaskState == WeekHellPreTaskState.IsFinished)
				{
					if (DungeonUtility.GetDungeonWeekLeftTimes(this._dungeonId) <= 0)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("activity_week_hell_week_time_zero"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
					if (DungeonUtility.GetDungeonDailyLeftTimes(this._dungeonId) <= 0)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fallen_hell_num_des"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
			}
			this._isSelected = true;
			this.UpdateItemSelectedEffect(this._isSelected);
			if (this._onMapItemClicked != null)
			{
				this._onMapItemClicked(this._dungeonId);
			}
		}

		// Token: 0x0600CE53 RID: 52819 RVA: 0x0032DB02 File Offset: 0x0032BF02
		private void UpdateSpecialFrame(bool flag)
		{
			if (this.specialFrame != null)
			{
				this.specialFrame.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CE54 RID: 52820 RVA: 0x0032DB28 File Offset: 0x0032BF28
		private void UpdateDungeonDailyNumber(int leftTime, int maxTime)
		{
			if (this.todayNumberText != null)
			{
				string text = string.Format(TR.Value("challenge_chapter_today_number"), leftTime, maxTime);
				this.todayNumberText.text = text;
				this.todayNumberText.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600CE55 RID: 52821 RVA: 0x0032DB80 File Offset: 0x0032BF80
		private void UpdateDungeonWeekNumber(int leftTime, int maxTime)
		{
			if (this.weekNumberText != null)
			{
				string text = string.Format(TR.Value("challenge_chapter_week_number"), leftTime, maxTime);
				this.weekNumberText.text = text;
				this.weekNumberText.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600CE56 RID: 52822 RVA: 0x0032DBD7 File Offset: 0x0032BFD7
		public int GetChapterDungeonId()
		{
			return this._dungeonId;
		}

		// Token: 0x04007866 RID: 30822
		private ChaptertDungeonUnit _dungeonUnit;

		// Token: 0x04007867 RID: 30823
		private int _dungeonId;

		// Token: 0x04007868 RID: 30824
		private bool _isSelected;

		// Token: 0x04007869 RID: 30825
		private bool _isLocked;

		// Token: 0x0400786A RID: 30826
		private DungeonTable _dungeonTable;

		// Token: 0x0400786B RID: 30827
		private ActivityDungeonSub _activityDungeonSub;

		// Token: 0x0400786C RID: 30828
		private OnChallengeMapItemClicked _onMapItemClicked;

		// Token: 0x0400786D RID: 30829
		[Space(10f)]
		[Header("Content")]
		[Space(5f)]
		[SerializeField]
		private Text name;

		// Token: 0x0400786E RID: 30830
		[SerializeField]
		private Image backImage;

		// Token: 0x0400786F RID: 30831
		[Space(20f)]
		[Header("ChapterState")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemLock;

		// Token: 0x04007870 RID: 30832
		[SerializeField]
		private Text lockLevelText;

		// Token: 0x04007871 RID: 30833
		[SerializeField]
		private Text recommendLevelText;

		// Token: 0x04007872 RID: 30834
		[SerializeField]
		private GameObject chapterNumberRoot;

		// Token: 0x04007873 RID: 30835
		[SerializeField]
		private Text todayNumberText;

		// Token: 0x04007874 RID: 30836
		[SerializeField]
		private Text weekNumberText;

		// Token: 0x04007875 RID: 30837
		[SerializeField]
		private Image specialFrame;

		// Token: 0x04007876 RID: 30838
		[SerializeField]
		private Text chapterDropText;

		// Token: 0x04007877 RID: 30839
		[SerializeField]
		private GameObject chapterActivityRoot;

		// Token: 0x04007878 RID: 30840
		[SerializeField]
		private GameObject chapterActivityFlag;

		// Token: 0x04007879 RID: 30841
		[SerializeField]
		private Text chapterActivityLeftTimeText;

		// Token: 0x0400787A RID: 30842
		[SerializeField]
		private SimpleTimer simpleTimer;

		// Token: 0x0400787B RID: 30843
		[Space(10f)]
		[Header("Position")]
		[Space(5f)]
		[SerializeField]
		private RectTransform sourcePosition;

		// Token: 0x0400787C RID: 30844
		[SerializeField]
		private RectTransform targetPosition;

		// Token: 0x0400787D RID: 30845
		[SerializeField]
		private RectTransform targetRightPosition;

		// Token: 0x0400787E RID: 30846
		[SerializeField]
		private RectTransform contentRoot;

		// Token: 0x0400787F RID: 30847
		[Space(10f)]
		[Header("Button")]
		[Space(5f)]
		[SerializeField]
		private Button chapterButton;

		// Token: 0x04007880 RID: 30848
		[SerializeField]
		private Button chapterSettingButton;

		// Token: 0x04007881 RID: 30849
		[SerializeField]
		private CommonHelpNewAssistant commonHelpNewAssistant;

		// Token: 0x04007882 RID: 30850
		[SerializeField]
		private GameObject challengeFlag;

		// Token: 0x04007883 RID: 30851
		[SerializeField]
		private ComChapterDungeonUnit comChapterDungeonUnit;
	}
}
