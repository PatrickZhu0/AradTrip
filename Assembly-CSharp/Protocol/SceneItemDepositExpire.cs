using System;

namespace Protocol
{
	// Token: 0x02000985 RID: 2437
	[Protocol]
	public class SceneItemDepositExpire : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DFF RID: 28159 RVA: 0x0013EE50 File Offset: 0x0013D250
		public uint GetMsgID()
		{
			return 501059U;
		}

		// Token: 0x06006E00 RID: 28160 RVA: 0x0013EE57 File Offset: 0x0013D257
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E01 RID: 28161 RVA: 0x0013EE5F File Offset: 0x0013D25F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E02 RID: 28162 RVA: 0x0013EE68 File Offset: 0x0013D268
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.oddExpireTime);
		}

		// Token: 0x06006E03 RID: 28163 RVA: 0x0013EE78 File Offset: 0x0013D278
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oddExpireTime);
		}

		// Token: 0x06006E04 RID: 28164 RVA: 0x0013EE88 File Offset: 0x0013D288
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.oddExpireTime);
		}

		// Token: 0x06006E05 RID: 28165 RVA: 0x0013EE98 File Offset: 0x0013D298
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oddExpireTime);
		}

		// Token: 0x06006E06 RID: 28166 RVA: 0x0013EEA8 File Offset: 0x0013D2A8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040031CC RID: 12748
		public const uint MsgID = 501059U;

		// Token: 0x040031CD RID: 12749
		public uint Sequence;

		// Token: 0x040031CE RID: 12750
		public uint oddExpireTime;
	}
}
