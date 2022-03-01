using System;

namespace Protocol
{
	// Token: 0x02000C6F RID: 3183
	[Protocol]
	public class WorldGetDiscipleMasterTasksReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083F2 RID: 33778 RVA: 0x00172300 File Offset: 0x00170700
		public uint GetMsgID()
		{
			return 601756U;
		}

		// Token: 0x060083F3 RID: 33779 RVA: 0x00172307 File Offset: 0x00170707
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083F4 RID: 33780 RVA: 0x0017230F File Offset: 0x0017070F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083F5 RID: 33781 RVA: 0x00172318 File Offset: 0x00170718
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083F6 RID: 33782 RVA: 0x00172328 File Offset: 0x00170728
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083F7 RID: 33783 RVA: 0x00172338 File Offset: 0x00170738
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083F8 RID: 33784 RVA: 0x00172348 File Offset: 0x00170748
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083F9 RID: 33785 RVA: 0x00172358 File Offset: 0x00170758
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003F07 RID: 16135
		public const uint MsgID = 601756U;

		// Token: 0x04003F08 RID: 16136
		public uint Sequence;

		// Token: 0x04003F09 RID: 16137
		public ulong discipleId;
	}
}
