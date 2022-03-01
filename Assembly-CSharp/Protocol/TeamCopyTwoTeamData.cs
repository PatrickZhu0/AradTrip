using System;

namespace Protocol
{
	// Token: 0x02000C14 RID: 3092
	[Protocol]
	public class TeamCopyTwoTeamData : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008146 RID: 33094 RVA: 0x0016D5C0 File Offset: 0x0016B9C0
		public uint GetMsgID()
		{
			return 1100086U;
		}

		// Token: 0x06008147 RID: 33095 RVA: 0x0016D5C7 File Offset: 0x0016B9C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008148 RID: 33096 RVA: 0x0016D5CF File Offset: 0x0016B9CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008149 RID: 33097 RVA: 0x0016D5D8 File Offset: 0x0016B9D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameOverTime);
		}

		// Token: 0x0600814A RID: 33098 RVA: 0x0016D5E8 File Offset: 0x0016B9E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameOverTime);
		}

		// Token: 0x0600814B RID: 33099 RVA: 0x0016D5F8 File Offset: 0x0016B9F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameOverTime);
		}

		// Token: 0x0600814C RID: 33100 RVA: 0x0016D608 File Offset: 0x0016BA08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameOverTime);
		}

		// Token: 0x0600814D RID: 33101 RVA: 0x0016D618 File Offset: 0x0016BA18
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DB8 RID: 15800
		public const uint MsgID = 1100086U;

		// Token: 0x04003DB9 RID: 15801
		public uint Sequence;

		// Token: 0x04003DBA RID: 15802
		public uint gameOverTime;
	}
}
