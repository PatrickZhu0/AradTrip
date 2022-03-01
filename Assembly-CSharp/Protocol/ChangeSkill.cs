using System;

namespace Protocol
{
	// Token: 0x02000B5A RID: 2906
	public class ChangeSkill : IProtocolStream
	{
		// Token: 0x06007BD3 RID: 31699 RVA: 0x001627F1 File Offset: 0x00160BF1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.dif);
		}

		// Token: 0x06007BD4 RID: 31700 RVA: 0x0016280F File Offset: 0x00160C0F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dif);
		}

		// Token: 0x06007BD5 RID: 31701 RVA: 0x0016282D File Offset: 0x00160C2D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.dif);
		}

		// Token: 0x06007BD6 RID: 31702 RVA: 0x0016284B File Offset: 0x00160C4B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dif);
		}

		// Token: 0x06007BD7 RID: 31703 RVA: 0x0016286C File Offset: 0x00160C6C
		public int getLen()
		{
			int num = 0;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003AB0 RID: 15024
		public ushort id;

		// Token: 0x04003AB1 RID: 15025
		public byte dif;
	}
}
