using System;

namespace Protocol
{
	// Token: 0x020007E2 RID: 2018
	[Protocol]
	public class SceneDungeonResetAreaIndexRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600615D RID: 24925 RVA: 0x00123C3C File Offset: 0x0012203C
		public uint GetMsgID()
		{
			return 506834U;
		}

		// Token: 0x0600615E RID: 24926 RVA: 0x00123C43 File Offset: 0x00122043
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600615F RID: 24927 RVA: 0x00123C4B File Offset: 0x0012204B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006160 RID: 24928 RVA: 0x00123C54 File Offset: 0x00122054
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaIndex);
		}

		// Token: 0x06006161 RID: 24929 RVA: 0x00123C72 File Offset: 0x00122072
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaIndex);
		}

		// Token: 0x06006162 RID: 24930 RVA: 0x00123C90 File Offset: 0x00122090
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaIndex);
		}

		// Token: 0x06006163 RID: 24931 RVA: 0x00123CAE File Offset: 0x001220AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaIndex);
		}

		// Token: 0x06006164 RID: 24932 RVA: 0x00123CCC File Offset: 0x001220CC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002892 RID: 10386
		public const uint MsgID = 506834U;

		// Token: 0x04002893 RID: 10387
		public uint Sequence;

		// Token: 0x04002894 RID: 10388
		public uint dungeonId;

		// Token: 0x04002895 RID: 10389
		public uint areaIndex;
	}
}
