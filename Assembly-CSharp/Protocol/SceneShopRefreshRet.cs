using System;

namespace Protocol
{
	// Token: 0x020008F3 RID: 2291
	[Protocol]
	public class SceneShopRefreshRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068FB RID: 26875 RVA: 0x00136388 File Offset: 0x00134788
		public uint GetMsgID()
		{
			return 500933U;
		}

		// Token: 0x060068FC RID: 26876 RVA: 0x0013638F File Offset: 0x0013478F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068FD RID: 26877 RVA: 0x00136397 File Offset: 0x00134797
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068FE RID: 26878 RVA: 0x001363A0 File Offset: 0x001347A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060068FF RID: 26879 RVA: 0x001363B0 File Offset: 0x001347B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006900 RID: 26880 RVA: 0x001363C0 File Offset: 0x001347C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006901 RID: 26881 RVA: 0x001363D0 File Offset: 0x001347D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006902 RID: 26882 RVA: 0x001363E0 File Offset: 0x001347E0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F9C RID: 12188
		public const uint MsgID = 500933U;

		// Token: 0x04002F9D RID: 12189
		public uint Sequence;

		// Token: 0x04002F9E RID: 12190
		public uint code;
	}
}
