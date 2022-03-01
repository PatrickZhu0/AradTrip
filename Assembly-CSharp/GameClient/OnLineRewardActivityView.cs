using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018AA RID: 6314
	public class OnLineRewardActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F6E3 RID: 63203 RVA: 0x0042BCA4 File Offset: 0x0042A0A4
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			if (this.mTime != null)
			{
				this.mTime.text = Function.GetTimeWithoutYearNoZero((int)this.mModel.StartTime, (int)this.mModel.EndTime);
			}
			this.InitItems(model);
		}

		// Token: 0x0600F6E4 RID: 63204 RVA: 0x0042BD0E File Offset: 0x0042A10E
		public void Show()
		{
		}

		// Token: 0x0600F6E5 RID: 63205 RVA: 0x0042BD10 File Offset: 0x0042A110
		public void UpdateData(ILimitTimeActivityModel data)
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

		// Token: 0x0600F6E6 RID: 63206 RVA: 0x0042BDAA File Offset: 0x0042A1AA
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F6E7 RID: 63207 RVA: 0x0042BDC0 File Offset: 0x0042A1C0
		public void Dispose()
		{
			foreach (IActivityCommonItem activityCommonItem in this.mItems.Values)
			{
				activityCommonItem.Dispose();
			}
			this.mItems.Clear();
			this.mOnItemClick = null;
			this.mModel = null;
		}

		// Token: 0x0600F6E8 RID: 63208 RVA: 0x0042BE3C File Offset: 0x0042A23C
		public void Hide()
		{
		}

		// Token: 0x0600F6E9 RID: 63209 RVA: 0x0042BE40 File Offset: 0x0042A240
		private void InitItems(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("加载预制体失败，路径:" + data.ItemPath, new object[0]);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogErrorFormat("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + data.ItemPath, new object[0]);
				return;
			}
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.dailyItemPath, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogErrorFormat("加载预制体失败，路径:" + this.dailyItemPath, new object[0]);
				return;
			}
			if (gameObject2.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogErrorFormat("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.dailyItemPath, new object[0]);
				return;
			}
			GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.loginItemPath, true, 0U);
			if (gameObject3 == null)
			{
				return;
			}
			if (gameObject3.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogErrorFormat("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.loginItemPath, new object[0]);
				return;
			}
			this.mItems.Clear();
			List<ILimitTimeActivityTaskDataModel> list = new List<ILimitTimeActivityTaskDataModel>();
			List<ILimitTimeActivityTaskDataModel> list2 = new List<ILimitTimeActivityTaskDataModel>();
			List<ILimitTimeActivityTaskDataModel> list3 = new List<ILimitTimeActivityTaskDataModel>();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (limitTimeActivityTaskDataModel.ParamNums[0] == 0U)
					{
						list2.Add(limitTimeActivityTaskDataModel);
					}
					else if (limitTimeActivityTaskDataModel.ParamNums[0] == 1U)
					{
						list.Add(limitTimeActivityTaskDataModel);
					}
					else
					{
						list3.Add(limitTimeActivityTaskDataModel);
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel2 = list[j];
				if (limitTimeActivityTaskDataModel2 != null)
				{
					this._AddItem(gameObject3, limitTimeActivityTaskDataModel2, data, this.mOnLineLoginItemRoot);
				}
			}
			for (int k = 0; k < list2.Count; k++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel3 = list2[k];
				if (limitTimeActivityTaskDataModel3 != null)
				{
					this._AddItem(gameObject2, limitTimeActivityTaskDataModel3, data, this.mOnLineGiftItemRoot);
				}
			}
			for (int l = 0; l < list3.Count; l++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel4 = list3[l];
				if (limitTimeActivityTaskDataModel4 != null)
				{
					this._AddItem(gameObject, limitTimeActivityTaskDataModel4, data, this.mNumberDayItemRoot);
				}
			}
			Object.Destroy(gameObject);
			Object.Destroy(gameObject2);
			Object.Destroy(gameObject3);
		}

		// Token: 0x0600F6EA RID: 63210 RVA: 0x0042C0E8 File Offset: 0x0042A4E8
		protected void _AddItem(GameObject go, ILimitTimeActivityTaskDataModel taskData, ILimitTimeActivityModel data, RectTransform goParent)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(goParent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(taskData.DataId, data.Id, taskData, this.mOnItemClick);
			this.mItems.Add(taskData.DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x040097BE RID: 38846
		[SerializeField]
		private RectTransform mOnLineGiftItemRoot;

		// Token: 0x040097BF RID: 38847
		[SerializeField]
		private RectTransform mNumberDayItemRoot;

		// Token: 0x040097C0 RID: 38848
		[SerializeField]
		private RectTransform mOnLineLoginItemRoot;

		// Token: 0x040097C1 RID: 38849
		[SerializeField]
		private Text mTime;

		// Token: 0x040097C2 RID: 38850
		[SerializeField]
		private string dailyItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/OnLineRewardDailyItem";

		// Token: 0x040097C3 RID: 38851
		[SerializeField]
		private string loginItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/OnLineRewardLoginItem";

		// Token: 0x040097C4 RID: 38852
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x040097C5 RID: 38853
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040097C6 RID: 38854
		protected ILimitTimeActivityModel mModel;
	}
}
