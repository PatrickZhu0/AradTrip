using System;

namespace Protocol
{
	// Token: 0x0200095A RID: 2394
	[Protocol]
	public class SceneStrengthenTicketSynthesisReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C8E RID: 27790 RVA: 0x0013C1CC File Offset: 0x0013A5CC
		public uint GetMsgID()
		{
			return 501031U;
		}

		// Token: 0x06006C8F RID: 27791 RVA: 0x0013C1D3 File Offset: 0x0013A5D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C90 RID: 27792 RVA: 0x0013C1DB File Offset: 0x0013A5DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C91 RID: 27793 RVA: 0x0013C1E4 File Offset: 0x0013A5E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.synthesisPlan);
		}

		// Token: 0x06006C92 RID: 27794 RVA: 0x0013C1F4 File Offset: 0x0013A5F4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.synthesisPlan);
		}

		// Token: 0x06006C93 RID: 27795 RVA: 0x0013C204 File Offset: 0x0013A604
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.synthesisPlan);
		}

		// Token: 0x06006C94 RID: 27796 RVA: 0x0013C214 File Offset: 0x0013A614
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.synthesisPlan);
		}

		// Token: 0x06006C95 RID: 27797 RVA: 0x0013C224 File Offset: 0x0013A624
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003121 RID: 12577
		public const uint MsgID = 501031U;

		// Token: 0x04003122 RID: 12578
		public uint Sequence;

		// Token: 0x04003123 RID: 12579
		public uint synthesisPlan;
	}
}
