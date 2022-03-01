using System;

namespace Protocol
{
	// Token: 0x02000B9C RID: 2972
	[Protocol]
	public class WorldTeamMatchCancelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DD7 RID: 32215 RVA: 0x00165AE1 File Offset: 0x00163EE1
		public uint GetMsgID()
		{
			return 601650U;
		}

		// Token: 0x06007DD8 RID: 32216 RVA: 0x00165AE8 File Offset: 0x00163EE8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DD9 RID: 32217 RVA: 0x00165AF0 File Offset: 0x00163EF0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DDA RID: 32218 RVA: 0x00165AF9 File Offset: 0x00163EF9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007DDB RID: 32219 RVA: 0x00165AFB File Offset: 0x00163EFB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007DDC RID: 32220 RVA: 0x00165AFD File Offset: 0x00163EFD
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007DDD RID: 32221 RVA: 0x00165AFF File Offset: 0x00163EFF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007DDE RID: 32222 RVA: 0x00165B04 File Offset: 0x00163F04
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003BA4 RID: 15268
		public const uint MsgID = 601650U;

		// Token: 0x04003BA5 RID: 15269
		public uint Sequence;
	}
}
