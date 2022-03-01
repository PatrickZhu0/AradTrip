using System;

namespace Protocol
{
	// Token: 0x020009E4 RID: 2532
	[Protocol]
	public class WorldNotifyNewMail : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600711D RID: 28957 RVA: 0x001469EF File Offset: 0x00144DEF
		public uint GetMsgID()
		{
			return 601509U;
		}

		// Token: 0x0600711E RID: 28958 RVA: 0x001469F6 File Offset: 0x00144DF6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600711F RID: 28959 RVA: 0x001469FE File Offset: 0x00144DFE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007120 RID: 28960 RVA: 0x00146A07 File Offset: 0x00144E07
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007121 RID: 28961 RVA: 0x00146A16 File Offset: 0x00144E16
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007122 RID: 28962 RVA: 0x00146A25 File Offset: 0x00144E25
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007123 RID: 28963 RVA: 0x00146A34 File Offset: 0x00144E34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007124 RID: 28964 RVA: 0x00146A44 File Offset: 0x00144E44
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x0400338C RID: 13196
		public const uint MsgID = 601509U;

		// Token: 0x0400338D RID: 13197
		public uint Sequence;

		// Token: 0x0400338E RID: 13198
		public MailTitleInfo info = new MailTitleInfo();
	}
}
