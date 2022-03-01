using System;

namespace Protocol
{
	// Token: 0x02000A00 RID: 2560
	[Protocol]
	public class SceneWudaoJoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071C8 RID: 29128 RVA: 0x0014A920 File Offset: 0x00148D20
		public uint GetMsgID()
		{
			return 506706U;
		}

		// Token: 0x060071C9 RID: 29129 RVA: 0x0014A927 File Offset: 0x00148D27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071CA RID: 29130 RVA: 0x0014A92F File Offset: 0x00148D2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071CB RID: 29131 RVA: 0x0014A938 File Offset: 0x00148D38
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071CC RID: 29132 RVA: 0x0014A93A File Offset: 0x00148D3A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071CD RID: 29133 RVA: 0x0014A93C File Offset: 0x00148D3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071CE RID: 29134 RVA: 0x0014A93E File Offset: 0x00148D3E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071CF RID: 29135 RVA: 0x0014A940 File Offset: 0x00148D40
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003454 RID: 13396
		public const uint MsgID = 506706U;

		// Token: 0x04003455 RID: 13397
		public uint Sequence;
	}
}
