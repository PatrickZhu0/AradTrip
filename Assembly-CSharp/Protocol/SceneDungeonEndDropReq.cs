using System;

namespace Protocol
{
	// Token: 0x020007D1 RID: 2001
	[Protocol]
	public class SceneDungeonEndDropReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060C4 RID: 24772 RVA: 0x00122F6C File Offset: 0x0012136C
		public uint GetMsgID()
		{
			return 506823U;
		}

		// Token: 0x060060C5 RID: 24773 RVA: 0x00122F73 File Offset: 0x00121373
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060C6 RID: 24774 RVA: 0x00122F7B File Offset: 0x0012137B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060C7 RID: 24775 RVA: 0x00122F84 File Offset: 0x00121384
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.multi);
		}

		// Token: 0x060060C8 RID: 24776 RVA: 0x00122F94 File Offset: 0x00121394
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multi);
		}

		// Token: 0x060060C9 RID: 24777 RVA: 0x00122FA4 File Offset: 0x001213A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.multi);
		}

		// Token: 0x060060CA RID: 24778 RVA: 0x00122FB4 File Offset: 0x001213B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multi);
		}

		// Token: 0x060060CB RID: 24779 RVA: 0x00122FC4 File Offset: 0x001213C4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x0400285E RID: 10334
		public const uint MsgID = 506823U;

		// Token: 0x0400285F RID: 10335
		public uint Sequence;

		// Token: 0x04002860 RID: 10336
		public byte multi;
	}
}
