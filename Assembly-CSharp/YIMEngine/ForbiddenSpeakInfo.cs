using System;

namespace YIMEngine
{
	// Token: 0x02004A63 RID: 19043
	public class ForbiddenSpeakInfo
	{
		// Token: 0x170024BD RID: 9405
		// (get) Token: 0x0601B93D RID: 112957 RVA: 0x0087B68F File Offset: 0x00879A8F
		// (set) Token: 0x0601B93E RID: 112958 RVA: 0x0087B697 File Offset: 0x00879A97
		public string ChannelID
		{
			get
			{
				return this.channelID;
			}
			set
			{
				this.channelID = value;
			}
		}

		// Token: 0x170024BE RID: 9406
		// (get) Token: 0x0601B93F RID: 112959 RVA: 0x0087B6A0 File Offset: 0x00879AA0
		// (set) Token: 0x0601B940 RID: 112960 RVA: 0x0087B6A8 File Offset: 0x00879AA8
		public bool IsForbidRoom
		{
			get
			{
				return this.isForbidRoom;
			}
			set
			{
				this.isForbidRoom = value;
			}
		}

		// Token: 0x170024BF RID: 9407
		// (get) Token: 0x0601B941 RID: 112961 RVA: 0x0087B6B1 File Offset: 0x00879AB1
		// (set) Token: 0x0601B942 RID: 112962 RVA: 0x0087B6B9 File Offset: 0x00879AB9
		public int ReasonType
		{
			get
			{
				return this.reasonType;
			}
			set
			{
				this.reasonType = value;
			}
		}

		// Token: 0x170024C0 RID: 9408
		// (get) Token: 0x0601B943 RID: 112963 RVA: 0x0087B6C2 File Offset: 0x00879AC2
		// (set) Token: 0x0601B944 RID: 112964 RVA: 0x0087B6CA File Offset: 0x00879ACA
		public ulong EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}

		// Token: 0x040133AC RID: 78764
		private string channelID;

		// Token: 0x040133AD RID: 78765
		private bool isForbidRoom;

		// Token: 0x040133AE RID: 78766
		private int reasonType;

		// Token: 0x040133AF RID: 78767
		private ulong endTime;
	}
}
