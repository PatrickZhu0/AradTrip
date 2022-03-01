using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FF RID: 6399
	public class NewYearOnDayItem : ActivityItemBase
	{
		// Token: 0x0600F961 RID: 63841 RVA: 0x004412C4 File Offset: 0x0043F6C4
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mTaskDesTxt.SafeSetText(data.Desc);
			this.mTaskProgressTxt.SafeSetText(TR.Value("NewYearOnDay_TaskProgress", data.DoneNum, data.TotalNum));
			this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					this._CreateItem(data.AwardDataList[i]);
				}
			}
		}

		// Token: 0x0600F962 RID: 63842 RVA: 0x00441360 File Offset: 0x0043F760
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mUnFinishGo.CustomActive(true);
				this.mReceiveBtn.CustomActive(false);
				this.mHaveReceiveGo.CustomActive(false);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mReceiveBtn.CustomActive(true);
				this.mUnFinishGo.CustomActive(false);
				this.mHaveReceiveGo.CustomActive(false);
				break;
			case OpActTaskState.OATS_OVER:
				this.mHaveReceiveGo.CustomActive(true);
				this.mUnFinishGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
				break;
			}
			this.mTaskProgressTxt.SafeSetText(TR.Value("NewYearOnDay_TaskProgress", data.DoneNum, data.TotalNum));
		}

		// Token: 0x0600F963 RID: 63843 RVA: 0x0044143D File Offset: 0x0043F83D
		public override void Dispose()
		{
			base.Dispose();
			this.mReceiveBtn.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F964 RID: 63844 RVA: 0x00441460 File Offset: 0x0043F860
		private void _CreateItem(OpTaskReward opTaskReward)
		{
			if (opTaskReward != null)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRootGo);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (comItem != null && itemData != null)
				{
					comItem.GetComponent<RectTransform>().sizeDelta = this.mComItemSize;
					itemData.Count = (int)opTaskReward.num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (NewYearOnDayItem.<>f__mg$cache0 == null)
					{
						NewYearOnDayItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, NewYearOnDayItem.<>f__mg$cache0);
				}
			}
		}

		// Token: 0x04009B29 RID: 39721
		[SerializeField]
		private Text mTaskDesTxt;

		// Token: 0x04009B2A RID: 39722
		[SerializeField]
		private Text mTaskProgressTxt;

		// Token: 0x04009B2B RID: 39723
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009B2C RID: 39724
		[SerializeField]
		private GameObject mUnFinishGo;

		// Token: 0x04009B2D RID: 39725
		[SerializeField]
		private GameObject mHaveReceiveGo;

		// Token: 0x04009B2E RID: 39726
		[SerializeField]
		private GameObject mItemRootGo;

		// Token: 0x04009B2F RID: 39727
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B30 RID: 39728
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
