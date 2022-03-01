using System;

namespace Protocol
{
	// Token: 0x0200082B RID: 2091
	[Protocol]
	public class WorldGuildLeaveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060062F5 RID: 25333 RVA: 0x00129D08 File Offset: 0x00128108
		public uint GetMsgID()
		{
			return 601903U;
		}

		// Token: 0x060062F6 RID: 25334 RVA: 0x00129D0F File Offset: 0x0012810F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060062F7 RID: 25335 RVA: 0x00129D17 File Offset: 0x00128117
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060062F8 RID: 25336 RVA: 0x00129D20 File Offset: 0x00128120
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060062F9 RID: 25337 RVA: 0x00129D22 File Offset: 0x00128122
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060062FA RID: 25338 RVA: 0x00129D24 File Offset: 0x00128124
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060062FB RID: 25339 RVA: 0x00129D26 File Offset: 0x00128126
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060062FC RID: 25340 RVA: 0x00129D28 File Offset: 0x00128128
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002C7A RID: 11386
		public const uint MsgID = 601903U;

		// Token: 0x04002C7B RID: 11387
		public uint Sequence;
	}
}
