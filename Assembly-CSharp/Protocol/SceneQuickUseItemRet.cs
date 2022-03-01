using System;

namespace Protocol
{
	// Token: 0x02000923 RID: 2339
	[Protocol]
	public class SceneQuickUseItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AA8 RID: 27304 RVA: 0x00138EBC File Offset: 0x001372BC
		public uint GetMsgID()
		{
			return 500951U;
		}

		// Token: 0x06006AA9 RID: 27305 RVA: 0x00138EC3 File Offset: 0x001372C3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AAA RID: 27306 RVA: 0x00138ECB File Offset: 0x001372CB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AAB RID: 27307 RVA: 0x00138ED4 File Offset: 0x001372D4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006AAC RID: 27308 RVA: 0x00138EE4 File Offset: 0x001372E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006AAD RID: 27309 RVA: 0x00138EF4 File Offset: 0x001372F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006AAE RID: 27310 RVA: 0x00138F04 File Offset: 0x00137304
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006AAF RID: 27311 RVA: 0x00138F14 File Offset: 0x00137314
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400305B RID: 12379
		public const uint MsgID = 500951U;

		// Token: 0x0400305C RID: 12380
		public uint Sequence;

		// Token: 0x0400305D RID: 12381
		public uint code;
	}
}
