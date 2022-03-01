using System;

namespace Protocol
{
	// Token: 0x0200084D RID: 2125
	[Protocol]
	public class WorldGuildTableJoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006427 RID: 25639 RVA: 0x0012B5F8 File Offset: 0x001299F8
		public uint GetMsgID()
		{
			return 601937U;
		}

		// Token: 0x06006428 RID: 25640 RVA: 0x0012B5FF File Offset: 0x001299FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006429 RID: 25641 RVA: 0x0012B607 File Offset: 0x00129A07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600642A RID: 25642 RVA: 0x0012B610 File Offset: 0x00129A10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600642B RID: 25643 RVA: 0x0012B62E File Offset: 0x00129A2E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600642C RID: 25644 RVA: 0x0012B64C File Offset: 0x00129A4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x0600642D RID: 25645 RVA: 0x0012B66A File Offset: 0x00129A6A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x0600642E RID: 25646 RVA: 0x0012B688 File Offset: 0x00129A88
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002CE5 RID: 11493
		public const uint MsgID = 601937U;

		// Token: 0x04002CE6 RID: 11494
		public uint Sequence;

		// Token: 0x04002CE7 RID: 11495
		public byte seat;

		// Token: 0x04002CE8 RID: 11496
		public byte type;
	}
}
