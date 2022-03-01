using System;

namespace Protocol
{
	// Token: 0x02000A24 RID: 2596
	[Protocol]
	public class WorldNewTitleTakeUpGuildPostReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072F7 RID: 29431 RVA: 0x0014C9C1 File Offset: 0x0014ADC1
		public uint GetMsgID()
		{
			return 609211U;
		}

		// Token: 0x060072F8 RID: 29432 RVA: 0x0014C9C8 File Offset: 0x0014ADC8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072F9 RID: 29433 RVA: 0x0014C9D0 File Offset: 0x0014ADD0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072FA RID: 29434 RVA: 0x0014C9D9 File Offset: 0x0014ADD9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060072FB RID: 29435 RVA: 0x0014C9DB File Offset: 0x0014ADDB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060072FC RID: 29436 RVA: 0x0014C9DD File Offset: 0x0014ADDD
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060072FD RID: 29437 RVA: 0x0014C9DF File Offset: 0x0014ADDF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060072FE RID: 29438 RVA: 0x0014C9E4 File Offset: 0x0014ADE4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040034D3 RID: 13523
		public const uint MsgID = 609211U;

		// Token: 0x040034D4 RID: 13524
		public uint Sequence;
	}
}
