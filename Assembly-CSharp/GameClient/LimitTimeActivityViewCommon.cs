using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200189D RID: 6301
	public class LimitTimeActivityViewCommon : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F66E RID: 63086 RVA: 0x00417C44 File Offset: 0x00416044
		public virtual void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this.mNote.Init(model, true, null);
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (this.mModel.Id == 11013U)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mModel.TaskDatas.Find((ILimitTimeActivityTaskDataModel x) => x.DataId == 11013006U);
				if (limitTimeActivityTaskDataModel != null)
				{
					uint num = limitTimeActivityTaskDataModel.ParamNums[3];
					uint num2 = limitTimeActivityTaskDataModel.ParamNums[4];
					if (serverTime < num2)
					{
						this.mRetunGiftIsUpdate = true;
					}
				}
			}
			else if (this.mModel.Id == 11017U)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel2 = this.mModel.TaskDatas.Find((ILimitTimeActivityTaskDataModel x) => x.DataId == 11017003U);
				if (limitTimeActivityTaskDataModel2 != null)
				{
					uint num = limitTimeActivityTaskDataModel2.ParamNums[2];
					uint num2 = limitTimeActivityTaskDataModel2.ParamNums[3];
					if (serverTime < num2)
					{
						this.mRetunPrivilegeIsUpdate = true;
					}
				}
			}
		}

		// Token: 0x0600F66F RID: 63087 RVA: 0x00417D80 File Offset: 0x00416180
		private void Update()
		{
			if (this.mRetunGiftIsUpdate)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mModel.TaskDatas.Find((ILimitTimeActivityTaskDataModel x) => x.DataId == 11013006U);
				if (limitTimeActivityTaskDataModel != null)
				{
					uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
					uint num = limitTimeActivityTaskDataModel.ParamNums[3];
					uint num2 = limitTimeActivityTaskDataModel.ParamNums[4];
					if (serverTime >= num2)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, this.mModel.Id, null, null, null);
						this.mRetunGiftIsUpdate = false;
					}
					if (!this.mActivityIsStart && serverTime >= num && serverTime < num2)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, this.mModel.Id, null, null, null);
						this.mActivityIsStart = true;
					}
				}
				else
				{
					this.mRetunGiftIsUpdate = false;
				}
			}
			if (this.mRetunPrivilegeIsUpdate)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel2 = this.mModel.TaskDatas.Find((ILimitTimeActivityTaskDataModel x) => x.DataId == 11017003U);
				if (limitTimeActivityTaskDataModel2 != null)
				{
					uint serverTime2 = DataManager<TimeManager>.GetInstance().GetServerTime();
					uint num3 = limitTimeActivityTaskDataModel2.ParamNums[2];
					uint num4 = limitTimeActivityTaskDataModel2.ParamNums[3];
					if (serverTime2 >= num4)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, this.mModel.Id, null, null, null);
						this.mRetunPrivilegeIsUpdate = false;
					}
					if (!this.mActivityIsStart && serverTime2 >= num3 && serverTime2 < num4)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, this.mModel.Id, null, null, null);
						this.mActivityIsStart = true;
					}
				}
				else
				{
					this.mRetunPrivilegeIsUpdate = false;
				}
			}
		}

		// Token: 0x0600F670 RID: 63088 RVA: 0x00417F60 File Offset: 0x00416360
		public virtual void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
					if (this.mItems.ContainsKey(limitTimeActivityTaskDataModel.DataId))
					{
						this.mItems[limitTimeActivityTaskDataModel.DataId].UpdateData(limitTimeActivityTaskDataModel);
						if (limitTimeActivityTaskDataModel.DataId == 11013006U)
						{
							uint num = limitTimeActivityTaskDataModel.ParamNums[3];
							uint num2 = limitTimeActivityTaskDataModel.ParamNums[4];
							if (serverTime >= num2)
							{
								this.mItems.Remove(limitTimeActivityTaskDataModel.DataId);
							}
						}
						else if (limitTimeActivityTaskDataModel.DataId == 11017003U)
						{
							uint num = limitTimeActivityTaskDataModel.ParamNums[2];
							uint num2 = limitTimeActivityTaskDataModel.ParamNums[3];
							if (serverTime >= num2)
							{
								this.mItems.Remove(limitTimeActivityTaskDataModel.DataId);
							}
						}
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
		}

		// Token: 0x0600F671 RID: 63089 RVA: 0x00418190 File Offset: 0x00416590
		public virtual void Dispose()
		{
			foreach (IActivityCommonItem activityCommonItem in this.mItems.Values)
			{
				activityCommonItem.Dispose();
			}
			this.mItems.Clear();
			this.mOnItemClick = null;
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
			this.mModel = null;
			this.mRetunGiftIsUpdate = false;
			this.mRetunPrivilegeIsUpdate = false;
			this.mActivityIsStart = false;
		}

		// Token: 0x0600F672 RID: 63090 RVA: 0x0041823C File Offset: 0x0041663C
		public virtual void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F673 RID: 63091 RVA: 0x0041824F File Offset: 0x0041664F
		public virtual void Show()
		{
		}

		// Token: 0x0600F674 RID: 63092 RVA: 0x00418251 File Offset: 0x00416651
		public virtual void Hide()
		{
		}

		// Token: 0x0600F675 RID: 63093 RVA: 0x00418254 File Offset: 0x00416654
		protected virtual void _InitItems(ILimitTimeActivityModel data)
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
					this._AddItem(gameObject, i, data);
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F676 RID: 63094 RVA: 0x0041830C File Offset: 0x0041670C
		protected void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (data.TaskDatas[id].DataId == 11013006U)
			{
				uint num = data.TaskDatas[id].ParamNums[3];
				uint num2 = data.TaskDatas[id].ParamNums[4];
				if (serverTime < num || serverTime >= num2)
				{
					return;
				}
			}
			else if (data.TaskDatas[id].DataId == 11017003U)
			{
				uint num = data.TaskDatas[id].ParamNums[2];
				uint num2 = data.TaskDatas[id].ParamNums[3];
				if (serverTime < num || serverTime >= num2)
				{
					return;
				}
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x04009735 RID: 38709
		[SerializeField]
		protected RectTransform mItemRoot;

		// Token: 0x04009736 RID: 38710
		[SerializeField]
		protected ActivityNote mNote;

		// Token: 0x04009737 RID: 38711
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x04009738 RID: 38712
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009739 RID: 38713
		protected ILimitTimeActivityModel mModel;

		// Token: 0x0400973A RID: 38714
		protected bool mRetunGiftIsUpdate;

		// Token: 0x0400973B RID: 38715
		protected bool mRetunPrivilegeIsUpdate;

		// Token: 0x0400973C RID: 38716
		protected bool mActivityIsStart;
	}
}
