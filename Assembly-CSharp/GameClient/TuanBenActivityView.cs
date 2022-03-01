using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001818 RID: 6168
	public class TuanBenActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F2FF RID: 62207 RVA: 0x0041A544 File Offset: 0x00418944
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this.mTakeRewardBtn.SafeAddOnClickListener(new UnityAction(this._OnTakeRewardBtnClick));
			this.mGoBtn.SafeAddOnClickListener(new UnityAction(this._OnGoBtnClick));
			this._ShowActivityDes(model);
			this.UpdateData(model);
			this._InitItems();
		}

		// Token: 0x0600F300 RID: 62208 RVA: 0x0041A5B0 File Offset: 0x004189B0
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || data.TaskDatas.Count < 1)
			{
				return;
			}
			this.mHaveTakenGo.CustomActive(false);
			this.mNotTakenGo.CustomActive(false);
			this.mCanTakenGo.CustomActive(false);
			this.mTaskData = data.TaskDatas[0];
			if (this.mTaskData == null)
			{
				return;
			}
			OpActTaskState state = this.mTaskData.State;
			if (state != OpActTaskState.OATS_UNFINISH)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					if (state == OpActTaskState.OATS_OVER)
					{
						this.mHaveTakenGo.CustomActive(true);
					}
				}
				else
				{
					this.mCanTakenGo.CustomActive(true);
				}
			}
			else
			{
				this.mNotTakenGo.CustomActive(true);
			}
		}

		// Token: 0x0600F301 RID: 62209 RVA: 0x0041A680 File Offset: 0x00418A80
		public void Close()
		{
			this.mTaskData = null;
			this.mOnItemClick = null;
			this.mTakeRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnTakeRewardBtnClick));
			this.mGoBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGoBtnClick));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F302 RID: 62210 RVA: 0x0041A6D4 File Offset: 0x00418AD4
		public void Show()
		{
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600F303 RID: 62211 RVA: 0x0041A6E2 File Offset: 0x00418AE2
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F304 RID: 62212 RVA: 0x0041A6F0 File Offset: 0x00418AF0
		public void Dispose()
		{
		}

		// Token: 0x0600F305 RID: 62213 RVA: 0x0041A6F2 File Offset: 0x00418AF2
		private void _OnTakeRewardBtnClick()
		{
			if (this.mOnItemClick != null && this.mTaskData != null)
			{
				this.mOnItemClick((int)this.mTaskData.DataId, 0, 0UL);
			}
		}

		// Token: 0x0600F306 RID: 62214 RVA: 0x0041A724 File Offset: 0x00418B24
		private void _OnGoBtnClick()
		{
			bool flag = TeamDuplicationUtility.IsShowTeamDuplicationWithNormalLevel();
			if (flag)
			{
				TeamDuplicationUtility.EnterInTeamDuplicationBuildScene(true);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("TUANBEN_ACTIVITY_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600F307 RID: 62215 RVA: 0x0041A765 File Offset: 0x00418B65
		private void _OnReviewBtnClick()
		{
		}

		// Token: 0x0600F308 RID: 62216 RVA: 0x0041A768 File Offset: 0x00418B68
		private void _ShowActivityDes(ILimitTimeActivityModel model)
		{
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleDesTxt.SafeSetText(model.RuleDesc);
			if (this.mReviewDrop != null)
			{
				this.mReviewList.Clear();
				this.mReviewList.Add((int)model.Param);
				this.mReviewDrop.SetDropList(this.mReviewList, 0);
			}
			if (model.ParamArray2 != null && model.ParamArray2.Length >= 1)
			{
				this.mTicketDesTxt.SafeSetText(string.Format(TR.Value("TUANBEN_ACTIVITY_TICKET_DES"), model.ParamArray2[0]));
			}
		}

		// Token: 0x0600F309 RID: 62217 RVA: 0x0041A834 File Offset: 0x00418C34
		private void _InitItems()
		{
			if (this.mTaskData != null && this.mTaskData.AwardDataList != null && this.mTaskData.AwardDataList.Count >= 1)
			{
				OpTaskReward opTaskReward = this.mTaskData.AwardDataList[0];
				if (opTaskReward == null)
				{
					return;
				}
				if (this.mItemParent == null)
				{
					return;
				}
				ComItem comItem = ComItemManager.Create(this.mItemParent.gameObject);
				if (comItem == null)
				{
					return;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (itemData == null)
				{
					return;
				}
				itemData.Count = (int)opTaskReward.num;
				ComItem comItem2 = comItem;
				ItemData item = itemData;
				if (TuanBenActivityView.<>f__mg$cache0 == null)
				{
					TuanBenActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, TuanBenActivityView.<>f__mg$cache0);
			}
		}

		// Token: 0x0600F30A RID: 62218 RVA: 0x0041A904 File Offset: 0x00418D04
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x04009573 RID: 38259
		[SerializeField]
		private GameObject mHaveTakenGo;

		// Token: 0x04009574 RID: 38260
		[SerializeField]
		private GameObject mNotTakenGo;

		// Token: 0x04009575 RID: 38261
		[SerializeField]
		private GameObject mCanTakenGo;

		// Token: 0x04009576 RID: 38262
		[SerializeField]
		private Button mTakeRewardBtn;

		// Token: 0x04009577 RID: 38263
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x04009578 RID: 38264
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009579 RID: 38265
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x0400957A RID: 38266
		[SerializeField]
		private Text mTicketDesTxt;

		// Token: 0x0400957B RID: 38267
		[SerializeField]
		private Transform mItemParent;

		// Token: 0x0400957C RID: 38268
		[SerializeField]
		private ComChapterInfoDrop mReviewDrop;

		// Token: 0x0400957D RID: 38269
		private List<int> mReviewList = new List<int>();

		// Token: 0x0400957E RID: 38270
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400957F RID: 38271
		private ILimitTimeActivityTaskDataModel mTaskData;

		// Token: 0x04009580 RID: 38272
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
