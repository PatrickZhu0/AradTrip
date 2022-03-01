using System;

namespace Protocol
{
	// Token: 0x02000839 RID: 2105
	[Protocol]
	public class WorldGuildKickRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006373 RID: 25459 RVA: 0x0012A6E4 File Offset: 0x00128AE4
		public uint GetMsgID()
		{
			return 601917U;
		}

		// Token: 0x06006374 RID: 25460 RVA: 0x0012A6EB File Offset: 0x00128AEB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006375 RID: 25461 RVA: 0x0012A6F3 File Offset: 0x00128AF3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006376 RID: 25462 RVA: 0x0012A6FC File Offset: 0x00128AFC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006377 RID: 25463 RVA: 0x0012A70C File Offset: 0x00128B0C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006378 RID: 25464 RVA: 0x0012A71C File Offset: 0x00128B1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006379 RID: 25465 RVA: 0x0012A72C File Offset: 0x00128B2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600637A RID: 25466 RVA: 0x0012A73C File Offset: 0x00128B3C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002CA8 RID: 11432
		public const uint MsgID = 601917U;

		// Token: 0x04002CA9 RID: 11433
		public uint Sequence;

		// Token: 0x04002CAA RID: 11434
		public uint result;
	}
}
