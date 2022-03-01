using System;

namespace Protocol
{
	// Token: 0x020007AA RID: 1962
	public class SceneDungeonInfo : IProtocolStream
	{
		// Token: 0x06005F98 RID: 24472 RVA: 0x0011E0A1 File Offset: 0x0011C4A1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.bestScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bestRecordTime);
		}

		// Token: 0x06005F99 RID: 24473 RVA: 0x0011E0CD File Offset: 0x0011C4CD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bestScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bestRecordTime);
		}

		// Token: 0x06005F9A RID: 24474 RVA: 0x0011E0F9 File Offset: 0x0011C4F9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.bestScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bestRecordTime);
		}

		// Token: 0x06005F9B RID: 24475 RVA: 0x0011E125 File Offset: 0x0011C525
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bestScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bestRecordTime);
		}

		// Token: 0x06005F9C RID: 24476 RVA: 0x0011E154 File Offset: 0x0011C554
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04002797 RID: 10135
		public uint id;

		// Token: 0x04002798 RID: 10136
		public byte bestScore;

		// Token: 0x04002799 RID: 10137
		public uint bestRecordTime;
	}
}
