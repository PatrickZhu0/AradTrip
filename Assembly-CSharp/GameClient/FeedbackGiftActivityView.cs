using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001892 RID: 6290
	public class FeedbackGiftActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F612 RID: 62994 RVA: 0x0042639B File Offset: 0x0042479B
		public sealed override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this._UpdateTitleInfo(model);
			this._UpdateProgressInfo(model);
		}

		// Token: 0x0600F613 RID: 62995 RVA: 0x004263CC File Offset: 0x004247CC
		public sealed override void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(data.TaskDatas[i].DataId))
				{
					this.mItems[data.TaskDatas[i].DataId].UpdateData(data.TaskDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					this._AddItem(gameObject, i, data);
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < data.TaskDatas.Count; k++)
				{
					if (list[j] == data.TaskDatas[k].DataId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					IActivityCommonItem activityCommonItem = this.mItems[list[j]];
					this.mItems.Remove(list[j]);
					activityCommonItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			this._UpdateProgressInfo(data);
		}

		// Token: 0x0600F614 RID: 62996 RVA: 0x00426560 File Offset: 0x00424960
		protected sealed override void _InitItems(ILimitTimeActivityModel data)
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
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				this._AddItem(gameObject, i, data);
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F615 RID: 62997 RVA: 0x004265F4 File Offset: 0x004249F4
		protected new void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoots[id].transform, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F616 RID: 62998 RVA: 0x00426677 File Offset: 0x00424A77
		private void _UpdateTitleInfo(ILimitTimeActivityModel model)
		{
			this.mTextTime.SafeSetText(string.Format("{0}", Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
			this.mTextRule.SafeSetText(model.RuleDesc);
		}

		// Token: 0x0600F617 RID: 62999 RVA: 0x004266B0 File Offset: 0x00424AB0
		private void _UpdateProgressInfo(ILimitTimeActivityModel model)
		{
			if (this.mImageProgresss != null && model.ParamArray != null && model.ParamArray.Length > 0)
			{
				float num = 0f;
				if (model.TaskDatas.Count > 0)
				{
					num = model.TaskDatas[0].DoneNum;
				}
				this.mImageProgresss.value = num / model.ParamArray[0];
				this.mTextTotalProgrees.SafeSetText(string.Format("{0}", num));
			}
		}

		// Token: 0x040096E4 RID: 38628
		[SerializeField]
		private GameObject[] mItemRoots = new GameObject[0];

		// Token: 0x040096E5 RID: 38629
		[SerializeField]
		private Text mTextTime;

		// Token: 0x040096E6 RID: 38630
		[SerializeField]
		private Text mTextRule;

		// Token: 0x040096E7 RID: 38631
		[SerializeField]
		private Text mTextTotalProgrees;

		// Token: 0x040096E8 RID: 38632
		[SerializeField]
		private Slider mImageProgresss;
	}
}
