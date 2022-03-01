using System;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020018D8 RID: 6360
public class BrushFigureGiftsItem : ActivityItemBase
{
	// Token: 0x0600F850 RID: 63568 RVA: 0x004370A0 File Offset: 0x004354A0
	private void Start()
	{
		if (this.receiveBtn != null)
		{
			this.receiveBtn.onClick.RemoveAllListeners();
			this.receiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
		}
		if (this.goBtn != null)
		{
			this.goBtn.onClick.RemoveAllListeners();
			this.goBtn.onClick.AddListener(new UnityAction(this.OnGoBtnClick));
		}
	}

	// Token: 0x0600F851 RID: 63569 RVA: 0x00437128 File Offset: 0x00435528
	private void OnGoBtnClick()
	{
		if (this.mData != null && this.mData.ParamNums2 != null && this.mData.ParamNums2.Count > 0)
		{
			int dungeonID = (int)this.mData.ParamNums2[0];
			DungeonModelTable.eType dugeonModleTypeById = DungeonUtility.GetDugeonModleTypeById(dungeonID);
			if (dugeonModleTypeById != DungeonModelTable.eType.Type_None)
			{
				ChallengeUtility.OnOpenChallengeMapFrame(dugeonModleTypeById, 0, 0);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
		}
	}

	// Token: 0x0600F852 RID: 63570 RVA: 0x0043719E File Offset: 0x0043559E
	private void OnReceiveBtnClick()
	{
		this._OnItemClick();
		if (this.mData != null)
		{
			this.OnRequsetAccountData(this.mData);
		}
	}

	// Token: 0x0600F853 RID: 63571 RVA: 0x004371C0 File Offset: 0x004355C0
	public override void UpdateData(ILimitTimeActivityTaskDataModel data)
	{
		if (data == null)
		{
			return;
		}
		this.receiveGo.CustomActive(false);
		this.haveToReceiveGo.CustomActive(false);
		this.unFinishedGo.CustomActive(false);
		this.goGo.CustomActive(false);
		if (!this.mIsLeftMinus0)
		{
			switch (data.State)
			{
			case OpActTaskState.OATS_UNFINISH:
				if (this.bIsDailyTask)
				{
					this.goGo.CustomActive(true);
				}
				else
				{
					this.unFinishedGo.CustomActive(true);
				}
				break;
			case OpActTaskState.OATS_FINISHED:
				this.receiveGo.CustomActive(true);
				break;
			case OpActTaskState.OATS_OVER:
				this.haveToReceiveGo.CustomActive(true);
				break;
			}
		}
		else
		{
			this.haveToReceiveGo.CustomActive(true);
		}
	}

	// Token: 0x0600F854 RID: 63572 RVA: 0x004372A0 File Offset: 0x004356A0
	protected override void OnInit(ILimitTimeActivityTaskDataModel data)
	{
		if (data == null)
		{
			return;
		}
		this.mData = data;
		if (this.mData.AccountDailySubmitLimit > 0)
		{
			this.bIsDailyTask = true;
		}
		if (this.taskName != null)
		{
			this.taskName.text = this.mData.Desc;
		}
		if (this.mData.AwardDataList.Count > 0)
		{
			OpTaskReward opTaskReward = this.mData.AwardDataList[0];
			if (this.commonNewItem != null)
			{
				this.commonNewItem.InitItem((int)opTaskReward.id, (int)opTaskReward.num);
			}
		}
		this.UpdateProgress(data);
		this.RegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
		this.OnRequsetAccountData(data);
	}

	// Token: 0x0600F855 RID: 63573 RVA: 0x0043736A File Offset: 0x0043576A
	private void UpdateProgress(ILimitTimeActivityTaskDataModel data)
	{
		if (this.taskProgress != null)
		{
			this.taskProgress.text = string.Format(this.progressDesc, data.DoneNum, data.TotalNum);
		}
	}

	// Token: 0x0600F856 RID: 63574 RVA: 0x004373A9 File Offset: 0x004357A9
	private void OnActivityCounterUpdate(UIEvent uiEvent)
	{
		if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
		{
			this.ShowHaveUsedNumState(this.mData);
		}
	}

	// Token: 0x0600F857 RID: 63575 RVA: 0x004373E0 File Offset: 0x004357E0
	private void ShowHaveUsedNumState(ILimitTimeActivityTaskDataModel data)
	{
		if (data != null)
		{
			int num = 0;
			int num2 = 0;
			if (data.AccountDailySubmitLimit > 0)
			{
				num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
				num = data.AccountDailySubmitLimit;
			}
			else if (data.AccountTotalSubmitLimit > 0)
			{
				num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
				num = data.AccountTotalSubmitLimit;
			}
			int num3 = num - num2;
			if (num3 <= 0 && num > 0)
			{
				this.receiveGo.CustomActive(false);
				this.haveToReceiveGo.CustomActive(true);
				this.unFinishedGo.CustomActive(false);
				this.goGo.CustomActive(false);
				this.mIsLeftMinus0 = true;
			}
		}
	}

	// Token: 0x0600F858 RID: 63576 RVA: 0x0043749C File Offset: 0x0043589C
	public override void Dispose()
	{
		base.Dispose();
		if (this.receiveBtn != null)
		{
			this.receiveBtn.onClick.RemoveAllListeners();
		}
		if (this.goBtn != null)
		{
			this.goBtn.onClick.RemoveAllListeners();
		}
		this.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
		this.mIsLeftMinus0 = false;
		this.bIsDailyTask = false;
	}

	// Token: 0x04009971 RID: 39281
	[SerializeField]
	private Text taskName;

	// Token: 0x04009972 RID: 39282
	[SerializeField]
	private Text taskProgress;

	// Token: 0x04009973 RID: 39283
	[SerializeField]
	private CommonNewItem commonNewItem;

	// Token: 0x04009974 RID: 39284
	[SerializeField]
	private Button receiveBtn;

	// Token: 0x04009975 RID: 39285
	[SerializeField]
	private Button goBtn;

	// Token: 0x04009976 RID: 39286
	[SerializeField]
	private GameObject receiveGo;

	// Token: 0x04009977 RID: 39287
	[SerializeField]
	private GameObject haveToReceiveGo;

	// Token: 0x04009978 RID: 39288
	[SerializeField]
	private GameObject unFinishedGo;

	// Token: 0x04009979 RID: 39289
	[SerializeField]
	private GameObject goGo;

	// Token: 0x0400997A RID: 39290
	[SerializeField]
	private string progressDesc = "已完成：{0}/{1}";

	// Token: 0x0400997B RID: 39291
	private ILimitTimeActivityTaskDataModel mData;

	// Token: 0x0400997C RID: 39292
	private bool mIsLeftMinus0;

	// Token: 0x0400997D RID: 39293
	private bool bIsDailyTask;
}
