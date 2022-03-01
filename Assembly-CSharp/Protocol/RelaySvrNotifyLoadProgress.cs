using System;

namespace Protocol
{
	// Token: 0x02000AA3 RID: 2723
	[Protocol]
	public class RelaySvrNotifyLoadProgress : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600769C RID: 30364 RVA: 0x00156D7C File Offset: 0x0015517C
		public uint GetMsgID()
		{
			return 1300016U;
		}

		// Token: 0x0600769D RID: 30365 RVA: 0x00156D83 File Offset: 0x00155183
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600769E RID: 30366 RVA: 0x00156D8B File Offset: 0x0015518B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600769F RID: 30367 RVA: 0x00156D94 File Offset: 0x00155194
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.progress);
		}

		// Token: 0x060076A0 RID: 30368 RVA: 0x00156DB2 File Offset: 0x001551B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.progress);
		}

		// Token: 0x060076A1 RID: 30369 RVA: 0x00156DD0 File Offset: 0x001551D0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.progress);
		}

		// Token: 0x060076A2 RID: 30370 RVA: 0x00156DEE File Offset: 0x001551EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.progress);
		}

		// Token: 0x060076A3 RID: 30371 RVA: 0x00156E0C File Offset: 0x0015520C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x0400376E RID: 14190
		public const uint MsgID = 1300016U;

		// Token: 0x0400376F RID: 14191
		public uint Sequence;

		// Token: 0x04003770 RID: 14192
		public byte pos;

		// Token: 0x04003771 RID: 14193
		public byte progress;
	}
}
