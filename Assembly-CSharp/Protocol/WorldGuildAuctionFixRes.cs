using System;

namespace Protocol
{
	// Token: 0x02000899 RID: 2201
	[Protocol]
	public class WorldGuildAuctionFixRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066BE RID: 26302 RVA: 0x00130278 File Offset: 0x0012E678
		public uint GetMsgID()
		{
			return 608518U;
		}

		// Token: 0x060066BF RID: 26303 RVA: 0x0013027F File Offset: 0x0012E67F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066C0 RID: 26304 RVA: 0x00130287 File Offset: 0x0012E687
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066C1 RID: 26305 RVA: 0x00130290 File Offset: 0x0012E690
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060066C2 RID: 26306 RVA: 0x001302A0 File Offset: 0x0012E6A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060066C3 RID: 26307 RVA: 0x001302B0 File Offset: 0x0012E6B0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060066C4 RID: 26308 RVA: 0x001302C0 File Offset: 0x0012E6C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060066C5 RID: 26309 RVA: 0x001302D0 File Offset: 0x0012E6D0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DF3 RID: 11763
		public const uint MsgID = 608518U;

		// Token: 0x04002DF4 RID: 11764
		public uint Sequence;

		// Token: 0x04002DF5 RID: 11765
		public uint retCode;
	}
}
