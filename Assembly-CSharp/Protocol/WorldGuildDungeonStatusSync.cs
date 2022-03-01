using System;

namespace Protocol
{
	// Token: 0x0200088D RID: 2189
	[Protocol]
	public class WorldGuildDungeonStatusSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006655 RID: 26197 RVA: 0x0012F751 File Offset: 0x0012DB51
		public uint GetMsgID()
		{
			return 608509U;
		}

		// Token: 0x06006656 RID: 26198 RVA: 0x0012F758 File Offset: 0x0012DB58
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006657 RID: 26199 RVA: 0x0012F760 File Offset: 0x0012DB60
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006658 RID: 26200 RVA: 0x0012F769 File Offset: 0x0012DB69
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonStatus);
		}

		// Token: 0x06006659 RID: 26201 RVA: 0x0012F779 File Offset: 0x0012DB79
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonStatus);
		}

		// Token: 0x0600665A RID: 26202 RVA: 0x0012F789 File Offset: 0x0012DB89
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonStatus);
		}

		// Token: 0x0600665B RID: 26203 RVA: 0x0012F799 File Offset: 0x0012DB99
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonStatus);
		}

		// Token: 0x0600665C RID: 26204 RVA: 0x0012F7AC File Offset: 0x0012DBAC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DC8 RID: 11720
		public const uint MsgID = 608509U;

		// Token: 0x04002DC9 RID: 11721
		public uint Sequence;

		// Token: 0x04002DCA RID: 11722
		public uint dungeonStatus;
	}
}
