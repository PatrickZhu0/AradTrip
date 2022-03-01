using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001881 RID: 6273
	public class ChristmasSnowmanActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5AA RID: 62890 RVA: 0x004245BD File Offset: 0x004229BD
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

		// Token: 0x0600F5AB RID: 62891 RVA: 0x004245EC File Offset: 0x004229EC
		public sealed override void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(data.TaskDatas[i].DataId))
				{
					this.mItems[data.TaskDatas[i].DataId].UpdateData(data.TaskDatas[i]);
				}
				else if (i == data.TaskDatas.Count - 1)
				{
					if (gameObject2 == null)
					{
						gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mItemPrefabPath2, true, 0U);
					}
					this._AddItem(gameObject2, i, data);
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
			if (gameObject2 != null)
			{
				Object.Destroy(gameObject2);
			}
			this._UpdateProgressInfo(data);
		}

		// Token: 0x0600F5AC RID: 62892 RVA: 0x004247D8 File Offset: 0x00422BD8
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
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mItemPrefabPath2, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogError("加载预制体失败，路径:" + this.mItemPrefabPath2);
				return;
			}
			if (gameObject2.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.mItemPrefabPath2);
				return;
			}
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (i == data.TaskDatas.Count - 1)
				{
					this._AddItem(gameObject2, i, data);
				}
				else
				{
					this._AddItem(gameObject, i, data);
				}
			}
			Object.Destroy(gameObject);
			Object.Destroy(gameObject2);
		}

		// Token: 0x0600F5AD RID: 62893 RVA: 0x004248F0 File Offset: 0x00422CF0
		protected new void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoots[id].transform, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F5AE RID: 62894 RVA: 0x00424973 File Offset: 0x00422D73
		private void _UpdateTitleInfo(ILimitTimeActivityModel model)
		{
			this.mTextTime.SafeSetText(string.Format("{0}", Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
			this.mTextRule.SafeSetText(model.RuleDesc);
		}

		// Token: 0x0600F5AF RID: 62895 RVA: 0x004249AC File Offset: 0x00422DAC
		private void _UpdateProgressInfo(ILimitTimeActivityModel model)
		{
			if (this.mImageProgresss != null && model.ParamArray != null && model.ParamArray.Length > 1)
			{
				float num = 0f;
				for (int i = 0; i < model.TaskDatas.Count; i++)
				{
					num += model.TaskDatas[i].DoneNum;
				}
				this.mImageProgresss.fillAmount = (model.ParamArray[0] - num) / model.ParamArray[0];
				string format = (num <= 0f) ? TR.Value("activity_sheng_dan_xue_ren_total_progress_Two") : TR.Value("activity_sheng_dan_xue_ren_total_progress");
				this.mTextTotalProgrees.SafeSetText(string.Format(format, num, model.ParamArray[0]));
			}
			if (model.ParamArray != null && model.ParamArray.Length >= 2)
			{
				string name = string.Format("{0}{1}", model.Id, CounterKeys.OPACT_MAGPIE_BRIDGE_DAILY_PROGRESS);
				int count = DataManager<CountDataManager>.GetInstance().GetCount(name);
				uint num2 = model.ParamArray[1];
				this.mTextTodayFalling.SafeSetText(string.Format("{0}℃/{1}℃", count, num2));
			}
		}

		// Token: 0x040096B1 RID: 38577
		[SerializeField]
		private GameObject[] mItemRoots = new GameObject[0];

		// Token: 0x040096B2 RID: 38578
		[SerializeField]
		private Text mTextTime;

		// Token: 0x040096B3 RID: 38579
		[SerializeField]
		private Text mTextRule;

		// Token: 0x040096B4 RID: 38580
		[SerializeField]
		private Text mTextTodayFalling;

		// Token: 0x040096B5 RID: 38581
		[SerializeField]
		private Text mTextTotalProgrees;

		// Token: 0x040096B6 RID: 38582
		[SerializeField]
		private Image mImageProgresss;

		// Token: 0x040096B7 RID: 38583
		[SerializeField]
		private string mItemPrefabPath2 = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ChristmasSnowmanItem2";
	}
}
