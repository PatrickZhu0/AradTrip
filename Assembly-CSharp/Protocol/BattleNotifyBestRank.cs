using System;

namespace Protocol
{
	// Token: 0x0200071C RID: 1820
	[Protocol]
	public class BattleNotifyBestRank : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B6F RID: 23407 RVA: 0x00115238 File Offset: 0x00113638
		public uint GetMsgID()
		{
			return 508937U;
		}

		// Token: 0x06005B70 RID: 23408 RVA: 0x0011523F File Offset: 0x0011363F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B71 RID: 23409 RVA: 0x00115247 File Offset: 0x00113647
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B72 RID: 23410 RVA: 0x00115250 File Offset: 0x00113650
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
		}

		// Token: 0x06005B73 RID: 23411 RVA: 0x00115260 File Offset: 0x00113660
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
		}

		// Token: 0x06005B74 RID: 23412 RVA: 0x00115270 File Offset: 0x00113670
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
		}

		// Token: 0x06005B75 RID: 23413 RVA: 0x00115280 File Offset: 0x00113680
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
		}

		// Token: 0x06005B76 RID: 23414 RVA: 0x00115290 File Offset: 0x00113690
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002548 RID: 9544
		public const uint MsgID = 508937U;

		// Token: 0x04002549 RID: 9545
		public uint Sequence;

		// Token: 0x0400254A RID: 9546
		public uint rank;
	}
}
