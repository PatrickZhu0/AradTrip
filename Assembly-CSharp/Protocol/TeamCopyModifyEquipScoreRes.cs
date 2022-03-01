using System;

namespace Protocol
{
	// Token: 0x02000C08 RID: 3080
	[Protocol]
	public class TeamCopyModifyEquipScoreRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080E3 RID: 32995 RVA: 0x0016C24C File Offset: 0x0016A64C
		public uint GetMsgID()
		{
			return 1100077U;
		}

		// Token: 0x060080E4 RID: 32996 RVA: 0x0016C253 File Offset: 0x0016A653
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080E5 RID: 32997 RVA: 0x0016C25B File Offset: 0x0016A65B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080E6 RID: 32998 RVA: 0x0016C264 File Offset: 0x0016A664
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060080E7 RID: 32999 RVA: 0x0016C274 File Offset: 0x0016A674
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060080E8 RID: 33000 RVA: 0x0016C284 File Offset: 0x0016A684
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060080E9 RID: 33001 RVA: 0x0016C294 File Offset: 0x0016A694
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060080EA RID: 33002 RVA: 0x0016C2A4 File Offset: 0x0016A6A4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D80 RID: 15744
		public const uint MsgID = 1100077U;

		// Token: 0x04003D81 RID: 15745
		public uint Sequence;

		// Token: 0x04003D82 RID: 15746
		public uint retCode;
	}
}
