using System;

namespace YIMEngine
{
	// Token: 0x02004A5E RID: 19038
	public class ContactsSessionInfo
	{
		// Token: 0x170024B0 RID: 9392
		// (get) Token: 0x0601B921 RID: 112929 RVA: 0x0087B5A2 File Offset: 0x008799A2
		// (set) Token: 0x0601B922 RID: 112930 RVA: 0x0087B5AA File Offset: 0x008799AA
		public string ContactID
		{
			get
			{
				return this.strContactID;
			}
			set
			{
				this.strContactID = value;
			}
		}

		// Token: 0x170024B1 RID: 9393
		// (get) Token: 0x0601B923 RID: 112931 RVA: 0x0087B5B3 File Offset: 0x008799B3
		// (set) Token: 0x0601B924 RID: 112932 RVA: 0x0087B5BB File Offset: 0x008799BB
		public MessageBodyType MessageType
		{
			get
			{
				return this.iMessageType;
			}
			set
			{
				this.iMessageType = value;
			}
		}

		// Token: 0x170024B2 RID: 9394
		// (get) Token: 0x0601B925 RID: 112933 RVA: 0x0087B5C4 File Offset: 0x008799C4
		// (set) Token: 0x0601B926 RID: 112934 RVA: 0x0087B5CC File Offset: 0x008799CC
		public string MessageContent
		{
			get
			{
				return this.strMessageContent;
			}
			set
			{
				this.strMessageContent = value;
			}
		}

		// Token: 0x170024B3 RID: 9395
		// (get) Token: 0x0601B927 RID: 112935 RVA: 0x0087B5D5 File Offset: 0x008799D5
		// (set) Token: 0x0601B928 RID: 112936 RVA: 0x0087B5DD File Offset: 0x008799DD
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

		// Token: 0x170024B4 RID: 9396
		// (get) Token: 0x0601B929 RID: 112937 RVA: 0x0087B5E6 File Offset: 0x008799E6
		// (set) Token: 0x0601B92A RID: 112938 RVA: 0x0087B5EE File Offset: 0x008799EE
		public uint NotReadMsgNum
		{
			get
			{
				return this.iNotReadMsgNum;
			}
			set
			{
				this.iNotReadMsgNum = value;
			}
		}

		// Token: 0x0401330D RID: 78605
		private string strContactID;

		// Token: 0x0401330E RID: 78606
		private MessageBodyType iMessageType;

		// Token: 0x0401330F RID: 78607
		private string strMessageContent;

		// Token: 0x04013310 RID: 78608
		private int iCreateTime;

		// Token: 0x04013311 RID: 78609
		private uint iNotReadMsgNum;
	}
}
