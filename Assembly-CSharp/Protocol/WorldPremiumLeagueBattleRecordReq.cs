using System;

namespace Protocol
{
	// Token: 0x02000A6F RID: 2671
	[Protocol]
	public class WorldPremiumLeagueBattleRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007516 RID: 29974 RVA: 0x00152CCA File Offset: 0x001510CA
		public uint GetMsgID()
		{
			return 607709U;
		}

		// Token: 0x06007517 RID: 29975 RVA: 0x00152CD1 File Offset: 0x001510D1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007518 RID: 29976 RVA: 0x00152CD9 File Offset: 0x001510D9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007519 RID: 29977 RVA: 0x00152CE2 File Offset: 0x001510E2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSelf);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x0600751A RID: 29978 RVA: 0x00152D0E File Offset: 0x0015110E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSelf);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x0600751B RID: 29979 RVA: 0x00152D3A File Offset: 0x0015113A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSelf);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x0600751C RID: 29980 RVA: 0x00152D66 File Offset: 0x00151166
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSelf);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x0600751D RID: 29981 RVA: 0x00152D94 File Offset: 0x00151194
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003673 RID: 13939
		public const uint MsgID = 607709U;

		// Token: 0x04003674 RID: 13940
		public uint Sequence;

		// Token: 0x04003675 RID: 13941
		public byte isSelf;

		// Token: 0x04003676 RID: 13942
		public uint startIndex;

		// Token: 0x04003677 RID: 13943
		public uint count;
	}
}
