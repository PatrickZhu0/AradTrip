using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001887 RID: 6279
	public class ConsumeRebateActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5D0 RID: 62928 RVA: 0x0042535B File Offset: 0x0042375B
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			this.mHaveConsumePointTxt.SafeSetText(string.Format(TR.Value("ConsumePoint_TipContent"), this.GetCurConsumePoint(model), this.GetTotalConsumePoint(model)));
		}

		// Token: 0x0600F5D1 RID: 62929 RVA: 0x00425398 File Offset: 0x00423798
		private int GetCurConsumePoint(ILimitTimeActivityModel model)
		{
			int num = 0;
			if (model == null)
			{
				return num;
			}
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = model.TaskDatas[i];
				if (limitTimeActivityTaskDataModel == null)
				{
					return num;
				}
				if ((ulong)limitTimeActivityTaskDataModel.DoneNum > (ulong)((long)num))
				{
					num = (int)limitTimeActivityTaskDataModel.DoneNum;
				}
			}
			return num;
		}

		// Token: 0x0600F5D2 RID: 62930 RVA: 0x004253F8 File Offset: 0x004237F8
		private int GetTotalConsumePoint(ILimitTimeActivityModel model)
		{
			int result = 0;
			if (model == null)
			{
				return result;
			}
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = model.TaskDatas[i];
				if (limitTimeActivityTaskDataModel == null)
				{
					return result;
				}
				if (i == model.TaskDatas.Count - 1)
				{
					result = (int)limitTimeActivityTaskDataModel.TotalNum;
				}
			}
			return result;
		}

		// Token: 0x040096C8 RID: 38600
		[SerializeField]
		private Text mHaveConsumePointTxt;
	}
}
