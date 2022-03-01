using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200189B RID: 6299
	public class LevelFightActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x17001CFD RID: 7421
		// (set) Token: 0x0600F661 RID: 63073 RVA: 0x004285FF File Offset: 0x004269FF
		public UnityAction OnButtonClick
		{
			set
			{
				this.mButtonGoTo.SafeRemoveAllListener();
				this.mButtonGoTo.SafeAddOnClickListener(value);
			}
		}

		// Token: 0x0600F662 RID: 63074 RVA: 0x00428618 File Offset: 0x00426A18
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			this.mNote.ShowLogoText(false);
		}

		// Token: 0x0600F663 RID: 63075 RVA: 0x00428630 File Offset: 0x00426A30
		public void SetRank(int rank)
		{
			if (rank != 0)
			{
				this.mTextMyRank.text = string.Format(TR.Value("activity_level_fight_rank_succeeded"), rank);
			}
			else
			{
				this.mTextMyRank.text = string.Format(TR.Value("activity_level_fight_rank_failed"), new object[0]);
			}
		}

		// Token: 0x0600F664 RID: 63076 RVA: 0x00428688 File Offset: 0x00426A88
		public void ShowPlayerName(bool isShow)
		{
			this.mPlayerNameTitle.CustomActive(isShow);
		}

		// Token: 0x0600F665 RID: 63077 RVA: 0x00428696 File Offset: 0x00426A96
		public void SetEndTime(int endTime)
		{
			this.mEndTime = endTime;
			this.mTextMyRank.CustomActive(true);
			base.InvokeRepeating("_UpdateTime", 0f, 1f);
		}

		// Token: 0x0600F666 RID: 63078 RVA: 0x004286C0 File Offset: 0x00426AC0
		public void ShowResultText(int num)
		{
			this.mTextMyRank.CustomActive(true);
			this.mTextTime.SafeSetText(string.Format(TR.Value("activity_level_fight_show_end_time"), num));
		}

		// Token: 0x0600F667 RID: 63079 RVA: 0x004286EE File Offset: 0x00426AEE
		public override void Dispose()
		{
			base.Dispose();
			this.mButtonGoTo.SafeRemoveAllListener();
		}

		// Token: 0x0600F668 RID: 63080 RVA: 0x00428701 File Offset: 0x00426B01
		private void _UpdateTime()
		{
			if (this.mEndTime == 0)
			{
				base.CancelInvoke("_UpdateTime");
				return;
			}
			this.mTextTime.SafeSetText(string.Format(TR.Value("activity_level_fight_end_time"), Function.SetShowTime(this.mEndTime)));
		}

		// Token: 0x04009730 RID: 38704
		[SerializeField]
		private Text mTextMyRank;

		// Token: 0x04009731 RID: 38705
		[SerializeField]
		private Text mTextTime;

		// Token: 0x04009732 RID: 38706
		[SerializeField]
		private GameObject mPlayerNameTitle;

		// Token: 0x04009733 RID: 38707
		[SerializeField]
		private Button mButtonGoTo;

		// Token: 0x04009734 RID: 38708
		private int mEndTime;
	}
}
