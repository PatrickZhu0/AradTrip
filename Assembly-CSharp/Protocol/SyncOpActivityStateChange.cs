using System;

namespace Protocol
{
	// Token: 0x02000A37 RID: 2615
	[Protocol]
	public class SyncOpActivityStateChange : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007354 RID: 29524 RVA: 0x0014F108 File Offset: 0x0014D508
		public uint GetMsgID()
		{
			return 501149U;
		}

		// Token: 0x06007355 RID: 29525 RVA: 0x0014F10F File Offset: 0x0014D50F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007356 RID: 29526 RVA: 0x0014F117 File Offset: 0x0014D517
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007357 RID: 29527 RVA: 0x0014F120 File Offset: 0x0014D520
		public void encode(byte[] buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x06007358 RID: 29528 RVA: 0x0014F12F File Offset: 0x0014D52F
		public void decode(byte[] buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x06007359 RID: 29529 RVA: 0x0014F13E File Offset: 0x0014D53E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x0600735A RID: 29530 RVA: 0x0014F14D File Offset: 0x0014D54D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x0600735B RID: 29531 RVA: 0x0014F15C File Offset: 0x0014D55C
		public int getLen()
		{
			int num = 0;
			return num + this.data.getLen();
		}

		// Token: 0x04003589 RID: 13705
		public const uint MsgID = 501149U;

		// Token: 0x0400358A RID: 13706
		public uint Sequence;

		// Token: 0x0400358B RID: 13707
		public OpActivityData data = new OpActivityData();
	}
}
