using System;

namespace Protocol
{
	// Token: 0x02000AFD RID: 2813
	public class SceneDir : IProtocolStream
	{
		// Token: 0x06007909 RID: 30985 RVA: 0x0015CD54 File Offset: 0x0015B154
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int16(buffer, ref pos_, this.x);
			BaseDLL.encode_int16(buffer, ref pos_, this.y);
			BaseDLL.encode_int8(buffer, ref pos_, this.faceRight);
		}

		// Token: 0x0600790A RID: 30986 RVA: 0x0015CD80 File Offset: 0x0015B180
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int16(buffer, ref pos_, ref this.x);
			BaseDLL.decode_int16(buffer, ref pos_, ref this.y);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.faceRight);
		}

		// Token: 0x0600790B RID: 30987 RVA: 0x0015CDAC File Offset: 0x0015B1AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int16(buffer, ref pos_, this.x);
			BaseDLL.encode_int16(buffer, ref pos_, this.y);
			BaseDLL.encode_int8(buffer, ref pos_, this.faceRight);
		}

		// Token: 0x0600790C RID: 30988 RVA: 0x0015CDD8 File Offset: 0x0015B1D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int16(buffer, ref pos_, ref this.x);
			BaseDLL.decode_int16(buffer, ref pos_, ref this.y);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.faceRight);
		}

		// Token: 0x0600790D RID: 30989 RVA: 0x0015CE04 File Offset: 0x0015B204
		public int getLen()
		{
			int num = 0;
			num += 2;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003922 RID: 14626
		public short x;

		// Token: 0x04003923 RID: 14627
		public short y;

		// Token: 0x04003924 RID: 14628
		public byte faceRight;
	}
}
