using System;

namespace Protocol
{
	// Token: 0x02000A15 RID: 2581
	[Protocol]
	public class WorldMonopolySellCardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600727F RID: 29311 RVA: 0x0014B8ED File Offset: 0x00149CED
		public uint GetMsgID()
		{
			return 610211U;
		}

		// Token: 0x06007280 RID: 29312 RVA: 0x0014B8F4 File Offset: 0x00149CF4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007281 RID: 29313 RVA: 0x0014B8FC File Offset: 0x00149CFC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007282 RID: 29314 RVA: 0x0014B905 File Offset: 0x00149D05
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06007283 RID: 29315 RVA: 0x0014B923 File Offset: 0x00149D23
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007284 RID: 29316 RVA: 0x0014B941 File Offset: 0x00149D41
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06007285 RID: 29317 RVA: 0x0014B95F File Offset: 0x00149D5F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007286 RID: 29318 RVA: 0x0014B980 File Offset: 0x00149D80
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400349A RID: 13466
		public const uint MsgID = 610211U;

		// Token: 0x0400349B RID: 13467
		public uint Sequence;

		// Token: 0x0400349C RID: 13468
		public uint id;

		// Token: 0x0400349D RID: 13469
		public uint num;
	}
}
