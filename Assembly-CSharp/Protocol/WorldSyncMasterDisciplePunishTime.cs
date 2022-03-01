using System;

namespace Protocol
{
	// Token: 0x02000CB7 RID: 3255
	[Protocol]
	public class WorldSyncMasterDisciplePunishTime : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008626 RID: 34342 RVA: 0x001773D0 File Offset: 0x001757D0
		public uint GetMsgID()
		{
			return 601751U;
		}

		// Token: 0x06008627 RID: 34343 RVA: 0x001773D7 File Offset: 0x001757D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008628 RID: 34344 RVA: 0x001773DF File Offset: 0x001757DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008629 RID: 34345 RVA: 0x001773E8 File Offset: 0x001757E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.apprenticMasterPunishTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.recruitDisciplePunishTime);
		}

		// Token: 0x0600862A RID: 34346 RVA: 0x00177406 File Offset: 0x00175806
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.apprenticMasterPunishTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.recruitDisciplePunishTime);
		}

		// Token: 0x0600862B RID: 34347 RVA: 0x00177424 File Offset: 0x00175824
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.apprenticMasterPunishTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.recruitDisciplePunishTime);
		}

		// Token: 0x0600862C RID: 34348 RVA: 0x00177442 File Offset: 0x00175842
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.apprenticMasterPunishTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.recruitDisciplePunishTime);
		}

		// Token: 0x0600862D RID: 34349 RVA: 0x00177460 File Offset: 0x00175860
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04004037 RID: 16439
		public const uint MsgID = 601751U;

		// Token: 0x04004038 RID: 16440
		public uint Sequence;

		// Token: 0x04004039 RID: 16441
		public ulong apprenticMasterPunishTime;

		// Token: 0x0400403A RID: 16442
		public ulong recruitDisciplePunishTime;
	}
}
