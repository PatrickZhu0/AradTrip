using System;

namespace Protocol
{
	// Token: 0x02000B47 RID: 2887
	[Protocol]
	public class SceneGameSetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B46 RID: 31558 RVA: 0x00160DE0 File Offset: 0x0015F1E0
		public uint GetMsgID()
		{
			return 501224U;
		}

		// Token: 0x06007B47 RID: 31559 RVA: 0x00160DE7 File Offset: 0x0015F1E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B48 RID: 31560 RVA: 0x00160DEF File Offset: 0x0015F1EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B49 RID: 31561 RVA: 0x00160DF8 File Offset: 0x0015F1F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007B4A RID: 31562 RVA: 0x00160E08 File Offset: 0x0015F208
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007B4B RID: 31563 RVA: 0x00160E18 File Offset: 0x0015F218
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007B4C RID: 31564 RVA: 0x00160E28 File Offset: 0x0015F228
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007B4D RID: 31565 RVA: 0x00160E38 File Offset: 0x0015F238
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A62 RID: 14946
		public const uint MsgID = 501224U;

		// Token: 0x04003A63 RID: 14947
		public uint Sequence;

		// Token: 0x04003A64 RID: 14948
		public uint retCode;
	}
}
