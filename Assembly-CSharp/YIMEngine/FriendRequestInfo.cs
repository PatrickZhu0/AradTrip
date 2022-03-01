using System;

namespace YIMEngine
{
	// Token: 0x02004A6F RID: 19055
	public class FriendRequestInfo
	{
		// Token: 0x170024D5 RID: 9429
		// (get) Token: 0x0601B971 RID: 113009 RVA: 0x0087B847 File Offset: 0x00879C47
		// (set) Token: 0x0601B972 RID: 113010 RVA: 0x0087B84F File Offset: 0x00879C4F
		public string AskerID
		{
			get
			{
				return this.askerID;
			}
			set
			{
				this.askerID = value;
			}
		}

		// Token: 0x170024D6 RID: 9430
		// (get) Token: 0x0601B973 RID: 113011 RVA: 0x0087B858 File Offset: 0x00879C58
		// (set) Token: 0x0601B974 RID: 113012 RVA: 0x0087B860 File Offset: 0x00879C60
		public string AskerNickname
		{
			get
			{
				return this.askerNickname;
			}
			set
			{
				this.askerNickname = value;
			}
		}

		// Token: 0x170024D7 RID: 9431
		// (get) Token: 0x0601B975 RID: 113013 RVA: 0x0087B869 File Offset: 0x00879C69
		// (set) Token: 0x0601B976 RID: 113014 RVA: 0x0087B871 File Offset: 0x00879C71
		public string InviteeID
		{
			get
			{
				return this.inviteeID;
			}
			set
			{
				this.inviteeID = value;
			}
		}

		// Token: 0x170024D8 RID: 9432
		// (get) Token: 0x0601B977 RID: 113015 RVA: 0x0087B87A File Offset: 0x00879C7A
		// (set) Token: 0x0601B978 RID: 113016 RVA: 0x0087B882 File Offset: 0x00879C82
		public string InviteeNickname
		{
			get
			{
				return this.inviteeNickname;
			}
			set
			{
				this.inviteeNickname = value;
			}
		}

		// Token: 0x170024D9 RID: 9433
		// (get) Token: 0x0601B979 RID: 113017 RVA: 0x0087B88B File Offset: 0x00879C8B
		// (set) Token: 0x0601B97A RID: 113018 RVA: 0x0087B893 File Offset: 0x00879C93
		public string ValidateInfo
		{
			get
			{
				return this.validateInfo;
			}
			set
			{
				this.validateInfo = value;
			}
		}

		// Token: 0x170024DA RID: 9434
		// (get) Token: 0x0601B97B RID: 113019 RVA: 0x0087B89C File Offset: 0x00879C9C
		// (set) Token: 0x0601B97C RID: 113020 RVA: 0x0087B8A4 File Offset: 0x00879CA4
		public AddFriendStatus Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		// Token: 0x170024DB RID: 9435
		// (get) Token: 0x0601B97D RID: 113021 RVA: 0x0087B8AD File Offset: 0x00879CAD
		// (set) Token: 0x0601B97E RID: 113022 RVA: 0x0087B8B5 File Offset: 0x00879CB5
		public uint CreateTime
		{
			get
			{
				return this.createTime;
			}
			set
			{
				this.createTime = value;
			}
		}

		// Token: 0x040133ED RID: 78829
		private string askerID;

		// Token: 0x040133EE RID: 78830
		private string askerNickname;

		// Token: 0x040133EF RID: 78831
		private string inviteeID;

		// Token: 0x040133F0 RID: 78832
		private string inviteeNickname;

		// Token: 0x040133F1 RID: 78833
		private string validateInfo;

		// Token: 0x040133F2 RID: 78834
		private AddFriendStatus status;

		// Token: 0x040133F3 RID: 78835
		private uint createTime;
	}
}
