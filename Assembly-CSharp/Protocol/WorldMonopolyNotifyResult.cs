using System;

namespace Protocol
{
	// Token: 0x02000A17 RID: 2583
	[Protocol]
	public class WorldMonopolyNotifyResult : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007291 RID: 29329 RVA: 0x0014BA14 File Offset: 0x00149E14
		public uint GetMsgID()
		{
			return 610213U;
		}

		// Token: 0x06007292 RID: 29330 RVA: 0x0014BA1B File Offset: 0x00149E1B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007293 RID: 29331 RVA: 0x0014BA23 File Offset: 0x00149E23
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007294 RID: 29332 RVA: 0x0014BA2C File Offset: 0x00149E2C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resultId);
			BaseDLL.encode_int64(buffer, ref pos_, this.param);
		}

		// Token: 0x06007295 RID: 29333 RVA: 0x0014BA4A File Offset: 0x00149E4A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resultId);
			BaseDLL.decode_int64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007296 RID: 29334 RVA: 0x0014BA68 File Offset: 0x00149E68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resultId);
			BaseDLL.encode_int64(buffer, ref pos_, this.param);
		}

		// Token: 0x06007297 RID: 29335 RVA: 0x0014BA86 File Offset: 0x00149E86
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resultId);
			BaseDLL.decode_int64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007298 RID: 29336 RVA: 0x0014BAA4 File Offset: 0x00149EA4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040034A1 RID: 13473
		public const uint MsgID = 610213U;

		// Token: 0x040034A2 RID: 13474
		public uint Sequence;

		// Token: 0x040034A3 RID: 13475
		public uint resultId;

		// Token: 0x040034A4 RID: 13476
		public long param;
	}
}
