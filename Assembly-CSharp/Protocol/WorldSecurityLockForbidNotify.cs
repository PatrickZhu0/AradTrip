using System;

namespace Protocol
{
	// Token: 0x02000B2B RID: 2859
	[Protocol]
	public class WorldSecurityLockForbidNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A77 RID: 31351 RVA: 0x0015FAC0 File Offset: 0x0015DEC0
		public uint GetMsgID()
		{
			return 608410U;
		}

		// Token: 0x06007A78 RID: 31352 RVA: 0x0015FAC7 File Offset: 0x0015DEC7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A79 RID: 31353 RVA: 0x0015FACF File Offset: 0x0015DECF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A7A RID: 31354 RVA: 0x0015FAD8 File Offset: 0x0015DED8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06007A7B RID: 31355 RVA: 0x0015FAE8 File Offset: 0x0015DEE8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06007A7C RID: 31356 RVA: 0x0015FAF8 File Offset: 0x0015DEF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06007A7D RID: 31357 RVA: 0x0015FB08 File Offset: 0x0015DF08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06007A7E RID: 31358 RVA: 0x0015FB18 File Offset: 0x0015DF18
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040039D1 RID: 14801
		public const uint MsgID = 608410U;

		// Token: 0x040039D2 RID: 14802
		public uint Sequence;

		// Token: 0x040039D3 RID: 14803
		public uint ret;
	}
}
