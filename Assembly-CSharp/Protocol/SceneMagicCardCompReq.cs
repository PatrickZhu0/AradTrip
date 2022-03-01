using System;

namespace Protocol
{
	// Token: 0x02000907 RID: 2311
	[Protocol]
	public class SceneMagicCardCompReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069AF RID: 27055 RVA: 0x001372F8 File Offset: 0x001356F8
		public uint GetMsgID()
		{
			return 500946U;
		}

		// Token: 0x060069B0 RID: 27056 RVA: 0x001372FF File Offset: 0x001356FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069B1 RID: 27057 RVA: 0x00137307 File Offset: 0x00135707
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069B2 RID: 27058 RVA: 0x00137310 File Offset: 0x00135710
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardB);
		}

		// Token: 0x060069B3 RID: 27059 RVA: 0x0013732E File Offset: 0x0013572E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardB);
		}

		// Token: 0x060069B4 RID: 27060 RVA: 0x0013734C File Offset: 0x0013574C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardB);
		}

		// Token: 0x060069B5 RID: 27061 RVA: 0x0013736A File Offset: 0x0013576A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardB);
		}

		// Token: 0x060069B6 RID: 27062 RVA: 0x00137388 File Offset: 0x00135788
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002FE9 RID: 12265
		public const uint MsgID = 500946U;

		// Token: 0x04002FEA RID: 12266
		public uint Sequence;

		// Token: 0x04002FEB RID: 12267
		public ulong cardA;

		// Token: 0x04002FEC RID: 12268
		public ulong cardB;
	}
}
