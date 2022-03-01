using System;

namespace Protocol
{
	// Token: 0x02000B4A RID: 2890
	[Protocol]
	public class SceneSaveOptionsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B61 RID: 31585 RVA: 0x00160F00 File Offset: 0x0015F300
		public uint GetMsgID()
		{
			return 501205U;
		}

		// Token: 0x06007B62 RID: 31586 RVA: 0x00160F07 File Offset: 0x0015F307
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B63 RID: 31587 RVA: 0x00160F0F File Offset: 0x0015F30F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B64 RID: 31588 RVA: 0x00160F18 File Offset: 0x0015F318
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.options);
		}

		// Token: 0x06007B65 RID: 31589 RVA: 0x00160F28 File Offset: 0x0015F328
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.options);
		}

		// Token: 0x06007B66 RID: 31590 RVA: 0x00160F38 File Offset: 0x0015F338
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.options);
		}

		// Token: 0x06007B67 RID: 31591 RVA: 0x00160F48 File Offset: 0x0015F348
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.options);
		}

		// Token: 0x06007B68 RID: 31592 RVA: 0x00160F58 File Offset: 0x0015F358
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A6A RID: 14954
		public const uint MsgID = 501205U;

		// Token: 0x04003A6B RID: 14955
		public uint Sequence;

		// Token: 0x04003A6C RID: 14956
		public uint options;
	}
}
