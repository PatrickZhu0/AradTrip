using System;

namespace Protocol
{
	// Token: 0x02000678 RID: 1656
	[Protocol]
	public class SceneNewSignIn : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005663 RID: 22115 RVA: 0x0010901F File Offset: 0x0010741F
		public uint GetMsgID()
		{
			return 501161U;
		}

		// Token: 0x06005664 RID: 22116 RVA: 0x00109026 File Offset: 0x00107426
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005665 RID: 22117 RVA: 0x0010902E File Offset: 0x0010742E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005666 RID: 22118 RVA: 0x00109037 File Offset: 0x00107437
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.day);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAll);
		}

		// Token: 0x06005667 RID: 22119 RVA: 0x00109055 File Offset: 0x00107455
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.day);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAll);
		}

		// Token: 0x06005668 RID: 22120 RVA: 0x00109073 File Offset: 0x00107473
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.day);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAll);
		}

		// Token: 0x06005669 RID: 22121 RVA: 0x00109091 File Offset: 0x00107491
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.day);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAll);
		}

		// Token: 0x0600566A RID: 22122 RVA: 0x001090B0 File Offset: 0x001074B0
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002250 RID: 8784
		public const uint MsgID = 501161U;

		// Token: 0x04002251 RID: 8785
		public uint Sequence;

		// Token: 0x04002252 RID: 8786
		public byte day;

		// Token: 0x04002253 RID: 8787
		public byte isAll;
	}
}
