using System;

namespace Protocol
{
	// Token: 0x02000908 RID: 2312
	[Protocol]
	public class SceneMagicCardCompRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069B8 RID: 27064 RVA: 0x001373A8 File Offset: 0x001357A8
		public uint GetMsgID()
		{
			return 500947U;
		}

		// Token: 0x060069B9 RID: 27065 RVA: 0x001373AF File Offset: 0x001357AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069BA RID: 27066 RVA: 0x001373B7 File Offset: 0x001357B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069BB RID: 27067 RVA: 0x001373C0 File Offset: 0x001357C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
		}

		// Token: 0x060069BC RID: 27068 RVA: 0x001373EC File Offset: 0x001357EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
		}

		// Token: 0x060069BD RID: 27069 RVA: 0x00137418 File Offset: 0x00135818
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
		}

		// Token: 0x060069BE RID: 27070 RVA: 0x00137444 File Offset: 0x00135844
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
		}

		// Token: 0x060069BF RID: 27071 RVA: 0x00137470 File Offset: 0x00135870
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002FED RID: 12269
		public const uint MsgID = 500947U;

		// Token: 0x04002FEE RID: 12270
		public uint Sequence;

		// Token: 0x04002FEF RID: 12271
		public uint code;

		// Token: 0x04002FF0 RID: 12272
		public uint cardId;

		// Token: 0x04002FF1 RID: 12273
		public byte cardLev;
	}
}
