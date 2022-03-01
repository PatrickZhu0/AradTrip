using System;

namespace Protocol
{
	// Token: 0x02000CB9 RID: 3257
	[Protocol]
	public class WorldAutomaticFinishSchoolRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008638 RID: 34360 RVA: 0x001774F4 File Offset: 0x001758F4
		public uint GetMsgID()
		{
			return 601773U;
		}

		// Token: 0x06008639 RID: 34361 RVA: 0x001774FB File Offset: 0x001758FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600863A RID: 34362 RVA: 0x00177503 File Offset: 0x00175903
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600863B RID: 34363 RVA: 0x0017750C File Offset: 0x0017590C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600863C RID: 34364 RVA: 0x0017751C File Offset: 0x0017591C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600863D RID: 34365 RVA: 0x0017752C File Offset: 0x0017592C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600863E RID: 34366 RVA: 0x0017753C File Offset: 0x0017593C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600863F RID: 34367 RVA: 0x0017754C File Offset: 0x0017594C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400403E RID: 16446
		public const uint MsgID = 601773U;

		// Token: 0x0400403F RID: 16447
		public uint Sequence;

		// Token: 0x04004040 RID: 16448
		public uint code;
	}
}
