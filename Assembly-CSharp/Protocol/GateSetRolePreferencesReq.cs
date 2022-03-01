using System;

namespace Protocol
{
	// Token: 0x020009DB RID: 2523
	[Protocol]
	public class GateSetRolePreferencesReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070D8 RID: 28888 RVA: 0x0014602D File Offset: 0x0014442D
		public uint GetMsgID()
		{
			return 300325U;
		}

		// Token: 0x060070D9 RID: 28889 RVA: 0x00146034 File Offset: 0x00144434
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070DA RID: 28890 RVA: 0x0014603C File Offset: 0x0014443C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070DB RID: 28891 RVA: 0x00146045 File Offset: 0x00144445
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.preferencesFlag);
		}

		// Token: 0x060070DC RID: 28892 RVA: 0x00146063 File Offset: 0x00144463
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.preferencesFlag);
		}

		// Token: 0x060070DD RID: 28893 RVA: 0x00146081 File Offset: 0x00144481
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.preferencesFlag);
		}

		// Token: 0x060070DE RID: 28894 RVA: 0x0014609F File Offset: 0x0014449F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.preferencesFlag);
		}

		// Token: 0x060070DF RID: 28895 RVA: 0x001460C0 File Offset: 0x001444C0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003362 RID: 13154
		public const uint MsgID = 300325U;

		// Token: 0x04003363 RID: 13155
		public uint Sequence;

		// Token: 0x04003364 RID: 13156
		public ulong roleId;

		// Token: 0x04003365 RID: 13157
		public byte preferencesFlag;
	}
}
