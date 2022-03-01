using System;

namespace Protocol
{
	// Token: 0x02000B97 RID: 2967
	[Protocol]
	public class WorldTeamInviteRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DAA RID: 32170 RVA: 0x001656A0 File Offset: 0x00163AA0
		public uint GetMsgID()
		{
			return 601644U;
		}

		// Token: 0x06007DAB RID: 32171 RVA: 0x001656A7 File Offset: 0x00163AA7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DAC RID: 32172 RVA: 0x001656AF File Offset: 0x00163AAF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DAD RID: 32173 RVA: 0x001656B8 File Offset: 0x00163AB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DAE RID: 32174 RVA: 0x001656D6 File Offset: 0x00163AD6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DAF RID: 32175 RVA: 0x001656F4 File Offset: 0x00163AF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DB0 RID: 32176 RVA: 0x00165712 File Offset: 0x00163B12
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DB1 RID: 32177 RVA: 0x00165730 File Offset: 0x00163B30
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003B92 RID: 15250
		public const uint MsgID = 601644U;

		// Token: 0x04003B93 RID: 15251
		public uint Sequence;

		// Token: 0x04003B94 RID: 15252
		public ulong targetId;

		// Token: 0x04003B95 RID: 15253
		public uint result;
	}
}
