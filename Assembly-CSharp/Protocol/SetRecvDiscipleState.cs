using System;

namespace Protocol
{
	// Token: 0x02000C9A RID: 3226
	[Protocol]
	public class SetRecvDiscipleState : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008521 RID: 34081 RVA: 0x001758F0 File Offset: 0x00173CF0
		public uint GetMsgID()
		{
			return 601718U;
		}

		// Token: 0x06008522 RID: 34082 RVA: 0x001758F7 File Offset: 0x00173CF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008523 RID: 34083 RVA: 0x001758FF File Offset: 0x00173CFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008524 RID: 34084 RVA: 0x00175908 File Offset: 0x00173D08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x06008525 RID: 34085 RVA: 0x00175918 File Offset: 0x00173D18
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x06008526 RID: 34086 RVA: 0x00175928 File Offset: 0x00173D28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x06008527 RID: 34087 RVA: 0x00175938 File Offset: 0x00173D38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x06008528 RID: 34088 RVA: 0x00175948 File Offset: 0x00173D48
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003FCC RID: 16332
		public const uint MsgID = 601718U;

		// Token: 0x04003FCD RID: 16333
		public uint Sequence;

		// Token: 0x04003FCE RID: 16334
		public byte state;
	}
}
