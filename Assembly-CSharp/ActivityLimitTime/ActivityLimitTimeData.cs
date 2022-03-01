using System;
using System.Collections.Generic;
using Protocol;

namespace ActivityLimitTime
{
	// Token: 0x020011B9 RID: 4537
	public class ActivityLimitTimeData
	{
		// Token: 0x0600AE14 RID: 44564 RVA: 0x0025F954 File Offset: 0x0025DD54
		public ActivityLimitTimeData()
		{
			this.ResetData();
		}

		// Token: 0x17001A7C RID: 6780
		// (get) Token: 0x0600AE15 RID: 44565 RVA: 0x0025F96D File Offset: 0x0025DD6D
		// (set) Token: 0x0600AE16 RID: 44566 RVA: 0x0025F975 File Offset: 0x0025DD75
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

		// Token: 0x17001A7D RID: 6781
		// (get) Token: 0x0600AE17 RID: 44567 RVA: 0x0025F97E File Offset: 0x0025DD7E
		// (set) Token: 0x0600AE18 RID: 44568 RVA: 0x0025F986 File Offset: 0x0025DD86
		public ActivityState ActivityState
		{
			get
			{
				return this.activityState;
			}
			set
			{
				this.activityState = value;
			}
		}

		// Token: 0x17001A7E RID: 6782
		// (get) Token: 0x0600AE19 RID: 44569 RVA: 0x0025F98F File Offset: 0x0025DD8F
		// (set) Token: 0x0600AE1A RID: 44570 RVA: 0x0025F997 File Offset: 0x0025DD97
		public OpActivityTmpType ActivityType
		{
			get
			{
				return this.activityType;
			}
			set
			{
				this.activityType = value;
			}
		}

		// Token: 0x17001A7F RID: 6783
		// (get) Token: 0x0600AE1B RID: 44571 RVA: 0x0025F9A0 File Offset: 0x0025DDA0
		// (set) Token: 0x0600AE1C RID: 44572 RVA: 0x0025F9A8 File Offset: 0x0025DDA8
		public ActivityTabTag ActivityTabTag
		{
			get
			{
				return this.activityTabTag;
			}
			set
			{
				this.activityTabTag = value;
			}
		}

		// Token: 0x17001A80 RID: 6784
		// (get) Token: 0x0600AE1D RID: 44573 RVA: 0x0025F9B1 File Offset: 0x0025DDB1
		// (set) Token: 0x0600AE1E RID: 44574 RVA: 0x0025F9B9 File Offset: 0x0025DDB9
		public ActivityCircleType ActivityCircleType
		{
			get
			{
				return this.activityCircleType;
			}
			set
			{
				this.activityCircleType = value;
			}
		}

		// Token: 0x17001A81 RID: 6785
		// (get) Token: 0x0600AE1F RID: 44575 RVA: 0x0025F9C2 File Offset: 0x0025DDC2
		// (set) Token: 0x0600AE20 RID: 44576 RVA: 0x0025F9CA File Offset: 0x0025DDCA
		public string ActivityTabName
		{
			get
			{
				return this.activityTabName;
			}
			set
			{
				this.activityTabName = value;
			}
		}

		// Token: 0x17001A82 RID: 6786
		// (get) Token: 0x0600AE21 RID: 44577 RVA: 0x0025F9D3 File Offset: 0x0025DDD3
		// (set) Token: 0x0600AE22 RID: 44578 RVA: 0x0025F9DB File Offset: 0x0025DDDB
		public string LogoDesc
		{
			get
			{
				return this.logoDesc;
			}
			set
			{
				this.logoDesc = value;
			}
		}

		// Token: 0x17001A83 RID: 6787
		// (get) Token: 0x0600AE23 RID: 44579 RVA: 0x0025F9E4 File Offset: 0x0025DDE4
		// (set) Token: 0x0600AE24 RID: 44580 RVA: 0x0025F9EC File Offset: 0x0025DDEC
		public string ActivityTimePre
		{
			get
			{
				return this.activityTimePre;
			}
			set
			{
				this.activityTimePre = value;
			}
		}

		// Token: 0x17001A84 RID: 6788
		// (get) Token: 0x0600AE25 RID: 44581 RVA: 0x0025F9F5 File Offset: 0x0025DDF5
		// (set) Token: 0x0600AE26 RID: 44582 RVA: 0x0025F9FD File Offset: 0x0025DDFD
		public string Description { get; set; }

		// Token: 0x17001A85 RID: 6789
		// (get) Token: 0x0600AE27 RID: 44583 RVA: 0x0025FA06 File Offset: 0x0025DE06
		// (set) Token: 0x0600AE28 RID: 44584 RVA: 0x0025FA0E File Offset: 0x0025DE0E
		public uint ActivityStartTime
		{
			get
			{
				return this.activityStartTime;
			}
			set
			{
				this.activityStartTime = value;
			}
		}

		// Token: 0x17001A86 RID: 6790
		// (get) Token: 0x0600AE29 RID: 44585 RVA: 0x0025FA17 File Offset: 0x0025DE17
		// (set) Token: 0x0600AE2A RID: 44586 RVA: 0x0025FA1F File Offset: 0x0025DE1F
		public uint ActivityEndTime
		{
			get
			{
				return this.activityEndTime;
			}
			set
			{
				this.activityEndTime = value;
			}
		}

		// Token: 0x17001A87 RID: 6791
		// (get) Token: 0x0600AE2B RID: 44587 RVA: 0x0025FA28 File Offset: 0x0025DE28
		// (set) Token: 0x0600AE2C RID: 44588 RVA: 0x0025FA30 File Offset: 0x0025DE30
		public string ActivityRole
		{
			get
			{
				return this.activityRole;
			}
			set
			{
				this.activityRole = value;
			}
		}

		// Token: 0x17001A88 RID: 6792
		// (get) Token: 0x0600AE2D RID: 44589 RVA: 0x0025FA39 File Offset: 0x0025DE39
		// (set) Token: 0x0600AE2E RID: 44590 RVA: 0x0025FA41 File Offset: 0x0025DE41
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

		// Token: 0x0600AE2F RID: 44591 RVA: 0x0025FA4C File Offset: 0x0025DE4C
		public void ResetData()
		{
			this.activityState = ActivityState.None;
			this.activityType = OpActivityTmpType.OAT_NONE;
			this.activityTabTag = ActivityTabTag.None;
			this.activityCircleType = ActivityCircleType.None;
			this.activityTabName = string.Empty;
			this.activityStartTime = 0U;
			this.activityEndTime = 0U;
			this.activityRole = string.Empty;
			this.activityTaskDesc = string.Empty;
			if (this.activityDetailDataList != null)
			{
				this.activityDetailDataList.Clear();
			}
		}

		// Token: 0x0400616F RID: 24943
		private uint dataId;

		// Token: 0x04006170 RID: 24944
		private ActivityState activityState;

		// Token: 0x04006171 RID: 24945
		private OpActivityTmpType activityType;

		// Token: 0x04006172 RID: 24946
		private ActivityTabTag activityTabTag;

		// Token: 0x04006173 RID: 24947
		private ActivityCircleType activityCircleType;

		// Token: 0x04006174 RID: 24948
		private string activityTabName;

		// Token: 0x04006175 RID: 24949
		private string logoDesc;

		// Token: 0x04006176 RID: 24950
		private string activityTimePre;

		// Token: 0x04006178 RID: 24952
		private uint activityStartTime;

		// Token: 0x04006179 RID: 24953
		private uint activityEndTime;

		// Token: 0x0400617A RID: 24954
		private string activityRole;

		// Token: 0x0400617B RID: 24955
		private string activityTaskDesc;

		// Token: 0x0400617C RID: 24956
		public List<ActivityLimitTimeDetailData> activityDetailDataList = new List<ActivityLimitTimeDetailData>();
	}
}
