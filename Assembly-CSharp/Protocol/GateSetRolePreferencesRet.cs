using System;

namespace Protocol
{
	// Token: 0x020009DC RID: 2524
	[Protocol]
	public class GateSetRolePreferencesRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070E1 RID: 28897 RVA: 0x001460E0 File Offset: 0x001444E0
		public uint GetMsgID()
		{
			return 300326U;
		}

		// Token: 0x060070E2 RID: 28898 RVA: 0x001460E7 File Offset: 0x001444E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070E3 RID: 28899 RVA: 0x001460EF File Offset: 0x001444EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070E4 RID: 28900 RVA: 0x001460F8 File Offset: 0x001444F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPreferencesTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.delPreferencesTime);
		}

		// Token: 0x060070E5 RID: 28901 RVA: 0x00146132 File Offset: 0x00144532
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPreferencesTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.delPreferencesTime);
		}

		// Token: 0x060070E6 RID: 28902 RVA: 0x0014616C File Offset: 0x0014456C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPreferencesTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.delPreferencesTime);
		}

		// Token: 0x060070E7 RID: 28903 RVA: 0x001461A6 File Offset: 0x001445A6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPreferencesTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.delPreferencesTime);
		}

		// Token: 0x060070E8 RID: 28904 RVA: 0x001461E0 File Offset: 0x001445E0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003366 RID: 13158
		public const uint MsgID = 300326U;

		// Token: 0x04003367 RID: 13159
		public uint Sequence;

		// Token: 0x04003368 RID: 13160
		public ulong roleId;

		// Token: 0x04003369 RID: 13161
		public uint result;

		// Token: 0x0400336A RID: 13162
		public uint addPreferencesTime;

		// Token: 0x0400336B RID: 13163
		public uint delPreferencesTime;
	}
}
