using System;

namespace Protocol
{
	// Token: 0x02000906 RID: 2310
	[Protocol]
	public class SceneAddMagicRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069A6 RID: 27046 RVA: 0x001371D0 File Offset: 0x001355D0
		public uint GetMsgID()
		{
			return 500945U;
		}

		// Token: 0x060069A7 RID: 27047 RVA: 0x001371D7 File Offset: 0x001355D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069A8 RID: 27048 RVA: 0x001371DF File Offset: 0x001355DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069A9 RID: 27049 RVA: 0x001371E8 File Offset: 0x001355E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
		}

		// Token: 0x060069AA RID: 27050 RVA: 0x00137222 File Offset: 0x00135622
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
		}

		// Token: 0x060069AB RID: 27051 RVA: 0x0013725C File Offset: 0x0013565C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
		}

		// Token: 0x060069AC RID: 27052 RVA: 0x00137296 File Offset: 0x00135696
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
		}

		// Token: 0x060069AD RID: 27053 RVA: 0x001372D0 File Offset: 0x001356D0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002FE3 RID: 12259
		public const uint MsgID = 500945U;

		// Token: 0x04002FE4 RID: 12260
		public uint Sequence;

		// Token: 0x04002FE5 RID: 12261
		public uint code;

		// Token: 0x04002FE6 RID: 12262
		public ulong itemUid;

		// Token: 0x04002FE7 RID: 12263
		public uint cardId;

		// Token: 0x04002FE8 RID: 12264
		public byte cardLev;
	}
}
