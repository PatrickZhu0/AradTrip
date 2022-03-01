using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B8 RID: 6328
	public class WeeklyCheckInActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F746 RID: 63302 RVA: 0x0042E288 File Offset: 0x0042C688
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mActivityTime.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mActivityRule.SafeSetText(model.RuleDesc.Replace('|', '\n'));
			this.mBtnRecommendedDungeons.SafeRemoveAllListener();
			Button button = this.mBtnRecommendedDungeons;
			if (WeeklyCheckInActivityView.<>f__mg$cache0 == null)
			{
				WeeklyCheckInActivityView.<>f__mg$cache0 = new UnityAction(WeeklyCheckInActivityView.OnRecommendedDungeonsBtnClick);
			}
			button.SafeAddOnClickListener(WeeklyCheckInActivityView.<>f__mg$cache0);
			this.InitItems(model);
		}

		// Token: 0x0600F747 RID: 63303 RVA: 0x0042E338 File Offset: 0x0042C738
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

		// Token: 0x0600F748 RID: 63304 RVA: 0x0042E3D2 File Offset: 0x0042C7D2
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F749 RID: 63305 RVA: 0x0042E3E8 File Offset: 0x0042C7E8
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

		// Token: 0x0600F74A RID: 63306 RVA: 0x0042E464 File Offset: 0x0042C864
		public void Hide()
		{
		}

		// Token: 0x0600F74B RID: 63307 RVA: 0x0042E466 File Offset: 0x0042C866
		public void Show()
		{
		}

		// Token: 0x0600F74C RID: 63308 RVA: 0x0042E468 File Offset: 0x0042C868
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
					if (limitTimeActivityTaskDataModel.ParamNums.Count > 0)
					{
						if (limitTimeActivityTaskDataModel.ParamNums[0] == 0U)
						{
							list.Add(limitTimeActivityTaskDataModel);
						}
						else
						{
							list2.Add(limitTimeActivityTaskDataModel);
						}
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel2 = list[j];
				if (limitTimeActivityTaskDataModel2 != null)
				{
					this._AddItem(gameObject, limitTimeActivityTaskDataModel2, data, this.mSignInRoot, j);
				}
			}
			for (int k = 0; k < list2.Count; k++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel3 = list2[k];
				if (limitTimeActivityTaskDataModel3 != null)
				{
					this._AddItem(gameObject, limitTimeActivityTaskDataModel3, data, this.mCumulativeSignInRoot, k);
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F74D RID: 63309 RVA: 0x0042E5F4 File Offset: 0x0042C9F4
		protected void _AddItem(GameObject go, ILimitTimeActivityTaskDataModel taskData, ILimitTimeActivityModel data, RectTransform goParent, int index)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(goParent, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(taskData.DataId, data.Id, taskData, this.mOnItemClick);
			gameObject.GetComponent<WeeklyCheckInActivityItem>().SetBackground(index);
			this.mItems.Add(taskData.DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F74E RID: 63310 RVA: 0x0042E658 File Offset: 0x0042CA58
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x0600F74F RID: 63311 RVA: 0x0042E6D0 File Offset: 0x0042CAD0
		public static void OnRecommendedDungeonsBtnClick()
		{
			WeekSignSpringTable weekSignSpringTable = null;
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<WeekSignSpringTable>())
			{
				WeekSignSpringTable weekSignSpringTable2 = keyValuePair.Value as WeekSignSpringTable;
				if (weekSignSpringTable2 != null)
				{
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= weekSignSpringTable2.StartLv)
					{
						if ((int)DataManager<PlayerBaseData>.GetInstance().Level <= weekSignSpringTable2.EndLv)
						{
							weekSignSpringTable = weekSignSpringTable2;
							break;
						}
					}
				}
			}
			string[] array = weekSignSpringTable.AcquiredMethod.Split(new char[]
			{
				'|'
			});
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				int item = 0;
				if (int.TryParse(array[i], out item))
				{
					list.Add(item);
				}
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RecommendedDungeonsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RecommendedDungeonsFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RecommendedDungeonsFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x04009815 RID: 38933
		[SerializeField]
		private RectTransform mSignInRoot;

		// Token: 0x04009816 RID: 38934
		[SerializeField]
		private RectTransform mCumulativeSignInRoot;

		// Token: 0x04009817 RID: 38935
		[SerializeField]
		private Text mActivityTime;

		// Token: 0x04009818 RID: 38936
		[SerializeField]
		private Text mActivityRule;

		// Token: 0x04009819 RID: 38937
		[SerializeField]
		private Button mBtnRecommendedDungeons;

		// Token: 0x0400981A RID: 38938
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x0400981B RID: 38939
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400981C RID: 38940
		protected ILimitTimeActivityModel mModel;

		// Token: 0x0400981D RID: 38941
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache0;
	}
}
