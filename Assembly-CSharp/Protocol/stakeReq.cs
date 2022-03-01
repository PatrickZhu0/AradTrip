using System;

namespace Protocol
{
	// Token: 0x02000739 RID: 1849
	[Protocol]
	public class stakeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C4A RID: 23626 RVA: 0x00116BA9 File Offset: 0x00114FA9
		public uint GetMsgID()
		{
			return 708307U;
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x00116BB0 File Offset: 0x00114FB0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x00116BB8 File Offset: 0x00114FB8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C4D RID: 23629 RVA: 0x00116BC1 File Offset: 0x00114FC1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005C4E RID: 23630 RVA: 0x00116BDF File Offset: 0x00114FDF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005C4F RID: 23631 RVA: 0x00116BFD File Offset: 0x00114FFD
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06005C50 RID: 23632 RVA: 0x00116C1B File Offset: 0x0011501B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005C51 RID: 23633 RVA: 0x00116C3C File Offset: 0x0011503C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025AD RID: 9645
		public const uint MsgID = 708307U;

		// Token: 0x040025AE RID: 9646
		public uint Sequence;

		// Token: 0x040025AF RID: 9647
		public uint id;

		// Token: 0x040025B0 RID: 9648
		public uint num;
	}
}
