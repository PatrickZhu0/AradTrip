using System;

namespace Protocol
{
	// Token: 0x02000694 RID: 1684
	public class ExpeditionMapBaseInfo : IProtocolStream
	{
		// Token: 0x0600574A RID: 22346 RVA: 0x0010A98E File Offset: 0x00108D8E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, this.memberNum);
		}

		// Token: 0x0600574B RID: 22347 RVA: 0x0010A9BA File Offset: 0x00108DBA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.memberNum);
		}

		// Token: 0x0600574C RID: 22348 RVA: 0x0010A9E6 File Offset: 0x00108DE6
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, this.memberNum);
		}

		// Token: 0x0600574D RID: 22349 RVA: 0x0010AA12 File Offset: 0x00108E12
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.memberNum);
		}

		// Token: 0x0600574E RID: 22350 RVA: 0x0010AA40 File Offset: 0x00108E40
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			return num + 2;
		}

		// Token: 0x040022B4 RID: 8884
		public byte mapId;

		// Token: 0x040022B5 RID: 8885
		public byte expeditionStatus;

		// Token: 0x040022B6 RID: 8886
		public ushort memberNum;
	}
}
