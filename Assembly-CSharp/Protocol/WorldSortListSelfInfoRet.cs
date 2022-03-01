using System;

namespace Protocol
{
	// Token: 0x02000B6C RID: 2924
	[Protocol]
	public class WorldSortListSelfInfoRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C6F RID: 31855 RVA: 0x001633B8 File Offset: 0x001617B8
		public uint GetMsgID()
		{
			return 602611U;
		}

		// Token: 0x06007C70 RID: 31856 RVA: 0x001633BF File Offset: 0x001617BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C71 RID: 31857 RVA: 0x001633C7 File Offset: 0x001617C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C72 RID: 31858 RVA: 0x001633D0 File Offset: 0x001617D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
		}

		// Token: 0x06007C73 RID: 31859 RVA: 0x001633E0 File Offset: 0x001617E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
		}

		// Token: 0x06007C74 RID: 31860 RVA: 0x001633F0 File Offset: 0x001617F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
		}

		// Token: 0x06007C75 RID: 31861 RVA: 0x00163400 File Offset: 0x00161800
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
		}

		// Token: 0x06007C76 RID: 31862 RVA: 0x00163410 File Offset: 0x00161810
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AED RID: 15085
		public const uint MsgID = 602611U;

		// Token: 0x04003AEE RID: 15086
		public uint Sequence;

		// Token: 0x04003AEF RID: 15087
		public uint ranking;
	}
}
