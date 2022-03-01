using System;

namespace Protocol
{
	// Token: 0x020009E1 RID: 2529
	[Protocol]
	public class WorldReadMailReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007102 RID: 28930 RVA: 0x00146795 File Offset: 0x00144B95
		public uint GetMsgID()
		{
			return 601504U;
		}

		// Token: 0x06007103 RID: 28931 RVA: 0x0014679C File Offset: 0x00144B9C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007104 RID: 28932 RVA: 0x001467A4 File Offset: 0x00144BA4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007105 RID: 28933 RVA: 0x001467AD File Offset: 0x00144BAD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007106 RID: 28934 RVA: 0x001467BD File Offset: 0x00144BBD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007107 RID: 28935 RVA: 0x001467CD File Offset: 0x00144BCD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007108 RID: 28936 RVA: 0x001467DD File Offset: 0x00144BDD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007109 RID: 28937 RVA: 0x001467F0 File Offset: 0x00144BF0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400337F RID: 13183
		public const uint MsgID = 601504U;

		// Token: 0x04003380 RID: 13184
		public uint Sequence;

		// Token: 0x04003381 RID: 13185
		public ulong id;
	}
}
