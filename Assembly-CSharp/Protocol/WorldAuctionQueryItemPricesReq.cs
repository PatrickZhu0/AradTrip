using System;

namespace Protocol
{
	// Token: 0x020006D1 RID: 1745
	[Protocol]
	public class WorldAuctionQueryItemPricesReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005908 RID: 22792 RVA: 0x0010E9B4 File Offset: 0x0010CDB4
		public uint GetMsgID()
		{
			return 603922U;
		}

		// Token: 0x06005909 RID: 22793 RVA: 0x0010E9BB File Offset: 0x0010CDBB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600590A RID: 22794 RVA: 0x0010E9C3 File Offset: 0x0010CDC3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600590B RID: 22795 RVA: 0x0010E9CC File Offset: 0x0010CDCC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x0600590C RID: 22796 RVA: 0x0010EA20 File Offset: 0x0010CE20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x0600590D RID: 22797 RVA: 0x0010EA74 File Offset: 0x0010CE74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x0600590E RID: 22798 RVA: 0x0010EAC8 File Offset: 0x0010CEC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x0600590F RID: 22799 RVA: 0x0010EB1C File Offset: 0x0010CF1C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x040023BB RID: 9147
		public const uint MsgID = 603922U;

		// Token: 0x040023BC RID: 9148
		public uint Sequence;

		// Token: 0x040023BD RID: 9149
		public byte type;

		// Token: 0x040023BE RID: 9150
		public uint itemTypeId;

		// Token: 0x040023BF RID: 9151
		public uint strengthen;

		// Token: 0x040023C0 RID: 9152
		public uint beadbuffid;

		// Token: 0x040023C1 RID: 9153
		public byte enhanceType;
	}
}
