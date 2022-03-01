using System;

namespace Protocol
{
	// Token: 0x020006DC RID: 1756
	[Protocol]
	public class WorldActionAttentRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005968 RID: 22888 RVA: 0x0010FCA7 File Offset: 0x0010E0A7
		public uint GetMsgID()
		{
			return 603930U;
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x0010FCAE File Offset: 0x0010E0AE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600596A RID: 22890 RVA: 0x0010FCB6 File Offset: 0x0010E0B6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600596B RID: 22891 RVA: 0x0010FCBF File Offset: 0x0010E0BF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.aution.encode(buffer, ref pos_);
		}

		// Token: 0x0600596C RID: 22892 RVA: 0x0010FCDC File Offset: 0x0010E0DC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.aution.decode(buffer, ref pos_);
		}

		// Token: 0x0600596D RID: 22893 RVA: 0x0010FCF9 File Offset: 0x0010E0F9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.aution.encode(buffer, ref pos_);
		}

		// Token: 0x0600596E RID: 22894 RVA: 0x0010FD16 File Offset: 0x0010E116
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.aution.decode(buffer, ref pos_);
		}

		// Token: 0x0600596F RID: 22895 RVA: 0x0010FD34 File Offset: 0x0010E134
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.aution.getLen();
		}

		// Token: 0x040023FC RID: 9212
		public const uint MsgID = 603930U;

		// Token: 0x040023FD RID: 9213
		public uint Sequence;

		// Token: 0x040023FE RID: 9214
		public uint code;

		// Token: 0x040023FF RID: 9215
		public AuctionBaseInfo aution = new AuctionBaseInfo();
	}
}
