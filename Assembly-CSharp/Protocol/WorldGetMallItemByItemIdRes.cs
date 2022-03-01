using System;

namespace Protocol
{
	// Token: 0x02000919 RID: 2329
	[Protocol]
	public class WorldGetMallItemByItemIdRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A4E RID: 27214 RVA: 0x0013862F File Offset: 0x00136A2F
		public uint GetMsgID()
		{
			return 602822U;
		}

		// Token: 0x06006A4F RID: 27215 RVA: 0x00138636 File Offset: 0x00136A36
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A50 RID: 27216 RVA: 0x0013863E File Offset: 0x00136A3E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A51 RID: 27217 RVA: 0x00138647 File Offset: 0x00136A47
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			this.mallItem.encode(buffer, ref pos_);
		}

		// Token: 0x06006A52 RID: 27218 RVA: 0x00138672 File Offset: 0x00136A72
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			this.mallItem.decode(buffer, ref pos_);
		}

		// Token: 0x06006A53 RID: 27219 RVA: 0x0013869D File Offset: 0x00136A9D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			this.mallItem.encode(buffer, ref pos_);
		}

		// Token: 0x06006A54 RID: 27220 RVA: 0x001386C8 File Offset: 0x00136AC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			this.mallItem.decode(buffer, ref pos_);
		}

		// Token: 0x06006A55 RID: 27221 RVA: 0x001386F4 File Offset: 0x00136AF4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + this.mallItem.getLen();
		}

		// Token: 0x04003032 RID: 12338
		public const uint MsgID = 602822U;

		// Token: 0x04003033 RID: 12339
		public uint Sequence;

		// Token: 0x04003034 RID: 12340
		public uint retCode;

		// Token: 0x04003035 RID: 12341
		public uint itemId;

		// Token: 0x04003036 RID: 12342
		public MallItemInfo mallItem = new MallItemInfo();
	}
}
