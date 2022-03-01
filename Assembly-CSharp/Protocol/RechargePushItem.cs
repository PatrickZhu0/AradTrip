using System;

namespace Protocol
{
	// Token: 0x0200097B RID: 2427
	public class RechargePushItem : IProtocolStream
	{
		// Token: 0x06006DAB RID: 28075 RVA: 0x0013E334 File Offset: 0x0013C734
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.validTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastTimestamp);
		}

		// Token: 0x06006DAC RID: 28076 RVA: 0x0013E3C0 File Offset: 0x0013C7C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.validTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastTimestamp);
		}

		// Token: 0x06006DAD RID: 28077 RVA: 0x0013E44C File Offset: 0x0013C84C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.price);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discountPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.validTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastTimestamp);
		}

		// Token: 0x06006DAE RID: 28078 RVA: 0x0013E4D8 File Offset: 0x0013C8D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.price);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discountPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.validTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastTimestamp);
		}

		// Token: 0x06006DAF RID: 28079 RVA: 0x0013E564 File Offset: 0x0013C964
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040031A6 RID: 12710
		public uint pushId;

		// Token: 0x040031A7 RID: 12711
		public uint itemId;

		// Token: 0x040031A8 RID: 12712
		public uint itemCount;

		// Token: 0x040031A9 RID: 12713
		public uint buyTimes;

		// Token: 0x040031AA RID: 12714
		public uint maxTimes;

		// Token: 0x040031AB RID: 12715
		public uint price;

		// Token: 0x040031AC RID: 12716
		public uint discountPrice;

		// Token: 0x040031AD RID: 12717
		public uint validTimestamp;

		// Token: 0x040031AE RID: 12718
		public uint lastTimestamp;
	}
}
