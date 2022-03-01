using System;

namespace YouMe
{
	// Token: 0x02004AAC RID: 19116
	public class IMChannel : IChannel
	{
		// Token: 0x0601BC0E RID: 113678 RVA: 0x008830BA File Offset: 0x008814BA
		public IMChannel(string channelID)
		{
			this.channelID = channelID;
		}

		// Token: 0x17002564 RID: 9572
		// (get) Token: 0x0601BC0F RID: 113679 RVA: 0x008830C9 File Offset: 0x008814C9
		public string ChannelID
		{
			get
			{
				return this.channelID;
			}
		}

		// Token: 0x04013591 RID: 79249
		private string channelID;
	}
}
