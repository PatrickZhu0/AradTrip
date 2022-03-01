using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FB RID: 6395
	public class LimitTimeHellItem : ActivityItemBase
	{
		// Token: 0x0600F936 RID: 63798 RVA: 0x0043F988 File Offset: 0x0043DD88
		public override void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mActivityData = data;
			this.mOnItemClick = onItemClick;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i].State != OpActTaskState.OATS_OVER)
				{
					this.InitTaskItem(data.TaskDatas[i]);
					break;
				}
			}
			if (data.TaskDatas.Count > 0 && data.TaskDatas[data.TaskDatas.Count - 1].State == OpActTaskState.OATS_OVER)
			{
				this.InitTaskItem(data.TaskDatas[data.TaskDatas.Count - 1]);
			}
		}

		// Token: 0x0600F937 RID: 63799 RVA: 0x0043FA44 File Offset: 0x0043DE44
		private void InitTaskItem(ILimitTimeActivityTaskDataModel taskData)
		{
			this.mId = taskData.DataId;
			if (taskData != null && taskData.AwardDataList != null)
			{
				if (this.mComItems != null)
				{
					for (int i = this.mComItems.Count - 1; i >= 0; i--)
					{
						ComItemManager.Destroy(this.mComItems[i]);
					}
					this.mComItems.Clear();
				}
				for (int j = 0; j < taskData.AwardDataList.Count; j++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)taskData.AwardDataList[j].id, 100, 0);
						itemData.Count = (int)taskData.AwardDataList[j].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (LimitTimeHellItem.<>f__mg$cache0 == null)
						{
							LimitTimeHellItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, LimitTimeHellItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (taskData.AwardDataList.Count > this.mScrollCount);
			}
			this.mDes.text = taskData.Desc;
			if (taskData.DoneNum > this.mActivityData.Param)
			{
				this.mCount.text = string.Format("{0}/{1}", this.mActivityData.Param, this.mActivityData.Param);
			}
			else
			{
				this.mCount.text = string.Format("{0}/{1}", taskData.DoneNum, this.mActivityData.Param);
			}
			this.mTaskCount.text = this.GetTaskCount();
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			if (taskData.State != OpActTaskState.OATS_FINISHED)
			{
				this.mButtonExchangeGray.enabled = true;
				this.mButtonExchange.interactable = false;
			}
			else
			{
				this.mButtonExchangeGray.enabled = false;
				this.mButtonExchange.interactable = true;
			}
		}

		// Token: 0x0600F938 RID: 63800 RVA: 0x0043FC94 File Offset: 0x0043E094
		private string GetTaskCount()
		{
			int num = 0;
			for (int i = 0; i < this.mActivityData.TaskDatas.Count; i++)
			{
				if (this.mActivityData.TaskDatas[i].State == OpActTaskState.OATS_OVER)
				{
					num++;
				}
			}
			return string.Format("{0}/{1}", this.mActivityData.TaskDatas.Count - num, this.mActivityData.TaskDatas.Count);
		}

		// Token: 0x0600F939 RID: 63801 RVA: 0x0043FD1C File Offset: 0x0043E11C
		private void tryUpdateTask(ILimitTimeActivityModel data)
		{
			if (this.mActivityData == null)
			{
				this.mActivityData = data;
			}
			for (int i = 0; i < this.mActivityData.TaskDatas.Count; i++)
			{
				if (this.mActivityData.TaskDatas[i].State != OpActTaskState.OATS_OVER)
				{
					this.InitTaskItem(this.mActivityData.TaskDatas[i]);
					break;
				}
			}
			if (this.mActivityData.TaskDatas.Count > 0 && this.mActivityData.TaskDatas[this.mActivityData.TaskDatas.Count - 1].State == OpActTaskState.OATS_OVER)
			{
				this.InitTaskItem(this.mActivityData.TaskDatas[this.mActivityData.TaskDatas.Count - 1]);
			}
		}

		// Token: 0x0600F93A RID: 63802 RVA: 0x0043FE04 File Offset: 0x0043E204
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			Logger.LogErrorFormat("old updateData", new object[0]);
		}

		// Token: 0x0600F93B RID: 63803 RVA: 0x0043FE16 File Offset: 0x0043E216
		public void UpdateFromMode(ILimitTimeActivityModel data)
		{
			this.tryUpdateTask(data);
		}

		// Token: 0x0600F93C RID: 63804 RVA: 0x0043FE1F File Offset: 0x0043E21F
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F93D RID: 63805 RVA: 0x0043FE24 File Offset: 0x0043E224
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F93E RID: 63806 RVA: 0x0043FE94 File Offset: 0x0043E294
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x04009AF1 RID: 39665
		[SerializeField]
		private Text mDes;

		// Token: 0x04009AF2 RID: 39666
		[SerializeField]
		private Text mCount;

		// Token: 0x04009AF3 RID: 39667
		[SerializeField]
		private Text mTaskCount;

		// Token: 0x04009AF4 RID: 39668
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009AF5 RID: 39669
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009AF6 RID: 39670
		[SerializeField]
		private Button mButtonExchange;

		// Token: 0x04009AF7 RID: 39671
		[SerializeField]
		private UIGray mButtonExchangeGray;

		// Token: 0x04009AF8 RID: 39672
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009AF9 RID: 39673
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009AFA RID: 39674
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009AFB RID: 39675
		private ILimitTimeActivityModel mActivityData;

		// Token: 0x04009AFC RID: 39676
		private ILimitTimeActivityModel mActivityDataNew;

		// Token: 0x04009AFD RID: 39677
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
