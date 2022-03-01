using System;

namespace Protocol
{
	// Token: 0x02000911 RID: 2321
	[Protocol]
	public class WorldMallBuy : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A09 RID: 27145 RVA: 0x00137DA1 File Offset: 0x001361A1
		public uint GetMsgID()
		{
			return 602801U;
		}

		// Token: 0x06006A0A RID: 27146 RVA: 0x00137DA8 File Offset: 0x001361A8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A0B RID: 27147 RVA: 0x00137DB0 File Offset: 0x001361B0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A0C RID: 27148 RVA: 0x00137DB9 File Offset: 0x001361B9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A0D RID: 27149 RVA: 0x00137DD7 File Offset: 0x001361D7
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A0E RID: 27150 RVA: 0x00137DF5 File Offset: 0x001361F5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A0F RID: 27151 RVA: 0x00137E13 File Offset: 0x00136213
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A10 RID: 27152 RVA: 0x00137E34 File Offset: 0x00136234
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 2;
		}

		// Token: 0x04003016 RID: 12310
		public const uint MsgID = 602801U;

		// Token: 0x04003017 RID: 12311
		public uint Sequence;

		// Token: 0x04003018 RID: 12312
		public uint itemId;

		// Token: 0x04003019 RID: 12313
		public ushort num;
	}
}
