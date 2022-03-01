using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DC RID: 6364
	public class ChristmasSnowmanItem : ActivityItemBase
	{
		// Token: 0x0600F87B RID: 63611 RVA: 0x004396DC File Offset: 0x00437ADC
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mUnFinishBtn.CustomActive(true);
				this.mFinishBtn.CustomActive(false);
				this.mOverBtn.CustomActive(false);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mUnFinishBtn.CustomActive(false);
				this.mFinishBtn.CustomActive(true);
				this.mOverBtn.CustomActive(false);
				break;
			case OpActTaskState.OATS_OVER:
				this.mUnFinishBtn.CustomActive(false);
				this.mFinishBtn.CustomActive(false);
				this.mOverBtn.CustomActive(true);
				break;
			}
		}

		// Token: 0x0600F87C RID: 63612 RVA: 0x004397A0 File Offset: 0x00437BA0
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.SetItemInfo(data);
			if (this.mUnFinishBtn != null)
			{
				this.mUnFinishBtn.onClick.RemoveAllListeners();
				this.mUnFinishBtn.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(this.mItemData, null, 4, true, false, true);
				});
			}
			if (this.mFinishBtn != null)
			{
				this.mFinishBtn.onClick.RemoveAllListeners();
				this.mFinishBtn.onClick.AddListener(new UnityAction(this._OnItemClick));
			}
			if (this.mOverBtn != null)
			{
				this.mOverBtn.onClick.RemoveAllListeners();
				this.mOverBtn.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(this.mItemData, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x0600F87D RID: 63613 RVA: 0x0043986C File Offset: 0x00437C6C
		public sealed override void Dispose()
		{
			base.Dispose();
			if (this.mUnFinishBtn != null)
			{
				this.mUnFinishBtn.onClick.RemoveAllListeners();
			}
			if (this.mFinishBtn != null)
			{
				this.mFinishBtn.onClick.RemoveAllListeners();
			}
			if (this.mOverBtn != null)
			{
				this.mOverBtn.onClick.RemoveAllListeners();
			}
			this.mItemData = null;
		}

		// Token: 0x0600F87E RID: 63614 RVA: 0x004398EC File Offset: 0x00437CEC
		private void SetItemInfo(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList.Count > 0)
			{
				int id = (int)data.AwardDataList[0].id;
				int num = (int)data.AwardDataList[0].num;
				this.mItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(id);
				if (this.mItemData == null)
				{
					return;
				}
				ETCImageLoader.LoadSprite(ref this.mIconImage, this.mItemData.Icon, true);
				if (num > 1 && this.mItemCount != null)
				{
					this.mItemCount.text = num.ToString();
				}
			}
		}

		// Token: 0x040099C2 RID: 39362
		[SerializeField]
		private Button mUnFinishBtn;

		// Token: 0x040099C3 RID: 39363
		[SerializeField]
		private Button mFinishBtn;

		// Token: 0x040099C4 RID: 39364
		[SerializeField]
		private Button mOverBtn;

		// Token: 0x040099C5 RID: 39365
		[SerializeField]
		private Image mIconImage;

		// Token: 0x040099C6 RID: 39366
		[SerializeField]
		private Text mItemCount;

		// Token: 0x040099C7 RID: 39367
		private ItemData mItemData;
	}
}
