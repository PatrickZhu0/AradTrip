using System;

namespace Protocol
{
	// Token: 0x02000679 RID: 1657
	[Protocol]
	public class SceneNewSignRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600566C RID: 22124 RVA: 0x001090D0 File Offset: 0x001074D0
		public uint GetMsgID()
		{
			return 501162U;
		}

		// Token: 0x0600566D RID: 22125 RVA: 0x001090D7 File Offset: 0x001074D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600566E RID: 22126 RVA: 0x001090DF File Offset: 0x001074DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600566F RID: 22127 RVA: 0x001090E8 File Offset: 0x001074E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005670 RID: 22128 RVA: 0x001090F8 File Offset: 0x001074F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005671 RID: 22129 RVA: 0x00109108 File Offset: 0x00107508
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005672 RID: 22130 RVA: 0x00109118 File Offset: 0x00107518
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005673 RID: 22131 RVA: 0x00109128 File Offset: 0x00107528
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002254 RID: 8788
		public const uint MsgID = 501162U;

		// Token: 0x04002255 RID: 8789
		public uint Sequence;

		// Token: 0x04002256 RID: 8790
		public uint errorCode;
	}
}
