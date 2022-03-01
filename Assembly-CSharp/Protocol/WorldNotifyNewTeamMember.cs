using System;

namespace Protocol
{
	// Token: 0x02000B7F RID: 2943
	[Protocol]
	public class WorldNotifyNewTeamMember : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CD2 RID: 31954 RVA: 0x00164218 File Offset: 0x00162618
		public uint GetMsgID()
		{
			return 601602U;
		}

		// Token: 0x06007CD3 RID: 31955 RVA: 0x0016421F File Offset: 0x0016261F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CD4 RID: 31956 RVA: 0x00164227 File Offset: 0x00162627
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CD5 RID: 31957 RVA: 0x00164230 File Offset: 0x00162630
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007CD6 RID: 31958 RVA: 0x0016423F File Offset: 0x0016263F
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007CD7 RID: 31959 RVA: 0x0016424E File Offset: 0x0016264E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007CD8 RID: 31960 RVA: 0x0016425D File Offset: 0x0016265D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007CD9 RID: 31961 RVA: 0x0016426C File Offset: 0x0016266C
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003B37 RID: 15159
		public const uint MsgID = 601602U;

		// Token: 0x04003B38 RID: 15160
		public uint Sequence;

		// Token: 0x04003B39 RID: 15161
		public TeammemberInfo info = new TeammemberInfo();
	}
}
