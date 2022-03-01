using System;

namespace Protocol
{
	// Token: 0x02000724 RID: 1828
	[Protocol]
	public class SceneBattleNoWarNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BB4 RID: 23476 RVA: 0x001158B4 File Offset: 0x00113CB4
		public uint GetMsgID()
		{
			return 508945U;
		}

		// Token: 0x06005BB5 RID: 23477 RVA: 0x001158BB File Offset: 0x00113CBB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BB6 RID: 23478 RVA: 0x001158C3 File Offset: 0x00113CC3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BB7 RID: 23479 RVA: 0x001158CC File Offset: 0x00113CCC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BB8 RID: 23480 RVA: 0x001158CE File Offset: 0x00113CCE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BB9 RID: 23481 RVA: 0x001158D0 File Offset: 0x00113CD0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BBA RID: 23482 RVA: 0x001158D2 File Offset: 0x00113CD2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BBB RID: 23483 RVA: 0x001158D4 File Offset: 0x00113CD4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002562 RID: 9570
		public const uint MsgID = 508945U;

		// Token: 0x04002563 RID: 9571
		public uint Sequence;
	}
}
