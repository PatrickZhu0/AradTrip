using System;

namespace Protocol
{
	// Token: 0x020006F4 RID: 1780
	[Protocol]
	public class SceneBattleUseItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A10 RID: 23056 RVA: 0x001124E0 File Offset: 0x001108E0
		public uint GetMsgID()
		{
			return 508902U;
		}

		// Token: 0x06005A11 RID: 23057 RVA: 0x001124E7 File Offset: 0x001108E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A12 RID: 23058 RVA: 0x001124EF File Offset: 0x001108EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A13 RID: 23059 RVA: 0x001124F8 File Offset: 0x001108F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06005A14 RID: 23060 RVA: 0x00112508 File Offset: 0x00110908
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06005A15 RID: 23061 RVA: 0x00112518 File Offset: 0x00110918
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06005A16 RID: 23062 RVA: 0x00112528 File Offset: 0x00110928
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06005A17 RID: 23063 RVA: 0x00112538 File Offset: 0x00110938
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002488 RID: 9352
		public const uint MsgID = 508902U;

		// Token: 0x04002489 RID: 9353
		public uint Sequence;

		// Token: 0x0400248A RID: 9354
		public uint code;
	}
}
