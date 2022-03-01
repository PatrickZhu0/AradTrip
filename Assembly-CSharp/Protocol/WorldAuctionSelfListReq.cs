using System;

namespace Protocol
{
	// Token: 0x020006C1 RID: 1729
	[Protocol]
	public class WorldAuctionSelfListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005878 RID: 22648 RVA: 0x0010DBFD File Offset: 0x0010BFFD
		public uint GetMsgID()
		{
			return 603904U;
		}

		// Token: 0x06005879 RID: 22649 RVA: 0x0010DC04 File Offset: 0x0010C004
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600587A RID: 22650 RVA: 0x0010DC0C File Offset: 0x0010C00C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600587B RID: 22651 RVA: 0x0010DC15 File Offset: 0x0010C015
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600587C RID: 22652 RVA: 0x0010DC25 File Offset: 0x0010C025
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600587D RID: 22653 RVA: 0x0010DC35 File Offset: 0x0010C035
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600587E RID: 22654 RVA: 0x0010DC45 File Offset: 0x0010C045
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600587F RID: 22655 RVA: 0x0010DC58 File Offset: 0x0010C058
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x0400237B RID: 9083
		public const uint MsgID = 603904U;

		// Token: 0x0400237C RID: 9084
		public uint Sequence;

		// Token: 0x0400237D RID: 9085
		public byte type;
	}
}
