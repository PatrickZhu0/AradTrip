using System;

namespace GameClient
{
	// Token: 0x020012B4 RID: 4788
	public class NewMessageNoticeData
	{
		// Token: 0x0600B8AB RID: 47275 RVA: 0x002A5087 File Offset: 0x002A3487
		public NewMessageNoticeData(string tag)
		{
			this.tag = tag;
		}

		// Token: 0x17001B3B RID: 6971
		// (get) Token: 0x0600B8AC RID: 47276 RVA: 0x002A5096 File Offset: 0x002A3496
		public string mTag
		{
			get
			{
				return this.tag;
			}
		}

		// Token: 0x17001B3C RID: 6972
		// (get) Token: 0x0600B8AD RID: 47277 RVA: 0x002A509E File Offset: 0x002A349E
		// (set) Token: 0x0600B8AE RID: 47278 RVA: 0x002A50A6 File Offset: 0x002A34A6
		public bool mNotUse
		{
			get
			{
				return this.bNotUse;
			}
			set
			{
				this.bNotUse = value;
			}
		}

		// Token: 0x0400680B RID: 26635
		private string tag;

		// Token: 0x0400680C RID: 26636
		public string mTitle;

		// Token: 0x0400680D RID: 26637
		public string mMessage;

		// Token: 0x0400680E RID: 26638
		public object mUserdata;

		// Token: 0x0400680F RID: 26639
		public Action<NewMessageNoticeData> mForwardAction;

		// Token: 0x04006810 RID: 26640
		public bool bReaded;

		// Token: 0x04006811 RID: 26641
		private bool bNotUse;
	}
}
