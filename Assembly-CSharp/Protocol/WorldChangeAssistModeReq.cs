using System;

namespace Protocol
{
	// Token: 0x02000BA1 RID: 2977
	[Protocol]
	public class WorldChangeAssistModeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E04 RID: 32260 RVA: 0x00165DB2 File Offset: 0x001641B2
		public uint GetMsgID()
		{
			return 601655U;
		}

		// Token: 0x06007E05 RID: 32261 RVA: 0x00165DB9 File Offset: 0x001641B9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E06 RID: 32262 RVA: 0x00165DC1 File Offset: 0x001641C1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E07 RID: 32263 RVA: 0x00165DCA File Offset: 0x001641CA
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isAssist);
		}

		// Token: 0x06007E08 RID: 32264 RVA: 0x00165DDA File Offset: 0x001641DA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAssist);
		}

		// Token: 0x06007E09 RID: 32265 RVA: 0x00165DEA File Offset: 0x001641EA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isAssist);
		}

		// Token: 0x06007E0A RID: 32266 RVA: 0x00165DFA File Offset: 0x001641FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAssist);
		}

		// Token: 0x06007E0B RID: 32267 RVA: 0x00165E0C File Offset: 0x0016420C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003BB5 RID: 15285
		public const uint MsgID = 601655U;

		// Token: 0x04003BB6 RID: 15286
		public uint Sequence;

		// Token: 0x04003BB7 RID: 15287
		public byte isAssist;
	}
}
