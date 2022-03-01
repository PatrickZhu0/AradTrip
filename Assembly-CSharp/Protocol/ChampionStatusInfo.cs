using System;

namespace Protocol
{
	// Token: 0x02000755 RID: 1877
	public class ChampionStatusInfo : IProtocolStream
	{
		// Token: 0x06005D28 RID: 23848 RVA: 0x001182B4 File Offset: 0x001166B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.prepareStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleEndTime);
		}

		// Token: 0x06005D29 RID: 23849 RVA: 0x00118324 File Offset: 0x00116724
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.prepareStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleEndTime);
		}

		// Token: 0x06005D2A RID: 23850 RVA: 0x00118394 File Offset: 0x00116794
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.prepareStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleStartTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleEndTime);
		}

		// Token: 0x06005D2B RID: 23851 RVA: 0x00118404 File Offset: 0x00116804
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.prepareStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleStartTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleEndTime);
		}

		// Token: 0x06005D2C RID: 23852 RVA: 0x00118474 File Offset: 0x00116874
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400262F RID: 9775
		public uint status;

		// Token: 0x04002630 RID: 9776
		public uint startTime;

		// Token: 0x04002631 RID: 9777
		public uint endTime;

		// Token: 0x04002632 RID: 9778
		public uint preStartTime;

		// Token: 0x04002633 RID: 9779
		public uint prepareStartTime;

		// Token: 0x04002634 RID: 9780
		public uint battleStartTime;

		// Token: 0x04002635 RID: 9781
		public uint battleEndTime;
	}
}
