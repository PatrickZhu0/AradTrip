using System;

namespace Protocol
{
	// Token: 0x02000932 RID: 2354
	public class TimeItem : IProtocolStream
	{
		// Token: 0x06006B2C RID: 27436 RVA: 0x00139B90 File Offset: 0x00137F90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
		}

		// Token: 0x06006B2D RID: 27437 RVA: 0x00139BAE File Offset: 0x00137FAE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
		}

		// Token: 0x06006B2E RID: 27438 RVA: 0x00139BCC File Offset: 0x00137FCC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
		}

		// Token: 0x06006B2F RID: 27439 RVA: 0x00139BEA File Offset: 0x00137FEA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
		}

		// Token: 0x06006B30 RID: 27440 RVA: 0x00139C08 File Offset: 0x00138008
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003096 RID: 12438
		public ulong itemUid;

		// Token: 0x04003097 RID: 12439
		public uint state;
	}
}
