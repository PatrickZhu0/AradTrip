using System;

namespace Protocol
{
	// Token: 0x02000C6D RID: 3181
	[Protocol]
	public class WorldPublishMasterDialyTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083E0 RID: 33760 RVA: 0x001721D9 File Offset: 0x001705D9
		public uint GetMsgID()
		{
			return 601752U;
		}

		// Token: 0x060083E1 RID: 33761 RVA: 0x001721E0 File Offset: 0x001705E0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083E2 RID: 33762 RVA: 0x001721E8 File Offset: 0x001705E8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083E3 RID: 33763 RVA: 0x001721F1 File Offset: 0x001705F1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083E4 RID: 33764 RVA: 0x00172201 File Offset: 0x00170601
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083E5 RID: 33765 RVA: 0x00172211 File Offset: 0x00170611
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083E6 RID: 33766 RVA: 0x00172221 File Offset: 0x00170621
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083E7 RID: 33767 RVA: 0x00172234 File Offset: 0x00170634
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003F00 RID: 16128
		public const uint MsgID = 601752U;

		// Token: 0x04003F01 RID: 16129
		public uint Sequence;

		// Token: 0x04003F02 RID: 16130
		public ulong discipleId;
	}
}
