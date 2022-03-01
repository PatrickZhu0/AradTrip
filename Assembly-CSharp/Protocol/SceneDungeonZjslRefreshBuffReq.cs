using System;

namespace Protocol
{
	// Token: 0x020007E9 RID: 2025
	[Protocol]
	public class SceneDungeonZjslRefreshBuffReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600619C RID: 24988 RVA: 0x00124224 File Offset: 0x00122624
		public uint GetMsgID()
		{
			return 506835U;
		}

		// Token: 0x0600619D RID: 24989 RVA: 0x0012422B File Offset: 0x0012262B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600619E RID: 24990 RVA: 0x00124233 File Offset: 0x00122633
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600619F RID: 24991 RVA: 0x0012423C File Offset: 0x0012263C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.useItem);
		}

		// Token: 0x060061A0 RID: 24992 RVA: 0x0012425A File Offset: 0x0012265A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.useItem);
		}

		// Token: 0x060061A1 RID: 24993 RVA: 0x00124278 File Offset: 0x00122678
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.useItem);
		}

		// Token: 0x060061A2 RID: 24994 RVA: 0x00124296 File Offset: 0x00122696
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.useItem);
		}

		// Token: 0x060061A3 RID: 24995 RVA: 0x001242B4 File Offset: 0x001226B4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040028A9 RID: 10409
		public const uint MsgID = 506835U;

		// Token: 0x040028AA RID: 10410
		public uint Sequence;

		// Token: 0x040028AB RID: 10411
		public uint dungeonId;

		// Token: 0x040028AC RID: 10412
		public uint useItem;
	}
}
