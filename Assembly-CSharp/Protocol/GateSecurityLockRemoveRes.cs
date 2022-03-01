using System;

namespace Protocol
{
	// Token: 0x02000B2E RID: 2862
	[Protocol]
	public class GateSecurityLockRemoveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A92 RID: 31378 RVA: 0x0015FCE4 File Offset: 0x0015E0E4
		public uint GetMsgID()
		{
			return 308402U;
		}

		// Token: 0x06007A93 RID: 31379 RVA: 0x0015FCEB File Offset: 0x0015E0EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A94 RID: 31380 RVA: 0x0015FCF3 File Offset: 0x0015E0F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A95 RID: 31381 RVA: 0x0015FCFC File Offset: 0x0015E0FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06007A96 RID: 31382 RVA: 0x0015FD0C File Offset: 0x0015E10C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06007A97 RID: 31383 RVA: 0x0015FD1C File Offset: 0x0015E11C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06007A98 RID: 31384 RVA: 0x0015FD2C File Offset: 0x0015E12C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06007A99 RID: 31385 RVA: 0x0015FD3C File Offset: 0x0015E13C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040039DA RID: 14810
		public const uint MsgID = 308402U;

		// Token: 0x040039DB RID: 14811
		public uint Sequence;

		// Token: 0x040039DC RID: 14812
		public uint ret;
	}
}
