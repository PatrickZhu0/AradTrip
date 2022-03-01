using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200186C RID: 6252
	public class AbyssBlackGoldMemberActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F501 RID: 62721 RVA: 0x004215BB File Offset: 0x0041F9BB
		private void Awake()
		{
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.onClick.RemoveAllListeners();
				this.mBuyBtn.onClick.AddListener(new UnityAction(this.OnBuyClick));
			}
		}

		// Token: 0x0600F502 RID: 62722 RVA: 0x004215FA File Offset: 0x0041F9FA
		private void OnDestroy()
		{
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyClick));
			}
			this.Close();
		}

		// Token: 0x0600F503 RID: 62723 RVA: 0x0042162F File Offset: 0x0041FA2F
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F504 RID: 62724 RVA: 0x00421642 File Offset: 0x0041FA42
		public void Dispose()
		{
			this.chargeMallTable = null;
			this.taskDataModel = null;
			this.limitTimeActivityModel = null;
		}

		// Token: 0x0600F505 RID: 62725 RVA: 0x00421659 File Offset: 0x0041FA59
		public void Hide()
		{
		}

		// Token: 0x0600F506 RID: 62726 RVA: 0x0042165C File Offset: 0x0041FA5C
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.limitTimeActivityModel = model;
			this.chargeMallTable = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(this.chargeMallTableID, string.Empty, string.Empty);
			if (this.chargeMallTable == null)
			{
				return;
			}
			if (this.mActivityTime != null)
			{
				this.mActivityTime.text = string.Format("{0}-{1}", Function.GetDateTime((int)model.StartTime, false), Function.GetDateTime((int)model.EndTime, false));
			}
			if (this.mRMB != null)
			{
				this.mRMB.text = string.Format(this.mRMBDesc, this.chargeMallTable.ChargeMoney);
			}
			if (model.TaskDatas.Count > 0)
			{
				this.taskDataModel = model.TaskDatas[0];
			}
			if (this.taskDataModel != null)
			{
				if (this.taskDataModel.ParamNums.Count >= 2)
				{
					int time = (int)this.taskDataModel.ParamNums[0];
					int time2 = (int)this.taskDataModel.ParamNums[1];
					if (this.mTime != null)
					{
						this.mTime.text = string.Format("{0}-{1}", Function.GetDateTime(time, false), Function.GetDateTime(time2, false));
					}
				}
				this.UpdateBalckGoldMerberState(this.taskDataModel);
			}
		}

		// Token: 0x0600F507 RID: 62727 RVA: 0x004217CA File Offset: 0x0041FBCA
		public void Show()
		{
		}

		// Token: 0x0600F508 RID: 62728 RVA: 0x004217CC File Offset: 0x0041FBCC
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data == null || data.TaskDatas == null)
			{
				return;
			}
			if (data.TaskDatas.Count > 0 && this.taskDataModel != null && data.TaskDatas[0].DataId == this.taskDataModel.DataId)
			{
				this.UpdateBalckGoldMerberState(data.TaskDatas[0]);
			}
		}

		// Token: 0x0600F509 RID: 62729 RVA: 0x0042183C File Offset: 0x0041FC3C
		public void UpdateBalckGoldMerberState(ILimitTimeActivityTaskDataModel taskData)
		{
			if (taskData == null)
			{
				return;
			}
			if (this.miIactiveRoot != null)
			{
				this.miIactiveRoot.CustomActive(false);
			}
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.CustomActive(false);
			}
			if (this.mActiveRoot != null)
			{
				this.mActiveRoot.CustomActive(false);
			}
			if (this.mSimpleTimer != null)
			{
				this.mSimpleTimer.CustomActive(false);
			}
			switch (taskData.State)
			{
			case OpActTaskState.OATS_UNFINISH:
				if (this.mBuyBtn != null)
				{
					this.mBuyBtn.CustomActive(true);
				}
				if (this.miIactiveRoot != null)
				{
					this.miIactiveRoot.CustomActive(true);
				}
				break;
			case OpActTaskState.OATS_FINISHED:
				if (this.mActiveRoot != null)
				{
					this.mActiveRoot.CustomActive(true);
				}
				if (this.mSimpleTimer != null)
				{
					this.mSimpleTimer.CustomActive(true);
					int num = (int)(this.limitTimeActivityModel.EndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
					if (num <= 86400)
					{
						this.mSimpleTimer.useSystemUpdate = true;
					}
					else
					{
						this.mSimpleTimer.useSystemUpdate = false;
					}
					this.mSimpleTimer.SetCountdown(num);
					this.mSimpleTimer.StartTimer();
				}
				break;
			}
		}

		// Token: 0x0600F50A RID: 62730 RVA: 0x004219CC File Offset: 0x0041FDCC
		private void OnBuyClick()
		{
			if (this.chargeMallTable == null)
			{
				return;
			}
			Singleton<PayManager>.GetInstance().DoPay(this.chargeMallTable.ID, this.chargeMallTable.ChargeMoney, ChargeMallType.DungeonRightCard);
		}

		// Token: 0x0400963A RID: 38458
		[SerializeField]
		private Text mTime;

		// Token: 0x0400963B RID: 38459
		[SerializeField]
		private Text mActivityTime;

		// Token: 0x0400963C RID: 38460
		[SerializeField]
		private Text mRMB;

		// Token: 0x0400963D RID: 38461
		[SerializeField]
		private GameObject miIactiveRoot;

		// Token: 0x0400963E RID: 38462
		[SerializeField]
		private GameObject mActiveRoot;

		// Token: 0x0400963F RID: 38463
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x04009640 RID: 38464
		[SerializeField]
		private SimpleTimer mSimpleTimer;

		// Token: 0x04009641 RID: 38465
		[SerializeField]
		private string mRMBDesc = "￥{0}";

		// Token: 0x04009642 RID: 38466
		[SerializeField]
		private int chargeMallTableID = 16;

		// Token: 0x04009643 RID: 38467
		private ChargeMallTable chargeMallTable;

		// Token: 0x04009644 RID: 38468
		private ILimitTimeActivityTaskDataModel taskDataModel;

		// Token: 0x04009645 RID: 38469
		private ILimitTimeActivityModel limitTimeActivityModel;
	}
}
