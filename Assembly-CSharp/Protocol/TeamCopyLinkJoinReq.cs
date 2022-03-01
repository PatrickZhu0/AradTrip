using System;

namespace Protocol
{
	// Token: 0x02000BF9 RID: 3065
	[Protocol]
	public class TeamCopyLinkJoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600805C RID: 32860 RVA: 0x0016B830 File Offset: 0x00169C30
		public uint GetMsgID()
		{
			return 1100062U;
		}

		// Token: 0x0600805D RID: 32861 RVA: 0x0016B837 File Offset: 0x00169C37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600805E RID: 32862 RVA: 0x0016B83F File Offset: 0x00169C3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600805F RID: 32863 RVA: 0x0016B848 File Offset: 0x00169C48
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
		}

		// Token: 0x06008060 RID: 32864 RVA: 0x0016B866 File Offset: 0x00169C66
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
		}

		// Token: 0x06008061 RID: 32865 RVA: 0x0016B884 File Offset: 0x00169C84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
		}

		// Token: 0x06008062 RID: 32866 RVA: 0x0016B8A2 File Offset: 0x00169CA2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
		}

		// Token: 0x06008063 RID: 32867 RVA: 0x0016B8C0 File Offset: 0x00169CC0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D49 RID: 15689
		public const uint MsgID = 1100062U;

		// Token: 0x04003D4A RID: 15690
		public uint Sequence;

		// Token: 0x04003D4B RID: 15691
		public uint teamId;

		// Token: 0x04003D4C RID: 15692
		public uint isGold;
	}
}
