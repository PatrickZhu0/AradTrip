using System;

namespace Protocol
{
	// Token: 0x02000710 RID: 1808
	[Protocol]
	public class SceneBattleDelItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B06 RID: 23302 RVA: 0x00114614 File Offset: 0x00112A14
		public uint GetMsgID()
		{
			return 508924U;
		}

		// Token: 0x06005B07 RID: 23303 RVA: 0x0011461B File Offset: 0x00112A1B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B08 RID: 23304 RVA: 0x00114623 File Offset: 0x00112A23
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B09 RID: 23305 RVA: 0x0011462C File Offset: 0x00112A2C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B0A RID: 23306 RVA: 0x0011463C File Offset: 0x00112A3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B0B RID: 23307 RVA: 0x0011464C File Offset: 0x00112A4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B0C RID: 23308 RVA: 0x0011465C File Offset: 0x00112A5C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B0D RID: 23309 RVA: 0x0011466C File Offset: 0x00112A6C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002514 RID: 9492
		public const uint MsgID = 508924U;

		// Token: 0x04002515 RID: 9493
		public uint Sequence;

		// Token: 0x04002516 RID: 9494
		public uint retCode;
	}
}
