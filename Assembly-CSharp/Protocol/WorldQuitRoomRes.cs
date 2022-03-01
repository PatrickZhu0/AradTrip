using System;

namespace Protocol
{
	// Token: 0x02000AE1 RID: 2785
	[Protocol]
	public class WorldQuitRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007834 RID: 30772 RVA: 0x0015C020 File Offset: 0x0015A420
		public uint GetMsgID()
		{
			return 607818U;
		}

		// Token: 0x06007835 RID: 30773 RVA: 0x0015C027 File Offset: 0x0015A427
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007836 RID: 30774 RVA: 0x0015C02F File Offset: 0x0015A42F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007837 RID: 30775 RVA: 0x0015C038 File Offset: 0x0015A438
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007838 RID: 30776 RVA: 0x0015C048 File Offset: 0x0015A448
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007839 RID: 30777 RVA: 0x0015C058 File Offset: 0x0015A458
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600783A RID: 30778 RVA: 0x0015C068 File Offset: 0x0015A468
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600783B RID: 30779 RVA: 0x0015C078 File Offset: 0x0015A478
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038C4 RID: 14532
		public const uint MsgID = 607818U;

		// Token: 0x040038C5 RID: 14533
		public uint Sequence;

		// Token: 0x040038C6 RID: 14534
		public uint result;
	}
}
