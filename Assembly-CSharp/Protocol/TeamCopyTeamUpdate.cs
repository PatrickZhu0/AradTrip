using System;

namespace Protocol
{
	// Token: 0x02000BE1 RID: 3041
	[Protocol]
	public class TeamCopyTeamUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F87 RID: 32647 RVA: 0x00169C9C File Offset: 0x0016809C
		public uint GetMsgID()
		{
			return 1100039U;
		}

		// Token: 0x06007F88 RID: 32648 RVA: 0x00169CA3 File Offset: 0x001680A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F89 RID: 32649 RVA: 0x00169CAB File Offset: 0x001680AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F8A RID: 32650 RVA: 0x00169CB4 File Offset: 0x001680B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007F8B RID: 32651 RVA: 0x00169CD2 File Offset: 0x001680D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007F8C RID: 32652 RVA: 0x00169CF0 File Offset: 0x001680F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007F8D RID: 32653 RVA: 0x00169D0E File Offset: 0x0016810E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007F8E RID: 32654 RVA: 0x00169D2C File Offset: 0x0016812C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003CE0 RID: 15584
		public const uint MsgID = 1100039U;

		// Token: 0x04003CE1 RID: 15585
		public uint Sequence;

		// Token: 0x04003CE2 RID: 15586
		public uint opType;

		// Token: 0x04003CE3 RID: 15587
		public uint teamId;
	}
}
