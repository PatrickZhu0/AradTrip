using System;

namespace Protocol
{
	// Token: 0x02000CA7 RID: 3239
	[Protocol]
	public class QueryAddonPaySwitch : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008596 RID: 34198 RVA: 0x001768C8 File Offset: 0x00174CC8
		public uint GetMsgID()
		{
			return 501715U;
		}

		// Token: 0x06008597 RID: 34199 RVA: 0x001768CF File Offset: 0x00174CCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008598 RID: 34200 RVA: 0x001768D7 File Offset: 0x00174CD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008599 RID: 34201 RVA: 0x001768E0 File Offset: 0x00174CE0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600859A RID: 34202 RVA: 0x001768E2 File Offset: 0x00174CE2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600859B RID: 34203 RVA: 0x001768E4 File Offset: 0x00174CE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600859C RID: 34204 RVA: 0x001768E6 File Offset: 0x00174CE6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600859D RID: 34205 RVA: 0x001768E8 File Offset: 0x00174CE8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04004004 RID: 16388
		public const uint MsgID = 501715U;

		// Token: 0x04004005 RID: 16389
		public uint Sequence;
	}
}
