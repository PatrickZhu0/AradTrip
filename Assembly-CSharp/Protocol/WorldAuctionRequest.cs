using System;

namespace Protocol
{
	// Token: 0x020006C3 RID: 1731
	[Protocol]
	public class WorldAuctionRequest : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600588A RID: 22666 RVA: 0x0010DE59 File Offset: 0x0010C259
		public uint GetMsgID()
		{
			return 603906U;
		}

		// Token: 0x0600588B RID: 22667 RVA: 0x0010DE60 File Offset: 0x0010C260
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600588C RID: 22668 RVA: 0x0010DE68 File Offset: 0x0010C268
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600588D RID: 22669 RVA: 0x0010DE74 File Offset: 0x0010C274
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_int8(buffer, ref pos_, this.duration);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAgain);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctionGuid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x0600588E RID: 22670 RVA: 0x0010DF1C File Offset: 0x0010C31C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.duration);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAgain);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctionGuid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x0600588F RID: 22671 RVA: 0x0010DFC4 File Offset: 0x0010C3C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_int8(buffer, ref pos_, this.duration);
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadbuffId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAgain);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctionGuid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
		}

		// Token: 0x06005890 RID: 22672 RVA: 0x0010E06C File Offset: 0x0010C46C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.duration);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadbuffId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAgain);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctionGuid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
		}

		// Token: 0x06005891 RID: 22673 RVA: 0x0010E114 File Offset: 0x0010C514
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num += 4;
			num++;
			num += 8;
			return num + 1;
		}

		// Token: 0x04002382 RID: 9090
		public const uint MsgID = 603906U;

		// Token: 0x04002383 RID: 9091
		public uint Sequence;

		// Token: 0x04002384 RID: 9092
		public byte type;

		// Token: 0x04002385 RID: 9093
		public ulong id;

		// Token: 0x04002386 RID: 9094
		public uint typeId;

		// Token: 0x04002387 RID: 9095
		public uint num;

		// Token: 0x04002388 RID: 9096
		public uint price;

		// Token: 0x04002389 RID: 9097
		public byte duration;

		// Token: 0x0400238A RID: 9098
		public byte strength;

		// Token: 0x0400238B RID: 9099
		public uint beadbuffId;

		// Token: 0x0400238C RID: 9100
		public byte isAgain;

		// Token: 0x0400238D RID: 9101
		public ulong auctionGuid;

		// Token: 0x0400238E RID: 9102
		public byte enhanceType;
	}
}
