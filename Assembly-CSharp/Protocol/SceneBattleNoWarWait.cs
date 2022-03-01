using System;

namespace Protocol
{
	// Token: 0x02000725 RID: 1829
	[Protocol]
	public class SceneBattleNoWarWait : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BBD RID: 23485 RVA: 0x001158EC File Offset: 0x00113CEC
		public uint GetMsgID()
		{
			return 508946U;
		}

		// Token: 0x06005BBE RID: 23486 RVA: 0x001158F3 File Offset: 0x00113CF3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BBF RID: 23487 RVA: 0x001158FB File Offset: 0x00113CFB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BC0 RID: 23488 RVA: 0x00115904 File Offset: 0x00113D04
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BC1 RID: 23489 RVA: 0x00115906 File Offset: 0x00113D06
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BC2 RID: 23490 RVA: 0x00115908 File Offset: 0x00113D08
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BC3 RID: 23491 RVA: 0x0011590A File Offset: 0x00113D0A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BC4 RID: 23492 RVA: 0x0011590C File Offset: 0x00113D0C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002564 RID: 9572
		public const uint MsgID = 508946U;

		// Token: 0x04002565 RID: 9573
		public uint Sequence;
	}
}
