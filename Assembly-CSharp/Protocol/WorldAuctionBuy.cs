using System;

namespace Protocol
{
	// Token: 0x020006C4 RID: 1732
	[Protocol]
	public class WorldAuctionBuy : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005893 RID: 22675 RVA: 0x0010E158 File Offset: 0x0010C558
		public uint GetMsgID()
		{
			return 603908U;
		}

		// Token: 0x06005894 RID: 22676 RVA: 0x0010E15F File Offset: 0x0010C55F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005895 RID: 22677 RVA: 0x0010E167 File Offset: 0x0010C567
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005896 RID: 22678 RVA: 0x0010E170 File Offset: 0x0010C570
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005897 RID: 22679 RVA: 0x0010E18E File Offset: 0x0010C58E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005898 RID: 22680 RVA: 0x0010E1AC File Offset: 0x0010C5AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005899 RID: 22681 RVA: 0x0010E1CA File Offset: 0x0010C5CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x0010E1E8 File Offset: 0x0010C5E8
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400238F RID: 9103
		public const uint MsgID = 603908U;

		// Token: 0x04002390 RID: 9104
		public uint Sequence;

		// Token: 0x04002391 RID: 9105
		public ulong id;

		// Token: 0x04002392 RID: 9106
		public uint num;
	}
}
