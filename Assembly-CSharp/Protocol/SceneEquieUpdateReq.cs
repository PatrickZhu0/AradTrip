using System;

namespace Protocol
{
	// Token: 0x02000979 RID: 2425
	[Protocol]
	public class SceneEquieUpdateReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D99 RID: 28057 RVA: 0x0013E210 File Offset: 0x0013C610
		public uint GetMsgID()
		{
			return 501048U;
		}

		// Token: 0x06006D9A RID: 28058 RVA: 0x0013E217 File Offset: 0x0013C617
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D9B RID: 28059 RVA: 0x0013E21F File Offset: 0x0013C61F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D9C RID: 28060 RVA: 0x0013E228 File Offset: 0x0013C628
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006D9D RID: 28061 RVA: 0x0013E238 File Offset: 0x0013C638
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006D9E RID: 28062 RVA: 0x0013E248 File Offset: 0x0013C648
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006D9F RID: 28063 RVA: 0x0013E258 File Offset: 0x0013C658
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006DA0 RID: 28064 RVA: 0x0013E268 File Offset: 0x0013C668
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400319F RID: 12703
		public const uint MsgID = 501048U;

		// Token: 0x040031A0 RID: 12704
		public uint Sequence;

		// Token: 0x040031A1 RID: 12705
		public ulong equipUid;
	}
}
