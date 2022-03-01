using System;

namespace Protocol
{
	// Token: 0x0200095E RID: 2398
	[Protocol]
	public class SceneMountPreciousBeadReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CB2 RID: 27826 RVA: 0x0013C3D8 File Offset: 0x0013A7D8
		public uint GetMsgID()
		{
			return 501033U;
		}

		// Token: 0x06006CB3 RID: 27827 RVA: 0x0013C3DF File Offset: 0x0013A7DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CB4 RID: 27828 RVA: 0x0013C3E7 File Offset: 0x0013A7E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CB5 RID: 27829 RVA: 0x0013C3F0 File Offset: 0x0013A7F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CB6 RID: 27830 RVA: 0x0013C41C File Offset: 0x0013A81C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CB7 RID: 27831 RVA: 0x0013C448 File Offset: 0x0013A848
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
		}

		// Token: 0x06006CB8 RID: 27832 RVA: 0x0013C474 File Offset: 0x0013A874
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
		}

		// Token: 0x06006CB9 RID: 27833 RVA: 0x0013C4A0 File Offset: 0x0013A8A0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 1;
		}

		// Token: 0x0400312E RID: 12590
		public const uint MsgID = 501033U;

		// Token: 0x0400312F RID: 12591
		public uint Sequence;

		// Token: 0x04003130 RID: 12592
		public ulong preciousBeadUid;

		// Token: 0x04003131 RID: 12593
		public ulong itemUid;

		// Token: 0x04003132 RID: 12594
		public byte holeIndex;
	}
}
