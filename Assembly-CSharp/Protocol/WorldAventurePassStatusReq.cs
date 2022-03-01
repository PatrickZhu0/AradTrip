using System;

namespace Protocol
{
	// Token: 0x02000C21 RID: 3105
	[Protocol]
	public class WorldAventurePassStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081A9 RID: 33193 RVA: 0x0016DD4C File Offset: 0x0016C14C
		public uint GetMsgID()
		{
			return 609501U;
		}

		// Token: 0x060081AA RID: 33194 RVA: 0x0016DD53 File Offset: 0x0016C153
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081AB RID: 33195 RVA: 0x0016DD5B File Offset: 0x0016C15B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081AC RID: 33196 RVA: 0x0016DD64 File Offset: 0x0016C164
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060081AD RID: 33197 RVA: 0x0016DD66 File Offset: 0x0016C166
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060081AE RID: 33198 RVA: 0x0016DD68 File Offset: 0x0016C168
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060081AF RID: 33199 RVA: 0x0016DD6A File Offset: 0x0016C16A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060081B0 RID: 33200 RVA: 0x0016DD6C File Offset: 0x0016C16C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003DE0 RID: 15840
		public const uint MsgID = 609501U;

		// Token: 0x04003DE1 RID: 15841
		public uint Sequence;
	}
}
