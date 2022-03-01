using System;

namespace Protocol
{
	// Token: 0x02000CA5 RID: 3237
	[Protocol]
	public class AddonPaySwitchReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008584 RID: 34180 RVA: 0x0017681C File Offset: 0x00174C1C
		public uint GetMsgID()
		{
			return 501713U;
		}

		// Token: 0x06008585 RID: 34181 RVA: 0x00176823 File Offset: 0x00174C23
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008586 RID: 34182 RVA: 0x0017682B File Offset: 0x00174C2B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008587 RID: 34183 RVA: 0x00176834 File Offset: 0x00174C34
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008588 RID: 34184 RVA: 0x00176836 File Offset: 0x00174C36
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008589 RID: 34185 RVA: 0x00176838 File Offset: 0x00174C38
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600858A RID: 34186 RVA: 0x0017683A File Offset: 0x00174C3A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600858B RID: 34187 RVA: 0x0017683C File Offset: 0x00174C3C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003FFF RID: 16383
		public const uint MsgID = 501713U;

		// Token: 0x04004000 RID: 16384
		public uint Sequence;
	}
}
