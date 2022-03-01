using System;

namespace Protocol
{
	// Token: 0x02000CB6 RID: 3254
	[Protocol]
	public class WorldDiscipleFinishSchoolRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600861D RID: 34333 RVA: 0x0017735C File Offset: 0x0017575C
		public uint GetMsgID()
		{
			return 601750U;
		}

		// Token: 0x0600861E RID: 34334 RVA: 0x00177363 File Offset: 0x00175763
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600861F RID: 34335 RVA: 0x0017736B File Offset: 0x0017576B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008620 RID: 34336 RVA: 0x00177374 File Offset: 0x00175774
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008621 RID: 34337 RVA: 0x00177384 File Offset: 0x00175784
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06008622 RID: 34338 RVA: 0x00177394 File Offset: 0x00175794
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008623 RID: 34339 RVA: 0x001773A4 File Offset: 0x001757A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06008624 RID: 34340 RVA: 0x001773B4 File Offset: 0x001757B4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04004034 RID: 16436
		public const uint MsgID = 601750U;

		// Token: 0x04004035 RID: 16437
		public uint Sequence;

		// Token: 0x04004036 RID: 16438
		public uint code;
	}
}
