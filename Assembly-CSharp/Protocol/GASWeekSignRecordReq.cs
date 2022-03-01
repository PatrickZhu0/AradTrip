using System;

namespace Protocol
{
	// Token: 0x02000A45 RID: 2629
	[Protocol]
	public class GASWeekSignRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073CF RID: 29647 RVA: 0x0014FF08 File Offset: 0x0014E308
		public uint GetMsgID()
		{
			return 707401U;
		}

		// Token: 0x060073D0 RID: 29648 RVA: 0x0014FF0F File Offset: 0x0014E30F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073D1 RID: 29649 RVA: 0x0014FF17 File Offset: 0x0014E317
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073D2 RID: 29650 RVA: 0x0014FF20 File Offset: 0x0014E320
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
		}

		// Token: 0x060073D3 RID: 29651 RVA: 0x0014FF30 File Offset: 0x0014E330
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
		}

		// Token: 0x060073D4 RID: 29652 RVA: 0x0014FF40 File Offset: 0x0014E340
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
		}

		// Token: 0x060073D5 RID: 29653 RVA: 0x0014FF50 File Offset: 0x0014E350
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
		}

		// Token: 0x060073D6 RID: 29654 RVA: 0x0014FF60 File Offset: 0x0014E360
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040035BD RID: 13757
		public const uint MsgID = 707401U;

		// Token: 0x040035BE RID: 13758
		public uint Sequence;

		// Token: 0x040035BF RID: 13759
		public uint opActType;
	}
}
