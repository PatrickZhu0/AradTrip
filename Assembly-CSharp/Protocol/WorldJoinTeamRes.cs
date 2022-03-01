using System;

namespace Protocol
{
	// Token: 0x02000B7B RID: 2939
	[Protocol]
	public class WorldJoinTeamRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CB4 RID: 31924 RVA: 0x0016395C File Offset: 0x00161D5C
		public uint GetMsgID()
		{
			return 601628U;
		}

		// Token: 0x06007CB5 RID: 31925 RVA: 0x00163963 File Offset: 0x00161D63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CB6 RID: 31926 RVA: 0x0016396B File Offset: 0x00161D6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CB7 RID: 31927 RVA: 0x00163974 File Offset: 0x00161D74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.inTeam);
		}

		// Token: 0x06007CB8 RID: 31928 RVA: 0x00163992 File Offset: 0x00161D92
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inTeam);
		}

		// Token: 0x06007CB9 RID: 31929 RVA: 0x001639B0 File Offset: 0x00161DB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.inTeam);
		}

		// Token: 0x06007CBA RID: 31930 RVA: 0x001639CE File Offset: 0x00161DCE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inTeam);
		}

		// Token: 0x06007CBB RID: 31931 RVA: 0x001639EC File Offset: 0x00161DEC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003B1B RID: 15131
		public const uint MsgID = 601628U;

		// Token: 0x04003B1C RID: 15132
		public uint Sequence;

		// Token: 0x04003B1D RID: 15133
		public uint result;

		// Token: 0x04003B1E RID: 15134
		public byte inTeam;
	}
}
