using System;

namespace Protocol
{
	// Token: 0x02000960 RID: 2400
	[Protocol]
	public class SceneExtirpePreciousBeadReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CC4 RID: 27844 RVA: 0x0013C5EC File Offset: 0x0013A9EC
		public uint GetMsgID()
		{
			return 501035U;
		}

		// Token: 0x06006CC5 RID: 27845 RVA: 0x0013C5F3 File Offset: 0x0013A9F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CC6 RID: 27846 RVA: 0x0013C5FB File Offset: 0x0013A9FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CC7 RID: 27847 RVA: 0x0013C604 File Offset: 0x0013AA04
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pestleId);
		}

		// Token: 0x06006CC8 RID: 27848 RVA: 0x0013C630 File Offset: 0x0013AA30
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pestleId);
		}

		// Token: 0x06006CC9 RID: 27849 RVA: 0x0013C65C File Offset: 0x0013AA5C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.holeIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pestleId);
		}

		// Token: 0x06006CCA RID: 27850 RVA: 0x0013C688 File Offset: 0x0013AA88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.holeIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pestleId);
		}

		// Token: 0x06006CCB RID: 27851 RVA: 0x0013C6B4 File Offset: 0x0013AAB4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 4;
		}

		// Token: 0x04003139 RID: 12601
		public const uint MsgID = 501035U;

		// Token: 0x0400313A RID: 12602
		public uint Sequence;

		// Token: 0x0400313B RID: 12603
		public ulong itemUid;

		// Token: 0x0400313C RID: 12604
		public byte holeIndex;

		// Token: 0x0400313D RID: 12605
		public uint pestleId;
	}
}
