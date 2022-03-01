using System;

namespace Protocol
{
	// Token: 0x02000A9D RID: 2717
	[Protocol]
	public class RelaySvrRaceEndNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007666 RID: 30310 RVA: 0x001567F2 File Offset: 0x00154BF2
		public uint GetMsgID()
		{
			return 1300009U;
		}

		// Token: 0x06007667 RID: 30311 RVA: 0x001567F9 File Offset: 0x00154BF9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007668 RID: 30312 RVA: 0x00156801 File Offset: 0x00154C01
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007669 RID: 30313 RVA: 0x0015680A File Offset: 0x00154C0A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
		}

		// Token: 0x0600766A RID: 30314 RVA: 0x0015681A File Offset: 0x00154C1A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
		}

		// Token: 0x0600766B RID: 30315 RVA: 0x0015682A File Offset: 0x00154C2A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
		}

		// Token: 0x0600766C RID: 30316 RVA: 0x0015683A File Offset: 0x00154C3A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
		}

		// Token: 0x0600766D RID: 30317 RVA: 0x0015684C File Offset: 0x00154C4C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003756 RID: 14166
		public const uint MsgID = 1300009U;

		// Token: 0x04003757 RID: 14167
		public uint Sequence;

		// Token: 0x04003758 RID: 14168
		public byte reason;
	}
}
