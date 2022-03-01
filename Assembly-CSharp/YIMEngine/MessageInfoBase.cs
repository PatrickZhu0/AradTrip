using System;

namespace YIMEngine
{
	// Token: 0x02004A4F RID: 19023
	public abstract class MessageInfoBase
	{
		// Token: 0x1700248A RID: 9354
		// (get) Token: 0x0601B8CF RID: 112847 RVA: 0x0087B2E8 File Offset: 0x008796E8
		// (set) Token: 0x0601B8D0 RID: 112848 RVA: 0x0087B2F0 File Offset: 0x008796F0
		public ChatType ChatType
		{
			get
			{
				return this.chatType;
			}
			internal set
			{
				this.chatType = value;
			}
		}

		// Token: 0x1700248B RID: 9355
		// (get) Token: 0x0601B8D1 RID: 112849 RVA: 0x0087B2F9 File Offset: 0x008796F9
		// (set) Token: 0x0601B8D2 RID: 112850 RVA: 0x0087B301 File Offset: 0x00879701
		public int CreateTime
		{
			get
			{
				return this.iCreateTime;
			}
			set
			{
				this.iCreateTime = value;
			}
		}

		// Token: 0x1700248C RID: 9356
		// (get) Token: 0x0601B8D3 RID: 112851 RVA: 0x0087B30A File Offset: 0x0087970A
		// (set) Token: 0x0601B8D4 RID: 112852 RVA: 0x0087B312 File Offset: 0x00879712
		public string SenderID
		{
			get
			{
				return this.strSenderID;
			}
			set
			{
				this.strSenderID = value;
			}
		}

		// Token: 0x1700248D RID: 9357
		// (get) Token: 0x0601B8D5 RID: 112853 RVA: 0x0087B31B File Offset: 0x0087971B
		// (set) Token: 0x0601B8D6 RID: 112854 RVA: 0x0087B323 File Offset: 0x00879723
		public string RecvID
		{
			get
			{
				return this.strRecvID;
			}
			set
			{
				this.strRecvID = value;
			}
		}

		// Token: 0x1700248E RID: 9358
		// (get) Token: 0x0601B8D7 RID: 112855 RVA: 0x0087B32C File Offset: 0x0087972C
		// (set) Token: 0x0601B8D8 RID: 112856 RVA: 0x0087B334 File Offset: 0x00879734
		public MessageBodyType MessageType
		{
			get
			{
				return this.messageType;
			}
			set
			{
				this.messageType = value;
			}
		}

		// Token: 0x1700248F RID: 9359
		// (get) Token: 0x0601B8D9 RID: 112857 RVA: 0x0087B33D File Offset: 0x0087973D
		// (set) Token: 0x0601B8DA RID: 112858 RVA: 0x0087B345 File Offset: 0x00879745
		public ulong RequestID
		{
			get
			{
				return this.iRequestID;
			}
			set
			{
				this.iRequestID = value;
			}
		}

		// Token: 0x17002490 RID: 9360
		// (get) Token: 0x0601B8DB RID: 112859 RVA: 0x0087B34E File Offset: 0x0087974E
		// (set) Token: 0x0601B8DC RID: 112860 RVA: 0x0087B356 File Offset: 0x00879756
		public uint Distance
		{
			get
			{
				return this.iDistance;
			}
			set
			{
				this.iDistance = value;
			}
		}

		// Token: 0x17002491 RID: 9361
		// (get) Token: 0x0601B8DD RID: 112861 RVA: 0x0087B35F File Offset: 0x0087975F
		// (set) Token: 0x0601B8DE RID: 112862 RVA: 0x0087B367 File Offset: 0x00879767
		public bool IsRead
		{
			get
			{
				return this.bIsRead;
			}
			set
			{
				this.bIsRead = value;
			}
		}

		// Token: 0x04013204 RID: 78340
		private ChatType chatType;

		// Token: 0x04013205 RID: 78341
		private string strSenderID;

		// Token: 0x04013206 RID: 78342
		private string strRecvID;

		// Token: 0x04013207 RID: 78343
		private ulong iRequestID;

		// Token: 0x04013208 RID: 78344
		private MessageBodyType messageType;

		// Token: 0x04013209 RID: 78345
		private int iCreateTime;

		// Token: 0x0401320A RID: 78346
		private uint iDistance;

		// Token: 0x0401320B RID: 78347
		private bool bIsRead;
	}
}
