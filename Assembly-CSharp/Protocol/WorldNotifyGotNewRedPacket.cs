using System;

namespace Protocol
{
	// Token: 0x02000A7D RID: 2685
	[Protocol]
	public class WorldNotifyGotNewRedPacket : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007573 RID: 30067 RVA: 0x00154044 File Offset: 0x00152444
		public uint GetMsgID()
		{
			return 607302U;
		}

		// Token: 0x06007574 RID: 30068 RVA: 0x0015404B File Offset: 0x0015244B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007575 RID: 30069 RVA: 0x00154053 File Offset: 0x00152453
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007576 RID: 30070 RVA: 0x0015405C File Offset: 0x0015245C
		public void encode(byte[] buffer, ref int pos_)
		{
			this.entry.encode(buffer, ref pos_);
		}

		// Token: 0x06007577 RID: 30071 RVA: 0x0015406B File Offset: 0x0015246B
		public void decode(byte[] buffer, ref int pos_)
		{
			this.entry.decode(buffer, ref pos_);
		}

		// Token: 0x06007578 RID: 30072 RVA: 0x0015407A File Offset: 0x0015247A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.entry.encode(buffer, ref pos_);
		}

		// Token: 0x06007579 RID: 30073 RVA: 0x00154089 File Offset: 0x00152489
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.entry.decode(buffer, ref pos_);
		}

		// Token: 0x0600757A RID: 30074 RVA: 0x00154098 File Offset: 0x00152498
		public int getLen()
		{
			int num = 0;
			return num + this.entry.getLen();
		}

		// Token: 0x040036B4 RID: 14004
		public const uint MsgID = 607302U;

		// Token: 0x040036B5 RID: 14005
		public uint Sequence;

		// Token: 0x040036B6 RID: 14006
		public RedPacketBaseEntry entry = new RedPacketBaseEntry();
	}
}
