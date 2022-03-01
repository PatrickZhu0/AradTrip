using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace ActivityLimitTime
{
	// Token: 0x020018C7 RID: 6343
	public class ActivityLTTab : ActivityLTItem<ActivityLTTab>
	{
		// Token: 0x0600F7D6 RID: 63446 RVA: 0x00434150 File Offset: 0x00432550
		public override void Init(GameObject parent, ActivityLimitTimeFrame frame, ActivityLimitTimeData data)
		{
			this.goParent = parent;
			this.currFrame = frame;
			this.currActivityData = data;
			this.Create();
			if (this.goSelf != null)
			{
				this.mBind = this.goSelf.GetComponent<ComCommonBind>();
				if (this.mBind)
				{
					this.redPoint = this.mBind.GetGameObject("RedPointGo");
					this.redPoint.CustomActive(false);
					this.activityTypeImgNew = this.mBind.GetGameObject("TypeImgNew");
					this.activityTypeImgNew.CustomActive(false);
					this.activityTypeImgLT = this.mBind.GetGameObject("TypeImgLT");
					this.activityTypeImgLT.CustomActive(false);
					this.tabTitle_select = this.mBind.GetCom<Text>("Title_Select");
					this.tabTitle_unSelect = this.mBind.GetCom<Text>("Title_UnSelect");
					this.bg_Unselect = this.mBind.GetGameObject("Bg_UnSelect");
					this.bg_select = this.mBind.GetGameObject("Bg_Select");
					if (this.bg_select)
					{
						this.bg_select.CustomActive(false);
					}
					if (this.bg_Unselect)
					{
						this.bg_Unselect.CustomActive(true);
					}
					this.tabToggle = this.mBind.GetCom<Toggle>("TabToggle");
					this.tabToggle.onValueChanged.RemoveAllListeners();
					this.tabToggle.isOn = (this.isSelected = false);
					if (this.currFrame != null)
					{
						this.tabToggle.group = this.currFrame.GetCurrToggleGroup();
					}
					this.tabToggle.onValueChanged.RemoveAllListeners();
					this.tabToggle.onValueChanged.AddListener(delegate(bool value)
					{
						this.SetDetailDataOnSelect(data.ActivityType, value);
					});
				}
				Utility.AttachTo(this.goSelf, this.goParent, false);
				this.SetDataToView();
				if (this.currActivityData != null)
				{
					this.UpdateRedPoint(this.currActivityData.activityDetailDataList);
				}
			}
		}

		// Token: 0x0600F7D7 RID: 63447 RVA: 0x00434375 File Offset: 0x00432775
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<ActivityItemObjectManager>.instance.GetActTabGo();
		}

		// Token: 0x0600F7D8 RID: 63448 RVA: 0x0043438D File Offset: 0x0043278D
		public override void Destory()
		{
			base.Destory();
			MonoSingleton<ActivityItemObjectManager>.instance.ReleaseActTabGo(this.goSelf);
			this.Reset();
		}

		// Token: 0x0600F7D9 RID: 63449 RVA: 0x004343AC File Offset: 0x004327AC
		public override void Reset()
		{
			base.Reset();
			this.redPoint = null;
			this.activityTypeImgNew = null;
			this.activityTypeImgLT = null;
			this.tabTitle_select = null;
			this.tabTitle_unSelect = null;
			this.bg_Unselect = null;
			this.bg_select = null;
			this.tabToggle = null;
			this.isSelected = false;
		}

		// Token: 0x0600F7DA RID: 63450 RVA: 0x00434400 File Offset: 0x00432800
		public void UpdateRedPoint(List<ActivityLimitTimeDetailData> detailDataList)
		{
			if (detailDataList != null)
			{
				ActivityLimitTimeData currActivityData = this.GetCurrActivityData();
				if (currActivityData == null)
				{
					return;
				}
				for (int i = 0; i < detailDataList.Count; i++)
				{
					if (detailDataList[i].ActivityDetailState == ActivityTaskState.Finished)
					{
						this.redPoint.CustomActive(true);
						break;
					}
					this.redPoint.CustomActive(false);
				}
				OpActivityTmpType activityType = currActivityData.ActivityType;
				if (activityType == OpActivityTmpType.OAT_HELL_TICKET_FOR_DRAW_PRIZE)
				{
					if (DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME) > 0)
					{
						this.redPoint.CustomActive(true);
					}
					else
					{
						this.redPoint.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600F7DB RID: 63451 RVA: 0x004344B5 File Offset: 0x004328B5
		public void ShowRedPoint(bool isShow)
		{
			this.redPoint.CustomActive(isShow);
		}

		// Token: 0x0600F7DC RID: 63452 RVA: 0x004344C3 File Offset: 0x004328C3
		public bool IsRedPointShow()
		{
			return !(this.redPoint == null) && this.redPoint.activeInHierarchy;
		}

		// Token: 0x0600F7DD RID: 63453 RVA: 0x004344E4 File Offset: 0x004328E4
		public void SetFashionToggleOnSelect(bool IsOpen)
		{
			if (this.EndTime != 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ControlFashionFrame, IsOpen, this.EndTime, null, null);
				this.tabToggle.isOn = IsOpen;
				if (this.bg_select)
				{
					this.bg_select.CustomActive(IsOpen);
				}
				if (this.bg_Unselect)
				{
					this.bg_Unselect.CustomActive(!IsOpen);
				}
			}
		}

		// Token: 0x0600F7DE RID: 63454 RVA: 0x00434568 File Offset: 0x00432968
		public void SetDetailDataOnSelect(OpActivityTmpType ActivityType, bool isSelected)
		{
			if (this.isSelected == isSelected)
			{
				return;
			}
			this.isSelected = isSelected;
			if (isSelected)
			{
				if (this.currActivityData != null && this.currFrame != null)
				{
					this.currFrame.ResetViewOnTabSelected(ActivityType, this);
				}
				if (this.bg_select)
				{
					this.bg_select.CustomActive(true);
				}
				if (this.bg_Unselect)
				{
					this.bg_Unselect.CustomActive(false);
				}
			}
			else
			{
				if (this.bg_select)
				{
					this.bg_select.CustomActive(false);
				}
				if (this.bg_Unselect)
				{
					this.bg_Unselect.CustomActive(true);
				}
			}
		}

		// Token: 0x0600F7DF RID: 63455 RVA: 0x00434627 File Offset: 0x00432A27
		public uint GetCurrActivityId()
		{
			if (this.currActivityData == null)
			{
				return 0U;
			}
			return this.currActivityData.DataId;
		}

		// Token: 0x0600F7E0 RID: 63456 RVA: 0x00434641 File Offset: 0x00432A41
		public ActivityLimitTimeData GetCurrActivityData()
		{
			return this.currActivityData;
		}

		// Token: 0x0600F7E1 RID: 63457 RVA: 0x00434649 File Offset: 0x00432A49
		public void SetSelected(bool value = true)
		{
			if (this.tabToggle)
			{
				this.tabToggle.isOn = value;
			}
		}

		// Token: 0x0600F7E2 RID: 63458 RVA: 0x00434667 File Offset: 0x00432A67
		public bool BeSelected()
		{
			return this.tabToggle && this.tabToggle.isOn;
		}

		// Token: 0x0600F7E3 RID: 63459 RVA: 0x00434688 File Offset: 0x00432A88
		protected override void SetDataToView()
		{
			if (this.currActivityData != null)
			{
				if (this.tabTitle_unSelect)
				{
					this.tabTitle_unSelect.text = this.currActivityData.ActivityTabName;
				}
				if (this.tabTitle_select)
				{
					this.tabTitle_select.text = this.currActivityData.ActivityTabName;
				}
				if (this.currActivityData.ActivityTabTag != ActivityTabTag.None)
				{
					ActivityTabTag activityTabTag = this.currActivityData.ActivityTabTag;
					if (activityTabTag != ActivityTabTag.New)
					{
						if (activityTabTag == ActivityTabTag.LimitTime)
						{
							if (this.activityTypeImgNew)
							{
								this.activityTypeImgNew.CustomActive(true);
							}
						}
					}
					else if (this.activityTypeImgNew)
					{
						this.activityTypeImgNew.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x0600F7E4 RID: 63460 RVA: 0x0043475D File Offset: 0x00432B5D
		public override void RefreshView(ActivityLimitTimeData data)
		{
			this.currActivityData = data;
			this.SetDataToView();
		}

		// Token: 0x04009901 RID: 39169
		private Toggle tabToggle;

		// Token: 0x04009902 RID: 39170
		private GameObject redPoint;

		// Token: 0x04009903 RID: 39171
		private GameObject activityTypeImgNew;

		// Token: 0x04009904 RID: 39172
		private GameObject activityTypeImgLT;

		// Token: 0x04009905 RID: 39173
		private Text tabTitle_select;

		// Token: 0x04009906 RID: 39174
		private Text tabTitle_unSelect;

		// Token: 0x04009907 RID: 39175
		private GameObject bg_Unselect;

		// Token: 0x04009908 RID: 39176
		private GameObject bg_select;

		// Token: 0x04009909 RID: 39177
		private bool isSelected;

		// Token: 0x0400990A RID: 39178
		private int EndTime;
	}
}
