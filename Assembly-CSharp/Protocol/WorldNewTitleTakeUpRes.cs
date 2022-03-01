using System;

namespace Protocol
{
	// Token: 0x02000A1F RID: 2591
	[Protocol]
	public class WorldNewTitleTakeUpRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072CA RID: 29386 RVA: 0x0014C33C File Offset: 0x0014A73C
		public uint GetMsgID()
		{
			return 609203U;
		}

		// Token: 0x060072CB RID: 29387 RVA: 0x0014C343 File Offset: 0x0014A743
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072CC RID: 29388 RVA: 0x0014C34B File Offset: 0x0014A74B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072CD RID: 29389 RVA: 0x0014C354 File Offset: 0x0014A754
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
		}

		// Token: 0x060072CE RID: 29390 RVA: 0x0014C372 File Offset: 0x0014A772
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
		}

		// Token: 0x060072CF RID: 29391 RVA: 0x0014C390 File Offset: 0x0014A790
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
		}

		// Token: 0x060072D0 RID: 29392 RVA: 0x0014C3AE File Offset: 0x0014A7AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
		}

		// Token: 0x060072D1 RID: 29393 RVA: 0x0014C3CC File Offset: 0x0014A7CC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040034C0 RID: 13504
		public const uint MsgID = 609203U;

		// Token: 0x040034C1 RID: 13505
		public uint Sequence;

		// Token: 0x040034C2 RID: 13506
		public uint res;

		// Token: 0x040034C3 RID: 13507
		public ulong titleGuid;
	}
}
