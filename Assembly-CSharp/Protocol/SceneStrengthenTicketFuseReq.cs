using System;

namespace Protocol
{
	// Token: 0x0200095C RID: 2396
	[Protocol]
	public class SceneStrengthenTicketFuseReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CA0 RID: 27808 RVA: 0x0013C2B4 File Offset: 0x0013A6B4
		public uint GetMsgID()
		{
			return 501037U;
		}

		// Token: 0x06006CA1 RID: 27809 RVA: 0x0013C2BB File Offset: 0x0013A6BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CA2 RID: 27810 RVA: 0x0013C2C3 File Offset: 0x0013A6C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CA3 RID: 27811 RVA: 0x0013C2CC File Offset: 0x0013A6CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.pickTicketA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.pickTicketB);
		}

		// Token: 0x06006CA4 RID: 27812 RVA: 0x0013C2EA File Offset: 0x0013A6EA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.pickTicketA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.pickTicketB);
		}

		// Token: 0x06006CA5 RID: 27813 RVA: 0x0013C308 File Offset: 0x0013A708
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.pickTicketA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.pickTicketB);
		}

		// Token: 0x06006CA6 RID: 27814 RVA: 0x0013C326 File Offset: 0x0013A726
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.pickTicketA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.pickTicketB);
		}

		// Token: 0x06006CA7 RID: 27815 RVA: 0x0013C344 File Offset: 0x0013A744
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04003127 RID: 12583
		public const uint MsgID = 501037U;

		// Token: 0x04003128 RID: 12584
		public uint Sequence;

		// Token: 0x04003129 RID: 12585
		public ulong pickTicketA;

		// Token: 0x0400312A RID: 12586
		public ulong pickTicketB;
	}
}
