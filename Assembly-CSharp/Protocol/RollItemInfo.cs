using System;

namespace Protocol
{
	// Token: 0x020007BC RID: 1980
	public class RollItemInfo : IProtocolStream
	{
		// Token: 0x06006013 RID: 24595 RVA: 0x0011FEF8 File Offset: 0x0011E2F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rollIndex);
			this.dropItem.encode(buffer, ref pos_);
		}

		// Token: 0x06006014 RID: 24596 RVA: 0x0011FF15 File Offset: 0x0011E315
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rollIndex);
			this.dropItem.decode(buffer, ref pos_);
		}

		// Token: 0x06006015 RID: 24597 RVA: 0x0011FF32 File Offset: 0x0011E332
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rollIndex);
			this.dropItem.encode(buffer, ref pos_);
		}

		// Token: 0x06006016 RID: 24598 RVA: 0x0011FF4F File Offset: 0x0011E34F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rollIndex);
			this.dropItem.decode(buffer, ref pos_);
		}

		// Token: 0x06006017 RID: 24599 RVA: 0x0011FF6C File Offset: 0x0011E36C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + this.dropItem.getLen();
		}

		// Token: 0x040027D2 RID: 10194
		public byte rollIndex;

		// Token: 0x040027D3 RID: 10195
		public DropItem dropItem = new DropItem();
	}
}
