using System;

namespace Protocol
{
	// Token: 0x020009C8 RID: 2504
	[Protocol]
	public class GateReconnectGameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007030 RID: 28720 RVA: 0x00144ED5 File Offset: 0x001432D5
		public uint GetMsgID()
		{
			return 300312U;
		}

		// Token: 0x06007031 RID: 28721 RVA: 0x00144EDC File Offset: 0x001432DC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007032 RID: 28722 RVA: 0x00144EE4 File Offset: 0x001432E4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007033 RID: 28723 RVA: 0x00144EED File Offset: 0x001432ED
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastRecvSequence);
		}

		// Token: 0x06007034 RID: 28724 RVA: 0x00144F0B File Offset: 0x0014330B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastRecvSequence);
		}

		// Token: 0x06007035 RID: 28725 RVA: 0x00144F29 File Offset: 0x00143329
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastRecvSequence);
		}

		// Token: 0x06007036 RID: 28726 RVA: 0x00144F47 File Offset: 0x00143347
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastRecvSequence);
		}

		// Token: 0x06007037 RID: 28727 RVA: 0x00144F68 File Offset: 0x00143368
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003320 RID: 13088
		public const uint MsgID = 300312U;

		// Token: 0x04003321 RID: 13089
		public uint Sequence;

		// Token: 0x04003322 RID: 13090
		public uint result;

		// Token: 0x04003323 RID: 13091
		public uint lastRecvSequence;
	}
}
