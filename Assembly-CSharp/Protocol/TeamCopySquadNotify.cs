using System;

namespace Protocol
{
	// Token: 0x02000BE0 RID: 3040
	[Protocol]
	public class TeamCopySquadNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F7E RID: 32638 RVA: 0x00169BE9 File Offset: 0x00167FE9
		public uint GetMsgID()
		{
			return 1100038U;
		}

		// Token: 0x06007F7F RID: 32639 RVA: 0x00169BF0 File Offset: 0x00167FF0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F80 RID: 32640 RVA: 0x00169BF8 File Offset: 0x00167FF8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F81 RID: 32641 RVA: 0x00169C01 File Offset: 0x00168001
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
		}

		// Token: 0x06007F82 RID: 32642 RVA: 0x00169C1F File Offset: 0x0016801F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
		}

		// Token: 0x06007F83 RID: 32643 RVA: 0x00169C3D File Offset: 0x0016803D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
		}

		// Token: 0x06007F84 RID: 32644 RVA: 0x00169C5B File Offset: 0x0016805B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
		}

		// Token: 0x06007F85 RID: 32645 RVA: 0x00169C7C File Offset: 0x0016807C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003CDC RID: 15580
		public const uint MsgID = 1100038U;

		// Token: 0x04003CDD RID: 15581
		public uint Sequence;

		// Token: 0x04003CDE RID: 15582
		public uint squadId;

		// Token: 0x04003CDF RID: 15583
		public uint squadStatus;
	}
}
