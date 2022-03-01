using System;
using System.Collections.Generic;

namespace ActivityLimitTime
{
	// Token: 0x020011BA RID: 4538
	public class ActivityLimitTimeDetailData
	{
		// Token: 0x0600AE30 RID: 44592 RVA: 0x0025FABA File Offset: 0x0025DEBA
		public ActivityLimitTimeDetailData()
		{
			this.ResetData();
		}

		// Token: 0x17001A89 RID: 6793
		// (get) Token: 0x0600AE31 RID: 44593 RVA: 0x0025FAD3 File Offset: 0x0025DED3
		// (set) Token: 0x0600AE32 RID: 44594 RVA: 0x0025FADB File Offset: 0x0025DEDB
		public uint DataId
		{
			get
			{
				return this.dataId;
			}
			set
			{
				this.dataId = value;
			}
		}

		// Token: 0x17001A8A RID: 6794
		// (get) Token: 0x0600AE33 RID: 44595 RVA: 0x0025FAE4 File Offset: 0x0025DEE4
		// (set) Token: 0x0600AE34 RID: 44596 RVA: 0x0025FAEC File Offset: 0x0025DEEC
		public ActivityTaskState ActivityDetailState
		{
			get
			{
				return this.activityDetailState;
			}
			set
			{
				this.activityDetailState = value;
			}
		}

		// Token: 0x17001A8B RID: 6795
		// (get) Token: 0x0600AE35 RID: 44597 RVA: 0x0025FAF5 File Offset: 0x0025DEF5
		// (set) Token: 0x0600AE36 RID: 44598 RVA: 0x0025FAFD File Offset: 0x0025DEFD
		public string ActivityTaskDesc
		{
			get
			{
				return this.activityTaskDesc;
			}
			set
			{
				this.activityTaskDesc = value;
			}
		}

		// Token: 0x17001A8C RID: 6796
		// (get) Token: 0x0600AE37 RID: 44599 RVA: 0x0025FB06 File Offset: 0x0025DF06
		// (set) Token: 0x0600AE38 RID: 44600 RVA: 0x0025FB0E File Offset: 0x0025DF0E
		public int DoneNum
		{
			get
			{
				return this.doneNum;
			}
			set
			{
				this.doneNum = value;
			}
		}

		// Token: 0x17001A8D RID: 6797
		// (get) Token: 0x0600AE39 RID: 44601 RVA: 0x0025FB17 File Offset: 0x0025DF17
		// (set) Token: 0x0600AE3A RID: 44602 RVA: 0x0025FB1F File Offset: 0x0025DF1F
		public int TotalNum
		{
			get
			{
				return this.totalNum;
			}
			set
			{
				this.totalNum = value;
			}
		}

		// Token: 0x17001A8E RID: 6798
		// (get) Token: 0x0600AE3B RID: 44603 RVA: 0x0025FB28 File Offset: 0x0025DF28
		// (set) Token: 0x0600AE3C RID: 44604 RVA: 0x0025FB30 File Offset: 0x0025DF30
		public List<int> ParamNums
		{
			get
			{
				return this.paramNums;
			}
			set
			{
				this.paramNums = value;
			}
		}

		// Token: 0x0600AE3D RID: 44605 RVA: 0x0025FB39 File Offset: 0x0025DF39
		public void ResetData()
		{
			this.activityDetailState = ActivityTaskState.Init;
			this.doneNum = 0;
			this.totalNum = 0;
			this.paramNums = null;
			if (this.awardDataList != null)
			{
				this.awardDataList.Clear();
			}
		}

		// Token: 0x0400617D RID: 24957
		private uint dataId;

		// Token: 0x0400617E RID: 24958
		private ActivityTaskState activityDetailState;

		// Token: 0x0400617F RID: 24959
		private string activityTaskDesc;

		// Token: 0x04006180 RID: 24960
		private int doneNum;

		// Token: 0x04006181 RID: 24961
		private int totalNum;

		// Token: 0x04006182 RID: 24962
		private List<int> paramNums;

		// Token: 0x04006183 RID: 24963
		public List<ActivityLimitTimeAward> awardDataList = new List<ActivityLimitTimeAward>();
	}
}
