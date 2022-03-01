using System;

namespace Protocol
{
	// Token: 0x02000A0E RID: 2574
	[Protocol]
	public class WorldMonopolyRollReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007243 RID: 29251 RVA: 0x0014B49C File Offset: 0x0014989C
		public uint GetMsgID()
		{
			return 610205U;
		}

		// Token: 0x06007244 RID: 29252 RVA: 0x0014B4A3 File Offset: 0x001498A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007245 RID: 29253 RVA: 0x0014B4AB File Offset: 0x001498AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007246 RID: 29254 RVA: 0x0014B4B4 File Offset: 0x001498B4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007247 RID: 29255 RVA: 0x0014B4B6 File Offset: 0x001498B6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007248 RID: 29256 RVA: 0x0014B4B8 File Offset: 0x001498B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007249 RID: 29257 RVA: 0x0014B4BA File Offset: 0x001498BA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600724A RID: 29258 RVA: 0x0014B4BC File Offset: 0x001498BC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003487 RID: 13447
		public const uint MsgID = 610205U;

		// Token: 0x04003488 RID: 13448
		public uint Sequence;
	}
}
