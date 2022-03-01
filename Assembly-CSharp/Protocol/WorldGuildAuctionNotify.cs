using System;

namespace Protocol
{
	// Token: 0x0200089A RID: 2202
	[Protocol]
	public class WorldGuildAuctionNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066C7 RID: 26311 RVA: 0x001302EC File Offset: 0x0012E6EC
		public uint GetMsgID()
		{
			return 608519U;
		}

		// Token: 0x060066C8 RID: 26312 RVA: 0x001302F3 File Offset: 0x0012E6F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066C9 RID: 26313 RVA: 0x001302FB File Offset: 0x0012E6FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066CA RID: 26314 RVA: 0x00130304 File Offset: 0x0012E704
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isOpen);
		}

		// Token: 0x060066CB RID: 26315 RVA: 0x00130322 File Offset: 0x0012E722
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isOpen);
		}

		// Token: 0x060066CC RID: 26316 RVA: 0x00130340 File Offset: 0x0012E740
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isOpen);
		}

		// Token: 0x060066CD RID: 26317 RVA: 0x0013035E File Offset: 0x0012E75E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isOpen);
		}

		// Token: 0x060066CE RID: 26318 RVA: 0x0013037C File Offset: 0x0012E77C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002DF6 RID: 11766
		public const uint MsgID = 608519U;

		// Token: 0x04002DF7 RID: 11767
		public uint Sequence;

		// Token: 0x04002DF8 RID: 11768
		public uint type;

		// Token: 0x04002DF9 RID: 11769
		public uint isOpen;
	}
}
