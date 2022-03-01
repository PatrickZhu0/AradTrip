using System;

namespace Protocol
{
	// Token: 0x020008F2 RID: 2290
	[Protocol]
	public class SceneShopRefresh : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068F2 RID: 26866 RVA: 0x00136314 File Offset: 0x00134714
		public uint GetMsgID()
		{
			return 500932U;
		}

		// Token: 0x060068F3 RID: 26867 RVA: 0x0013631B File Offset: 0x0013471B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068F4 RID: 26868 RVA: 0x00136323 File Offset: 0x00134723
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068F5 RID: 26869 RVA: 0x0013632C File Offset: 0x0013472C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
		}

		// Token: 0x060068F6 RID: 26870 RVA: 0x0013633C File Offset: 0x0013473C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
		}

		// Token: 0x060068F7 RID: 26871 RVA: 0x0013634C File Offset: 0x0013474C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
		}

		// Token: 0x060068F8 RID: 26872 RVA: 0x0013635C File Offset: 0x0013475C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
		}

		// Token: 0x060068F9 RID: 26873 RVA: 0x0013636C File Offset: 0x0013476C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002F99 RID: 12185
		public const uint MsgID = 500932U;

		// Token: 0x04002F9A RID: 12186
		public uint Sequence;

		// Token: 0x04002F9B RID: 12187
		public byte shopId;
	}
}
