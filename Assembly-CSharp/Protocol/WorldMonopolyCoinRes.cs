using System;

namespace Protocol
{
	// Token: 0x02000A0B RID: 2571
	[Protocol]
	public class WorldMonopolyCoinRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007228 RID: 29224 RVA: 0x0014B2C8 File Offset: 0x001496C8
		public uint GetMsgID()
		{
			return 610202U;
		}

		// Token: 0x06007229 RID: 29225 RVA: 0x0014B2CF File Offset: 0x001496CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600722A RID: 29226 RVA: 0x0014B2D7 File Offset: 0x001496D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600722B RID: 29227 RVA: 0x0014B2E0 File Offset: 0x001496E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x0600722C RID: 29228 RVA: 0x0014B2F0 File Offset: 0x001496F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600722D RID: 29229 RVA: 0x0014B300 File Offset: 0x00149700
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x0600722E RID: 29230 RVA: 0x0014B310 File Offset: 0x00149710
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600722F RID: 29231 RVA: 0x0014B320 File Offset: 0x00149720
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400347C RID: 13436
		public const uint MsgID = 610202U;

		// Token: 0x0400347D RID: 13437
		public uint Sequence;

		// Token: 0x0400347E RID: 13438
		public uint num;
	}
}
