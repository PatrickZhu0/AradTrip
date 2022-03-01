using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A7 RID: 6311
	public class MysteriousStoresActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F6CB RID: 63179 RVA: 0x0042B400 File Offset: 0x00429800
		private void Awake()
		{
			if (this.shopBtn != null)
			{
				this.shopBtn.onClick.RemoveAllListeners();
				this.shopBtn.onClick.AddListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.goBtn1 != null)
			{
				this.goBtn1.onClick.RemoveAllListeners();
				this.goBtn1.onClick.AddListener(delegate()
				{
					this.OnGoBtnClick(this.activityId);
				});
			}
			if (this.goBtn2 != null)
			{
				this.goBtn2.onClick.RemoveAllListeners();
				this.goBtn2.onClick.AddListener(delegate()
				{
					this.OnGoBtnClick(this.activityId2);
				});
			}
			if (this.goBtn3 != null)
			{
				this.goBtn3.onClick.RemoveAllListeners();
				this.goBtn3.onClick.AddListener(delegate()
				{
					this.OnGoBtnClick(this.activityId3);
				});
			}
		}

		// Token: 0x0600F6CC RID: 63180 RVA: 0x0042B504 File Offset: 0x00429904
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				return;
			}
			if (this.time != null)
			{
				this.time.text = Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime);
			}
			if (this.rule != null)
			{
				this.rule.text = model.RuleDesc;
			}
			this.RefreshPointInfo(model);
			DataManager<ActivityDataManager>.GetInstance().OnSendSceneSecretCoinReq();
		}

		// Token: 0x0600F6CD RID: 63181 RVA: 0x0042B578 File Offset: 0x00429978
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.RefreshPointInfo(data);
		}

		// Token: 0x0600F6CE RID: 63182 RVA: 0x0042B584 File Offset: 0x00429984
		private void RefreshPointInfo(ILimitTimeActivityModel data)
		{
			if (data == null)
			{
				return;
			}
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					for (int j = 0; j < limitTimeActivityTaskDataModel.ParamProgressList.Count; j++)
					{
						OpActTaskParam opActTaskParam = limitTimeActivityTaskDataModel.ParamProgressList[j];
						if (opActTaskParam != null)
						{
							int value = (int)opActTaskParam.value;
							if (opActTaskParam.key == "cost_point_total")
							{
								if (this.totalPoint != null)
								{
									this.totalPoint.text = value.ToString();
								}
							}
							else if (opActTaskParam.key == "cost_point_current" && this.currentPoint != null)
							{
								this.currentPoint.text = value.ToString();
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F6CF RID: 63183 RVA: 0x0042B689 File Offset: 0x00429A89
		private void OnShopBtnClick()
		{
			DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(this.iShopId, 0, 0, -1);
		}

		// Token: 0x0600F6D0 RID: 63184 RVA: 0x0042B6A0 File Offset: 0x00429AA0
		private void OnGoBtnClick(uint activityId)
		{
			LimitTimeActivityFrame limitTimeActivityFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(LimitTimeActivityFrame)) as LimitTimeActivityFrame;
			if (limitTimeActivityFrame != null)
			{
				limitTimeActivityFrame.OpenFrameByActivityId(activityId);
			}
		}

		// Token: 0x0600F6D1 RID: 63185 RVA: 0x0042B6D4 File Offset: 0x00429AD4
		public void Close()
		{
		}

		// Token: 0x0600F6D2 RID: 63186 RVA: 0x0042B6D8 File Offset: 0x00429AD8
		public void Dispose()
		{
			if (this.shopBtn != null)
			{
				this.shopBtn.onClick.RemoveListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.goBtn1 != null)
			{
				this.goBtn1.onClick.RemoveAllListeners();
			}
			if (this.goBtn2 != null)
			{
				this.goBtn2.onClick.RemoveAllListeners();
			}
			if (this.goBtn3 != null)
			{
				this.goBtn3.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600F6D3 RID: 63187 RVA: 0x0042B775 File Offset: 0x00429B75
		public void Hide()
		{
		}

		// Token: 0x0600F6D4 RID: 63188 RVA: 0x0042B777 File Offset: 0x00429B77
		public void Show()
		{
		}

		// Token: 0x040097A6 RID: 38822
		[SerializeField]
		private Text time;

		// Token: 0x040097A7 RID: 38823
		[SerializeField]
		private Text rule;

		// Token: 0x040097A8 RID: 38824
		[SerializeField]
		private Text totalPoint;

		// Token: 0x040097A9 RID: 38825
		[SerializeField]
		private Text currentPoint;

		// Token: 0x040097AA RID: 38826
		[SerializeField]
		private Button shopBtn;

		// Token: 0x040097AB RID: 38827
		[SerializeField]
		private Button goBtn1;

		// Token: 0x040097AC RID: 38828
		[SerializeField]
		private Button goBtn2;

		// Token: 0x040097AD RID: 38829
		[SerializeField]
		private Button goBtn3;

		// Token: 0x040097AE RID: 38830
		[Header("商店id")]
		[SerializeField]
		private int iShopId = 39;

		// Token: 0x040097AF RID: 38831
		[Header("奇幻之旅活动ID")]
		[SerializeField]
		private uint activityId = 1762U;

		// Token: 0x040097B0 RID: 38832
		[Header("周年登录活动ID")]
		[SerializeField]
		private uint activityId2 = 1765U;

		// Token: 0x040097B1 RID: 38833
		[Header("周年蛋糕活动ID")]
		[SerializeField]
		private uint activityId3 = 1765U;
	}
}
