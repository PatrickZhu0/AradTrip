using System;

namespace Protocol
{
	// Token: 0x020009C9 RID: 2505
	[Protocol]
	public class GateRecoverRoleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007039 RID: 28729 RVA: 0x00144F88 File Offset: 0x00143388
		public uint GetMsgID()
		{
			return 300305U;
		}

		// Token: 0x0600703A RID: 28730 RVA: 0x00144F8F File Offset: 0x0014338F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600703B RID: 28731 RVA: 0x00144F97 File Offset: 0x00143397
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600703C RID: 28732 RVA: 0x00144FA0 File Offset: 0x001433A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
		}

		// Token: 0x0600703D RID: 28733 RVA: 0x00144FB0 File Offset: 0x001433B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
		}

		// Token: 0x0600703E RID: 28734 RVA: 0x00144FC0 File Offset: 0x001433C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
		}

		// Token: 0x0600703F RID: 28735 RVA: 0x00144FD0 File Offset: 0x001433D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
		}

		// Token: 0x06007040 RID: 28736 RVA: 0x00144FE0 File Offset: 0x001433E0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003324 RID: 13092
		public const uint MsgID = 300305U;

		// Token: 0x04003325 RID: 13093
		public uint Sequence;

		// Token: 0x04003326 RID: 13094
		public ulong roleId;
	}
}
