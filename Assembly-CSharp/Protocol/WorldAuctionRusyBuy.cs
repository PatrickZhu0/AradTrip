using System;

namespace Protocol
{
	// Token: 0x020006D9 RID: 1753
	[Protocol]
	public class WorldAuctionRusyBuy : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600594D RID: 22861 RVA: 0x0010F8D6 File Offset: 0x0010DCD6
		public uint GetMsgID()
		{
			return 603926U;
		}

		// Token: 0x0600594E RID: 22862 RVA: 0x0010F8DD File Offset: 0x0010DCDD
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600594F RID: 22863 RVA: 0x0010F8E5 File Offset: 0x0010DCE5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005950 RID: 22864 RVA: 0x0010F8EE File Offset: 0x0010DCEE
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x0010F90C File Offset: 0x0010DD0C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005952 RID: 22866 RVA: 0x0010F92A File Offset: 0x0010DD2A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005953 RID: 22867 RVA: 0x0010F948 File Offset: 0x0010DD48
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005954 RID: 22868 RVA: 0x0010F968 File Offset: 0x0010DD68
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040023F1 RID: 9201
		public const uint MsgID = 603926U;

		// Token: 0x040023F2 RID: 9202
		public uint Sequence;

		// Token: 0x040023F3 RID: 9203
		public ulong id;

		// Token: 0x040023F4 RID: 9204
		public uint num;
	}
}
