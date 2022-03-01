using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A1 RID: 6305
	public class LimitTimeHaveExtraItemActivityViewCommon : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F68C RID: 63116 RVA: 0x00428E9D File Offset: 0x0042729D
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.activityId = model.Id;
			base.Init(model, onItemClick);
		}

		// Token: 0x0600F68D RID: 63117 RVA: 0x00428EB4 File Offset: 0x004272B4
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
			this.mItems.Clear();
			this.mExtraItemRoot.CustomActive(false);
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i].CantAccept == 0)
				{
					this.mExtraItemRoot.CustomActive(true);
					if (data.TaskDatas[i].State != OpActTaskState.OATS_INIT)
					{
						this._UpdateExtraItem(data.TaskDatas[i]);
					}
				}
				else
				{
					base._AddItem(gameObject, i, data);
				}
			}
			if (this.mExtraItemRoot.activeSelf)
			{
				this.mNormalItemRoot.sizeDelta = this.mNormalItemRoot1;
			}
			else
			{
				this.mNormalItemRoot.sizeDelta = this.mNormalItemRoot2;
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F68E RID: 63118 RVA: 0x00428FE5 File Offset: 0x004273E5
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F68F RID: 63119 RVA: 0x00428FF0 File Offset: 0x004273F0
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			this.mExtraItemRoot.CustomActive(false);
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i].CantAccept == 0)
				{
					this.mExtraItemRoot.CustomActive(true);
					this._UpdateExtraItem(data.TaskDatas[i]);
				}
				else if (this.mItems.ContainsKey(data.TaskDatas[i].DataId))
				{
					this.mItems[data.TaskDatas[i].DataId].UpdateData(data.TaskDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					base._AddItem(gameObject, i, data);
				}
			}
			if (this.mExtraItemRoot.activeSelf)
			{
				this.mNormalItemRoot.sizeDelta = this.mNormalItemRoot1;
			}
			else
			{
				this.mNormalItemRoot.sizeDelta = this.mNormalItemRoot2;
			}
		}

		// Token: 0x0600F690 RID: 63120 RVA: 0x00429140 File Offset: 0x00427540
		private void _UpdateExtraItem(ILimitTimeActivityTaskDataModel data)
		{
			this.mDesc.text = data.Desc;
			this.mCount.text = string.Format("已完成{0}/{1}", data.DoneNum, data.TotalNum);
			for (int i = 0; i < this.rewardList.Count; i++)
			{
				Object.Destroy(this.rewardList[i]);
			}
			for (int j = 0; j < data.AwardDataList.Count; j++)
			{
				ComItem comItem = ComItemManager.Create(this.mRewardListRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[j].id, 100, 0);
					itemData.Count = (int)data.AwardDataList[j].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (LimitTimeHaveExtraItemActivityViewCommon.<>f__mg$cache0 == null)
					{
						LimitTimeHaveExtraItemActivityViewCommon.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, LimitTimeHaveExtraItemActivityViewCommon.<>f__mg$cache0);
					(comItem.transform as RectTransform).sizeDelta = this.mRewardSize;
					this.rewardList.Add(comItem.gameObject);
				}
			}
			this.mFinished.CustomActive(false);
			this.mUnFinish.CustomActive(false);
			this.mReceive.CustomActive(false);
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_UNFINISH)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					if (state == OpActTaskState.OATS_OVER)
					{
						this.mFinished.CustomActive(true);
					}
				}
				else
				{
					this.mReceive.CustomActive(true);
				}
			}
			else
			{
				this.mUnFinish.CustomActive(true);
			}
			this.mUnFinishBtn.onClick.RemoveAllListeners();
			this.mUnFinishBtn.onClick.AddListener(delegate()
			{
			});
			this.mReceiveBtn.onClick.RemoveAllListeners();
			this.mReceiveBtn.onClick.AddListener(delegate()
			{
				DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this.activityId, data.DataId, 0UL);
			});
		}

		// Token: 0x04009771 RID: 38769
		[SerializeField]
		private Text mDesc;

		// Token: 0x04009772 RID: 38770
		[SerializeField]
		private Text mCount;

		// Token: 0x04009773 RID: 38771
		[SerializeField]
		private GameObject mExtraItemRoot;

		// Token: 0x04009774 RID: 38772
		[SerializeField]
		private RectTransform mNormalItemRoot;

		// Token: 0x04009775 RID: 38773
		[SerializeField]
		private GameObject mFinished;

		// Token: 0x04009776 RID: 38774
		[SerializeField]
		private GameObject mUnFinish;

		// Token: 0x04009777 RID: 38775
		[SerializeField]
		private GameObject mReceive;

		// Token: 0x04009778 RID: 38776
		[SerializeField]
		private Button mUnFinishBtn;

		// Token: 0x04009779 RID: 38777
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x0400977A RID: 38778
		[SerializeField]
		private GameObject mRewardListRoot;

		// Token: 0x0400977B RID: 38779
		[SerializeField]
		private Vector2 mRewardSize = new Vector2(100f, 100f);

		// Token: 0x0400977C RID: 38780
		[SerializeField]
		private Vector2 mNormalItemRoot1 = new Vector2(1183f, 246f);

		// Token: 0x0400977D RID: 38781
		[SerializeField]
		private Vector2 mNormalItemRoot2 = new Vector2(1183f, 385f);

		// Token: 0x0400977E RID: 38782
		private uint activityId;

		// Token: 0x0400977F RID: 38783
		private List<GameObject> rewardList = new List<GameObject>();

		// Token: 0x04009780 RID: 38784
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
