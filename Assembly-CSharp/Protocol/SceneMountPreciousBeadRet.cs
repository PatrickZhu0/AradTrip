using System;

namespace Protocol
{
	// Token: 0x0200095F RID: 2399
	[Protocol]
	public class SceneMountPreciousBeadRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CBB RID: 27835 RVA: 0x0013C4C4 File Offset: 0x0013A8C4
		public uint GetMsgID()
		{
			return 501034U;
		}

		// Token: 0x06006CBC RID: 27836 RVA: 0x0013C4CB File Offset: 0x0013A8CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CBD RID: 27837 RVA: 0x0013C4D3 File Offset: 0x0013A8D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CBE RID: 27838 RVA: 0x0013C4DC File Offset: 0x0013A8DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CBF RID: 27839 RVA: 0x0013C516 File Offset: 0x0013A916
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CC0 RID: 27840 RVA: 0x0013C550 File Offset: 0x0013A950
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CC1 RID: 27841 RVA: 0x0013C58A File Offset: 0x0013A98A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CC2 RID: 27842 RVA: 0x0013C5C4 File Offset: 0x0013A9C4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003133 RID: 12595
		public const uint MsgID = 501034U;

		// Token: 0x04003134 RID: 12596
		public uint Sequence;

		// Token: 0x04003135 RID: 12597
		public uint code;

		// Token: 0x04003136 RID: 12598
		public uint preciousBeadId;

		// Token: 0x04003137 RID: 12599
		public ulong itemUid;

		// Token: 0x04003138 RID: 12600
		public byte holeIndex;
	}
}
