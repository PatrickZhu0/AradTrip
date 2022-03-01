using System;

namespace YIMEngine
{
	// Token: 0x02004A6C RID: 19052
	public class Notice
	{
		// Token: 0x170024CA RID: 9418
		// (get) Token: 0x0601B959 RID: 112985 RVA: 0x0087B77C File Offset: 0x00879B7C
		// (set) Token: 0x0601B95A RID: 112986 RVA: 0x0087B784 File Offset: 0x00879B84
		public ulong NoticeID
		{
			get
			{
				return this.uNoticeID;
			}
			set
			{
				this.uNoticeID = value;
			}
		}

		// Token: 0x170024CB RID: 9419
		// (get) Token: 0x0601B95B RID: 112987 RVA: 0x0087B78D File Offset: 0x00879B8D
		// (set) Token: 0x0601B95C RID: 112988 RVA: 0x0087B795 File Offset: 0x00879B95
		public int NoticeType
		{
			get
			{
				return this.iNoticeType;
			}
			set
			{
				this.iNoticeType = value;
			}
		}

		// Token: 0x170024CC RID: 9420
		// (get) Token: 0x0601B95D RID: 112989 RVA: 0x0087B79E File Offset: 0x00879B9E
		// (set) Token: 0x0601B95E RID: 112990 RVA: 0x0087B7A6 File Offset: 0x00879BA6
		public string ChannelID
		{
			get
			{
				return this.strChannelID;
			}
			set
			{
				this.strChannelID = value;
			}
		}

		// Token: 0x170024CD RID: 9421
		// (get) Token: 0x0601B95F RID: 112991 RVA: 0x0087B7AF File Offset: 0x00879BAF
		// (set) Token: 0x0601B960 RID: 112992 RVA: 0x0087B7B7 File Offset: 0x00879BB7
		public string Content
		{
			get
			{
				return this.strContent;
			}
			set
			{
				this.strContent = value;
			}
		}

		// Token: 0x170024CE RID: 9422
		// (get) Token: 0x0601B961 RID: 112993 RVA: 0x0087B7C0 File Offset: 0x00879BC0
		// (set) Token: 0x0601B962 RID: 112994 RVA: 0x0087B7C8 File Offset: 0x00879BC8
		public string LinkText
		{
			get
			{
				return this.strLinkeText;
			}
			set
			{
				this.strLinkeText = value;
			}
		}

		// Token: 0x170024CF RID: 9423
		// (get) Token: 0x0601B963 RID: 112995 RVA: 0x0087B7D1 File Offset: 0x00879BD1
		// (set) Token: 0x0601B964 RID: 112996 RVA: 0x0087B7D9 File Offset: 0x00879BD9
		public string LinkAddr
		{
			get
			{
				return this.strLinkAddr;
			}
			set
			{
				this.strLinkAddr = value;
			}
		}

		// Token: 0x170024D0 RID: 9424
		// (get) Token: 0x0601B965 RID: 112997 RVA: 0x0087B7E2 File Offset: 0x00879BE2
		// (set) Token: 0x0601B966 RID: 112998 RVA: 0x0087B7EA File Offset: 0x00879BEA
		public uint BeginTime
		{
			get
			{
				return this.iBeginTime;
			}
			set
			{
				this.iBeginTime = value;
			}
		}

		// Token: 0x170024D1 RID: 9425
		// (get) Token: 0x0601B967 RID: 112999 RVA: 0x0087B7F3 File Offset: 0x00879BF3
		// (set) Token: 0x0601B968 RID: 113000 RVA: 0x0087B7FB File Offset: 0x00879BFB
		public uint EndTime
		{
			get
			{
				return this.iEndTime;
			}
			set
			{
				this.iEndTime = value;
			}
		}

		// Token: 0x040133DD RID: 78813
		private ulong uNoticeID;

		// Token: 0x040133DE RID: 78814
		private int iNoticeType;

		// Token: 0x040133DF RID: 78815
		private string strChannelID;

		// Token: 0x040133E0 RID: 78816
		private string strContent;

		// Token: 0x040133E1 RID: 78817
		private string strLinkeText;

		// Token: 0x040133E2 RID: 78818
		private string strLinkAddr;

		// Token: 0x040133E3 RID: 78819
		private uint iBeginTime;

		// Token: 0x040133E4 RID: 78820
		private uint iEndTime;
	}
}
