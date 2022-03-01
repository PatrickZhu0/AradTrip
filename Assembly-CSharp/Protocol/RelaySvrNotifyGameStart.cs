using System;

namespace Protocol
{
	// Token: 0x02000A8E RID: 2702
	[Protocol]
	public class RelaySvrNotifyGameStart : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075FA RID: 30202 RVA: 0x00155180 File Offset: 0x00153580
		public uint GetMsgID()
		{
			return 1300003U;
		}

		// Token: 0x060075FB RID: 30203 RVA: 0x00155187 File Offset: 0x00153587
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075FC RID: 30204 RVA: 0x0015518F File Offset: 0x0015358F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075FD RID: 30205 RVA: 0x00155198 File Offset: 0x00153598
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint64(buffer, ref pos_, this.startTime);
		}

		// Token: 0x060075FE RID: 30206 RVA: 0x001551B6 File Offset: 0x001535B6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.startTime);
		}

		// Token: 0x060075FF RID: 30207 RVA: 0x001551D4 File Offset: 0x001535D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint64(buffer, ref pos_, this.startTime);
		}

		// Token: 0x06007600 RID: 30208 RVA: 0x001551F2 File Offset: 0x001535F2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.startTime);
		}

		// Token: 0x06007601 RID: 30209 RVA: 0x00155210 File Offset: 0x00153610
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04003715 RID: 14101
		public const uint MsgID = 1300003U;

		// Token: 0x04003716 RID: 14102
		public uint Sequence;

		// Token: 0x04003717 RID: 14103
		public ulong session;

		// Token: 0x04003718 RID: 14104
		public ulong startTime;
	}
}
