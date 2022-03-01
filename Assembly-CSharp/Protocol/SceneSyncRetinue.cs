using System;

namespace Protocol
{
	// Token: 0x02000AB6 RID: 2742
	[Protocol]
	public class SceneSyncRetinue : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600770B RID: 30475 RVA: 0x001586AF File Offset: 0x00156AAF
		public uint GetMsgID()
		{
			return 507002U;
		}

		// Token: 0x0600770C RID: 30476 RVA: 0x001586B6 File Offset: 0x00156AB6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600770D RID: 30477 RVA: 0x001586BE File Offset: 0x00156ABE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600770E RID: 30478 RVA: 0x001586C7 File Offset: 0x00156AC7
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x0600770F RID: 30479 RVA: 0x001586D6 File Offset: 0x00156AD6
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007710 RID: 30480 RVA: 0x001586E5 File Offset: 0x00156AE5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007711 RID: 30481 RVA: 0x001586F4 File Offset: 0x00156AF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007712 RID: 30482 RVA: 0x00158704 File Offset: 0x00156B04
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x040037C0 RID: 14272
		public const uint MsgID = 507002U;

		// Token: 0x040037C1 RID: 14273
		public uint Sequence;

		// Token: 0x040037C2 RID: 14274
		public RetinueInfo info = new RetinueInfo();
	}
}
