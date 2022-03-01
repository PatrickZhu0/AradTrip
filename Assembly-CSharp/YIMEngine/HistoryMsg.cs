using System;

namespace YIMEngine
{
	// Token: 0x02004A5D RID: 19037
	public class HistoryMsg
	{
		// Token: 0x170024A1 RID: 9377
		// (get) Token: 0x0601B903 RID: 112899 RVA: 0x0087B49F File Offset: 0x0087989F
		// (set) Token: 0x0601B904 RID: 112900 RVA: 0x0087B4A7 File Offset: 0x008798A7
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

		// Token: 0x170024A2 RID: 9378
		// (get) Token: 0x0601B905 RID: 112901 RVA: 0x0087B4B0 File Offset: 0x008798B0
		// (set) Token: 0x0601B906 RID: 112902 RVA: 0x0087B4B8 File Offset: 0x008798B8
		public ChatType ChatType
		{
			get
			{
				return this.iChatType;
			}
			set
			{
				this.iChatType = value;
			}
		}

		// Token: 0x170024A3 RID: 9379
		// (get) Token: 0x0601B907 RID: 112903 RVA: 0x0087B4C1 File Offset: 0x008798C1
		// (set) Token: 0x0601B908 RID: 112904 RVA: 0x0087B4C9 File Offset: 0x008798C9
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

		// Token: 0x170024A4 RID: 9380
		// (get) Token: 0x0601B909 RID: 112905 RVA: 0x0087B4D2 File Offset: 0x008798D2
		// (set) Token: 0x0601B90A RID: 112906 RVA: 0x0087B4DA File Offset: 0x008798DA
		public string LocalPath
		{
			get
			{
				return this.strLocalPath;
			}
			set
			{
				this.strLocalPath = value;
			}
		}

		// Token: 0x170024A5 RID: 9381
		// (get) Token: 0x0601B90B RID: 112907 RVA: 0x0087B4E3 File Offset: 0x008798E3
		// (set) Token: 0x0601B90C RID: 112908 RVA: 0x0087B4EB File Offset: 0x008798EB
		public string Text
		{
			get
			{
				return this.strText;
			}
			set
			{
				this.strText = value;
			}
		}

		// Token: 0x170024A6 RID: 9382
		// (get) Token: 0x0601B90D RID: 112909 RVA: 0x0087B4F4 File Offset: 0x008798F4
		// (set) Token: 0x0601B90E RID: 112910 RVA: 0x0087B4FC File Offset: 0x008798FC
		public ulong MessageID
		{
			get
			{
				return this.uMessageID;
			}
			set
			{
				this.uMessageID = value;
			}
		}

		// Token: 0x170024A7 RID: 9383
		// (get) Token: 0x0601B90F RID: 112911 RVA: 0x0087B505 File Offset: 0x00879905
		// (set) Token: 0x0601B910 RID: 112912 RVA: 0x0087B50D File Offset: 0x0087990D
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

		// Token: 0x170024A8 RID: 9384
		// (get) Token: 0x0601B911 RID: 112913 RVA: 0x0087B516 File Offset: 0x00879916
		// (set) Token: 0x0601B912 RID: 112914 RVA: 0x0087B51E File Offset: 0x0087991E
		public string ReceiveID
		{
			get
			{
				return this.strReceiveID;
			}
			set
			{
				this.strReceiveID = value;
			}
		}

		// Token: 0x170024A9 RID: 9385
		// (get) Token: 0x0601B913 RID: 112915 RVA: 0x0087B527 File Offset: 0x00879927
		// (set) Token: 0x0601B914 RID: 112916 RVA: 0x0087B52F File Offset: 0x0087992F
		public string Param
		{
			get
			{
				return this.strParam;
			}
			set
			{
				this.strParam = value;
			}
		}

		// Token: 0x170024AA RID: 9386
		// (get) Token: 0x0601B915 RID: 112917 RVA: 0x0087B538 File Offset: 0x00879938
		// (set) Token: 0x0601B916 RID: 112918 RVA: 0x0087B540 File Offset: 0x00879940
		public int Duration
		{
			get
			{
				return this.iDuration;
			}
			set
			{
				this.iDuration = value;
			}
		}

		// Token: 0x170024AB RID: 9387
		// (get) Token: 0x0601B917 RID: 112919 RVA: 0x0087B549 File Offset: 0x00879949
		// (set) Token: 0x0601B918 RID: 112920 RVA: 0x0087B551 File Offset: 0x00879951
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

		// Token: 0x170024AC RID: 9388
		// (get) Token: 0x0601B919 RID: 112921 RVA: 0x0087B55A File Offset: 0x0087995A
		public byte[] CustomMsg
		{
			get
			{
				return Convert.FromBase64String(this.Text);
			}
		}

		// Token: 0x170024AD RID: 9389
		// (get) Token: 0x0601B91A RID: 112922 RVA: 0x0087B567 File Offset: 0x00879967
		// (set) Token: 0x0601B91B RID: 112923 RVA: 0x0087B56F File Offset: 0x0087996F
		public int FileSize
		{
			get
			{
				return this.iFileSize;
			}
			set
			{
				this.iFileSize = value;
			}
		}

		// Token: 0x170024AE RID: 9390
		// (get) Token: 0x0601B91C RID: 112924 RVA: 0x0087B578 File Offset: 0x00879978
		// (set) Token: 0x0601B91D RID: 112925 RVA: 0x0087B580 File Offset: 0x00879980
		public string FileName
		{
			get
			{
				return this.strFileName;
			}
			set
			{
				this.strFileName = value;
			}
		}

		// Token: 0x170024AF RID: 9391
		// (get) Token: 0x0601B91E RID: 112926 RVA: 0x0087B589 File Offset: 0x00879989
		// (set) Token: 0x0601B91F RID: 112927 RVA: 0x0087B591 File Offset: 0x00879991
		public string FileExtension
		{
			get
			{
				return this.strFileExtension;
			}
			set
			{
				this.strFileExtension = value;
			}
		}

		// Token: 0x040132FE RID: 78590
		private ChatType iChatType;

		// Token: 0x040132FF RID: 78591
		private MessageBodyType iMessageType;

		// Token: 0x04013300 RID: 78592
		private string strParam;

		// Token: 0x04013301 RID: 78593
		private string strReceiveID;

		// Token: 0x04013302 RID: 78594
		private string strSenderID;

		// Token: 0x04013303 RID: 78595
		private ulong uMessageID;

		// Token: 0x04013304 RID: 78596
		private string strText;

		// Token: 0x04013305 RID: 78597
		private string strLocalPath;

		// Token: 0x04013306 RID: 78598
		private int iCreateTime;

		// Token: 0x04013307 RID: 78599
		private int iDuration;

		// Token: 0x04013308 RID: 78600
		private bool bIsRead;

		// Token: 0x04013309 RID: 78601
		private byte[] customMsg;

		// Token: 0x0401330A RID: 78602
		private string strFileName;

		// Token: 0x0401330B RID: 78603
		private string strFileExtension;

		// Token: 0x0401330C RID: 78604
		private int iFileSize;
	}
}
