using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD9 RID: 7129
	public class TAPMissionFrame : ClientFrame
	{
		// Token: 0x0601175E RID: 71518 RVA: 0x00511FD7 File Offset: 0x005103D7
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPMission";
		}

		// Token: 0x0601175F RID: 71519 RVA: 0x00511FDE File Offset: 0x005103DE
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

		// Token: 0x06011760 RID: 71520 RVA: 0x0051200E File Offset: 0x0051040E
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x06011761 RID: 71521 RVA: 0x00512022 File Offset: 0x00510422
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMyPupilMissionUpdate, new ClientEventSystem.UIEventHandler(this.OnMyPupilMissionUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPReportTeacherSuccess, new ClientEventSystem.UIEventHandler(this.OnTAPReportTeacherUpdate));
		}

		// Token: 0x06011762 RID: 71522 RVA: 0x0051205A File Offset: 0x0051045A
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMyPupilMissionUpdate, new ClientEventSystem.UIEventHandler(this.OnMyPupilMissionUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPReportTeacherSuccess, new ClientEventSystem.UIEventHandler(this.OnTAPReportTeacherUpdate));
		}

		// Token: 0x06011763 RID: 71523 RVA: 0x00512094 File Offset: 0x00510494
		private void _InitComUIList()
		{
			this.mMissionScrollView.Initialize();
			this.mMissionScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateMissionBind(item);
				}
			};
			this.mMissionScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
			this.mRewardScrollView.Initialize();
			this.mRewardScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRewardBind(item);
				}
			};
			this.mRewardScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x06011764 RID: 71524 RVA: 0x00512138 File Offset: 0x00510538
		private void _UpdateMissionBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (item.m_index >= this.myMissionList.Count)
			{
				return;
			}
			MissionInfo missionInfo = this.myMissionList[item.m_index];
			Text com = component.GetCom<Text>("MissionName");
			Text com2 = component.GetCom<Text>("Schedule");
			Text com3 = component.GetCom<Text>("Score");
			Image com4 = component.GetCom<Image>("bg");
			GameObject gameObject = component.GetGameObject("ScheduleImage");
			if (item.m_index % 2 == 0)
			{
				com4.CustomActive(true);
			}
			else
			{
				com4.CustomActive(false);
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				com.text = tableItem.TaskName;
				string text = Utility.ParseMissionTextForMissionInfo(missionInfo, false, false, true);
				if (text == "已完成")
				{
					gameObject.CustomActive(true);
					com2.text = string.Empty;
				}
				else
				{
					gameObject.CustomActive(false);
					com2.text = text;
				}
				string award = tableItem.Award;
				int num = -1;
				int num2 = -1;
				string[] array = award.Split(new char[]
				{
					'_'
				});
				if (array.Length != 2)
				{
					return;
				}
				int.TryParse(array[0], out num);
				int.TryParse(array[1], out num2);
				if (num != -1 && num2 != -1)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						com3.text = num2.ToString();
					}
				}
			}
		}

		// Token: 0x06011765 RID: 71525 RVA: 0x005122F0 File Offset: 0x005106F0
		private void _UpdateRewardBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (this.myRewardList.Count <= 0)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("rewardRoot");
			ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(gameObject);
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(this.myRewardList[item.m_index].tableID, 100, 0);
			if (ItemDetailData == null)
			{
				return;
			}
			ItemDetailData.Count = this.myRewardList[item.m_index].count;
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
		}

		// Token: 0x06011766 RID: 71526 RVA: 0x005123CD File Offset: 0x005107CD
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x06011767 RID: 71527 RVA: 0x005123E8 File Offset: 0x005107E8
		private void _InitData()
		{
			this.myMissionList.Clear();
			this.myRewardList.Clear();
			if (this.relationData.tapType == TAPType.Pupil)
			{
				MasterTaskShareData myPupilData = DataManager<TAPNewDataManager>.GetInstance().GetMyPupilData(this.relationData.uid);
				this.thisGiftType = TAPGiftType.TeacherDailyGift;
				this._InitRewardList();
				if (myPupilData != null)
				{
					List<MissionInfo> list = myPupilData.dailyTasks.ToList<MissionInfo>();
					for (int i = 0; i < list.Count; i++)
					{
						this.myMissionList.Add(list[i]);
					}
					this._UpdateUI(this.myMissionList);
				}
			}
			else
			{
				this.thisGiftType = TAPGiftType.PupilDailyGift;
				this._InitRewardList();
				List<MissionInfo> dailyMission = DataManager<TAPNewDataManager>.GetInstance().GetDailyMission();
				for (int j = 0; j < dailyMission.Count; j++)
				{
					this.myMissionList.Add(dailyMission[j]);
				}
				if (this.myMissionList != null)
				{
					this._UpdateUI(this.myMissionList);
				}
			}
		}

		// Token: 0x06011768 RID: 71528 RVA: 0x005124E8 File Offset: 0x005108E8
		private void _InitRewardList()
		{
			this.myRewardList.Clear();
			this.myRewardList = DataManager<TAPNewDataManager>.GetInstance()._GetRewardItemTableList((int)this.thisGiftType);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MasterSysGiftTable>();
		}

		// Token: 0x06011769 RID: 71529 RVA: 0x00512521 File Offset: 0x00510921
		private void _ClearData()
		{
			this.myMissionList.Clear();
			this.myRewardList.Clear();
			this.relationData = null;
			this.thisGiftType = TAPGiftType.None;
		}

		// Token: 0x0601176A RID: 71530 RVA: 0x00512547 File Offset: 0x00510947
		private void _ClearUI()
		{
		}

		// Token: 0x0601176B RID: 71531 RVA: 0x0051254C File Offset: 0x0051094C
		private void _UpdateUI(List<MissionInfo> missionList)
		{
			if (this.relationData.tapType == TAPType.Teacher)
			{
				this.mTitleText.text = string.Format(TR.Value("tap_mission_daily_pupil_text"), this.relationData.name);
			}
			else
			{
				this.mTitleText.text = string.Format(TR.Value("tap_mission_daily_teacher_text"), this.relationData.name);
			}
			if (missionList.Count != 0)
			{
				this.mMissionScrollView.SetElementAmount(missionList.Count);
			}
			if (this.myRewardList != null && this.myRewardList.Count != 0)
			{
				this.mRewardScrollView.SetElementAmount(this.myRewardList.Count);
			}
			this.mUnFinish.CustomActive(false);
			this.mFinished.CustomActive(false);
			this.mReportTeacher.CustomActive(false);
			this.mReceiveReward.CustomActive(false);
			if (this.relationData.dailyTaskState == 1)
			{
				if (this.relationData.tapType == TAPType.Pupil)
				{
					this.mUnFinish.CustomActive(true);
				}
				else
				{
					this.mReportTeacher.CustomActive(true);
				}
			}
			else if (this.relationData.dailyTaskState == 2)
			{
				this.mReceiveReward.CustomActive(true);
			}
			else if (this.relationData.dailyTaskState == 3)
			{
				this.mFinished.CustomActive(true);
			}
			else if (this.relationData.dailyTaskState == 4 && this.relationData.tapType == TAPType.Pupil)
			{
				this.mReceiveReward.CustomActive(true);
			}
		}

		// Token: 0x0601176C RID: 71532 RVA: 0x005126EC File Offset: 0x00510AEC
		private void OnMyPupilMissionUpdate(UIEvent uiEvent)
		{
			RelationData relationData = (RelationData)uiEvent.Param1;
			if (relationData != null)
			{
				this.relationData = relationData;
			}
			this._InitData();
		}

		// Token: 0x0601176D RID: 71533 RVA: 0x00512718 File Offset: 0x00510B18
		private void OnTAPReportTeacherUpdate(UIEvent uiEvent)
		{
			string talkStr = TR.Value("tap_talk_teacher_finish_mission");
			DataManager<TAPNewDataManager>.GetInstance()._TalkToPeople(this.relationData, talkStr);
		}

		// Token: 0x0601176E RID: 71534 RVA: 0x00512744 File Offset: 0x00510B44
		protected override void _bindExUI()
		{
			this.mTitleText = this.mBind.GetCom<Text>("TitleText");
			this.mRewardScrollView = this.mBind.GetCom<ComUIListScript>("RewardScrollView");
			this.mSubmit = this.mBind.GetCom<Button>("submit");
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.AddListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mReportTeacher = this.mBind.GetCom<Button>("reportTeacher");
			if (null != this.mReportTeacher)
			{
				this.mReportTeacher.onClick.AddListener(new UnityAction(this._onReportTeacherButtonClick));
			}
			this.mReceiveReward = this.mBind.GetCom<Button>("receiveReward");
			if (null != this.mReceiveReward)
			{
				this.mReceiveReward.onClick.AddListener(new UnityAction(this._onReceiveRewardButtonClick));
			}
			this.mMissionScrollView = this.mBind.GetCom<ComUIListScript>("MissionScrollView");
			this.mUnFinish = this.mBind.GetGameObject("UnFinish");
			this.mFinished = this.mBind.GetGameObject("Finished");
		}

		// Token: 0x0601176F RID: 71535 RVA: 0x00512888 File Offset: 0x00510C88
		protected override void _unbindExUI()
		{
			this.mTitleText = null;
			this.mRewardScrollView = null;
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.RemoveListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mSubmit = null;
			if (null != this.mReportTeacher)
			{
				this.mReportTeacher.onClick.RemoveListener(new UnityAction(this._onReportTeacherButtonClick));
			}
			this.mReportTeacher = null;
			if (null != this.mReceiveReward)
			{
				this.mReceiveReward.onClick.RemoveListener(new UnityAction(this._onReceiveRewardButtonClick));
			}
			this.mReceiveReward = null;
			this.mMissionScrollView = null;
			this.mUnFinish = null;
			this.mFinished = null;
		}

		// Token: 0x06011770 RID: 71536 RVA: 0x00512954 File Offset: 0x00510D54
		private void _onSubmitButtonClick()
		{
		}

		// Token: 0x06011771 RID: 71537 RVA: 0x00512956 File Offset: 0x00510D56
		private void _onReportTeacherButtonClick()
		{
			DataManager<TAPNewDataManager>.GetInstance().SendReportDailyMission(this.relationData.uid);
		}

		// Token: 0x06011772 RID: 71538 RVA: 0x0051296D File Offset: 0x00510D6D
		private void _onReceiveRewardButtonClick()
		{
			if (this.relationData.tapType == TAPType.Pupil)
			{
				DataManager<TAPNewDataManager>.GetInstance().SendFinishDailyMission(this.relationData.uid);
			}
			else
			{
				DataManager<TAPNewDataManager>.GetInstance().SendFinishDailyMission(0UL);
			}
		}

		// Token: 0x0400B562 RID: 46434
		private RelationData relationData;

		// Token: 0x0400B563 RID: 46435
		private List<MissionInfo> myMissionList = new List<MissionInfo>();

		// Token: 0x0400B564 RID: 46436
		private List<TAPMissionReward> myRewardList = new List<TAPMissionReward>();

		// Token: 0x0400B565 RID: 46437
		private TAPGiftType thisGiftType;

		// Token: 0x0400B566 RID: 46438
		private Text mTitleText;

		// Token: 0x0400B567 RID: 46439
		private ComUIListScript mRewardScrollView;

		// Token: 0x0400B568 RID: 46440
		private Button mSubmit;

		// Token: 0x0400B569 RID: 46441
		private Button mReportTeacher;

		// Token: 0x0400B56A RID: 46442
		private Button mReceiveReward;

		// Token: 0x0400B56B RID: 46443
		private ComUIListScript mMissionScrollView;

		// Token: 0x0400B56C RID: 46444
		private GameObject mUnFinish;

		// Token: 0x0400B56D RID: 46445
		private GameObject mFinished;
	}
}
