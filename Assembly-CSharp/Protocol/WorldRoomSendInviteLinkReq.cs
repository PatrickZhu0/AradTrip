using System;

namespace Protocol
{
	// Token: 0x02000AF6 RID: 2806
	[Protocol]
	public class WorldRoomSendInviteLinkReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078F1 RID: 30961 RVA: 0x0015CB98 File Offset: 0x0015AF98
		public uint GetMsgID()
		{
			return 607841U;
		}

		// Token: 0x060078F2 RID: 30962 RVA: 0x0015CB9F File Offset: 0x0015AF9F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078F3 RID: 30963 RVA: 0x0015CBA7 File Offset: 0x0015AFA7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078F4 RID: 30964 RVA: 0x0015CBB0 File Offset: 0x0015AFB0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
		}

		// Token: 0x060078F5 RID: 30965 RVA: 0x0015CBCE File Offset: 0x0015AFCE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
		}

		// Token: 0x060078F6 RID: 30966 RVA: 0x0015CBEC File Offset: 0x0015AFEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
		}

		// Token: 0x060078F7 RID: 30967 RVA: 0x0015CC0A File Offset: 0x0015B00A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
		}

		// Token: 0x060078F8 RID: 30968 RVA: 0x0015CC28 File Offset: 0x0015B028
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400390B RID: 14603
		public const uint MsgID = 607841U;

		// Token: 0x0400390C RID: 14604
		public uint Sequence;

		// Token: 0x0400390D RID: 14605
		public uint roomId;

		// Token: 0x0400390E RID: 14606
		public byte channel;
	}
}
