using System;

namespace Protocol
{
	// Token: 0x020008CE RID: 2254
	public class MallBuyGotInfo : IProtocolStream
	{
		// Token: 0x060067C9 RID: 26569 RVA: 0x001320BC File Offset: 0x001304BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.buyGotType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyGotNum);
		}

		// Token: 0x060067CA RID: 26570 RVA: 0x001320E8 File Offset: 0x001304E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.buyGotType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyGotNum);
		}

		// Token: 0x060067CB RID: 26571 RVA: 0x00132114 File Offset: 0x00130514
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.buyGotType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyGotNum);
		}

		// Token: 0x060067CC RID: 26572 RVA: 0x00132140 File Offset: 0x00130540
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.buyGotType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyGotNum);
		}

		// Token: 0x060067CD RID: 26573 RVA: 0x0013216C File Offset: 0x0013056C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002ECF RID: 11983
		public byte buyGotType;

		// Token: 0x04002ED0 RID: 11984
		public uint itemDataId;

		// Token: 0x04002ED1 RID: 11985
		public uint buyGotNum;
	}
}
