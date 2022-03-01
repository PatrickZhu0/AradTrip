using System;

namespace Protocol
{
	// Token: 0x02000A57 RID: 2647
	[Protocol]
	public class SceneSellPetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007465 RID: 29797 RVA: 0x001514FC File Offset: 0x0014F8FC
		public uint GetMsgID()
		{
			return 502210U;
		}

		// Token: 0x06007466 RID: 29798 RVA: 0x00151503 File Offset: 0x0014F903
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007467 RID: 29799 RVA: 0x0015150B File Offset: 0x0014F90B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007468 RID: 29800 RVA: 0x00151514 File Offset: 0x0014F914
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007469 RID: 29801 RVA: 0x00151524 File Offset: 0x0014F924
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600746A RID: 29802 RVA: 0x00151534 File Offset: 0x0014F934
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600746B RID: 29803 RVA: 0x00151544 File Offset: 0x0014F944
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600746C RID: 29804 RVA: 0x00151554 File Offset: 0x0014F954
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400360D RID: 13837
		public const uint MsgID = 502210U;

		// Token: 0x0400360E RID: 13838
		public uint Sequence;

		// Token: 0x0400360F RID: 13839
		public uint result;
	}
}
