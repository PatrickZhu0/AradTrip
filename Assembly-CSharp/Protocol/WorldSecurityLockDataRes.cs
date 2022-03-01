using System;

namespace Protocol
{
	// Token: 0x02000B24 RID: 2852
	[Protocol]
	public class WorldSecurityLockDataRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A38 RID: 31288 RVA: 0x0015F030 File Offset: 0x0015D430
		public uint GetMsgID()
		{
			return 608403U;
		}

		// Token: 0x06007A39 RID: 31289 RVA: 0x0015F037 File Offset: 0x0015D437
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A3A RID: 31290 RVA: 0x0015F03F File Offset: 0x0015D43F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A3B RID: 31291 RVA: 0x0015F048 File Offset: 0x0015D448
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isCommonDev);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isUseLock);
			BaseDLL.encode_uint32(buffer, ref pos_, this.freezeTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unFreezeTime);
		}

		// Token: 0x06007A3C RID: 31292 RVA: 0x0015F09C File Offset: 0x0015D49C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isCommonDev);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isUseLock);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.freezeTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unFreezeTime);
		}

		// Token: 0x06007A3D RID: 31293 RVA: 0x0015F0F0 File Offset: 0x0015D4F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lockState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isCommonDev);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isUseLock);
			BaseDLL.encode_uint32(buffer, ref pos_, this.freezeTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unFreezeTime);
		}

		// Token: 0x06007A3E RID: 31294 RVA: 0x0015F144 File Offset: 0x0015D544
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lockState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isCommonDev);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isUseLock);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.freezeTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unFreezeTime);
		}

		// Token: 0x06007A3F RID: 31295 RVA: 0x0015F198 File Offset: 0x0015D598
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040039AE RID: 14766
		public const uint MsgID = 608403U;

		// Token: 0x040039AF RID: 14767
		public uint Sequence;

		// Token: 0x040039B0 RID: 14768
		public uint lockState;

		// Token: 0x040039B1 RID: 14769
		public uint isCommonDev;

		// Token: 0x040039B2 RID: 14770
		public uint isUseLock;

		// Token: 0x040039B3 RID: 14771
		public uint freezeTime;

		// Token: 0x040039B4 RID: 14772
		public uint unFreezeTime;
	}
}
