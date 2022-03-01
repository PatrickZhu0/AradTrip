using System;

namespace Protocol
{
	// Token: 0x020008EC RID: 2284
	[Protocol]
	public class SceneShopQuery : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068BC RID: 26812 RVA: 0x00135DF8 File Offset: 0x001341F8
		public uint GetMsgID()
		{
			return 500922U;
		}

		// Token: 0x060068BD RID: 26813 RVA: 0x00135DFF File Offset: 0x001341FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068BE RID: 26814 RVA: 0x00135E07 File Offset: 0x00134207
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068BF RID: 26815 RVA: 0x00135E10 File Offset: 0x00134210
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cache);
		}

		// Token: 0x060068C0 RID: 26816 RVA: 0x00135E2E File Offset: 0x0013422E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cache);
		}

		// Token: 0x060068C1 RID: 26817 RVA: 0x00135E4C File Offset: 0x0013424C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cache);
		}

		// Token: 0x060068C2 RID: 26818 RVA: 0x00135E6A File Offset: 0x0013426A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cache);
		}

		// Token: 0x060068C3 RID: 26819 RVA: 0x00135E88 File Offset: 0x00134288
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002F82 RID: 12162
		public const uint MsgID = 500922U;

		// Token: 0x04002F83 RID: 12163
		public uint Sequence;

		// Token: 0x04002F84 RID: 12164
		public byte shopId;

		// Token: 0x04002F85 RID: 12165
		public byte cache;
	}
}
