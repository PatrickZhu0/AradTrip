using System;

namespace Protocol
{
	// Token: 0x02000726 RID: 1830
	[Protocol]
	public class SceneBattleOccuListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BC6 RID: 23494 RVA: 0x00115924 File Offset: 0x00113D24
		public uint GetMsgID()
		{
			return 508947U;
		}

		// Token: 0x06005BC7 RID: 23495 RVA: 0x0011592B File Offset: 0x00113D2B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BC8 RID: 23496 RVA: 0x00115933 File Offset: 0x00113D33
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BC9 RID: 23497 RVA: 0x0011593C File Offset: 0x00113D3C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BCA RID: 23498 RVA: 0x0011593E File Offset: 0x00113D3E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005BCB RID: 23499 RVA: 0x00115940 File Offset: 0x00113D40
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BCC RID: 23500 RVA: 0x00115942 File Offset: 0x00113D42
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005BCD RID: 23501 RVA: 0x00115944 File Offset: 0x00113D44
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002566 RID: 9574
		public const uint MsgID = 508947U;

		// Token: 0x04002567 RID: 9575
		public uint Sequence;
	}
}
