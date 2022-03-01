using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B7 RID: 6327
	public class SwipePicturesToSendTicketsActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F741 RID: 63297 RVA: 0x0042E024 File Offset: 0x0042C424
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mTime.SafeSetText(TR.Value("Limit_Time_Activity_Time_Interval_Format", Function._TransTimeStampToStr(this.mModel.StartTime), Function._TransTimeStampToStr(model.EndTime)));
			this._InitItems(model);
		}

		// Token: 0x0600F742 RID: 63298 RVA: 0x0042E088 File Offset: 0x0042C488
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

		// Token: 0x0600F743 RID: 63299 RVA: 0x0042E124 File Offset: 0x0042C524
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
			this.mItems.Clear();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i] != null)
				{
					if (i == 0)
					{
						this._AddItem(gameObject, i, data, this.mContent);
					}
					else
					{
						this._AddItem(gameObject, i, data, this.mContent2);
					}
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F744 RID: 63300 RVA: 0x0042E1FC File Offset: 0x0042C5FC
		protected void _AddItem(GameObject go, int id, ILimitTimeActivityModel data, RectTransform parent)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(parent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x04009812 RID: 38930
		[SerializeField]
		private RectTransform mContent;

		// Token: 0x04009813 RID: 38931
		[SerializeField]
		private RectTransform mContent2;

		// Token: 0x04009814 RID: 38932
		[SerializeField]
		private Text mTime;
	}
}
