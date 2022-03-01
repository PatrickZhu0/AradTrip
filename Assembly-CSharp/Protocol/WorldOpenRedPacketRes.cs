using System;

namespace Protocol
{
	// Token: 0x02000A84 RID: 2692
	[Protocol]
	public class WorldOpenRedPacketRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075B2 RID: 30130 RVA: 0x0015464B File Offset: 0x00152A4B
		public uint GetMsgID()
		{
			return 607309U;
		}

		// Token: 0x060075B3 RID: 30131 RVA: 0x00154652 File Offset: 0x00152A52
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075B4 RID: 30132 RVA: 0x0015465A File Offset: 0x00152A5A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075B5 RID: 30133 RVA: 0x00154663 File Offset: 0x00152A63
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.detail.encode(buffer, ref pos_);
		}

		// Token: 0x060075B6 RID: 30134 RVA: 0x00154680 File Offset: 0x00152A80
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.detail.decode(buffer, ref pos_);
		}

		// Token: 0x060075B7 RID: 30135 RVA: 0x0015469D File Offset: 0x00152A9D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.detail.encode(buffer, ref pos_);
		}

		// Token: 0x060075B8 RID: 30136 RVA: 0x001546BA File Offset: 0x00152ABA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.detail.decode(buffer, ref pos_);
		}

		// Token: 0x060075B9 RID: 30137 RVA: 0x001546D8 File Offset: 0x00152AD8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.detail.getLen();
		}

		// Token: 0x040036CB RID: 14027
		public const uint MsgID = 607309U;

		// Token: 0x040036CC RID: 14028
		public uint Sequence;

		// Token: 0x040036CD RID: 14029
		public uint result;

		// Token: 0x040036CE RID: 14030
		public RedPacketDetail detail = new RedPacketDetail();
	}
}
