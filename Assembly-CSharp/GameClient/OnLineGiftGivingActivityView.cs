using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A9 RID: 6313
	public class OnLineGiftGivingActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F6DA RID: 63194 RVA: 0x0042B7C0 File Offset: 0x00429BC0
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mActivityTime.SafeSetText(string.Format("{0}~{1}", Function._TransTimeStampToStr(model.StartTime), Function._TransTimeStampToStr(model.EndTime)));
			this.mActivityRule.SafeSetText(model.RuleDesc.Replace('|', '\n'));
			if (this.mModel.ParamArray.Length >= 2)
			{
				this.totalonLineTime = (int)this.mModel.ParamArray[0];
				this.totalDay = (int)this.mModel.ParamArray[1];
			}
			this.InitItems(model);
			if (this.mActiveUpdate != null)
			{
				this.mActiveUpdate.SetTotlaNum(this.totalonLineTime);
			}
		}

		// Token: 0x0600F6DB RID: 63195 RVA: 0x0042B893 File Offset: 0x00429C93
		public void Show()
		{
		}

		// Token: 0x0600F6DC RID: 63196 RVA: 0x0042B898 File Offset: 0x00429C98
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
					if (limitTimeActivityTaskDataModel.ParamNums2[0] == 2U)
					{
						this.curDay = (int)limitTimeActivityTaskDataModel.DoneNum;
					}
				}
			}
			if (this.mNumberDay != null)
			{
				this.mNumberDay.text = string.Format("({0}/{1})", this.curDay, this.totalDay);
			}
		}

		// Token: 0x0600F6DD RID: 63197 RVA: 0x0042B98C File Offset: 0x00429D8C
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F6DE RID: 63198 RVA: 0x0042B9A0 File Offset: 0x00429DA0
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

		// Token: 0x0600F6DF RID: 63199 RVA: 0x0042BA1C File Offset: 0x00429E1C
		public void Hide()
		{
		}

		// Token: 0x0600F6E0 RID: 63200 RVA: 0x0042BA20 File Offset: 0x00429E20
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
			this.mItems.Clear();
			List<ILimitTimeActivityTaskDataModel> list = new List<ILimitTimeActivityTaskDataModel>();
			List<ILimitTimeActivityTaskDataModel> list2 = new List<ILimitTimeActivityTaskDataModel>();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if (limitTimeActivityTaskDataModel.ParamNums2[0] == 1U)
					{
						list.Add(limitTimeActivityTaskDataModel);
					}
					else
					{
						list2.Add(limitTimeActivityTaskDataModel);
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel2 = list[j];
				if (limitTimeActivityTaskDataModel2 != null)
				{
					bool bIsShowArrow = j != list.Count - 1;
					this._AddItem(gameObject, limitTimeActivityTaskDataModel2, data, this.mOnLineGiftItemRoot, bIsShowArrow);
				}
			}
			for (int k = 0; k < list2.Count; k++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel3 = list2[k];
				if (limitTimeActivityTaskDataModel3 != null)
				{
					this.curDay = (int)limitTimeActivityTaskDataModel3.DoneNum;
					bool bIsShowArrow2 = k != list2.Count - 1;
					this._AddItem(gameObject, limitTimeActivityTaskDataModel3, data, this.mNumberDayItemRoot, bIsShowArrow2);
				}
			}
			if (this.mNumberDay != null)
			{
				this.mNumberDay.text = string.Format("({0}/{1})", this.curDay, this.totalDay);
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F6E1 RID: 63201 RVA: 0x0042BC10 File Offset: 0x0042A010
		protected void _AddItem(GameObject go, ILimitTimeActivityTaskDataModel taskData, ILimitTimeActivityModel data, RectTransform goParent, bool bIsShowArrow)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(goParent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(taskData.DataId, data.Id, taskData, this.mOnItemClick);
			(gameObject.GetComponent<IActivityCommonItem>() as OnLineGiftGivingItem).OnSetArrowIsShow(bIsShowArrow);
			this.mItems.Add(taskData.DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x040097B2 RID: 38834
		[SerializeField]
		protected RectTransform mOnLineGiftItemRoot;

		// Token: 0x040097B3 RID: 38835
		[SerializeField]
		protected RectTransform mNumberDayItemRoot;

		// Token: 0x040097B4 RID: 38836
		[SerializeField]
		protected ActiveUpdate mActiveUpdate;

		// Token: 0x040097B5 RID: 38837
		[SerializeField]
		protected Text mNumberDay;

		// Token: 0x040097B6 RID: 38838
		[SerializeField]
		private Text mActivityTime;

		// Token: 0x040097B7 RID: 38839
		[SerializeField]
		private Text mActivityRule;

		// Token: 0x040097B8 RID: 38840
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x040097B9 RID: 38841
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040097BA RID: 38842
		protected ILimitTimeActivityModel mModel;

		// Token: 0x040097BB RID: 38843
		private int totalonLineTime;

		// Token: 0x040097BC RID: 38844
		private int totalDay;

		// Token: 0x040097BD RID: 38845
		private int curDay;
	}
}
