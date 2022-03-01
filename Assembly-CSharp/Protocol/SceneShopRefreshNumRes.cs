using System;

namespace Protocol
{
	// Token: 0x020008F5 RID: 2293
	[Protocol]
	public class SceneShopRefreshNumRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600690D RID: 26893 RVA: 0x00136470 File Offset: 0x00134870
		public uint GetMsgID()
		{
			return 500957U;
		}

		// Token: 0x0600690E RID: 26894 RVA: 0x00136477 File Offset: 0x00134877
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600690F RID: 26895 RVA: 0x0013647F File Offset: 0x0013487F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006910 RID: 26896 RVA: 0x00136488 File Offset: 0x00134888
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.restRefreshNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxRefreshNum);
		}

		// Token: 0x06006911 RID: 26897 RVA: 0x001364B4 File Offset: 0x001348B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.restRefreshNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxRefreshNum);
		}

		// Token: 0x06006912 RID: 26898 RVA: 0x001364E0 File Offset: 0x001348E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.restRefreshNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxRefreshNum);
		}

		// Token: 0x06006913 RID: 26899 RVA: 0x0013650C File Offset: 0x0013490C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.restRefreshNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxRefreshNum);
		}

		// Token: 0x06006914 RID: 26900 RVA: 0x00136538 File Offset: 0x00134938
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x04002FA2 RID: 12194
		public const uint MsgID = 500957U;

		// Token: 0x04002FA3 RID: 12195
		public uint Sequence;

		// Token: 0x04002FA4 RID: 12196
		public byte shopId;

		// Token: 0x04002FA5 RID: 12197
		public byte restRefreshNum;

		// Token: 0x04002FA6 RID: 12198
		public byte maxRefreshNum;
	}
}
