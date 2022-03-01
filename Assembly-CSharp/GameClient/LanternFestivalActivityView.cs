using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001899 RID: 6297
	public class LanternFestivalActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F64E RID: 63054 RVA: 0x00427B59 File Offset: 0x00425F59
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

		// Token: 0x0600F64F RID: 63055 RVA: 0x00427B88 File Offset: 0x00425F88
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

		// Token: 0x0600F650 RID: 63056 RVA: 0x00427D1C File Offset: 0x0042611C
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

		// Token: 0x0600F651 RID: 63057 RVA: 0x00427DB0 File Offset: 0x004261B0
		protected new void _AddItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoots[id].transform, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x0600F652 RID: 63058 RVA: 0x00427E34 File Offset: 0x00426234
		private void _UpdateTitleInfo(ILimitTimeActivityModel model)
		{
			this.mTextTime.SafeSetText(string.Format("{0}", Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
			this.mTextRule.SafeSetText(model.RuleDesc);
			if (this.mBg != null && model.LogoPath != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBg, model.LogoPath, true);
			}
			if (this.mHelpAssistant != null)
			{
				if (model.Param == 4U)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_APRILFOOLSDAYACTIVITY;
				}
				else if (model.Param == 5U)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_AT_DRAGONBOATFESTIVALACTIVITY;
				}
			}
		}

		// Token: 0x0600F653 RID: 63059 RVA: 0x00427EF0 File Offset: 0x004262F0
		private void _UpdateProgressInfo(ILimitTimeActivityModel model)
		{
			if (this.mImageProgresss != null && model.ParamArray != null && model.ParamArray.Length > 1)
			{
				float num = 0f;
				for (int i = 0; i < model.TaskDatas.Count; i++)
				{
					num += model.TaskDatas[i].DoneNum;
				}
				this.mImageProgresss.fillAmount = num / model.ParamArray[0];
				this.mTextTotalProgrees.SafeSetText(string.Format("{0}/{1}", num, model.ParamArray[0]));
			}
			if (model.ParamArray != null && model.ParamArray.Length >= 2)
			{
				string name = string.Format("{0}{1}", model.Id, CounterKeys.OPACT_MAGPIE_BRIDGE_DAILY_PROGRESS);
				int count = DataManager<CountDataManager>.GetInstance().GetCount(name);
				uint num2 = model.ParamArray[1];
				this.mTextTodayFalling.SafeSetText(string.Format("{0}/{1}", count, num2));
			}
		}

		// Token: 0x0400971E RID: 38686
		[SerializeField]
		private GameObject[] mItemRoots = new GameObject[0];

		// Token: 0x0400971F RID: 38687
		[SerializeField]
		private Text mTextTime;

		// Token: 0x04009720 RID: 38688
		[SerializeField]
		private Text mTextRule;

		// Token: 0x04009721 RID: 38689
		[SerializeField]
		private Text mTextTodayFalling;

		// Token: 0x04009722 RID: 38690
		[SerializeField]
		private Text mTextTotalProgrees;

		// Token: 0x04009723 RID: 38691
		[SerializeField]
		private Image mImageProgresss;

		// Token: 0x04009724 RID: 38692
		[SerializeField]
		private Image mBg;

		// Token: 0x04009725 RID: 38693
		[SerializeField]
		private HelpAssistant mHelpAssistant;
	}
}
