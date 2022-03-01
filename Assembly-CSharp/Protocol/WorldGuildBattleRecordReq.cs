using System;

namespace Protocol
{
	// Token: 0x02000859 RID: 2137
	[Protocol]
	public class WorldGuildBattleRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006493 RID: 25747 RVA: 0x0012BD34 File Offset: 0x0012A134
		public uint GetMsgID()
		{
			return 601948U;
		}

		// Token: 0x06006494 RID: 25748 RVA: 0x0012BD3B File Offset: 0x0012A13B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006495 RID: 25749 RVA: 0x0012BD43 File Offset: 0x0012A143
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006496 RID: 25750 RVA: 0x0012BD4C File Offset: 0x0012A14C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSelf);
			BaseDLL.encode_int32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x06006497 RID: 25751 RVA: 0x0012BD78 File Offset: 0x0012A178
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSelf);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x06006498 RID: 25752 RVA: 0x0012BDA4 File Offset: 0x0012A1A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSelf);
			BaseDLL.encode_int32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x06006499 RID: 25753 RVA: 0x0012BDD0 File Offset: 0x0012A1D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSelf);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x0600649A RID: 25754 RVA: 0x0012BDFC File Offset: 0x0012A1FC
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D0D RID: 11533
		public const uint MsgID = 601948U;

		// Token: 0x04002D0E RID: 11534
		public uint Sequence;

		// Token: 0x04002D0F RID: 11535
		public byte isSelf;

		// Token: 0x04002D10 RID: 11536
		public int startIndex;

		// Token: 0x04002D11 RID: 11537
		public uint count;
	}
}
