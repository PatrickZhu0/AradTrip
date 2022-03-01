using System;

namespace Protocol
{
	// Token: 0x02000B20 RID: 2848
	[Protocol]
	public class SceneSyncScoreWarInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A26 RID: 31270 RVA: 0x0015EE44 File Offset: 0x0015D244
		public uint GetMsgID()
		{
			return 508101U;
		}

		// Token: 0x06007A27 RID: 31271 RVA: 0x0015EE4B File Offset: 0x0015D24B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A28 RID: 31272 RVA: 0x0015EE53 File Offset: 0x0015D253
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A29 RID: 31273 RVA: 0x0015EE5C File Offset: 0x0015D25C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndTime);
		}

		// Token: 0x06007A2A RID: 31274 RVA: 0x0015EE7A File Offset: 0x0015D27A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndTime);
		}

		// Token: 0x06007A2B RID: 31275 RVA: 0x0015EE98 File Offset: 0x0015D298
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndTime);
		}

		// Token: 0x06007A2C RID: 31276 RVA: 0x0015EEB6 File Offset: 0x0015D2B6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndTime);
		}

		// Token: 0x06007A2D RID: 31277 RVA: 0x0015EED4 File Offset: 0x0015D2D4
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x0400399E RID: 14750
		public const uint MsgID = 508101U;

		// Token: 0x0400399F RID: 14751
		public uint Sequence;

		// Token: 0x040039A0 RID: 14752
		public byte status;

		// Token: 0x040039A1 RID: 14753
		public uint statusEndTime;
	}
}
