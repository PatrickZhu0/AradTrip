using System;

namespace Protocol
{
	// Token: 0x020009D2 RID: 2514
	[Protocol]
	public class GateConvertAccountReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600708A RID: 28810 RVA: 0x00145759 File Offset: 0x00143B59
		public uint GetMsgID()
		{
			return 300322U;
		}

		// Token: 0x0600708B RID: 28811 RVA: 0x00145760 File Offset: 0x00143B60
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600708C RID: 28812 RVA: 0x00145768 File Offset: 0x00143B68
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600708D RID: 28813 RVA: 0x00145771 File Offset: 0x00143B71
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600708E RID: 28814 RVA: 0x00145773 File Offset: 0x00143B73
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600708F RID: 28815 RVA: 0x00145775 File Offset: 0x00143B75
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007090 RID: 28816 RVA: 0x00145777 File Offset: 0x00143B77
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007091 RID: 28817 RVA: 0x0014577C File Offset: 0x00143B7C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003343 RID: 13123
		public const uint MsgID = 300322U;

		// Token: 0x04003344 RID: 13124
		public uint Sequence;
	}
}
