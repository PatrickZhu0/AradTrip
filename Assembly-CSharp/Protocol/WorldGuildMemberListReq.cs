using System;

namespace Protocol
{
	// Token: 0x0200083B RID: 2107
	[Protocol]
	public class WorldGuildMemberListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006385 RID: 25477 RVA: 0x0012A7DE File Offset: 0x00128BDE
		public uint GetMsgID()
		{
			return 601919U;
		}

		// Token: 0x06006386 RID: 25478 RVA: 0x0012A7E5 File Offset: 0x00128BE5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006387 RID: 25479 RVA: 0x0012A7ED File Offset: 0x00128BED
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006388 RID: 25480 RVA: 0x0012A7F6 File Offset: 0x00128BF6
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildID);
		}

		// Token: 0x06006389 RID: 25481 RVA: 0x0012A806 File Offset: 0x00128C06
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildID);
		}

		// Token: 0x0600638A RID: 25482 RVA: 0x0012A816 File Offset: 0x00128C16
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildID);
		}

		// Token: 0x0600638B RID: 25483 RVA: 0x0012A826 File Offset: 0x00128C26
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildID);
		}

		// Token: 0x0600638C RID: 25484 RVA: 0x0012A838 File Offset: 0x00128C38
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002CAE RID: 11438
		public const uint MsgID = 601919U;

		// Token: 0x04002CAF RID: 11439
		public uint Sequence;

		// Token: 0x04002CB0 RID: 11440
		public ulong guildID;
	}
}
