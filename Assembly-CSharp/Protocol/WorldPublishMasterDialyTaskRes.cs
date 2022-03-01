using System;

namespace Protocol
{
	// Token: 0x02000C6E RID: 3182
	[Protocol]
	public class WorldPublishMasterDialyTaskRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083E9 RID: 33769 RVA: 0x00172250 File Offset: 0x00170650
		public uint GetMsgID()
		{
			return 601753U;
		}

		// Token: 0x060083EA RID: 33770 RVA: 0x00172257 File Offset: 0x00170657
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083EB RID: 33771 RVA: 0x0017225F File Offset: 0x0017065F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083EC RID: 33772 RVA: 0x00172268 File Offset: 0x00170668
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083ED RID: 33773 RVA: 0x00172286 File Offset: 0x00170686
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083EE RID: 33774 RVA: 0x001722A4 File Offset: 0x001706A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
		}

		// Token: 0x060083EF RID: 33775 RVA: 0x001722C2 File Offset: 0x001706C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
		}

		// Token: 0x060083F0 RID: 33776 RVA: 0x001722E0 File Offset: 0x001706E0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003F03 RID: 16131
		public const uint MsgID = 601753U;

		// Token: 0x04003F04 RID: 16132
		public uint Sequence;

		// Token: 0x04003F05 RID: 16133
		public uint code;

		// Token: 0x04003F06 RID: 16134
		public ulong discipleId;
	}
}
