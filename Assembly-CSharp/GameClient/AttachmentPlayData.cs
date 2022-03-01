using System;

namespace GameClient
{
	// Token: 0x02001184 RID: 4484
	public class AttachmentPlayData : ActionPlayData
	{
		// Token: 0x17001A44 RID: 6724
		// (get) Token: 0x0600AB9E RID: 43934 RVA: 0x0024D050 File Offset: 0x0024B450
		// (set) Token: 0x0600AB9F RID: 43935 RVA: 0x0024D058 File Offset: 0x0024B458
		public string attachmentName
		{
			get
			{
				return this.m_strAttachmentName;
			}
			set
			{
				this.m_strAttachmentName = value;
			}
		}

		// Token: 0x17001A45 RID: 6725
		// (get) Token: 0x0600ABA0 RID: 43936 RVA: 0x0024D061 File Offset: 0x0024B461
		// (set) Token: 0x0600ABA1 RID: 43937 RVA: 0x0024D069 File Offset: 0x0024B469
		public bool visible
		{
			get
			{
				return this.m_bVisible;
			}
			set
			{
				if (this.m_bVisible != value)
				{
					this.m_bVisible = value;
					this.m_bDirty = true;
				}
			}
		}

		// Token: 0x04006039 RID: 24633
		protected string m_strAttachmentName = string.Empty;

		// Token: 0x0400603A RID: 24634
		protected bool m_bVisible = true;
	}
}
