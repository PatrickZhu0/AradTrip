using System;

namespace Protocol
{
	// Token: 0x02000B4C RID: 2892
	[Protocol]
	public class SceneShortcutKeySetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B70 RID: 31600 RVA: 0x001610DB File Offset: 0x0015F4DB
		public uint GetMsgID()
		{
			return 501229U;
		}

		// Token: 0x06007B71 RID: 31601 RVA: 0x001610E2 File Offset: 0x0015F4E2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B72 RID: 31602 RVA: 0x001610EA File Offset: 0x0015F4EA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B73 RID: 31603 RVA: 0x001610F3 File Offset: 0x0015F4F3
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007B74 RID: 31604 RVA: 0x00161102 File Offset: 0x0015F502
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007B75 RID: 31605 RVA: 0x00161111 File Offset: 0x0015F511
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007B76 RID: 31606 RVA: 0x00161120 File Offset: 0x0015F520
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007B77 RID: 31607 RVA: 0x00161130 File Offset: 0x0015F530
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003A6F RID: 14959
		public const uint MsgID = 501229U;

		// Token: 0x04003A70 RID: 14960
		public uint Sequence;

		// Token: 0x04003A71 RID: 14961
		public ShortcutKeyInfo info = new ShortcutKeyInfo();
	}
}
