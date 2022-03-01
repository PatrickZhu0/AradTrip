using System;

namespace Protocol
{
	// Token: 0x0200074B RID: 1867
	[Protocol]
	public class SceneChampionReliveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CD1 RID: 23761 RVA: 0x00117874 File Offset: 0x00115C74
		public uint GetMsgID()
		{
			return 509806U;
		}

		// Token: 0x06005CD2 RID: 23762 RVA: 0x0011787B File Offset: 0x00115C7B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CD3 RID: 23763 RVA: 0x00117883 File Offset: 0x00115C83
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CD4 RID: 23764 RVA: 0x0011788C File Offset: 0x00115C8C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CD5 RID: 23765 RVA: 0x0011788E File Offset: 0x00115C8E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CD6 RID: 23766 RVA: 0x00117890 File Offset: 0x00115C90
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CD7 RID: 23767 RVA: 0x00117892 File Offset: 0x00115C92
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CD8 RID: 23768 RVA: 0x00117894 File Offset: 0x00115C94
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002607 RID: 9735
		public const uint MsgID = 509806U;

		// Token: 0x04002608 RID: 9736
		public uint Sequence;
	}
}
