using System;

namespace Protocol
{
	// Token: 0x02000B2C RID: 2860
	[Protocol]
	public class WorldSecurityLockPasswdErrorNum : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A80 RID: 31360 RVA: 0x0015FB34 File Offset: 0x0015DF34
		public uint GetMsgID()
		{
			return 608411U;
		}

		// Token: 0x06007A81 RID: 31361 RVA: 0x0015FB3B File Offset: 0x0015DF3B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A82 RID: 31362 RVA: 0x0015FB43 File Offset: 0x0015DF43
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A83 RID: 31363 RVA: 0x0015FB4C File Offset: 0x0015DF4C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.error_num);
		}

		// Token: 0x06007A84 RID: 31364 RVA: 0x0015FB5C File Offset: 0x0015DF5C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.error_num);
		}

		// Token: 0x06007A85 RID: 31365 RVA: 0x0015FB6C File Offset: 0x0015DF6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.error_num);
		}

		// Token: 0x06007A86 RID: 31366 RVA: 0x0015FB7C File Offset: 0x0015DF7C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.error_num);
		}

		// Token: 0x06007A87 RID: 31367 RVA: 0x0015FB8C File Offset: 0x0015DF8C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040039D4 RID: 14804
		public const uint MsgID = 608411U;

		// Token: 0x040039D5 RID: 14805
		public uint Sequence;

		// Token: 0x040039D6 RID: 14806
		public uint error_num;
	}
}
