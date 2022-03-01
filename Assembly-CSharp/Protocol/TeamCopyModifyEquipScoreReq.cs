using System;

namespace Protocol
{
	// Token: 0x02000C07 RID: 3079
	[Protocol]
	public class TeamCopyModifyEquipScoreReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080DA RID: 32986 RVA: 0x0016C1D8 File Offset: 0x0016A5D8
		public uint GetMsgID()
		{
			return 1100076U;
		}

		// Token: 0x060080DB RID: 32987 RVA: 0x0016C1DF File Offset: 0x0016A5DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080DC RID: 32988 RVA: 0x0016C1E7 File Offset: 0x0016A5E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080DD RID: 32989 RVA: 0x0016C1F0 File Offset: 0x0016A5F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
		}

		// Token: 0x060080DE RID: 32990 RVA: 0x0016C200 File Offset: 0x0016A600
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
		}

		// Token: 0x060080DF RID: 32991 RVA: 0x0016C210 File Offset: 0x0016A610
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
		}

		// Token: 0x060080E0 RID: 32992 RVA: 0x0016C220 File Offset: 0x0016A620
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
		}

		// Token: 0x060080E1 RID: 32993 RVA: 0x0016C230 File Offset: 0x0016A630
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D7D RID: 15741
		public const uint MsgID = 1100076U;

		// Token: 0x04003D7E RID: 15742
		public uint Sequence;

		// Token: 0x04003D7F RID: 15743
		public uint equipScore;
	}
}
