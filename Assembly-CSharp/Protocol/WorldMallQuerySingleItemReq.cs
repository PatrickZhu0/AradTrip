using System;

namespace Protocol
{
	// Token: 0x0200091A RID: 2330
	[Protocol]
	public class WorldMallQuerySingleItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A57 RID: 27223 RVA: 0x00138722 File Offset: 0x00136B22
		public uint GetMsgID()
		{
			return 602823U;
		}

		// Token: 0x06006A58 RID: 27224 RVA: 0x00138729 File Offset: 0x00136B29
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A59 RID: 27225 RVA: 0x00138731 File Offset: 0x00136B31
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A5A RID: 27226 RVA: 0x0013873A File Offset: 0x00136B3A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallItemId);
		}

		// Token: 0x06006A5B RID: 27227 RVA: 0x0013874A File Offset: 0x00136B4A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallItemId);
		}

		// Token: 0x06006A5C RID: 27228 RVA: 0x0013875A File Offset: 0x00136B5A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mallItemId);
		}

		// Token: 0x06006A5D RID: 27229 RVA: 0x0013876A File Offset: 0x00136B6A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mallItemId);
		}

		// Token: 0x06006A5E RID: 27230 RVA: 0x0013877C File Offset: 0x00136B7C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003037 RID: 12343
		public const uint MsgID = 602823U;

		// Token: 0x04003038 RID: 12344
		public uint Sequence;

		// Token: 0x04003039 RID: 12345
		public uint mallItemId;
	}
}
