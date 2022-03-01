using System;

namespace Protocol
{
	// Token: 0x020009ED RID: 2541
	[Protocol]
	public class WorldMatchStartRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007141 RID: 28993 RVA: 0x00146DE8 File Offset: 0x001451E8
		public uint GetMsgID()
		{
			return 606702U;
		}

		// Token: 0x06007142 RID: 28994 RVA: 0x00146DEF File Offset: 0x001451EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007143 RID: 28995 RVA: 0x00146DF7 File Offset: 0x001451F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007144 RID: 28996 RVA: 0x00146E00 File Offset: 0x00145200
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007145 RID: 28997 RVA: 0x00146E10 File Offset: 0x00145210
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007146 RID: 28998 RVA: 0x00146E20 File Offset: 0x00145220
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007147 RID: 28999 RVA: 0x00146E30 File Offset: 0x00145230
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007148 RID: 29000 RVA: 0x00146E40 File Offset: 0x00145240
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040033C2 RID: 13250
		public const uint MsgID = 606702U;

		// Token: 0x040033C3 RID: 13251
		public uint Sequence;

		// Token: 0x040033C4 RID: 13252
		public uint result;
	}
}
