using System;

namespace Protocol
{
	// Token: 0x02000AA5 RID: 2725
	[Protocol]
	public class RelaySvrObserveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060076AE RID: 30382 RVA: 0x00156F54 File Offset: 0x00155354
		public uint GetMsgID()
		{
			return 1300023U;
		}

		// Token: 0x060076AF RID: 30383 RVA: 0x00156F5B File Offset: 0x0015535B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060076B0 RID: 30384 RVA: 0x00156F63 File Offset: 0x00155363
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060076B1 RID: 30385 RVA: 0x00156F6C File Offset: 0x0015536C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060076B2 RID: 30386 RVA: 0x00156F7C File Offset: 0x0015537C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060076B3 RID: 30387 RVA: 0x00156F8C File Offset: 0x0015538C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060076B4 RID: 30388 RVA: 0x00156F9C File Offset: 0x0015539C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060076B5 RID: 30389 RVA: 0x00156FAC File Offset: 0x001553AC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003778 RID: 14200
		public const uint MsgID = 1300023U;

		// Token: 0x04003779 RID: 14201
		public uint Sequence;

		// Token: 0x0400377A RID: 14202
		public uint result;
	}
}
