using System;

namespace Protocol
{
	// Token: 0x020009B3 RID: 2483
	[Protocol]
	public class SceneUnlockRoleStorageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F94 RID: 28564 RVA: 0x00142000 File Offset: 0x00140400
		public uint GetMsgID()
		{
			return 501098U;
		}

		// Token: 0x06006F95 RID: 28565 RVA: 0x00142007 File Offset: 0x00140407
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F96 RID: 28566 RVA: 0x0014200F File Offset: 0x0014040F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F97 RID: 28567 RVA: 0x00142018 File Offset: 0x00140418
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F98 RID: 28568 RVA: 0x0014201A File Offset: 0x0014041A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F99 RID: 28569 RVA: 0x0014201C File Offset: 0x0014041C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F9A RID: 28570 RVA: 0x0014201E File Offset: 0x0014041E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F9B RID: 28571 RVA: 0x00142020 File Offset: 0x00140420
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400329F RID: 12959
		public const uint MsgID = 501098U;

		// Token: 0x040032A0 RID: 12960
		public uint Sequence;
	}
}
