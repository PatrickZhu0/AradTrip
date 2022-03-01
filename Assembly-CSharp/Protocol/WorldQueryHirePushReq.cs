using System;

namespace Protocol
{
	// Token: 0x02000C46 RID: 3142
	[Protocol]
	public class WorldQueryHirePushReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082CF RID: 33487 RVA: 0x001702B0 File Offset: 0x0016E6B0
		public uint GetMsgID()
		{
			return 601796U;
		}

		// Token: 0x060082D0 RID: 33488 RVA: 0x001702B7 File Offset: 0x0016E6B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082D1 RID: 33489 RVA: 0x001702BF File Offset: 0x0016E6BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082D2 RID: 33490 RVA: 0x001702C8 File Offset: 0x0016E6C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060082D3 RID: 33491 RVA: 0x001702D8 File Offset: 0x0016E6D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060082D4 RID: 33492 RVA: 0x001702E8 File Offset: 0x0016E6E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060082D5 RID: 33493 RVA: 0x001702F8 File Offset: 0x0016E6F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060082D6 RID: 33494 RVA: 0x00170308 File Offset: 0x0016E708
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003E6F RID: 15983
		public const uint MsgID = 601796U;

		// Token: 0x04003E70 RID: 15984
		public uint Sequence;

		// Token: 0x04003E71 RID: 15985
		public byte type;
	}
}
