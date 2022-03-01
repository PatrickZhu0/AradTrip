using System;

namespace Protocol
{
	// Token: 0x02000B26 RID: 2854
	[Protocol]
	public class WorldSecurityLockOpRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A4A RID: 31306 RVA: 0x0015F338 File Offset: 0x0015D738
		public uint GetMsgID()
		{
			return 608405U;
		}

		// Token: 0x06007A4B RID: 31307 RVA: 0x0015F33F File Offset: 0x0015D73F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A4C RID: 31308 RVA: 0x0015F347 File Offset: 0x0015D747
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A4D RID: 31309 RVA: 0x0015F350 File Offset: 0x0015D750
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockOpType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.freezeTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unFreezeTime);
		}

		// Token: 0x06007A4E RID: 31310 RVA: 0x0015F3A4 File Offset: 0x0015D7A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockOpType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.freezeTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unFreezeTime);
		}

		// Token: 0x06007A4F RID: 31311 RVA: 0x0015F3F8 File Offset: 0x0015D7F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockOpType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.freezeTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unFreezeTime);
		}

		// Token: 0x06007A50 RID: 31312 RVA: 0x0015F44C File Offset: 0x0015D84C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockOpType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.freezeTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unFreezeTime);
		}

		// Token: 0x06007A51 RID: 31313 RVA: 0x0015F4A0 File Offset: 0x0015D8A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040039B9 RID: 14777
		public const uint MsgID = 608405U;

		// Token: 0x040039BA RID: 14778
		public uint Sequence;

		// Token: 0x040039BB RID: 14779
		public uint ret;

		// Token: 0x040039BC RID: 14780
		public uint lockOpType;

		// Token: 0x040039BD RID: 14781
		public uint lockState;

		// Token: 0x040039BE RID: 14782
		public uint freezeTime;

		// Token: 0x040039BF RID: 14783
		public uint unFreezeTime;
	}
}
