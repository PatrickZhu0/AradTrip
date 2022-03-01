using System;

namespace Protocol
{
	// Token: 0x02000A83 RID: 2691
	[Protocol]
	public class WorldOpenRedPacketReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075A9 RID: 30121 RVA: 0x001545CC File Offset: 0x001529CC
		public uint GetMsgID()
		{
			return 607308U;
		}

		// Token: 0x060075AA RID: 30122 RVA: 0x001545D3 File Offset: 0x001529D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075AB RID: 30123 RVA: 0x001545DB File Offset: 0x001529DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075AC RID: 30124 RVA: 0x001545E4 File Offset: 0x001529E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060075AD RID: 30125 RVA: 0x001545F4 File Offset: 0x001529F4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060075AE RID: 30126 RVA: 0x00154604 File Offset: 0x00152A04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060075AF RID: 30127 RVA: 0x00154614 File Offset: 0x00152A14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060075B0 RID: 30128 RVA: 0x00154624 File Offset: 0x00152A24
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040036C8 RID: 14024
		public const uint MsgID = 607308U;

		// Token: 0x040036C9 RID: 14025
		public uint Sequence;

		// Token: 0x040036CA RID: 14026
		public ulong id;
	}
}
