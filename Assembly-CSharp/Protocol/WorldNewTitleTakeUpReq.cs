using System;

namespace Protocol
{
	// Token: 0x02000A1E RID: 2590
	[Protocol]
	public class WorldNewTitleTakeUpReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072C1 RID: 29377 RVA: 0x0014C289 File Offset: 0x0014A689
		public uint GetMsgID()
		{
			return 609202U;
		}

		// Token: 0x060072C2 RID: 29378 RVA: 0x0014C290 File Offset: 0x0014A690
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072C3 RID: 29379 RVA: 0x0014C298 File Offset: 0x0014A698
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072C4 RID: 29380 RVA: 0x0014C2A1 File Offset: 0x0014A6A1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
		}

		// Token: 0x060072C5 RID: 29381 RVA: 0x0014C2BF File Offset: 0x0014A6BF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
		}

		// Token: 0x060072C6 RID: 29382 RVA: 0x0014C2DD File Offset: 0x0014A6DD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
		}

		// Token: 0x060072C7 RID: 29383 RVA: 0x0014C2FB File Offset: 0x0014A6FB
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
		}

		// Token: 0x060072C8 RID: 29384 RVA: 0x0014C31C File Offset: 0x0014A71C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040034BC RID: 13500
		public const uint MsgID = 609202U;

		// Token: 0x040034BD RID: 13501
		public uint Sequence;

		// Token: 0x040034BE RID: 13502
		public ulong titleGuid;

		// Token: 0x040034BF RID: 13503
		public uint titleId;
	}
}
