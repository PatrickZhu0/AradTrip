using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001813 RID: 6163
	public class AnniversaryBuffPrayActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F2C1 RID: 62145 RVA: 0x004184F4 File Offset: 0x004168F4
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleDesTxt.SafeSetText(model.RuleDesc);
			this._InitItems(model);
		}

		// Token: 0x0600F2C2 RID: 62146 RVA: 0x00418546 File Offset: 0x00416946
		public void Show()
		{
		}

		// Token: 0x0600F2C3 RID: 62147 RVA: 0x00418548 File Offset: 0x00416948
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			for (int i = 0; i < this.mTaskDataList.Count; i++)
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
					this._AddItem(gameObject, i, data, data.TaskDatas[i]);
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < this.mTaskDataList.Count; k++)
				{
					if (list[j] == this.mTaskDataList[k].DataId)
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
		}

		// Token: 0x0600F2C4 RID: 62148 RVA: 0x004186DE File Offset: 0x00416ADE
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2C5 RID: 62149 RVA: 0x004186F1 File Offset: 0x00416AF1
		public void Dispose()
		{
			this.mItems.Clear();
		}

		// Token: 0x0600F2C6 RID: 62150 RVA: 0x004186FE File Offset: 0x00416AFE
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F2C7 RID: 62151 RVA: 0x0041870C File Offset: 0x00416B0C
		private void _InitItems(ILimitTimeActivityModel data)
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
				Logger.LogError("预制体上找不到IActivityCommonItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			this.mItems.Clear();
			this.mTaskDataDic.Clear();
			this.mTaskDataList.Clear();
			this.taskTimeStr.Clear();
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (!this.mTaskDataDic.ContainsKey(data.TaskDatas[i].TotalNum))
				{
					this.mTaskDataDic.Add(data.TaskDatas[i].TotalNum, data.TaskDatas[i]);
					this.mTaskDataList.Add(data.TaskDatas[i]);
					if (data.TaskDatas[i].ParamNums != null && data.TaskDatas[i].ParamNums.Count >= 2)
					{
						this.taskTimeStr.Add(this._TransTimeStamToStr(data.TaskDatas[i].ParamNums[0], data.TaskDatas[i].ParamNums[1]));
					}
				}
				else if (data.TaskDatas[i].TotalNum == 8U)
				{
					this.mTaskDataList.Add(data.TaskDatas[i]);
					if (data.TaskDatas[i].ParamNums != null && data.TaskDatas[i].ParamNums.Count >= 2)
					{
						this.taskTimeStr.Add(this._TransTimeStamToStr(data.TaskDatas[i].ParamNums[0], data.TaskDatas[i].ParamNums[1]));
					}
				}
				else
				{
					for (int j = 0; j < this.mTaskDataList.Count; j++)
					{
						if (this.mTaskDataList[j].TotalNum == data.TaskDatas[i].TotalNum && data.TaskDatas[i].ParamNums != null && data.TaskDatas[i].ParamNums.Count >= 2)
						{
							string text = this.taskTimeStr[j];
							string arg = this._TransTimeStamToStr(data.TaskDatas[i].ParamNums[0], data.TaskDatas[i].ParamNums[1]);
							this.taskTimeStr.Remove(text);
							string item = string.Format("{0}\n{1}", text, arg);
							this.taskTimeStr.Add(item);
						}
					}
				}
			}
			for (int k = 0; k < this.mTaskDataList.Count; k++)
			{
				this._AddItem(gameObject, k, data, this.mTaskDataList[k]);
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F2C8 RID: 62152 RVA: 0x00418A58 File Offset: 0x00416E58
		private void _AddItem(GameObject go, int id, ILimitTimeActivityModel data, ILimitTimeActivityTaskDataModel taskData)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			if (data.Id == 1482U)
			{
				if (taskData.TotalNum == 6U)
				{
					Transform transform = this.mSpecialRoot1;
					gameObject.transform.SetParent(transform, false);
					gameObject.transform.localPosition = Vector3.zero;
				}
				else if (taskData.TotalNum == 7U)
				{
					Transform transform = this.mSpecialRoot2;
					gameObject.transform.SetParent(transform, false);
					gameObject.transform.localPosition = Vector3.zero;
				}
				else
				{
					Transform transform = this.mNormalRoot;
					gameObject.transform.SetParent(transform, false);
				}
			}
			else if (data.Id == 1584U)
			{
				if (taskData.TotalNum == 5U)
				{
					Transform transform = this.mSpecialRoot1;
					gameObject.transform.SetParent(transform, false);
					gameObject.transform.localPosition = Vector3.zero;
				}
				else if (taskData.TotalNum == 4U)
				{
					Transform transform = this.mSpecialRoot2;
					gameObject.transform.SetParent(transform, false);
					gameObject.transform.localPosition = Vector3.zero;
				}
				else
				{
					Transform transform = this.mNormalRoot;
					gameObject.transform.SetParent(transform, false);
				}
			}
			gameObject.GetComponent<IActivityCommonItem>().Init(this.mTaskDataList[id].DataId, data.Id, this.mTaskDataList[id], null);
			gameObject.GetComponent<AnniversaryBuffPrayItem>().ShowTime(this.taskTimeStr[id]);
			if (!this.mItems.ContainsKey(this.mTaskDataList[id].DataId))
			{
				this.mItems.Add(this.mTaskDataList[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
			}
		}

		// Token: 0x0600F2C9 RID: 62153 RVA: 0x00418C1C File Offset: 0x0041701C
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x0600F2CA RID: 62154 RVA: 0x00418C74 File Offset: 0x00417074
		private string _TransTimeStampToStrEx(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}.{1}", dateTime.Month, dateTime.Day);
		}

		// Token: 0x0600F2CB RID: 62155 RVA: 0x00418CC5 File Offset: 0x004170C5
		private string _formartTimeToStr(uint start, uint end)
		{
			return string.Format("{0}-{1}", this._TransTimeStampToStrEx(start), this._TransTimeStampToStrEx(end));
		}

		// Token: 0x0600F2CC RID: 62156 RVA: 0x00418CDF File Offset: 0x004170DF
		private string _TransTimeStamToStr(uint startTime, uint endTime)
		{
			return string.Format("{0}~{1}", this._TransTimeStampToStr(startTime), this._TransTimeStampToStr(endTime));
		}

		// Token: 0x04009533 RID: 38195
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009534 RID: 38196
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x04009535 RID: 38197
		[SerializeField]
		private Transform mNormalRoot;

		// Token: 0x04009536 RID: 38198
		[SerializeField]
		private Transform mSpecialRoot1;

		// Token: 0x04009537 RID: 38199
		[SerializeField]
		private Transform mSpecialRoot2;

		// Token: 0x04009538 RID: 38200
		private Dictionary<uint, ILimitTimeActivityTaskDataModel> mTaskDataDic = new Dictionary<uint, ILimitTimeActivityTaskDataModel>();

		// Token: 0x04009539 RID: 38201
		private List<ILimitTimeActivityTaskDataModel> mTaskDataList = new List<ILimitTimeActivityTaskDataModel>();

		// Token: 0x0400953A RID: 38202
		private List<string> taskTimeStr = new List<string>();

		// Token: 0x0400953B RID: 38203
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();
	}
}
