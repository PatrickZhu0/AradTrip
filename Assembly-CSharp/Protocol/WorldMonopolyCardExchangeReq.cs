using System;

namespace Protocol
{
	// Token: 0x02000A10 RID: 2576
	[Protocol]
	public class WorldMonopolyCardExchangeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007255 RID: 29269 RVA: 0x0014B584 File Offset: 0x00149984
		public uint GetMsgID()
		{
			return 610207U;
		}

		// Token: 0x06007256 RID: 29270 RVA: 0x0014B58B File Offset: 0x0014998B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007257 RID: 29271 RVA: 0x0014B593 File Offset: 0x00149993
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007258 RID: 29272 RVA: 0x0014B59C File Offset: 0x0014999C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06007259 RID: 29273 RVA: 0x0014B5AC File Offset: 0x001499AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600725A RID: 29274 RVA: 0x0014B5BC File Offset: 0x001499BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600725B RID: 29275 RVA: 0x0014B5CC File Offset: 0x001499CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600725C RID: 29276 RVA: 0x0014B5DC File Offset: 0x001499DC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400348D RID: 13453
		public const uint MsgID = 610207U;

		// Token: 0x0400348E RID: 13454
		public uint Sequence;

		// Token: 0x0400348F RID: 13455
		public uint id;
	}
}
