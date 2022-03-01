using System;

namespace Protocol
{
	// Token: 0x02000849 RID: 2121
	[Protocol]
	public class WorldGuildCancelDismissReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006403 RID: 25603 RVA: 0x0012B48C File Offset: 0x0012988C
		public uint GetMsgID()
		{
			return 601933U;
		}

		// Token: 0x06006404 RID: 25604 RVA: 0x0012B493 File Offset: 0x00129893
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006405 RID: 25605 RVA: 0x0012B49B File Offset: 0x0012989B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006406 RID: 25606 RVA: 0x0012B4A4 File Offset: 0x001298A4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006407 RID: 25607 RVA: 0x0012B4A6 File Offset: 0x001298A6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006408 RID: 25608 RVA: 0x0012B4A8 File Offset: 0x001298A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006409 RID: 25609 RVA: 0x0012B4AA File Offset: 0x001298AA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600640A RID: 25610 RVA: 0x0012B4AC File Offset: 0x001298AC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CDB RID: 11483
		public const uint MsgID = 601933U;

		// Token: 0x04002CDC RID: 11484
		public uint Sequence;
	}
}
