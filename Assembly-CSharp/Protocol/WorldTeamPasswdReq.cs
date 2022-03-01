using System;

namespace Protocol
{
	// Token: 0x02000B83 RID: 2947
	[Protocol]
	public class WorldTeamPasswdReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CF6 RID: 31990 RVA: 0x0016442C File Offset: 0x0016282C
		public uint GetMsgID()
		{
			return 601612U;
		}

		// Token: 0x06007CF7 RID: 31991 RVA: 0x00164433 File Offset: 0x00162833
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CF8 RID: 31992 RVA: 0x0016443B File Offset: 0x0016283B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CF9 RID: 31993 RVA: 0x00164444 File Offset: 0x00162844
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.target);
		}

		// Token: 0x06007CFA RID: 31994 RVA: 0x00164454 File Offset: 0x00162854
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007CFB RID: 31995 RVA: 0x00164464 File Offset: 0x00162864
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.target);
		}

		// Token: 0x06007CFC RID: 31996 RVA: 0x00164474 File Offset: 0x00162874
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007CFD RID: 31997 RVA: 0x00164484 File Offset: 0x00162884
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003B44 RID: 15172
		public const uint MsgID = 601612U;

		// Token: 0x04003B45 RID: 15173
		public uint Sequence;

		// Token: 0x04003B46 RID: 15174
		public ulong target;
	}
}
