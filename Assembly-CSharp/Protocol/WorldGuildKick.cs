using System;

namespace Protocol
{
	// Token: 0x02000838 RID: 2104
	[Protocol]
	public class WorldGuildKick : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600636A RID: 25450 RVA: 0x0012A670 File Offset: 0x00128A70
		public uint GetMsgID()
		{
			return 601916U;
		}

		// Token: 0x0600636B RID: 25451 RVA: 0x0012A677 File Offset: 0x00128A77
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600636C RID: 25452 RVA: 0x0012A67F File Offset: 0x00128A7F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600636D RID: 25453 RVA: 0x0012A688 File Offset: 0x00128A88
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600636E RID: 25454 RVA: 0x0012A698 File Offset: 0x00128A98
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600636F RID: 25455 RVA: 0x0012A6A8 File Offset: 0x00128AA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06006370 RID: 25456 RVA: 0x0012A6B8 File Offset: 0x00128AB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06006371 RID: 25457 RVA: 0x0012A6C8 File Offset: 0x00128AC8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002CA5 RID: 11429
		public const uint MsgID = 601916U;

		// Token: 0x04002CA6 RID: 11430
		public uint Sequence;

		// Token: 0x04002CA7 RID: 11431
		public ulong id;
	}
}
