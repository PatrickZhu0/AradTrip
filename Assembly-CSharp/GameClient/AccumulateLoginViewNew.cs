using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001804 RID: 6148
	public class AccumulateLoginViewNew : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F25E RID: 62046 RVA: 0x00415F24 File Offset: 0x00414324
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
				this.mTime.text = Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime);
			}
			this._InitItems(model);
		}

		// Token: 0x0600F25F RID: 62047 RVA: 0x00415F84 File Offset: 0x00414384
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
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

		// Token: 0x0600F260 RID: 62048 RVA: 0x00416014 File Offset: 0x00414414
		protected void _InitItems(ILimitTimeActivityModel data)
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
			this.mItems.Clear();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (i == data.TaskDatas.Count - 1)
					{
						this.accumulateLoginNewTurnTableItem.Init(limitTimeActivityTaskDataModel.DataId, data.Id, limitTimeActivityTaskDataModel, this.mOnItemClick);
						this.mItems.Add(limitTimeActivityTaskDataModel.DataId, this.accumulateLoginNewTurnTableItem);
					}
					else
					{
						this._AddItem(gameObject, i, data);
					}
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F261 RID: 62049 RVA: 0x00416118 File Offset: 0x00414518
		protected void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F262 RID: 62050 RVA: 0x00416194 File Offset: 0x00414594
		public void Show()
		{
		}

		// Token: 0x0600F263 RID: 62051 RVA: 0x00416196 File Offset: 0x00414596
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F264 RID: 62052 RVA: 0x004161AC File Offset: 0x004145AC
		public void Dispose()
		{
			foreach (IActivityCommonItem activityCommonItem in this.mItems.Values)
			{
				activityCommonItem.Dispose();
			}
			this.mItems.Clear();
			this.mOnItemClick = null;
		}

		// Token: 0x0600F265 RID: 62053 RVA: 0x00416220 File Offset: 0x00414620
		public void Hide()
		{
		}

		// Token: 0x040094EB RID: 38123
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x040094EC RID: 38124
		[SerializeField]
		private Text mTime;

		// Token: 0x040094ED RID: 38125
		[SerializeField]
		private AccumulateLoginNewTurnTableItem accumulateLoginNewTurnTableItem;

		// Token: 0x040094EE RID: 38126
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x040094EF RID: 38127
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040094F0 RID: 38128
		protected ILimitTimeActivityModel mModel;
	}
}
