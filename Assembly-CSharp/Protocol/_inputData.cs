using System;

namespace Protocol
{
	// Token: 0x02000A8F RID: 2703
	public class _inputData : IProtocolStream
	{
		// Token: 0x06007603 RID: 30211 RVA: 0x00155230 File Offset: 0x00153630
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data3);
		}

		// Token: 0x06007604 RID: 30212 RVA: 0x0015526A File Offset: 0x0015366A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data3);
		}

		// Token: 0x06007605 RID: 30213 RVA: 0x001552A4 File Offset: 0x001536A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data3);
		}

		// Token: 0x06007606 RID: 30214 RVA: 0x001552DE File Offset: 0x001536DE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data3);
		}

		// Token: 0x06007607 RID: 30215 RVA: 0x00155318 File Offset: 0x00153718
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003719 RID: 14105
		public uint sendTime;

		// Token: 0x0400371A RID: 14106
		public uint data1;

		// Token: 0x0400371B RID: 14107
		public uint data2;

		// Token: 0x0400371C RID: 14108
		public uint data3;
	}
}
