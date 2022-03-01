using System;

namespace Protocol
{
	// Token: 0x02000802 RID: 2050
	[Protocol]
	public class SceneCreditPointRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006259 RID: 25177 RVA: 0x00125DC4 File Offset: 0x001241C4
		public uint GetMsgID()
		{
			return 510104U;
		}

		// Token: 0x0600625A RID: 25178 RVA: 0x00125DCB File Offset: 0x001241CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600625B RID: 25179 RVA: 0x00125DD3 File Offset: 0x001241D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600625C RID: 25180 RVA: 0x00125DDC File Offset: 0x001241DC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600625D RID: 25181 RVA: 0x00125DDE File Offset: 0x001241DE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600625E RID: 25182 RVA: 0x00125DE0 File Offset: 0x001241E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600625F RID: 25183 RVA: 0x00125DE2 File Offset: 0x001241E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006260 RID: 25184 RVA: 0x00125DE4 File Offset: 0x001241E4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002B6D RID: 11117
		public const uint MsgID = 510104U;

		// Token: 0x04002B6E RID: 11118
		public uint Sequence;
	}
}
