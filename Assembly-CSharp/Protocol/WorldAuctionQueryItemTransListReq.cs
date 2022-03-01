using System;

namespace Protocol
{
	// Token: 0x020006E2 RID: 1762
	[Protocol]
	public class WorldAuctionQueryItemTransListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600599B RID: 22939 RVA: 0x00110489 File Offset: 0x0010E889
		public uint GetMsgID()
		{
			return 603935U;
		}

		// Token: 0x0600599C RID: 22940 RVA: 0x00110490 File Offset: 0x0010E890
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600599D RID: 22941 RVA: 0x00110498 File Offset: 0x0010E898
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600599E RID: 22942 RVA: 0x001104A1 File Offset: 0x0010E8A1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadBuffId);
		}

		// Token: 0x0600599F RID: 22943 RVA: 0x001104DB File Offset: 0x0010E8DB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadBuffId);
		}

		// Token: 0x060059A0 RID: 22944 RVA: 0x00110515 File Offset: 0x0010E915
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadBuffId);
		}

		// Token: 0x060059A1 RID: 22945 RVA: 0x0011054F File Offset: 0x0010E94F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadBuffId);
		}

		// Token: 0x060059A2 RID: 22946 RVA: 0x0011058C File Offset: 0x0010E98C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04002417 RID: 9239
		public const uint MsgID = 603935U;

		// Token: 0x04002418 RID: 9240
		public uint Sequence;

		// Token: 0x04002419 RID: 9241
		public uint itemTypeId;

		// Token: 0x0400241A RID: 9242
		public uint strengthen;

		// Token: 0x0400241B RID: 9243
		public byte enhanceType;

		// Token: 0x0400241C RID: 9244
		public uint beadBuffId;
	}
}
