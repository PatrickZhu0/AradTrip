using System;

namespace Protocol
{
	// Token: 0x020009EC RID: 2540
	[Protocol]
	public class WorldMatchStartReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007138 RID: 28984 RVA: 0x00146D73 File Offset: 0x00145173
		public uint GetMsgID()
		{
			return 506701U;
		}

		// Token: 0x06007139 RID: 28985 RVA: 0x00146D7A File Offset: 0x0014517A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600713A RID: 28986 RVA: 0x00146D82 File Offset: 0x00145182
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600713B RID: 28987 RVA: 0x00146D8B File Offset: 0x0014518B
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600713C RID: 28988 RVA: 0x00146D9B File Offset: 0x0014519B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600713D RID: 28989 RVA: 0x00146DAB File Offset: 0x001451AB
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600713E RID: 28990 RVA: 0x00146DBB File Offset: 0x001451BB
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600713F RID: 28991 RVA: 0x00146DCC File Offset: 0x001451CC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040033BF RID: 13247
		public const uint MsgID = 506701U;

		// Token: 0x040033C0 RID: 13248
		public uint Sequence;

		// Token: 0x040033C1 RID: 13249
		public byte type;
	}
}
