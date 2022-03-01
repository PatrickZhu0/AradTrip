using System;

namespace Protocol
{
	// Token: 0x02000781 RID: 1921
	[Protocol]
	public class WorldChatLinkDataRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E87 RID: 24199 RVA: 0x0011B8F0 File Offset: 0x00119CF0
		public uint GetMsgID()
		{
			return 600803U;
		}

		// Token: 0x06005E88 RID: 24200 RVA: 0x0011B8F7 File Offset: 0x00119CF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E89 RID: 24201 RVA: 0x0011B8FF File Offset: 0x00119CFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E8A RID: 24202 RVA: 0x0011B908 File Offset: 0x00119D08
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E8B RID: 24203 RVA: 0x0011B90A File Offset: 0x00119D0A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E8C RID: 24204 RVA: 0x0011B90C File Offset: 0x00119D0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E8D RID: 24205 RVA: 0x0011B90E File Offset: 0x00119D0E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E8E RID: 24206 RVA: 0x0011B910 File Offset: 0x00119D10
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040026E5 RID: 9957
		public const uint MsgID = 600803U;

		// Token: 0x040026E6 RID: 9958
		public uint Sequence;
	}
}
