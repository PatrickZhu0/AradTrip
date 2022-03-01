using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ActivityLimitTime
{
	// Token: 0x020018C9 RID: 6345
	public class ActivityLTDetailContent : ActivityLTObject<ActivityLTDetailContent>
	{
		// Token: 0x0600F7EF RID: 63471 RVA: 0x00434A5C File Offset: 0x00432E5C
		public void Init(GameObject parent, ActivityLimitTimeFrame frame, ActivityLimitTimeDetailData data, OpActivityTmpType actType)
		{
			this.Create();
			this.goParent = parent;
			this.currFrame = frame;
			this.currActivityData = data;
			this.currActType = actType;
			if (this.goSelf != null)
			{
				this.mBind = this.goSelf.GetComponent<ComCommonBind>();
				if (this.mBind)
				{
					this.descText = this.mBind.GetCom<Text>("DescText");
					this.doneSlider = this.mBind.GetCom<Slider>("DoneSlider");
					this.doneText = this.mBind.GetCom<Text>("DoneText");
					this.awardParentGo = this.mBind.GetGameObject("AwardParent");
					this.receiveBtn = this.mBind.GetCom<Button>("ReceiveBtn");
					if (this.receiveBtn)
					{
						this.receiveBtn.onClick.RemoveAllListeners();
						this.receiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveTaskAward));
					}
					this.receiveBtnGo = this.mBind.GetGameObject("ReceiveBtnGo");
					this.receiveImgGo = this.mBind.GetGameObject("ReceivedImgGo");
					this.undoneImgGo = this.mBind.GetGameObject("UnDoneImgGo");
					this.taskScrollRect = this.mBind.GetCom<ScrollRect>("TaskParentScroll");
					this.scrollRectCanvas = this.mBind.GetCom<CanvasGroup>("ScrollCanvas");
					this.actLTSCrollCtrl = this.mBind.GetCom<ActivityLTScrollRectCtrl>("ActScrollCtrl");
					this.actLTSCrollCtrl.AddDragDirListener(new Action<ActivityLTScrollRectCtrl.DragDirection>(this.OnScrollDragDir));
					ScrollRect component = this.actLTSCrollCtrl.gameObject.GetComponent<ScrollRect>();
					if (component != null)
					{
						component.horizontalNormalizedPosition = 0f;
					}
				}
				Utility.AttachTo(this.goSelf, this.goParent, false);
				this.SetDataToView();
				this.doneSlider.CustomActive(true);
				if (actType == OpActivityTmpType.OAT_DAY_LOGIN || actType == OpActivityTmpType.OAT_DAILY_REWARD)
				{
					this.doneSlider.CustomActive(false);
				}
			}
		}

		// Token: 0x0600F7F0 RID: 63472 RVA: 0x00434C70 File Offset: 0x00433070
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<ActivityItemObjectManager>.instance.GetActDetailGo();
		}

		// Token: 0x0600F7F1 RID: 63473 RVA: 0x00434C88 File Offset: 0x00433088
		private void SetDataToView()
		{
			if (this.currActivityData != null)
			{
				this.SetActDetailDesc(this.currActivityData);
				this.doneSlider.maxValue = (float)this.currActivityData.TotalNum;
				this.doneSlider.value = (float)this.currActivityData.DoneNum;
				if (this.currActivityData.ActivityDetailState == ActivityTaskState.Over)
				{
					this.doneSlider.value = 100f;
					this.doneText.text = string.Format("{0}/{1}", this.currActivityData.TotalNum, this.currActivityData.TotalNum);
				}
				else
				{
					this.doneText.text = string.Format("{0}/{1}", this.currActivityData.DoneNum, this.currActivityData.TotalNum);
				}
				this.activityLTAwardIcons = new List<ActivityLTAwardIcon>();
				List<ActivityLimitTimeAward> awardDataList = this.currActivityData.awardDataList;
				if (awardDataList == null)
				{
					return;
				}
				if (awardDataList.Count > ActivityLTDetailContent.taskAwardCount)
				{
					this.SetScrollRectHorizonal(true);
					this.SetScrollViewportRayTarget(true);
				}
				else
				{
					this.SetScrollRectHorizonal(false);
					this.SetScrollViewportRayTarget(false);
				}
				for (int i = 0; i < awardDataList.Count; i++)
				{
					ActivityLTAwardIcon activityLTAwardIcon = new ActivityLTAwardIcon();
					if (this.awardParentGo)
					{
						activityLTAwardIcon.Init(this.awardParentGo, this.currFrame, awardDataList[i]);
						this.activityLTAwardIcons.Add(activityLTAwardIcon);
					}
				}
				this.ShowStateBtnByTaskState(this.currActivityData.ActivityDetailState);
			}
		}

		// Token: 0x0600F7F2 RID: 63474 RVA: 0x00434E1C File Offset: 0x0043321C
		public void RefreshView(ActivityLimitTimeDetailData data, OpActivityTmpType actType)
		{
			this.currActivityData = data;
			this.currActType = actType;
			if (this.activityLTAwardIcons != null)
			{
				for (int i = 0; i < this.activityLTAwardIcons.Count; i++)
				{
					this.activityLTAwardIcons[i].Destory();
				}
			}
			this.SetDataToView();
		}

		// Token: 0x0600F7F3 RID: 63475 RVA: 0x00434E75 File Offset: 0x00433275
		public uint GetCurrDetailDataId()
		{
			return this.currActivityData.DataId;
		}

		// Token: 0x0600F7F4 RID: 63476 RVA: 0x00434E84 File Offset: 0x00433284
		private void OnReceiveTaskAward()
		{
			if (this.currActivityData == null)
			{
				return;
			}
			if (this.currFrame == null)
			{
				return;
			}
			if (this.currFrame.GetSelectedActTab() != null)
			{
				uint currActivityId = this.currFrame.GetSelectedActTab().GetCurrActivityId();
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(currActivityId, this.currActivityData.DataId);
			}
		}

		// Token: 0x0600F7F5 RID: 63477 RVA: 0x00434EE8 File Offset: 0x004332E8
		private void ShowStateBtnByTaskState(ActivityTaskState taskState)
		{
			if (taskState != ActivityTaskState.Over)
			{
				if (taskState != ActivityTaskState.Finished)
				{
					this.undoneImgGo.CustomActive(true);
					this.receiveImgGo.CustomActive(false);
					this.receiveBtnGo.CustomActive(false);
				}
				else
				{
					this.undoneImgGo.CustomActive(false);
					this.receiveImgGo.CustomActive(false);
					this.receiveBtnGo.CustomActive(true);
				}
			}
			else
			{
				this.receiveBtnGo.CustomActive(false);
				this.undoneImgGo.CustomActive(false);
				this.receiveImgGo.CustomActive(true);
			}
		}

		// Token: 0x0600F7F6 RID: 63478 RVA: 0x00434F84 File Offset: 0x00433384
		public override void Destory()
		{
			if (this.goSelf)
			{
				if (this.activityLTAwardIcons != null)
				{
					for (int i = 0; i < this.activityLTAwardIcons.Count; i++)
					{
						this.activityLTAwardIcons[i].Destory();
					}
				}
				MonoSingleton<ActivityItemObjectManager>.instance.ReleaseActDetailGo(this.goSelf);
			}
			this.Reset();
		}

		// Token: 0x0600F7F7 RID: 63479 RVA: 0x00434FF0 File Offset: 0x004333F0
		public void Reset()
		{
			this.goParent = null;
			this.currFrame = null;
			this.currActivityData = null;
			this.goSelf = null;
			this.currActType = OpActivityTmpType.OAT_NONE;
			this.mBind = null;
			this.descText = null;
			this.awardParentGo = null;
			this.receiveBtn = null;
			this.activityLTAwardIcons = null;
			this.doneSlider = null;
			this.doneText = null;
			this.receiveBtnGo = null;
			this.receiveImgGo = null;
			this.undoneImgGo = null;
			this.scrollRectCanvas = null;
			this.SetScrollRectHorizonal(false);
			this.taskScrollRect = null;
			if (this.actLTSCrollCtrl != null)
			{
				this.actLTSCrollCtrl.RemoveAllDragDirListener();
			}
			this.SetScrollViewportRayTarget(false);
			this.actLTSCrollCtrl = null;
		}

		// Token: 0x0600F7F8 RID: 63480 RVA: 0x004350A8 File Offset: 0x004334A8
		private void SetActDetailDesc(ActivityLimitTimeDetailData currData)
		{
			if (this.descText.text == null)
			{
				return;
			}
			if (currData == null)
			{
				return;
			}
			if (this.currActType == OpActivityTmpType.OAT_NONE)
			{
				return;
			}
			int count = currData.ParamNums.Count;
			int[] array = new int[count + 1];
			array[0] = currData.TotalNum;
			for (int i = 1; i <= count; i++)
			{
				array[i] = this.currActivityData.ParamNums[i - 1];
			}
			OpActivityTmpType opActivityTmpType = this.currActType;
			IActivityDetailDesc activityDetailDesc;
			if (opActivityTmpType != OpActivityTmpType.OAT_DAY_COST_ITEM && opActivityTmpType != OpActivityTmpType.OAT_COST_ITEM)
			{
				if (opActivityTmpType != OpActivityTmpType.OAT_DAY_COMPLETE_DUNG && opActivityTmpType != OpActivityTmpType.OAT_COMPLETE_DUNG)
				{
					activityDetailDesc = new ActDetailBaseDesc();
				}
				else
				{
					activityDetailDesc = new ActDetailDungeonDesc();
				}
			}
			else
			{
				activityDetailDesc = new ActDetailItemDesc();
			}
			if (activityDetailDesc != null)
			{
				string text = activityDetailDesc.FormatActivityDesc(currData.ActivityTaskDesc, array);
				this.descText.text = text;
			}
		}

		// Token: 0x0600F7F9 RID: 63481 RVA: 0x00435194 File Offset: 0x00433594
		private void OnScrollDragDir(ActivityLTScrollRectCtrl.DragDirection dragDir)
		{
			switch (dragDir)
			{
			case ActivityLTScrollRectCtrl.DragDirection.Ready:
				this.OnMoveScrollToHorizon(true);
				break;
			case ActivityLTScrollRectCtrl.DragDirection.None:
				this.OnMoveScrollToHorizon(false);
				break;
			case ActivityLTScrollRectCtrl.DragDirection.Horizonal:
				this.OnMoveScrollToHorizon(true);
				break;
			case ActivityLTScrollRectCtrl.DragDirection.Vertical:
				this.OnMoveScrollToHorizon(false);
				break;
			}
		}

		// Token: 0x0600F7FA RID: 63482 RVA: 0x004351EC File Offset: 0x004335EC
		private void OnMoveScrollToHorizon(bool bHorizonal)
		{
			this.SetScrollViewportRayTarget(bHorizonal);
		}

		// Token: 0x0600F7FB RID: 63483 RVA: 0x004351F5 File Offset: 0x004335F5
		private void SetScrollViewportRayTarget(bool enabled)
		{
			if (this.actLTSCrollCtrl == null)
			{
				return;
			}
			if (this.actLTSCrollCtrl.GetScrollViewportImg())
			{
				this.actLTSCrollCtrl.GetScrollViewportImg().raycastTarget = enabled;
			}
		}

		// Token: 0x0600F7FC RID: 63484 RVA: 0x0043522F File Offset: 0x0043362F
		private void SetScrollRectHorizonal(bool enabled)
		{
			if (this.taskScrollRect != null)
			{
				this.taskScrollRect.horizontal = enabled;
			}
		}

		// Token: 0x04009910 RID: 39184
		public static int taskAwardCount = 5;

		// Token: 0x04009911 RID: 39185
		protected GameObject goParent;

		// Token: 0x04009912 RID: 39186
		protected ActivityLimitTimeDetailData currActivityData;

		// Token: 0x04009913 RID: 39187
		protected ActivityLimitTimeFrame currFrame;

		// Token: 0x04009914 RID: 39188
		private OpActivityTmpType currActType;

		// Token: 0x04009915 RID: 39189
		protected ComCommonBind mBind;

		// Token: 0x04009916 RID: 39190
		private Text descText;

		// Token: 0x04009917 RID: 39191
		private Slider doneSlider;

		// Token: 0x04009918 RID: 39192
		private Text doneText;

		// Token: 0x04009919 RID: 39193
		private GameObject awardParentGo;

		// Token: 0x0400991A RID: 39194
		private Button receiveBtn;

		// Token: 0x0400991B RID: 39195
		private GameObject receiveBtnGo;

		// Token: 0x0400991C RID: 39196
		private GameObject receiveImgGo;

		// Token: 0x0400991D RID: 39197
		private GameObject undoneImgGo;

		// Token: 0x0400991E RID: 39198
		private ScrollRect taskScrollRect;

		// Token: 0x0400991F RID: 39199
		private CanvasGroup scrollRectCanvas;

		// Token: 0x04009920 RID: 39200
		private ActivityLTScrollRectCtrl actLTSCrollCtrl;

		// Token: 0x04009921 RID: 39201
		private List<ActivityLTAwardIcon> activityLTAwardIcons;

		// Token: 0x020018CA RID: 6346
		private struct TaskStatusText
		{
			// Token: 0x04009922 RID: 39202
			public const string Received = "已领取";

			// Token: 0x04009923 RID: 39203
			public const string UnReceived = "待领取";

			// Token: 0x04009924 RID: 39204
			public const string UnDone = "未完成";
		}
	}
}
