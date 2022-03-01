using System;

namespace Protocol
{
	// Token: 0x02000BE3 RID: 3043
	[Protocol]
	public class TeamCopyChangeSeatReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F99 RID: 32665 RVA: 0x00169DFC File Offset: 0x001681FC
		public uint GetMsgID()
		{
			return 1100041U;
		}

		// Token: 0x06007F9A RID: 32666 RVA: 0x00169E03 File Offset: 0x00168203
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F9B RID: 32667 RVA: 0x00169E0B File Offset: 0x0016820B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F9C RID: 32668 RVA: 0x00169E14 File Offset: 0x00168214
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.srcSeat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.destSeat);
		}

		// Token: 0x06007F9D RID: 32669 RVA: 0x00169E32 File Offset: 0x00168232
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.srcSeat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.destSeat);
		}

		// Token: 0x06007F9E RID: 32670 RVA: 0x00169E50 File Offset: 0x00168250
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.srcSeat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.destSeat);
		}

		// Token: 0x06007F9F RID: 32671 RVA: 0x00169E6E File Offset: 0x0016826E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.srcSeat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.destSeat);
		}

		// Token: 0x06007FA0 RID: 32672 RVA: 0x00169E8C File Offset: 0x0016828C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003CE8 RID: 15592
		public const uint MsgID = 1100041U;

		// Token: 0x04003CE9 RID: 15593
		public uint Sequence;

		// Token: 0x04003CEA RID: 15594
		public uint srcSeat;

		// Token: 0x04003CEB RID: 15595
		public uint destSeat;
	}
}
