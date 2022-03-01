using System;

namespace Protocol
{
	// Token: 0x020007B1 RID: 1969
	[Protocol]
	public class SceneDungeonHardUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005FCB RID: 24523 RVA: 0x0011E890 File Offset: 0x0011CC90
		public uint GetMsgID()
		{
			return 506804U;
		}

		// Token: 0x06005FCC RID: 24524 RVA: 0x0011E897 File Offset: 0x0011CC97
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005FCD RID: 24525 RVA: 0x0011E89F File Offset: 0x0011CC9F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005FCE RID: 24526 RVA: 0x0011E8A8 File Offset: 0x0011CCA8
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005FCF RID: 24527 RVA: 0x0011E8B7 File Offset: 0x0011CCB7
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005FD0 RID: 24528 RVA: 0x0011E8C6 File Offset: 0x0011CCC6
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005FD1 RID: 24529 RVA: 0x0011E8D5 File Offset: 0x0011CCD5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005FD2 RID: 24530 RVA: 0x0011E8E4 File Offset: 0x0011CCE4
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x040027A7 RID: 10151
		public const uint MsgID = 506804U;

		// Token: 0x040027A8 RID: 10152
		public uint Sequence;

		// Token: 0x040027A9 RID: 10153
		public SceneDungeonHardInfo info = new SceneDungeonHardInfo();
	}
}
