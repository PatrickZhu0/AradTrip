using System;

namespace Protocol
{
	// Token: 0x02000C34 RID: 3124
	[Protocol]
	public class WorldBillingChargeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600823C RID: 33340 RVA: 0x0016F370 File Offset: 0x0016D770
		public uint GetMsgID()
		{
			return 604012U;
		}

		// Token: 0x0600823D RID: 33341 RVA: 0x0016F377 File Offset: 0x0016D777
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600823E RID: 33342 RVA: 0x0016F37F File Offset: 0x0016D77F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600823F RID: 33343 RVA: 0x0016F388 File Offset: 0x0016D788
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008240 RID: 33344 RVA: 0x0016F398 File Offset: 0x0016D798
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008241 RID: 33345 RVA: 0x0016F3A8 File Offset: 0x0016D7A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008242 RID: 33346 RVA: 0x0016F3B8 File Offset: 0x0016D7B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008243 RID: 33347 RVA: 0x0016F3C8 File Offset: 0x0016D7C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003E37 RID: 15927
		public const uint MsgID = 604012U;

		// Token: 0x04003E38 RID: 15928
		public uint Sequence;

		// Token: 0x04003E39 RID: 15929
		public uint result;
	}
}
