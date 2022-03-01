using System;

namespace Protocol
{
	// Token: 0x02000C94 RID: 3220
	[Protocol]
	public class WorldAddToBlackList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084EE RID: 34030 RVA: 0x001751FC File Offset: 0x001735FC
		public uint GetMsgID()
		{
			return 601703U;
		}

		// Token: 0x060084EF RID: 34031 RVA: 0x00175203 File Offset: 0x00173603
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084F0 RID: 34032 RVA: 0x0017520B File Offset: 0x0017360B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084F1 RID: 34033 RVA: 0x00175214 File Offset: 0x00173614
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.tarUid);
		}

		// Token: 0x060084F2 RID: 34034 RVA: 0x00175224 File Offset: 0x00173624
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tarUid);
		}

		// Token: 0x060084F3 RID: 34035 RVA: 0x00175234 File Offset: 0x00173634
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.tarUid);
		}

		// Token: 0x060084F4 RID: 34036 RVA: 0x00175244 File Offset: 0x00173644
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.tarUid);
		}

		// Token: 0x060084F5 RID: 34037 RVA: 0x00175254 File Offset: 0x00173654
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003FBA RID: 16314
		public const uint MsgID = 601703U;

		// Token: 0x04003FBB RID: 16315
		public uint Sequence;

		// Token: 0x04003FBC RID: 16316
		public ulong tarUid;
	}
}
