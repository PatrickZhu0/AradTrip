using System;

namespace Protocol
{
	// Token: 0x02000B6B RID: 2923
	[Protocol]
	public class WorldSortListSelfInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C66 RID: 31846 RVA: 0x00163344 File Offset: 0x00161744
		public uint GetMsgID()
		{
			return 602610U;
		}

		// Token: 0x06007C67 RID: 31847 RVA: 0x0016334B File Offset: 0x0016174B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C68 RID: 31848 RVA: 0x00163353 File Offset: 0x00161753
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C69 RID: 31849 RVA: 0x0016335C File Offset: 0x0016175C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06007C6A RID: 31850 RVA: 0x0016336C File Offset: 0x0016176C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06007C6B RID: 31851 RVA: 0x0016337C File Offset: 0x0016177C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06007C6C RID: 31852 RVA: 0x0016338C File Offset: 0x0016178C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06007C6D RID: 31853 RVA: 0x0016339C File Offset: 0x0016179C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003AEA RID: 15082
		public const uint MsgID = 602610U;

		// Token: 0x04003AEB RID: 15083
		public uint Sequence;

		// Token: 0x04003AEC RID: 15084
		public byte type;
	}
}
