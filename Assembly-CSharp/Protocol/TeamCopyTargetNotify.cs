using System;

namespace Protocol
{
	// Token: 0x02000BD0 RID: 3024
	[Protocol]
	public class TeamCopyTargetNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EF4 RID: 32500 RVA: 0x0016885B File Offset: 0x00166C5B
		public uint GetMsgID()
		{
			return 1100021U;
		}

		// Token: 0x06007EF5 RID: 32501 RVA: 0x00168862 File Offset: 0x00166C62
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EF6 RID: 32502 RVA: 0x0016886A File Offset: 0x00166C6A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EF7 RID: 32503 RVA: 0x00168873 File Offset: 0x00166C73
		public void encode(byte[] buffer, ref int pos_)
		{
			this.squadTarget.encode(buffer, ref pos_);
			this.teamTarget.encode(buffer, ref pos_);
		}

		// Token: 0x06007EF8 RID: 32504 RVA: 0x0016888F File Offset: 0x00166C8F
		public void decode(byte[] buffer, ref int pos_)
		{
			this.squadTarget.decode(buffer, ref pos_);
			this.teamTarget.decode(buffer, ref pos_);
		}

		// Token: 0x06007EF9 RID: 32505 RVA: 0x001688AB File Offset: 0x00166CAB
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.squadTarget.encode(buffer, ref pos_);
			this.teamTarget.encode(buffer, ref pos_);
		}

		// Token: 0x06007EFA RID: 32506 RVA: 0x001688C7 File Offset: 0x00166CC7
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.squadTarget.decode(buffer, ref pos_);
			this.teamTarget.decode(buffer, ref pos_);
		}

		// Token: 0x06007EFB RID: 32507 RVA: 0x001688E4 File Offset: 0x00166CE4
		public int getLen()
		{
			int num = 0;
			num += this.squadTarget.getLen();
			return num + this.teamTarget.getLen();
		}

		// Token: 0x04003C9F RID: 15519
		public const uint MsgID = 1100021U;

		// Token: 0x04003CA0 RID: 15520
		public uint Sequence;

		// Token: 0x04003CA1 RID: 15521
		public TeamCopyTarget squadTarget = new TeamCopyTarget();

		// Token: 0x04003CA2 RID: 15522
		public TeamCopyTarget teamTarget = new TeamCopyTarget();
	}
}
