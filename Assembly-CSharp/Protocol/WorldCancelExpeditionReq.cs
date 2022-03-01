using System;

namespace Protocol
{
	// Token: 0x020006A6 RID: 1702
	[Protocol]
	public class WorldCancelExpeditionReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057E9 RID: 22505 RVA: 0x0010BCB9 File Offset: 0x0010A0B9
		public uint GetMsgID()
		{
			return 608617U;
		}

		// Token: 0x060057EA RID: 22506 RVA: 0x0010BCC0 File Offset: 0x0010A0C0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057EB RID: 22507 RVA: 0x0010BCC8 File Offset: 0x0010A0C8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057EC RID: 22508 RVA: 0x0010BCD1 File Offset: 0x0010A0D1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x060057ED RID: 22509 RVA: 0x0010BCE1 File Offset: 0x0010A0E1
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x060057EE RID: 22510 RVA: 0x0010BCF1 File Offset: 0x0010A0F1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x060057EF RID: 22511 RVA: 0x0010BD01 File Offset: 0x0010A101
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x060057F0 RID: 22512 RVA: 0x0010BD14 File Offset: 0x0010A114
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040022FC RID: 8956
		public const uint MsgID = 608617U;

		// Token: 0x040022FD RID: 8957
		public uint Sequence;

		// Token: 0x040022FE RID: 8958
		public byte mapId;
	}
}
