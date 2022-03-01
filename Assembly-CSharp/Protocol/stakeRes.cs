using System;

namespace Protocol
{
	// Token: 0x0200073A RID: 1850
	[Protocol]
	public class stakeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C53 RID: 23635 RVA: 0x00116C5C File Offset: 0x0011505C
		public uint GetMsgID()
		{
			return 708308U;
		}

		// Token: 0x06005C54 RID: 23636 RVA: 0x00116C63 File Offset: 0x00115063
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C55 RID: 23637 RVA: 0x00116C6B File Offset: 0x0011506B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C56 RID: 23638 RVA: 0x00116C74 File Offset: 0x00115074
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005C57 RID: 23639 RVA: 0x00116CA0 File Offset: 0x001150A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005C58 RID: 23640 RVA: 0x00116CCC File Offset: 0x001150CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005C59 RID: 23641 RVA: 0x00116CF8 File Offset: 0x001150F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005C5A RID: 23642 RVA: 0x00116D24 File Offset: 0x00115124
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025B1 RID: 9649
		public const uint MsgID = 708308U;

		// Token: 0x040025B2 RID: 9650
		public uint Sequence;

		// Token: 0x040025B3 RID: 9651
		public uint ret;

		// Token: 0x040025B4 RID: 9652
		public uint id;

		// Token: 0x040025B5 RID: 9653
		public uint num;
	}
}
