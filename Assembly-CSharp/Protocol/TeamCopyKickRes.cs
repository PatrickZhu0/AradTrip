using System;

namespace Protocol
{
	// Token: 0x02000BE8 RID: 3048
	[Protocol]
	public class TeamCopyKickRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FC6 RID: 32710 RVA: 0x0016A3C0 File Offset: 0x001687C0
		public uint GetMsgID()
		{
			return 1100046U;
		}

		// Token: 0x06007FC7 RID: 32711 RVA: 0x0016A3C7 File Offset: 0x001687C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FC8 RID: 32712 RVA: 0x0016A3CF File Offset: 0x001687CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FC9 RID: 32713 RVA: 0x0016A3D8 File Offset: 0x001687D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FCA RID: 32714 RVA: 0x0016A3E8 File Offset: 0x001687E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FCB RID: 32715 RVA: 0x0016A3F8 File Offset: 0x001687F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FCC RID: 32716 RVA: 0x0016A408 File Offset: 0x00168808
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FCD RID: 32717 RVA: 0x0016A418 File Offset: 0x00168818
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CFE RID: 15614
		public const uint MsgID = 1100046U;

		// Token: 0x04003CFF RID: 15615
		public uint Sequence;

		// Token: 0x04003D00 RID: 15616
		public uint retCode;
	}
}
