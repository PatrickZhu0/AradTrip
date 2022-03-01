using System;

namespace Protocol
{
	// Token: 0x02000A9C RID: 2716
	[Protocol]
	public class RelaySvrDungeonRaceEndReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600765D RID: 30301 RVA: 0x00156778 File Offset: 0x00154B78
		public uint GetMsgID()
		{
			return 1300008U;
		}

		// Token: 0x0600765E RID: 30302 RVA: 0x0015677F File Offset: 0x00154B7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600765F RID: 30303 RVA: 0x00156787 File Offset: 0x00154B87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007660 RID: 30304 RVA: 0x00156790 File Offset: 0x00154B90
		public void encode(byte[] buffer, ref int pos_)
		{
			this.raceEndInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007661 RID: 30305 RVA: 0x0015679F File Offset: 0x00154B9F
		public void decode(byte[] buffer, ref int pos_)
		{
			this.raceEndInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007662 RID: 30306 RVA: 0x001567AE File Offset: 0x00154BAE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.raceEndInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007663 RID: 30307 RVA: 0x001567BD File Offset: 0x00154BBD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.raceEndInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007664 RID: 30308 RVA: 0x001567CC File Offset: 0x00154BCC
		public int getLen()
		{
			int num = 0;
			return num + this.raceEndInfo.getLen();
		}

		// Token: 0x04003753 RID: 14163
		public const uint MsgID = 1300008U;

		// Token: 0x04003754 RID: 14164
		public uint Sequence;

		// Token: 0x04003755 RID: 14165
		public DungeonRaceEndInfo raceEndInfo = new DungeonRaceEndInfo();
	}
}
