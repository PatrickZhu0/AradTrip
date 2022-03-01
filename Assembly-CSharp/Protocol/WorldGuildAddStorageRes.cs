using System;

namespace Protocol
{
	// Token: 0x02000872 RID: 2162
	[Protocol]
	public class WorldGuildAddStorageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006574 RID: 25972 RVA: 0x0012DD21 File Offset: 0x0012C121
		public uint GetMsgID()
		{
			return 601973U;
		}

		// Token: 0x06006575 RID: 25973 RVA: 0x0012DD28 File Offset: 0x0012C128
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006576 RID: 25974 RVA: 0x0012DD30 File Offset: 0x0012C130
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006577 RID: 25975 RVA: 0x0012DD39 File Offset: 0x0012C139
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006578 RID: 25976 RVA: 0x0012DD49 File Offset: 0x0012C149
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006579 RID: 25977 RVA: 0x0012DD59 File Offset: 0x0012C159
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600657A RID: 25978 RVA: 0x0012DD69 File Offset: 0x0012C169
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600657B RID: 25979 RVA: 0x0012DD7C File Offset: 0x0012C17C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D75 RID: 11637
		public const uint MsgID = 601973U;

		// Token: 0x04002D76 RID: 11638
		public uint Sequence;

		// Token: 0x04002D77 RID: 11639
		public uint result;
	}
}
