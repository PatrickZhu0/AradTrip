using System;

namespace Protocol
{
	// Token: 0x02000C3C RID: 3132
	public class HireInfoData : IProtocolStream
	{
		// Token: 0x0600827B RID: 33403 RVA: 0x0016F828 File Offset: 0x0016DC28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cnt);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x0600827C RID: 33404 RVA: 0x0016F854 File Offset: 0x0016DC54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cnt);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x0600827D RID: 33405 RVA: 0x0016F880 File Offset: 0x0016DC80
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cnt);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x0600827E RID: 33406 RVA: 0x0016F8AC File Offset: 0x0016DCAC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cnt);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x0600827F RID: 33407 RVA: 0x0016F8D8 File Offset: 0x0016DCD8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003E50 RID: 15952
		public uint taskID;

		// Token: 0x04003E51 RID: 15953
		public uint cnt;

		// Token: 0x04003E52 RID: 15954
		public byte status;
	}
}
