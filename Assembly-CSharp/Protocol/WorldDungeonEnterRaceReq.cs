using System;

namespace Protocol
{
	// Token: 0x020007E3 RID: 2019
	[Protocol]
	public class WorldDungeonEnterRaceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006166 RID: 24934 RVA: 0x00123CEC File Offset: 0x001220EC
		public uint GetMsgID()
		{
			return 606809U;
		}

		// Token: 0x06006167 RID: 24935 RVA: 0x00123CF3 File Offset: 0x001220F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006168 RID: 24936 RVA: 0x00123CFB File Offset: 0x001220FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006169 RID: 24937 RVA: 0x00123D04 File Offset: 0x00122104
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600616A RID: 24938 RVA: 0x00123D06 File Offset: 0x00122106
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600616B RID: 24939 RVA: 0x00123D08 File Offset: 0x00122108
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600616C RID: 24940 RVA: 0x00123D0A File Offset: 0x0012210A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600616D RID: 24941 RVA: 0x00123D0C File Offset: 0x0012210C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002896 RID: 10390
		public const uint MsgID = 606809U;

		// Token: 0x04002897 RID: 10391
		public uint Sequence;
	}
}
