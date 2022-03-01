using System;

namespace Protocol
{
	// Token: 0x0200074E RID: 1870
	[Protocol]
	public class SceneChampion16TableReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CE9 RID: 23785 RVA: 0x00117C5E File Offset: 0x0011605E
		public uint GetMsgID()
		{
			return 509808U;
		}

		// Token: 0x06005CEA RID: 23786 RVA: 0x00117C65 File Offset: 0x00116065
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CEB RID: 23787 RVA: 0x00117C6D File Offset: 0x0011606D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CEC RID: 23788 RVA: 0x00117C76 File Offset: 0x00116076
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CED RID: 23789 RVA: 0x00117C78 File Offset: 0x00116078
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CEE RID: 23790 RVA: 0x00117C7A File Offset: 0x0011607A
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CEF RID: 23791 RVA: 0x00117C7C File Offset: 0x0011607C
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CF0 RID: 23792 RVA: 0x00117C80 File Offset: 0x00116080
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002613 RID: 9747
		public const uint MsgID = 509808U;

		// Token: 0x04002614 RID: 9748
		public uint Sequence;
	}
}
