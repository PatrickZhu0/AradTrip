using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001888 RID: 6280
	public class DailyChallengeActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5D4 RID: 62932 RVA: 0x0042546E File Offset: 0x0042386E
		private void Awake()
		{
			DataManager<ActivityDataManager>.GetInstance().RegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
		}

		// Token: 0x0600F5D5 RID: 62933 RVA: 0x00425488 File Offset: 0x00423888
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mTime.SafeSetText(TR.Value("Limit_Time_Activity_Time_Interval_Format", Function.GetDateTimeHaveMonthToSecond((int)this.mModel.StartTime), Function.GetDateTimeHaveMonthToSecond((int)model.EndTime)));
			if (this.mModel.ParamArray != null && this.mModel.ParamArray.Length >= 2)
			{
				this.mAcountTotalReceiveNum = (int)this.mModel.ParamArray[0];
				this.mRoleTotalReceiveNum = (int)this.mModel.ParamArray[1];
			}
			this.UpdateInfo();
			this._InitItems(this.mModel);
		}

		// Token: 0x0600F5D6 RID: 62934 RVA: 0x00425538 File Offset: 0x00423938
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (this.mItems.ContainsKey(limitTimeActivityTaskDataModel.DataId))
					{
						this.mItems[limitTimeActivityTaskDataModel.DataId].UpdateData(limitTimeActivityTaskDataModel);
					}
				}
			}
		}

		// Token: 0x0600F5D7 RID: 62935 RVA: 0x004255D4 File Offset: 0x004239D4
		protected override void _InitItems(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + data.ItemPath);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mGrandTotalItemPath, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogError("加载预制体失败，路径:" + this.mGrandTotalItemPath);
				return;
			}
			if (gameObject2.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.mGrandTotalItemPath);
				return;
			}
			this.mItems.Clear();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (limitTimeActivityTaskDataModel.ParamNums2 != null && limitTimeActivityTaskDataModel.ParamNums2.Count > 0)
					{
						if (limitTimeActivityTaskDataModel.ParamNums2[0] == 1U)
						{
							this._AddItem(gameObject2, i, data, this.mItemRoot2);
						}
						else
						{
							this._AddItem(gameObject, i, data, this.mItemRoot);
						}
					}
					else
					{
						this._AddItem(gameObject, i, data, this.mItemRoot);
					}
				}
			}
		}

		// Token: 0x0600F5D8 RID: 62936 RVA: 0x00425740 File Offset: 0x00423B40
		protected void _AddItem(GameObject go, int id, ILimitTimeActivityModel data, RectTransform parent)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(parent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F5D9 RID: 62937 RVA: 0x004257B8 File Offset: 0x00423BB8
		private void OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mModel != null && (uint)uiEvent.Param1 == this.mModel.Id)
			{
				this.UpdateInfo();
			}
		}

		// Token: 0x0600F5DA RID: 62938 RVA: 0x004257E8 File Offset: 0x00423BE8
		private void UpdateInfo()
		{
			int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK);
			int num = this.mAcountTotalReceiveNum - activityConunter;
			if (num <= 0)
			{
				num = 0;
			}
			int num2 = this.mRoleTotalReceiveNum;
			List<uint> haveRecivedTaskID = DataManager<ActivityDataManager>.GetInstance().GetHaveRecivedTaskID(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY);
			if (haveRecivedTaskID != null && haveRecivedTaskID.Count > 0)
			{
				num2 = this.mRoleTotalReceiveNum - haveRecivedTaskID.Count;
				if (num2 <= 0)
				{
					num2 = 0;
				}
			}
			if (num <= 0)
			{
				num2 = 0;
			}
			if (this.mRoleDesc != null)
			{
				this.mRoleDesc.text = TR.Value("limitactivity_dailychallenge_roleDesc", num2, this.mRoleTotalReceiveNum);
			}
			if (this.mAccountDesc != null)
			{
				this.mAccountDesc.text = TR.Value("limitactivity_dailychallenge_accountDesc", num, this.mAcountTotalReceiveNum);
			}
		}

		// Token: 0x0600F5DB RID: 62939 RVA: 0x004258D3 File Offset: 0x00423CD3
		private void OnDestroy()
		{
			DataManager<ActivityDataManager>.GetInstance().UnRegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
		}

		// Token: 0x040096C9 RID: 38601
		[SerializeField]
		private RectTransform mItemRoot2;

		// Token: 0x040096CA RID: 38602
		[SerializeField]
		private Text mTime;

		// Token: 0x040096CB RID: 38603
		[SerializeField]
		private Text mRoleDesc;

		// Token: 0x040096CC RID: 38604
		[SerializeField]
		private Text mAccountDesc;

		// Token: 0x040096CD RID: 38605
		[SerializeField]
		private string mGrandTotalItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/DailyChallengeGrandTotalItem";

		// Token: 0x040096CE RID: 38606
		private int mAcountTotalReceiveNum;

		// Token: 0x040096CF RID: 38607
		private int mRoleTotalReceiveNum;
	}
}
