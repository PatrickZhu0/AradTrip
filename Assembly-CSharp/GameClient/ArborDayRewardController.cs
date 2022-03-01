using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001871 RID: 6257
	public class ArborDayRewardController : MonoBehaviour
	{
		// Token: 0x0600F525 RID: 62757 RVA: 0x004220B8 File Offset: 0x004204B8
		public void InitRewardController(ILimitTimeActivityModel model)
		{
			this._model = model;
			if (this._model == null)
			{
				return;
			}
			List<ILimitTimeActivityTaskDataModel> taskDatas = this._model.TaskDatas;
			if (taskDatas == null || taskDatas.Count <= 0)
			{
				return;
			}
			this._firstTaskDataModel = taskDatas[0];
			if (this._firstTaskDataModel == null)
			{
				Logger.LogErrorFormat("RewardTaskDataModel is null", new object[0]);
				return;
			}
			this._firstRewardItemId = ArborDayUtility.GetRewardItemId(this._firstTaskDataModel);
			this.InitRewardDescription();
			this.InitRewardItem();
		}

		// Token: 0x0600F526 RID: 62758 RVA: 0x00422140 File Offset: 0x00420540
		public void OnUpdateRewardController(ILimitTimeActivityModel activityModel)
		{
			if (activityModel == null || activityModel.TaskDatas == null || activityModel.TaskDatas.Count <= 0)
			{
				return;
			}
			this._firstTaskDataModel = activityModel.TaskDatas[0];
			if (this.firstRewardItem != null)
			{
				this.firstRewardItem.UpdateItem(this._firstTaskDataModel);
			}
		}

		// Token: 0x0600F527 RID: 62759 RVA: 0x004221A4 File Offset: 0x004205A4
		private void InitRewardDescription()
		{
			if (this.rewardDescriptionLabel == null)
			{
				return;
			}
			string desc = this._firstTaskDataModel.Desc;
			string rewardItemName = ArborDayUtility.GetRewardItemName(this._firstRewardItemId);
			string text = string.Format(TR.Value("Arbor_Day_Reward_Detail_Label"), desc, rewardItemName);
			this.rewardDescriptionLabel.text = text;
		}

		// Token: 0x0600F528 RID: 62760 RVA: 0x004221F9 File Offset: 0x004205F9
		private void InitRewardItem()
		{
			if (this.firstRewardItem != null)
			{
				this.firstRewardItem.InitItem(this._firstTaskDataModel, this._model.Id);
			}
		}

		// Token: 0x04009652 RID: 38482
		private ILimitTimeActivityModel _model;

		// Token: 0x04009653 RID: 38483
		private ILimitTimeActivityTaskDataModel _firstTaskDataModel;

		// Token: 0x04009654 RID: 38484
		private int _firstRewardItemId;

		// Token: 0x04009655 RID: 38485
		[SerializeField]
		private Text rewardDescriptionLabel;

		// Token: 0x04009656 RID: 38486
		[Space(10f)]
		[Header("Reward")]
		[Space(10f)]
		[SerializeField]
		private ArborDayRewardItem firstRewardItem;
	}
}
