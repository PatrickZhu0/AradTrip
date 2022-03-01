using System;

namespace Protocol
{
	// Token: 0x02000B87 RID: 2951
	[Protocol]
	public class WorldSyncTeammaster : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D1A RID: 32026 RVA: 0x001648EC File Offset: 0x00162CEC
		public uint GetMsgID()
		{
			return 601609U;
		}

		// Token: 0x06007D1B RID: 32027 RVA: 0x001648F3 File Offset: 0x00162CF3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D1C RID: 32028 RVA: 0x001648FB File Offset: 0x00162CFB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D1D RID: 32029 RVA: 0x00164904 File Offset: 0x00162D04
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.master);
		}

		// Token: 0x06007D1E RID: 32030 RVA: 0x00164914 File Offset: 0x00162D14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.master);
		}

		// Token: 0x06007D1F RID: 32031 RVA: 0x00164924 File Offset: 0x00162D24
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.master);
		}

		// Token: 0x06007D20 RID: 32032 RVA: 0x00164934 File Offset: 0x00162D34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.master);
		}

		// Token: 0x06007D21 RID: 32033 RVA: 0x00164944 File Offset: 0x00162D44
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003B56 RID: 15190
		public const uint MsgID = 601609U;

		// Token: 0x04003B57 RID: 15191
		public uint Sequence;

		// Token: 0x04003B58 RID: 15192
		public ulong master;
	}
}
