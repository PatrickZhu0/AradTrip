using System;

namespace Protocol
{
	// Token: 0x02000937 RID: 2359
	[Protocol]
	public class SceneSellItemBatRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B56 RID: 27478 RVA: 0x0013A1F7 File Offset: 0x001385F7
		public uint GetMsgID()
		{
			return 500974U;
		}

		// Token: 0x06006B57 RID: 27479 RVA: 0x0013A1FE File Offset: 0x001385FE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B58 RID: 27480 RVA: 0x0013A206 File Offset: 0x00138606
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B59 RID: 27481 RVA: 0x0013A20F File Offset: 0x0013860F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B5A RID: 27482 RVA: 0x0013A21F File Offset: 0x0013861F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B5B RID: 27483 RVA: 0x0013A22F File Offset: 0x0013862F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B5C RID: 27484 RVA: 0x0013A23F File Offset: 0x0013863F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B5D RID: 27485 RVA: 0x0013A250 File Offset: 0x00138650
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040030A6 RID: 12454
		public const uint MsgID = 500974U;

		// Token: 0x040030A7 RID: 12455
		public uint Sequence;

		// Token: 0x040030A8 RID: 12456
		public uint code;
	}
}
