using System;

namespace Protocol
{
	// Token: 0x020008F4 RID: 2292
	[Protocol]
	public class SceneShopRefreshNumReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006904 RID: 26884 RVA: 0x001363FC File Offset: 0x001347FC
		public uint GetMsgID()
		{
			return 500956U;
		}

		// Token: 0x06006905 RID: 26885 RVA: 0x00136403 File Offset: 0x00134803
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006906 RID: 26886 RVA: 0x0013640B File Offset: 0x0013480B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006907 RID: 26887 RVA: 0x00136414 File Offset: 0x00134814
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
		}

		// Token: 0x06006908 RID: 26888 RVA: 0x00136424 File Offset: 0x00134824
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
		}

		// Token: 0x06006909 RID: 26889 RVA: 0x00136434 File Offset: 0x00134834
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
		}

		// Token: 0x0600690A RID: 26890 RVA: 0x00136444 File Offset: 0x00134844
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
		}

		// Token: 0x0600690B RID: 26891 RVA: 0x00136454 File Offset: 0x00134854
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002F9F RID: 12191
		public const uint MsgID = 500956U;

		// Token: 0x04002FA0 RID: 12192
		public uint Sequence;

		// Token: 0x04002FA1 RID: 12193
		public byte shopId;
	}
}
