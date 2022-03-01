using System;

namespace Protocol
{
	// Token: 0x020006D4 RID: 1748
	[Protocol]
	public class SceneAbnormalTransactionRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005923 RID: 22819 RVA: 0x0010EF50 File Offset: 0x0010D350
		public uint GetMsgID()
		{
			return 503906U;
		}

		// Token: 0x06005924 RID: 22820 RVA: 0x0010EF57 File Offset: 0x0010D357
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005925 RID: 22821 RVA: 0x0010EF5F File Offset: 0x0010D35F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005926 RID: 22822 RVA: 0x0010EF68 File Offset: 0x0010D368
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005927 RID: 22823 RVA: 0x0010EF6A File Offset: 0x0010D36A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005928 RID: 22824 RVA: 0x0010EF6C File Offset: 0x0010D36C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005929 RID: 22825 RVA: 0x0010EF6E File Offset: 0x0010D36E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600592A RID: 22826 RVA: 0x0010EF70 File Offset: 0x0010D370
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040023D0 RID: 9168
		public const uint MsgID = 503906U;

		// Token: 0x040023D1 RID: 9169
		public uint Sequence;
	}
}
