using System;

namespace Protocol
{
	// Token: 0x02000B93 RID: 2963
	[Protocol]
	public class WorldTeamProcessRequesterReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D86 RID: 32134 RVA: 0x00165455 File Offset: 0x00163855
		public uint GetMsgID()
		{
			return 601640U;
		}

		// Token: 0x06007D87 RID: 32135 RVA: 0x0016545C File Offset: 0x0016385C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D88 RID: 32136 RVA: 0x00165464 File Offset: 0x00163864
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D89 RID: 32137 RVA: 0x0016546D File Offset: 0x0016386D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007D8A RID: 32138 RVA: 0x0016548B File Offset: 0x0016388B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007D8B RID: 32139 RVA: 0x001654A9 File Offset: 0x001638A9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007D8C RID: 32140 RVA: 0x001654C7 File Offset: 0x001638C7
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007D8D RID: 32141 RVA: 0x001654E8 File Offset: 0x001638E8
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003B84 RID: 15236
		public const uint MsgID = 601640U;

		// Token: 0x04003B85 RID: 15237
		public uint Sequence;

		// Token: 0x04003B86 RID: 15238
		public ulong targetId;

		// Token: 0x04003B87 RID: 15239
		public byte agree;
	}
}
