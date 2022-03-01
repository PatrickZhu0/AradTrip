using System;

namespace Protocol
{
	// Token: 0x02000A6B RID: 2667
	[Protocol]
	public class WorldPremiumLeagueEnrollRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074F2 RID: 29938 RVA: 0x00152930 File Offset: 0x00150D30
		public uint GetMsgID()
		{
			return 607705U;
		}

		// Token: 0x060074F3 RID: 29939 RVA: 0x00152937 File Offset: 0x00150D37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074F4 RID: 29940 RVA: 0x0015293F File Offset: 0x00150D3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074F5 RID: 29941 RVA: 0x00152948 File Offset: 0x00150D48
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060074F6 RID: 29942 RVA: 0x00152958 File Offset: 0x00150D58
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060074F7 RID: 29943 RVA: 0x00152968 File Offset: 0x00150D68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060074F8 RID: 29944 RVA: 0x00152978 File Offset: 0x00150D78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060074F9 RID: 29945 RVA: 0x00152988 File Offset: 0x00150D88
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003665 RID: 13925
		public const uint MsgID = 607705U;

		// Token: 0x04003666 RID: 13926
		public uint Sequence;

		// Token: 0x04003667 RID: 13927
		public uint result;
	}
}
